﻿namespace Core.Entities
{
    public class MontoInteresado : BaseEntity
    {
        public string Nombre { get; set; } = string.Empty;
        public string? Descripcion { get; set; }
    }
}
