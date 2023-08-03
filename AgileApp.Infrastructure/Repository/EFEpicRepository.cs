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
    public class EFEpicRepository : IEpicRepository
    {
        private readonly AgileAppDbContext context;
        public EFEpicRepository(AgileAppDbContext context)
        {
            this.context = context;
        }

        public async Task CreateAsync(Epic entity)
        {
            await context.Epic.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var deletingEpic = await context.Epic.FindAsync(id);
            if (deletingEpic != null)
            {
                context.Epic.Remove(deletingEpic);
            }
            await context.SaveChangesAsync();
        }

        public async Task<List<Epic>> GetAllAsync()
        {
            return await context.Epic.AsNoTracking().ToListAsync();
        }

        public async Task<Epic> GetAsync(int id)
        {
            return await context.Epic.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task UpdateAsync(Epic entity)
        {
            context.Epic.Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
