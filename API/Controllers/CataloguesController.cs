
using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Entities.Views;
using Core.Interfaces;
using Infrastructure.Data.DBContext;
using Infrastructure.Data.Services;
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

        [HttpGet("empresaPlanilla")]
        public async Task<ActionResult<IReadOnlyList<ListadoEmpresaPlanilla>>> GetEmpresasPlanilla()
        {
            return await _dbContext.Set<ListadoEmpresaPlanilla>().ToListAsync();
        }

        [HttpGet("ajuste_plan-pago")]
        public async Task<ActionResult<IReadOnlyList<object>>> GetAjustesPlanPago()
        {
            return await _dbContext.TipoTransaccion.Where(t => t.Id == 17 || t.Id == 20 || t.Id == 21 || t.Id == 22).Select(t => new
            {
                t.Id,
                t.Descripcion
            }).ToListAsync();
        }

        [HttpGet("actualiza_dias_mora")]
        public async Task<ActionResult<IReadOnlyList<object>>> GetDiasMora()
        {
            var prestamos = await _dbContext.Prestamos.Where(p => p.EstadoPrestamoId != 5).ToListAsync();

            foreach (var prestamo in prestamos)
            {
                var fechaPago = await _dbContext.PlanPagos.Where(p => p.PrestamoId == prestamo.Id && p.Aplicado == false).Select(p => p.FechaPago).FirstOrDefaultAsync();

                var fechaInicio = new DateTime(2020 - 01 - 01);

                if (fechaPago >= fechaInicio && fechaPago <= DateTime.Now)
                {
                    var diasMora = (int)(DateTime.Now - fechaPago).TotalDays;
                    prestamo.DiasMora = diasMora;

                }
                else
                {
                    prestamo.DiasMora = 0;
                }

                _unitOfWork.Repository<Prestamo>().Update(prestamo);

            }

            var result = await _unitOfWork.Complete();

            if (result < 0) return null!;


            return Ok(new { message = "Acción realizada Satisfactoriamente" });
        }

        [HttpGet("reporte_general")]
        public async Task<ActionResult<IEnumerable<ReporteGeneralCreditos>>> GetReporteGeneral()
        {
            var reporte = await _dbContext.Set<ReporteGeneralCreditos>().ToListAsync();

            return Ok(reporte);
        }

        [HttpGet("reporte_CasosBTS")]
        public async Task<ActionResult<IEnumerable<ReporteCasosBTS>>> GetReporteBts()
        {            
            var reporte = await _dbContext.Set<ReporteCasosBTS>().ToListAsync();

            return Ok(reporte);
        }

        [HttpGet("reporte_contabilidad")]
        public async Task<ActionResult<AplicacionPagos>> GetReporteContabilidad(DateTime fechaInicio, DateTime fechaFinal)
        {
            var reporte = await _dbContext.AplicacionPagos.FromSqlInterpolated($"Exec ReporteContabilidad {fechaInicio}, {fechaFinal}").ToListAsync();

            return Ok(reporte);
        }

        [HttpGet("generacion_archivo_batch")]
        public async Task<ActionResult<object>> GetBatchFile()
        {
            var reportes = await _dbContext.Set<BatchFile>().ToListAsync();

            List<Core.Entities.Views.Encabezado> encabezado = new();
            List<Core.Entities.Views.Detalle> detalle = new();
            List<Core.Entities.Views.TotalImpuestos> totalImpuestos = new();
            List<Core.Entities.Views.Frases> frases = new();

            foreach (var reporte in reportes)
            {
                encabezado = await _dbContext.fxBatchGetHeader(reporte.BatchKey, reporte.BatchDate).ToListAsync();
                detalle = await _dbContext.fxBatchGetDetail(reporte.BatchKey, reporte.BatchDate).ToListAsync();
                totalImpuestos = await _dbContext.fxBatchGetTotalTaxes(reporte.BatchKey, reporte.BatchDate).ToListAsync();
                frases = await _dbContext.fxBatchGetPhrases(reporte.BatchKey, reporte.BatchDate).ToListAsync();
            }

            return Ok(new { message = "Acción realizada Satisfactoriamente", encabezado, detalle, totalImpuestos, frases });
        }
    }
}
