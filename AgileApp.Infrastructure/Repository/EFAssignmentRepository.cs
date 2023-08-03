using AgileApp.Entities;
using AgileApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileApp.Infrastructure.Repository
{
    public class EFAssignmentRepository : IAssignmentRepository
    {
        private readonly AgileAppDbContext context;
        public EFAssignmentRepository(AgileAppDbContext context)
        {
            this.context = context;
        }

        public async Task CreateAsync(Assignment entity)
        {
            await context.Assignment.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var deletingAssignment = await context.Assignment.FindAsync(id);
            if (deletingAssignment != null)
            {
                context.Assignment.Remove(deletingAssignment);  
            }
            await context.SaveChangesAsync();
        }

        public async Task<List<Assignment>> GetAllAsync()
        {
            return await context.Assignment.AsNoTracking().ToListAsync();
        }

        public async Task<Assignment> GetAsync(int id)
        {
            return await context.Assignment.AsNoTracking().FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task UpdateAsync(Assignment entity)
        {
            context.Assignment.Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
