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
    public class EFTeamRepository : ITeamRepository
    {
        private readonly AgileAppDbContext context;
        public EFTeamRepository(AgileAppDbContext context)
        {
            this.context = context;
        }

        public async Task CreateAsync(Team entity)
        {
            await context.Team.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var deletingTeam = await context.Team.FindAsync(id);
            if (deletingTeam != null)
            {
                context.Team.Remove(deletingTeam);
            }
            await context.SaveChangesAsync();
        }

        public async Task<List<Team>> GetAllAsync()
        {
            return await context.Team.AsNoTracking().ToListAsync();
        }

        public async Task<Team> GetAsync(int id)
        {
            return await context.Team.AsNoTracking().FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task UpdateAsync(Team entity)
        {
            context.Team.Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
