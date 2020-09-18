using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
        private readonly ClientService _clientService;

        public ClientController(ClientService createService)
        {
            _clientService = createService;
        }

        [HttpPost]
        public long NewClient(NewClientDto client)
        {
           return _clientService.Create(client);
        }

        [HttpGet("{id}")]
        public ClientDetailsDto Get(long id)
        {
           return _clientService.Get(id);
        }

        [HttpGet]
        public IEnumerable<ClientItemDto> GetAll()
        {
            return _clientService.GetAll();
        }
    }
}
