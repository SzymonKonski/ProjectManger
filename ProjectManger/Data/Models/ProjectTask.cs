﻿using ProjectManger.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManger.Data.Models
{
    public class ProjectTask
    {
        public long Id { get; set; }
        public ProjectTaskStatus Status { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime Deadline  { get; set; }
        public long ProjectId { get; set; }
        public virtual Project Project { get; set; }
    }
}
