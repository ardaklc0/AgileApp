using AgileApp.DataTransferObject.Requests.Assignment;
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
        
        public async Task<IActionResult> Edit(int id)
        {
            var assignment = await assignmentService.GetAssignmentForUpdateAsync(id);
            return View(assignment);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, UpdateExistingAssignmentRequest request)
        {
            if (ModelState.IsValid)
            {
                await assignmentService.UpdateAssignmentAsync(request);
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            var existingAssignment = await assignmentService.GetAssignmentAsync(id);
            return View(existingAssignment);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (ModelState.IsValid)
            {
                await assignmentService.DeleteAssignmentAsync(id); 
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateNewAssignmentRequest request)
        {
            if (ModelState.IsValid)
            {
                await assignmentService.CreateAssignmentAsync(request);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
