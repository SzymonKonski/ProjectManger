using AutoMapper;
using Microsoft.EntityFrameworkCore;
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

        public ProjectService()
        {
            _context = new PMContext();
        }

        public async Task CreateProject(NewProjectDto project)
        {
            var entity = new Project
            {
                Name = project.Name,
                Description = project.Description,
                Deadline = DateTime.Parse(project.Deadline),
                Status = Enums.ProjectStatus.New
            };

            if(project.ClientId != 0)
            {
                var client = _context.Clients.Single(x => x.Id == project.ClientId);
                client.Projects.Add(entity);
            }
            else
            {
                _context.Projects.Add(entity);
            }

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
                Pricing = project.Pricing,
                Status = project.Status.ToString(),
                Client = project.Client != null ? project.Client.Name : string.Empty 
            };

            return dto;
        }

        public IEnumerable<ProjectDetailDto> GetAllProjects()
        {
            var projects = _context.Projects.Include(x => x.Client).ToList().Select(x => new ProjectDetailDto
            {
                Id = x.Id,
                Name = x.Name,
                Deadline = x.Deadline.ToString("dd-MM-yyyy"),
                Status = x.Status.ToString(),
                Pricing = x.Pricing,
                ClientId = x.ClientId,
                Client = x.ClientId != 0  ? x.Client.Name : string.Empty
            });

            return projects;
        }

        public void FinishProject(long id)
        {
            var project = _context.Projects.Include(x=>x.Client).Single(x => x.Id == id);
            project.Status = Enums.ProjectStatus.Finished;
            _context.Projects.Update(project);
            _context.SaveChanges();
        }

        public IEnumerable<ProjectTasksDto> GetProjectTasksStatistic()
        {
            var projects = _context.Projects.Include(x => x.Tasks).Include(x => x.Client).OrderBy(x => x.CreatedDate).ToList().Select(x => new ProjectTasksDto
            {
                ProjectName = x.Name,
                New = x.Tasks.Count(x=>x.Status == Enums.ProjectTaskStatus.New),
                InProgress = x.Tasks.Count(x=> x.Status == Enums.ProjectTaskStatus.InProgress),
                Finished = x.Tasks.Count(x => x.Status == Enums.ProjectTaskStatus.Finished),
                ClientName = x.Client != null ? x.Client.Name : string.Empty
            });

            return projects;
        }
    }
}
