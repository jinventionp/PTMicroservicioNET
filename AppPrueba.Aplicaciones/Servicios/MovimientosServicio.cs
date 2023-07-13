using System;
using System.Collections.Generic;
using System.Text;

using Prueba.Dominio;
using Prueba.Dominio.Interfaces.Repositorios;
using Prueba.Aplicaciones.Interfaces;
using Prueba.Dominio.Interfaces;

namespace Prueba.Aplicaciones.Servicios
{
    public class MovimientosServicio : IServicioMovimientos<Movimientos, Guid, DateTime, DateTime>
    {
        private readonly IRepositorioMovimientos<Movimientos, Guid, DateTime, DateTime> repoMovimientos;
        private readonly IRepositorioBase<Cuenta, Guid> repoCuenta;

        public MovimientosServicio(
            IRepositorioMovimientos<Movimientos, Guid, DateTime, DateTime> _repoMovimientos,
            IRepositorioBase<Cuenta, Guid> _repoCuenta
            )
        {
            repoMovimientos = _repoMovimientos;
            repoCuenta = _repoCuenta;
        }
        public Movimientos Crear(Movimientos entidad)
        {
            if (entidad == null)
                throw new ArgumentNullException("La entidad 'Movimientos' es requerida para crear");
            
            var cuenta = repoCuenta.ObtenerPorID(entidad.cuentaId);
            if (entidad.tipoMovimiento == "Retiro" && cuenta.saldoInicial == 0)
                throw new ArgumentNullException("Saldo no disponible");

            if (entidad.tipoMovimiento == "Retiro")
            { //Resta
                if (cuenta.saldoInicial >= entidad.valor) {
                    entidad.saldo = cuenta.saldoInicial - entidad.valor;
                }
            }
            else if (entidad.tipoMovimiento == "Deposito")
            { //Suma
                entidad.saldo = cuenta.saldoInicial + entidad.valor;
            }                   
            
            var resultMovimientos = repoMovimientos.Crear(entidad);
            repoMovimientos.GuardarCambios();
            return resultMovimientos;
        }

        public void Editar(Movimientos entidad)
        {
            if (entidad == null)
                throw new ArgumentNullException("La entidad 'Movimientos' es requerida para editar");

            repoMovimientos.Editar(entidad);
            repoMovimientos.GuardarCambios();
        }

        public void Eliminar(Guid entidadId)
        {
            repoMovimientos.Eliminar(entidadId);
            repoMovimientos.GuardarCambios();
        }

        public List<Movimientos> Listar()
        {
            return repoMovimientos.Listar();
        }

        public Movimientos ObtenerPorID(Guid entidadId)
        {
            return repoMovimientos.ObtenerPorID(entidadId);
        }

        public List<ListadoMovimientos> ObtenerPorRangoFecha(Guid entidadId, DateTime entidadFechaInicial, DateTime entidadFechaFinal)
        {
            return repoMovimientos.ObtenerPorRangoFecha(entidadId, entidadFechaInicial, entidadFechaFinal);
        }
    }
}
