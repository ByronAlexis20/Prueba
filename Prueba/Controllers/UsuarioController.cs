using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Prueba.Data;
using System.Threading.Tasks;
using Prueba.Models;

namespace Prueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly PruebaContext _context;
        public UsuarioController(PruebaContext context)
        {
            _context = context;
            //agregar departamentos y cargos por defecto
            //usuario por defecto (Admin)
            
            //departamento
            
            if (_context.Departamento.Count() == 0)
            {
                List<Departamento> departamentos = new List<Departamento>();
                departamentos.Add(new Departamento { Codigo = "SIST", Nombre = "Sistemas",  Activo = true });
                departamentos.Add(new Departamento { Codigo = "RRHH", Nombre = "Recursos humanos", Activo = true });
                departamentos.Add(new Departamento { Codigo = "FIN", Nombre = "Financiero", Activo = true });
                _context.Departamento.AddRange(departamentos);
            }
            //Cargo
            if (_context.Cargo.Count() == 0)
            {
                List<Cargo> cargos = new List<Cargo>();
                cargos.Add(new Cargo { Codigo = "PROG", Nombre = "Programador", Activo = true });
                cargos.Add(new Cargo { Codigo = "JRH", Nombre = "Jefe", Activo = true });
                cargos.Add(new Cargo { Codigo = "ANL", Nombre = "Analista", Activo = true });
                _context.Cargo.AddRange(cargos);
            }
        }

        
        //API QUE PERMITE OBTENER TODOS LOS USUARIOS
        [HttpGet("obtenerusuarios")]
        public async Task<ActionResult> ObtenerTodosUsuarios()
        {
            var usuarios = await _context.Usuario.ToListAsync();
            return Ok(usuarios);
        }

        //SERVICIO PARA CREAR USUUARIO
        [HttpPost("crearusuarios")]
        public async Task<ActionResult> CrearUsuarios( Usuario user )
        {
            _context.Usuario.Add(user);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(ObtenerUsuarioPorId), new { id = user.Id }, user);
        }

        //SERVICIO PARA OBTENER LOS USUARIO POR ID
        [HttpGet("obtenerporid/{id}")]
        public async Task<ActionResult> ObtenerUsuarioPorId(int id)
        {
            var usuario = await _context.Usuario.FirstOrDefaultAsync(s => s.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        //SERVICIO QUE ME PERMITE EDITAR UN REGISTRO
        [HttpPut("editarUsuario/{id}")]
        public async Task<ActionResult> EditarUsuario(int id, Usuario user)
        {
            Usuario usuario = await _context.Usuario.FirstOrDefaultAsync(s => s.Id == id);

            if (usuario != null)
            {
                usuario.NombreUsuario = user.NombreUsuario;
                usuario.PrimerNombre = user.PrimerNombre;
                usuario.SegundoNombre = user.SegundoNombre;
                usuario.PrimerApellido = user.PrimerApellido;
                usuario.DepartamentoId = user.DepartamentoId;
                usuario.cargoId = user.cargoId;

                _context.Entry(usuario).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return NoContent();
            }
            return BadRequest();
        }

        //SERVICIO QUE ME ELIMINAR UN USUARIO
        [HttpDelete("eliminarusuario/{id}")]
        public async Task<ActionResult> EliminarUsuarioPorId(int id)
        {
            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            _context.Usuario.Remove(usuario);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
