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
        private TaskService _taskService = new TaskService();

        [HttpGet("{id}/task")]
        public IEnumerable<TaskListItemDto> GetTasks(long id)
        {
            return _taskService.GetTasks(id);
        }

        [HttpPost("{id}/task")]
        public async Task AddTask([FromBody] NewTaskDto task, long id)
        {
            await _taskService.AddTask(task, id);
        }

        [HttpPut("task/{id}")]
        public void ChangeTaskStatus([FromBody] ProjectTaskStatusDto status, long id)
        {
            status.Id = id;
            _taskService.ChangeStatus(status);
        }
    }
}
