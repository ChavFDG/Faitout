using Faitout.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Faitout.Services
{
    public class BaseService
    {
        protected readonly ApplicationDbContext _context;
        public BaseService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void ResetContextState()
        {
            _context.ChangeTracker.Entries()
                                  .Where(e => e.Entity != null).ToList()
                                  .ForEach(e => e.State = EntityState.Detached);
        }
    }
}
