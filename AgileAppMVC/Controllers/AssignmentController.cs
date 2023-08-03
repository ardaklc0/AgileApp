using AgileApp.Services;
using AgileAppMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace AgileAppMVC.Controllers
{
    public class AssignmentController : Controller
    {
        private readonly IAssignmentService assignmentService;
        private readonly IEpicService epicService;
        private readonly IUserService userService;
        public AssignmentController(IAssignmentService assignmentService, IEpicService epicService, IUserService userService)
        {
            this.assignmentService = assignmentService;
            this.epicService = epicService;
            this.userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            var assignments = await assignmentService.GetAssignmentsAsync();
            var epics = await epicService.GetEpicsAsync();
            var users = await userService.GetAllUsersAsync();
            var assignmentEpicViewModel = new AssignmentEpicUserViewModel
            {
                assignments = assignments,
                epics = epics,
                users = users
            };
            return View(assignmentEpicViewModel);
        }
    }
}
