using Microsoft.EntityFrameworkCore;
using Prueba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba.Data
{
    public class PruebaContext : DbContext
    {
        public PruebaContext(DbContextOptions<PruebaContext> options)
            : base(options) { }
        public DbSet<Departamento> Departamento { get; set; }
        public DbSet<Cargo> Cargo { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
    }
}
