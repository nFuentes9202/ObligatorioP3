using Obligatorio.WebApi.DTOS.Especies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesCasosUso.Especies
{
    public interface IGetEspecieById
    {
        public EspecieListadoDTO GetEspecie(int? id);
    }
}
