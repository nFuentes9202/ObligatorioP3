using Dominio.Entidades.ValueObjects.Ecosistema;
using Dominio.ExcepcionesEntidades;
using Dominio.InterfacesEntidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    [Index(nameof(Nombre), IsUnique = true)]
    public class Ecosistema: IEntity, IValidable<Ecosistema>
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public double AreaMetrosCuadrados { get; set; }
        public string Descripcion { get; set; }
        public List<Especie> Especies { get; set; }
        public List<Pais> Paises { get; set; }
        public List<Amenaza> Amenazas { get; set; }
        public Coordenadas Coordenadas { get; set; }   
        public Imagen Imagen { get; set; }
        public EstadoConservacion EstadoConservacion { get; set; }
        public int EstadoConservacionId { get; set; }
        public void Validar()
        {
            if (String.IsNullOrEmpty(Nombre))
            {
                throw new EcosistemaException("El nombre no puede ser vacío");
            }
            if(AreaMetrosCuadrados <= 0)
            {
                throw new EcosistemaException("El area en metros cuadrados debe ser mayor a 0");
            }
            if (String.IsNullOrEmpty(Descripcion))
            {
                throw new EcosistemaException("La descripción no puede ser vacía");
            }
        }
    }
}
