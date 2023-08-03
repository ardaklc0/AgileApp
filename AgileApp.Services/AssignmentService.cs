using AgileApp.DataTransferObject.Requests.Assignment;
using AgileApp.DataTransferObject.Responses.Assignment;
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
    public class AssignmentService : IAssignmentService
    {
        private readonly IAssignmentRepository repository;
        public AssignmentService(IAssignmentRepository repository)
        {
            this.repository = repository;
        }

        public async Task CreateAssignmentAsync(CreateNewAssignmentRequest request)
        {
            var assignment = new Assignment
            {
                Name = request.Name,
                UserId = request.UserId,
                Status = request.Status,
                CreationDate = request.CreationDate,
                DueDate = request.DueDate,
                Comment = request.Comment,
                Details = request.Details,
                IsDone = request.IsDone,
                EpicId = request.EpicId,
                AssignmentPageId = request.AssignmentPageId,
                AssignmentLogo = request.AssignmentLogo,
            };
            await repository.CreateAsync(assignment);
        }

        public async Task DeleteAssignmentAsync(int id)
        {
            await repository.DeleteAsync(id);
        }

        public async Task<GetAssignmentDisplayResponse> GetAssignmentAsync(int id)
        {
            var assignment = await repository.GetAsync(id);
            var response = new GetAssignmentDisplayResponse
            {
                Id = assignment.Id,
                Name = assignment.Name,
                UserId = assignment.UserId,
                Status = assignment.Status,
                CreationDate = assignment.CreationDate,
                DueDate = assignment.DueDate,
                Comment = assignment.Comment,
                Details = assignment.Details,
                IsDone = assignment.IsDone,
                EpicId = assignment.EpicId,
                AssignmentPageId = assignment.AssignmentPageId,
                AssignmentLogo = assignment.AssignmentLogo,
            };
            return response;
        }

        public async Task<IEnumerable<GetAssignmentDisplayResponse>> GetAssignmentsAsync()
        {
            var assignments = await repository.GetAllAsync();
            var responses = assignments.Select(assignment => new GetAssignmentDisplayResponse
            {
                Id = assignment.Id,
                Name = assignment.Name,
                UserId = assignment.UserId,
                Status = assignment.Status,
                CreationDate = assignment.CreationDate,
                DueDate = assignment.DueDate,
                Comment = assignment.Comment,
                Details = assignment.Details,
                IsDone = assignment.IsDone,
                EpicId = assignment.EpicId,
                AssignmentPageId = assignment.AssignmentPageId,
                AssignmentLogo = assignment.AssignmentLogo,
            });
            return responses;
        }

        public Task UpdateAssignmentAsync(UpdateExistingAssignmentRequest request)
        {
            var updatedAssignment = new Assignment
            {
                Id = request.Id,
                Name = request.Name,
                UserId = request.UserId,
                Status = request.Status,
                CreationDate = request.CreationDate,
                DueDate = request.DueDate,
                Comment = request.Comment,
                Details = request.Details,
                IsDone = request.IsDone,
                EpicId = request.EpicId,
                AssignmentPageId = request.AssignmentPageId,
                AssignmentLogo = request.AssignmentLogo,
            };
            return repository.UpdateAsync(updatedAssignment);
        }
    }
}
