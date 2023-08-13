using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using PAWS_ProyectoFinal.Infrastructure.TagHelpers;
using PAWS_ProyectoFinal.Models;
using PAWS_ProyectoFinal.Models.ViewModels;

namespace PAWS_ProyectoFinal.Controllers
{
	public class CarritoController : Controller
	{
		private readonly PAWSContext _context;

		public CarritoController(PAWSContext context)
		{
			_context = context;
		}
		public IActionResult Index()
		{
			List<ItemCarrito> carrito = HttpContext.Session.GetJson<List<ItemCarrito>>("Carrito") ?? new List<ItemCarrito>();

			CarritoCompras carritoC = new()
			{
				ItemCarrito = carrito,
				TotalFinal = carrito.Sum(x => x.Cantidad * x.Precio)
			};

			return View(carritoC);
		}
		public async Task<IActionResult> Agregar(int Id)
		{
			Producto producto = await _context.Producto.FindAsync(Id);

			List<ItemCarrito> carrito = HttpContext.Session.GetJson<List<ItemCarrito>>("Carrito") ?? new List<ItemCarrito>();

			ItemCarrito itemCarrito = carrito.Where(c => c.ProductoId == Id).FirstOrDefault();

			if (itemCarrito == null)
			{
				carrito.Add(new ItemCarrito(producto));
			}
			else
			{
				itemCarrito.Cantidad += 1;
			}

			HttpContext.Session.SetJson("Carrito", carrito);

			TempData["Success"] = "El producto fue añadido!";

			return Redirect(Request.Headers["Referer"].ToString());

		}
		public async Task<IActionResult> Disminuir(int Id)
		{
			List<ItemCarrito> carrito = HttpContext.Session.GetJson<List<ItemCarrito>>("Carrito");
			
			ItemCarrito itemCarrito = carrito.Where(c => c.ProductoId == Id).FirstOrDefault();

			if (itemCarrito.Cantidad > 1)
			{
				--itemCarrito.Cantidad;
			}
			else
			{
				carrito.RemoveAll(p => p.ProductoId == Id);
			}

			if (carrito.Count == 0)
			{
				HttpContext.Session.Remove("Carrito");
			}
			else
			{
				HttpContext.Session.SetJson("Carrito", carrito);
			}

			TempData["Success"] = "El producto fue eliminado!";

			return RedirectToAction("Index");
		}
		public async Task<IActionResult> Remover(int Id)
		{
			List<ItemCarrito> carrito = HttpContext.Session.GetJson<List<ItemCarrito>>("Carrito");
			
			carrito.RemoveAll(p => p.ProductoId == Id);

			if (carrito.Count == 0)
			{
				HttpContext.Session.Remove("Carrito");
			}
			else
			{
				HttpContext.Session.SetJson("Carrito", carrito);
			}

			TempData["Success"] = "El producto fue eliminado!";

			return RedirectToAction("Index");
		}
		public IActionResult Eliminar()
		{
			HttpContext.Session.Remove("Carrito");

			return RedirectToAction("Index");
		}


		public async Task<IActionResult> Facturar() 
		{
			List<ItemCarrito> carrito = HttpContext.Session.GetJson<List<ItemCarrito>>("Carrito") ?? new List<ItemCarrito>();

			CarritoCompras carritoC = new()
			{
				ItemCarrito = carrito,
				TotalFinal = carrito.Sum(x => x.Cantidad * x.Precio)
			};
			Venta factura = new()
			{ 
				ClienteId = 1,
				NombreCliente = HttpContext.Session.GetString("nombre")+" "+ HttpContext.Session.GetString("apellido"),
				CorreoCliente = HttpContext.Session.GetString("correo"),
				TipoPago ="Tarjeta",
				MontoPago = carritoC.TotalFinal,
				FechaRegistro = DateTime.Now
			};

			_context.Venta.Add(factura);
			await _context.SaveChangesAsync();
			var idFact = factura.Id;

			foreach (var item in carrito) 
			{
				DetalleVenta linea = new() { 
					VentaId = idFact,
					ProductoNombre = item.NomProducto,
					ProductoId = item.ProductoId,
					PrecioVenta = item.Precio,
					Cantidad = item.Cantidad,
					Total = item.Total
				};

				_context.DetalleVenta.Add(linea);
				await _context.SaveChangesAsync();
			}
			HttpContext.Session.Remove("Carrito");

			return RedirectToAction("Index");
		}
	}
}
