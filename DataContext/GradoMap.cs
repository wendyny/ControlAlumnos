using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControlAlumnos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControlAlumnos.DataContext
{
    public class GradoMap:IEntityTypeConfiguration<Grado>
    {
        public void Configure(EntityTypeBuilder<Grado> builder) 
        {
            builder.ToTable("Grados", "dbo");
            builder.HasKey(g=>g.idGrado);
            builder.Property(g => g.idGrado).IsRequired().UseSqlServerIdentityColumn();
            builder.Property(g =>g.nombreGrado).HasColumnType("varchar(50)").HasMaxLength(50).IsRequired();
        }
    }
}
