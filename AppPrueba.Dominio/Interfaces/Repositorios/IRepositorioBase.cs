using System;
using System.Collections.Generic;
using System.Text;

using Prueba.Dominio.Interfaces;
namespace Prueba.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioBase<TEntidad, TEntidadID>
        : ICrear<TEntidad>, IEditar<TEntidad>, IEliminar<TEntidadID>, IListar<TEntidad, TEntidadID>, ITransaccion
    {
    }
}
