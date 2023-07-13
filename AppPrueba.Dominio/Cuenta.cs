using System;
using System.Collections.Generic;
using System.Text;

namespace Prueba.Dominio
{
    public class Cuenta
    {
        //número cuenta, tipo cuenta, saldo Inicial, estado.
        public Guid cuentaId { get; set; }
        public Guid clienteId { get; set; }
        public string numeroCuenta { get; set; }
        public string tipoCuenta { get; set; }
        public decimal saldoInicial { get; set; }
        public bool estado { get; set; }
        public Cliente cliente { get; set; }
        public List<Movimientos> Movimientos { get; set; } // Relación uno a muchos con la entidad Movimiento
    }
}
