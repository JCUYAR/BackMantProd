using System;
using System.Collections.Generic;

namespace WebAPI.Models;

public partial class Producto
{
    public int IdProductos { get; set; }

    public string? Nombre { get; set; }

    public string? Marca { get; set; }

    public decimal? Precio { get; set; }
    public int? Stock { get; set; }
    public string? Estado { get; set; }
}
