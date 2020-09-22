using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControlAlumnos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControlAlumnos.DataContext
{
    public class AlumnoMap:IEntityTypeConfiguration<Alumno>
    {
        public void Configure(EntityTypeBuilder<Alumno> builder) 
        {
            builder.ToTable("Alumnos", "dbo");
            builder.HasKey(a=>a.Id);
            builder.Property(a => a.Id).IsRequired().UseSqlServerIdentityColumn();
            builder.HasOne(g => g.grado).WithMany(g => g.alumnos).HasForeignKey(g => g.idGrado);
            builder.Property(n =>n.nombre).HasColumnType("varchar(50)").HasMaxLength(50).IsRequired();
        }
    }
}
