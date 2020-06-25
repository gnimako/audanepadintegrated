using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NodaTime;

namespace AUDANEPAD_Integrated.Models
{
    public class Struc_DivStaffMapping
    {
        [Key]
        public string Transaction_Id { get; set; }
        public  int EmployeePK { get; set; }
        public string IdentityUserId { get; set; }
        [Required, MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public string Staff_Number { get; set; }
        public int Directorate_Id { get; set; }

        public int Division_Id { get; set; }

        public bool? Mapping_Status { get; set; }
        public bool? PrimaryDivision { get; set; }
        public LocalDate TransactionDate { get; set; }
        
    }
}