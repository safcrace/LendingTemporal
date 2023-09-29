using Microsoft.AspNetCore.Mvc;

namespace API.Dtos
{
    public class PlanPagoTemporalDto
    {
        public InfoPrestamoDto? InfoPrestamo { get; set; }
        public List<ProjectionDto>? Projection { get; set; }

        public static explicit operator PlanPagoTemporalDto(ActionResult<PlanPagoTemporalDto> v)
        {
            if (v == null)
            {
                throw new ArgumentNullException(nameof(v), "El ActionResult no puede ser nulo.");
            }

            // Extraer el PlanPagoTemporalDto del ActionResult
            PlanPagoTemporalDto planPagoTemporalDto = v.Value;

            if (planPagoTemporalDto == null)
            {
                throw new InvalidOperationException("El ActionResult no contiene un PlanPagoTemporalDto.");
            }

            return planPagoTemporalDto;
        }
    }
}
