using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManger.Dtos;
using ProjectManger.Services;

namespace ProjectManger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ClientService _clientService = new ClientService();
        [HttpPost]
        public void NewClient(NewClientDto client)
        {
            _clientService.Create(client);
        }

        [HttpGet("{id}")]
        public ClientDetailsDto Get(long id)
        {
            return null;
        }

        [HttpGet]
        public IEnumerable<ClientItemDto> GetAll()
        {
            return null;
        }
    }
}
