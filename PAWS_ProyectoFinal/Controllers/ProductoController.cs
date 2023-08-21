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
    public class ProductoController : Controller
    {
        private readonly PAWSContext _context;

        public ProductoController(PAWSContext context)
        {
            _context = context;
        }

     
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("nombre") == null)
            {
                return RedirectToAction("Index", "InicioSesion");
            }

            var pAWSContext = _context.Producto.Include(p => p.Categoria);
            return View(await pAWSContext.ToListAsync());
        }

 
        public async Task<IActionResult> Details(int? id)
        {

            if (HttpContext.Session.GetString("nombre") == null)
            {
                return RedirectToAction("Index", "InicioSesion");
            }

            if (id == null || _context.Producto == null)
            {
                return NotFound();
            }

            var producto = await _context.Producto
                .Include(p => p.Categoria)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

    
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("nombre") == null)
            {
                return RedirectToAction("Index", "InicioSesion");
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categoria, "Id", "NombreCategoria");
            return View();
        }

    
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CategoriaId,NombreProducto,DescripcionProducto,PrecioProducto,EstadoProducto,File")] Producto producto, IFormFile file)
        {
            if (HttpContext.Session.GetString("nombre") == null)
            {
                return RedirectToAction("Index", "InicioSesion");
            }

            if (ModelState.IsValid)
            {

                //-------------------------------------------------------------
                byte[] bytes;
                if (producto.File != null)
                {
                    using (Stream fs = producto.File.OpenReadStream())
                    {
                        using (BinaryReader br = new(fs))
                        {
                            bytes = br.ReadBytes((int)fs.Length);
                            producto.ImagenProducto = Convert.ToBase64String(bytes, 0, bytes.Length);
                        }
                    }
                    _context.Add(producto);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");

                }
                //-------------------------------------------------------------

                ViewData["CategoriaId"] = new SelectList(_context.Categoria, "Id", "NombreCategoria", producto.CategoriaId);
                return View(producto);
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categoria, "Id", "NombreCategoria", producto.CategoriaId);
            return View(producto);
        }

     
        public async Task<IActionResult> Edit(int? id)
        {
            if (HttpContext.Session.GetString("nombre") == null)
            {
                return RedirectToAction("Index", "InicioSesion");
            }

            if (id == null || _context.Producto == null)
            {
                return NotFound();
            }

            var producto = await _context.Producto.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categoria, "Id", "NombreCategoria");
            return View(producto);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CategoriaId,NombreProducto,DescripcionProducto,PrecioProducto,EstadoProducto, File")] Producto producto, IFormFile file)
        {

            if (HttpContext.Session.GetString("nombre") == null)
            {
                return RedirectToAction("Index", "InicioSesion");
            }

            if (id != producto.Id)
            {
                return NotFound();
            }


            try
            {
                if (ModelState.IsValid)
                {
                    byte[] bytes;
                    if (producto.File != null)
                    {
                        using (Stream fs = producto.File.OpenReadStream())
                        {
                            using (BinaryReader br = new(fs))
                            {
                                bytes = br.ReadBytes((int)fs.Length);
                                producto.ImagenProducto = Convert.ToBase64String(bytes, 0, bytes.Length);
                            }
                        }

                        _context.Update(producto);
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                    ViewData["CategoriaId"] = new SelectList(_context.Categoria, "Id", "NombreCategoria", producto.CategoriaId);
                    return View(producto);
                }
                ViewData["CategoriaId"] = new SelectList(_context.Categoria, "Id", "NombreCategoria", producto.CategoriaId);
                return View(producto);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductoExists(producto.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

        }



     
        public async Task<IActionResult> Delete(int? id)
        {

            if (HttpContext.Session.GetString("nombre") == null)
            {
                return RedirectToAction("Index", "InicioSesion");
            }

            if (id == null || _context.Producto == null)
            {
                return NotFound();
            }

            var producto = await _context.Producto
                .Include(p => p.Categoria)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

    
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Producto == null)
            {
                return Problem("Entity set 'PAWSContext.Producto'  is null.");
            }
            var producto = await _context.Producto.FindAsync(id);
            if (producto != null)
            {
                _context.Producto.Remove(producto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductoExists(int id)
        {
            return (_context.Producto?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
