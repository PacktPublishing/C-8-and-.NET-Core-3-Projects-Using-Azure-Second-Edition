using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BugTracker.Models;
using MongoDB.Driver;
using Microsoft.Extensions.Options;
using BugTracker.Data;
using BugTracker.Interfaces;

namespace BugTracker.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWorkItemService _workItemService;

        public HomeController(IWorkItemService workItemService)
        {
            _workItemService = workItemService;            
        }
        public IActionResult Index()
        {
            var workItems = _workItemService.GetAllWorkItems();
            return View(workItems);
        }

        public ActionResult AddWorkItem()
        {
            return RedirectToAction("AddItem", "AddWorkItem");
        }

        











        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
