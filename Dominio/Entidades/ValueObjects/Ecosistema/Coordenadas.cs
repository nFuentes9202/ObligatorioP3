using Dominio.ExcepcionesEntidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades.ValueObjects.Ecosistema
{
    [Owned]
    public class Coordenadas
    {
        public decimal Latitud { get;private set; }
        public decimal Longitud { get;private set; }
        public Coordenadas()
        {
            Validar();
        }
        public Coordenadas(decimal latitud, decimal longitud)
        {
            Latitud = latitud;
            Longitud = longitud;
            Validar();
        }

        private void Validar()
        {
            if(Latitud < -180)
            {
                throw new EcosistemaException("La latitud no puede ser menor a -180 grados");
            }
            if (Latitud > 180)
            {
                throw new EcosistemaException("La latitud no puede ser mayor a 180 grados");
            }
            if(Longitud < -90)
            {
                throw new EcosistemaException("La longitud no puede ser menor a -90 grados");
            }
            if (Longitud > 90)
            {
                throw new EcosistemaException("La longitud no puede ser mayor a 90 grados");
            }
        }
    }

}
