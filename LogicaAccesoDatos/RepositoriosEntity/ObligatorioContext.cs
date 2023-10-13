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
        public DbSet<Amenaza> Amenazas { get; set; }
        public DbSet<Especie> Especies { get; set; }
        public DbSet<EstadoConservacion> EstadosConservacion { get; set; }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<Ecosistema> Ecosistemas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string cadenaConexion = @"SERVER=(LocalDb)\MsSqlLocalDb;DATABASE=ObligatorioP3";
            optionsBuilder.UseSqlServer(cadenaConexion);
        }
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
        }

    }
}
