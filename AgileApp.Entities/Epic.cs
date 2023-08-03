using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileApp.Entities
{
    public class Epic : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Details { get; set; }
        public Team? Team { get; set; }
        public int? TeamId { get; set; }
        public bool IsDone { get; set; }
        public List<Assignment>? Assignments { get; set; }

    }
}
