using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Custom;
using WebAPI.Models;
using WebAPI.Models.DTOS;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Runtime.InteropServices;
using WebAPI.Models.DTOS.ProductoResponse;
using WebAPI.Domain.Commands.ProductoCommand;
using WebAPI.Domain.Queries.ProductoQueries;


namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly DbpruebaContext _dbpruebaContext;
        public ProductoController(DbpruebaContext dbpruebaContext)
        {
            _dbpruebaContext = dbpruebaContext;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista ()
        {
            var lista = await _dbpruebaContext.Productos.ToListAsync();
            return StatusCode(StatusCodes.Status200OK, new {value = lista});
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddProducto(AddProductoCommand product)
        {
            // Validación de tipo y rango de datos
            if (product.Precio <= 0)
            {
                return BadRequest("El precio debe ser un valor mayor que 0.");
            }

            if (product.Stock < 0)
            {
                return BadRequest("El stock no puede ser un valor negativo.");
            }

            // Crear el producto a partir del comando recibido
            var addProduct = new Producto
            {
                Nombre = product.Nombre,
                Marca = product.Marca,
                Precio = product.Precio, // Ya es un decimal
                Stock = product.Stock,   // Ya es un int
                Estado = product.Estado,
            };

            // Agregar el producto a la base de datos
            await _dbpruebaContext.Productos.AddAsync(addProduct);
            await _dbpruebaContext.SaveChangesAsync();

            // Crear la respuesta
            var response = new AddProductoResponse
            {
                Id = addProduct.IdProductos,
                Nombre = addProduct.Nombre,
            };

            return Ok(response);
        }

        [HttpGet]
        [Route("Visualize")]
        public async Task<IActionResult> VisualizeProducto([FromQuery] VisualizeProductoQuery query)
        {
            if (string.IsNullOrEmpty(query.Id.ToString()))
            {
                return BadRequest("El parámetro Key es obligatorio y no puede ser nulo o vacío.");
            }

            var lista = await _dbpruebaContext.Productos
                .Where(n => n.IdProductos == query.Id)
                .Select(n => new VisualizeProductoResponse
                {
                    IdProductos = n.IdProductos,
                    Nombre = n.Nombre,
                    Marca = n.Marca,
                    Precio = n.Precio,
                    Stock = n.Stock,
                    Estado = n.Estado
                })
                .ToListAsync();
            return Ok(lista);
        }

    }
}
