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
        void Update(int id, string ruta);

        public IEnumerable<Ecosistema> ObtenerEcosistemasSegunId(IEnumerable<int> ids);
    }
}
