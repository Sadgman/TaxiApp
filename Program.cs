using Microsoft.EntityFrameworkCore;
using TaxiApp.Models;

var builder = WebApplication.CreateBuilder(args);

// Configurar servicios al contenedor.
builder.Services.AddControllersWithViews();

// Configurar la cadena de conexión
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<TaxiContexto>(options =>
    options.UseSqlServer(connectionString));

var app = builder.Build();

// Configurar la tubería HTTP.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
