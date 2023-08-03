using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileApp.Entities
{
    public class AssignmentPage : IEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? PageLogo { get; set; }
        public string? Type { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public List<Assignment>? Assignments { get; set; }

    }
}
