using Microsoft.EntityFrameworkCore;
using PAWS_ProyectoFinal.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<PAWSContext>(opciones =>
	opciones.UseSqlServer(builder.Configuration.GetConnectionString("PAWS_ProyectoFinal")));

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(opciones =>
{
	opciones.IdleTimeout = TimeSpan.FromMinutes(30);
	opciones.Cookie.IsEssential = true;
});

var app = builder.Build();

app.UseSession();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseSession();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=InicioSesion}/{action=Index}/{id?}");

app.Run();
