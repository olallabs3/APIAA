﻿// <auto-generated />
using System;
using APIAA.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace APIAA.Migrations
{
    [DbContext(typeof(VideojuegoContext))]
    [Migration("20230307173518_Migracion")]
    partial class Migracion
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("APIAA.Models.Biblioteca", b =>
                {
                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.Property<int>("VideojuegoId")
                        .HasColumnType("int");

                    b.HasKey("UsuarioId", "VideojuegoId");

                    b.HasIndex("VideojuegoId");

                    b.ToTable("Biblioteca");
                });

            modelBuilder.Entity("APIAA.Models.Transaccion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<double>("Unidades")
                        .HasColumnType("float");

                    b.Property<int>("VideojuegoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VideojuegoId");

                    b.ToTable("Transacciones");
                });

            modelBuilder.Entity("APIAA.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Admin")
                        .HasColumnType("bit");

                    b.Property<string>("Contrasenya")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("APIAA.Models.Videojuego", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Agotado")
                        .HasColumnType("bit");

                    b.Property<double>("PrecioVenta")
                        .HasColumnType("float");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Unidades")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Videojuegos");
                });

            modelBuilder.Entity("APIAA.Models.Biblioteca", b =>
                {
                    b.HasOne("APIAA.Models.Usuario", "Usuario")
                        .WithMany("Bibliotecas")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("APIAA.Models.Videojuego", "Videojuego")
                        .WithMany("Bibliotecas")
                        .HasForeignKey("VideojuegoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");

                    b.Navigation("Videojuego");
                });

            modelBuilder.Entity("APIAA.Models.Transaccion", b =>
                {
                    b.HasOne("APIAA.Models.Videojuego", "Videojuego")
                        .WithMany()
                        .HasForeignKey("VideojuegoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Videojuego");
                });

            modelBuilder.Entity("APIAA.Models.Usuario", b =>
                {
                    b.Navigation("Bibliotecas");
                });

            modelBuilder.Entity("APIAA.Models.Videojuego", b =>
                {
                    b.Navigation("Bibliotecas");
                });
#pragma warning restore 612, 618
        }
    }
}