using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesCasosUso.Ecosistemas
{
    // TODO Agregar items a interfaz
    public interface IGetEcosistemas
    {
        public IEnumerable<Ecosistema> GetAll();

        public IEnumerable<Ecosistema> Filtrar();
    }
}
