using Dominio.Entidades.ValueObjects.Ecosistema;
using Dominio.InterfacesEntidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Ecosistema: IEntity, IValidable<Ecosistema>
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public double AreaMetrosCuadrados { get; set; }
        public string Descripcion { get; set; }
        public List<Especie> Especies { get; set; }
        public List<Pais> Paises { get; set; }
        public List<Amenaza> Amenazas { get; set; }
        public Coordenadas Coordenadas { get; set; }   
        public Imagen Imagen { get; set; }
        public void Validar()
        {
            throw new NotImplementedException();
        }
    }
}
