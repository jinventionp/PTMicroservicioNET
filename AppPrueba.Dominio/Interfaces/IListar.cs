using System;
using System.Collections.Generic;
using System.Text;

namespace Prueba.Dominio.Interfaces
{
    public interface IListar<TEntidad, TEntidadID> //, TEntidadFechaInicial, TEntidadFechaFinal 
    {
        List<TEntidad> Listar();
        TEntidad ObtenerPorID(TEntidadID entidadId);
        //TEntidad ObtenerPorRangoFecha(TEntidadFechaInicial entidadFechaInicial, TEntidadFechaFinal entidadFechaFinal);
    }
}
