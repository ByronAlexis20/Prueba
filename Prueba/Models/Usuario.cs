using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Cargo")]
        public int cargoId { get; set; }
        [ForeignKey("Departamento")]
        public int DepartamentoId { get; set; }
        public String NombreUsuario { get; set; }
        public String PrimerNombre { get; set; }
        public String SegundoNombre { get; set; }
        public String PrimerApellido { get; set; }
        public String SegundoApellido { get; set; }
        public virtual Cargo Cargo { get; set; }
        public virtual Departamento Departamento { get; set; }
    }
}
