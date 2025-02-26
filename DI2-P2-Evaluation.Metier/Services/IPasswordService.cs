using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DI2_P2_Evaluation.Metier.DTOs;

namespace DI2_P2_Evaluation.Domain.Interfaces
{
    public interface IPasswordService
    {
        Task<IEnumerable<PasswordDTO>> GetAllPasswords();
        Task<PasswordDTO> CreatePassword(PasswordDTO passwordDto);
        Task<bool> DeletePassword(int id);
        string EncryptPassword(string password, int encryptionType);
    }
}
