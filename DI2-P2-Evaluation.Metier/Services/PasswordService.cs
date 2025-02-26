
using DI2_P2_Evaluation.Domain.Entities;
using DI2_P2_Evaluation.Domain.Interfaces;
using DI2_P2_Evaluation.Infrastructure.Repositories;
using DI2_P2_Evaluation.Metier.DTOs;
using DI2_P2_Evaluation.Metier.Services.Encryption;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Buffers.Text;

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

        public async Task<PasswordDTO> CreatePassword(PasswordDTO passwordDto)
        {
            Password password = new Password
            {
                EncryptedValue = passwordDto.EncryptedValue
            };

            var addedPassword = await _passwordRepository.CreatePassword(password);

            return new PasswordDTO
            {
                Id = addedPassword.Id,
                EncryptedValue = addedPassword.EncryptedValue,
            };
        }

        public async Task<bool> DeletePassword(int id)
        {
            await _passwordRepository.DeletePassword(id);
            return true;
        }

        public string EncryptPassword(string password, int encryptionType)
        {
            ApplicationType appType = (ApplicationType)encryptionType;

            if (appType == ApplicationType.GeneralPublic)
            {
                AESEncryptionStrategy encryptionStrategy = new AESEncryptionStrategy();
                string key = encryptionStrategy.GenerateKey();

                return encryptionStrategy.Encrypt(password, key);
            }
            else
            {
                RSAEncryptionStrategy encryptionStrategy = new RSAEncryptionStrategy();
                var (publicKey, privateKey) = encryptionStrategy.GenerateKeys();

                return encryptionStrategy.Encrypt(password, publicKey);
            }
        }
    }
}
