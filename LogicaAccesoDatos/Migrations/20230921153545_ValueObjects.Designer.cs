﻿// <auto-generated />
using LogicaAccesoDatos.RepositoriosEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LogicaAccesoDatos.Migrations
{
    [DbContext(typeof(ObligatorioContext))]
    [Migration("20230921153545_ValueObjects")]
    partial class ValueObjects
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                            b1.HasKey("EspecieId");

                            b1.ToTable("Especies");

                            b1.WithOwner()
                                .HasForeignKey("EspecieId");
                        });

                    b.OwnsOne("Dominio.Entidades.ValueObjects.Especie.Imagen", "Imagen", b1 =>
                        {
                            b1.Property<int>("EspecieId")
                                .HasColumnType("int");

                            b1.HasKey("EspecieId");

                            b1.ToTable("Especies");

                            b1.WithOwner()
                                .HasForeignKey("EspecieId");
                        });

                    b.OwnsOne("Dominio.Entidades.ValueObjects.Especie.Nombre", "Nombre", b1 =>
                        {
                            b1.Property<int>("EspecieId")
                                .HasColumnType("int");

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
