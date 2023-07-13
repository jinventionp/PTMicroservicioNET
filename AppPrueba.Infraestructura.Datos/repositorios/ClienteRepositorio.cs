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
    public class ClienteRepositorio : IRepositorioBase<Cliente, Guid>
    {
        private PruebaContexto db;

        public ClienteRepositorio(PruebaContexto _db)
        {
            db = _db;
        }
        public Cliente Crear(Cliente entidad)
        {
            entidad.clienteId = Guid.NewGuid();
            db.Clientes.Add(entidad);
            return entidad;
        }

        public void Editar(Cliente entidad)
        {
            var cliente = db.Clientes.Where(c => c.clienteId == entidad.clienteId).FirstOrDefault();
            if (cliente != null)
            {
                cliente.nombre = entidad.nombre;
                cliente.genero = entidad.genero;
                cliente.edad = entidad.edad;
                cliente.identificacion = entidad.identificacion;
                cliente.direccion = entidad.telefono;
                cliente.contrasena = entidad.contrasena;
                cliente.estado = entidad.estado;

                db.Entry(cliente).State = EntityState.Modified;
            }
        }

        public void Eliminar(Guid entidadId)
        {
            var cliente = db.Clientes.Where(c => c.clienteId == entidadId).FirstOrDefault();
            if (cliente != null)
            {
                db.Clientes.Remove(cliente);
            }
        }

        public void GuardarCambios()
        {
            db.SaveChanges();
        }

        public List<Cliente> Listar()
        {
            return db.Clientes.ToList();
        }

        public Cliente ObtenerPorID(Guid entidadId)
        {
            var cliente = db.Clientes.Where(c => c.clienteId == entidadId).FirstOrDefault();
            return cliente;
        }
    }
}
