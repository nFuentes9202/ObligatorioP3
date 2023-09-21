using Dominio.ExcepcionesEntidades;
using Dominio.InterfacesEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Pais: IEntity, IValidable<Pais>
    {
        public int Id { get; set; }
        public string CodigoAlpha3 { get; set; }
        public string Nombre { get; set; }
        public List<Ecosistema> Ecosistemas { get; set; }

        public void Validar()
        {
            if(CodigoAlpha3.Length > 3)
            {
                throw new PaisException("El código alpha es de 3 caracteres");
            }
            if(String.IsNullOrEmpty(CodigoAlpha3))
            {
                throw new PaisException("El código alpha no puede ser vacío");
            }
            if (String.IsNullOrEmpty(Nombre))
            {
                throw new PaisException("El nombre no puede ser vacío");
            }
        }
        
    }
}
