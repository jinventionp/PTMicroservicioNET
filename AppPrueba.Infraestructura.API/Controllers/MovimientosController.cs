using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Prueba.Dominio;
using Prueba.Aplicaciones.Servicios;
using Prueba.Infraestructura.Datos.Contextos;
using Prueba.Infraestructura.Datos.repositorios;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Prueba.Infraestructura.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimientosController : ControllerBase
    {
        MovimientosServicio CrearServicio()
        {
            PruebaContexto db = new PruebaContexto();
            MovimientosRepositorio repo = new MovimientosRepositorio(db);
            CuentaRepositorio repoCuenta = new CuentaRepositorio(db);
            MovimientosServicio servicio = new MovimientosServicio(repo, repoCuenta);
            return servicio;
        }

        [HttpGet]
        public ActionResult<List<Movimientos>> Get()
        {
            var servicio = CrearServicio();
            return Ok(servicio.Listar());
        }

        [HttpGet("{id}")]
        public ActionResult<Movimientos> Get(Guid id)
        {
            var servicio = CrearServicio();
            return Ok(servicio.ObtenerPorID(id));
        }

        [HttpGet("{id}/{fechaInicial}/{fechaFinal}")]
        public ActionResult<List<ListadoMovimientos>> Get(Guid id, DateTime fechaInicial, DateTime fechaFinal)
        {
            var servicio = CrearServicio();
            return Ok(servicio.ObtenerPorRangoFecha(id, fechaInicial, fechaFinal));
        }

        [HttpPost]
        public ActionResult Post([FromBody] Movimientos Movimientos)
        {
            var servicio = CrearServicio();
            servicio.Crear(Movimientos);
            return Ok("Entidad Movimientos creada con éxito !!!");
        }

        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Movimientos Movimientos)
        {
            var servicio = CrearServicio();
            Movimientos.movimientoId = id;
            servicio.Editar(Movimientos);
            return Ok("Entidad Movimientos editada con éxito !!!");
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var servicio = CrearServicio();
            servicio.Eliminar(id);
            return Ok("Entidad Movimientos eliminada correctamente !!!");
        }
    }
}
