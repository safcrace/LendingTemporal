using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Infrastructure.Data.DBContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController, Route("api/tipo_prestamo")]
public class TipoPrestamoController : ControllerBase
{
    private readonly IUnitOfWork repository;
    private readonly IMapper mapper;
    private readonly ApplicationDbContext _dbContext;

    public TipoPrestamoController(IUnitOfWork repository, IMapper mapper, ApplicationDbContext dbContext)
    {
        this.repository = repository;
        this.mapper = mapper;
        _dbContext = dbContext;
    }

    [HttpGet]
    public async Task<ActionResult> GetAll()
    {
        var tipos = await repository.TipoPrestamo.ListAllAsync();

        var tiposCredito = this.mapper.Map<List<ListadoTiposCreditoDto>>(tipos);

        foreach (var tipo in tiposCredito)
        {
            tipo.TipoCuota = await _dbContext.TipoCuotas.Where(x => x.Id == tipo.TipoCuotaId).Select(x => x.Nombre).FirstOrDefaultAsync();
            tipo.Moneda = await _dbContext.Monedas.Where(x => x.Id == tipo.MonedaId).Select(x => x.Nombre).FirstOrDefaultAsync();
        }

        return Ok(tiposCredito);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<IEnumerable<object>>> GetById(int id)
    {

        var tipo = await repository.TipoPrestamo.GetByIdAsync(id);

        var nombreMoneda = await _dbContext.Monedas.Where(x => x.Id == tipo.MonedaId).Select(x => x.Nombre).FirstOrDefaultAsync();
        var nombreTipoCuota = await _dbContext.TipoCuotas.Where(x => x.Id == tipo.TipoCuotaId).Select(x => x.Nombre).FirstOrDefaultAsync();
        

        if (tipo == null) return NotFound();

        var tipoPrestamo = mapper.Map<TipoPrestamoDto>(tipo);

        var intereses = await _dbContext.InteresesDepartamentos.Where(x => x.TipoPrestamoId == tipoPrestamo.Id).ToListAsync();       
        var interesesDepartamentos = this.mapper.Map<List<InteresesDepartamentosDto>>(intereses);        
        var mora = await _dbContext.MoraDepartamentos.Where(x => x.TipoPrestamoId == tipoPrestamo.Id).ToListAsync();
        var moraDepartamentos = this.mapper.Map<List<MoraDepartamentosDto>>(mora);
        var parametros = await _dbContext.ParametrosDepartamentos.Where(x => x.TipoPrestamoId == tipoPrestamo.Id).ToListAsync();        
        var parametrosDepartamentos = this.mapper.Map<List<ParametrosDepartamentosDto>>(parametros);
        var documentos = await _dbContext.DocumentosPrestamos.Where(x => x.TipoPrestamoId == tipoPrestamo.Id).ToListAsync();
        var documentosPrestamo = this.mapper.Map<List<DocumentoPrestamoDto>>(documentos);







        ////var dtos = new List<TipoPrestamoDto>();

        return Ok(new { tipoPrestamo, nombreMoneda, nombreTipoCuota, interesesDepartamentos, moraDepartamentos, parametrosDepartamentos, documentosPrestamo });
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

            await UpdateComplements(id);

            mapper.Map(tipoPrestamoDto, tipoPrestamo);
            _dbContext.TipoPrestamos.Update(tipoPrestamo);
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

    private async Task UpdateComplements(int id)
    {
        await _dbContext.Database.ExecuteSqlInterpolatedAsync($@"Delete From
                                                                        InteresesDepartamentos
                                                                     Where
                                                                        TipoPrestamoId = {id}");

        await _dbContext.Database.ExecuteSqlInterpolatedAsync($@"Delete From
                                                                        MoraDepartamentos
                                                                     Where
                                                                        TipoPrestamoId = {id}");

        await _dbContext.Database.ExecuteSqlInterpolatedAsync($@"Delete From
                                                                        ParametrosDepartamentos
                                                                     Where
                                                                        TipoPrestamoId = {id}");

        await _dbContext.Database.ExecuteSqlInterpolatedAsync($@"Delete From
                                                                        DocumentosPrestamos
                                                                     Where
                                                                        TipoPrestamoId = {id}");
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

    private async Task<List<string>> GetDocuments(int prestamoId)
    {
        var documentos = await repository.Repository<DocumentosPrestamo>()
            .ListAsync(new BaseSpecification<DocumentosPrestamo>(x => x.TipoPrestamoId == prestamoId));

        return documentos.Select(x => x.Nombre).ToList();
    }

    private async Task<CatalogDto> GetMoneda(int monedaId)
    {
        var moneda = await repository.Repository<Moneda>().GetByIdAsync(monedaId);

        return mapper.Map<CatalogDto>(moneda);
    }
}