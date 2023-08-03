using AgileApp.DataTransferObject.Requests.Team;
using AgileApp.DataTransferObject.Responses.Team;
using AgileApp.Entities;
using AgileApp.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileApp.Services
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository repository;
        public TeamService(ITeamRepository repository)
        {
            this.repository = repository;
        }

        public async Task CreateTeamAsync(CreateNewTeamRequest request)
        {
            var team = new Team
            {
                Name = request.Name,
                CreationDate = request.CreationDate,
                Description = request.Description,
            };
            await repository.CreateAsync(team);
        }

        public async Task DeleteTeamAsync(int id)
        {
            await repository.DeleteAsync(id);
        }

        public async Task<GetTeamDisplayResponse> GetTeamAsync(int id)
        {
            var team = await repository.GetAsync(id);
            var response = new GetTeamDisplayResponse
            {
                Id = team.Id,
                Name = team.Name,
                Description = team.Description,
                CreationDate = team.CreationDate,
            };
            return response;
        }

        public async Task<IEnumerable<GetTeamDisplayResponse>> GetTeamsAsync()
        {
            var teams = await repository.GetAllAsync();
            var responses = teams.Select(team => new GetTeamDisplayResponse
            {
                Id = team.Id,
                Name = team.Name,
                Description = team.Description,
                CreationDate = team.CreationDate,
            });
            return responses;
        }

        public Task UpdateTeamAsync(UpdateExistingTeamRequest request)
        {
            var updatedTeam = new Team
            {
                Id = request.Id,
                Name = request.Name,
                Description = request.Description,
            };
            return repository.UpdateAsync(updatedTeam);
        }
    }
}
