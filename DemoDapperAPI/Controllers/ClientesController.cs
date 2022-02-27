using DemoDapperAPI.Models;
using DemoDapperAPI.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DemoDapperAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        // GET: api/<ClientesController>
        [HttpGet]
        public ActionResult<IEnumerable<Clte>> Get()
        {
            var clienteService = new ClteService();
            {
                var cliente = clienteService.GetClientes();
                if (cliente != null)
                {
                    return Ok(cliente);
                }
                return NotFound("Aviso:No hay clientes");
            }
        }

        [HttpGet]
        [Route("ASYNC")]
        public async Task<ActionResult<IEnumerable<Clte>>> GetAsync()
        {
            var clienteService = new ClteService();
            {
                var cliente = await clienteService.GetClientesAsync();
                if (cliente != null)
                {
                    return Ok(cliente);
                }
                return NotFound("Aviso: No hay clientes");
            }
        }

        // GET api/<ClientesController>/5
        [HttpGet("{id}")]
        public ActionResult<Clte> Get(int id)
        {
            var clienteService = new ClteService();
            {
                var cliente = clienteService.GetClienteById(id);
                if (cliente != null)
                {
                    return Ok(cliente);
                }
                return NotFound("Aviso:No hay cliente con ese id: " + id);
            }
        }

        // POST api/<ClientesController>
        [HttpPost]
        public void Post([FromBody] Clte cliente)
        {
            var clienteService = new ClteService();
            {
                clienteService.AddClient(cliente, true);

            }
        }

        //api/cliente/async
        [HttpPost]
        [Route("ASYNC")]
        public async Task PostAsync([FromBody] Clte cliente)
        {
            try
            {
                var clienteService = new ClteService();
                {
                    cliente.id = 0;
                    await clienteService.AddClientAsync(cliente);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        // PUT api/<ClientesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Clte cliente)
        {
            try
            {
                var clienteService = new ClteService();
                {
                    cliente.id = id;
                    clienteService.UpdateClient(cliente, true);
                }

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        [HttpPut("{id}")]
        [Route("ASYNC")]
        public async Task PutAsync([FromBody] Clte cliente)
        {
            try
            {
                var clienteService = new ClteService();
                {
                    await clienteService.UpdateClientAsync(cliente);
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        // DELETE api/<ClientesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
