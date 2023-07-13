using System;
using System.Collections.Generic;
using System.Text;

using Prueba.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Prueba.Infraestructura.Datos.configs
{
    class ClienteConfig : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("tblClientes");
            builder.HasKey(c => c.clienteId);

            builder
                .HasMany(c => c.Cuentas)
                .WithOne(c => c.cliente);
        }
    }
}
