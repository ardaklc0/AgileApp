using AgileApp.Infrastructure.Data;
using AgileApp.Infrastructure.Repository;
using AgileApp.Services;
using Microsoft.EntityFrameworkCore;

namespace AgileAppAPI.Extensions
{
    public static class IoCExtension
    {
        public static IServiceCollection AddInjections(this IServiceCollection services, string connectionString)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUserRepository, EFUserRepository>();
            services.AddScoped<ITeamService, TeamService>();
            services.AddScoped<ITeamRepository, EFTeamRepository>();
            services.AddScoped<IEpicService, EpicService>();
            services.AddScoped<IEpicRepository, EFEpicRepository>();
            services.AddScoped<IAssignmentService, AssignmentService>();
            services.AddScoped<IAssignmentRepository, EFAssignmentRepository>();
            services.AddScoped<IAssignmentPageService, AssignmentPageService>();
            services.AddScoped<IAssignmentPageRepository, EFAssignmentPageRepository>();

            services.AddDbContext<AgileAppDbContext>(opt => opt.UseSqlServer(connectionString));
            return services;
        }
    }
}
