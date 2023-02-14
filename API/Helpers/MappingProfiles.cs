using API.Dtos;
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
            CreateMap<Pais, PaisDto>();
            CreateMap<Departamento, DepartamentoDto>();
            CreateMap<Municipio, MunicipioDto>();
            CreateMap<Banco, BancoDto>();
            CreateMap<Caja, CajaDto>();
            CreateMap<FormaPago, FormaPagoDto>();
            CreateMap<EstadoCivil, EstadoCivilDto>();
            CreateMap<TipoPrestamo, TipoPrestamoDto>();
            CreateMap<DestinoPrestamo, DestinoPrestamoDto>();
            CreateMap<Ocupacion, OcupacionDto>();
            CreateMap<TipoVivienda, TipoViviendaDto>();
            //CreateMap<Gestor, GestorDto>();
        }
    }
}
