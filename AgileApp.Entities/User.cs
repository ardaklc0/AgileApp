using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileApp.Entities
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Password { get; set; }
        public string? PhoneNumber { get; set; }
        public string Role { get; set; }
        public string? Address { get; set; }
        public Team Team { get; set; }
        public int TeamId { get; set; }
        public List<AssignmentPage>? AssignmentPages { get; set; }

    }
}
