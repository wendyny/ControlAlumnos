using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControlAlumnos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControlAlumnos.DataContext
{
    public class DetalleMap:IEntityTypeConfiguration<DetallePagos>
    {
        public void Configure(EntityTypeBuilder<DetallePagos> builder) 
        {
            builder.ToTable("DetallesAlumno", "dbo");
            builder.Property(d => d.IdAlumno_master).IsRequired().UseSqlServerIdentityColumn();
            builder.HasOne(a => a.Alumno).WithMany(a=> a.detalleAlumno).HasForeignKey(a => a.idAlumno);
            builder.HasOne(m => m.Mes).WithMany(m => m.detalleMes).HasForeignKey(m => m.idMes);
    
        }
    }
}
