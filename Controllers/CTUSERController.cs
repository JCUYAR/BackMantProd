using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;
using WebAPI.Models.DTOS.CTUSERResponse;
using WebAPI.Domain.Commands.CTUSERCommand;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class CTUSERController : ControllerBase
    {
        private readonly DbpruebaContext _dbpruebaContext;
        public CTUSERController(DbpruebaContext dbpruebaContext)
        {
            _dbpruebaContext = dbpruebaContext;
        }

        [HttpGet]
        [Route("List")]
        public async Task<IActionResult> Lista()
        {
            // Obtiene la lista de CTUSER desde la base de datos y mapea cada elemento a ListCTUSERResponse
            var lista = await _dbpruebaContext.CTUSER
                .Select(ctuser => new ListCTUSERResponse
                {
                    Id = ctuser.Id,
                    Name = ctuser.Name,
                    Lname = ctuser.Lname,
                    Doctype = ctuser.Doctype
                    // Incluye cualquier otra propiedad que necesites
                })
                .ToListAsync();

            // Retorna la lista de objetos ListCTUSERResponse como respuesta
            return Ok(lista);
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddCTUSER(AddCTUSERCommand ctuser)
        {
            var addCTUSER = new CTUSER
            {
                Id = ctuser.Id,
                Name = ctuser.Name,
                Lname = ctuser.Lname,
                Doctype = ctuser.Doctype,
                Docnum = ctuser.Docnum,
                Nationality = ctuser.Nationality,
                Address = ctuser.Address,
                Borndate = ctuser.Borndate,
                Gender = ctuser.Gender,
            };

            await _dbpruebaContext.CTUSER.AddAsync(addCTUSER);
            await _dbpruebaContext.SaveChangesAsync();

            // Crear la respuesta a partir del objeto guardado
            var response = new AddCTUSERResponse
            {
                Id = addCTUSER.Id, // Asumiendo que 'Id' es una propiedad autoincremental que se genera al guardar
                Name = addCTUSER.Name
            };

            return Ok(response); // Devuelve la respuesta en la estructura deseada
        }


    }
}
