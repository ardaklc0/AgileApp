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
    public class EFAssignmentPageRepository : IAssignmentPageRepository
    {
        private readonly AgileAppDbContext context;
        public EFAssignmentPageRepository(AgileAppDbContext context)
        {
            this.context = context;
        }

        public async Task CreateAsync(AssignmentPage entity)
        {
            await context.AssignmentPage.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var deletingAssignmentPage = await context.AssignmentPage.FindAsync(id);
            if (deletingAssignmentPage != null)
            {
                context.AssignmentPage.Remove(deletingAssignmentPage);
            }
            await context.SaveChangesAsync();
        }

        public async Task<List<AssignmentPage>> GetAllAsync()
        {
            return await context.AssignmentPage.AsNoTracking().ToListAsync();
        }

        public async Task<AssignmentPage> GetAsync(int id)
        {
            return await context.AssignmentPage.AsNoTracking().FirstOrDefaultAsync(ap => ap.Id == id);
        }

        public async Task UpdateAsync(AssignmentPage entity)
        {
            context.AssignmentPage.Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
