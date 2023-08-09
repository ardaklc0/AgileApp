using AgileApp.DataTransferObject.Responses.Assignment;
using AgileApp.Entities;

namespace AgileAppMVC.Models
{
    public class TaskViewModel
    {
        public IEnumerable<GetAssignmentDisplayResponse> ToDos { get; set; }
        public IEnumerable<GetAssignmentDisplayResponse> InProgresses { get; set; }
        public IEnumerable<GetAssignmentDisplayResponse> Dones { get; set; }
    }
}
