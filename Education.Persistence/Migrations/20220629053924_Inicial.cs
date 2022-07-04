using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Education.Persistence.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    CursoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    FechaPublicacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Precio = table.Column<decimal>(type: "decimal(14,2)", precision: 14, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.CursoId);
                });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "CursoId", "Descripcion", "FechaCreacion", "FechaPublicacion", "Precio", "Titulo" },
                values: new object[] { new Guid("3594b10f-8cd5-4b38-989d-91d693719c34"), "Fundamentos de contabilidad", new DateTime(2022, 6, 29, 0, 39, 24, 585, DateTimeKind.Local).AddTicks(8125), new DateTime(2024, 6, 29, 0, 39, 24, 585, DateTimeKind.Local).AddTicks(8127), 30m, "Curso de Contabilidad" });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "CursoId", "Descripcion", "FechaCreacion", "FechaPublicacion", "Precio", "Titulo" },
                values: new object[] { new Guid("43add9d0-7940-4a46-b726-6d9069dab452"), "Fundamentos de programación", new DateTime(2022, 6, 29, 0, 39, 24, 585, DateTimeKind.Local).AddTicks(8061), new DateTime(2024, 6, 29, 0, 39, 24, 585, DateTimeKind.Local).AddTicks(8074), 24m, "Curso de Algoritmos" });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "CursoId", "Descripcion", "FechaCreacion", "FechaPublicacion", "Precio", "Titulo" },
                values: new object[] { new Guid("8ce62520-e2bd-4ad0-99aa-81467c94de06"), "Fundamentos de ASP.NET", new DateTime(2022, 6, 29, 0, 39, 24, 585, DateTimeKind.Local).AddTicks(8145), new DateTime(2024, 6, 29, 0, 39, 24, 585, DateTimeKind.Local).AddTicks(8146), 250m, "Curso de NET6" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cursos");
        }
    }
}
