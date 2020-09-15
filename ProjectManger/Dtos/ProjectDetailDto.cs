using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManger.Dtos
{
    public class ProjectDetailDto
    {
        public long Id { get; set; }
        public string Deadline { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string Client { get; set; }
    }
}
