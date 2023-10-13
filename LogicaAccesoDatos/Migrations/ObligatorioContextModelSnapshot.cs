﻿// <auto-generated />
using System;
using LogicaAccesoDatos.RepositoriosEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LogicaAccesoDatos.Migrations
{
    [DbContext(typeof(ObligatorioContext))]
    partial class ObligatorioContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AmenazaEcosistema", b =>
                {
                    b.Property<int>("AmenazasId")
                        .HasColumnType("int");

                    b.Property<int>("EcosistemasId")
                        .HasColumnType("int");

                    b.HasKey("AmenazasId", "EcosistemasId");

                    b.HasIndex("EcosistemasId");

                    b.ToTable("AmenazaEcosistema");
                });

            modelBuilder.Entity("AmenazaEspecie", b =>
                {
                    b.Property<int>("AmenazasId")
                        .HasColumnType("int");

                    b.Property<int>("EspeciesId")
                        .HasColumnType("int");

                    b.HasKey("AmenazasId", "EspeciesId");

                    b.HasIndex("EspeciesId");

                    b.ToTable("AmenazaEspecie");
                });

            modelBuilder.Entity("Dominio.Entidades.Amenaza", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GradoPeligrosidad")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Amenazas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descripcion = "Caza furtiva",
                            GradoPeligrosidad = 8
                        },
                        new
                        {
                            Id = 2,
                            Descripcion = "Deforestación",
                            GradoPeligrosidad = 7
                        });
                });

            modelBuilder.Entity("Dominio.Entidades.Ecosistema", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("AreaMetrosCuadrados")
                        .HasColumnType("float");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EstadoConservacionId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EstadoConservacionId");

                    b.ToTable("Ecosistemas");
                });

            modelBuilder.Entity("Dominio.Entidades.Especie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EstadoConservacionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EstadoConservacionId");

                    b.ToTable("Especies");
                });

            modelBuilder.Entity("Dominio.Entidades.EstadoConservacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RangoSeguridadMaximo")
                        .HasColumnType("int");

                    b.Property<int>("RangoSeguridadMinimo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("EstadosConservacion");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nombre = "En peligro",
                            RangoSeguridadMaximo = 3,
                            RangoSeguridadMinimo = 1
                        },
                        new
                        {
                            Id = 2,
                            Nombre = "Vulnerable",
                            RangoSeguridadMaximo = 7,
                            RangoSeguridadMinimo = 4
                        });
                });

            modelBuilder.Entity("Dominio.Entidades.Pais", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CodigoAlpha3")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Paises");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CodigoAlpha3 = "ARG",
                            Nombre = "Argentina"
                        },
                        new
                        {
                            Id = 2,
                            CodigoAlpha3 = "BRA",
                            Nombre = "Brasil"
                        });
                });

            modelBuilder.Entity("EcosistemaEspecie", b =>
                {
                    b.Property<int>("EcosistemasId")
                        .HasColumnType("int");

                    b.Property<int>("EspeciesId")
                        .HasColumnType("int");

                    b.HasKey("EcosistemasId", "EspeciesId");

                    b.HasIndex("EspeciesId");

                    b.ToTable("EcosistemaEspecie");
                });

            modelBuilder.Entity("EcosistemaPais", b =>
                {
                    b.Property<int>("EcosistemasId")
                        .HasColumnType("int");

                    b.Property<int>("PaisesId")
                        .HasColumnType("int");

                    b.HasKey("EcosistemasId", "PaisesId");

                    b.HasIndex("PaisesId");

                    b.ToTable("EcosistemaPais");
                });

            modelBuilder.Entity("Usuarios.Entidades.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Alias")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContraseniaEncriptada")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContraseniaSinEncriptar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaIngreso")
                        .HasColumnType("datetime2");

                    b.Property<string>("TipoUsuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");

                    b.HasDiscriminator<string>("TipoUsuario").HasValue("Usuario");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Usuarios.Entidades.UsuarioAdmin", b =>
                {
                    b.HasBaseType("Usuarios.Entidades.Usuario");

                    b.HasDiscriminator().HasValue("Admin");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Alias = "AdminUser",
                            ContraseniaEncriptada = "SomeEncryptedPassword",
                            ContraseniaSinEncriptar = "UserPasswordPlainText",
                            FechaIngreso = new DateTime(2023, 10, 13, 11, 1, 43, 957, DateTimeKind.Local).AddTicks(2687)
                        });
                });

            modelBuilder.Entity("Usuarios.Entidades.UsuarioAutorizado", b =>
                {
                    b.HasBaseType("Usuarios.Entidades.Usuario");

                    b.HasDiscriminator().HasValue("Autorizado");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            Alias = "GeneralUser",
                            ContraseniaEncriptada = "AnotherEncryptedPassword",
                            ContraseniaSinEncriptar = "UserPasswordPlainText",
                            FechaIngreso = new DateTime(2023, 10, 13, 11, 1, 43, 957, DateTimeKind.Local).AddTicks(2725)
                        });
                });

            modelBuilder.Entity("AmenazaEcosistema", b =>
                {
                    b.HasOne("Dominio.Entidades.Amenaza", null)
                        .WithMany()
                        .HasForeignKey("AmenazasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dominio.Entidades.Ecosistema", null)
                        .WithMany()
                        .HasForeignKey("EcosistemasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AmenazaEspecie", b =>
                {
                    b.HasOne("Dominio.Entidades.Amenaza", null)
                        .WithMany()
                        .HasForeignKey("AmenazasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dominio.Entidades.Especie", null)
                        .WithMany()
                        .HasForeignKey("EspeciesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Dominio.Entidades.Ecosistema", b =>
                {
                    b.HasOne("Dominio.Entidades.EstadoConservacion", "EstadoConservacion")
                        .WithMany()
                        .HasForeignKey("EstadoConservacionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.OwnsOne("Dominio.Entidades.ValueObjects.Ecosistema.Coordenadas", "Coordenadas", b1 =>
                        {
                            b1.Property<int>("EcosistemaId")
                                .HasColumnType("int");

                            b1.Property<decimal>("Latitud")
                                .HasColumnType("decimal(18,2)");

                            b1.Property<decimal>("Longitud")
                                .HasColumnType("decimal(18,2)");

                            b1.HasKey("EcosistemaId");

                            b1.ToTable("Ecosistemas");

                            b1.WithOwner()
                                .HasForeignKey("EcosistemaId");
                        });

                    b.OwnsOne("Dominio.Entidades.ValueObjects.Ecosistema.Imagen", "Imagen", b1 =>
                        {
                            b1.Property<int>("EcosistemaId")
                                .HasColumnType("int");

                            b1.Property<string>("Descripcion")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Nombre")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("rutaImagen")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("EcosistemaId");

                            b1.ToTable("Ecosistemas");

                            b1.WithOwner()
                                .HasForeignKey("EcosistemaId");
                        });

                    b.Navigation("Coordenadas")
                        .IsRequired();

                    b.Navigation("EstadoConservacion");

                    b.Navigation("Imagen")
                        .IsRequired();
                });

            modelBuilder.Entity("Dominio.Entidades.Especie", b =>
                {
                    b.HasOne("Dominio.Entidades.EstadoConservacion", "EstadoConservacion")
                        .WithMany()
                        .HasForeignKey("EstadoConservacionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.OwnsOne("Dominio.Entidades.ValueObjects.Especie.AtributosFisicos", "AtributosFisicos", b1 =>
                        {
                            b1.Property<int>("EspecieId")
                                .HasColumnType("int");

                            b1.Property<decimal>("RangoLongitudCm")
                                .HasColumnType("decimal(18,2)");

                            b1.Property<decimal>("RangoPesoKg")
                                .HasColumnType("decimal(18,2)");

                            b1.HasKey("EspecieId");

                            b1.ToTable("Especies");

                            b1.WithOwner()
                                .HasForeignKey("EspecieId");
                        });

                    b.OwnsOne("Dominio.Entidades.ValueObjects.Especie.Imagen", "Imagen", b1 =>
                        {
                            b1.Property<int>("EspecieId")
                                .HasColumnType("int");

                            b1.Property<string>("Descripcion")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Nombre")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("EspecieId");

                            b1.ToTable("Especies");

                            b1.WithOwner()
                                .HasForeignKey("EspecieId");
                        });

                    b.OwnsOne("Dominio.Entidades.ValueObjects.Especie.Nombre", "Nombre", b1 =>
                        {
                            b1.Property<int>("EspecieId")
                                .HasColumnType("int");

                            b1.Property<string>("NombreCientifico")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("NombreVulgar")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("EspecieId");

                            b1.ToTable("Especies");

                            b1.WithOwner()
                                .HasForeignKey("EspecieId");
                        });

                    b.Navigation("AtributosFisicos")
                        .IsRequired();

                    b.Navigation("EstadoConservacion");

                    b.Navigation("Imagen")
                        .IsRequired();

                    b.Navigation("Nombre")
                        .IsRequired();
                });

            modelBuilder.Entity("EcosistemaEspecie", b =>
                {
                    b.HasOne("Dominio.Entidades.Ecosistema", null)
                        .WithMany()
                        .HasForeignKey("EcosistemasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dominio.Entidades.Especie", null)
                        .WithMany()
                        .HasForeignKey("EspeciesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EcosistemaPais", b =>
                {
                    b.HasOne("Dominio.Entidades.Ecosistema", null)
                        .WithMany()
                        .HasForeignKey("EcosistemasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dominio.Entidades.Pais", null)
                        .WithMany()
                        .HasForeignKey("PaisesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
