﻿// <auto-generated />
using System;
using GestionDeVentas.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GestionDeVentas.Persistence.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GestionDeVentas.Domain.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellido1")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Apellido2")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("Categoría")
                        .HasColumnType("int");

                    b.Property<string>("Ciudad")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Clientes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Apellido1 = "Rivero",
                            Apellido2 = "Gómez",
                            Categoría = 100,
                            Ciudad = "Almería",
                            Nombre = "Aarón"
                        },
                        new
                        {
                            Id = 2,
                            Apellido1 = "Salas",
                            Apellido2 = "Díaz",
                            Categoría = 200,
                            Ciudad = "Granada",
                            Nombre = "Adela"
                        });
                });

            modelBuilder.Entity("GestionDeVentas.Domain.Comercial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellido1")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Apellido2")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<float?>("Comisión")
                        .HasColumnType("real");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Comercios");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Apellido1 = "Sáez",
                            Apellido2 = "Vega",
                            Comisión = 0.15f,
                            Nombre = "Daniel"
                        },
                        new
                        {
                            Id = 2,
                            Apellido1 = "Gómez",
                            Apellido2 = "López",
                            Comisión = 0.13f,
                            Nombre = "Juan"
                        });
                });

            modelBuilder.Entity("GestionDeVentas.Domain.Pedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdCliente")
                        .HasColumnType("int");

                    b.Property<int>("IdComercial")
                        .HasColumnType("int");

                    b.Property<double>("Total")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("IdCliente");

                    b.HasIndex("IdComercial");

                    b.ToTable("Pedidos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Fecha = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2002),
                            IdCliente = 2,
                            IdComercial = 1,
                            Total = 150.5
                        },
                        new
                        {
                            Id = 2,
                            Fecha = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1997),
                            IdCliente = 1,
                            IdComercial = 2,
                            Total = 270.64999999999998
                        });
                });

            modelBuilder.Entity("GestionDeVentas.Domain.Pedido", b =>
                {
                    b.HasOne("GestionDeVentas.Domain.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GestionDeVentas.Domain.Comercial", "Comercial")
                        .WithMany()
                        .HasForeignKey("IdComercial")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Comercial");
                });
#pragma warning restore 612, 618
        }
    }
}