using System.ComponentModel.DataAnnotations;

namespace MVCExamProject.ViewModel
{
    public class SignUPUserViewModel
    {
        public string Name { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string? Email { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
