using Dominio.Entidades;
using Dominio.Entidades.ValueObjects.Especie;

namespace MVC.Models
{
    public class EspecieModel
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public List<Amenaza> Amenazas { get; set; }
        public List<Ecosistema> Ecosistemas { get; set; }
        public decimal RangoPesoKg { get; set; }
        public decimal RangoLongitudCm { get; set; }
        public string DescripcionImagen { get; set; }
        public string NombreImagen { get; set; }
        public string RutaImagen { get; set; }
        public string NombreCientifico { get; set; }
        public string NombreVulgar { get; set; }
        public EstadoConservacion EstadoConservacion { get; set; }
        public int EstadoConservacionId { get; set; }


        public EspecieModel(Especie especie)
        {
            Id = especie.Id;
            Descripcion = especie.Descripcion;
            Amenazas = especie.Amenazas;
            Ecosistemas = especie.Ecosistemas;
            RangoPesoKg = especie.AtributosFisicos.RangoPesoKg;
            RangoLongitudCm = especie.AtributosFisicos.RangoLongitudCm;
            DescripcionImagen = especie.Imagen.Descripcion;
            NombreImagen = especie.Imagen.Nombre;
            RutaImagen = especie.Imagen.RutaImagen;
            NombreCientifico = especie.Nombre.NombreCientifico;
            NombreVulgar = especie.Nombre.NombreVulgar;
            EstadoConservacion = especie.EstadoConservacion;
            EstadoConservacionId = especie.EstadoConservacionId;
        }
    }
}

