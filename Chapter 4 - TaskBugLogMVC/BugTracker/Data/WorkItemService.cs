using System.Collections.Generic;
using System.Threading.Tasks;
using BugTracker.Interfaces;
using BugTracker.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace BugTracker.Data
{
    public class WorkItemService : IWorkItemService
    {
        private readonly MongoDBRepository repository;

        public WorkItemService(IOptions<Settings> settings)
        {
            repository = new MongoDBRepository(settings);
        }
        
        IEnumerable<WorkItem> IWorkItemService.GetAllWorkItems()
        {
            return repository.WorkItems.Find(x => true).ToList();
        }
                
        public void InsertWorkItem(WorkItem workItem)
        {
            repository.WorkItems.InsertOne(workItem);
        }
    }
}































