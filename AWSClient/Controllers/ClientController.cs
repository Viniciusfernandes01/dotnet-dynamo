using AWSClient.Database;
using AWSClient.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AWSClient.Controllers
{
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly ClientRepository clientRepository;

        public ClientController(ClientRepository clientRepository)
        {
            this.clientRepository = clientRepository;
        }

        [HttpPost]
        [Route("save")]
        public async Task<IActionResult> Save(Client client)
        {
            client.IdClient = Guid.NewGuid();

            await this.clientRepository.Save(client);

            return Created($"/{client.IdClient}", client);
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll()
        {
            var result = await this.clientRepository.GetAll();

            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await this.clientRepository.GetById(id);

            if (!result.Any())
            {
                return NotFound();
            }

            return Ok(result.FirstOrDefault());
        }

    }
}
