using AgileApp.DataTransferObject.Requests.Team;
using AgileApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgileAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService service;
        public TeamController(ITeamService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetTeams()
        {
            var teams = await service.GetTeamsAsync();
            return Ok(teams);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetTeam(int id)
        {
            var team = await service.GetTeamAsync(id);
            return Ok(team);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTeam(CreateNewTeamRequest request)
        {
            await service.CreateTeamAsync(request);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTeam(int id, UpdateExistingTeamRequest request)
        {
            await service.UpdateTeamAsync(request);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTeam(int id)
        {
            await service.DeleteTeamAsync(id);
            return Ok();
        }

    }
}
