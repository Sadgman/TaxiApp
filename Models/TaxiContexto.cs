namespace TaxiApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

public class TaxiContexto : DbContext
{
    public DbSet<Taxi> Taxis { get; set; }
    public DbSet<Conductor> Conductores { get; set; }
    public DbSet<Viaje> Viajes { get; set; }
    public DbSet<Cliente> Clientes { get; set; }

    public TaxiContexto(DbContextOptions<TaxiContexto> options) : base(options)
    {
    }
}
