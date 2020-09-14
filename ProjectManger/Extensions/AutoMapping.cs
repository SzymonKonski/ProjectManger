using AutoMapper;
using ProjectManger.Data.Models;
using ProjectManger.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManger.Extensions
{
    class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<NewProjectDto, Project>().BeforeMap((s,d) => d.Status = Enums.ProjectStatus.New)
                .ForMember(x => x.Deadline, opt => opt.MapFrom(s => DateTime.Parse(s.Deadline)));
        }
    }
}
