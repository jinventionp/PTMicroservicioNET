using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Prueba.Dominio;
using Prueba.Dominio.Interfaces.Repositorios;
using Prueba.Infraestructura.Datos.Contextos;

using Microsoft.EntityFrameworkCore;

namespace Prueba.Infraestructura.Datos.repositorios
{
    public class CuentaRepositorio : IRepositorioBase<Cuenta, Guid>
    {
        private PruebaContexto db;

        public CuentaRepositorio(PruebaContexto _db)
        {
            db = _db;
        }
        public Cuenta Crear(Cuenta entidad)
        {
            entidad.cuentaId = Guid.NewGuid();
            db.Cuentas.Add(entidad);
            return entidad;
        }

        public void Editar(Cuenta entidad)
        {
            var cuenta = db.Cuentas.Where(c => c.cuentaId == entidad.cuentaId).FirstOrDefault();
            if (cuenta != null)
            {
                cuenta.numeroCuenta = entidad.numeroCuenta;
                cuenta.tipoCuenta = entidad.tipoCuenta;
                cuenta.saldoInicial = entidad.saldoInicial;
                cuenta.estado = entidad.estado;

                db.Entry(cuenta).State = EntityState.Modified;
            }
        }

        public void Eliminar(Guid entidadId)
        {
            var cuenta = db.Cuentas.Where(c => c.cuentaId == entidadId).FirstOrDefault();
            if (cuenta != null)
            {
                db.Cuentas.Remove(cuenta);
            }
        }

        public void GuardarCambios()
        {
            db.SaveChanges();
        }

        public List<Cuenta> Listar()
        {
            return db.Cuentas.ToList();
        }

        public Cuenta ObtenerPorID(Guid entidadId)
        {
            var cuenta = db.Cuentas.Where(c => c.cuentaId == entidadId).FirstOrDefault();
            return cuenta;
        }
    }
}
