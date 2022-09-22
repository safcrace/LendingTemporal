using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {   
            CreateMap<CreatePaymentPlanDto, PlanPago>();
            CreateMap<CreatePaymentPlanDetailsDto, DetallePlanPago>();
            CreateMap<CreateLendingDto, Prestamo>();
            CreateMap<CreatePersonDto, Persona>();
            CreateMap<EstadoCivil, EstadoCivilDto>();
            CreateMap<TipoPrestamo, TipoPrestamoDto>();
            CreateMap<DestinoPrestamo, DestinoPrestamoDto>();
            CreateMap<Gestor, GestorDto>();
        }
    }
}
