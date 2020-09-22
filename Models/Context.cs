using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using ControlAlumnos.DataContext;
using Microsoft.EntityFrameworkCore;

namespace ControlAlumnos.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        { }
        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Grado> Grados { get; set; }
        public DbSet<Mes> Meses { get; set; }
        public DbSet<DetallePagos> DetallesAlumno { get; set; }

        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder) 
        { 
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-P1J30VH;Database=ControlPagos;Trusted_Connection=True;"); 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AlumnoMap());
            modelBuilder.ApplyConfiguration(new DetalleMap());
            modelBuilder.ApplyConfiguration(new GradoMap());
            modelBuilder.ApplyConfiguration(new MesMap());
            base.OnModelCreating(modelBuilder);
        }
             

    }
         
}

