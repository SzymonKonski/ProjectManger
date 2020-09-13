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
        [HttpGet]
        public IEnumerable<ProjectDetailDto> GetAll()
        {
            return projectService.GetAllProjects();
        }

        [Route("")]
        [HttpPost]
        public async Task<long> Create(NewProjectDto project)
        {
            return await projectService.CreateProject(project);
        }

        [Route("{id}")]
        [HttpGet]
        public ProjectDetailDto GetDetails(long id)
        {
            return projectService.GetDetails(id);
        }
    }
}
