using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManger.Data.Models
{
    public class Client
    {
        public Client(string name, string address, string email, string phone, string description)
        {
            Projects = new Collection<Project>();
            Name = name;
            Address = address;
            Email = email;
            PhoneNumber = phone;
            Description = description;
        }
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
    }
}
