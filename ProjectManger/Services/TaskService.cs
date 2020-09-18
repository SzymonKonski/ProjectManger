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
    public class TaskService
    {
        private PMContext _context;

        public TaskService()
        {
            _context = new PMContext();
        }

        public IEnumerable<TaskListItemDto> GetBetween(string from, string to)
        {
            var fromDate = DateTime.ParseExact(from, "dd-MM-yyyy", null);
            var toDate = DateTime.ParseExact(to, "dd-MM-yyyy", null);

            var tasks = _context.ProjectTasks.Include(x => x.Project).Where(x => x.Deadline >= fromDate && x.Deadline <= toDate).ToList();

            return tasks.Select(x => new TaskListItemDto
            {
                Title = x.Title,
                Date = x.Deadline.ToString("dd-MM-yyyy"),
                Status = x.Status.ToString(),
                ProjectId = x.ProjectId,
                ProjectName = x.Project.Name
            }); 
        }

    public IEnumerable<TaskListItemDto> GetTasks(long id)
        {
            var tasks = _context.Projects.Include(x => x.Tasks).Single(x => x.Id == id).Tasks.ToList();

            return tasks.Select(x => new TaskListItemDto
            {
                Title = x.Title,
                Date = x.Deadline.ToString("dd-MM-yyyy"),
                Status = x.Status.ToString(),
                ProjectId = x.ProjectId,
                ProjectName = x.Project.Name
            });
        }

        public async Task AddTask(NewTaskDto task, long id)
        {
            var entity = new ProjectTask
            {
                Description = task.Description,
                Deadline = DateTime.ParseExact(task.Date, "dd-MM-yyyy", null),
                Title = task.Title,
                CreatedDate = DateTime.Now,
                Status = Enums.ProjectTaskStatus.New
            };

            _context.Projects.Single(x => x.Id == id).Tasks.Add(entity);
            await _context.SaveChangesAsync();
        }

        public void ChangeStatus(ProjectTaskStatusDto status)
        {
            var entity = _context.ProjectTasks.Single(x => x.Id == status.Id);

            entity.Status = Enum.Parse<Enums.ProjectTaskStatus>(status.Status);

            _context.ProjectTasks.Update(entity);
            _context.SaveChanges();

            var project = _context.Projects.Include(x => x.Tasks).Single(x => x.Id == status.ProjectId);

            if (project.Tasks.Any(x => x.Status == Enums.ProjectTaskStatus.InProgress))
            {
                project.Status = Enums.ProjectStatus.InProgress;
                _context.Projects.Update(project);
                _context.SaveChanges();
            }
        }
        
    }
}
