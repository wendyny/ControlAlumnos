using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControlAlumnos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControlAlumnos.DataContext
{
    public class MesMap:IEntityTypeConfiguration<Mes>
    {
        public void Configure(EntityTypeBuilder<Mes> builder) 
        {
            builder.ToTable("Meses", "dbo");
            builder.HasKey(m=>m.idMes);
            builder.Property(m => m.idMes).IsRequired().UseSqlServerIdentityColumn();
            builder.Property(m =>m.nombreMes).HasColumnType("varchar(50)").HasMaxLength(50).IsRequired();
        }
    }
}
