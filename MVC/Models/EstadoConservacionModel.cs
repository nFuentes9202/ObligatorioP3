namespace MVC.Models
{
    public class EstadoConservacionModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int RangoSeguridadMinimo { get; set; }
        public int RangoSeguridadMaximo { get; set; }
    }
}
