using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManger.Dtos
{
    public class ProjectItemDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Pricing { get; set; }
        public string Status { get; set; }
        public string Deadline { get; set; }
    }
}
