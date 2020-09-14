using AutoMapper;
using ProjectManger.Data;
using ProjectManger.Data.Models;
using ProjectManger.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManger.Services
{
    public class ProjectService
    {
        private PMContext _context;
        private readonly IMapper _mapper;


        public ProjectService(IMapper mapper)
        {
            _context = new PMContext();
            _mapper = mapper;
        }

        public async Task CreateProject(NewProjectDto project, long id)
        {
            //var entity = new Project
            //{
            //    Name = project.Name,
            //    Description = project.Description,
            //    Deadline = DateTime.Parse(project.Deadline),
            //    Status = Enums.ProjectStatus.New
            //};

            var entity = _mapper.Map<Project>(project);
            _context.Clients.Single(x => x.Id == id).Projects.Add(entity);
            await _context.SaveChangesAsync();        
        }

        public ProjectDetailDto GetDetails(long id)
        {
            var project = _context.Projects.Single(x => x.Id == id);


            var dto = new ProjectDetailDto
            {
                Id = project.Id,
                Deadline = project.Deadline.ToString("dd-MM-yyyy"),
                Description = project.Description,
                Name = project.Name,
                Status = project.Status.ToString()
            };

            return dto;
        }

        public IEnumerable<ProjectDetailDto> GetAllProjects()
        {
            var projects = _context.Projects.ToList().Select(x => new ProjectDetailDto
            {
                Id = x.Id,
                Name = x.Name,
                Deadline = x.Deadline.ToString("dd-MM-yyyy"),
                Status = x.Status.ToString()
            });

            return projects;
        }

        public void FinishProject(long id)
        {
            var project = _context.Projects.Single(x => x.Id == id);
            project.Status = Enums.ProjectStatus.Finished;
            _context.Projects.Update(project);
            _context.SaveChanges();
        }
    }
}
