using System;
using System.Collections.Generic;
using System.Text;

using Prueba.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Prueba.Infraestructura.Datos.configs
{
    public class CuentaConfig : IEntityTypeConfiguration<Cuenta>
    {
        public void Configure(EntityTypeBuilder<Cuenta> builder)
        {
            builder.ToTable("tblCuentas");
            builder.HasKey(c => c.cuentaId);

            builder
                .HasMany(c => c.Movimientos)
                .WithOne(m => m.cuenta);
        }
    }
}
