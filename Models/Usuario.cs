using System;
using System.Collections.Generic;

namespace WebAPI.Models;

public partial class Usuario
{
    public int IdUsusarios { get; set; }

    public string? Nombre { get; set; }

    public string? Correo { get; set; }

    public string? Clave { get; set; }
}
