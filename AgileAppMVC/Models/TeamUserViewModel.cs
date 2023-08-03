using AgileApp.DataTransferObject.Responses.Team;
using AgileApp.DataTransferObject.Responses.User;

namespace AgileAppMVC.Models
{
    public class TeamUserViewModel
    {
        public IEnumerable<GetTeamDisplayResponse> teams { get; set; }
        public IEnumerable<GetUserDisplayResponse> users { get; set; }
    }
}
