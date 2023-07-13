using System;
using System.Collections.Generic;
using System.Text;

using Prueba.Dominio;
using Prueba.Dominio.Interfaces.Repositorios;
using Prueba.Aplicaciones.Interfaces;

namespace Prueba.Aplicaciones.Servicios
{
    public class ClienteServicio : IServicioBase<Cliente, Guid>
    {
        private readonly IRepositorioBase<Cliente, Guid> repoCliente;

        public ClienteServicio(IRepositorioBase<Cliente, Guid> _repoCliente)
        {
            repoCliente = _repoCliente;
        }
        public Cliente Crear(Cliente entidad)
        {
            if (entidad == null)
                throw new ArgumentNullException("La entidad 'Cliente' es requerida para crear");

            var resultCliente = repoCliente.Crear(entidad);
            repoCliente.GuardarCambios();
            return resultCliente;
        }

        public void Editar(Cliente entidad)
        {
            if (entidad == null)
                throw new ArgumentNullException("La entidad 'Cliente' es requerida para editar");

            repoCliente.Editar(entidad);
            repoCliente.GuardarCambios();
        }

        public void Eliminar(Guid entidadId)
        {
            repoCliente.Eliminar(entidadId);
            repoCliente.GuardarCambios();
        }

        public List<Cliente> Listar()
        {
            return repoCliente.Listar();
        }

        public Cliente ObtenerPorID(Guid entidadId)
        {
            return repoCliente.ObtenerPorID(entidadId);
        }
    }
}
