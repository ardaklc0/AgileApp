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
    public class EFUserRepository : IUserRepository
    {
        private readonly AgileAppDbContext context;
        public EFUserRepository(AgileAppDbContext context)
        {
            this.context = context;
        }

        public async Task CreateAsync(User entity)
        {
            await context.User.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var deletingUser = await context.User.FindAsync(id);
            if (deletingUser != null)
            {
                context.User.Remove(deletingUser);
            }
            await context.SaveChangesAsync();
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await context.User.AsNoTracking().ToListAsync();
        }

        public async Task<User> GetAsync(int id)
        {
            return await context.User.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task UpdateAsync(User entity)
        {
            context.User.Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
