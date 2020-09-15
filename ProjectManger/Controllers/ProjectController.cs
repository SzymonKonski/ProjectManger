using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
        private ProjectService _projectService = new ProjectService();


        [Route("")]
        [HttpGet]
        public IEnumerable<ProjectDetailDto> GetAll()
        {
            return _projectService.GetAllProjects();
        }

        [Route("{id}")]
        [HttpPost]
        public async Task Create([FromBody]  NewProjectDto project, long id)
        {
            await _projectService.CreateProject(project,id);
        }

        [Route("{id}")]
        [HttpGet]
        public ProjectDetailDto GetDetails(long id)
        {
            return _projectService.GetDetails(id);
        }

        [HttpPut("{id}/finish")]
        public void FinishProject(long id)
        {
            _projectService.FinishProject(id);
        }
    }
}
