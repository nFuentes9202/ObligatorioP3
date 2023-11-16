using Obligatorio.WebApi.DTOS.Ecosistemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesCasosUso.Ecosistemas
{
    public interface IGetEcosistemaById
    {
        public EcosistemaListadoDTO GetEcosistema(int? id);
    }
}
