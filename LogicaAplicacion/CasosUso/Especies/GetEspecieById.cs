using Dominio.Entidades;
using Dominio.ExcepcionesEntidades;
using Dominio.InterfacesRepositorio;
using LogicaAplicacion.InterfacesCasosUso.Especies;
using Obligatorio.WebApi.DTOS.Especies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.Especies
{
    public class GetEspecieById : IGetEspecieById
    {
        private IRepositorioEspecie _repoEspecie;

        public GetEspecieById(IRepositorioEspecie repoEspecie)
        {
            _repoEspecie = repoEspecie;
        }

        public EspecieListadoDTO GetEspecie(int? id)
        {
            if(id == null)
            {
                throw new EspecieException("Ingrese el id de la especie a buscar");
            }
            Especie especie = _repoEspecie.FindById(id.Value);
            EspecieListadoDTO especieDTO = especie != null ? MapeoEspecie.EspecieToEspecieDTO(especie) : null;
            return especieDTO;
        }
    }
}
