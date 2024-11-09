using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;
using WebAPI.Models.DTOS.TablaGeneralResponse;
using System.Text.RegularExpressions;
using WebAPI.Domain.Queries.TablaGeneralQueries;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class TablaGeneralController : ControllerBase
    {
        private readonly DbpruebaContext _dbpruebaContext;
        public TablaGeneralController(DbpruebaContext dbpruebaContext)
        {
            _dbpruebaContext = dbpruebaContext;
        }

        [HttpGet]
        [Route("GetByKeyCode")]
        public async Task<IActionResult> GetByKeyCode([FromQuery]TablaGeneralQuery query)
        {
            if (string.IsNullOrEmpty(query.Key.ToString()))
            {
                return BadRequest("El parámetro Key es obligatorio y no puede ser nulo o vacío.");
            }

            // Realizar la consulta usando LINQ
            var lista = await _dbpruebaContext.TablaGeneral
                .Where(n => n.Grupo == query.Key.ToString()) // Filtrar por la columna Grupo
                .Select(n => new GetByKeyCodeResponse
                {
                    Value = n.Grupo,
                    Description = n.Descripcion
                })
                .ToListAsync();

            // Retornar los resultados
            return Ok(lista);
        }

    }
}
