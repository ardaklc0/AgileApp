using AgileApp.DataTransferObject.Requests.AssignmentPage;
using AgileApp.DataTransferObject.Responses.AssignmentPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileApp.Services
{
    public interface IAssignmentPageService
    {
        Task<GetAssignmentPageDisplayResponse> GetAssignmentPageAsync(int id);
        Task<IEnumerable<GetAssignmentPageDisplayResponse>> GetAssignmentPagesAsync();
        Task CreateAssignmentPageAsync(CreateNewAssignmentPageRequest request);
        Task DeleteAssignmentPageAsync(int id);
        Task UpdateAssignmentPageAsync(UpdateExistingAssignmentPageRequest request);
    }
}
