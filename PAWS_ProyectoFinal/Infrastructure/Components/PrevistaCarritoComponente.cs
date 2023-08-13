using Microsoft.AspNetCore.Mvc;
using PAWS_ProyectoFinal.Infrastructure.TagHelpers;
using PAWS_ProyectoFinal.Models;
using PAWS_ProyectoFinal.Models.ViewModels;


namespace PAWS_ProyectoFinal.Infrasctrucure.Components
{
	public class PrevistaCarritoComponente : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			List<ItemCarrito> carrito = HttpContext.Session.GetJson<List<ItemCarrito>>("Carrito");
			PrevistaCarrito previstaCarrito;

			if (carrito == null || carrito.Count == 0)
			{
				previstaCarrito = null;
			}
			else
			{
				previstaCarrito = new()
				{
					NumeroItems = carrito.Sum(x => x.Cantidad),
					TotalNeto = carrito.Sum(x => x.Cantidad * x.Precio)
				};
			}

			return View(previstaCarrito);

		}
	}
}
