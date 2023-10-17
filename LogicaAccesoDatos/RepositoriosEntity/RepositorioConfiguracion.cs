using Dominio.Entidades;
using Dominio.ExcepcionesEntidades;
using Dominio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.RepositoriosEntity
{
    public class RepositorioConfiguracion : IRepositorioConfiguracion
    {
        private ObligatorioContext _db;
        public RepositorioConfiguracion(ObligatorioContext db)
        {
            _db = db;
        }
        public void Add(ConfiguracionValidaciones obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(ConfiguracionValidaciones obj)
        {
            throw new NotImplementedException();
        }

        public ConfiguracionValidaciones FindById(int? id)
        {
            throw new NotImplementedException();
        }

        public ConfiguracionValidaciones Get()
        {
            try
            {
                return _db.Configuraciones.FirstOrDefault();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<ConfiguracionValidaciones> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(ConfiguracionValidaciones obj)
        {
            try
            {
                var configExistente = _db.Configuraciones.FirstOrDefault();
                if (configExistente == null)
                {
                    throw new ConfiguracionException("No existe dicha configuración");
                }
                configExistente.ActualizarTopeMinimoDescripcion(obj.TopeMinimoDescripcion, configExistente.TopeMinimoDescripcion);
                configExistente.ActualizarTopeMinimoNombre(obj.TopeMinimoNombre, configExistente.TopeMinimoNombre);
                configExistente.ActualizarTopeMaximoDescripcion(obj.TopeMaximoDescripcion, configExistente.TopeMaximoDescripcion);
                configExistente.ActualizarTopeMaximoNombre(obj.TopeMaximoNombre, configExistente.TopeMaximoNombre);

                _db.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
