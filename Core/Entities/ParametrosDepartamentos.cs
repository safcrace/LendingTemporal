﻿namespace Core.Entities
{
    public class ParametrosDepartamentos
    {
        public TipoPrestamo? TipoPrestamo { get; set; } 
        public int TipoPrestamoId { get; set; }
        public Departamento? Departamento { get; set; }
        public int DepartamentoId { get; set; }
        public bool MontoFijo { get; set; }
        public bool MontoVariable { get; set; }
        public decimal MontoMinimo { get; set; }
        public decimal MontoMaximo { get; set; }
        public decimal MontoPredeterminado { get; set; }
        public bool PlazoFijo { get; set; }
        public bool PlazoVariable { get; set; }
        public byte PlazoMinimo { get; set; }
        public byte PlazoMaximo { get; set; }
        public byte PlazoPredeterminado { get; set; }
        public byte DiaInicioMes { get; set; }
        public byte DiaQuincena { get; set; }
        public byte DiaFinMes { get; set; }
        public bool Habilitado { get; set; } = true;
    }
}