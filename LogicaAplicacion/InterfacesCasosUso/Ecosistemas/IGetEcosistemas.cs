using Dominio.Entidades;
using Obligatorio.WebApi.DTOS.Ecosistemas;
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
        public IEnumerable<EcosistemaListadoDTO> GetEcosistemasDTO();

        public IEnumerable<EcosistemaListadoDTO> Filtrar();
    }
}
