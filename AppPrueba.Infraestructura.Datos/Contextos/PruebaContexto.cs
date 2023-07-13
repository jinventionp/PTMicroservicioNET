using System;
using System.Collections.Generic;
using System.Text;

using Prueba.Dominio;
using Microsoft.EntityFrameworkCore;
using Prueba.Infraestructura.Datos.configs;

namespace Prueba.Infraestructura.Datos.Contextos
{
    public class PruebaContexto : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Cuenta> Cuentas { get; set; }
        public DbSet<Movimientos> Movimientos { get; set; }

        //Sobreescribir le metodo OnConfigure
        protected override void OnConfiguring(DbContextOptionsBuilder options) 
        {
            options.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=prueba;Trusted_Connection=True;");
        }

        //Sobreescribir le metodo OnModelCreating
        protected override void OnModelCreating(ModelBuilder builder) {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new ClienteConfig());
            builder.ApplyConfiguration(new CuentaConfig());
            builder.ApplyConfiguration(new MovimientosConfig());
        }
    }
}
