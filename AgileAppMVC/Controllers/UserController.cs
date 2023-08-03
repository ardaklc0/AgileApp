using AgileApp.Services;
using AgileAppMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace AgileAppMVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService userService;
        private readonly ITeamService teamService;
        public UserController(IUserService userService, ITeamService teamService)
        {
            this.userService = userService;
            this.teamService = teamService;
        }

        public async Task<IActionResult> Index()
        {
            var users = await userService.GetAllUsersAsync();
            var teams = await teamService.GetTeamsAsync();
            var teamUserViewModel = new TeamUserViewModel
            {
                teams = teams,
                users = users
            };
            return View(teamUserViewModel);
        }
    }
}
