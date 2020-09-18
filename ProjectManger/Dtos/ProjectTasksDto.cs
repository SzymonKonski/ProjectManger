using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManger.Dtos
{
    public class ProjectTasksDto
    {
        public string ProjectName { get; set; }
        public int New { get; set; }
        public int InProgress { get; set; }
        public int Finished { get; set; }
        public string ClientName { get; set; }
    }
}
