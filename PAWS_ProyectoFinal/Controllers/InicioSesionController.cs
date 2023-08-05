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

                //HttpContext.Session.Remove("correo");

                return RedirectToAction("Index", "Home");
            }

               return View(usuario);

        }
    }


}
