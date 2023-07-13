using System;
using System.Collections.Generic;
using System.Text;

namespace Prueba.Dominio.Interfaces
{
    public interface IListarFecha<TEntidad, TEntidadID, TEntidadFechaInicial, TEntidadFechaFinal> //, TEntidadFechaInicial, TEntidadFechaFinal 
    {
        List<TEntidad> Listar();
        TEntidad ObtenerPorID(TEntidadID entidadId);
        List<ListadoMovimientos> ObtenerPorRangoFecha(TEntidadID entidadId, TEntidadFechaInicial entidadFechaInicial, TEntidadFechaFinal entidadFechaFinal);
    }
}
