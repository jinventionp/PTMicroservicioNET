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
    public class MovimientosRepositorio : IRepositorioMovimientos<Movimientos, Guid, DateTime, DateTime>
    {
        private PruebaContexto db;

        public MovimientosRepositorio(PruebaContexto _db)
        {
            db = _db;
        }
        public Movimientos Crear(Movimientos entidad)
        {
            entidad.movimientoId = Guid.NewGuid();
            db.Movimientos.Add(entidad);
            return entidad;
        }

        public void Editar(Movimientos entidad)
        {
            var movimiento = db.Movimientos.Where(c => c.movimientoId == entidad.movimientoId).FirstOrDefault();
            if (movimiento != null)
            {
                movimiento.fecha = entidad.fecha;
                movimiento.tipoMovimiento = entidad.tipoMovimiento;
                movimiento.valor = entidad.valor;
                movimiento.saldo = entidad.saldo;

                db.Entry(movimiento).State = EntityState.Modified;
            }
        }

        public void Eliminar(Guid entidadId)
        {
            var movimiento = db.Movimientos.Where(c => c.movimientoId == entidadId).FirstOrDefault();
            if (movimiento != null)
            {
                db.Movimientos.Remove(movimiento);
            }
        }

        public void GuardarCambios()
        {
            db.SaveChanges();
        }

        public List<Movimientos> Listar()
        {
            return db.Movimientos.ToList();
        }

        public Movimientos ObtenerPorID(Guid entidadId)
        {
            var movimiento = db.Movimientos.Where(c => c.movimientoId == entidadId).FirstOrDefault();
            return movimiento;
        }

        public List<ListadoMovimientos> ObtenerPorRangoFecha(Guid entidadId, DateTime entidadFechaInicial, DateTime entidadFechaFinal)
        {            
            var cliente = db.Clientes.Where(cli => cli.clienteId == entidadId).FirstOrDefault();
            List<Cuenta> cuentas = db.Cuentas.Where(cu => cu.clienteId == cliente.clienteId).ToList();
            List<string> cuentaIds = new List<string>();
            cuentas.ForEach(cuenta => {
                cuentaIds.Add(cuenta.cuentaId.ToString());
            });
            List<Movimientos> movimientos = db.Movimientos
                .Where(
                    m => m.fecha >= entidadFechaInicial && 
                    m.fecha <= entidadFechaFinal && 
                    cuentaIds.Contains(m.cuentaId.ToString()))
                .ToList();
            List<ListadoMovimientos> listadoMovimientos = new List<ListadoMovimientos>();
            movimientos.ForEach(movimiento => {
                ListadoMovimientos listMovi = new ListadoMovimientos();
                listMovi.fecha = movimiento.fecha;
                listMovi.cliente = cliente.nombre;
                listMovi.numeroCuenta = movimiento.cuenta.numeroCuenta;
                listMovi.tipo = movimiento.cuenta.tipoCuenta;
                listMovi.saldoInicial = movimiento.cuenta.saldoInicial;
                listMovi.estado = movimiento.cuenta.estado;
                listMovi.movimiento = movimiento.valor;
                listMovi.saldoDisponible = movimiento.saldo;

                listadoMovimientos.Add(listMovi);
            });
            return listadoMovimientos;
        }
    }
}
