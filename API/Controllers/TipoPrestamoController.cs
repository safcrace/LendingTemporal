using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Entities.Configuration;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace API.Controllers;

[ApiController, Route("api/tipo_prestamo")]
public class TipoPrestamoController : ControllerBase
{
    private readonly IUnitOfWork repository;
    private readonly IMapper mapper;

    public TipoPrestamoController(IUnitOfWork repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult> Get([FromQuery, BindRequired] string filter = "all")
    {
        var validFilters = new[] { "all", "personas", "organizaciones" };
        if (!validFilters.Contains(filter.ToLower()))
            return new BadRequestObjectResult($"El filtro {filter} no es válido. Los filtros válidos son: {string.Join(", ", validFilters)}");

        var prestamos = await repository.TipoPrestamo.ListAllAsync();

        var dtos = mapper.Map<List<TipoPrestamoListDto>>(prestamos);

        return Ok(dtos);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetById(int id)
    {
        var prestamo = await repository.TipoPrestamo.GetByIdAsync(id);

        if (prestamo == null) return NotFound();

        var moneda = await repository.Repository<Moneda>().GetByIdAsync(prestamo.CurrencyId);
        var documentos = await repository.Repository<DocumentosPrestamo>()
            .ListAsync(new BaseSpecification<DocumentosPrestamo>(x => x.TipoPrestamoId == id));

        var dto = mapper.Map<TipoPrestamoDto>(prestamo);
        dto.Moneda = mapper.Map<CatalogDto>(moneda);
        dto.DocumentosRequeridos = mapper.Map<List<DocumentoPrestamoDto>>(documentos);

        return Ok(dto);
    }

    [HttpGet("moneda")]
    public async Task<ActionResult> GetCurrencies()
    {
        var currencies = await repository.Repository<Moneda>().ListAllAsync();

        var dtos = mapper.Map<List<CatalogDto>>(currencies);

        return Ok(dtos);
    }

    [HttpPost]
    public async Task<ActionResult> Post(CreateTipoPrestamoDto tipoPrestamoDto)
    {
        try
        {
            var tipoPrestamo = mapper.Map<TipoPrestamo>(tipoPrestamoDto);

            repository.TipoPrestamo.Add(tipoPrestamo);
            var result = await repository.Complete();

            if (result <= 0) return new BadRequestObjectResult("No se pudo crear el tipo de préstamo");

            return Ok(new { message = "Tipo de préstamo creado con éxito", tipoPrestamo.Id });
        }
        catch (Exception e)
        {
            return e.InnerException != null
                ? new BadRequestObjectResult(e.InnerException.Message)
                : new BadRequestObjectResult(e.Message);
        }
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> Put(int id, UpdateTipoPrestamoDto tipoPrestamoDto)
    {
        try
        {
            var tipoPrestamo = await repository.TipoPrestamo.GetByIdAsync(id);

            if (tipoPrestamo == null) return NotFound();
            var docs = await repository.Repository<DocumentosPrestamo>().ListAllAsync();

            repository.Repository<DocumentosPrestamo>().DeleteRange(docs);

            mapper.Map(tipoPrestamoDto, tipoPrestamo);
            repository.TipoPrestamo.Update(tipoPrestamo);
            var result = await repository.Complete();

            if (result <= 0) return new BadRequestObjectResult("No se pudo actualizar el tipo de préstamo");

            return Ok(new { message = "Tipo de préstamo actualizado con éxito", tipoPrestamo.Id });
        }
        catch (Exception e)
        {
            return e.InnerException != null
                ? new BadRequestObjectResult(e.InnerException.Message)
                : new BadRequestObjectResult(e.Message);
        }
    }

    [HttpPut("{id:int}/toggle")]
    public async Task<ActionResult> Toggle(int id)
    {
        try
        {
            var tipoPrestamo = await repository.TipoPrestamo.GetByIdAsync(id);

            if (tipoPrestamo == null) return NotFound();

            tipoPrestamo.Habilitado = !tipoPrestamo.Habilitado;

            repository.TipoPrestamo.Update(tipoPrestamo);
            var result = await repository.Complete();

            if (result <= 0) return new BadRequestObjectResult("No se pudo actualizar el tipo de préstamo");

            var message = tipoPrestamo.Habilitado ? "Tipo de préstamo habilitado con éxito" : "Tipo de préstamo deshabilitado con éxito";
            return Ok(new { message, tipoPrestamo.Id });
        }
        catch (Exception e)
        {
            return e.InnerException != null
                ? new BadRequestObjectResult(e.InnerException.Message)
                : new BadRequestObjectResult(e.Message);
        }
    }
}