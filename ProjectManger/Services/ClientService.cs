using ProjectManger.Data;
using ProjectManger.Data.Models;
using ProjectManger.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManger.Services
{
    public class ClientService
    {
        private PMContext _context;

        public ClientService()
        {
            _context = new PMContext();
        }

        public void Create(NewClientDto client)
        {
            var entity = new Client
            {
                Name = client.Name,
                Description = client.Description,
                PhoneNumber = client.Phone,
                Email = client.Email,
                Address = client.Address
            };

            _context.Clients.Add(entity);
        }
    }
}
