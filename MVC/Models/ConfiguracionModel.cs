namespace MVC.Models
{
    public class ConfiguracionModel
    {
        public int Id { get; set; }
        public int TopeMinimoDescripcion { get; set; }
        public int TopeMaximoDescripcion { get; set; }
        public int TopeMinimoNombre { get; set; }
        public int TopeMaximoNombre { get; set; }

        public ConfiguracionModel()
        {
        }
    }
}
