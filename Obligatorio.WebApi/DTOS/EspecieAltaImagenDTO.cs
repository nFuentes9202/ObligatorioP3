﻿namespace Obligatorio.WebApi.DTOS
{
    public class EspecieAltaImagenDTO
    {
        public int Id { get; set; }
        public string? Descripcion { get; set; }
        public string? NombreCientifico { get; set; }
        public string? NombreVulgar { get; set; }
        public decimal RangoPesoKg { get; set; }
        public decimal RangoLongitudCm { get; set; }
        public string? ImagenRuta { get; set; }
        public IFormFile Imagen { get; set; }

        public string? DescripcionImagen { get; set; }
        public int EstadoConservacionId { get; set; }
        public IEnumerable<int> AmenazasSeleccionadasIds { get; set; }
        public IEnumerable<int> EcosistemasSeleccionadosIds { get; set; }
    }
}
