// Models/LoginViewModel.cs
// ViewModel para sa login form — validation rules lang, walang DB.

using System.ComponentModel.DataAnnotations;

namespace Dashboard.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "USERNAME IS REQUIRED.")]
        [Display(Name = "USERNAME")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "PASSWORD IS REQUIRED.")]
        [DataType(DataType.Password)]
        [Display(Name = "PASSWORD")]
        public string Password { get; set; } = string.Empty;
    }
}
