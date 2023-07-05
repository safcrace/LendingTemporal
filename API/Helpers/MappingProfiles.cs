﻿using API.Dtos;
using AutoMapper;
using Core.Entities;

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
            CreateMap<CreateTipoPrestamoDto, TipoPrestamo>();
            CreateMap<CreateDocumentoPrestamoDto, DocumentosPrestamo>();
            CreateMap<CreateInteresesRegionesDto, InteresesRegiones>();
            CreateMap<CreateMoraRegionesDto, MoraRegiones>();
            CreateMap<CreateParametrosRegionesDto, ParametrosRegiones>();
            CreateMap<Pais, PaisDto>();
            CreateMap<Region, RegionDto>();
            CreateMap<Departamento, DepartamentoDto>();
            CreateMap<Municipio, MunicipioDto>();
            CreateMap<InteresesRegiones, InteresesRegionesDto>();
            CreateMap<Banco, BancoDto>();
            CreateMap<Caja, CajaDto>();
            CreateMap<FormaPago, FormaPagoDto>();
            CreateMap<EstadoCivil, EstadoCivilDto>();
            CreateMap<DestinoPrestamo, DestinoPrestamoDto>();
            CreateMap<Ocupacion, OcupacionDto>();
            CreateMap<TipoVivienda, TipoViviendaDto>();
            CreateMap<DocumentosPrestamo, DocumentoPrestamoDto>();
            //CreateMap<Gestor, GestorDto>();

            CreateMap<TipoPrestamo, TipoPrestamoDto>();
            CreateMap<TipoPrestamo, ListadoTiposCreditoDto>()
                .ForMember(x => x.TipoCuota, Mc => Mc.MapFrom(y => y.TipoCuota.Nombre))
                .ForMember(x => x.Moneda, Mc => Mc.MapFrom(y => y.Moneda.Nombre)); 
            //CreateMap<InteresesRegiones, InteresesRegionesDto>();
            CreateMap<MoraRegiones, MoraRegionesDto>();
            CreateMap<ParametrosRegiones, ParametrosRegionesDto>();
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