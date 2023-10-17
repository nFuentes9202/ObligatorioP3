using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using Usuarios.ExcepcionesUsuarios;
using Usuarios.InterfacesEntidades;



namespace Usuarios.Entidades
{
    public abstract class Usuario : IValidable<Usuario>
    {
        #region Atributos
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El alias no puede ser vacío")]
        [MinLength(6, ErrorMessage = "El nombre debe tener 6 caracteres como mínimo")]
        public string Alias { get; set; }//debe ser unico
        [Required(ErrorMessage = "La contraseña no puede ser vacía")]
        [MinLength(8, ErrorMessage = "La contraseña debe tener 8 caracteres como mínimo")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[.,;:#\!]).+$", ErrorMessage = "La contraseña debe incluir al menos una mayúscula, una minúscula, un dígito y un carácter de puntuación (. , ; : # !)")]
        public string ContraseniaSinEncriptar { get; set; }
        public string? ContraseniaEncriptada { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string TipoUsuario { get; set; }

        #endregion
        protected Usuario() { }

        public Usuario(string alias, string contraseniasinencriptar)
        {
            Alias = alias;
            ContraseniaSinEncriptar = contraseniasinencriptar;
            ContraseniaEncriptada = EncriptarContraseña(contraseniasinencriptar);
            FechaIngreso = DateTime.Now;
        }

        private static string EncriptarContraseña(string contraseniasinencriptar)
        {
            byte[] salt = GenerateSalt();//genera un salt
            string passencriptada = Encriptar(contraseniasinencriptar, salt);//encripta la contraseña
            return passencriptada;//devuelve la contraseña encriptada

        }

        private static byte[] GenerateSalt()
        {
            byte[] salt = new byte[32];//crea un array de 32 bytes
            Random random = new Random();
            random.NextBytes(salt);//rellena el array con bytes aleatorios
            return salt;//devuelve el array salt
        }

        private static string Encriptar(string contraseniasinencriptar, byte[] salt)
        {
            using (var sha256 = new SHA256Managed())//crea un objeto sha256 para encriptar la contraseña
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(contraseniasinencriptar);//convierte la contraseña en un array de bytes
                //Concatena el salt y la contraseña
                byte[] passwordSalt = new byte[passwordBytes.Length + salt.Length];//crea un array de bytes con la longitud de la contraseña y el salt
                salt.CopyTo(passwordSalt, 0);//copia el salt en el array
                passwordBytes.CopyTo(passwordSalt, salt.Length);//copia la contraseña en el array

                byte[] hash = sha256.ComputeHash(passwordSalt);//encripta la contraseña
                return Convert.ToBase64String(hash);//convierte el hash en un string y lo devuelve
            }
        }

        #region Validaciones
        public void Validar()
        {
            if (string.IsNullOrEmpty(this.Alias) || this.Alias.Length < 6)
                throw new UsuarioException("El alias no puede ser nulo o vacio");
            if (this.Alias.Length < 6)
                throw new UsuarioException("El alias debe tener 6 caracteres como mínimo");
            if (string.IsNullOrEmpty(ContraseniaSinEncriptar))
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


        #endregion
    }
}