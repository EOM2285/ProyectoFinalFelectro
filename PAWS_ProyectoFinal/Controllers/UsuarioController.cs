using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PAWS_ProyectoFinal.Models;

namespace PAWS_ProyectoFinal.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly PAWSContext _context;

        public UsuarioController(PAWSContext context)
        {
            _context = context;
        }

        // GET: Usuario
        public async Task<IActionResult> Index()
        {

            if (HttpContext.Session.GetString("nombre") == null)
            {
                return RedirectToAction("Index", "InicioSesion");
            }

            var pAWSContext = _context.Usuario.Include(p => p.Roll).Where(x=> x.RollId == 2);
            return View(await pAWSContext.ToListAsync());
           

        }

        // GET: Usuario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (HttpContext.Session.GetString("nombre") == null)
            {
                return RedirectToAction("Index", "InicioSesion");
            }

            if (id == null || _context.Usuario == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario.Include(x=>x.Roll).FirstOrDefaultAsync(m => m.Id == id);

            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Apellidos,Correo,Contrasena,Telefono,UltimaConexion,EstadoUsuario")] Usuario usuario)
        {
          

            if (ModelState.IsValid)
            {
                usuario.RollId = 1;
                usuario.EstadoUsuario = true;
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index","InicioSesion");
            }
            return View(usuario);
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------------

        [HttpGet]
        public IActionResult CreateAdmin()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAdmin([Bind("Id,Nombre,Apellidos,Correo,Contrasena,Telefono,UltimaConexion,EstadoUsuario")] Usuario usuario)
        {


            if (ModelState.IsValid)
            {
                usuario.RollId = 2;
                usuario.EstadoUsuario = true;
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(usuario);
        }


        //---------------------------------------------------------------------------------------------------------------------------------------------------


        public async Task<IActionResult> Edit(int? id)
        {
            if (HttpContext.Session.GetString("nombre") == null)
            {
                return RedirectToAction("Index", "InicioSesion");
            }


            if (id == null || _context.Usuario == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Apellidos,Correo,Contrasena,Telefono,UltimaConexion,EstadoUsuario, RollId")] Usuario usuario)
        {
            if (HttpContext.Session.GetString("nombre") == null)
            {
                return RedirectToAction("Index", "InicioSesion");
            }

            if (id != usuario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }

        // GET: Usuario/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (HttpContext.Session.GetString("nombre") == null)
            {
                return RedirectToAction("Index", "InicioSesion");
            }

            if (id == null || _context.Usuario == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario.Include(x=>x.Roll).FirstOrDefaultAsync(m => m.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Usuario == null)
            {
                return Problem("Entity set 'PAWSContext.Usuario'  is null.");
            }
            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuario.Remove(usuario);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioExists(int id)
        {
          return (_context.Usuario?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
