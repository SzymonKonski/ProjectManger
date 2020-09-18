using Microsoft.EntityFrameworkCore;
using ProjectManger.Data;
using ProjectManger.Data.Models;
using ProjectManger.Dtos;
using System.Collections.Generic;
using System.Linq;

namespace ProjectManger.Services
{
    public class ClientService
    {
        private PMContext _context;

        public ClientService()
        {
            _context = new PMContext();
        }

        public long Create(NewClientDto client)
        {
             var entity = new Client(client.Name,client.Address,client.Email,client.Phone, client.Description);
            _context.Clients.Add(entity);
            _context.SaveChanges();
            return entity.Id;
        }

        public IEnumerable<ClientItemDto> GetAll()
        {
            var entities = _context.Clients.Include(x => x.Projects).ToList();

            return entities.Select(x => new ClientItemDto
            {
                Email = x.Email,
                Id = x.Id,
                Name = x.Name,
                Phone = x.PhoneNumber,
                Projects = x.Projects.Count
            });
        }

        public ClientDetailsDto Get(long id)
        {
            var client = _context.Clients.Include(x => x.Projects).Single(x => x.Id == id);
            return new ClientDetailsDto
            {
                Id = client.Id,
                Address = client.Address,
                Description = client.Description,
                Email = client.Email,
                Name = client.Name,
                Phone = client.PhoneNumber,
                Projects = client.Projects.Select(x => new ProjectItemDto
                {
                    Id = x.Id,
                    Deadline = x.Deadline.ToString("dd-MM-yyyy"),
                    Name = x.Name,
                    Pricing = x.Pricing,
                    Status = x.Status.ToString()
                })
            };
        }
    }
}
