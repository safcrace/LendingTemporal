
using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Entities.Views;
using Core.Interfaces;
using Infrastructure.Data.DBContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace API.Controllers
{
    public class CataloguesController : BaseApiController
    {        
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _dbContext;

        public CataloguesController(IUnitOfWork unitOfWork, IMapper mapper, ApplicationDbContext dbContext)
        {            
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _dbContext = dbContext;
        }

        [HttpGet("bancos")]
        public async Task<ActionResult<IReadOnlyList<BancoDto>>> GetBancos()
        {
            var bancos = await _unitOfWork.Repository<Banco>().ListAllAsync();

            return Ok(_mapper.Map<IReadOnlyList<BancoDto>>(bancos));
        }

        [HttpGet("cajas")]
        public async Task<ActionResult<IReadOnlyList<CajaDto>>> GetCajas()
        {
            var cajas = await _unitOfWork.Repository<Caja>().ListAllAsync();

            return Ok(_mapper.Map<IReadOnlyList<CajaDto>>(cajas));
        }


        [HttpGet("estado-civil")]
        public async Task<ActionResult<IReadOnlyList<EstadoCivilDto>>> GetEstadoCivil()
        {
            var estadoCivil = await _unitOfWork.Repository<EstadoCivil>().ListAllAsync();

            return Ok(_mapper.Map<IReadOnlyList<EstadoCivilDto>>(estadoCivil));           
        }

        [HttpGet("forma_pago")]
        public async Task<ActionResult<IReadOnlyList<FormaPagoDto>>> GetFormaPago()
        {
            var formaPago = await _unitOfWork.Repository<FormaPago>().ListAllAsync();

            return Ok(_mapper.Map<IReadOnlyList<FormaPagoDto>>(formaPago));
        }

        [HttpGet("tipo-prestamo")]
        public async Task<ActionResult<IReadOnlyList<TipoPrestamoDto>>> GetTipoPrestamo()
        {
            var tipoPrestamo = await _unitOfWork.Repository<TipoPrestamo>().ListAllAsync();

            return Ok(_mapper.Map<IReadOnlyList<TipoPrestamoDto>>(tipoPrestamo));
        }

        [HttpGet("destino-prestamo")]
        public async Task<ActionResult<IReadOnlyList<DestinoPrestamoDto>>> GetDestinoPrestamo()
        {
            var destinoPrestamo = await _unitOfWork.Repository<DestinoPrestamo>().ListAllAsync();

            return Ok(_mapper.Map<IReadOnlyList<DestinoPrestamoDto>>(destinoPrestamo));
        }

        [HttpGet("gestores")]
        public async Task<ActionResult<IReadOnlyList<ListadoAsesor>>> GetGestores()
        {
            return await _dbContext.Set<ListadoAsesor>().ToListAsync();            
        }


    }
}
