using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManger.Dtos;
using ProjectManger.Services;

namespace ProjectManger.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private ProjectService _projectService = new ProjectService();


        [HttpGet]
        public IEnumerable<ProjectDetailDto> GetAll()
        {
            return _projectService.GetAllProjects();
        }

        [HttpPost]
        public async Task Create(NewProjectDto project)
        {
            await _projectService.CreateProject(project);
        }

        [HttpGet("{id}")]
        public ProjectDetailDto GetDetails(long id)
        {
            return _projectService.GetDetails(id);
        }

        [HttpPut("{id}/finish")]
        public void FinishProject(long id)
        {
            _projectService.FinishProject(id);
        }

        [HttpGet("statistic")]
        public IEnumerable<ProjectTasksDto> GetStatistics()
        {
            return _projectService.GetProjectTasksStatistic();
        }
    }
}
