using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileApp.DataTransferObject.Responses.AssignmentPage
{
    public class GetAssignmentPageDisplayResponse
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? PageLogo { get; set; }
        public string? Type { get; set; }
        public int UserId { get; set; }
    }
}
