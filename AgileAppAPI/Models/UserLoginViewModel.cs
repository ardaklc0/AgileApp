using System.ComponentModel.DataAnnotations;

namespace AgileAppAPI.Models
{
    public class UserLoginViewModel
    {
        [Required(ErrorMessage = "Username cannot be empty")]
        public string Nickname { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
