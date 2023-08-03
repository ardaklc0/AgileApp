using AgileApp.DataTransferObject.Requests.Team;
using AgileApp.DataTransferObject.Responses.Team;
using AgileApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileApp.Services
{
    public interface ITeamService
    {
        Task<GetTeamDisplayResponse> GetTeamAsync(int id);
        Task<IEnumerable<GetTeamDisplayResponse>> GetTeamsAsync();
        Task CreateTeamAsync(CreateNewTeamRequest request);
        Task DeleteTeamAsync(int id);
        Task UpdateTeamAsync(UpdateExistingTeamRequest request);
    }
}
