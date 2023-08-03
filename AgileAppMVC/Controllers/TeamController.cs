using AgileApp.Services;
using AgileAppMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace AgileAppMVC.Controllers
{
    public class TeamController : Controller
    {
        private readonly ITeamService teamService;
        private readonly IUserService userService;
        public TeamController(ITeamService teamService, IUserService userService)
        {
            this.teamService = teamService;
            this.userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            var teams = await teamService.GetTeamsAsync();
            return View(teams);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> ShowUserWithTeams(int teamId)
        {
            var users = await userService.GetAllUsersWithRespectToTeamIdAsync(teamId);
            var teams = await teamService.GetTeamsAsync();
            var teamUserViewModel = new TeamUserViewModel
            {
                users = users,
                teams = teams
            };
            return View(teamUserViewModel);
        }
    }
}
