using System;
using System.Collections.Generic;
using System.Text;

using Prueba.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Prueba.Infraestructura.Datos.configs
{
    public class MovimientosConfig : IEntityTypeConfiguration<Movimientos>
    {
        public void Configure(EntityTypeBuilder<Movimientos> builder)
        {
            builder.ToTable("tblMovimientos");
            builder.HasKey(c => c.movimientoId);
        }
    }
}
