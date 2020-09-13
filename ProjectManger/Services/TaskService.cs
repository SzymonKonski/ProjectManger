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
        public IEnumerable<TaskListItemDto> GetTasks(long id)
        {
            var tasks = _context.Projects.Include(x => x.Tasks).Single(x => x.Id == id).Tasks.ToList();

            return tasks.Select(x => new TaskListItemDto
            {
                Number = x.Id,
                Title = x.Title,
                Date = x.Date
            });
        }

        public async Task AddTask(NewTaskDto task, long id)
        {
            var entity = new ProjectTask
            {
                Description = task.Description,
                Date = task.Date,
                Done = false,
                Title = task.Title,
            };

            _context.Projects.Single(x => x.Id == id).Tasks.Add(entity);
            await _context.SaveChangesAsync();
        }
    }
}
