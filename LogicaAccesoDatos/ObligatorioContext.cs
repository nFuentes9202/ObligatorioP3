using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos
{
    public class ObligatorioContext:DbContext
    {
        public DbSet<Ecosistema> Ecosistemas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string cadenaConexion = @"SERVER=(LocalDb)\MsSqlLocalDb;DATABASE=";
            optionsBuilder.UseSqlServer(cadenaConexion);
        }
1        
    }
}
