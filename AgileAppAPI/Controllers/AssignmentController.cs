using AgileApp.DataTransferObject.Requests.Assignment;
using AgileApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgileAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentController : ControllerBase
    {
        private readonly IAssignmentService service;
        public AssignmentController(IAssignmentService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAssignments()
        {
            var assignments = await service.GetAssignmentsAsync();
            return Ok(assignments);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAssignment(int id)
        {
            var assignment = await service.GetAssignmentAsync(id);
            return Ok(assignment);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAssignment(CreateNewAssignmentRequest request)
        {
            await service.CreateAssignmentAsync(request);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAssignment(int id, UpdateExistingAssignmentRequest request)
        {
            await service.UpdateAssignmentAsync(request);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAssignment(int id)
        {
            await service.DeleteAssignmentAsync(id);
            return Ok();
        }
    }
}
