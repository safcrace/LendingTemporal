using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Entities.Configuration;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CreatePaymentPlanDetailsDto, PlanPago>();
            CreateMap<CreateLendingDto, Prestamo>();
            CreateMap<CreatePersonDto, Persona>();
            CreateMap<CreateEmpresaDto, Empresa>();
            CreateMap<CreateRegistroCajaDto, RegistroCaja>();
            CreateMap<Pais, PaisDto>();
            CreateMap<Departamento, DepartamentoDto>();
            CreateMap<Municipio, MunicipioDto>();
            CreateMap<Banco, BancoDto>();
            CreateMap<Caja, CajaDto>();
            CreateMap<FormaPago, FormaPagoDto>();
            CreateMap<EstadoCivil, EstadoCivilDto>();
            CreateMap<DestinoPrestamo, DestinoPrestamoDto>();
            CreateMap<Ocupacion, OcupacionDto>();
            CreateMap<TipoVivienda, TipoViviendaDto>();
            //CreateMap<Gestor, GestorDto>();

            CreateMap<TipoPrestamo, TipoPrestamoDto>();
            CreateMap<CreateTipoPrestamoDto, TipoPrestamo>()
                .ForMember(x => x.CurrencyId, opt => opt.MapFrom(src => src.MonedaId))
                .ForMember(x => x.Descripcion, opt => opt.MapFrom(src => src.Nombre));
            CreateMap<UpdateTipoPrestamoDto, TipoPrestamo>()
                .ForMember(x => x.CurrencyId, opt => opt.MapFrom(src => src.MonedaId))
                .ForAllMembers(opts => opts.Condition((_, _, srcMember) => srcMember != null));
            CreateMap<DocumentosPrestamo, DocumentoPrestamoDto>()
                .ForMember(x => x.Nombre, opt => opt.MapFrom(src => src.Name));
            CreateMap<CreateDocumentoPrestamoDto, DocumentosPrestamo>()
                .ForMember(x => x.Name, opt => opt.MapFrom(src => src.Nombre));
            CreateMap<Moneda, CatalogDto>()
                .ForMember(x => x.Nombre, opt => opt.MapFrom(src => src.Name));

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