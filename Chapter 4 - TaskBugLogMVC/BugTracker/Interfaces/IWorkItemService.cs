using BugTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.Interfaces
{
    public interface IWorkItemService
    {
        IEnumerable<WorkItem> GetAllWorkItems();
        void InsertWorkItem(WorkItem workItem);
    }
}
