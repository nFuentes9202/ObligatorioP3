using Dominio.Entidades;
using Dominio.InterfacesRepositorio;
using LogicaAplicacion.InterfacesCasosUso.Ecosistemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.Ecosistemas
{
    public class GetEcosistemas : IGetEcosistemas
    {
        private readonly IRepositorioEcosistema _eco;
        public GetEcosistemas(IRepositorioEcosistema eco) {
            _eco = eco;
        }
        public IEnumerable<Ecosistema> GetAll()
        {
            return _eco.GetAll();
        }

        public IEnumerable<Ecosistema> Filtrar()
        {
            throw new NotImplementedException();
        }
    }
}
