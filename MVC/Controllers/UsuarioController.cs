using Dominio.InterfacesRepositorio;
using LogicaAccesoDatos.RepositoriosEntity;
using Microsoft.AspNetCore.Mvc;
using Usuarios.Entidades;
using Usuarios.InterfacesRepositorio;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MVC.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly RepositorioUsuario _repoUsuario;

        public UsuarioController(RepositorioUsuario repoUsuario)
        {
            _repoUsuario = repoUsuario;
        }

        public IActionResult Login()
        {
            int? lid = HttpContext.Session.GetInt32("LogueadoId");
            if(lid == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public IActionResult Login(string alias, string password)
        {
            try
            {
                Usuario logueado = _repoUsuario.Login(alias, password);
                if (logueado != null)
                {
                    HttpContext.Session.SetInt32("LogueadoId", logueado.Id);
                    HttpContext.Session.SetString("LogueadoAlias", logueado.Alias);
                    HttpContext.Session.SetString("LogueadoTipo", logueado.TipoUsuario);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.MensajeLogin = "Datos incorrectos";
                }


            }
            catch (Exception)
            {

                throw;
            }
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult CrearUsuarioAutorizado()
        {
            int? lid = HttpContext.Session.GetInt32("LogueadoId");
            if (lid == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public IActionResult CrearUsuarioAutorizado(string alias, string password)
        {
            try
            {
                if(_repoUsuario.AliasExiste(alias))
                {
                    ViewBag.Mensaje = "El alias ya existe";
                    return View();
                }
                else
                {
                    UsuarioAutorizado usuarioAutorizado = new UsuarioAutorizado(alias, password);
                    usuarioAutorizado.TipoUsuario = "Autorizado";
                    _repoUsuario.Add(usuarioAutorizado);
                    return RedirectToAction("Index", "Home");
                }

            }
            catch (Exception)
            {

                throw;
            }
        }



    }
}
