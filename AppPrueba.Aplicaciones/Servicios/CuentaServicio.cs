using System;
using System.Collections.Generic;
using System.Text;

using Prueba.Dominio;
using Prueba.Dominio.Interfaces.Repositorios;
using Prueba.Aplicaciones.Interfaces;

namespace Prueba.Aplicaciones.Servicios
{
    public class CuentaServicio : IServicioBase<Cuenta, Guid>
    {
        private readonly IRepositorioBase<Cuenta, Guid> repoCuenta;

        public CuentaServicio(IRepositorioBase<Cuenta, Guid> _repoCuenta)
        {
            repoCuenta = _repoCuenta;
        }
        public Cuenta Crear(Cuenta entidad)
        {
            if (entidad == null)
                throw new ArgumentNullException("La entidad 'Cuenta' es requerida para crear");

            var resultCuenta = repoCuenta.Crear(entidad);
            repoCuenta.GuardarCambios();
            return resultCuenta;
        }

        public void Editar(Cuenta entidad)
        {
            if (entidad == null)
                throw new ArgumentNullException("La entidad 'Cuenta' es requerida para editar");

            repoCuenta.Editar(entidad);
            repoCuenta.GuardarCambios();
        }

        public void Eliminar(Guid entidadId)
        {
            repoCuenta.Eliminar(entidadId);
            repoCuenta.GuardarCambios();
        }

        public List<Cuenta> Listar()
        {
            return repoCuenta.Listar();
        }

        public Cuenta ObtenerPorID(Guid entidadId)
        {
            return repoCuenta.ObtenerPorID(entidadId);
        }
    }
}
