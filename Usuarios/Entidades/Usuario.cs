using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using Usuarios.ExcepcionesUsuarios;
using Usuarios.InterfacesEntidades;

namespace Usuarios.Entidades
{
    public abstract class Usuario: IValidable<Usuario>
    {
        #region Atributos
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El alias no puede ser vacío")]
        [MinLength(6, ErrorMessage = "El nombre debe tener 6 caracteres como mínimo")]
        public string Alias { get; set; }//debe ser unico
        public string ContraseniaEncriptada { get; private set; }
        [Required(ErrorMessage = "La contraseña no puede ser vacía")]
        [MinLength(8, ErrorMessage = "La contraseña debe tener 8 caracteres como mínimo")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[.,;:#\!]).+$", ErrorMessage = "La contraseña debe incluir al menos una mayúscula, una minúscula, un dígito y un carácter de puntuación (. , ; : # !)")]
        public string ContraseniaSinEncriptar { get; set; }
        public DateTime FechaIngreso { get; set; }

        #endregion
        public Usuario(string alias, string contraseniasinencriptar)
        {
            Alias = alias;
            ContraseniaSinEncriptar = contraseniasinencriptar;
            ContraseniaEncriptada = EncriptarContraseña(contraseniasinencriptar);
            FechaIngreso = DateTime.Now;
        }

        public abstract string EncriptarContraseña(string contraseniasinencriptar);//hay que ver como encriptamos


        #region Validaciones
        public void Validar()
        {
            if(string.IsNullOrEmpty(this.Alias) || this.Alias.Length<6)
                throw new UsuarioException("El alias no puede ser nulo o vacio");
            if (this.Alias.Length < 6)
                throw new UsuarioException("El alias debe tener 6 caracteres como mínimo");
            if(string.IsNullOrEmpty(ContraseniaSinEncriptar))
                throw new UsuarioException("La contraseña sin encriptar no puede ser nula o vacia");
            if (ValidarContraseña(this.ContraseniaSinEncriptar) == false)
                throw new UsuarioException("La contraseña debe incluir al menos una mayúscula, una minúscula, un dígito y un carácter de puntuación (. , ; : # !)");
            
        }
        private bool ValidarContraseña(string contraseña)
        {
            // Verifica que la contraseña cumpla con los requisitos
            if (contraseña.Length < 8)
            {
                return false;
            }

            if (!contraseña.Any(char.IsUpper) || // Al menos una mayúscula
                !contraseña.Any(char.IsLower) || // Al menos una minúscula
                !contraseña.Any(char.IsDigit) || // Al menos un dígito
                !Regex.IsMatch(contraseña, @"[.,;:#\!]")) // Al menos un carácter de puntuación
            {
                return false;
            }

            return true;
        }

        /*public bool AliasExiste(string alias) //ver despues como implementar
        {
            // Consultar la base de datos para verificar si el alias existe
            //return _dbContext.Usuarios.Any(u => u.Alias == alias);
        }*/
        #endregion
    }
}