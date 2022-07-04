﻿// <auto-generated />
using System;
using Education.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Education.Persistence.Migrations
{
    [DbContext(typeof(EducationDbContext))]
    [Migration("20220629053924_Inicial")]
    partial class Inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Education.Domain.Curso", b =>
                {
                    b.Property<Guid>("CursoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaPublicacion")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Precio")
                        .HasPrecision(14, 2)
                        .HasColumnType("decimal(14,2)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("CursoId");

                    b.ToTable("Cursos");

                    b.HasData(
                        new
                        {
                            CursoId = new Guid("43add9d0-7940-4a46-b726-6d9069dab452"),
                            Descripcion = "Fundamentos de programación",
                            FechaCreacion = new DateTime(2022, 6, 29, 0, 39, 24, 585, DateTimeKind.Local).AddTicks(8061),
                            FechaPublicacion = new DateTime(2024, 6, 29, 0, 39, 24, 585, DateTimeKind.Local).AddTicks(8074),
                            Precio = 24m,
                            Titulo = "Curso de Algoritmos"
                        },
                        new
                        {
                            CursoId = new Guid("3594b10f-8cd5-4b38-989d-91d693719c34"),
                            Descripcion = "Fundamentos de contabilidad",
                            FechaCreacion = new DateTime(2022, 6, 29, 0, 39, 24, 585, DateTimeKind.Local).AddTicks(8125),
                            FechaPublicacion = new DateTime(2024, 6, 29, 0, 39, 24, 585, DateTimeKind.Local).AddTicks(8127),
                            Precio = 30m,
                            Titulo = "Curso de Contabilidad"
                        },
                        new
                        {
                            CursoId = new Guid("8ce62520-e2bd-4ad0-99aa-81467c94de06"),
                            Descripcion = "Fundamentos de ASP.NET",
                            FechaCreacion = new DateTime(2022, 6, 29, 0, 39, 24, 585, DateTimeKind.Local).AddTicks(8145),
                            FechaPublicacion = new DateTime(2024, 6, 29, 0, 39, 24, 585, DateTimeKind.Local).AddTicks(8146),
                            Precio = 250m,
                            Titulo = "Curso de NET6"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}