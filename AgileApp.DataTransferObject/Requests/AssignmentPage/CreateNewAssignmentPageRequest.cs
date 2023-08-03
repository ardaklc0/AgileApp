using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileApp.DataTransferObject.Requests.AssignmentPage
{
    public class CreateNewAssignmentPageRequest
    {
        public string? Name { get; set; }
        public string? PageLogo { get; set; }
        public string? Type { get; set; }
        public int UserId { get; set; }

    }
}
