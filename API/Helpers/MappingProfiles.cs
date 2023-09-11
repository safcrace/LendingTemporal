using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Entities.Identity;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CreatePaymentPlanDetailsDto, PlanPago>();
            CreateMap<CreateLendingDto, Prestamo>();
            CreateMap<CreatePersonDto, Persona>().ReverseMap();
            CreateMap<CreateEmpresaDto, Empresa>();
            CreateMap<CreateContactoEmpresaDto, ContactoEmpresa>();
            CreateMap<CreateLoteDto, Lote>();
            CreateMap<CreateDetalleLoteDto, DetalleLote>();
            CreateMap<CreateRegistroCajaDto, RegistroCaja>();
            CreateMap<CreateTipoPrestamoDto, TipoPrestamo>();
            CreateMap<CreateArchivoPrestamoDto, DocumentosPrestamo>();
            CreateMap<CreateInteresesDepartamentosDto, InteresesDepartamentos>();
            CreateMap<CreateMoraDepartamentosDto, MoraDepartamentos>();
            CreateMap<CreateParametrosDepartamentosDto, ParametrosDepartamentos>();
            CreateMap<CreatePersonReferenceDto, ReferenciaPersona>();
            CreateMap<CreateEmpresaReferenceDto, ReferenciaEmpresa>();
            CreateMap<CreateDesembolsoDto, Desembolso>();
            CreateMap<CreateArchivoPrestamoDto, ArchivoPrestamo>();
            CreateMap<CreaterBitacoraPrestamoDto, BitacoraPrestamo>();
            CreateMap<BitacoraPrestamo, BitacoraPrestamoDto>();
            CreateMap<ArchivoPrestamo, ArchivoPrestamoDto>();
            CreateMap<Pais, PaisDto>();
            CreateMap<Region, RegionDto>();
            CreateMap<Departamento, DepartamentoDto>();
            CreateMap<Municipio, MunicipioDto>();
            CreateMap<TipoCuota, TipoCuotaDto>();
            CreateMap<Moneda, MonedaDto>();
            CreateMap<CanalIngreso, CanalIngresoDto>();
            CreateMap<EmpresaCelular, EmpresaCelularDto>();
            CreateMap<Escolaridad, EscolaridadDto>();
            CreateMap<GrupoFamiliar, GrupoFamiliarDto>();
            CreateMap<MontoInteresado, MontoInteresadoDto>();
            CreateMap<OcupacionSinFin, OcupacionSinFinDto>();
            CreateMap<ProductoInteresado, ProductoInteresadoDto>();
            CreateMap<SegmentoNegocio, SegmentoNegocioDto>();
            CreateMap<SubSegmentoNegocio, SubSegmentoNegocioDto>();
            CreateMap<InteresesDepartamentos, InteresesDepartamentosDto>(); 
            CreateMap<Banco, BancoDto>();
            CreateMap<Caja, CajaDto>();
            CreateMap<FormaPago, FormaPagoDto>();
            CreateMap<EstadoCivil, EstadoCivilDto>();
            CreateMap<DestinoPrestamo, DestinoPrestamoDto>();
            CreateMap<Ocupacion, OcupacionDto>();
            CreateMap<TipoVivienda, TipoViviendaDto>();
            CreateMap<OrigenSolicitud, ResponseCatalogoDto>();
            CreateMap<OrigenIngreso, ResponseCatalogoDto>();
            CreateMap<UbicacionNegocio, ResponseCatalogoDto>();
            CreateMap<ClienteHabitual, ResponseCatalogoDto>();
            CreateMap<TipoReferencia, ResponseCatalogoDto>();
            CreateMap<DocumentosPrestamo, ResponseCatalogoDto>();
            CreateMap<AppUser, UsuariosDto>();
            CreateMap<MedioDesembolso, ResponseCatalogoDto>();
            CreateMap<TipoCuenta, ResponseCatalogoDto>();
            CreateMap<MotivoRechazo, ResponseCatalogoDto>();
            CreateMap<DocumentosPrestamo, DocumentoPrestamoDto>();
            CreateMap<Lote, LoteDto>();
            CreateMap<DetalleLote, DetalleLoteDto>().ReverseMap();
            CreateMap<Persona, DatosPersonaDto>().ReverseMap();
            CreateMap<Empresa, DatosEmpresaDto>().ReverseMap();
            CreateMap<Prestamo, DatosPrestamoDto>().ReverseMap();
            CreateMap<ContactoEmpresa, DatosContactoEmpresaDto>().ReverseMap();
            CreateMap<ReferenciaPersona, ReferenciaPersonaDto>().ReverseMap();
            CreateMap<ReferenciaEmpresa, ReferenciaEmpresaDto>().ReverseMap();
            CreateMap<Desembolso, DesembolsoDto>().ReverseMap();

            //CreateMap<Gestor, GestorDto>();

            CreateMap<TipoPrestamo, TipoPrestamoDto>();
            CreateMap<TipoPrestamo, ListadoTiposCreditoDto>()
                .ForMember(x => x.TipoCuota, Mc => Mc.MapFrom(y => y.TipoCuota.Nombre))
                .ForMember(x => x.Moneda, Mc => Mc.MapFrom(y => y.Moneda.Nombre)); 
            //CreateMap<InteresesRegiones, InteresesRegionesDto>();
            CreateMap<MoraDepartamentos, MoraDepartamentosDto>();
            CreateMap<ParametrosDepartamentos, ParametrosDepartamentosDto>();
            CreateMap<UpdateTipoPrestamoDto, TipoPrestamo>();
            //CreateMap<CreateTipoPrestamoDto, TipoPrestamo>()
            //    .ForMember(x => x.MonedaId, opt => opt.MapFrom(src => src.MonedaId))
            //    .ForMember(x => x.Descripcion, opt => opt.MapFrom(src => src.Nombre));
            //CreateMap<UpdateTipoPrestamoDto, TipoPrestamo>()
            //    .ForMember(x => x.MonedaId, opt => opt.MapFrom(src => src.MonedaId))
            //    .ForAllMembers(opts => opts.Condition((_, _, srcMember) => srcMember != null));
            //CreateMap<DocumentosPrestamo, DocumentoPrestamoDto>()
            //    .ForMember(x => x.Nombre, opt => opt.MapFrom(src => src.Name));
            //CreateMap<CreateDocumentoPrestamoDto, DocumentosPrestamo>()
            //    .ForMember(x => x.Name, opt => opt.MapFrom(src => src.Nombre));
            //CreateMap<Moneda, CatalogDto>()
            //    .ForMember(x => x.Nombre, opt => opt.MapFrom(src => src.Nombre));

            #region Others

            CreateMap<int?, int>().ConvertUsing((src, dest) => src ?? dest);
            CreateMap<decimal?, decimal>().ConvertUsing((src, dest) => src ?? dest);
            CreateMap<bool?, bool>().ConvertUsing((src, dest) => src ?? dest);
            CreateMap<double?, double>().ConvertUsing((src, dest) => src ?? dest);
            CreateMap<DateTime?, DateTime>().ConvertUsing((src, dest) => src ?? dest);

            #endregion
        }
    }
}