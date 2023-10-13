using Dominio.Entidades;

namespace MVC.Models.Conversiones
{
    public class ConversionesEcosistema
    {
        internal static Models.EcosistemaModel EcosistemaToEcosistemaModel(Ecosistema ecosis)
        {
            return new Models.EcosistemaModel(ecosis);
        }
    }
}
