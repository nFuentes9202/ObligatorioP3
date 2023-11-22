using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidades;

namespace Obligatorio.WebApi.DTOS.Especies
{
    public class EspecieListadoDTO
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public List<Amenaza> Amenazas { get; set; }
        public List<Ecosistema> Ecosistemas { get; set; }
        public string NombreCientifico { get; set; }
        public string NombreVulgar { get; set; }
        public decimal Peso { get; set; }
        public decimal Longitud { get; set; }
        public string DescripcionImagen { get; set; }
        public string NombreImagen { get; set; }
        public string? ImagenRuta { get; set; }
        public EstadoConservacion EstadoConservacion { get; set; }
        public int EstadoConservacionId { get; set; }

        public EspecieListadoDTO(Especie especie)
        {
            Id = especie.Id;
            Descripcion = especie.Descripcion;
            Amenazas = especie.Amenazas;
            Ecosistemas = especie.Ecosistemas;
            NombreCientifico = especie.Nombre.NombreCientifico;
            NombreVulgar = especie.Nombre.NombreVulgar;
            Peso = especie.AtributosFisicos.RangoPesoKg;
            Longitud = especie.AtributosFisicos.RangoLongitudCm;
            DescripcionImagen = especie.Imagen.Descripcion;
            NombreImagen = especie.Imagen.Nombre;
            ImagenRuta = especie.Imagen.RutaImagen;
            EstadoConservacion = especie.EstadoConservacion;
            EstadoConservacionId = especie.EstadoConservacionId;
        }
    }
}
