using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Usuarios.Entidades;

namespace LogicaAccesoDatos.RepositoriosEntity
{
    public class ObligatorioContext : DbContext
    {
        public ObligatorioContext(DbContextOptions<ObligatorioContext> options)
       : base(options)
        {
        }
        public DbSet<Amenaza> Amenazas { get; set; }
        public DbSet<Especie> Especies { get; set; }
        public DbSet<EstadoConservacion> EstadosConservacion { get; set; }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<Ecosistema> Ecosistemas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<ConfiguracionValidaciones> Configuraciones{get;set;}

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración para Especie
            modelBuilder.Entity<Especie>()
                .HasOne(e => e.EstadoConservacion)
                .WithMany()
                .HasForeignKey(e => e.EstadoConservacionId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configuración para Ecosistema 
            modelBuilder.Entity<Ecosistema>()
                .HasOne(e => e.EstadoConservacion)
                .WithMany()
                .HasForeignKey(e => e.EstadoConservacionId)
                .OnDelete(DeleteBehavior.Restrict);  

            modelBuilder.Entity<Usuario>()
            .HasDiscriminator<string>("TipoUsuario")
            .HasValue<UsuarioAdmin>("Admin")
            .HasValue<UsuarioAutorizado>("Autorizado");

            // Precarga para Amenazas
            modelBuilder.Entity<Amenaza>().HasData(
                new Amenaza { Id = 1, Descripcion = "Caza furtiva", GradoPeligrosidad = 8 },
                new Amenaza { Id = 2, Descripcion = "Deforestación", GradoPeligrosidad = 7 }
            );

            // Precarga para EstadosConservacion
            modelBuilder.Entity<EstadoConservacion>().HasData(
                new EstadoConservacion { Id = 1, Nombre = "En peligro", RangoSeguridadMinimo = 1, RangoSeguridadMaximo = 3 },
                new EstadoConservacion { Id = 2, Nombre = "Vulnerable", RangoSeguridadMinimo = 4, RangoSeguridadMaximo = 7 }
            );

            // Precarga para Paises
            modelBuilder.Entity<Pais>().HasData(
                new Pais { Id = 1, CodigoAlpha3 = "ARG", Nombre = "Argentina" },
                new Pais { Id = 2, CodigoAlpha3 = "BRA", Nombre = "Brasil" }
            );


            modelBuilder.Entity<UsuarioAdmin>().HasData(
        new UsuarioAdmin
        {
            Id = 1,
            Alias = "AdminUser",
            ContraseniaSinEncriptar = "UserPasswordPlainText",
            ContraseniaEncriptada = "SomeEncryptedPassword", // Usa una contraseña encriptada
            FechaIngreso = DateTime.Now
        }
    );

            // Precarga para UsuariosGeneral
            modelBuilder.Entity<UsuarioAutorizado>().HasData(
                new UsuarioAutorizado
                {
                    Id = 2,
                    Alias = "GeneralUser",
                    ContraseniaSinEncriptar = "UserPasswordPlainText",
                    ContraseniaEncriptada = "AnotherEncryptedPassword", // Usa una contraseña encriptada
                    FechaIngreso = DateTime.Now
                }
            );
            modelBuilder.Entity<ConfiguracionValidaciones>().HasData(
                new ConfiguracionValidaciones
                {
                    Id = 1,
                    TopeMaximoDescripcion = 500,
                    TopeMaximoNombre = 50,
                    TopeMinimoDescripcion = 50,
                    TopeMinimoNombre = 2
                }
            );
        }
    }
}
