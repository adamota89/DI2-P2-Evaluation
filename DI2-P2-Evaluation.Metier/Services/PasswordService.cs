
using DI2_P2_Evaluation.Domain.Interfaces;
using DI2_P2_Evaluation.Infrastructure.Repositories;
using DI2_P2_Evaluation.Metier.DTOs;

namespace DI2_P2_Evaluation.Domain.Interfaces
{
    public class PasswordService : IPasswordService
    {
        private readonly IPasswordRepository _passwordRepository;

        public PasswordService(IPasswordRepository passwordRepository)
        {
            _passwordRepository = passwordRepository;
        }

        public async Task<IEnumerable<PasswordDTO>> GetAllPasswords()
        {
            var passwords = await _passwordRepository.GetAllPasswords();

            return passwords.Select(password => new PasswordDTO
            {
                Id = password.Id,
                EncryptedValue = password.EncryptedValue,
            });
        }
    }
}
