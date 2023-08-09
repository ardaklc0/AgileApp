using AgileApp.DataTransferObject.Requests.Assignment;
using AgileApp.DataTransferObject.Responses.Assignment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileApp.Services
{
    public interface IAssignmentService
    {
        Task<GetAssignmentDisplayResponse> GetAssignmentAsync(int id);
        Task<UpdateExistingAssignmentRequest> GetAssignmentForUpdateAsync(int id);

        Task<IEnumerable<GetAssignmentDisplayResponse>> GetAssignmentsAsync();
        Task<IEnumerable<GetAssignmentDisplayResponse>> GetAssignmentWithRespectToStatusAsync(string status);
        Task CreateAssignmentAsync(CreateNewAssignmentRequest request);
        Task DeleteAssignmentAsync(int id);
        Task UpdateAssignmentAsync(UpdateExistingAssignmentRequest request);
    }
}
