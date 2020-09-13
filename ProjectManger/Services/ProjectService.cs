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

        public async Task<long> CreateProject(NewProjectDto project)
        {
            var entity = new Project
            {
                Name = project.Name,
                Description = project.Description,
                Deadline = DateTime.Parse(project.Deadline)
            };

            _context.Projects.Add(entity);

            await _context.SaveChangesAsync();

            return entity.Id;
        }

        public ProjectDetailDto GetDetails(long id)
        {
            var project = _context.Projects.Single(x => x.Id == id);


            var dto = new ProjectDetailDto
            {
                Id = project.Id,
                Deadline = project.Deadline.ToString("dd-MM-yyyy"),
                Description = project.Description,
                Name = project.Name
            };

            return dto;
        }

        public IEnumerable<TaskListItemDto> GetTasks(long id)
        {
            var tasks = _context.Projects.Single(x => x.Id == id).Tasks.ToList();

            return tasks.Select(x => new TaskListItemDto
            {
                Number = x.Id,
                Title = x.Title,
                Date = x.Date
            });
        }
    }
}
