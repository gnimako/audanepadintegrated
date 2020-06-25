using System;
using System.ComponentModel.DataAnnotations;
using AUDANEPAD_Integrated.Utilities;


namespace AUDANEPAD_Integrated.ViewModels
{
    public class LoginViewModel
    {
        [Required]
		[EmailAddress]
        [ValidEmailDomain(allowedDomain: "nepad.org",
        ErrorMessage = "Email domain must be nepad.org")]
        public string Email { get; set; }

		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }

        public string requestlogin { get; set; }

		[Display(Name = "Remember me")]
		public bool RememberMe { get; set; }
        
    }
}