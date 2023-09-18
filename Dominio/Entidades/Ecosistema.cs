using Dominio.InterfacesEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Ecosistema: IEntity, IValidable
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public double AreaMetrosCuadrados { get; set; }
        public string Descripcion { get; set; }

        public void Validar()
        {
            throw new NotImplementedException();
        }
    }
}
