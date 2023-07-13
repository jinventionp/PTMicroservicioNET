using System;
using System.Collections.Generic;
using System.Text;

namespace Prueba.Dominio
{
    public class Movimientos
    {
        //Fecha, tipo movimiento, valor, saldo
        public Guid movimientoId { get; set; }
        public Guid cuentaId { get; set; }
        public DateTime fecha { get; set; }
        public string tipoMovimiento { get; set; }
        public decimal valor { get; set; }
        public decimal saldo { get; set; }

        public Cuenta cuenta { get; set; }

    }
}
