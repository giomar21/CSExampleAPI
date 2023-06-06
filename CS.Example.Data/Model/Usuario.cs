using System;
using System.Collections.Generic;

namespace CS.Example.Data.Model;

public partial class Usuario
{
    public Guid IdUsuario { get; set; }

    public string Nombre { get; set; } = null!;

    public string ApellidoPaterno { get; set; } = null!;

    public string? ApellidoMaterno { get; set; }

    public decimal? Salario { get; set; }

    public string Curp { get; set; } = null!;

    public string? Telefono { get; set; }

    public DateTime FechaCreacion { get; set; }

    public DateTime? FechaActualizacion { get; set; }

    public bool Activo { get; set; }
}
