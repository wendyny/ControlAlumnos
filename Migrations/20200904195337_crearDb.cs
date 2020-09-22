using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ControlAlumnos.Migrations
{
    public partial class crearDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Grados",
                schema: "dbo",
                columns: table => new
                {
                    idGrado = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nombreGrado = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grados", x => x.idGrado);
                });

            migrationBuilder.CreateTable(
                name: "Meses",
                schema: "dbo",
                columns: table => new
                {
                    idMes = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nombreMes = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meses", x => x.idMes);
                });

            migrationBuilder.CreateTable(
                name: "Alumnos",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    idGrado = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alumnos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alumnos_Grados_idGrado",
                        column: x => x.idGrado,
                        principalSchema: "dbo",
                        principalTable: "Grados",
                        principalColumn: "idGrado",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetallesAlumno",
                schema: "dbo",
                columns: table => new
                {
                    IdAlumno_master = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    idAlumno = table.Column<int>(nullable: false),
                    idMes = table.Column<int>(nullable: false),
                    fecha = table.Column<DateTime>(nullable: false),
                    Total = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallesAlumno", x => x.IdAlumno_master);
                    table.ForeignKey(
                        name: "FK_DetallesAlumno_Alumnos_idAlumno",
                        column: x => x.idAlumno,
                        principalSchema: "dbo",
                        principalTable: "Alumnos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetallesAlumno_Meses_idMes",
                        column: x => x.idMes,
                        principalSchema: "dbo",
                        principalTable: "Meses",
                        principalColumn: "idMes",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alumnos_idGrado",
                schema: "dbo",
                table: "Alumnos",
                column: "idGrado");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesAlumno_idAlumno",
                schema: "dbo",
                table: "DetallesAlumno",
                column: "idAlumno");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesAlumno_idMes",
                schema: "dbo",
                table: "DetallesAlumno",
                column: "idMes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetallesAlumno",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Alumnos",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Meses",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Grados",
                schema: "dbo");
        }
    }
}
