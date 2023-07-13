using System;
using System.Collections.Generic;
using System.Text;

namespace Prueba.Dominio
{
    public class Cliente: Persona
    {
        public Guid clienteId { get; set; }
        public string contrasena { get; set; }
        public bool estado { get; set; }

        public List<Cuenta> Cuentas { get; set; } // Relación uno a muchos con la entidad Cuenta

    }
}
