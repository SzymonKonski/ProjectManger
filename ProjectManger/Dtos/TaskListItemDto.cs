using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManger.Dtos
{
    public class TaskListItemDto
    { 
        public string ProjectName { get; set; }
        public long ProjectId{ get; set; }
        public string Date { get; set; }
        public string Title { get; set; }
        public string Status { get; set; }
    }
}
