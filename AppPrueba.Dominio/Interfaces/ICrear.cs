using System;
using System.Collections.Generic;
using System.Text;

namespace Prueba.Dominio.Interfaces
{
    public interface ICrear<TEntidad>
    {
        TEntidad Crear(TEntidad entidad);
    }
}
