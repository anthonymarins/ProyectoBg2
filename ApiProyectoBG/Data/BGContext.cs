using ApiBalance.Modelo;
using Microsoft.EntityFrameworkCore;

namespace ApiBalance.Data
{
    public class BGContext : DbContext
    {
        public BGContext(DbContextOptions<BGContext> options) : base(options) { }
        public DbSet<CuentasI> Cuentas { get; set; }
        public DbSet<Entradas> Entradas { get; set; }
        public DbSet<Salidas> Salidas { get; set; } 

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CuentasI>().HasData(
                    new CuentasI()
                    {
                        IdCuenta = 1,
                        tipoCuenta = "Activo",
                        NombreCuenta = "Banco",
                        SaldoCuentas = 1500
                    }
                );
        }
    }
}
