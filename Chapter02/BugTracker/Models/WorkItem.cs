using MongoDB.Bson;

namespace BugTracker.Models
{
    public class WorkItem
    {
        public ObjectId Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Severity { get; set; }
        public string WorkItemType { get; set; }
        public string AssignedTo { get; set; }

        public WorkItem()
        {

        }

        public WorkItem(AddWorkItem addWorkItem)
        {
            Title = addWorkItem.Title;
            Description = addWorkItem.Description;
            Severity = addWorkItem.Severity;
            WorkItemType = addWorkItem.WorkItemType;
            AssignedTo = addWorkItem.AssignedTo;
        }
    }
}
