using System;
using System.Collections.Generic;
using System.Text;

using Prueba.Dominio.Interfaces;

namespace Prueba.Aplicaciones.Interfaces
{
    interface IServicioBase<TEntidad, TEntidadID>
        : ICrear<TEntidad>, IEditar<TEntidad>, IEliminar<TEntidadID>, IListar<TEntidad, TEntidadID>
    {
    }
}
