using Dominio.ExcepcionesEntidades;
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
            if(RangoSeguridad < 0 || RangoSeguridad > 100)
            {
                throw new EstadoConservacionException("El Rango de seguridad debe estar entre 0 y 100");
            }
            throw new NotImplementedException();
        }
    }
}
