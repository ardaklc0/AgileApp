using AgileApp.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileApp.Infrastructure.Data
{
    public class AgileAppDbContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Team> Team { get; set; }
        public DbSet<Epic> Epic { get; set; }
        public DbSet<Assignment> Assignment { get; set; }
        public DbSet<AssignmentPage> AssignmentPage { get; set; }
        
        public AgileAppDbContext(DbContextOptions<AgileAppDbContext> options) : base(options)
        {

        }

    }
}
