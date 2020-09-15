using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManger.Dtos
{
    public class NewProjectDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Deadline { get; set; }
        public long? ClientId { get; set; }
    }
}
