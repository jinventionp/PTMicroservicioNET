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
    public class ClientesController : ControllerBase
    {
        ClienteServicio CrearServicio()
        {
            PruebaContexto db = new PruebaContexto();
            ClienteRepositorio repo = new ClienteRepositorio(db);
            ClienteServicio servicio = new ClienteServicio(repo);
            return servicio;
        }

        [HttpGet]
        public ActionResult<List<Cliente>> Get()
        {
            var servicio = CrearServicio();
            return Ok(servicio.Listar());
        }

        [HttpGet("{id}")]
        public ActionResult<Cliente> Get(Guid id)
        {
            var servicio = CrearServicio();
            return Ok(servicio.ObtenerPorID(id));
        }

        [HttpPost]
        public ActionResult Post([FromBody] Cliente cliente)
        {
            var servicio = CrearServicio();
            servicio.Crear(cliente);
            return Ok("Entidad Cliente creada con éxito !!!");
        }

        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Cliente cliente)
        {
            var servicio = CrearServicio();
            cliente.clienteId = id;
            servicio.Editar(cliente);
            return Ok("Entidad Cliente editada con éxito !!!");
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var servicio = CrearServicio();
            servicio.Eliminar(id);
            return Ok("Entidad Cliente eliminada correctamente !!!");
        }

        // GET: api/<ClienteController>
        /*[HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }*/

        // GET api/<ClienteController>/5
        /*[HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }*/

        // POST api/<ClienteController>
        /*[HttpPost]
        public void Post([FromBody] string value)
        {
        }*/

        // PUT api/<ClienteController>/5
        /*[HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }*/

        // DELETE api/<ClienteController>/5
        /*[HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}
