using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.Models
{
    public class AddWorkItem
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Severity { get; set; }
        public string WorkItemType { get; set; }
        public string AssignedTo { get; set; }
    }
}
