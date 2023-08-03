using AgileApp.DataTransferObject.Requests.Epic;
using AgileApp.DataTransferObject.Responses.Epic;
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
    public class EpicService : IEpicService
    {
        private readonly IEpicRepository repository;
        public EpicService(IEpicRepository repository)
        {
            this.repository = repository;
        }

        public async Task CreateEpicAsync(CreateNewEpicRequest request)
        {
            var epic = new Epic
            {
                Name = request.Name,
                Description = request.Description,
                Details = request.Details,
                TeamId = request.TeamId,
                IsDone = request.IsDone,
            };
            await repository.CreateAsync(epic);
        }

        public async Task DeleteEpicAsync(int id)
        {
            await repository.DeleteAsync(id);
        }

        public async Task<GetEpicDisplayResponse> GetEpicAsync(int id)
        {
            var epic = await repository.GetAsync(id);
            var response = new GetEpicDisplayResponse
            {
                Id = epic.Id,
                Name = epic.Name,
                Description = epic.Description,
                Details = epic.Details,
                TeamId = epic.TeamId,
                IsDone = epic.IsDone,
            };
            return response;
        }

        public async Task<IEnumerable<GetEpicDisplayResponse>> GetEpicsAsync()
        {
            var epics = await repository.GetAllAsync();
            var responses = epics.Select(epic => new GetEpicDisplayResponse
            {
                Id = epic.Id,
                Name = epic.Name,
                Description = epic.Description,
                Details = epic.Details,
                TeamId = epic.TeamId,
                IsDone = epic.IsDone,
            });
            return responses;
        }

        public Task UpdateEpicAsync(UpdateExistingEpicRequest request)
        {
            var updatedEpic = new Epic
            {
                Id = request.Id,
                Name = request.Name,
                Description = request.Description,
                Details = request.Details,
                TeamId = request.TeamId,
                IsDone = request.IsDone,
            };
            return repository.UpdateAsync(updatedEpic);
        }
    }
}
