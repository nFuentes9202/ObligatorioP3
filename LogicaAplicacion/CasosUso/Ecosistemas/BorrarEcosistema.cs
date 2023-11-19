using Dominio.ExcepcionesEntidades;
using Dominio.InterfacesRepositorio;
using LogicaAplicacion.InterfacesCasosUso.Ecosistemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.Ecosistemas
{
    public class BorrarEcosistema : IBorrarEcosistema
    {
        private readonly IRepositorioEcosistema _repoEco;
        public BorrarEcosistema(IRepositorioEcosistema repoEco)
        {
            _repoEco = repoEco;
        }

        public void Eliminar(int? id)
        {
            if(id == null)
            {
                throw new EcosistemaException("No se puede dar de baja el ecosistema");
            }

            if (_repoEco.SePuedeBorrarEcosistema(id))
            {
                _repoEco.Delete(id);
            }
            else
            {
                throw new EcosistemaException("No se pudo eliminar, tiene especies");
            }

        }
    }
}
