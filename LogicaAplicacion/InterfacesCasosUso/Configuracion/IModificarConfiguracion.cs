using LogicaAplicacion.CasosUso.DTOS.Configuracion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesCasosUso.Configuracion
{
    // TODO Agregar items a interfaz
    public interface IModificarConfiguracion
    {
        public void Modificar(ConfiguracionDTO configuracionDTO);
    }
}
