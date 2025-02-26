using DI2_P2_Evaluation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI2_P2_Evaluation.Domain.Interfaces
{
    public interface IPasswordRepository
    {
        Task<IEnumerable<Password>> GetAllPasswords();

    }
}
