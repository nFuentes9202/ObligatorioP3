using Dominio.Entidades.ValueObjects.Especie;
using Dominio.ExcepcionesEntidades;
using Dominio.InterfacesEntidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Especie: IEntity, IValidable<Especie>
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public List<Amenaza> Amenazas { get; set; }
        public List<Ecosistema> Ecosistemas { get; set; }
        public AtributosFisicos AtributosFisicos { get; set; }
        public Imagen Imagen { get; set; }
        public Nombre Nombre { get; set; }
        public EstadoConservacion EstadoConservacion { get; set; }
        public int EstadoConservacionId { get; set; }
        public void Validar()
        {
            if (String.IsNullOrEmpty(Descripcion))
            {
                throw new EspecieException("La descripción no puede ser vacía");
            }
        }
    }
}
