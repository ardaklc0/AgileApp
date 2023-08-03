using AgileApp.DataTransferObject.Requests.User;
using AgileApp.DataTransferObject.Responses;
using AgileApp.DataTransferObject.Responses.User;
using AgileApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileApp.Services
{
    public interface IUserService
    {
        Task<GetUserDisplayResponse> GetUserAsync(int id);
        Task<IEnumerable<GetUserDisplayResponse>> GetAllUsersAsync();
        Task<IEnumerable<GetUserDisplayResponse>> GetAllUsersWithRespectToTeamIdAsync(int teamId);
        Task<User> ValidateUserAsync(string username, string password);
        Task CreateUserAsync(CreateNewUserRequest request);
        Task DeleteUserAsync(int id);
        Task UpdateUserAsync(UpdateExistingUserRequest request);
    }
}
