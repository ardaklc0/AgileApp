using AgileApp.DataTransferObject.Requests.User;
using AgileApp.DataTransferObject.Responses.User;
using AgileApp.Entities;
using AgileApp.Infrastructure.Repository;
using Azure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileApp.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository repository;
        public UserService(IUserRepository repository)
        {
            this.repository = repository;
        }

        public async Task CreateUserAsync(CreateNewUserRequest request)
        {
            var user = new User
            {
                Name = request.Name,
                Surname = request.Surname,
                Nickname = request.Nickname,
                Email = request.Email,
                Description = request.Description,
                BirthDate = request.BirthDate,
                Password = request.Password,
                PhoneNumber = request.PhoneNumber,
                Role = request.Role,
                Address = request.Address,
                TeamId = request.TeamId,
            };
            await repository.CreateAsync(user);
        }

        public async Task DeleteUserAsync(int id)
        {
            await repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<GetUserDisplayResponse>> GetAllUsersAsync()
        {
            var users = await repository.GetAllAsync();
            var responses = users.Select(user => new GetUserDisplayResponse
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                Nickname = user.Nickname,
                Email = user.Email,
                Description = user.Description,
                BirthDate = user.BirthDate,
                Password = user.Password,
                PhoneNumber = user.PhoneNumber,
                Role = user.Role,
                Address = user.Address,
                TeamId = user.TeamId,
            });
            return responses;
        }

        public async Task<IEnumerable<GetUserDisplayResponse>> GetAllUsersWithRespectToTeamIdAsync(int teamId)
        {
            var users = await repository.GetAllAsync();
            var selectedUsers = users.Where(user => user.TeamId == teamId);
            var responses = selectedUsers.Select(user => new GetUserDisplayResponse
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                Nickname = user.Nickname,
                Email = user.Email,
                Description = user.Description,
                BirthDate = user.BirthDate,
                Password = user.Password,
                PhoneNumber = user.PhoneNumber,
                Role = user.Role,
                Address = user.Address,
                TeamId = user.TeamId,
            });
            return responses;
        }

        public async Task<GetUserDisplayResponse> GetUserAsync(int id)
        {
            var user = await repository.GetAsync(id);
            var response = new GetUserDisplayResponse 
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                Nickname = user.Nickname,
                Email = user.Email,
                Description = user.Description,
                BirthDate = user.BirthDate,
                Password = user.Password,
                PhoneNumber = user.PhoneNumber,
                Role = user.Role,
                Address = user.Address,
                TeamId = user.TeamId,
            };
            return response;
        }

        public Task UpdateUserAsync(UpdateExistingUserRequest request)
        {
            var updatedUser = new User
            {
                Id = request.Id,
                Name = request.Name,
                Surname = request.Surname,
                Nickname = request.Nickname,
                Email = request.Email,
                Description = request.Description,
                BirthDate = request.BirthDate,
                Password = request.Password,
                PhoneNumber = request.PhoneNumber,
                Role = request.Role,
                Address = request.Address,
                TeamId = request.TeamId,
            };
            return repository.UpdateAsync(updatedUser);
        }

        public async Task<User> ValidateUserAsync(string username, string password)
        {
            var users = await repository.GetAllAsync();
            return users.SingleOrDefault(u => u.Nickname == username && u.Password == password);
        }
    }
}
