using System.ComponentModel.DataAnnotations;

namespace Login.Models
{
    public class SEC_UserModel
    {
        public int? LoginId { get; set; }
        public string LoginName { get; set; }
        public string LoginPassword { get; set; }
    }
    public class UserLoginModel
    {
        [Required]
        public string LoginName { get; set; }
        [Required]
        public string LoginPassword { get; set; }
    }
}
