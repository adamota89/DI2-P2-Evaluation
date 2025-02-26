using DI2_P2_Evaluation.Domain.Entities;
using DI2_P2_Evaluation.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI2_P2_Evaluation.Infrastructure.Repositories
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly ApplicationDbContext _context;

        public ApplicationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Application> CreateApplication(Application application)
        {
            _context.Applications.Add(application);
            await _context.SaveChangesAsync();

            return application;
        }

        public async Task<IEnumerable<Application>> GetAllApplications()
        {
            return await _context.Applications.ToListAsync();
        }
    }
}
