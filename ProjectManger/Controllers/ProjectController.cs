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
    public class ProjectController : ControllerBase
    {
        private ProjectService projectService = new ProjectService();

        [Route("")]
        [HttpPost]
        public async Task<long> Create(NewProjectDto project)
        {
            return await projectService.CreateProject(project);
        }

        [Route(":id")]
        [HttpGet]
        public ProjectDetailDto GetDetails([FromQuery]long id)
        {
            return projectService.GetDetails(id);
        }

        [Route("{id}/task")]
        [HttpGet]
        public IEnumerable<TaskListItemDto> GetTasks(long id)
        {
            return projectService.GetTasks(id)
        }

    }
}
