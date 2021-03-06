﻿// <auto-generated />
using System;
using ControlAlumnos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ControlAlumnos.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20200904195337_crearDb")]
    partial class crearDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ControlAlumnos.Models.Alumno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("idGrado");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("idGrado");

                    b.ToTable("Alumnos","dbo");
                });

            modelBuilder.Entity("ControlAlumnos.Models.DetallePagos", b =>
                {
                    b.Property<int>("IdAlumno_master")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Total");

                    b.Property<DateTime>("fecha");

                    b.Property<int>("idAlumno");

                    b.Property<int>("idMes");

                    b.HasKey("IdAlumno_master");

                    b.HasIndex("idAlumno");

                    b.HasIndex("idMes");

                    b.ToTable("DetallesAlumno","dbo");
                });

            modelBuilder.Entity("ControlAlumnos.Models.Grado", b =>
                {
                    b.Property<int>("idGrado")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("nombreGrado")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("idGrado");

                    b.ToTable("Grados","dbo");
                });

            modelBuilder.Entity("ControlAlumnos.Models.Mes", b =>
                {
                    b.Property<int>("idMes")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("nombreMes")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("idMes");

                    b.ToTable("Meses","dbo");
                });

            modelBuilder.Entity("ControlAlumnos.Models.Alumno", b =>
                {
                    b.HasOne("ControlAlumnos.Models.Grado", "grado")
                        .WithMany("alumnos")
                        .HasForeignKey("idGrado")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ControlAlumnos.Models.DetallePagos", b =>
                {
                    b.HasOne("ControlAlumnos.Models.Alumno", "Alumno")
                        .WithMany("detalleAlumno")
                        .HasForeignKey("idAlumno")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ControlAlumnos.Models.Mes", "Mes")
                        .WithMany("detalleMes")
                        .HasForeignKey("idMes")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
