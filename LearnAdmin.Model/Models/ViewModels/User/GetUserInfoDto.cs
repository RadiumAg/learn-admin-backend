using System.ComponentModel.DataAnnotations;

namespace LearnAdmin.Dto.User
{
    public class GetUserInfoDto
    {
        [Required(ErrorMessage = "Name is required.")]
        public string Account { get; set; }


        [Required(ErrorMessage = "Name is required.")]
        public string Password { get; set; }
    }


}
