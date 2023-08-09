using AgileApp.Services;
using AgileAppMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AgileAppMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAssignmentService service;
        public HomeController(ILogger<HomeController> logger, IAssignmentService service)
        {
            _logger = logger;
            this.service = service;
        }

        public async Task<IActionResult> Index()
        {
            var todos = await service.GetAssignmentWithRespectToStatusAsync("To-Do");
            var inprogresses = await service.GetAssignmentWithRespectToStatusAsync("In Progress");
            var dones = await service.GetAssignmentWithRespectToStatusAsync("Done");
            var taskViewModel = new TaskViewModel
            {
                Dones = dones,
                InProgresses = inprogresses,
                ToDos = todos
            };
            return View(taskViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}