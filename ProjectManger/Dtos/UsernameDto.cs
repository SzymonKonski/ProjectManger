using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManger.Dtos
{
    public class UsernameDto
    {
        public string Name { get; }

        public UsernameDto(string login)
        {
            Name = login;
        }
    }
}
