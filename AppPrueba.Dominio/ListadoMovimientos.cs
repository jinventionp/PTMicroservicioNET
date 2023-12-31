﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Prueba.Dominio
{
    public class ListadoMovimientos
    {
        public DateTime fecha { get; set; }
        public string cliente { get; set; }
        public string numeroCuenta { get; set; }
        public string tipo { get; set; }
        public decimal saldoInicial { get; set; }
        public bool estado { get; set; }
        public decimal movimiento { get; set; }
        public decimal saldoDisponible { get; set; }
    }
}
