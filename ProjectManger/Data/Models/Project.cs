using ProjectManger.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManger.Data.Models
{
    public class Project
    {
        public Project() 
        {
            Tasks = new Collection<ProjectTask>();
        }
        public long Id  { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public DateTime CreatedDate { get; set; }
        public ProjectStatus Status { get; set; }
        public decimal Pricing { get; set; }
        public virtual Client Client { get; set; }
        public virtual ICollection<ProjectTask> Tasks { get; set; }
    }
}
