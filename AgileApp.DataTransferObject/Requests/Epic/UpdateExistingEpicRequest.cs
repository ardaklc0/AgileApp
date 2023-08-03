using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileApp.DataTransferObject.Requests.Epic
{
    public class UpdateExistingEpicRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Details { get; set; }
        public int? TeamId { get; set; }
        public bool IsDone { get; set; }

    }
}
