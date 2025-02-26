using DI2_P2_Evaluation.Domain.Entities;
using DI2_P2_Evaluation.Domain.Interfaces;
using DI2_P2_Evaluation.Infrastructure;
using DI2_P2_Evaluation.Metier.DTOs;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace DI2_P2_Evaluation.Controllers
{
    [Route("api/")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IApplicationService _applicationService;

        public ApplicationController(ApplicationDbContext context, IApplicationService applicationService)
        {
            _context = context;
            _applicationService = applicationService;
        }

        [HttpGet("applications")]
        public async Task<ActionResult<IEnumerable<Application>>> GetApplications()
        {
            var applicationsDto = await _applicationService.GetAllApplications();

            return Ok(applicationsDto);
        }


        [HttpPost("applications")]
        public async Task<ActionResult<Application>> CreateApplication(ApplicationDTO applicationDto)
        {
            var addedApplication = await _applicationService.CreateApplication(applicationDto);

            return Ok(addedApplication);
        }
    }
}
