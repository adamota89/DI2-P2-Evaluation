using DI2_P2_Evaluation.Domain.Entities;
using DI2_P2_Evaluation.Domain.Interfaces;
using DI2_P2_Evaluation.Infrastructure;
using DI2_P2_Evaluation.Metier.DTOs;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
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

        [HttpPost("passwords")]
        public async Task<ActionResult<Password>> CreatePassword(PasswordDTO passwordDto)
        {
            var encryptedPassword = _passwordService.EncryptPassword(passwordDto.EncryptedValue, 0);
            passwordDto.EncryptedValue = encryptedPassword;
                
            var addedPassword = await _passwordService.CreatePassword(passwordDto);

            return Ok(addedPassword);
        }

        [HttpDelete("passwords/{id}")]
        public async Task<ActionResult<Password>> DeletePassword(int id)
        {
            var isPasswordDeleted = await _passwordService.DeletePassword(id);

            if (!isPasswordDeleted)
            {
                return NotFound();
            }

            return Ok(isPasswordDeleted);
        }

    }
}
