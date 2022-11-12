﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RegistroCandidatos.Data;

#nullable disable

namespace RegistroCandidatos.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221112200423_ConvirtiendoCampoCedulaEnValorUnicoEnBaseDeDatos")]
    partial class ConvirtiendoCampoCedulaEnValorUnicoEnBaseDeDatos
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("RegistroCandidatos.Models.Candidato", b =>
                {
                    b.Property<int>("ID_Candidato")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_Candidato"), 1L, 1);

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cedula")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ExpectativaSalarial")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaDeNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<int>("ID_Genero")
                        .HasColumnType("int");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TrabajoActual")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID_Candidato");

                    b.HasIndex("Cedula")
                        .IsUnique();

                    b.HasIndex("ID_Genero");

                    b.ToTable("Candidato");
                });

            modelBuilder.Entity("RegistroCandidatos.Models.Genero", b =>
                {
                    b.Property<int>("ID_Genero")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_Genero"), 1L, 1);

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID_Genero");

                    b.ToTable("Genero");
                });

            modelBuilder.Entity("RegistroCandidatos.Models.Candidato", b =>
                {
                    b.HasOne("RegistroCandidatos.Models.Genero", "Genero")
                        .WithMany("Candidato")
                        .HasForeignKey("ID_Genero")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genero");
                });

            modelBuilder.Entity("RegistroCandidatos.Models.Genero", b =>
                {
                    b.Navigation("Candidato");
                });
#pragma warning restore 612, 618
        }
    }
}