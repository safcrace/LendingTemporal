﻿using Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class DatosEmpresaDto
    {
        public int Id { get; set; }
        public int? EntidadId { get; set; }
        public int? ExpedienteSidId { get; set; }
        public int? DepartamentoId { get; set; }
        public string? MunicipioId { get; set; }
        public int? SegmentoNegocioId { get; set; }
        public int? SubSegmentoNegocioId { get; set; }        
        public int? NumeroPersonasTrabajanId { get; set; }        
        public int? ClientesHabitualesId { get; set; }
        [Required]
        public string Nombre { get; set; } = string.Empty;
        public string? Alias { get; set; }
        public DateTime FechaInicioOperaciones { get; set; } = DateTime.Now;
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public string? Email { get; set; }
        public string? Nit { get; set; }
        public bool PoseeRegistroSAT { get; set; }
        public decimal VentasMensuales { get; set; }
        public decimal GananciasMensuales { get; set; }
        public decimal OtrosIngresos { get; set; }
        public string? OrigenOtrosIngresos { get; set; }
        public string? Comentarios { get; set; }
        public List<DatosContactoEmpresaDto>? ContactoEmpresas { get; set; } = new List<DatosContactoEmpresaDto>();
    }
}