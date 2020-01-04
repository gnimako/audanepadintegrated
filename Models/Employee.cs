using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NodaTime;


namespace AUDANEPAD_Integrated.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string IdentityUserId { get; set; }
        [Required, MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public string Staff_Number { get; set; }

        public int Directorate_Id { get; set; }
        public int Department_Id { get; set; }

        public int Rank { get; set; }

        public int RankStep { get; set; }

        public string PhotoPath { get; set; }

        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Email { get; set; }

        //[DataType(DataType.Date)]
        //[Column(TypeName = "Date")]
        public LocalDate DOB { get; set; }

       

        public int Gender { get; set; }
        public string Address_Street { get; set; }
        public string Address_City { get; set; }
        public string Address_State { get; set; }
        public string Address_PostCode { get; set; }
        public int Country { get; set; }

        public bool Employee_Status { get; set; }

        public LocalDate TransactionDate { get; set; }
        
    }
}