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
        public int RangoSeguridadMinimo { get; set; }
        public int RangoSeguridadMaximo { get; set; }

        public void Validar()
        {
            if(RangoSeguridadMinimo < 0 || RangoSeguridadMinimo > 100)
            {
                throw new EstadoConservacionException("El Rango de seguridad mínimo debe estar entre 0 y 100");
            }
            if (RangoSeguridadMinimo <= 0)
            {
                throw new EstadoConservacionException("El rango de seguridad mínimo debe ser mayor a 0");
            }
            if (String.IsNullOrEmpty(Nombre))
            {
                throw new EstadoConservacionException("El nombre no puede ser vacío");
            }
            if (RangoSeguridadMaximo < 0 || RangoSeguridadMaximo > 100)
            {
                throw new EstadoConservacionException("El Rango de seguridad máximo debe estar entre 0 y 100");
            }
            if (RangoSeguridadMaximo <= 0)
            {
                throw new EstadoConservacionException("El rango de seguridad máximo debe ser mayor a 0");
            }

        }
    }
}
