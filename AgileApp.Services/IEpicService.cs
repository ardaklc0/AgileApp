using AgileApp.DataTransferObject.Requests.Epic;
using AgileApp.DataTransferObject.Responses.Epic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileApp.Services
{
    public interface IEpicService
    {
        Task<GetEpicDisplayResponse> GetEpicAsync(int id);
        Task<IEnumerable<GetEpicDisplayResponse>> GetEpicsAsync();
        Task CreateEpicAsync(CreateNewEpicRequest request);
        Task DeleteEpicAsync(int id);
        Task UpdateEpicAsync(UpdateExistingEpicRequest request);
    }
}
