using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BugTracker.Interfaces;
using BugTracker.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BugTracker.Controllers
{
    public class AddWorkItemController : Controller
    {
        private readonly IWorkItemService _workItemService;

        public AddWorkItemController(IWorkItemService workItemService)
        {
            _workItemService = workItemService;
        }

        public ActionResult AddItem()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateWorkItem(AddWorkItem addWorkItem)
        {
            var workItem = new WorkItem(addWorkItem);
            _workItemService.InsertWorkItem(workItem);
            return RedirectToAction("Index", "Home");
        }
                
    }
}