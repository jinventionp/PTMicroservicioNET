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
    public class CuentasController : ControllerBase
    {
        CuentaServicio CrearServicio()
        {
            PruebaContexto db = new PruebaContexto();
            CuentaRepositorio repo = new CuentaRepositorio(db);
            CuentaServicio servicio = new CuentaServicio(repo);
            return servicio;
        }

        [HttpGet]
        public ActionResult<List<Cuenta>> Get()
        {
            var servicio = CrearServicio();
            return Ok(servicio.Listar());
        }

        [HttpGet("{id}")]
        public ActionResult<Cuenta> Get(Guid id)
        {
            var servicio = CrearServicio();
            return Ok(servicio.ObtenerPorID(id));
        }

        [HttpPost]
        public ActionResult Post([FromBody] Cuenta Cuenta)
        {
            var servicio = CrearServicio();
            servicio.Crear(Cuenta);
            return Ok("Entidad Cuenta creada con éxito !!!");
        }

        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Cuenta Cuenta)
        {
            var servicio = CrearServicio();
            Cuenta.cuentaId = id;
            servicio.Editar(Cuenta);
            return Ok("Entidad Cuenta editada con éxito !!!");
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var servicio = CrearServicio();
            servicio.Eliminar(id);
            return Ok("Entidad Cuenta eliminada correctamente !!!");
        }
    }
}
