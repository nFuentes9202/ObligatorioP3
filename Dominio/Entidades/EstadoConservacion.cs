using Dominio.InterfacesEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class EstadoConservacion: IEntity, IValidable<EstadoConservacion>
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int RangoSeguridad { get; set; }

        public void Validar()
        {
            throw new NotImplementedException();
        }
    }
}
