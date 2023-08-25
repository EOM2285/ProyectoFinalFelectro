using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PAWS_ProyectoFinal.Models;

namespace PAWS_ProyectoFinal.Controllers
{
    public class VentaController : Controller
    {
        private readonly PAWSContext _context;

        public VentaController(PAWSContext context)
        {
            _context = context;
        }

       
        public async Task<IActionResult> FactPendiente()
        {
            if (HttpContext.Session.GetString("nombre") == null)
            {
                return RedirectToAction("Index", "InicioSesion");
            }
            var factura = _context.Venta.Where(v => v.StatusPedido =="Pendiente");
            return View(await factura.ToListAsync());
            
        }

        public async Task<IActionResult> FactProceso()
        {
            if (HttpContext.Session.GetString("nombre") == null)
            {
                return RedirectToAction("Index", "InicioSesion");
            }
            var factura = _context.Venta.Where(v => v.StatusPedido == "En Proceso");
            return View(await factura.ToListAsync());

        }

        public async Task<IActionResult> FactParaEntrega()
        {
            if (HttpContext.Session.GetString("nombre") == null)
            {
                return RedirectToAction("Index", "InicioSesion");
            }
            var factura = _context.Venta.Where(v => v.StatusPedido == "Para Entrega");
            return View(await factura.ToListAsync());

        }

        public async Task<IActionResult> FactEntregada()
        {
            if (HttpContext.Session.GetString("nombre") == null)
            {
                return RedirectToAction("Index", "InicioSesion");
            }
            var factura = _context.Venta.Where(v => v.StatusPedido == "Entregada");
            return View(await factura.ToListAsync());

        }

        public async Task<IActionResult> Details(int? id)
        {
            if (HttpContext.Session.GetString("nombre") == null)
            {
                return RedirectToAction("Index", "InicioSesion");
            }
            if (id == null || _context.Venta == null)
            {
                return NotFound();
            }

            var venta = await _context.Venta.Include(v=>v.DetalleVentas)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (venta == null)
            {
                return NotFound();
            }

            return View(venta);
        }

       
        public async Task<IActionResult> Asignar(int? id)
        {
            if (HttpContext.Session.GetString("nombre") == null)
            {
                return RedirectToAction("Index", "InicioSesion");
            }

            if (id == null || _context.Venta == null)
            {
                return NotFound();
            }
            var venta = await _context.Venta.FindAsync(id);
            if (venta == null)
            {
                return NotFound();
            }
            try
            {
                venta.StatusPedido = "En Proceso";
                _context.Update(venta);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VentaExists(venta.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction("FactProceso");
        }

        public async Task<IActionResult> Terminar(int? id)
        {
            if (HttpContext.Session.GetString("nombre") == null)
            {
                return RedirectToAction("Index", "InicioSesion");
            }

            if (id == null || _context.Venta == null)
            {
                return NotFound();
            }
            var venta = await _context.Venta.FindAsync(id);
            if (venta == null)
            {
                return NotFound();
            }
            try
            {
                venta.StatusPedido = "Para Entrega";
                _context.Update(venta);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VentaExists(venta.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction("FactParaEntrega");
        }


        public async Task<IActionResult> Entrega(int? id)
        {
            if (HttpContext.Session.GetString("nombre") == null)
            {
                return RedirectToAction("Index", "InicioSesion");
            }

            if (id == null || _context.Venta == null)
            {
                return NotFound();
            }
            var venta = await _context.Venta.FindAsync(id);
            if (venta == null)
            {
                return NotFound();
            }
            try
            {
                venta.StatusPedido = "Entregada";
                _context.Update(venta);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VentaExists(venta.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction("FactEntregada");
        }

        private bool VentaExists(int id)
        {
          return (_context.Venta?.Any(e => e.Id == id)).GetValueOrDefault();
        }
   
    }
}
