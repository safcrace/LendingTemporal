using API.Dtos;
using API.Interfaces;
using AutoMapper;
using Core.Entities;
using Core.Entities.Functions;
using Core.Entities.Identity;
using Core.Entities.Views;
using Core.Interfaces;
using EllipticCurve.Utils;
using Infrastructure.Data.DBContext;
using Infrastructure.Migrations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.IO.Pipelines;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace API.Controllers
{
    public class LendingController : BaseApiController
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IMailService _mailService;

        public LendingController(ApplicationDbContext dbContext, IUnitOfWork unitOfWork, IMapper mapper, IMailService mailService)
        {
            _dbContext = dbContext;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _mailService = mailService;
        }

        [HttpPost()]
        public async Task<ActionResult<IEnumerable<object>>> CreateLending(CreateLendingDto createLendingDto)
        {
            try
            {
                int result;

                if (createLendingDto.EntidadPrestamoId == 0)
                {
                    var expedienteSid = createLendingDto.TipoEntidad == 1 ? createLendingDto?.CreatePersonDto?.ExpedienteSidId : createLendingDto?.CreateCompanyDto?.ExpedienteSidId;

                    var entidad = new Entidad
                    {
                        TipoEntidadId = createLendingDto.TipoEntidad,
                        ExpedienteSidId = expedienteSid
                    };

                    _unitOfWork.Repository<Entidad>().Add(entidad);
                    result = await _unitOfWork.Complete();
                    if (result < 0) return null!;

                    createLendingDto.GestorPrestamoId = createLendingDto.GestorPrestamoId;

                    if (createLendingDto.CreatePersonDto is not null)
                    {
                        var persona = _mapper.Map<Persona>(createLendingDto.CreatePersonDto);
                        persona.EntidadId = entidad.Id;

                        _unitOfWork.Repository<Persona>().Add(persona);
                    }

                    if (createLendingDto.CreateCompanyDto is not null)
                    {
                        var empresa = _mapper.Map<Empresa>(createLendingDto.CreateCompanyDto);
                        empresa.EntidadId = entidad.Id;

                        _unitOfWork.Repository<Empresa>().Add(empresa);
                    }

                    var relacionEntidades = new RelacionEntidad
                    {
                        TipoRelacionId = 1,
                        EntidadPadreId = 1,
                        EntidadHijaId = entidad.Id
                    };

                    _unitOfWork.Repository<RelacionEntidad>().Add(relacionEntidades);
                    createLendingDto.EntidadPrestamoId = entidad.Id;
                }
                else
                {
                    if (createLendingDto.CreatePersonDto is not null)
                    {
                        var persona = await _dbContext.Personas.Where(x => x.EntidadId == createLendingDto.EntidadPrestamoId).FirstOrDefaultAsync();
                        var personaDto = createLendingDto.CreatePersonDto;
                        personaDto.EntidadId = createLendingDto.EntidadPrestamoId;
                        _mapper.Map(personaDto, persona);

                        var entidad = await _dbContext.Entidades.Where(x => x.Id == persona.EntidadId).FirstOrDefaultAsync();

                        entidad.ExpedienteSidId = personaDto.ExpedienteSidId;

                        _dbContext.Entidades.Update(entidad);

                        if (createLendingDto.AppUserAutorizoId is not null)
                        {
                            var bitacoraFicha = new BitacoraFicha
                            {
                                EntidadId = persona.EntidadId,
                                AppUserId = createLendingDto.AppUserId,
                                AppUserAuthorizedId = createLendingDto.AppUserAutorizoId,
                                Comentarios = null
                            };

                            _unitOfWork.Repository<BitacoraFicha>().Add(bitacoraFicha);
                        }
                    }
                    if (createLendingDto.CreateCompanyDto is not null)
                    {
                        var empresa = await _dbContext.Empresas.Where(x => x.EntidadId == createLendingDto.EntidadPrestamoId).FirstOrDefaultAsync();
                        var empresaDto = createLendingDto.CreateCompanyDto;
                        empresaDto.EntidadId = createLendingDto.EntidadPrestamoId;
                        _mapper.Map(empresaDto, empresa);

                        var entidad = await _dbContext.Entidades.Where(x => x.Id == empresa.EntidadId).FirstOrDefaultAsync();

                        entidad.ExpedienteSidId = empresaDto.ExpedienteSidId;

                        _dbContext.Entidades.Update(entidad);

                        if (createLendingDto.AppUserAutorizoId is not null)
                        {
                            var bitacoraFicha = new BitacoraFicha
                            {
                                EntidadId = empresa.EntidadId,
                                AppUserId = createLendingDto.AppUserId,
                                AppUserAuthorizedId = createLendingDto.AppUserAutorizoId,
                                Comentarios = null
                            };

                            _unitOfWork.Repository<BitacoraFicha>().Add(bitacoraFicha);
                        }

                    }
                }

                await _dbContext.SaveChangesAsync();

                var prestamo = _mapper.Map<Prestamo>(createLendingDto);

                _unitOfWork.Repository<Prestamo>().Add(prestamo);
                result = await _unitOfWork.Complete();


                var bitacoraPrestamo = new BitacoraPrestamo
                {
                    PrestamoId = prestamo.Id,
                    AppUserId = prestamo.AppUserId,
                    Comentarios = null,
                    TimeInStatus = 0,
                    EstadoPrestamoId = null,
                    NuevoEstadoPrestamoId = 9
                };

                _unitOfWork.Repository<BitacoraPrestamo>().Add(bitacoraPrestamo);

                result = await _unitOfWork.Complete();

                if (result < 0) return null!;

                return Ok(new { message = "Acción realizada Satisfactoriamente" });
            }
            catch (Exception e)
            {

                return e.InnerException != null
                ? new BadRequestObjectResult(e.InnerException.Message)
                : new BadRequestObjectResult(e.Message);
            }

        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<ListadoDeudores>>> GetLendings()
        {
            //return await _dbContext.Set<ListadoGeneral>().ToListAsync();
            return await _dbContext.ListadoDeudores.OrderBy(x => x.EntidadId).ToListAsync();
        }

        [HttpGet("listado-entidades/{tipoEntidadId}")]
        public async Task<ActionResult<IEnumerable<ListadoEntidades>>> GetEntidades(int tipoEntidadId)
        {
            var entidades = await _dbContext.Set<ListadoEntidades>().ToListAsync();
            entidades = entidades.Where(x => x.TipoEntidadId == tipoEntidadId).ToList();

            return Ok(entidades);
        }

        [HttpPut("entidades/{entidadId}")]
        public async Task<ActionResult<object>> UpdateEntidades(int entidadId, UpdateEntidadDto updateEntidadDto)
        {
            var entidad = await _unitOfWork.Repository<Entidad>().GetByIdAsync(entidadId);

            entidad.ExpedienteSidId = updateEntidadDto.ExpedienteSidId;

            await _unitOfWork.Complete();

            return Ok(new { mensaje = "Actualización realizada satisfactoriamente!" });
        }

        [HttpGet("listado_prospectos/{appUserId}")]
        public async Task<ActionResult<IEnumerable<ListadoProspectos>>> GetRequests(string? appUserId, string tipoConsulta = "General", int tipoPrestamoId = 0)
        {
            List<Core.Entities.Views.ListadoProspectos> listado = new();

            listado = await _dbContext.Set<ListadoProspectos>().ToListAsync();

            var estadosPermitidos = new List<int> { 9, 10, 12, 13, 15 };

            if (tipoConsulta == "General")
            {
                listado = listado.Where(x => estadosPermitidos.Contains(x.EstadoPrestamoId)).ToList();
            }



            if (tipoConsulta == "Usuario")
            {
                var usuario = _dbContext.Users
                                    .Where(usr => usr.Id == appUserId)
                                    .Join(_dbContext.Personas,
                                          usr => usr.PersonaId,
                                          per => per.Id,
                                          (usr, per) => new
                                          {
                                              per.EntidadId
                                          })
                                    .FirstOrDefault();



                if (usuario != null)
                {
                    var tipoUsuario = await _dbContext.RelacionEntidades.Where(x => x.EntidadHijaId == usuario.EntidadId).Select(x => x.TipoRelacionId).FirstOrDefaultAsync();

                    var entidadId = usuario.EntidadId;

                    if (tipoUsuario == 2)
                    {
                        listado = listado.Where(x => x.GestorAsignadoId == entidadId).ToList();
                    }
                    else if (tipoUsuario == 5)
                    {
                        listado = listado.Where(x => x.AnalistaAsignadoId == entidadId).ToList();
                    }
                    else
                    {
                        return BadRequest("Este Usuario no es Analista ni es Asesor.");
                    }

                    var otrosEstados = new List<int> { 11, 15, 16, 17, 18, 19 };
                    estadosPermitidos.AddRange(otrosEstados);

                    listado = listado.Where(x => estadosPermitidos.Contains(x.EstadoPrestamoId)).ToList();
                }

            }

            if (tipoConsulta == "Historial")
            {
                listado = listado.Where(x => x.EstadoPrestamoId == 11 || x.EstadoPrestamoId == 12).ToList();
            }

            if (tipoConsulta == "Evaluacion")
            {
                listado = listado.Where(x => x.TipoPrestamoId == tipoPrestamoId && x.EstadoPrestamoId == 14).ToList();
            }

            if (tipoConsulta == "AprobacionAnalista")
            {
                listado = listado.Where(x => x.EstadoPrestamoId == 16).ToList();
            }

            if (tipoConsulta == "AprobacionCreditos")
            {
                listado = listado.Where(x => x.EstadoPrestamoId == 17).ToList();
            }

            if (tipoConsulta == "AprobacionDirectores")
            {
                listado = listado.Where(x => x.EstadoPrestamoId == 18).ToList();
            }

            if (tipoConsulta == "AprobacionGerencia")
            {
                listado = listado.Where(x => x.EstadoPrestamoId == 19).ToList();
            }

            foreach (var item in listado)
            {

                var prestamo = _dbContext.Prestamos?.Where(x => x.Id == item.SolicitudId).FirstOrDefault();
                if (prestamo is not null)
                {

                    var bitacora = await _dbContext.BitacoraPrestamos.Where(x => x.PrestamoId == prestamo.Id).OrderByDescending(x => x.Id).FirstOrDefaultAsync();
                    if (bitacora is not null)
                    {
                        TimeSpan tiempoTranscurrido = DateTime.Now.Subtract(bitacora.FechaCreacion);
                        item.TiempoEnEstado = (int)tiempoTranscurrido.TotalDays;
                        bitacora.TimeInStatus = (byte)item.TiempoEnEstado;

                        if (item.TiempoEnEstado > 120 && (item.EstadoPrestamoId != 11 || item.EstadoPrestamoId != 20))
                        {
                            bitacora.CambioEstado = true;
                            prestamo.EstadoPrestamoId = 11;
                            _dbContext.Prestamos.Update(prestamo);
                            await _dbContext.SaveChangesAsync();


                            var nuevoEstado = new BitacoraPrestamo
                            {
                                PrestamoId = item.SolicitudId,
                                AppUserId = "8f00ad3d-22d4-424d-8e48-6df7aef4f7d6",
                                EstadoPrestamoId = bitacora.NuevoEstadoPrestamoId,
                                NuevoEstadoPrestamoId = 11,
                                Comentarios = "Cambio de Estado Automatico Aplicado"
                            };

                            await _dbContext.BitacoraPrestamos.AddAsync(nuevoEstado);

                            item.EstadoPrestamoId = 11;
                            item.Estado = "Rechazado";
                        }
                        _dbContext.BitacoraPrestamos.Update(bitacora);
                        await _dbContext.SaveChangesAsync();

                    }


                    item.FechaIngreso = bitacora.FechaCreacion;
                }
            }



            return Ok(listado);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<object>> GetLendingById(int id)
        {
            var entidadId = await _dbContext.Prestamos.Where(p => p.Id == id).Select(p => p.EntidadPrestamoId).FirstOrDefaultAsync();

            var tipoEntidadId = await _dbContext.Entidades.Where(e => e.Id == entidadId).Select(e => e.TipoEntidadId).FirstOrDefaultAsync();

            if (tipoEntidadId == 1)
            {
                var lendingP = await (from pre in _dbContext.Prestamos
                                      join ent in _dbContext.Entidades on pre.EntidadPrestamoId equals ent.Id
                                      join per in _dbContext.Personas on ent.Id equals per.EntidadId
                                      where pre.Id == id
                                      select new
                                      {
                                          PrestamoId = pre.Id,
                                          PrestamoReferencia = pre.ReferenciaMigracion,
                                          PersonaId = per.Id,
                                          Nombres = $"{per.PrimerNombre} {per.SegundoNombre} {per.TercerNombre}",
                                          Apellidos = $"{per.PrimerApellido} {per.SegundoApellido}",
                                          DPI = per.NumeroDocumento,
                                          per.Direccion,
                                          per.NumeroTelefono,
                                          per.NIT,
                                          EstadoCivil = per.EstadoCivil.Nombre,
                                          EstadoPrestamo = pre.EstadoPrestamo.Nombre,
                                          AsesorId = pre.GestorPrestamoId,
                                          TipoPrestamo = pre.TipoPrestamo.Nombre,
                                          MontoTotal = pre.MontoOtorgado,
                                          MontoTotalProyectado = pre.MontoTotalProyectado,
                                          Plazo = pre.Plazo,
                                          TasaInteres = pre.TasaInteres,
                                          TasaMora = pre.TasaMora,
                                          TasaIva = pre.TasaIva,
                                          FechaPlan = pre.FechaPlan,
                                          FechaAprobacion = pre.FechaAprobacion,
                                          DiasMora = pre.DiasMora
                                      }).ToListAsync();

                var agenteP = await (from pre in _dbContext.Prestamos
                                     join ent in _dbContext.Entidades on pre.GestorPrestamoId equals ent.Id
                                     join per in _dbContext.Personas on ent.Id equals per.EntidadId
                                     where pre.Id == id
                                     select new
                                     {
                                         Nombre = per.PrimerNombre + " " + per.SegundoApellido,

                                     }).FirstOrDefaultAsync();

                var empresaPlanilla = await (from pre in _dbContext.Prestamos
                                             join ent in _dbContext.Entidades on pre.EmpresaPrestamoId equals ent.Id
                                             join emp in _dbContext.Empresas on ent.Id equals emp.EntidadId
                                             where pre.Id == id
                                             select new
                                             {
                                                 Nombre = emp.Nombre
                                             }).FirstOrDefaultAsync();

                return Ok(new { lendingP, agenteP, empresaPlanilla });
            }

            var lendingE = await (from pre in _dbContext.Prestamos
                                  join ent in _dbContext.Entidades on pre.EntidadPrestamoId equals ent.Id
                                  join emp in _dbContext.Empresas on ent.Id equals emp.EntidadId
                                  where pre.Id == id
                                  select new
                                  {
                                      PrestamoId = pre.Id,
                                      PrestamoReferencia = pre.ReferenciaMigracion,
                                      Nombre = emp.Nombre,
                                      emp.Direccion,
                                      emp.Telefono,
                                      emp.Email,
                                      emp.Nit,
                                      AsesorId = pre.GestorPrestamoId,
                                      TipoPrestamo = pre.TipoPrestamo.Nombre,
                                      MontoTotal = pre.MontoOtorgado,
                                      MontoTotalProyectado = pre.MontoTotalProyectado,
                                      Plazo = pre.Plazo,
                                      TasaInteres = pre.TasaInteres,
                                      TasaMora = pre.TasaMora,
                                      TasaIva = pre.TasaIva,
                                      FechaPlan = pre.FechaPlan,
                                      FechaAprobacion = pre.FechaAprobacion,
                                      DiasMora = pre.DiasMora
                                  }).ToListAsync();

            var agenteE = await (from pre in _dbContext.Prestamos
                                 join ent in _dbContext.Entidades on pre.GestorPrestamoId equals ent.Id
                                 join per in _dbContext.Personas on ent.Id equals per.EntidadId
                                 where pre.Id == id
                                 select new
                                 {
                                     Nombre = per.PrimerNombre + " " + per.SegundoApellido,

                                 }).FirstOrDefaultAsync();

            return Ok(new { lendingE, agenteE });

        }

        [HttpGet("parametros_prestamo/{tipoPrestamoId:int}")]
        public async Task<ActionResult<object>> GetComplentoPrestamos(int tipoPrestamoId, int entidadId, int prestamoId)
        {
            int? departamentoId;
            var tipoEntidadId = await _dbContext.Entidades.Where(x => x.Id == entidadId).Select(x => x.TipoEntidadId).FirstOrDefaultAsync();

            if (tipoEntidadId <= 0)
            {
                return BadRequest("No existe el # de Entidad Proporcionado");
            }

            if (tipoEntidadId == 1)
            {
                departamentoId = await _dbContext.Personas.Where(x => x.EntidadId == entidadId).Select(x => x.DepartamentoId).FirstOrDefaultAsync();
            }
            else
            {
                departamentoId = await _dbContext.Empresas.Where(x => x.EntidadId == entidadId).Select(x => x.DepartamentoId).FirstOrDefaultAsync();
            }

            //var departamentoId = datosPersona is not null ? datosPersona.DepartamentoId : datosEmpresa?.DepartamentoId;
            var parametrosPrestamo = await _dbContext.ParametrosDepartamentos.Where(x => x.TipoPrestamoId == tipoPrestamoId && x.DepartamentoId == departamentoId).FirstOrDefaultAsync();
            var plazoMinimo = parametrosPrestamo.PlazoMinimo;
            var plazoMaximo = parametrosPrestamo.PlazoMaximo;
            var plazoPredeterminado = parametrosPrestamo.PlazoPredeterminado;
            var montoMinimo = parametrosPrestamo.MontoMinimo; // await _dbContext.ParametrosDepartamentos.Where(x => x.TipoPrestamoId == tipoPrestamoId).MinAsync(x => x.MontoMinimo);
            var montoMaximo = parametrosPrestamo.MontoMaximo; // await _dbContext.ParametrosDepartamentos.Where(x => x.TipoPrestamoId == tipoPrestamoId).MaxAsync(x => x.MontoMaximo);

            //var tasaDepartamentoId = datosPersona is not null ? datosPersona.DepartamentoId : datosEmpresa?.DepartamentoId;
            var interesesDepartamento = await _dbContext.InteresesDepartamentos.Where(x => x.TipoPrestamoId == tipoPrestamoId && x.DepartamentoId == departamentoId).FirstOrDefaultAsync();
            var tasaInteresMinima = interesesDepartamento.TasaMinima;
            var tasaInteresMaxima = interesesDepartamento.TasaMaxima;
            var tasaInteresPredeterminada = interesesDepartamento.TasaPredeterminada;

            var tasaInteresPrestamo = await _dbContext.Prestamos.Where(x => x.Id == prestamoId).Select(x => x.TasaInteres).FirstOrDefaultAsync();
            if (tasaInteresPrestamo > 0)
            {
                tasaInteresPredeterminada = tasaInteresPrestamo;
            }

            // Mora
            var moraDepartamento = await _dbContext.MoraDepartamentos.Where(x => x.TipoPrestamoId == tipoPrestamoId && x.DepartamentoId == departamentoId).FirstOrDefaultAsync();
            var tasaMoraMinima = moraDepartamento.TasaMinima;
            var tasaMoraMaxima = moraDepartamento.TasaMaxima;
            var tasaMoraPredeterminada = moraDepartamento.TasaPredeterminada;

            var tasaMoraPrestamo = await _dbContext.Prestamos.Where(x => x.Id == prestamoId).Select(x => x.TasaMora).FirstOrDefaultAsync();
            if (tasaMoraPrestamo > 0)
            {
                tasaMoraPredeterminada = tasaMoraPrestamo;
            }


            var diaInicioMes = await _dbContext.ParametrosDepartamentos.Where(x => x.TipoPrestamoId == tipoPrestamoId).MaxAsync(x => x.DiaInicioMes);
            var diaQuincena = await _dbContext.ParametrosDepartamentos.Where(x => x.TipoPrestamoId == tipoPrestamoId).MaxAsync(x => x.DiaQuincena);
            var diaFinMes = await _dbContext.ParametrosDepartamentos.Where(x => x.TipoPrestamoId == tipoPrestamoId).MaxAsync(x => x.DiaFinMes);


            //datosPrestamo.TasaIvaAsignada = await _dbContext.TipoPrestamos.Where(x => x.Id == datosPrestamo.TipoPrestamoId).Select(x => x.TasaIva).FirstOrDefaultAsync();

            var tipo = await _dbContext.TipoPrestamos.Where(x => x.Id == tipoPrestamoId).FirstOrDefaultAsync();
            var nombreTipoCuota = await _dbContext.TipoCuotas.Where(x => x.Id == tipo.TipoCuotaId).Select(x => x.Nombre).FirstOrDefaultAsync();

            var documentosRequeridos = await _dbContext.DocumentosPrestamos.Where(x => x.TipoPrestamoId == tipo.Id).Select(x => new { x.Id, x.Nombre }).ToListAsync();

            var montoOtorgado = _dbContext.Prestamos.Where(x => x.Id == prestamoId).Select(x => x.MontoOtorgado).FirstOrDefault();

            if (montoOtorgado >= 0) tipo.PermisosAnalista = true;
            if (montoOtorgado >= tipo.MontoMinimoJefeCreditos) tipo.PermisosJefeCreditos = true;
            if (montoOtorgado >= tipo.MontoMinimoComiteGerencia) tipo.PermisosComiteGerencia = true;
            if (montoOtorgado >= tipo.MontoMinimoComiteDirectores) tipo.PermisosComiteDirectores = true;


            var parametrosComplementoPrestamo = new
            {
                PlazoMinimo = plazoMinimo,
                PlazoMaximo = plazoMaximo,
                PlazoPredeterminado = plazoPredeterminado,
                TasaInteresMinima = tasaInteresMinima,
                TasaInteresMaxima = tasaInteresMaxima,
                TasaInteresPredeterminada = tasaInteresPredeterminada,
                TasaMoraMinima = tasaMoraMinima,
                TasaMoraMaxima = tasaMoraMaxima,
                TasaMoraPredeterminada = tasaMoraPredeterminada,
                MontoMinimo = montoMinimo,
                MontoMaximo = montoMaximo,
                TipoCuotaId = tipo.Id,
                TipoCuota = nombreTipoCuota,
                tipo.TasaIva,
                DiaInicioMes = diaInicioMes,
                DiaQuincenaMes = diaQuincena,
                DiaFinMes = diaFinMes,
                tipo.PermisosAnalista,
                tipo.PermisosJefeCreditos,
                tipo.PermisosComiteDirectores,
                tipo.PermisosComiteGerencia,
                documentosRequeridos
            };

            return Ok(parametrosComplementoPrestamo);

        }

        [HttpPut("cambio_estado")]
        public async Task<ActionResult<object>> UpdateLendingStatus(UpdateEstadoDto updateEstadoDto)
        {
            var desembolso = await _dbContext.Desembolsos.Where(x => x.PrestamoId == updateEstadoDto.PrestamoId).FirstOrDefaultAsync();
            var entrevista = await _dbContext.Entrevistas.Where(x => x.PrestamoId == updateEstadoDto.PrestamoId).FirstOrDefaultAsync();

            if (updateEstadoDto.NuevoEstadoId == 14)
            {
                var tipoPrestamoId = await _dbContext.Prestamos.Where(x => x.Id == updateEstadoDto.PrestamoId).Select(x => x.TipoPrestamoId).FirstOrDefaultAsync();

                var detallePlanPagos = await _dbContext.DetallePlanPagoTemporales.FirstOrDefaultAsync(x => x.PrestamoId == updateEstadoDto.PrestamoId);

                if (tipoPrestamoId is null || detallePlanPagos is null)
                {
                    return BadRequest("Datos de la Solicitud Incompletos, no puede trasladar a Evaluación, por favor revise la información");
                }

            }

            if (updateEstadoDto.NuevoEstadoId > 15)
            {
                if (entrevista is null)
                {
                    return BadRequest("Alerta! La solicitud aún no cuenta con Entrevista!");
                }

                if (desembolso is null)
                {
                    return BadRequest("Alerta! La solicitud aún no cuenta con Desembolso!");
                }

            }
            var prestamo = await _unitOfWork.Repository<Prestamo>().GetByIdAsync(updateEstadoDto.PrestamoId);

            var estadoActual = prestamo.EstadoPrestamoId;

            var bitacoraActual = await _dbContext.BitacoraPrestamos.Where(x => x.PrestamoId == updateEstadoDto.PrestamoId &&
                                        x.CambioEstado == false).FirstOrDefaultAsync();

            if (bitacoraActual is not null)
            {
                bitacoraActual.CambioEstado = true;

                await _dbContext.SaveChangesAsync();

                //_unitOfWork.Repository<BitacoraPrestamo>().Update(bitacoraActual);
                //await _unitOfWork.Complete();

                var bitacoraPrestamo = new BitacoraPrestamo
                {
                    PrestamoId = prestamo.Id,
                    AppUserId = updateEstadoDto.AppUserId,
                    Comentarios = updateEstadoDto.Comentario,
                    TimeInStatus = 0,
                    EstadoPrestamoId = estadoActual,
                    NuevoEstadoPrestamoId = updateEstadoDto.NuevoEstadoId
                };

                _unitOfWork.Repository<BitacoraPrestamo>().Add(bitacoraPrestamo);
            }

            prestamo.EstadoPrestamoId = updateEstadoDto.NuevoEstadoId;

            //if (updateEstadoDto.NuevoEstadoId == 15)
            //{
            //    prestamo.AnalistaPrestamoId = null;
            //}

            if (updateEstadoDto.MotivoRechazoId > 0)
            {
                prestamo.MotivoRechazoId = updateEstadoDto.MotivoRechazoId;
            }

            if (updateEstadoDto.NuevoEstadoId == 16 || updateEstadoDto.NuevoEstadoId == 17 || updateEstadoDto.NuevoEstadoId == 18)
            {
                var personaId = await _dbContext.Users.Where(x => x.Id == updateEstadoDto.AppUserId).Select(x => x.PersonaId).FirstOrDefaultAsync();

                var nombre = await _dbContext.Personas.Where(x => x.Id == personaId).Select(x => new { nombre = x.PrimerNombre + ' ' + x.PrimerApellido }).FirstOrDefaultAsync();

                switch (updateEstadoDto.NuevoEstadoId)
                {
                    case 16:
                        desembolso.AprobacionCreditos = nombre.nombre;
                        break;
                    case 17:
                        desembolso.AprobacionDireccion = nombre.nombre;
                        break;
                    case 18:
                        desembolso.AprobacionGerencia = nombre.nombre;
                        break;
                    default:
                        break;
                }
            }


            await _unitOfWork.Complete();


            return Ok(new { message = "Cambio de Estado Realizado Satisfactoriamente" });
        }

        [HttpPut("traslado_asesor/{prestamoId}")]
        public async Task<ActionResult<object>> ChangeAsesor(int prestamoId, int gestorId, int analistaId)
        {
            var prestamo = await _unitOfWork.Repository<Prestamo>().GetByIdAsync(prestamoId);

            if (gestorId > 0)
            {
                prestamo.GestorPrestamoId = gestorId;
            }
            else
            {
                prestamo.AnalistaPrestamoId = analistaId;
            }

            await _unitOfWork.Complete();

            return Ok(new { message = "Cambio de Asesor Realizado Satisfactoriamente" });
        }

        [HttpGet("entity/{entidadId:int}")]
        public async Task<ActionResult<object>> GetEntityById(int entidadId)
        {
            var tipoEntidadId = await _dbContext.Entidades.Where(e => e.Id == entidadId).Select(e => e.TipoEntidadId).FirstOrDefaultAsync();

            if (tipoEntidadId == 1)
            {
                var persona = await _dbContext.Personas.Where(x => x.EntidadId == entidadId)
                                            .Select(x => new
                                            {
                                                x.Id,
                                                Nombre = $"{x.PrimerNombre} {x.SegundoNombre} {x.TercerNombre} {x.PrimerApellido} {x.SegundoApellido}",
                                                DPI = x.NumeroDocumento,
                                                x.NIT,
                                                x.NumeroTelefono,
                                                x.NumeroCelular,
                                                x.Direccion,
                                                x.DireccionNegocio
                                            }).FirstOrDefaultAsync();

                //var agenteP = await (from pre in _dbContext.Prestamos
                //                     join ent in _dbContext.Entidades on pre.GestorPrestamoId equals ent.Id
                //                     join per in _dbContext.Personas on ent.Id equals per.EntidadId
                //                     where pre.Id == id
                //                     select new
                //                     {
                //                         Nombre = per.PrimerNombre + " " + per.SegundoApellido,

                //                     }).FirstOrDefaultAsync();

                //var empresaPlanilla = await (from pre in _dbContext.Prestamos
                //                             join ent in _dbContext.Entidades on pre.EmpresaPrestamoId equals ent.Id
                //                             join emp in _dbContext.Empresas on ent.Id equals emp.EntidadId
                //                             where pre.Id == id
                //                             select new
                //                             {
                //                                 Nombre = emp.Nombre
                //                             }).FirstOrDefaultAsync();

                //decimal Cargos = await _dbContext.EstadoCuentas.Where(x => x.PrestamoId == ).SumAsync(x => x.Cargo);

                var estadosPermitidos = new List<int?> { 1, 3, 4, 6, 7, 8 };

                var prestamosPer = await (from pre in _dbContext.Prestamos
                                          join ase in _dbContext.Personas on pre.GestorPrestamoId equals ase.EntidadId
                                          join tc in _dbContext.TipoPrestamos on pre.TipoPrestamoId equals tc.Id
                                          join est in _dbContext.EstadoPrestamos on pre.EstadoPrestamoId equals est.Id
                                          join empres in _dbContext.Empresas on pre.EmpresaPrestamoId equals empres.EntidadId into emp
                                          from empre in emp.DefaultIfEmpty()
                                          where pre.EntidadPrestamoId == entidadId && estadosPermitidos.Contains(pre.EstadoPrestamoId)
                                          select new
                                          {
                                              PrestamoId = pre.Id,
                                              PrestamoReferencia = pre.ReferenciaMigracion,
                                              pre.FechaAprobacion,
                                              TipoCredito = tc.Nombre,
                                              pre.MontoTotalProyectado,
                                              //Saldo = Scalars.FxSaldoPrestamoListado(pre.Id),
                                              Estado = est.Nombre,
                                              pre.DiasMora,
                                              Gestor = $"{ase.PrimerNombre} {ase.SegundoNombre} {ase.PrimerNombre} {ase.PrimerApellido} {ase.SegundoApellido}",
                                              EmpresaPlanilla = empre.Nombre
                                          }).OrderByDescending(x => x.PrestamoId).ToListAsync();


                return Ok(new { persona, prestamosPer });
            }

            var empresa = await _dbContext.Empresas.Where(x => x.EntidadId == entidadId)
                                            .Select(x => new
                                            {
                                                Nombre = x.Nombre,
                                                x.Direccion,
                                                x.Telefono
                                            }).FirstOrDefaultAsync();

            //var agenteE = await (from pre in _dbContext.Prestamos
            //                     join ent in _dbContext.Entidades on pre.GestorPrestamoId equals ent.Id
            //                     join per in _dbContext.Personas on ent.Id equals per.EntidadId
            //                     where pre.Id == id
            //                     select new
            //                     {
            //                         Nombre = per.PrimerNombre + " " + per.SegundoApellido,

            //                     }).FirstOrDefaultAsync();

            var prestamosEmp = await (from pre in _dbContext.Prestamos
                                      join ase in _dbContext.Personas on pre.GestorPrestamoId equals ase.EntidadId
                                      //join emp in _dbContext.Empresas on pre.EmpresaPrestamoId equals emp.EntidadId
                                      join tc in _dbContext.TipoPrestamos on pre.TipoPrestamoId equals tc.Id
                                      join est in _dbContext.EstadoPrestamos on pre.EstadoPrestamoId equals est.Id
                                      where pre.EntidadPrestamoId == entidadId
                                      select new
                                      {
                                          PrestamoId = pre.Id,
                                          PrestamoReferencia = pre.ReferenciaMigracion,
                                          pre.FechaAprobacion,
                                          TipoCredito = tc.Nombre,
                                          pre.MontoTotalProyectado,
                                          Saldo = 0,
                                          Estado = est.Nombre,
                                          pre.DiasMora
                                      }).OrderByDescending(x => x.PrestamoId).ToListAsync();

            return Ok(new { empresa, prestamosEmp });

        }

        [HttpGet("datos_prospecto/{entidadId:int}")]
        public async Task<ActionResult<DatosProspectoDto>> GetDatosProspecto(int entidadId, int prestamoId)
        {
            DatosProspectoDto datosProspectoDto = new DatosProspectoDto();
            DatosPersonaDto? datosPersona = new DatosPersonaDto();
            DatosEmpresaDto? datosEmpresa = new DatosEmpresaDto();
            DatosPrestamoDto? datosPrestamo = new DatosPrestamoDto();

            var entidad = await _dbContext.Entidades.Where(e => e.Id == entidadId).FirstOrDefaultAsync();


            if (entidad.TipoEntidadId == 1)
            {
                var persona = await _dbContext.Personas.Where(x => x.EntidadId == entidadId).FirstOrDefaultAsync();
                datosPersona = _mapper.Map<DatosPersonaDto>(persona);
                datosPersona.ExpedienteSidId = await _dbContext.Entidades.Where(x => x.Id == persona.EntidadId).Select(x => x.ExpedienteSidId).FirstOrDefaultAsync();
                datosPersona.DescripcionEstadoCivil = await _dbContext.EstadoCivil.Where(x => x.Id == datosPersona.EstadoCivilId).Select(x => x.Nombre).FirstOrDefaultAsync();
                datosPersona.DescripcionGenero = await _dbContext.Generos.Where(x => x.Id == datosPersona.GeneroId).Select(x => x.Nombre).FirstOrDefaultAsync();
                datosPersona.DescripcionDepartamento = await _dbContext.Departamentos.Where(x => x.Id == datosPersona.DepartamentoId).Select(x => x.Nombre).FirstOrDefaultAsync();
                datosPersona.DescripcionMunicipio = await _dbContext.Municipios.Where(x => x.Id == datosPersona.MunicipioId).Select(x => x.Nombre).FirstOrDefaultAsync();
                datosEmpresa = null;

            }
            else
            {
                var empresa = await _dbContext.Empresas.Where(x => x.EntidadId == entidadId).Include(x => x.ContactoEmpresas).FirstOrDefaultAsync();

                datosEmpresa = _mapper.Map<DatosEmpresaDto>(empresa);
                datosEmpresa.ExpedienteSidId = await _dbContext.Entidades.Where(x => x.Id == empresa.EntidadId).Select(x => x.ExpedienteSidId).FirstOrDefaultAsync();

                foreach (var contacto in datosEmpresa.ContactoEmpresas)
                {
                    contacto.NombreOcupacion = await _dbContext.Ocupaciones.Where(x => x.Id == contacto.OcupacionId).Select(x => x.Nombre).FirstOrDefaultAsync();
                }

                datosPersona = null;
            }

            if (prestamoId > 0)
            {
                var prestamo = await _dbContext.Prestamos.Where(x => x.Id == prestamoId).FirstOrDefaultAsync();
                datosPrestamo = _mapper.Map<DatosPrestamoDto>(prestamo);
                //datosProspectoDto.EstadoPrestamo = await _dbContext.EstadoPrestamos.Where(x => x.Id == prestamo.EstadoPrestamoId).Select(x => x.Nombre).FirstOrDefaultAsync();

                datosPrestamo.DescripcionMontoInteresado = await _dbContext.MontosInteresados.Where(x => x.Id == datosPrestamo.MontoInteresadoId).Select(x => x.Nombre).FirstOrDefaultAsync();
                datosPrestamo.NombreEstadoPrestamo = await _dbContext.EstadoPrestamos.Where(x => x.Id == datosPrestamo.EstadoPrestamoId).Select(x => x.Nombre).FirstOrDefaultAsync();
                datosPrestamo.DescripcionProductoInteresado = await _dbContext.ProductosInteresados.Where(x => x.Id == datosPrestamo.ProductoInteresadoId).Select(x => x.Nombre).FirstOrDefaultAsync();
                datosPrestamo.DescripcionCanalIngreso = await _dbContext.CanalesIngresos.Where(x => x.Id == datosPrestamo.CanalIngresoId).Select(x => x.Nombre).FirstOrDefaultAsync();
                var nombreAsesor = _dbContext.Prestamos
                                                .Where(pre => pre.Id == prestamoId)
                                                .Join(
                                                    _dbContext.Personas,
                                                    pre => pre.GestorPrestamoId,
                                                    per => per.EntidadId,
                                                    (pre, per) => new
                                                    {
                                                        per.PrimerNombre,
                                                        per.SegundoNombre,
                                                        per.TercerNombre,
                                                        per.PrimerApellido,
                                                        per.SegundoApellido,
                                                        per.ApellidoCasada
                                                    })
                                                .Select(per => new
                                                {
                                                    NombreAsesor = per.ApellidoCasada == null
                                                        ? $"{per.PrimerNombre} {per.SegundoNombre} {per.TercerNombre} {per.PrimerApellido} {per.SegundoApellido}"
                                                        : $"{per.PrimerNombre} {per.SegundoNombre} {per.TercerNombre} {per.PrimerApellido} {per.SegundoApellido} De {per.ApellidoCasada}"
                                                })
                                                .FirstOrDefault();
                datosPrestamo.NombreAsesor = nombreAsesor?.NombreAsesor;
                var nombreAnalista = _dbContext.Prestamos
                                                .Where(pre => pre.Id == prestamoId)
                                                .Join(
                                                    _dbContext.Personas,
                                                    pre => pre.AnalistaPrestamoId,
                                                    per => per.EntidadId,
                                                    (pre, per) => new
                                                    {
                                                        per.PrimerNombre,
                                                        per.SegundoNombre,
                                                        per.TercerNombre,
                                                        per.PrimerApellido,
                                                        per.SegundoApellido,
                                                        per.ApellidoCasada
                                                    })
                                                .Select(per => new
                                                {
                                                    NombreAnalista = per.ApellidoCasada == null
                                                        ? $"{per.PrimerNombre} {per.SegundoNombre} {per.TercerNombre} {per.PrimerApellido} {per.SegundoApellido}"
                                                        : $"{per.PrimerNombre} {per.SegundoNombre} {per.TercerNombre} {per.PrimerApellido} {per.SegundoApellido} De {per.ApellidoCasada}"
                                                })
                                                .FirstOrDefault();
                datosPrestamo.NombreAnalista = nombreAnalista?.NombreAnalista;
                var desembolsoId = await _dbContext.Desembolsos?.Where(x => x.PrestamoId == prestamoId).Select(x => x.Id).FirstOrDefaultAsync();
                datosPrestamo.DesembolsoId = desembolsoId;

            }
            else
            {
                datosPrestamo = null;
            }

            datosProspectoDto.DatosPersona = datosPersona;
            datosProspectoDto.DatosEmpresa = datosEmpresa;
            datosProspectoDto.DatosPrestamo = datosPrestamo;
            //datosProspectoDto.PrestamoId = prestamo.Id;
            //datosProspectoDto.EstadoPrestamoId = prestamo.EstadoPrestamoId;
            //datosProspectoDto.ProductoInteresadoId = prestamo.ProductoInteresadoId;
            //datosProspectoDto.MontoInteresadoId = prestamo.MontoInteresadoId;
            //datosProspectoDto.GestorPrestamoId = prestamo.GestorPrestamoId;
            //datosProspectoDto.CanalIngresoId = prestamo.CanalIngresoId;

            return Ok(datosProspectoDto);

        }


        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateLending(int id, UpdateProspectoDto updateProspectoDto)
        {
            try
            {
                var bitacoraFicha = new BitacoraFicha();
                var personaDto = updateProspectoDto.DatosPersona;

                if (personaDto is not null)
                {
                    //if (!personaDto.PoseeNegocio)
                    //{
                    //    return BadRequest("No se puede Grabar, porque selecciono la Opción No Posee Negocio");
                    //}
                    var persona = await _unitOfWork.Repository<Persona>().GetByIdAsync(personaDto.Id);

                    if (persona == null) return NotFound();

                    _mapper.Map(personaDto, persona);

                    if (updateProspectoDto.AppUserAutorizoId is not null)
                    {
                        bitacoraFicha = new BitacoraFicha
                        {
                            EntidadId = persona.EntidadId,
                            AppUserId = updateProspectoDto.AppUserModificoId,
                            AppUserAuthorizedId = updateProspectoDto.AppUserAutorizoId,
                            Comentarios = null
                        };

                        _unitOfWork.Repository<BitacoraFicha>().Add(bitacoraFicha);
                    }

                    //_unitOfWork.Repository<Persona>().Update(persona);
                }

                var empresaDto = updateProspectoDto.DatosEmpresa;

                if (empresaDto is not null)
                {
                    var rangoContactos = await _dbContext.ContactosEmpresas.Where(x => x.EmpresaId == empresaDto.Id).ToListAsync();

                    _unitOfWork.Repository<ContactoEmpresa>().DeleteRange(rangoContactos);

                    var empresa = await _unitOfWork.Repository<Empresa>().GetByIdAsync(empresaDto.Id);

                    if (empresa == null) return NotFound();

                    _mapper.Map(empresaDto, empresa);
                }

                var prestamoDto = updateProspectoDto.DatosPrestamo;


                if (prestamoDto is not null)
                {
                    if (prestamoDto.EstadoPrestamoId == 13 || prestamoDto.EstadoPrestamoId == 15)
                    {
                        var detalleplanPago = await _dbContext.DetallePlanPagoTemporales.Where(x => x.PrestamoId == prestamoDto.Id).ToListAsync();

                        _dbContext.DetallePlanPagoTemporales.RemoveRange(detalleplanPago);
                        await _dbContext.SaveChangesAsync();
                    }

                    if (prestamoDto.ObjetivoCredito is not null || prestamoDto.OtrosIngresos > 0)
                    {
                        var empresa = await _dbContext.Empresas.FirstOrDefaultAsync(x => x.EntidadId == prestamoDto.EntidadPrestamoId);
                        if (empresa is not null)
                        {
                            empresa.OtrosIngresos = prestamoDto.OtrosIngresos;
                            empresa.OrigenOtrosIngresos = prestamoDto.OrigenIngresos;
                            //await SaveChanges();
                        }
                    }

                    var prestamo = await _unitOfWork.Repository<Prestamo>().GetByIdAsync(prestamoDto.Id);

                    if (prestamo == null) return NotFound();

                    if (prestamo.EstadoPrestamoId != prestamoDto.EstadoPrestamoId)
                    {
                        var bitacoraPrestamo = new BitacoraPrestamo
                        {
                            PrestamoId = prestamo.Id,
                            AppUserId = prestamoDto.AppUserId,
                            Comentarios = null,
                            TimeInStatus = 0,
                            EstadoPrestamoId = prestamo.EstadoPrestamoId,
                            NuevoEstadoPrestamoId = prestamoDto.EstadoPrestamoId
                        };

                        _unitOfWork.Repository<BitacoraPrestamo>().Add(bitacoraPrestamo);
                    }

                    _mapper.Map(prestamoDto, prestamo);
                }


                await _unitOfWork.Complete();
                //await UpdateComplements(id);

                //_dbContext.TipoPrestamos.Update(tipoPrestamo);
                //var result = await repository.Complete();

                //if (result <= 0) return new BadRequestObjectResult("No se pudo actualizar el tipo de préstamo");                
                return Ok(new { message = "Tipo de préstamo actualizado con éxito" });
            }
            catch (Exception e)
            {
                return e.InnerException != null
                    ? new BadRequestObjectResult(e.InnerException.Message)
                    : new BadRequestObjectResult(e.Message);
            }
        }

        [HttpPut("carpeta/{id:int}")]
        public async Task<ActionResult<object>> UpdateCarpetaCredito(int id, UpdateCarpetaPrestamoDto updateCarpetaPrestamoDto)
        {
            var prestamo = await _unitOfWork.Repository<Prestamo>().GetByIdAsync(id);

            prestamo.CarpetaSidId = updateCarpetaPrestamoDto.CarpetaSidId;

            await _unitOfWork.Complete();

            return Ok(new { mensaje = "Actualización realizada satisfactoriamente!" });
        }

        [HttpGet("persona/{personaId}")]
        public async Task<ActionResult<IReadOnlyList<object>>> GetPersonById(int personaId)
        {
            var persona = await (from per in _dbContext.Personas
                                 where per.Id == personaId
                                 select new
                                 {
                                     per.PrimerNombre,
                                     per.SegundoNombre,
                                     per.TercerNombre,
                                     per.PrimerApellido,
                                     per.SegundoApellido,
                                     per.ApellidoCasada,
                                     per.FechaNacimiento,
                                     per.GeneroId,
                                     per.Email,
                                     DPI = per.NumeroDocumento,
                                     per.Direccion,
                                     per.Colonia,
                                     per.NumeroTelefono,
                                     per.NumeroCelular,
                                     per.NumeroTelefonoNegocio,
                                     per.NIT,
                                     per.PaisNacimientoId,
                                     per.DepartamentoId,
                                     per.MunicipioId,
                                     per.EstadoCivilId,
                                     per.DireccionNegocio,
                                     per.OcupacionSinFinId,
                                     per.Comentarios,
                                     per.CodigoSAP
                                 }).ToListAsync();

            return Ok(persona);
        }

        [HttpGet("busqueda_personas/{tipoEntidadId}")]
        public async Task<ActionResult<ListadoProspectos>> GetSearchPerson(int tipoEntidadId)
        {
            List<Core.Entities.Views.ListadoProspectos> listado = new();

            listado = await _dbContext.Set<ListadoProspectos>().ToListAsync();

            listado = listado.Where(x => x.TipoEntidadId == tipoEntidadId).DistinctBy(x => x.EntidadId).ToList();

            return Ok(listado);
        }

        [HttpPut("persona/{personaId}")]
        public async Task<ActionResult<object>> PutPersonaById(int personaId, UpdatePersonLendingDto updatePersonLendingDto)
        {
            //var prestamo = await _dbContext.Prestamos.Where(p => p.Id == prestamoId).FirstOrDefaultAsync();

            //prestamo.GestorPrestamoId = updatePersonLendingDto.AsesorId;
            //prestamo.EmpresaPrestamoId = updatePersonLendingDto.EmpresaPlanillaId;
            //prestamo.TipoPrestamoId = updatePersonLendingDto.TipoPrestamoId;

            //_unitOfWork.Repository<Prestamo>().Update(prestamo);

            //var result = await _unitOfWork.Complete();

            //if (result < 0) return null!;

            var persona = await _dbContext.Personas.Where(p => p.Id == personaId).FirstOrDefaultAsync();

            persona.PrimerNombre = updatePersonLendingDto.PrimerNombre;
            persona.SegundoNombre = updatePersonLendingDto.SegundoNombre;
            persona.TercerNombre = updatePersonLendingDto.TercerNombre;
            persona.PrimerApellido = updatePersonLendingDto.PrimerApellido;
            persona.SegundoApellido = updatePersonLendingDto.SegundoApellido;
            persona.ApellidoCasada = updatePersonLendingDto.ApellidoCasada;
            persona.FechaNacimiento = updatePersonLendingDto.FechaNacimiento;
            persona.GeneroId = updatePersonLendingDto.GeneroId;
            persona.Email = updatePersonLendingDto.Email;
            persona.NumeroDocumento = updatePersonLendingDto.NumeroDocumento;
            persona.Direccion = updatePersonLendingDto.Direccion;
            persona.Colonia = updatePersonLendingDto.Colonia;
            persona.TipoViviendaId = updatePersonLendingDto.TipoViviendaId;
            persona.NumeroTelefono = updatePersonLendingDto.NumeroTelefono;
            persona.NumeroCelular = updatePersonLendingDto.NumeroCelular;
            persona.NumeroTelefonoNegocio = updatePersonLendingDto.NumeroTelefonoLaboral;
            persona.NIT = updatePersonLendingDto.NIT;
            persona.EstadoCivilId = updatePersonLendingDto.EstadoCivilId;
            persona.PaisNacimientoId = updatePersonLendingDto.PaisNacimientoId;
            persona.DepartamentoId = updatePersonLendingDto.DepartamentoId;
            persona.MunicipioId = updatePersonLendingDto.MunicipioId;
            persona.OcupacionSinFinId = updatePersonLendingDto.OcupacionId;
            persona.DireccionNegocio = updatePersonLendingDto.DireccionLaboral;
            persona.Comentarios = updatePersonLendingDto.Comentarios;
            persona.CodigoSAP = updatePersonLendingDto.CodigoSAP;

            _unitOfWork.Repository<Persona>().Update(persona);

            var result = await _unitOfWork.Complete();

            if (result < 0) return null!;

            return Ok(new { message = "Acción realizada Satisfactoriamente" });

        }

        [HttpGet("saldos/{prestamoId:int}")]
        public async Task<ObtenerSaldosDto> GetSaldos(int prestamoId)
        {
            /** Aplicación de Mora **/
            var saldosPrestamo = await _dbContext.Prestamos.Where(p => p.Id == prestamoId).FirstOrDefaultAsync();

            var saldoCapital = saldosPrestamo.MontoOtorgado;
            var saldoInteres = saldosPrestamo.InteresProyectado;
            var saldoIvaInteres = saldosPrestamo.IvaProyectado;
            var saldoMora = 0.0m;
            var saldoIvaMora = 0.0m;
            var totalSaldo = saldoCapital + saldoInteres + saldoIvaInteres + saldoMora + saldoIvaMora;

            var pagoCapital = await _dbContext.EstadoCuentas.Where(e => e.PrestamoId == prestamoId && e.TipoTransaccionId == 8).SumAsync(e => e.Abono);
            var pagoInteres = await _dbContext.EstadoCuentas.Where(e => e.PrestamoId == prestamoId && e.TipoTransaccionId == 9).SumAsync(e => e.Abono);
            var pagoIvaInteres = await _dbContext.EstadoCuentas.Where(e => e.PrestamoId == prestamoId && e.TipoTransaccionId == 10).SumAsync(e => e.Abono);

            saldoCapital -= pagoCapital;
            saldoInteres -= pagoInteres;
            saldoIvaInteres -= pagoIvaInteres;

            var resultado = await _dbContext.SaldosMigracion(prestamoId).FirstOrDefaultAsync();

            if (resultado is not null)
            {
                saldoCapital = resultado.SaldoCapital;
                saldoInteres = resultado.SaldoInteres;
                saldoIvaInteres = resultado.SaldoIvaInteres;
                saldoMora = resultado.SaldoMora;
                saldoIvaMora = resultado.SaldoIvaMora;
                totalSaldo = resultado.SaldoCapital + resultado.SaldoInteres + resultado.SaldoIvaInteres + resultado.SaldoMora + resultado.SaldoIvaMora;
            }


            return new ObtenerSaldosDto
            { SaldoCapital = saldoCapital, SaldoIntereses = saldoInteres, SaldoIvaInteres = saldoIvaInteres, SaldoMora = saldoMora, SaldoIvaMora = saldoIvaMora, TotalSaldo = totalSaldo };

        }

        [HttpGet("plan_pago/{prestamoId:int}")]
        public async Task<ActionResult<object>> GetPlanPago(int prestamoId)
        {
            return await _dbContext.PlanPagos.Where(p => p.PrestamoId == prestamoId).Select(p => new
            {
                p.PrestamoId,
                p.Periodo,
                p.CuotaCapital,
                p.CuotaIntereses,
                p.CuotaIvaIntereses,
                p.CuotaGastos,
                p.TotalCuota,
                p.SaldoTotal,
                p.FechaPago,
                p.Aplicado
            }).ToListAsync();

        }

        [HttpGet("saldos_plan_pago/{prestamoId:int}")]
        public async Task<ActionResult<object>> GetSaldosPlanPago(int prestamoId)
        {
            return await _dbContext.PlanPagos.Where(p => p.PrestamoId == prestamoId).Select(p => new
            {
                p.PrestamoId,
                p.Periodo,
                p.SaldoCapital,
                p.SaldoIntereses,
                p.SaldoIvaIntereses,
                p.SaldoMora,
                p.SaldoIvaMora,
                SaldoTotal = p.SaldoCapital + p.SaldoIntereses + p.SaldoIvaIntereses + p.SaldoMora + p.SaldoIvaMora,
                p.FechaPago,
                p.Aplicado,
                planPagoId = p.Id
            }).ToListAsync();

        }

        [HttpGet("estado_cuenta/{prestamoId:int}")]
        public async Task<ActionResult<object>> GetEstadoCuenta(int prestamoId)
        {
            return await _dbContext.EstadoCuentaPrestamos.Where(x => x.PrestamoId == prestamoId).ToListAsync();
        }

        [HttpGet("historial_pago/{prestamoId:int}")]
        public async Task<ActionResult<object>> GetHIstorialPago(int prestamoId, string appUserId)
        {

            var entidadId = await _dbContext.Prestamos.Where(p => p.Id == prestamoId).Select(p => p.EntidadPrestamoId).FirstOrDefaultAsync();

            var tipoEntidadId = await _dbContext.Entidades.Where(e => e.Id == entidadId).Select(e => e.TipoEntidadId).FirstOrDefaultAsync();

            string deudor;

            if (tipoEntidadId == 1)
            {
                var deudorPersona = await (from pre in _dbContext.Prestamos
                                           join ent in _dbContext.Entidades on pre.EntidadPrestamoId equals ent.Id
                                           join per in _dbContext.Personas on ent.Id equals per.EntidadId
                                           where pre.Id == prestamoId
                                           select new
                                           {
                                               Nombre = per.PrimerNombre + " " + per.PrimerApellido,
                                           }).FirstOrDefaultAsync();
                deudor = deudorPersona.Nombre;
            }
            else
            {
                var deudorEmpresa = await (from pre in _dbContext.Prestamos
                                           join ent in _dbContext.Entidades on pre.EntidadPrestamoId equals ent.Id
                                           join per in _dbContext.Empresas on ent.Id equals per.EntidadId
                                           where pre.Id == prestamoId
                                           select new
                                           {
                                               Nombre = per.Nombre,
                                           }).FirstOrDefaultAsync();
                deudor = deudorEmpresa.Nombre;
            }

            var usuario = await (from user in _dbContext.Users
                                 join per in _dbContext.Personas on user.PersonaId equals per.Id
                                 where user.Id == appUserId
                                 select new
                                 {
                                     Nombre = per.PrimerNombre + " " + per.PrimerApellido,
                                 }).FirstOrDefaultAsync();

            var gestor = await (from pre in _dbContext.Prestamos
                                join ent in _dbContext.Entidades on pre.GestorPrestamoId equals ent.Id
                                join per in _dbContext.Personas on ent.Id equals per.EntidadId
                                where pre.Id == prestamoId
                                select new
                                {
                                    Nombre = per.PrimerNombre + " " + per.PrimerApellido,
                                }).FirstOrDefaultAsync();

            return await _dbContext.RegistroCajas.Where(x => x.PrestamoId == prestamoId).Select(x => new
            {
                ReciboNo = x.Id,
                NombreDeudor = deudor,
                NombreUsuario = usuario.Nombre,
                NombreGestor = gestor.Nombre,
                FechaRecibo = DateTime.Now,
                Caja = x.Caja.Nombre,
                FechaTransaccion = x.FechaPago,
                TipoTranCapital = 8,
                Capital = x.MontoCapital,
                TipoTranIntereses = 9,
                Intereses = x.MontoInteres,
                TipoTranIvaIntereses = 10,
                Iva = x.MontoIvaIntereses,
                TipoTransaccionMora = 11,
                Mora = x.MontoMora,
                TipoTransaccionIvaMora = 12,
                IvaMora = x.MontoIvaMora,
                TipoTransaccionGastos = 13,
                Gastos = x.MontoGastos,
                TipoTransaccionIvaGastos = 14,
                IvaGastos = x.MontoIvaGastos,
                MontoPago = x.MontoCapital + x.MontoInteres + x.MontoIvaIntereses + x.MontoMora + x.MontoIvaMora + x.MontoGastos + x.MontoIvaGastos,
                FormaPago = x.FormaPago.Nombre,
                NombreBanco = x.Banco.Nombre,
                Boleta = x.NumeroDocumento
            }).ToListAsync();
        }

        [HttpGet("distribuye_pago/{prestamoId:int}")]
        public async Task<DistribuyePagoDto> GetDistribuyePago(int prestamoId, decimal montoPago, DateTime fechaPago, bool aplicaMora = true)
        {
            decimal saldoMonto = montoPago;
            int diasMora = 0;
            decimal montoMora = 0.0m, montoIvaMora = 0.0m, montoIntereses = 0.0m, montoIvaIntereses = 0.0m, montoCapital = 0.0m, montoExcedente = 0.0m, capitalVencido = 0.0m,
                    cargoMontoMora = 0.0m, cargoMontoIvaMora = 0.0m;

            /** Plan de Pago Couta Vigente **/

            var planPago = await _dbContext.PlanPagos.Where(p => p.PrestamoId == prestamoId && p.Aplicado == false).FirstOrDefaultAsync();

            /** Se Calcula Mora si Existe **/
            var tasaMora = await _dbContext.Prestamos.Where(p => p.Id == prestamoId).Select(p => p.TasaMora).FirstOrDefaultAsync();

            if (aplicaMora == true)
            {
                //tasaMora = tasaMora / 100.00m;                

                diasMora = (int)(fechaPago - planPago.FechaPago).TotalDays;

                if (diasMora <= 0)
                {
                    diasMora = 0;
                }
            }


            var planesPago = await _dbContext.PlanPagos.Where(p => p.PrestamoId == prestamoId && p.Aplicado == false).ToListAsync();


            foreach (var plan in planesPago)
            {
                var fechaReferencia = fechaPago.Date; //DateTime.Now.Date;
                int iteracion = 0;

                if (!aplicaMora)
                {
                    fechaReferencia = (plan.FechaCreacion == plan.FechaModificacion) ? plan.FechaCreacion.Date.AddDays(1) : plan.FechaCreacion.Date;
                }

                if (fechaReferencia.Date < plan.FechaModificacion)
                {
                    plan.CuotaMora = 0;
                    plan.SaldoMora = 0;
                    plan.CuotaIvaMora = 0;
                    plan.SaldoIvaMora = 0;
                    //plan.FechaModificacion = plan.FechaCreacion;
                    //plan.TotalCuota = plan.CuotaCapital + plan.CuotaIntereses + plan.CuotaIvaIntereses + plan.CuotaMora + plan.CuotaIvaMora;
                    _dbContext.Update(plan);
                    await _dbContext.SaveChangesAsync();
                }
                if (fechaReferencia > plan.FechaModificacion)
                {
                    plan.CuotaMora = 0;
                    plan.SaldoMora = 0;
                    plan.CuotaIvaMora = 0;
                    plan.SaldoIvaMora = 0;
                    //plan.TotalCuota = plan.CuotaCapital + plan.CuotaIntereses + plan.CuotaIvaIntereses + plan.CuotaMora + plan.CuotaIvaMora;
                    _dbContext.Update(plan);
                    await _dbContext.SaveChangesAsync();
                }


                if (plan.FechaPago <= DateTime.Now && plan.FechaModificacion.Date != fechaReferencia)
                {
                    capitalVencido += plan.SaldoCapital; //* tasaMora;                
                    //cargoMontoMora += capitalVencido * tasaMora / 365 * diasMora;
                    //cargoMontoIvaMora += cargoMontoMora * 0.12m;
                    //if (!aplicaMora) { plan.CuotaMora = 0; } else { plan.CuotaMora += cargoMontoMora; }
                    //if (!aplicaMora) { plan.SaldoMora = 0; } else { plan.SaldoMora += cargoMontoMora; }
                    //if (!aplicaMora) { plan.CuotaIvaMora = 0; } else { plan.CuotaIvaMora += cargoMontoIvaMora; }
                    //if (!aplicaMora) { plan.SaldoIvaMora = 0; } else { plan.SaldoIvaMora += cargoMontoIvaMora; }
                    if (!aplicaMora) { plan.FechaModificacion = plan.FechaCreacion; } else { plan.FechaModificacion = fechaPago.Date; /*DateTime.Now;*/ }
                    //plan.TotalCuota = plan.CuotaCapital + plan.CuotaIntereses + plan.CuotaIvaIntereses + plan.CuotaMora + plan.CuotaIvaMora; 
                    _dbContext.Update(plan);
                    await _dbContext.SaveChangesAsync();
                }
            }
            cargoMontoMora = capitalVencido * tasaMora / 365 * diasMora;
            cargoMontoIvaMora = cargoMontoMora * 0.12m;
            if (!aplicaMora) { planPago.CuotaMora = 0; } else { planPago.CuotaMora += cargoMontoMora; }
            if (!aplicaMora) { planPago.SaldoMora = 0; } else { planPago.SaldoMora += cargoMontoMora; }
            if (!aplicaMora) { planPago.CuotaIvaMora = 0; } else { planPago.CuotaIvaMora += cargoMontoIvaMora; }
            if (!aplicaMora) { planPago.SaldoIvaMora = 0; } else { planPago.SaldoIvaMora += cargoMontoIvaMora; }
            //if (!aplicaMora) { planPago.FechaModificacion = planPago.FechaCreacion; } else { planPago.FechaModificacion = fechaPago.Date; }
            _dbContext.Update(planPago);
            await _dbContext.SaveChangesAsync();

            /** Pago Mora  **/
            if (planPago.SaldoMora > 0 && saldoMonto < planPago.SaldoMora)
            {
                montoMora = saldoMonto;
                saldoMonto = 0.0m;
            }

            if (saldoMonto >= planPago.SaldoMora)
            {
                saldoMonto -= planPago.SaldoMora;
                montoMora = planPago.SaldoMora;
            }

            /** Pago Iva Mora **/
            if (planPago.SaldoIvaMora > 0 && saldoMonto < planPago.SaldoIvaMora)
            {
                montoIvaMora = saldoMonto;
                saldoMonto = 0.0m;
            }

            if (saldoMonto >= planPago.SaldoIvaMora)
            {
                saldoMonto -= planPago.SaldoIvaMora;
                montoIvaMora = planPago.SaldoIvaMora;
            }


            /** Si el pago es mayor a la cuota **/
            if (saldoMonto > (planPago.SaldoCapital + planPago.SaldoIntereses + planPago.SaldoIvaIntereses))
            {
                montoExcedente = saldoMonto - (planPago.SaldoCapital + planPago.SaldoIntereses + planPago.SaldoIvaIntereses);
                saldoMonto = planPago.SaldoCapital + planPago.SaldoIntereses + planPago.SaldoIvaIntereses;
                foreach (var plan in planesPago)
                {
                    if (montoExcedente >= 0.01m && plan.Id > planPago.Id)
                    {
                        AbonarExcedente(plan.SaldoIvaIntereses, plan.SaldoIntereses, plan.SaldoCapital, ref montoExcedente, ref montoIvaIntereses, ref montoIntereses, ref montoCapital);
                    }
                }
            }


            if (planPago.SaldoIntereses > 0.00m || planPago.SaldoIvaIntereses > 0.00m)
            {
                /** Pago Intereses **/
                if (planPago.SaldoIntereses > 0 && saldoMonto < planPago.SaldoIntereses)
                {
                    /** Se calcula IVA correspondiente **/
                    var ivaMontoIntereses = saldoMonto * 0.12m;
                    montoIntereses += saldoMonto - ivaMontoIntereses;
                    saldoMonto = ivaMontoIntereses;
                }

                if (saldoMonto >= planPago.SaldoIntereses)
                {
                    saldoMonto -= planPago.SaldoIntereses;
                    montoIntereses += planPago.SaldoIntereses;
                }

                /** Pago Iva Intereses **/
                if (planPago.SaldoIvaIntereses > 0 && saldoMonto < planPago.SaldoIvaIntereses)
                {
                    montoIvaIntereses += saldoMonto;
                    saldoMonto = 0.0m;
                }
                if (saldoMonto >= planPago.SaldoIvaIntereses)
                {
                    saldoMonto -= planPago.SaldoIvaIntereses;
                    montoIvaIntereses += planPago.SaldoIvaIntereses;
                }
            }

            /** Cuota Capital **/
            if (planPago.SaldoCapital > 0 && saldoMonto < planPago.SaldoCapital)
            {
                montoCapital += saldoMonto;
                saldoMonto = 0.0m;
            }

            if (saldoMonto >= planPago.SaldoCapital)
            {
                saldoMonto -= planPago.SaldoCapital;
                montoCapital += planPago.SaldoCapital;
            }


            var EstadoCredito = await _dbContext.Prestamos.Where(p => p.Id == planPago.PrestamoId).Select(p => p.EstadoPrestamo.Nombre).FirstOrDefaultAsync();

            var getSaldos = await GetSaldos(prestamoId);
            var saldoTotal = getSaldos.TotalSaldo;


            return (new DistribuyePagoDto
            {
                MontoPago = montoPago,
                PagoCapital = montoCapital,
                PagoCapitalAnticipado = 0.00m,
                PagoIntereses = montoIntereses,
                PagoIvaIntereses = montoIvaIntereses,
                PagoMora = montoMora,
                PagoIvaMora = montoIvaMora,
                TotalGastos = planPago.CuotaGastos,
                IvaGastos = planPago.CuotaIvaGastos,
                SaldoTotalPagar = saldoTotal,
                FechaProximoPago = planPago.FechaPago.AddMonths(1),
                DiasMora = diasMora,
                EstadoCredito = await _dbContext.Prestamos.Where(p => p.Id == planPago.PrestamoId).Select(p => p.EstadoPrestamo.Nombre).FirstOrDefaultAsync(),
                TotalCuotasVencidas = 0,
                CuotasVencidasPagadas = 0
            });
        }

        private decimal AbonarExcedente(decimal cuotaIvaIntereses, decimal cuotaIntereses, decimal cuotaCapital, ref decimal montoExcedente, ref decimal montoIvaIntereses, ref decimal montoIntereses, ref decimal montoCapital)
        {
            if (montoExcedente >= (cuotaIntereses + cuotaIvaIntereses))
            {
                montoIvaIntereses += cuotaIvaIntereses;
                montoIntereses += cuotaIntereses;
                montoExcedente -= cuotaIvaIntereses + cuotaIntereses;
            }
            else
            {
                montoIvaIntereses += montoExcedente * 0.12m;
                montoExcedente -= montoExcedente * 0.12m;
                montoIntereses += montoExcedente;
                montoExcedente = 0;
            }

            if (montoExcedente >= cuotaCapital)
            {
                montoCapital += cuotaCapital;
                montoExcedente -= cuotaCapital;
            }
            else if (montoExcedente > 0 && cuotaCapital > montoExcedente)
            {
                montoCapital += montoExcedente;
                montoExcedente = 0;
            }

            return montoExcedente;
        }

        [HttpPost("plan-pago-temporal")]
        public async Task<PlanPagoTemporalDto> CreatePaymentPlanTemporal(CreatePaymentPlanTemporalDto createPaymentPlanDto)
        {
            decimal
                principalAmount = createPaymentPlanDto.PrincipalAmount,
                interestRate = createPaymentPlanDto.InterestRate,
                administrativeExpensesRate = createPaymentPlanDto.AdministrativeExpesesRate,
                taxRate = createPaymentPlanDto.TaxRate,
                principalFee, interestFee, administrativeExpensesFee, taxFee, subTotalFee, totalFee, balance;

            int term = createPaymentPlanDto.Term;

            var fechaPago = /*new DateTime(createPaymentPlanDto.StartDate.Year, createPaymentPlanDto.StartDate.Month, 2)*/createPaymentPlanDto.PayDate.AddMonths(1);//.AddDays(-1);

            var diasDiferencia = fechaPago.Subtract(DateTime.Now).Days;

            if (diasDiferencia < 30)
            {
                fechaPago = fechaPago.AddMonths(1);
            }

            IEnumerable<DetallePlanPagoTemporal> projectionDb = new List<DetallePlanPagoTemporal>();
            var projection = new List<ProjectionDto>();
            var infoPrestamo = new InfoPrestamoDto();

            var tipoCuota = createPaymentPlanDto.TipoCuota;

            if (interestRate == 0)
            {
                interestFee = 0.0m;
                principalFee = principalAmount;
                administrativeExpensesFee = 0.0m;
                taxFee = 0.0m;
                subTotalFee = principalAmount;
                totalFee = principalAmount;
                balance = principalAmount;
            }
            else
            {
                //subTotalFee = await _dbContext.Prestamos.Select(
                //                            p => Scalars.CalculateFee(createPaymentPlanDto.PrincipalAmount, createPaymentPlanDto.InterestRate, createPaymentPlanDto.Term))
                //                    .FirstOrDefaultAsync();


                interestFee = principalAmount * interestRate / 12;
                double interestPlusTaxFee = 0.00000;
                interestPlusTaxFee = (double)(interestRate * 1.12m / 12);

                principalFee = (tipoCuota == 2) ? principalAmount : principalAmount / term;

                //principalFee = principalAmount / term;
                //administrativeExpensesFee = subTotalFee * (administrativeExpensesRate * 0.01m);
                taxFee = interestFee * taxRate; //(taxRate * 0.01m);
                                                //totalFee = principalFee + interestFee + taxFee; //+ administrativeExpensesFee;

                balance = tipoCuota == 1 ? principalAmount - principalFee : principalAmount;

                if (balance < 0)
                {
                    balance = 0;
                }

                var totalCuotaNivelada = (double)principalAmount * (Math.Pow((1 + interestPlusTaxFee), term) * interestPlusTaxFee) / (Math.Pow((1 + interestPlusTaxFee), term) - 1);


                var code = Guid.NewGuid();

                var saldoAnterior = balance;

                var ultimoPagoCapital = 0.00m;

                decimal cuotaCapital, cuotaIntereses, cuotaIvaIntereses, totalCuota, saldoCapital;

                for (int i = 1; i <= term; i++)
                {

                    // tipo cuota:  1. Flat 2. Capital Vencimiento 3. Sobre Saldos 4. Cuota Nivelada

                    cuotaIntereses = (tipoCuota == 3 || tipoCuota == 4) ? balance * (interestRate / 12)
                                        : Math.Round(interestFee, 2);

                    cuotaIvaIntereses = tipoCuota == 3 ? balance * (interestRate / 12) * taxRate
                                        : tipoCuota == 4 ? cuotaIntereses * taxRate
                                        : taxFee;

                    cuotaCapital = tipoCuota == 1 || tipoCuota == 3 ? principalFee
                                        : (tipoCuota == 2 && i == term) ? principalFee
                                        : tipoCuota == 4 ? (decimal)totalCuotaNivelada - cuotaIntereses - cuotaIvaIntereses
                                        : 0.0m;

                    totalCuota = tipoCuota == 1 ? cuotaIntereses + cuotaIvaIntereses + cuotaCapital
                                        : (tipoCuota == 2 && i == term) ? principalFee + interestFee + taxFee
                                        : tipoCuota == 3 ? principalFee + (balance * (interestRate / 12)) + (balance * (interestRate / 12) * taxRate)
                                        : (tipoCuota == 4) ? (decimal)totalCuotaNivelada
                                        : 0 + interestFee + taxFee;

                    saldoCapital = tipoCuota == 1 ? balance
                                        : (tipoCuota == 2 && i == term) ? principalAmount
                                        : tipoCuota == 3 || tipoCuota == 4 ? balance
                                        //: tipoCuota == 5 ? Math.Round(balance -= (decimal)Math.Round(totalCuotaNivelada, 2) - Math.Round(balance * (interestRate / 12), 2) - Math.Round(taxFee, 2), 2)
                                        : 0;


                    var temporal = new DetallePlanPagoTemporal
                    {
                        PlanPagoId = code.ToString(),
                        PrestamoId = createPaymentPlanDto.SolicitudId,
                        Mes = i,
                        CuotaCapital = cuotaCapital,
                        CuotaIntereses = cuotaIntereses,
                        CuotaGastosAdministrativos = 0,// administrativeExpensesFee,
                        CuotaIvaIntereses = cuotaIvaIntereses,
                        TotalCuota = totalCuota,
                        SaldoCapital = saldoCapital,
                        FechaPago = fechaPago
                    };


                    _dbContext.DetallePlanPagoTemporales.Add(temporal);

                    await _dbContext.SaveChangesAsync();


                    /** Calculo Balance **/
                    ultimoPagoCapital = temporal.CuotaCapital;
                    saldoCapital = temporal.SaldoCapital - ultimoPagoCapital;
                    balance = tipoCuota == 1 ? balance - principalFee : saldoCapital; /** Ojo **/

                    //interestFee = balance * (interestRate * 0.01m) / 12;
                    //principalFee = subTotalFee - interestFee;

                    if (balance < 0) { balance = 0; }

                    //fechaPago = new DateTime(fechaPago.Year, fechaPago.Month, 1);
                    fechaPago = fechaPago.AddMonths(1);
                }

                projectionDb = await _dbContext.DetallePlanPagoTemporales.Where(p => p.PlanPagoId == code.ToString()).ToListAsync();

                projection = _mapper.Map<List<ProjectionDto>>(projectionDb);

                infoPrestamo = new InfoPrestamoDto
                {
                    SolicitudId = createPaymentPlanDto.SolicitudId,
                    NombreProspecto = createPaymentPlanDto.NombreProspecto,
                    ProductoInteresado = createPaymentPlanDto.ProductoInteresado,
                    MontoRealSolicitado = createPaymentPlanDto.PrincipalAmount,
                    Plazo = createPaymentPlanDto.Term,
                    TasaIntereses = createPaymentPlanDto.InterestRate,
                    DescripcionTipoCuota = createPaymentPlanDto.DescripcionTipoCuota,
                    NombreAsesor = createPaymentPlanDto.NombreAsesor
                };
            }

            var planPagoTemporalDto = new PlanPagoTemporalDto
            {
                InfoPrestamo = infoPrestamo,
                Projection = projection
            };


            return planPagoTemporalDto;
        }

        [HttpPost("plan-pago")]
        public async Task<object> CreatePaymentPlan(CreatePaymentPlanDto createPaymentPlanDto)
        {
            var prestamo = await _unitOfWork.Repository<Prestamo>().GetByIdAsync(createPaymentPlanDto.PrestamoId);

            prestamo.Plazo = createPaymentPlanDto.Plazo;
            prestamo.TasaInteres = createPaymentPlanDto.TasaInteres; /// 100.0m;
            prestamo.TasaIva = createPaymentPlanDto.TasaIva; /// 100.0m;
            prestamo.TasaMora = createPaymentPlanDto.TasaMora; /// 100.0m;
            prestamo.TasaGastos = createPaymentPlanDto.TasaGastos; /// 100.0m;
            prestamo.FechaPlan = createPaymentPlanDto.FechaPlan;

            PlanPago planPago = new PlanPago();

            int result;

            if (createPaymentPlanDto.PlanPagos != null)
            {
                var fila = createPaymentPlanDto.PlanPagos.FirstOrDefault();
                var totalProyectado = (prestamo.MontoOtorgado) + (fila.CuotaIntereses * prestamo.Plazo) + (fila.CuotaIvaIntereses * prestamo.Plazo);
                foreach (var plan in createPaymentPlanDto.PlanPagos)
                {
                    totalProyectado -= fila.TotalCuota;
                    planPago = _mapper.Map<PlanPago>(plan);
                    planPago.PrestamoId = prestamo.Id;
                    planPago.SaldoCapital = planPago.CuotaCapital;
                    planPago.SaldoIntereses = planPago.CuotaIntereses;
                    planPago.SaldoIvaIntereses = planPago.CuotaIvaIntereses;
                    planPago.SaldoMora = planPago.CuotaMora;
                    planPago.SaldoGastos = planPago.CuotaGastos;
                    planPago.SaldoTotal = totalProyectado;
                    _unitOfWork.Repository<PlanPago>().Add(planPago);
                }

            }

            prestamo.InteresProyectado = planPago.CuotaIntereses * prestamo.Plazo;
            prestamo.IvaProyectado = planPago.CuotaIvaIntereses * prestamo.Plazo;
            prestamo.GastosProyectados = planPago.CuotaGastos * prestamo.Plazo;
            prestamo.MontoTotalProyectado = prestamo.MontoOtorgado + prestamo.InteresProyectado + prestamo.IvaProyectado + prestamo.GastosProyectados;

            EstadoCuenta estadoCuenta = new EstadoCuenta
            {
                AppUserId = "c44ab09d-9b73-4ea9-9191-064c903ac294",
                PrestamoId = planPago.PrestamoId,
                TipoTransaccionId = 1,
                Cargo = prestamo.MontoOtorgado,
                SaldoAnterior = 0,
                SaldoActual = prestamo.MontoOtorgado,
                Concepto = "Monto Saldo Capital Inicial"
            };

            _unitOfWork.Repository<EstadoCuenta>().Add(estadoCuenta);

            estadoCuenta = new EstadoCuenta
            {
                AppUserId = "c44ab09d-9b73-4ea9-9191-064c903ac294",
                PrestamoId = planPago.PrestamoId,
                TipoTransaccionId = 2,
                Cargo = prestamo.InteresProyectado,
                SaldoAnterior = prestamo.MontoOtorgado,
                SaldoActual = prestamo.MontoOtorgado + prestamo.InteresProyectado,
                Concepto = "Monto Saldo de Intereses Inicial"
            };

            _unitOfWork.Repository<EstadoCuenta>().Add(estadoCuenta);

            estadoCuenta = new EstadoCuenta
            {
                AppUserId = "c44ab09d-9b73-4ea9-9191-064c903ac294",
                PrestamoId = planPago.PrestamoId,
                TipoTransaccionId = 3,
                Cargo = prestamo.IvaProyectado,
                SaldoAnterior = prestamo.MontoOtorgado + prestamo.InteresProyectado,
                SaldoActual = prestamo.MontoOtorgado + prestamo.InteresProyectado + prestamo.IvaProyectado,
                Concepto = "Monto Saldo Iva Inicial"
            };

            _unitOfWork.Repository<EstadoCuenta>().Add(estadoCuenta);

            prestamo.EstadoPrestamoId = 1;

            _unitOfWork.Repository<Prestamo>().Update(prestamo);

            result = await _unitOfWork.Complete();

            if (result < 0) return null!;

            var ultimoPagoPlan = await _unitOfWork.Repository<PlanPago>().GetByIdAsync(planPago.Id);

            if (ultimoPagoPlan.SaldoTotal > 0)
            {
                ultimoPagoPlan.CuotaCapital += ultimoPagoPlan.SaldoTotal;
                ultimoPagoPlan.SaldoCapital += ultimoPagoPlan.SaldoTotal;
                ultimoPagoPlan.TotalCuota = ultimoPagoPlan.CuotaCapital + ultimoPagoPlan.CuotaIntereses + ultimoPagoPlan.CuotaIvaIntereses;
                ultimoPagoPlan.SaldoTotal = 0;
            }
            else
            {
                ultimoPagoPlan.CuotaCapital -= ultimoPagoPlan.SaldoTotal;
                ultimoPagoPlan.SaldoCapital -= ultimoPagoPlan.SaldoTotal;
                ultimoPagoPlan.TotalCuota = ultimoPagoPlan.CuotaCapital + ultimoPagoPlan.CuotaIntereses + ultimoPagoPlan.CuotaIvaIntereses;
                ultimoPagoPlan.SaldoTotal = 0;
            }

            result = await _unitOfWork.Complete();

            if (result < 0) return null!;

            return Ok(new { message = "Acción realizada Satisfactoriamente" });
        }

        [HttpPost("registro-pago")]
        public async Task<ActionResult<object>> CreateRegistroPago(CreateRegistroCajaDto createRegistroCajaDto)
        {
            //return Ok(new { Mensaje = "Bloqueado Temporalmente" });

            var montoPagoCalculado = createRegistroCajaDto.MontoPago;

            createRegistroCajaDto.MontoPago = createRegistroCajaDto.MontoCapital + createRegistroCajaDto.MontoInteres + createRegistroCajaDto.MontoIvaIntereses
                    + createRegistroCajaDto.MontoMora + createRegistroCajaDto.MontoIvaMora + createRegistroCajaDto.MontoGastos + createRegistroCajaDto.MontoIvaGastos;

            if (createRegistroCajaDto.MontoPago != montoPagoCalculado)
            {
                return BadRequest("No se pudo realizar el pago. Se ha producido una Excepción por favor comuniquese con el Administrador");
            }

            var registroPago = _mapper.Map<RegistroCaja>(createRegistroCajaDto);

            _unitOfWork.Repository<RegistroCaja>().Add(registroPago);

            var result = await _unitOfWork.Complete();

            if (result < 0) return null!;

            var planPagos = await _dbContext.PlanPagos.Where(p => p.PrestamoId == createRegistroCajaDto.PrestamoId && p.Aplicado == false).ToListAsync();

            var planPago = await _dbContext.PlanPagos.Where(p => p.PrestamoId == createRegistroCajaDto.PrestamoId && p.Aplicado == false).FirstOrDefaultAsync();

            if (planPago != null)
            {
                var ultimoEstadoCuenta = await _dbContext.EstadoCuentas.Where(e => e.PrestamoId == createRegistroCajaDto.PrestamoId).OrderByDescending(e => e.Id).FirstOrDefaultAsync();
                var saldoActual = ultimoEstadoCuenta.SaldoActual;

                if (createRegistroCajaDto.MontoMora > 0)
                {
                    saldoActual = await CargoEstadoCuenta(createRegistroCajaDto.PrestamoId, 5, registroPago.Id, planPago.Id, createRegistroCajaDto.MontoIvaMora, "Cargo Iva Mora", createRegistroCajaDto.AppUserId, saldoActual);

                    /** Abono Iva Mora **/
                    saldoActual = await AbonoEstadoCuenta(createRegistroCajaDto.PrestamoId, 12, registroPago.Id, planPago.Id, createRegistroCajaDto.MontoIvaMora, "Abono Iva Mora", createRegistroCajaDto.AppUserId, saldoActual, planPagos);

                    saldoActual = await CargoEstadoCuenta(createRegistroCajaDto.PrestamoId, 4, registroPago.Id, planPago.Id, createRegistroCajaDto.MontoMora, "Cargo Mora", createRegistroCajaDto.AppUserId, saldoActual);

                    /** Abono Mora **/
                    saldoActual = await AbonoEstadoCuenta(createRegistroCajaDto.PrestamoId, 11, registroPago.Id, planPago.Id, createRegistroCajaDto.MontoMora, "Abono Mora", createRegistroCajaDto.AppUserId, saldoActual, planPagos);
                }

                if (createRegistroCajaDto.MontoIvaIntereses > 0)
                {
                    /** Abono Iva Intereses **/
                    saldoActual = await AbonoEstadoCuenta(createRegistroCajaDto.PrestamoId, 10, registroPago.Id, planPago.Id, createRegistroCajaDto.MontoIvaIntereses, "Abono Iva Intereses", createRegistroCajaDto.AppUserId, saldoActual, planPagos);
                }

                if (createRegistroCajaDto.MontoInteres > 0)
                {
                    /** Abono Intereses **/
                    saldoActual = await AbonoEstadoCuenta(createRegistroCajaDto.PrestamoId, 9, registroPago.Id, planPago.Id, createRegistroCajaDto.MontoInteres, "Abono Intereses", createRegistroCajaDto.AppUserId, saldoActual, planPagos);
                }

                if (createRegistroCajaDto.MontoCapital > 0)
                {
                    /** Abono Capital **/
                    saldoActual = await AbonoEstadoCuenta(createRegistroCajaDto.PrestamoId, 8, registroPago.Id, planPago.Id, createRegistroCajaDto.MontoCapital, "Abono Capital", createRegistroCajaDto.AppUserId, saldoActual, planPagos);
                }

                await _dbContext.SaveChangesAsync();

            }

            /** Actualización de Pagos en el Plan de Pagos **/

            decimal montoCapital = createRegistroCajaDto.MontoCapital, montoIntereses = createRegistroCajaDto.MontoInteres, montoIvaIntereses = createRegistroCajaDto.MontoIvaIntereses,
                montoMora = createRegistroCajaDto.MontoMora, montoIvaMora = createRegistroCajaDto.MontoIvaMora, montoGastos = createRegistroCajaDto.MontoGastos,
                montoIvaGastos = createRegistroCajaDto.MontoIvaGastos;

            var actualizaPlanPago = await _dbContext.PlanPagos.Where(p => p.PrestamoId == createRegistroCajaDto.PrestamoId && p.Aplicado == false).ToListAsync();



            foreach (var plan in actualizaPlanPago)
            {
                if (montoCapital >= plan.SaldoCapital)
                {
                    montoCapital -= plan.SaldoCapital;
                    plan.SaldoCapital -= plan.SaldoCapital;
                }
                else
                {
                    plan.SaldoCapital -= montoCapital;
                    montoCapital = 0;
                }

                if (montoIntereses >= plan.SaldoIntereses)
                {
                    montoIntereses -= plan.SaldoIntereses;
                    plan.SaldoIntereses -= plan.SaldoIntereses;
                }
                else
                {
                    plan.SaldoIntereses -= montoIntereses;
                    montoIntereses = 0;
                }

                if (montoIvaIntereses >= plan.SaldoIvaIntereses)
                {
                    montoIvaIntereses -= plan.SaldoIvaIntereses;
                    plan.SaldoIvaIntereses -= plan.SaldoIvaIntereses;
                }
                else
                {
                    plan.SaldoIvaIntereses -= montoIvaIntereses;
                    montoIvaIntereses = 0;
                }

                if (montoMora >= plan.SaldoMora)
                {
                    montoMora -= plan.SaldoMora;
                    plan.SaldoMora -= plan.SaldoMora;
                }
                else
                {
                    plan.SaldoMora -= montoMora;
                    montoMora = 0;
                }

                if (montoIvaMora >= plan.SaldoIvaMora)
                {
                    montoIvaMora -= plan.SaldoIvaMora;
                    plan.SaldoIvaMora -= plan.SaldoIvaMora;
                }
                else
                {
                    plan.SaldoIvaMora -= montoIvaMora;
                    montoIvaMora = 0;
                }

                if (montoGastos >= plan.SaldoGastos)
                {
                    montoGastos -= plan.SaldoGastos;
                    plan.SaldoGastos -= plan.SaldoGastos;
                }
                else
                {
                    plan.SaldoGastos -= montoGastos;
                    montoGastos = 0;
                }


                if (montoIvaGastos >= plan.SaldoIvaGastos)
                {
                    montoIvaGastos -= plan.SaldoIvaGastos;
                    plan.SaldoIvaGastos -= plan.SaldoIvaGastos;
                }
                else
                {
                    plan.SaldoIvaGastos -= montoIvaGastos;
                    montoIvaGastos = 0;
                }

                if (plan.SaldoCapital < 0.01m && plan.SaldoIntereses < 0.01m && plan.SaldoIvaIntereses < 0.01m
                    && plan.SaldoMora < 0.01m && plan.SaldoIvaMora < 0.01m && plan.SaldoGastos < 0.01m && plan.SaldoIvaGastos < 0.01m)
                {
                    plan.Aplicado = true;
                }
                _unitOfWork.Repository<PlanPago>().Update(plan);

            }

            await _unitOfWork.Complete();

            /** Actualización de Prestamo: Días de Mora y Estado **/

            var prestamo = await _dbContext.Prestamos.FirstOrDefaultAsync(x => x.Id == createRegistroCajaDto.PrestamoId);
            planPago = await _dbContext.PlanPagos.Where(p => p.PrestamoId == createRegistroCajaDto.PrestamoId && p.Aplicado == false).FirstOrDefaultAsync();

            if (planPago is not null)
            {
                var diasMora = (int)(DateTime.Now - planPago.FechaPago).TotalDays;

                if (diasMora < 0) diasMora = 0;
                prestamo.DiasMora = diasMora;
            }
            else
            {
                prestamo.DiasMora = 0;
            }


            /** Verificación de Saldo Total **/
            var saldos = await GetSaldos(prestamo.Id);

            if (saldos.TotalSaldo < 0.01m)
            {
                prestamo.EstadoPrestamoId = 4;
            }

            _unitOfWork.Repository<Prestamo>().Update(prestamo);

            await _unitOfWork.Complete();


            return Ok(new { Mensaje = "Accion Realizada Satisfactoriamente" });
        }


        [HttpPost("pago-ajustes")]
        public async Task<ActionResult<object>> CreateRegistroAjustes(CreateRegistroCajaDto createRegistroCajaDto)
        {
            var registroPago = _mapper.Map<RegistroCaja>(createRegistroCajaDto);

            _unitOfWork.Repository<RegistroCaja>().Add(registroPago);

            var result = await _unitOfWork.Complete();

            //return Ok(new { message = "Acción realizada Satisfactoriamente" });

            if (result < 0) return null!;

            var planPagos = await _dbContext.PlanPagos.Where(p => p.Id == createRegistroCajaDto.PlanPagoId).ToListAsync();

            var planPago = await _dbContext.PlanPagos.Where(p => p.Id == createRegistroCajaDto.PlanPagoId).FirstOrDefaultAsync();

            if (planPago != null)
            {
                var ultimoEstadoCuenta = await _dbContext.EstadoCuentas.Where(e => e.PrestamoId == createRegistroCajaDto.PrestamoId).OrderByDescending(e => e.Id).FirstOrDefaultAsync();
                var saldoActual = ultimoEstadoCuenta.SaldoActual;

                if (createRegistroCajaDto.TipoTransaccionId == 17)
                {
                    /** Abono Ajuste Iva Intereses **/
                    saldoActual = await AbonoEstadoCuenta(createRegistroCajaDto.PrestamoId, 17, registroPago.Id, planPago.Id, createRegistroCajaDto.MontoPago, "Exoneración de Iva Intereses", createRegistroCajaDto.AppUserId, saldoActual, planPagos);
                }

                if (createRegistroCajaDto.TipoTransaccionId == 20)
                {
                    /** Abono Ajuste Intereses **/
                    saldoActual = await AbonoEstadoCuenta(createRegistroCajaDto.PrestamoId, 20, registroPago.Id, planPago.Id, createRegistroCajaDto.MontoPago, "Exoneración de Intereses", createRegistroCajaDto.AppUserId, saldoActual, planPagos);
                }

                if (createRegistroCajaDto.TipoTransaccionId == 21)
                {
                    /** Abono Ajuste Iva Mora **/
                    saldoActual = await AbonoEstadoCuenta(createRegistroCajaDto.PrestamoId, 21, registroPago.Id, planPago.Id, createRegistroCajaDto.MontoPago, "Exoneración de Iva Mora", createRegistroCajaDto.AppUserId, saldoActual, planPagos);
                }

                if (createRegistroCajaDto.TipoTransaccionId == 22)
                {
                    /** Abono Ajuste Mora **/
                    saldoActual = await AbonoEstadoCuenta(createRegistroCajaDto.PrestamoId, 22, registroPago.Id, planPago.Id, createRegistroCajaDto.MontoPago, "Exoneración de Mora", createRegistroCajaDto.AppUserId, saldoActual, planPagos);
                }

                if (createRegistroCajaDto.TipoTransaccionId == 23)
                {
                    /** Cargo Ajuste Iva Intereses **/
                    saldoActual = await CargoEstadoCuenta(createRegistroCajaDto.PrestamoId, 23, registroPago.Id, planPago.Id, createRegistroCajaDto.MontoPago, "Exoneración de Iva Intereses", createRegistroCajaDto.AppUserId, saldoActual);
                }

                if (createRegistroCajaDto.TipoTransaccionId == 24)
                {
                    /** Abono Ajuste Intereses **/
                    saldoActual = await CargoEstadoCuenta(createRegistroCajaDto.PrestamoId, 24, registroPago.Id, planPago.Id, createRegistroCajaDto.MontoPago, "Exoneración de Intereses", createRegistroCajaDto.AppUserId, saldoActual);
                }

                await _dbContext.SaveChangesAsync();

            }

            /** Actualización de Pagos en el Plan de Pagos **/

            decimal montoPago = createRegistroCajaDto.MontoPago;
            var actualizaPlanPago = await _dbContext.PlanPagos.Where(p => p.PrestamoId == createRegistroCajaDto.PrestamoId && p.Aplicado == false).ToListAsync();



            foreach (var plan in actualizaPlanPago)
            {
                if (createRegistroCajaDto.TipoTransaccionId == 17)
                {
                    if (montoPago > 0)
                    {
                        if (montoPago >= plan.CuotaIvaIntereses)
                        {
                            montoPago -= plan.CuotaIvaIntereses;
                            plan.SaldoIvaIntereses -= plan.CuotaIvaIntereses;
                        }
                        else
                        {
                            plan.SaldoIvaIntereses = montoPago;
                            montoPago = 0;
                        }
                    }
                }

                if (createRegistroCajaDto.TipoTransaccionId == 20)
                {
                    if (montoPago > 0)
                    {
                        if (montoPago >= plan.CuotaIntereses)
                        {
                            montoPago -= plan.CuotaIntereses;
                            plan.SaldoIntereses -= plan.CuotaIntereses;
                        }
                        else
                        {
                            plan.SaldoIntereses = montoPago;
                            montoPago = 0;
                        }
                    }
                }

                if (createRegistroCajaDto.TipoTransaccionId == 21)
                {
                    if (montoPago > 0)
                    {
                        if (montoPago >= plan.CuotaIvaMora)
                        {
                            montoPago -= plan.CuotaIvaMora;
                            plan.SaldoIvaMora -= plan.CuotaIvaMora;
                        }
                        else
                        {
                            plan.SaldoIvaMora = montoPago;
                            montoPago = 0;
                        }
                    }
                }

                if (createRegistroCajaDto.TipoTransaccionId == 22)
                {
                    if (montoPago > 0)
                    {
                        if (montoPago >= plan.CuotaMora)
                        {
                            montoPago -= plan.CuotaMora;
                            plan.SaldoMora -= plan.CuotaMora;
                        }
                        else
                        {
                            plan.SaldoMora -= montoPago;
                            montoPago = 0;
                        }
                    }
                }


                if (plan.SaldoCapital == 0 && plan.SaldoIntereses == 0 && plan.SaldoIvaIntereses == 0
                    && plan.SaldoMora == 0 && plan.SaldoIvaMora == 0 && plan.SaldoGastos == 0 && plan.SaldoIvaGastos == 0)
                {
                    plan.Aplicado = true;
                }
                _unitOfWork.Repository<PlanPago>().Update(plan);

            }


            await _unitOfWork.Complete();

            return Ok(new { Mensaje = "Accion Realizada Satisfactoriamente" });
        }

        [HttpGet]

        private async Task<decimal> AbonoEstadoCuenta(int prestamoId, int tipoTransaccionId, int registroCajaId, int planPagoId, decimal monto, string concepto, string appUserId, decimal saldoActual, List<PlanPago> planPago)
        {
            var estadoCuenta = new EstadoCuenta
            {
                AppUserId = appUserId,
                PrestamoId = prestamoId,
                RegistroCajaId = registroCajaId,
                TipoTransaccionId = tipoTransaccionId,
                Cargo = 0,
                Abono = monto,
                SaldoAnterior = saldoActual,
                SaldoActual = saldoActual - monto,
                Concepto = concepto,
            };

            _unitOfWork.Repository<EstadoCuenta>().Add(estadoCuenta);

            await _unitOfWork.Complete();

            //await _dbContext.EstadoCuentas.AddAsync(estadoCuenta);
            //await _dbContext.SaveChangesAsync();

            CuotaAbonoPlan(estadoCuenta.Id, planPagoId, tipoTransaccionId, monto, planPago);


            return estadoCuenta.SaldoActual;
        }

        private async Task<decimal> CargoEstadoCuenta(int prestamoId, int tipoTransaccionId, int registroCajaId, int planPagoId, decimal monto, string concepto, string appUserId, decimal saldoActual)
        {
            EstadoCuenta estadoCuenta;
            if (monto > 0)
            {
                estadoCuenta = new EstadoCuenta
                {
                    AppUserId = appUserId,
                    PrestamoId = prestamoId,
                    RegistroCajaId = registroCajaId,
                    TipoTransaccionId = tipoTransaccionId,
                    Cargo = monto,
                    Abono = 0,
                    SaldoAnterior = saldoActual,
                    SaldoActual = saldoActual + monto,
                    Concepto = concepto,
                };
                _unitOfWork.Repository<EstadoCuenta>().Add(estadoCuenta);
                await _unitOfWork.Complete();
                return estadoCuenta.SaldoActual;
            }

            return saldoActual;
            //await _dbContext.EstadoCuentas.AddAsync(estadoCuenta);
            //await _dbContext.SaveChangesAsync();

            //CuotaAbonoPlan(estadoCuenta.Id, planPagoId, tipoTransaccionId, monto);
        }

        private async void CuotaAbonoPlan(int estadoCuentaId, int planPagoId, int tipoTransaccionId, decimal monto, List<PlanPago> planPago)
        {
            decimal cuotaCapital = 0, abonoCapital = 0, cuotaIntereses = 0, abonoIntereses = 0, cuotaIvaIntereses = 0, abonoIvaIntereses = 0,
                    cuotaMora = 0, abonoMora = 0, cuotaIvaMora = 0, abonoIvaMora = 0, cuotaGastos = 0, cuotaIvaGastos = 0;

            if (tipoTransaccionId == 8) cuotaCapital = monto;
            if (tipoTransaccionId == 9 || tipoTransaccionId == 20 || tipoTransaccionId == 24) cuotaIntereses = monto;
            if (tipoTransaccionId == 10 || tipoTransaccionId == 17 || tipoTransaccionId == 23) cuotaIvaIntereses = monto;
            if (tipoTransaccionId == 11) cuotaMora = monto;
            if (tipoTransaccionId == 12) cuotaIvaMora = monto;


            //var planPago = await _dbContext.PlanPagos.Where(p => p.Id == planPagoId).ToListAsync();

            foreach (var plan in planPago)
            {

                if (cuotaCapital > 0 && cuotaCapital >= plan.SaldoCapital)
                {
                    cuotaCapital -= plan.SaldoCapital;
                    abonoCapital = plan.SaldoCapital;
                }
                else
                {
                    abonoCapital = cuotaCapital;
                    cuotaCapital = 0;
                }


                if (cuotaIntereses > 0 && cuotaIntereses >= plan.SaldoIntereses)
                {
                    cuotaIntereses -= plan.SaldoIntereses;
                    abonoIntereses = plan.SaldoIntereses;
                }
                else
                {
                    abonoIntereses = cuotaIntereses;
                    cuotaIntereses = 0;
                }

                if (cuotaIvaIntereses > 0 && cuotaIvaIntereses >= plan.SaldoIvaIntereses)
                {
                    cuotaIvaIntereses -= plan.SaldoIvaIntereses;
                    abonoIvaIntereses = plan.SaldoIvaIntereses;
                }
                else
                {
                    abonoIvaIntereses = cuotaIvaIntereses;
                    cuotaIvaIntereses = 0;
                }

                if (cuotaMora > 0 && cuotaMora >= plan.SaldoMora)
                {
                    cuotaMora -= plan.SaldoMora;
                    abonoMora = plan.SaldoMora;
                }
                else
                {
                    abonoMora = cuotaMora;
                    cuotaMora = 0;
                }

                if (cuotaIvaMora > 0 && cuotaIvaMora >= plan.SaldoIvaMora)
                {
                    cuotaIvaMora -= plan.SaldoIvaMora;
                    abonoIvaMora = plan.SaldoIvaMora;
                }
                else
                {
                    abonoIvaMora = cuotaIvaMora;
                    cuotaIvaMora = 0;
                }

                if (abonoCapital > 0 || abonoIntereses > 0 || abonoIvaIntereses > 0 || abonoMora > 0 || abonoIvaMora > 0)
                {
                    var cuotaAbono = new AbonoPlan
                    {
                        EstadoCuentaId = estadoCuentaId,
                        PlanPagoId = plan.Id,
                        CuotaCapital = abonoCapital,
                        CuotaIntereses = abonoIntereses,
                        CuotaIvaIntereses = abonoIvaIntereses,
                        CuotaMora = abonoMora,
                        CuotaIvaMora = abonoIvaMora,
                        CuotaGastos = cuotaGastos,
                        CuotaIvaGastos = cuotaIvaGastos
                    };

                    await _dbContext.AbonoPlanes.AddAsync(cuotaAbono);
                }

            }

        }

        [HttpGet("liquidar_credito/{creditoId}")]
        public async Task<ActionResult<object>> LiquidaCredito(int creditoId)
        {
            await _dbContext.Database.ExecuteSqlInterpolatedAsync($"sp_sct_payAllCurrentDebtAndCloseLoan {creditoId}");

            return Ok(new { Mensaje = "Accion Realizada Satisfactoriamente" });
        }

        [HttpGet("obtener_token/{prestamoId}")]
        public async Task<ActionResult<object>> GetToken(int prestamoId, string appUserId)
        {
            int longitud = 10;
            Guid newGuid = Guid.NewGuid();
            string token = newGuid.ToString().Replace("-", string.Empty).Substring(0, longitud);

            var prestamo = _dbContext.Prestamos.Where(s => s.Id == prestamoId).FirstOrDefault();

            prestamo.TokenAutorización = token;


            /** Se cambia a Estado 12**/

            var estadoActual = prestamo.EstadoPrestamoId;

            var bitacoraActual = await _dbContext.BitacoraPrestamos.Where(x => x.PrestamoId == prestamoId &&
                                        x.CambioEstado == false).FirstOrDefaultAsync();

            bitacoraActual.CambioEstado = true;

            var bitacoraPrestamo = new BitacoraPrestamo
            {
                PrestamoId = prestamo.Id,
                AppUserId = appUserId,
                Comentarios = null,
                TimeInStatus = 0,
                EstadoPrestamoId = estadoActual,
                NuevoEstadoPrestamoId = 12
            };

            _unitOfWork.Repository<BitacoraPrestamo>().Add(bitacoraPrestamo);

            prestamo.EstadoPrestamoId = 12;

            await _unitOfWork.Complete();

            var email = _dbContext.Personas.Where(x => x.EntidadId == prestamo.EntidadPrestamoId).Select(x => x.Email).FirstOrDefault();


            // Envío de Correo Electróncio
            string to = "safcrace@gmail.com";
            string subject = "Validation Token";
            string body = $"<h3>Dear Student:</h3>" +
                           $"<p>Please enter the following Token to validate your ARGO Academy student account.</p>" +
                           $"<p><b>{token}</b></p>" +
                           $"<h4>Thank you for using our platform.</h4>";

            await _mailService.SendEmailAsync(to, subject, body);

            return Ok(new { message = $"Token Generado Satisfactoriamente!! ", token, email });
        }

        [HttpGet("validar_token/{prestamoId}")]
        public async Task<ActionResult<object>> ValidateToken(int prestamoId, string appUserId, string token)
        {
            var prestamo = _dbContext.Prestamos.Where(s => s.Id == prestamoId).FirstOrDefault();

            if (prestamo.TokenAutorización != token)
            {
                return Ok(BadRequest("El token no es válido, por favor verificar"));
            }


            /** Se cambia a Estado 13**/

            var estadoActual = prestamo.EstadoPrestamoId;

            var bitacoraActual = await _dbContext.BitacoraPrestamos.Where(x => x.PrestamoId == prestamoId &&
                                        x.CambioEstado == false).FirstOrDefaultAsync();

            bitacoraActual.CambioEstado = true;

            var bitacoraPrestamo = new BitacoraPrestamo
            {
                PrestamoId = prestamo.Id,
                AppUserId = appUserId,
                Comentarios = null,
                TimeInStatus = 0,
                EstadoPrestamoId = estadoActual,
                NuevoEstadoPrestamoId = 13
            };

            _unitOfWork.Repository<BitacoraPrestamo>().Add(bitacoraPrestamo);

            prestamo.EstadoPrestamoId = 13;

            await _unitOfWork.Complete();


            return Ok(new { message = $"Token Valiadado Exitosamente!! " });
        }

        [HttpPost("referencia-persona")]
        public async Task<ActionResult<IEnumerable<object>>> CreatePersonReference(CreatePersonReferenceDto createPersonReferenceDto)
        {
            //foreach (var item in createPersonReferenceDto)
            //{
            var referenciaPersona = _mapper.Map<ReferenciaPersona>(createPersonReferenceDto);

            _unitOfWork.Repository<ReferenciaPersona>().Add(referenciaPersona);
            //}

            var result = await _unitOfWork.Complete();

            if (result < 0) return null!;

            return Ok(new { message = "Acción realizada Satisfactoriamente" });
        }

        [HttpGet("referencias_persona/{personaId:int}")]
        public async Task<ActionResult<ReferenciaPersonaDto>> GetReferenciaPersona(int personaId)
        {
            var referencias = await _dbContext.ReferenciasPersonas.Where(p => p.PersonaId == personaId).ToListAsync();

            var referenciasPersona = _mapper.Map<List<ReferenciaPersonaDto>>(referencias);

            foreach (var item in referenciasPersona)
            {
                item.DescripciónReferencia = await _dbContext.TipoReferencias.Where(x => x.Id == item.TipoReferenciaId).Select(x => x.Nombre).FirstOrDefaultAsync();
            }

            return Ok(referenciasPersona);
        }

        [HttpPut("referencia-persona/{id}")]
        public async Task<ActionResult<object>> UpdateReferenciaPersona(int id, UpdateReferenciasPersonaDto updateReferenciasPersona)
        {

            var referenciaPersona = await _unitOfWork.Repository<ReferenciaPersona>().GetByIdAsync(id);

            referenciaPersona.Comentario = updateReferenciasPersona.Comentario;

            await _unitOfWork.Complete();

            return Ok(new { message = "Actualizacion realizada Satisfactoriamente" });
        }

        [HttpDelete("referencias_persona/{referenciaId:int}")]
        public async Task<ActionResult<ReferenciaPersonaDto>> DeleteReferenciaPersona(int referenciaId)
        {
            var referencia = await _unitOfWork.Repository<ReferenciaPersona>().GetByIdAsync(referenciaId);
            _unitOfWork.Repository<ReferenciaPersona>().Delete(referencia);
            await _unitOfWork.Complete();

            return Ok(new { message = "Acción realizada Satisfactoriamente" });
        }

        [HttpPost("referencia-empresa")]
        public async Task<ActionResult<IEnumerable<object>>> CreateEmpresaReference(CreateEmpresaReferenceDto createEmpresaReferenceDto)
        {
            //foreach (var item in createPersonReferenceDto)
            //{
            var referenciaEmpresa = _mapper.Map<ReferenciaEmpresa>(createEmpresaReferenceDto);

            _unitOfWork.Repository<ReferenciaEmpresa>().Add(referenciaEmpresa);
            //}

            var result = await _unitOfWork.Complete();

            if (result < 0) return null!;

            return Ok(new { message = "Acción realizada Satisfactoriamente" });
        }


        [HttpGet("referencias_empresa/{empresaId:int}")]
        public async Task<ActionResult<ReferenciaEmpresaDto>> GetReferenciEmpresa(int empresaId)
        {
            var referencias = await _dbContext.ReferenciasEmpresas.Where(p => p.EmpresaId == empresaId).ToListAsync();

            var referenciasEmpresa = _mapper.Map<List<ReferenciaEmpresaDto>>(referencias);

            foreach (var item in referenciasEmpresa)
            {
                item.DescripciónReferencia = await _dbContext.TipoReferencias.Where(x => x.Id == item.TipoReferenciaId).Select(x => x.Nombre).FirstOrDefaultAsync();
            }

            return Ok(referenciasEmpresa);
        }

        [HttpPut("referencia-empresa/{id}")]
        public async Task<ActionResult<object>> UpdateReferenciaEmpresa(int id, UpdateReferenciasEmpresaDto updateReferenciasEmpresa)
        {

            var referenciaEmpresa = await _unitOfWork.Repository<ReferenciaEmpresa>().GetByIdAsync(id);

            referenciaEmpresa.Comentario = updateReferenciasEmpresa.Comentario;

            await _unitOfWork.Complete();

            return Ok(new { message = "Actualizacion realizada Satisfactoriamente" });
        }
        [HttpDelete("referencias_empresa/{referenciaId:int}")]
        public async Task<ActionResult<ReferenciaEmpresaDto>> DeleteReferenciaEmpresa(int referenciaId)
        {
            var referencia = await _unitOfWork.Repository<ReferenciaEmpresa>().GetByIdAsync(referenciaId);
            _unitOfWork.Repository<ReferenciaEmpresa>().Delete(referencia);
            await _unitOfWork.Complete();

            return Ok(new { message = "Acción realizada Satisfactoriamente" });
        }

        [HttpGet("solicitudes_categorias")]
        public async Task<ActionResult<object>> GetSolicitudesPorCategoria()
        {
            var distribucion = from pre in _dbContext.Prestamos
                               join tip in _dbContext.TipoPrestamos on pre.TipoPrestamoId equals tip.Id
                               where pre.EstadoPrestamoId == 14
                               group new { tip.Id, tip.Nombre } by new { tip.Id, tip.Nombre } into g
                               select new
                               {
                                   g.Key.Id,
                                   Nombre = g.Key,
                                   Total = g.Count()
                               };

            //distribucion = distribucion.Where(x => x.)

            return Ok(distribucion);
        }

        [HttpPost("bitacora-solicitud")]
        public async Task<ActionResult<IEnumerable<object>>> CreateBitacoraPrestamo(CreaterBitacoraPrestamoDto createrBitacoraPrestamoDto)
        {
            try
            {
                var bitacoraActual = await _dbContext.BitacoraPrestamos.Where(x => x.PrestamoId == createrBitacoraPrestamoDto.PrestamoId &&
                                        x.CambioEstado == false).FirstOrDefaultAsync();

                bitacoraActual.CambioEstado = true;

                var bitacora = _mapper.Map<BitacoraPrestamo>(createrBitacoraPrestamoDto);

                _unitOfWork.Repository<BitacoraPrestamo>().Add(bitacora);

                var result = await _unitOfWork.Complete();

                if (result < 0) return null!;

                return Ok(new { message = "Acción realizada Satisfactoriamente" });

            }
            catch (Exception e)
            {
                return e.InnerException != null
                    ? new BadRequestObjectResult(e.InnerException.Message)
                    : new BadRequestObjectResult(e.Message);
            }
        }

        [HttpGet("bitacora-solicitud/{prestamoId}")]
        public async Task<ActionResult<IEnumerable<BitacoraPrestamoDto>>> GetBitacoraPrestamo(int prestamoId)
        {
            var bitacora = await _dbContext.BitacoraPrestamos.Where(x => x.PrestamoId == prestamoId).ToListAsync();

            var bitacoraPrestamos = _mapper.Map<List<BitacoraPrestamoDto>>(bitacora);

            foreach (var item in bitacoraPrestamos)
            {
                var usuario = _dbContext.Users.Where(x => x.Id == item.AppUserId).Select(x => x.UserName).FirstOrDefault();
                //    from usr in _dbContext.Users
                //                join per in _dbContext.Personas on usr.PersonaId equals per.Id
                //                where usr.Id == item.AppUserId
                //                select new NombreUsuarioDto
                //                {
                //                    NombreUsuario = per.ApellidoCasada == null ?
                //                        $"{per.PrimerNombre} {per.SegundoNombre} {per.TercerNombre} {per.PrimerApellido} {per.SegundoApellido}" :
                //                        $"{per.PrimerNombre} {per.SegundoNombre} {per.TercerNombre} {per.PrimerApellido} {per.SegundoApellido} De {per.ApellidoCasada}"
                //                };
                //Console.WriteLine(usuario.Select(NombreUsuarioDto.n);
                item.NombreUsuario = usuario;

            }

            return Ok(bitacoraPrestamos);

        }

        [HttpPost("desembolsos")]
        public async Task<ActionResult<IEnumerable<object>>> CreateDesembolso(CreateDesembolsoDto createDesembolsoDto)
        {
            try
            {
                var tieneDesembolso = await _dbContext.Desembolsos.FirstOrDefaultAsync(x => x.PrestamoId == createDesembolsoDto.PrestamoId);

                if (tieneDesembolso is not null)
                {
                    return BadRequest("Error la solicitud ya cuenta con Desembolso");
                }

                var desembolso = _mapper.Map<Desembolso>(createDesembolsoDto);

                _unitOfWork.Repository<Desembolso>().Add(desembolso);

                var result = await _unitOfWork.Complete();

                if (result < 0) return null!;

                return Ok(new { message = "Acción realizada Satisfactoriamente" });

            }
            catch (Exception e)
            {
                return e.InnerException != null
                    ? new BadRequestObjectResult(e.InnerException.Message)
                    : new BadRequestObjectResult(e.Message);
            }
        }

        [HttpGet("desembolsos")]
        public async Task<ActionResult<object>> GetDesembolsos()
        {
            var listado = from des in _dbContext.Desembolsos
                          join pre in _dbContext.Prestamos on des.PrestamoId equals pre.Id
                          join ent in _dbContext.ListadoEntidades on pre.EntidadPrestamoId equals ent.EntidadId
                          where pre.EstadoPrestamoId == 20
                          select new
                          {
                              SolicitudId = pre.Id,
                              Nombre = ent.NombreEntidad //$"{per.PrimerNombre} {per.SegundoNombre} {per.TercerNombre} {per.PrimerApellido} {per.SegundoApellido}"
                          };

            return Ok(listado);
        }

        [HttpGet("distribucion-desembolsos/{prestamoId}")]
        public async Task<ActionResult<object>> GetDistribucionDesembolsos(int prestamoId)
        {
            var distribucion = from det in _dbContext.DetalleDesembolsos
                               join des in _dbContext.Desembolsos on det.DesembolsoId equals des.Id
                               join pre in _dbContext.Prestamos on des.PrestamoId equals pre.Id
                               join tip in _dbContext.MediosDesembolso on det.MedioDesembolsoId equals tip.Id
                               where det.TieneLote == false && pre.EstadoPrestamoId == 20 && det.MedioDesembolsoId != 3 && pre.Id == prestamoId
                               group tip by tip.Nombre into g
                               select new
                               {
                                   Nombre = g.Key,
                                   Total = g.Count()
                               };

            return Ok(distribucion);
        }

        [HttpGet("desembolsos/{desembolsoId}")]
        public async Task<ActionResult<DesembolsoDto>> GetDesembolsoPorId(int? desembolsoId)
        {
            var desembolso = await _dbContext.Desembolsos.Include(x => x.DetalleDesembolsos).FirstOrDefaultAsync(x => x.Id == desembolsoId);

            return Ok(_mapper.Map<DesembolsoDto>(desembolso));
        }

        [HttpGet("listado-desembolsos/{medioDesembolsoId}")]
        public async Task<ActionResult<IEnumerable<ListadoDesembolso>>> GetListadoDesembolsos(int medioDesembolsoId)
        {
            List<Core.Entities.Views.ListadoDesembolso> listado = new();

            listado = await _dbContext.Set<ListadoDesembolso>().ToListAsync();

            listado = listado.Where(x => x.MedioDesembolsoId == medioDesembolsoId).ToList();


            foreach (var item in listado)
            {

                var bitacora = await _dbContext.BitacoraPrestamos.Where(x => x.PrestamoId == item.SolicitudId).OrderByDescending(x => x.Id).FirstOrDefaultAsync();
                if (bitacora != null)
                {
                    TimeSpan tiempoTranscurrido = DateTime.Now.Subtract(bitacora.FechaCreacion);
                    item.TiempoSolicitud = (int)tiempoTranscurrido.TotalHours;
                    bitacora.TimeInStatus = (byte)item.TiempoSolicitud;
                    if (item.TiempoSolicitud > 240)
                    {
                        bitacora.CambioEstado = true;
                        var prestamo = _dbContext.Prestamos.Where(x => x.Id == item.SolicitudId).FirstOrDefault();
                        prestamo.EstadoPrestamoId = 11;
                        _dbContext.Prestamos.Update(prestamo);
                        await _dbContext.SaveChangesAsync();


                        var nuevoEstado = new BitacoraPrestamo
                        {
                            PrestamoId = item.SolicitudId,
                            AppUserId = "8f00ad3d-22d4-424d-8e48-6df7aef4f7d6",
                            EstadoPrestamoId = bitacora.NuevoEstadoPrestamoId,
                            NuevoEstadoPrestamoId = 11,
                            Comentarios = "Cambio de Estado Automatico Aplicado"
                        };

                        await _dbContext.BitacoraPrestamos.AddAsync(nuevoEstado);

                    }
                    _dbContext.BitacoraPrestamos.Update(bitacora);
                    await _dbContext.SaveChangesAsync();

                }
            }


            return Ok(listado);
        }

        [HttpPost("lotes")]
        public async Task<ActionResult<IEnumerable<object>>> CreateLotesDesembolsos(CreateLoteDto createLoteDto)
        {
            try
            {
                var lote = _mapper.Map<Lote>(createLoteDto);

                _unitOfWork.Repository<Lote>().Add(lote);

                var result = await _unitOfWork.Complete();

                if (result < 0) return null!;

                var loteId = lote.Id;

                foreach (var item in lote.DetalleLotes)
                {
                    //var desembolso = await _dbContext.Desembolsos.Where(x => x.PrestamoId == item.SolicitudId).FirstOrDefaultAsync();
                    var detalleDesembolso = await _dbContext.DetalleDesembolsos.Where(x => x.Id == item.DetalleDesembolsoId).FirstOrDefaultAsync();

                    detalleDesembolso.LoteId = loteId;
                    detalleDesembolso.TieneLote = true;
                }

                _dbContext.SaveChanges();

                var personaId = await _dbContext.Users.Where(x => x.Id == lote.AppUserId).Select(x => x.PersonaId).FirstOrDefaultAsync();

                var nombres = await _dbContext.Personas.Where(x => x.Id == personaId).Select(x => new { nombre = x.PrimerNombre, apellido = x.PrimerApellido }).FirstOrDefaultAsync();

                var nombre = $"{nombres.nombre} {nombres.apellido}";



                return Ok(new { message = "Acción realizada Satisfactoriamente", lote.Id, lote.FechaCreacion, nombre });
            }
            catch (Exception e)
            {

                return e.InnerException != null
                ? new BadRequestObjectResult(e.InnerException.Message)
                : new BadRequestObjectResult(e.Message);
            }

        }

        [HttpGet("listado-lotes")]
        public async Task<ActionResult<IEnumerable<LoteDto>>> GetListadoLotes()
        {

            var lotes = await _dbContext.Lotes.ToListAsync();

            var listadoLotes = _mapper.Map<List<LoteDto>>(lotes);

            listadoLotes = listadoLotes.Where(x => x.Habilitado == true && x.Aprobado == false).ToList();

            foreach (var item in listadoLotes)
            {
                var personaId = await _dbContext.Users.Where(x => x.Id == item.AppUserId).Select(x => x.PersonaId).FirstOrDefaultAsync();

                var nombres = await _dbContext.Personas.Where(x => x.Id == personaId).Select(x => new { nombre = x.PrimerNombre, apellido = x.PrimerApellido }).FirstOrDefaultAsync();

                var nombreUsuario = $"{nombres.nombre} {nombres.apellido}";

                item.GeneradoPor = nombreUsuario;
            }

            return Ok(listadoLotes);
        }

        [HttpGet("detalle-lote/{loteId}")]
        public async Task<ActionResult<object>> GetDetalleLotes(int loteId)
        {

            var detalle = await _dbContext.DetalleLotes.Where(x => x.LoteId == loteId && x.Aprobado == false && x.Habilitado == true).ToListAsync();

            var detalleLote = _mapper.Map<List<DetalleLoteDto>>(detalle);

            var lote = await _dbContext.Lotes.Where(x => x.Id == loteId).Select(x => new { x.AppUserId, x.FechaCreacion }).FirstOrDefaultAsync();

            var personaId = await _dbContext.Users.Where(x => x.Id == lote.AppUserId).Select(x => x.PersonaId).FirstOrDefaultAsync();

            var nombres = await _dbContext.Personas.Where(x => x.Id == personaId).Select(x => new { nombre = x.PrimerNombre, apellido = x.PrimerApellido }).FirstOrDefaultAsync();

            var nombreUsuario = $"{nombres.nombre} {nombres.apellido}";

            foreach (var item in detalleLote)
            {
                //var appUserId = await _dbContext.Lotes.Where(x => x.Id == item.LoteId).Select(x => x.AppUserId).FirstOrDefaultAsync();

                //var personId = await _dbContext.Users.Where(x => x.Id == appUserId).Select(x => x.PersonaId).FirstOrDefaultAsync();

                //var aprobadoPor = await _dbContext.Personas.Where(x => x.Id == personId).Select(x => new { nombre = x.PrimerNombre, apellido = x.PrimerApellido }).FirstOrDefaultAsync();
                /** Pendiente **/
                var desembolsoId = await _dbContext.Desembolsos.Where(x => x.PrestamoId == item.SolicitudId).Select(x => x.Id).FirstOrDefaultAsync();
                item.NumeroCuenta = await _dbContext.DetalleDesembolsos.Where(x => x.Id == item.DetalleDesembolsoId).Select(x => x.NumeroCuenta).FirstOrDefaultAsync();

            }

            var result = new
            {
                AprobadoPor = nombreUsuario,
                FechaAprobacion = lote.FechaCreacion,
                detalleLote
            };


            return Ok(result);
        }

        [HttpPut("detalle-lote/{detalleLoteId}")]
        public async Task<ActionResult<object>> UpdateDetalleLote(int detalleLoteId, DetalleLoteDto detalleLoteDto)
        {

            var detalleLote = await _unitOfWork.Repository<DetalleLote>().GetByIdAsync(detalleLoteId);
            detalleLoteDto.DetalleDesembolsoId = detalleLote.DetalleDesembolsoId;

            if (detalleLoteDto.Habilitado == false)
            {
                var detalleDesembolso = await _dbContext.DetalleDesembolsos.Where(x => x.Id == detalleLote.DetalleDesembolsoId).FirstOrDefaultAsync();
                detalleDesembolso.LoteId = null;
                detalleDesembolso.TieneLote = false;

                await _dbContext.SaveChangesAsync();
            }

            _mapper.Map(detalleLoteDto, detalleLote);

            await _unitOfWork.Complete();

            return Ok(new { message = "Actualizacion realizada Satisfactoriamente" });
        }

        [HttpPut("rechazar/{loteId}")]
        public async Task<ActionResult<object>> UpdateLote(int loteId)
        {
            var lote = await _unitOfWork.Repository<Lote>().GetByIdAsync(loteId);

            lote.Habilitado = false;

            await _unitOfWork.Complete();

            var detalleDesembolsos = await _dbContext.DetalleDesembolsos.Where(x => x.LoteId == loteId).ToListAsync();

            foreach (var item in detalleDesembolsos)
            {
                item.LoteId = null;
                item.TieneLote = false;
            }

            var detalleLote = await _dbContext.DetalleLotes.Where(x => x.LoteId == loteId).ToListAsync();

            foreach (var item in detalleLote)
            {
                item.Habilitado = false;
            }


            await _dbContext.SaveChangesAsync();

            return Ok(new { message = "Actualizacion realizada Satisfactoriamente" });
        }

        [HttpPut("aprobar-lote/{loteId}")]
        public async Task<ActionResult<object>> AprobarLote(int loteId)
        {
            int solicitudesAprobadas = 0,
                solicitudesNoAprobadas = 0;

            var detalleLote = await _dbContext.DetalleLotes.Where(x => x.LoteId == loteId).ToListAsync();

            foreach (var item in detalleLote)
            {

                if (item.Documento is not null && item.Habilitado == true)
                {
                    solicitudesAprobadas++;
                    item.Aprobado = true;
                    var detalleDesembolso = await _dbContext.DetalleDesembolsos.Where(x => x.Id == item.DetalleDesembolsoId).FirstOrDefaultAsync();
                    detalleDesembolso.Desembolsado = true;
                }
                else
                {
                    solicitudesNoAprobadas++;
                }

                await _dbContext.SaveChangesAsync();

                var lotes = await _dbContext.DetalleLotes.Where(x => x.LoteId == item.LoteId && x.Habilitado == true && x.Aprobado == false).CountAsync();


                if (lotes < 1)
                {
                    var lote = await _dbContext.Lotes.Where(x => x.Id == item.LoteId).FirstOrDefaultAsync();
                    lote.Aprobado = true;
                }

                await _dbContext.SaveChangesAsync();

                var desembolso = await _dbContext.Desembolsos.FirstOrDefaultAsync(x => x.PrestamoId == item.SolicitudId && x.Desembolsado == false);

                if (desembolso is not null)
                {
                    var desembolsosPendientes = await _dbContext.DetalleDesembolsos.Where(x => x.DesembolsoId == desembolso.Id && x.MedioDesembolsoId != 3 && x.Desembolsado == false).CountAsync();

                    if (desembolsosPendientes < 1)
                    {
                        desembolso.Desembolsado = true;
                        await _dbContext.SaveChangesAsync();

                        /**Creación de Crédito **/
                        await CreateNewCredit(item.SolicitudId);
                    }
                }
            }


            return Ok(new { message = "Acción Realizada Satisfactoriamente. Las solicitudes No Aprobadas, están pendientes de Documento!", solicitudesAprobadas, solicitudesNoAprobadas });
        }


        private async Task CreateNewCredit(int prestamoId)
        {
            var prestamo = await _unitOfWork.Repository<Prestamo>().GetByIdAsync(prestamoId);

            List<CreatePaymentPlanDetailsDto> detallePlan = new List<CreatePaymentPlanDetailsDto>();
            detallePlan = new List<CreatePaymentPlanDetailsDto>();

            var tipoPrestamo = await _unitOfWork.Repository<TipoPrestamo>().GetByIdAsync(prestamo.TipoPrestamoId);

            prestamo.EstadoPrestamoId = 1;
            prestamo.FechaDesembolso = DateTime.Now;
            prestamo.TasaIva = tipoPrestamo.TasaIva;

            /** Creación Plan de Pago **/
            var datosPrestamo = new CreatePaymentPlanTemporalDto
            {
                TipoCuota = (int)await _dbContext.TipoPrestamos.Where(x => x.Id == tipoPrestamo.TipoCuotaId).Select(x => x.TipoCuotaId).FirstOrDefaultAsync(),
                PrincipalAmount = prestamo.MontoOtorgado,
                InterestRate = prestamo.TasaInteres,
                TaxRate = prestamo.TasaIva,
                Term = prestamo.Plazo,
                StartDate = (DateTime)prestamo.FechaPlan,
                PayDate = (DateTime)prestamo.FechaPlan
            };

            var projection = _dbContext.DetallePlanPagoTemporales.Where(x => x.PrestamoId == prestamo.Id).OrderByDescending(x => x.Id).Take(prestamo.Plazo).ToList();

            var payDate = (DateTime)prestamo.FechaPlan;
            var periodo = 1;

            foreach (var plan in projection)
            {
                var planPagoEvaluacion = new CreatePaymentPlanDetailsDto
                {
                    PrestamoId = prestamo.Id,
                    Periodo = periodo,
                    CuotaCapital = plan.CuotaCapital,
                    CuotaIntereses = plan.CuotaIntereses,
                    CuotaIvaIntereses = plan.CuotaIvaIntereses,
                    TotalCuota = plan.TotalCuota,
                    FechaPago = payDate
                };

                detallePlan.Add(planPagoEvaluacion);
                payDate = payDate.AddMonths(1);
                periodo++;
            }

            var planPago = new CreatePaymentPlanDto
            {
                PrestamoId = prestamo.Id,
                FechaPlan = (DateTime)prestamo.FechaPlan,
                Plazo = prestamo.Plazo,
                TasaInteres = prestamo.TasaInteres,
                TasaMora = prestamo.TasaMora,
                TasaGastos = prestamo.TasaGastos,
                PlanPagos = detallePlan
            };

            await CreatePaymentPlan(planPago);

            await _dbContext.SaveChangesAsync();
            await _unitOfWork.Complete();


        }

        [HttpPost("archivos-prestamos")]
        public async Task<ActionResult<IEnumerable<object>>> CreateDocumentosPrestamos(CreateArchivoPrestamoDto createArchivoPrestamoDto)
        {
            try
            {
                var archivo = _mapper.Map<ArchivoPrestamo>(createArchivoPrestamoDto);

                _unitOfWork.Repository<ArchivoPrestamo>().Add(archivo);

                var result = await _unitOfWork.Complete();

                if (result < 0) return null!;

                return Ok(new { message = "Acción realizada Satisfactoriamente" });

            }
            catch (Exception e)
            {
                return e.InnerException != null
                    ? new BadRequestObjectResult(e.InnerException.Message)
                    : new BadRequestObjectResult(e.Message);
            }
        }

        [HttpGet("archivos-prestamos/{prestamoId}")]
        public async Task<ActionResult<IEnumerable<ArchivoPrestamoDto>>> GetListadoArchivos(int prestamoId)
        {

            var archivos = await _dbContext.ArchivosPrestamo.Where(x => x.PrestamoId == prestamoId).ToListAsync();

            return Ok(_mapper.Map<List<ArchivoPrestamoDto>>(archivos));
        }

        [HttpDelete("archivo-prestamos/{id}")]
        public async Task<ActionResult<object>> DeleteArchivoPrestamo(int id)
        {
            var archivo = await _unitOfWork.Repository<ArchivoPrestamo>().GetByIdAsync(id);
            _unitOfWork.Repository<ArchivoPrestamo>().Delete(archivo);
            await _unitOfWork.Complete();

            return Ok(new { message = "Acción realizada Satisfactoriamente" });
        }

        [HttpGet("entrevistas/{prestamoId}")]
        public async Task<ActionResult<object>> GetInterview(int prestamoId)
        {

            var entrevista = await _dbContext.Entrevistas.Where(x => x.PrestamoId == prestamoId).FirstOrDefaultAsync();

            if (entrevista is null)
            {
                return Ok(new { entrevista = "No existe entrevista" });
            }

            return Ok(entrevista.Texto);
        }

        [HttpPost("entrevistas")]
        public async Task<ActionResult<object>> CreateInterview(CreateEntrevistaDto entrevistaDto)
        {

            try
            {
                var entrevista = _mapper.Map<Entrevista>(entrevistaDto);

                _unitOfWork.Repository<Entrevista>().Add(entrevista);

                var result = await _unitOfWork.Complete();

                if (result < 0) return null!;

                return Ok(new { message = "Acción realizada Satisfactoriamente" });
            }
            catch (Exception e)
            {

                return e.InnerException != null
                ? new BadRequestObjectResult(e.InnerException.Message)
                : new BadRequestObjectResult(e.Message);
            }
        }

        [HttpPut("entrevistas")]
        public async Task<ActionResult<object>> UpdateEntrevista(CreateEntrevistaDto entrevistaDto)
        {
            var entrevista = await _dbContext.Entrevistas.Where(x => x.PrestamoId == entrevistaDto.PrestamoId).FirstOrDefaultAsync();

            entrevista.Texto = entrevistaDto.Texto;

            await _dbContext.SaveChangesAsync();

            return Ok(new { message = "Actualizacion realizada Satisfactoriamente" });
        }

    }
}
