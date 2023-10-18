using Dominio.Entidades;

namespace MVC.Models
{
    public class ConsultarEspeciesModel
    {


        public int Id { get; set; }
        public string NombreCientifico { get; set; }
        public string NombreVulgar { get; set; }
        public string Descripcion { get; set; }
        public decimal RangoPesoKg { get; set; }
        public decimal RangoLongitudCm { get; set; }
        public string EstadoConservacion { get; set; }
        public string EspecieRutaImagen { get; set; }

        public List<string> AmenazasDesc { get; set;}

        public List<string> EcosistemasNombre { get; set; }
        public List<double> EcosistemasMetrosCuadrados { get; set; }
        public List<string> EcosistemasDescripcion { get; set; }
        public List<decimal> EcosistemaLatitud { get; set; }
        public List<decimal> EcosistemasLongitud { get; set; }
        public List<string> EcosistemasRutaImagenes { get; set; }

        public IEnumerable<Ecosistema> Ecosistemas { get; set; }
        public IEnumerable<Amenaza> Amenazas { get; set; }



        public ConsultarEspeciesModel(Especie especie)
        {
            Id = especie.Id;
            NombreCientifico = especie.Nombre.NombreCientifico;
            NombreVulgar = especie.Nombre.NombreVulgar;
            Descripcion = especie.Descripcion;
            RangoPesoKg = especie.AtributosFisicos.RangoPesoKg;
            RangoLongitudCm = especie.AtributosFisicos.RangoLongitudCm;
            EstadoConservacion = especie.EstadoConservacion.Nombre;
            EspecieRutaImagen = especie.Imagen.RutaImagen;


            Ecosistemas = especie.Ecosistemas;
            Amenazas = especie.Amenazas;

            /*AmenazasDesc = especie.Amenazas.Select(a => a.Descripcion).ToList();


            EcosistemasNombre = especie.Ecosistemas.Select(e => e.Nombre).ToList();
            EcosistemasMetrosCuadrados = especie.Ecosistemas.Select(e => e.AreaMetrosCuadrados).ToList();
            EcosistemasDescripcion = especie.Ecosistemas.Select(e => e.Descripcion).ToList();
            EcosistemaLatitud = especie.Ecosistemas.Select(e => e.Coordenadas.Latitud).ToList();
            EcosistemasLongitud = especie.Ecosistemas.Select(e => e.Coordenadas.Longitud).ToList();
            EcosistemasRutaImagenes = especie.Ecosistemas.Select(e => e.Imagen.RutaImagen).ToList();*/

        }
    } 
}
