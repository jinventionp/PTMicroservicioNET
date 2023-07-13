using System;
using System.Collections.Generic;
using System.Text;

using Prueba.Dominio;
using Prueba.Dominio.Interfaces.Repositorios;
using Prueba.Aplicaciones.Interfaces;

namespace Prueba.Aplicaciones.Servicios
{
    public class PersonaServicio : IServicioBase<Persona, Guid>
    {
        private readonly IRepositorioBase<Persona, Guid> repoPersona;

        public PersonaServicio(IRepositorioBase<Persona, Guid> _repoPersona)
        {
            repoPersona = _repoPersona;
        }
        public Persona Crear(Persona entidad)
        {
            if (entidad == null)
                throw new ArgumentNullException("La entidad 'Persona' es requerida para crear");

            var resultPersona = repoPersona.Crear(entidad);
            repoPersona.GuardarCambios();
            return resultPersona;
        }

        public void Editar(Persona entidad)
        {
            if (entidad == null)
                throw new ArgumentNullException("La entidad 'Persona' es requerida para editar");

            repoPersona.Editar(entidad);
            repoPersona.GuardarCambios();
        }

        public void Eliminar(Guid entidadId)
        {
            repoPersona.Eliminar(entidadId);
            repoPersona.GuardarCambios();
        }

        public List<Persona> Listar()
        {
            return repoPersona.Listar();
        }

        public Persona ObtenerPorID(Guid entidadId)
        {
            return repoPersona.ObtenerPorID(entidadId);
        }
    }
}
