﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileApp.Entities
{
    public class Assignment : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public User? User { get; set; }
        public int? UserId { get; set; }
        public string Status { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? DueDate { get; set; }
        public string? Comment { get; set; }
        public string? Details { get; set; }
        public bool IsDone { get; set; }
        public Epic Epic{ get; set; }
        public int EpicId { get; set; }
        public AssignmentPage AssignmentPage { get; set; }
        public int AssignmentPageId { get; set; }
        public string? AssignmentLogo { get; set; }

    }
}
