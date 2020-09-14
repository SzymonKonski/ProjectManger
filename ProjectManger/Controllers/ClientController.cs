using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManger.Dtos;

namespace ProjectManger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        [HttpPost]
        public void NewClient(NewClientDto client)
        {
            
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
