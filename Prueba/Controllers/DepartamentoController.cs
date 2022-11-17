using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prueba.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentoController : Controller
    {
        private readonly PruebaContext _context;

        public DepartamentoController(PruebaContext context)
        {
            _context = context;
        }

        [HttpGet("obtenerdepartamentos")]
        public async Task<ActionResult> ObtenerDepartamentos()
        {
            var departamentos = await _context.Departamento.ToListAsync();
            return Ok(departamentos);
        }
    }
}
