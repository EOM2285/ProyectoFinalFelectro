using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PAWS_ProyectoFinal.Models;
using System.Diagnostics;

namespace PAWS_ProyectoFinal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
		private readonly PAWSContext _context;

		public HomeController(ILogger<HomeController> logger, PAWSContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            if ( HttpContext.Session.GetString("nombre") == null) 
            {
              return RedirectToAction("Index","InicioSesion");
            }
			var producto = _context.Producto.Include(p => p.Categoria);
			return View(await producto.ToListAsync());
		}

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}