using AgileApp.DataTransferObject.Requests.AssignmentPage;
using AgileApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgileAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentPageController : ControllerBase
    {
        private readonly IAssignmentPageService service;
        public AssignmentPageController(IAssignmentPageService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAssignmentPages()
        {
            var assignmentPages = await service.GetAssignmentPagesAsync();
            return Ok(assignmentPages);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAssignmentPage(int id)
        {
            var assignmentPage = await service.GetAssignmentPageAsync(id);
            return Ok(assignmentPage);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAssignment(CreateNewAssignmentPageRequest request)
        {
            await service.CreateAssignmentPageAsync(request);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAssignmentPage(int id, UpdateExistingAssignmentPageRequest request)
        {
            await service.UpdateAssignmentPageAsync(request);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAssignment(int id)
        {
            await service.DeleteAssignmentPageAsync(id);
            return Ok();
        }
    }
}
