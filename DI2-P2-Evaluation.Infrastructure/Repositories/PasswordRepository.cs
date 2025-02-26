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
    public class PasswordRepository : IPasswordRepository
    {
        private readonly ApplicationDbContext _context;

        public PasswordRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Password>> GetAllPasswords()
        {
            return await _context.Passwords.ToListAsync();
        }
    }
}
