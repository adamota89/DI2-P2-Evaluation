using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DI2_P2_Evaluation.Metier.DTOs;

namespace DI2_P2_Evaluation.Domain.Interfaces
{
    public interface IApplicationService
    {
        Task<IEnumerable<ApplicationDTO>> GetAllApplications();

    }
}
