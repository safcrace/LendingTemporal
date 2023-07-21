
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

        [HttpGet("paises")]
        public async Task<ActionResult<IEnumerable<PaisDto>>> GetCountries()
        {
            var paises = await _dbContext.Paises.ToListAsync();

            if (paises == null) return NotFound();

            return Ok(_mapper.Map<List<PaisDto>>(paises));
        }

        [HttpPost("regiones")]
        public async Task<ActionResult<IEnumerable<object>>> CreateRegion(CreateRegionDto createRegionDto)
        {
            var region = new Region
            {
                Nombre = createRegionDto.Nombre,
                Descripcion = createRegionDto.Descripcion
            };

            _unitOfWork.Repository<Region>().Add(region);
            var result = await _unitOfWork.Complete();
            if (result < 0) return null!;

            return Ok(new { Message = "Acción realizada Satisfactoriamente.", region.Id });
        }


        [HttpGet("regiones")]
        public async Task<ActionResult<IEnumerable<RegionDto>>> GetRegions()
        {
            var result = await _dbContext.Regiones.ToListAsync();

            var regiones = _mapper.Map<List<RegionDto>>(result);

            if (regiones == null) return NotFound();

            foreach (var region in regiones)
            {
                region.NumeroDepartamentos = await _dbContext.Departamentos.Where(x => x.RegionId == region.Id).CountAsync();
                region.NombreDepartamentos = await _dbContext.Departamentos.Where(x => x.RegionId == region.Id).Select(x => x.Nombre).ToListAsync();
            }

            return Ok(_mapper.Map<List<RegionDto>>(regiones));
        }

        [HttpGet("regiones/{regionId}")]
        public async Task<ActionResult<string>> GetRegionName(int regionId)
        {
            var region = await _dbContext.Regiones.Where(x => x.Id == regionId).Select(x => x.Nombre).FirstOrDefaultAsync();


            return Ok(region);
        }

        [HttpPut("regiones/{regionId}")]
        public async Task<ActionResult<IEnumerable<object>>> UPDATE(int regionId, UpdateRegionDto updateRegionDto)
        {
            var region = _dbContext.Regiones.Where(x => x.Id == regionId).FirstOrDefault();

            if (region == null) return NotFound();

            region.Nombre = updateRegionDto.Nombre;
            region.Descripcion = updateRegionDto.Descripcion;

            _unitOfWork.Repository<Region>().Update(region);
            var result = await _unitOfWork.Complete();
            if (result < 0) return null!;

            return Ok(new { Message = "Acción realizada Satisfactoriamente." });
        }

        [HttpGet("departamento_region/{regionId}")]
        public async Task<ActionResult<IEnumerable<DepartamentoDto>>> GetDepartamentosRegion(int regionId)
        {
            var departamentos = await _dbContext.Departamentos.Where(x => x.RegionId == regionId).ToListAsync();

            if (departamentos == null) return NotFound();

            return Ok(_mapper.Map<List<DepartamentoDto>>(departamentos));
        }

        [HttpPut("departamento_region/{departamentoId}")]
        public async Task<ActionResult<IEnumerable<RegionDto>>> UpdateRegionDepartamento(int departamentoId, int regionId, bool Action = true)
        {
            var departamento = await _dbContext.Departamentos.Where(x => x.Id == departamentoId).FirstOrDefaultAsync();

            if (departamento is null) return NotFound();

            if (Action)
            {
                departamento.RegionId = regionId;
            }
            else
            {
                departamento.RegionId = null;
            }

            _dbContext.Departamentos.Update(departamento);

            await _dbContext.SaveChangesAsync();

            return Ok(new { message = "Acción Realizada Satisfactoriamente" });
        }


        [HttpGet("departmentos")]
        public async Task<ActionResult<IEnumerable<DepartamentoDto>>> GetDepartments()
        {
            var departamentos = await _unitOfWork.Repository<Departamento>().ListAllAsync();

            if (departamentos == null) return NotFound();

            return Ok(_mapper.Map<List<DepartamentoDto>>(departamentos));
        }

        [HttpGet("municipios/{departamentoId}")]
        public async Task<ActionResult<IEnumerable<MunicipioDto>>> GetTownships(int departamentoId)
        {
            var municipios = await _dbContext.Municipios.Where(x => x.DepartamentoId == departamentoId).ToListAsync();

            if (municipios == null) return NotFound();

            return Ok(_mapper.Map<List<MunicipioDto>>(municipios));
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
            //var formaPago = await _unitOfWork.Repository<FormaPago>().ListAllAsync();
            var formaPago = await _dbContext.FormaPagos.Where(x => x.Habilitado == true).OrderBy(x => x.Nombre).ToListAsync();



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

        [HttpGet("tipo_cuota")]
        public async Task<ActionResult<IEnumerable<TipoCuotaDto>>> GetTipoCuota()
        {
            var tipoCuotas = await _unitOfWork.Repository<TipoCuota>().ListAllAsync();

            return Ok(_mapper.Map<IReadOnlyList<TipoCuotaDto>>(tipoCuotas));
        }

        [HttpGet("monedas")]
        public async Task<ActionResult<IEnumerable<MonedaDto>>> GetMoneda()
        {
            var monedas = await _unitOfWork.Repository<Moneda>().ListAllAsync();

            return Ok(_mapper.Map<IReadOnlyList<MonedaDto>>(monedas));
        }

        [HttpGet("ocupaciones")]
        public async Task<ActionResult<IEnumerable<OcupacionDto>>> GetOcupaciones()
        {
            var ocupaciones = await _unitOfWork.Repository<Ocupacion>().ListAllAsync();

            if (ocupaciones == null) return NotFound();

            return Ok(_mapper.Map<List<OcupacionDto>>(ocupaciones));
        }

        [HttpGet("tipos_vivienda")]
        public async Task<ActionResult<IEnumerable<TipoViviendaDto>>> GetTiposVivienda()
        {
            var tiposVivienda = await _unitOfWork.Repository<TipoVivienda>().ListAllAsync();

            if (tiposVivienda == null) return NotFound();

            return Ok(_mapper.Map<List<TipoViviendaDto>>(tiposVivienda));
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

        [HttpGet("actualiza_mora")]
        public async Task<ActionResult<IReadOnlyList<object>>> GetActualizaMora()
        {
            await _dbContext.Database.ExecuteSqlRawAsync("Exec sp_job_calcularMora");
            return Ok(new { message = "Acción realizada Satisfactoriamente" });
        }


        [HttpGet("actualiza_dias_mora")]
        public async Task<ActionResult<IReadOnlyList<object>>> GetDiasMora()
        {
            DateTime fechaActual = DateTime.Now, fechaReferencia = DateTime.Now.Date;
            decimal cargoMontoMora = 0.0m, cargoMontoIvaMora = 0.0m, capitalVencido = 0.0m;

            var prestamos = await _dbContext.Prestamos.Where(p => p.EstadoPrestamoId == 1 || p.EstadoPrestamoId == 7).ToListAsync();

            foreach (var prestamo in prestamos)
            {
                capitalVencido = 0.0m;
                cargoMontoMora = 0.0m;
                cargoMontoIvaMora = 0.0m;

                //var fechaPago = await _dbContext.PlanPagos.Where(p => p.PrestamoId == prestamo.Id && p.Aplicado == false).Select(p => p.FechaPago).FirstOrDefaultAsync();
                var planPago = await _dbContext.PlanPagos.Where(p => p.PrestamoId == prestamo.Id && p.Aplicado == false).FirstOrDefaultAsync();
                var tasaMora = prestamo.TasaMora;

                if (planPago is not null)
                {
                    //var fechaInicio = new DateTime(2020 - 01 - 01);
                    if (planPago.FechaPago < fechaActual)
                    {
                        //var diasMora = (int)(DateTime.Now - fechaPago).TotalDays;
                        var diasMora = (int)(fechaActual - planPago.FechaPago).TotalDays;
                        prestamo.DiasMora = diasMora;

                    }
                    else
                    {
                        prestamo.DiasMora = 0;
                    }


                    //var cuotasPendientesPlanPago = await _dbContext.PlanPagos.Where(p => p.PrestamoId == prestamo.Id && p.Aplicado == false).ToListAsync();

                    //foreach (var plan in cuotasPendientesPlanPago)
                    //{
                    //if (fechaReferencia.Date < plan.FechaModificacion)
                    //{
                    //    plan.CuotaMora = 0;
                    //    plan.SaldoMora = 0;
                    //    plan.CuotaIvaMora = 0;
                    //    plan.SaldoIvaMora = 0;
                    //    //plan.TotalCuota = plan.CuotaCapital + plan.CuotaIntereses + plan.CuotaIvaIntereses + plan.CuotaMora + plan.CuotaIvaMora;
                    //    _dbContext.Update(plan);
                    //    await _dbContext.SaveChangesAsync();
                    //}
                    //if (fechaReferencia > plan.FechaModificacion)
                    //{
                    //    plan.CuotaMora = 0;
                    //    plan.SaldoMora = 0;
                    //    plan.CuotaIvaMora = 0;
                    //    plan.SaldoIvaMora = 0;
                    //    //plan.TotalCuota = plan.CuotaCapital + plan.CuotaIntereses + plan.CuotaIvaIntereses + plan.CuotaMora + plan.CuotaIvaMora;
                    //    _dbContext.Update(plan);
                    //    await _dbContext.SaveChangesAsync();
                    //}


                    //    if (plan.FechaPago <= fechaActual && plan.FechaModificacion.Date != fechaReferencia)
                    //    {
                    //        capitalVencido += plan.SaldoCapital;
                    //    }
                    //}

                    //cargoMontoMora = capitalVencido * tasaMora / 365 * prestamo.DiasMora;
                    //cargoMontoIvaMora = cargoMontoMora * 0.12m;
                    //planPago.CuotaMora = cargoMontoMora;
                    //planPago.SaldoMora = cargoMontoMora;
                    //planPago.CuotaIvaMora = cargoMontoIvaMora;
                    //planPago.SaldoIvaMora = cargoMontoIvaMora;
                    //planPago.FechaModificacion = fechaActual.Date;
                    ////_dbContext.Update(planPago);
                    ////await _dbContext.SaveChangesAsync();

                    //_unitOfWork.Repository<PlanPago>().Update(planPago);
                    _unitOfWork.Repository<Prestamo>().Update(prestamo);
                }

            }

            var result = await _unitOfWork.Complete();

            if (result < 0) return null!;


            return Ok(new { message = "Acción realizada Satisfactoriamente", fechaActual });
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

        [HttpGet("generacion_reporte_transunion")]
        public async Task<ActionResult<object>> GetBatchFileTrans()
        {
            var reporte = await _dbContext.Set<ReporteTransUnion>().ToListAsync();

            //List<Core.Entities.Views.ReporteTransUnion> reporteTransUnion = new();           

            //foreach (var reporte in reportes)
            //{
            //    encabezado = await _dbContext.fxBatchGetHeader(reporte.BatchKey, reporte.BatchDate).ToListAsync();
            //    detalle = await _dbContext.fxBatchGetDetail(reporte.BatchKey, reporte.BatchDate).ToListAsync();
            //    totalImpuestos = await _dbContext.fxBatchGetTotalTaxes(reporte.BatchKey, reporte.BatchDate).ToListAsync();
            //    frases = await _dbContext.fxBatchGetPhrases(reporte.BatchKey, reporte.BatchDate).ToListAsync();
            //}

            return Ok(new { message = "Acción realizada Satisfactoriamente", reporte });
        }

        [HttpGet("busqueda_personas/{search}")]
        public async Task<ActionResult<ListadoPersonas>> GetSearchPerson(string search)
        {
            List<Core.Entities.Views.ListadoPersonas> listado = new();

            listado = await _dbContext.fxMDI_PersonsQryFull(search).ToListAsync();


            return Ok(listado);
        }

        [HttpGet("canales-ingreso")]
        public async Task<ActionResult<IEnumerable<CanalIngresoDto>>> GetCanalesIngreso()
        {
            var canalesIngresos = await _unitOfWork.Repository<CanalIngreso>().ListAllAsync();

            if (canalesIngresos == null) return NotFound();

            return Ok(_mapper.Map<List<CanalIngresoDto>>(canalesIngresos));
        }

        [HttpGet("empresas-celular")]
        public async Task<ActionResult<IEnumerable<EmpresaCelularDto>>> GetEmpresasCelular()
        {
            var empresasCelulares = await _unitOfWork.Repository<EmpresaCelular>().ListAllAsync();

            if (empresasCelulares == null) return NotFound();

            return Ok(_mapper.Map<List<EmpresaCelularDto>>(empresasCelulares));
        }

        [HttpGet("grupo-familiar")]
        public async Task<ActionResult<IEnumerable<GrupoFamiliarDto>>> GetFamiliarGroup()
        {
            var grupoFamiliar = await _unitOfWork.Repository<GrupoFamiliar>().ListAllAsync();

            if (grupoFamiliar == null) return NotFound();

            return Ok(_mapper.Map<List<GrupoFamiliarDto>>(grupoFamiliar));
        }

        [HttpGet("monto-interesado")]
        public async Task<ActionResult<IEnumerable<MontoInteresadoDto>>> GetMontosInteresados()
        {
            var montoInteresados = await _unitOfWork.Repository<MontoInteresado>().ListAllAsync();

            if (montoInteresados == null) return NotFound();

            return Ok(_mapper.Map<List<MontoInteresadoDto>>(montoInteresados));
        }

        [HttpGet("ocupaciones-SinFin")]
        public async Task<ActionResult<IEnumerable<OcupacionSinFinDto>>> GetOcupacionesSinFin()
        {
            var ocupaciones = await _unitOfWork.Repository<OcupacionSinFin>().ListAllAsync();

            if (ocupaciones == null) return NotFound();

            return Ok(_mapper.Map<List<OcupacionSinFinDto>>(ocupaciones));
        }

        [HttpGet("productos-interesados")]
        public async Task<ActionResult<IEnumerable<ProductoInteresadoDto>>> GetProductosInteresados()
        {
            var productoInteresados = await _unitOfWork.Repository<ProductoInteresado>().ListAllAsync();

            if (productoInteresados == null) return NotFound();

            return Ok(_mapper.Map<List<ProductoInteresadoDto>>(productoInteresados));
        }

        [HttpGet("segmentos-negocio")]
        public async Task<ActionResult<IEnumerable<SegmentoNegocioDto>>> GetSegmentosNegocio()
        {
            var segmentoNegocios = await _unitOfWork.Repository<SegmentoNegocio>().ListAllAsync();

            if (segmentoNegocios == null) return NotFound();

            return Ok(_mapper.Map<List<SegmentoNegocioDto>>(segmentoNegocios));
        }

        [HttpGet("subgementos-negocio/{segmentoNegocioId}")]
        public async Task<ActionResult<IEnumerable<SubSegmentoNegocioDto>>> GetSubsegmentosNegocios(int segmentoNegocioId)
        {
            var subsegmentos = await _dbContext.SubSegmentoNegocios.Where(x => x.SegmentoNegocioId == segmentoNegocioId ).ToListAsync();

            if (subsegmentos == null) return NotFound();

            return Ok(_mapper.Map<List<SubSegmentoNegocioDto>>(subsegmentos));
        }

    }
}
