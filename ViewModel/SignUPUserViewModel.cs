using MVCExamProject.Models;
using System.ComponentModel.DataAnnotations;

namespace MVCExamProject.ViewModel
{
	public class SignUPUserViewModel
	{
		[MaxLength(25)]
		[MinLength(3)]
		[Required]
		public string Name { get; set; }
<<<<<<< HEAD
		public int? Age { get; set; }
=======
		public int? Age{get; set;}
>>>>>>> started-from-usel-claims-fix
		[Required]
		[EmailAddress]
		public string Email { get; set; }
		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }
		[MaxLength(40)]
<<<<<<< HEAD

=======
		
>>>>>>> started-from-usel-claims-fix

		[DataType(DataType.Password)]
		[Compare("Password")]
		public string ConfirmPassword { get; set; }

		public bool IsAdmin { get; set; } = false;
		public List<UserExam>? UserExams { get; set; }
	}

<<<<<<< HEAD
}
=======
}
>>>>>>> started-from-usel-claims-fix
