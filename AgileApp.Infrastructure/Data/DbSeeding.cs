using AgileApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileApp.Infrastructure.Data
{
    public static class DbSeeding
    {
        public static void SeedDatabase(AgileAppDbContext dbContext)
        {
            seedTeamIfNotExist(dbContext);
            seedUserIfNotExist(dbContext);
            seedEpicIfNotExist(dbContext);
            seedAssignmentPageIfNotExist(dbContext);
            seedAssignmentIfNotExist(dbContext);
        }

        private static void seedTeamIfNotExist(AgileAppDbContext dbContext)
        {
            if (!dbContext.Team.Any())
            {
                var team = new Team
                {
                    Name = "Workflow",
                    CreationDate = DateTime.Now,
                    Description = "Release process handled",
                };
                dbContext.Team.Add(team);
                dbContext.SaveChanges();
            }
        }

        private static void seedUserIfNotExist(AgileAppDbContext dbContext)
        {
            if (!dbContext.User.Any())
            {
                var user = new User
                {
                    Name = "Arda",
                    Surname = "Kılıç",
                    Address = "Küplüce",
                    BirthDate = DateTime.Now,
                    Description = "IT Personal",
                    Email = "ardaklc0@gmail.com",
                    Nickname = "ardaklc",
                    Password = "12345678,arda",
                    PhoneNumber = "5379129993",
                    Role = "client",
                    TeamId = 1,
                };
                dbContext.User.Add(user);
                dbContext.SaveChanges();
            }
        }
        private static void seedEpicIfNotExist(AgileAppDbContext dbContext)
        {
            if (!dbContext.Epic.Any())
            {
                var epic = new Epic
                {
                    Name = "Completing boiler plate code in Java",
                    Description = "Boiler plate codes must be handled in order to reduce code size",
                    TeamId = 1,
                    IsDone = false,
                    Details = "Boiler plate codes must be handled in order to reduce code size",
                };
                dbContext.Epic.Add(epic);
                dbContext.SaveChanges();
            }
        }

        private static void seedAssignmentPageIfNotExist(AgileAppDbContext dbContext)
        {
            if (!dbContext.AssignmentPage.Any())
            {
                var assignmentpage = new AssignmentPage
                {
                    Name = "Workflow PDM",
                    PageLogo = "logo",
                    Type = "kanban",
                    UserId = 1,
                };
                dbContext.AssignmentPage.Add(assignmentpage);
                dbContext.SaveChanges();
            }
        }

        private static void seedAssignmentIfNotExist(AgileAppDbContext dbContext)
        {
            if (!dbContext.Assignment.Any())
            {
                var assignment = new Assignment
                {
                    Name = "Lombok will be used",
                    UserId = 1,
                    Status = "To-Do",
                    CreationDate = DateTime.Now,
                    IsDone = false,
                    EpicId = 1,
                    AssignmentPageId = 1,
                };
                dbContext.Assignment.Add(assignment);
                dbContext.SaveChanges();
            }
        }
    }
}
