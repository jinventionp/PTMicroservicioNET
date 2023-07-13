using System;
using System.Collections.Generic;
using System.Text;

using Prueba.Dominio.Interfaces;
namespace Prueba.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioMovimientos<TEntidad, TEntidadID, TEntidadFechaInicial, TEntidadFechaFinal>
        : ICrear<TEntidad>, IEditar<TEntidad>, IEliminar<TEntidadID>, IListarFecha<TEntidad, TEntidadID, TEntidadFechaInicial, TEntidadFechaFinal>, ITransaccion
    {
    }
}
