using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.InterfacesRepositorio
{
    public interface IRepositorioEcosistema:IRepositorio<Ecosistema>
    {
        public bool SePuedeBorrarEcosistema(int? id);
        public bool Delete(int? id);
    }
}
