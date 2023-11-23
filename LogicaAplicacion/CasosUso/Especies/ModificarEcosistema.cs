using Dominio.InterfacesRepositorio;
using LogicaAplicacion.InterfacesCasosUso.Ecosistemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.Especies
{
    public class ModificarEcosistema : IModificarEcosistema
    {
        private IRepositorioEcosistema _repo;
        public ModificarEcosistema(IRepositorioEcosistema repo)
        {
            _repo = repo;
        }
        public bool ModificarRutaEcosistema(int id, string ruta)
        {
            _repo.Update(id, ruta);
            return true;
        }
    }
}
