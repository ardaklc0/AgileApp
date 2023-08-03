using AgileApp.DataTransferObject.Requests.Epic;
using AgileApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgileAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EpicController : ControllerBase
    {
        private readonly IEpicService service;
        public EpicController(IEpicService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetEpics()
        {
            var epics = await service.GetEpicsAsync();
            return Ok(epics);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetEpic(int id)
        {
            var epic = await service.GetEpicAsync(id);
            return Ok(epic); 
        }

        [HttpPost]
        public async Task<IActionResult> CreateEpic(CreateNewEpicRequest request)
        {
            await service.CreateEpicAsync(request);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEpic(int id, UpdateExistingEpicRequest request)
        {
            await service.UpdateEpicAsync(request);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteEpic(int id)
        {
            await service.DeleteEpicAsync(id);
            return Ok();
        }
    }
}
