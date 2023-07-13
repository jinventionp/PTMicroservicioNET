using System;
using System.Collections.Generic;
using System.Text;
using Prueba.Dominio.Interfaces;

namespace Prueba.Aplicaciones.Interfaces
{
    public interface IServicioMovimientos<TEntidad, TEntidadID, TEntidadFechaInicial, TEntidadFechaFinal>
        : ICrear<TEntidad>, IEditar<TEntidad>, IEliminar<TEntidadID>, IListar<TEntidad, TEntidadID>, IListarFecha<TEntidad, TEntidadID, TEntidadFechaInicial, TEntidadFechaFinal>
    {
    }
}
