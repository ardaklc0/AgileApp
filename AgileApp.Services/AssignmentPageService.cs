using AgileApp.DataTransferObject.Requests.AssignmentPage;
using AgileApp.DataTransferObject.Responses.AssignmentPage;
using AgileApp.Entities;
using AgileApp.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileApp.Services
{
    public class AssignmentPageService : IAssignmentPageService
    {
        private readonly IAssignmentPageRepository repository; 
        public AssignmentPageService(IAssignmentPageRepository repository)
        {
            this.repository = repository;
        }

        public async Task CreateAssignmentPageAsync(CreateNewAssignmentPageRequest request)
        {
            var assignmentPage = new AssignmentPage
            {
                Name = request.Name,
                PageLogo = request.PageLogo,
                Type = request.Type,
                UserId = request.UserId,
            };
            await repository.CreateAsync(assignmentPage);
        }

        public async Task DeleteAssignmentPageAsync(int id)
        {
            await repository.DeleteAsync(id);
        }

        public async Task<GetAssignmentPageDisplayResponse> GetAssignmentPageAsync(int id)
        {
            var assignmentPage = await repository.GetAsync(id);
            var response = new GetAssignmentPageDisplayResponse
            {
                Id = assignmentPage.Id,
                Name = assignmentPage.Name,
                PageLogo = assignmentPage.PageLogo,
                Type = assignmentPage.Type,
                UserId = assignmentPage.UserId,
            };
            return response;
        }

        public async Task<IEnumerable<GetAssignmentPageDisplayResponse>> GetAssignmentPagesAsync()
        {
            var assignmentPages = await repository.GetAllAsync();
            var responses = assignmentPages.Select(assignmentPage => new GetAssignmentPageDisplayResponse
            {
                Id = assignmentPage.Id,
                Name = assignmentPage.Name,
                PageLogo = assignmentPage.PageLogo,
                Type = assignmentPage.Type,
                UserId = assignmentPage.UserId,
            });
            return responses;
        }

        public Task UpdateAssignmentPageAsync(UpdateExistingAssignmentPageRequest request)
        {
            var updatedAssignmentPage = new AssignmentPage
            {
                Id = request.Id,
                Name = request.Name,
                PageLogo = request.PageLogo,
                Type = request.Type,
                UserId = request.UserId,
            };
            return repository.UpdateAsync(updatedAssignmentPage);
        }
    }
}
