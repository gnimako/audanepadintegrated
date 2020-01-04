using System;
using Microsoft.AspNetCore.Identity;
using NodaTime;

namespace AUDANEPAD_Integrated.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string Staff_Number { get; set; }
        public bool Admin_Generated { get; set; }
        public int Employee_Id { get; set; }
        public LocalDate TransactionDate { get; set; }
        
    }
}