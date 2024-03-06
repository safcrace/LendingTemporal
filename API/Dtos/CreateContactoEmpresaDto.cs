﻿using Core.Entities;

namespace API.Dtos
{
    public class CreateContactoEmpresaDto
    {
        public int? EmpresaId { get; set; }        
        public int? OcupacionId { get; set; }
        public string? PrimerNombre { get; set; }
        public string ?SegundoNombre { get; set; }
        public string ?TercerNombre { get; set; }
        public string? PrimerApellido { get; set; }
        public string? SegundoApellido { get; set; }
        public string? ApellidoCasada { get; set; }
        public string? TelefonoPrincipal { get; set; }
        public string? Celular { get; set; }
        public string? CorreoElectronico { get; set; }
    }
}