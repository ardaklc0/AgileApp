using AgileApp.DataTransferObject.Responses.Assignment;
using AgileApp.DataTransferObject.Responses.Epic;
using AgileApp.DataTransferObject.Responses.User;

namespace AgileAppMVC.Models
{
    public class AssignmentEpicUserViewModel
    {
        public IEnumerable<GetAssignmentDisplayResponse> assignments { get; set; }
        public IEnumerable<GetEpicDisplayResponse> epics { get; set; }
        public IEnumerable<GetUserDisplayResponse> users { get; set; }
    }
}
