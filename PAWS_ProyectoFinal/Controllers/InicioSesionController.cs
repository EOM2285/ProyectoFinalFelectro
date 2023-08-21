using Microsoft.AspNetCore.Mvc;
using PAWS_ProyectoFinal.Models;

namespace PAWS_ProyectoFinal.Controllers
{
    public class InicioSesionController : Controller
    {


        private readonly PAWSContext _context;

        public InicioSesionController(PAWSContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            HttpContext.Session.Remove("nombre");
            HttpContext.Session.Remove("apellido");
            HttpContext.Session.Remove("correo");
            HttpContext.Session.Remove("Roll");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index([Bind("Correo,Contrasena")] Usuario usuario)
        {
            if (usuario.Contrasena != null && usuario.Correo != null)
            {
                var login = _context.Usuario.Where(x => x.Contrasena == usuario.Contrasena && x.Correo == usuario.Correo).FirstOrDefault();
                if (login == null)
                {
                    return View(usuario);
                }
                HttpContext.Session.SetString("nombre", login.Nombre);
                HttpContext.Session.SetString("apellido", login.Apellidos);
                HttpContext.Session.SetString("correo", login.Correo);
                HttpContext.Session.SetString("Roll", login.RollId.ToString());


                //HttpContext.Session.Remove("correo");


                /*  NO BORRAR
                // Verifica el rol del usuario
                if (login.Id_rol == 1) // Rol 1 - Admin
                {
                    return RedirectToAction("Index", "Home");
                }
                else if (login.Id_rol == 2) // Rol 2 - Usuario normal
                {
                    return RedirectToAction("Index", "Home");
                }
            }
               */




                return RedirectToAction("Index", "Home");
            }

               return View(usuario);

        }
    }


}
