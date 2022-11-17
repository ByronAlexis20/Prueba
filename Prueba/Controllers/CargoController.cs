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
    public class CargoController : Controller
    {
        private readonly PruebaContext _context;

        public CargoController(PruebaContext context)
        {
            _context = context;
        }

        [HttpGet("obtenercargos")]
        public async Task<ActionResult> ObtenerCargos()
        {
            var cargos = await _context.Cargo.ToListAsync();
            return Ok(cargos);
        }
    }
}
