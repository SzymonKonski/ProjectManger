using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManger.Dtos
{
    public class NewTaskDto
    {
        public long ProjectId { get; set; }
        public string Title { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }
    }
}
