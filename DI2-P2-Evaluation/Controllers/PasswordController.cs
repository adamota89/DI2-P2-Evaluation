using DI2_P2_Evaluation.Domain.Entities;
using DI2_P2_Evaluation.Domain.Interfaces;
using DI2_P2_Evaluation.Infrastructure;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace DI2_P2_Evaluation.Controllers
{
    [Route("api/")]
    [ApiController]
    public class PasswordController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IPasswordService _passwordService;

        public PasswordController(ApplicationDbContext context, IPasswordService passwordService)
        {
            _context = context;
            _passwordService = passwordService;
        }

        [HttpGet("passwords")]
        public async Task<ActionResult<IEnumerable<Password>>> GetPasswords()
        {
            var passwordsDto = await _passwordService.GetAllPasswords();

            return Ok(passwordsDto);
        }


    }
}
