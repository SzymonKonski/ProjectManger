using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManger.Dtos;
using ProjectManger.Services;

namespace ProjectManger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private TaskService taskService = new TaskService();

        [Route("")]
        [HttpGet]
        public IEnumerable<TaskListItemDto> GetTasks(long id)
        {
            return taskService.GetTasks(id);
        }

        [Route("")]
        [HttpPost]
        public async Task AddTask([FromBody] NewTaskDto task, long id)
        {
            await taskService.AddTask(task, id);
        }
    }
}
