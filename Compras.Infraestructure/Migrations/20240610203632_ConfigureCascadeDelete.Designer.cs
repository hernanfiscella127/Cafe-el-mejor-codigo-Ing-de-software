﻿// <auto-generated />
using System;
using Compras.Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Compras.Infraestructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240610203632_ConfigureCascadeDelete")]
    partial class ConfigureCascadeDelete
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Compras.Domain.Entidades.OrdenDeCompra", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("Fecha")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<int>("IdProveedor")
                        .HasColumnType("int");

                    b.Property<int?>("PrecioTotal")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdProveedor");

                    b.ToTable("OrdenDeCompra", (string)null);
                });

            modelBuilder.Entity("Compras.Domain.Entidades.OrdenProducto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("IdOrdenCompra")
                        .HasColumnType("int");

                    b.Property<int>("IdProducto")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdOrdenCompra");

                    b.HasIndex("IdProducto");

                    b.ToTable("OrdenProducto");
                });

            modelBuilder.Entity("Compras.Domain.Entidades.Producto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("FechaVencimiento")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdProveedor")
                        .HasColumnType("int");

                    b.Property<int>("NumeroLote")
                        .HasColumnType("int");

                    b.Property<double>("PrecioVenta")
                        .HasColumnType("float");

                    b.Property<int>("StockActual")
                        .HasColumnType("int");

                    b.Property<int>("StockMinimo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdProveedor");

                    b.ToTable("Producto", (string)null);
                });

            modelBuilder.Entity("Compras.Domain.Entidades.Proveedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("Cuil")
                        .HasColumnType("int");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("NombreEmpresa")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Telefono")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Proveedor", (string)null);
                });

            modelBuilder.Entity("Compras.Domain.Entidades.OrdenDeCompra", b =>
                {
                    b.HasOne("Compras.Domain.Entidades.Proveedor", "Proveedor")
                        .WithMany("OrdenesDeCompra")
                        .HasForeignKey("IdProveedor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Proveedor");
                });

            modelBuilder.Entity("Compras.Domain.Entidades.OrdenProducto", b =>
                {
                    b.HasOne("Compras.Domain.Entidades.OrdenDeCompra", "OrdenCompra")
                        .WithMany("OrdenProductos")
                        .HasForeignKey("IdOrdenCompra")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Compras.Domain.Entidades.Producto", "Producto")
                        .WithMany("OrdenProductos")
                        .HasForeignKey("IdProducto")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("OrdenCompra");

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("Compras.Domain.Entidades.Producto", b =>
                {
                    b.HasOne("Compras.Domain.Entidades.Proveedor", "Proveedor")
                        .WithMany("Productos")
                        .HasForeignKey("IdProveedor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Proveedor");
                });

            modelBuilder.Entity("Compras.Domain.Entidades.OrdenDeCompra", b =>
                {
                    b.Navigation("OrdenProductos");
                });

            modelBuilder.Entity("Compras.Domain.Entidades.Producto", b =>
                {
                    b.Navigation("OrdenProductos");
                });

            modelBuilder.Entity("Compras.Domain.Entidades.Proveedor", b =>
                {
                    b.Navigation("OrdenesDeCompra");

                    b.Navigation("Productos");
                });
#pragma warning restore 612, 618
        }
    }
}
