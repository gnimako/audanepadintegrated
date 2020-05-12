using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NodaTime;

namespace AUDANEPAD_Integrated.Models
{
    public class Struc_Division
    {
        [Key]
        public int Record_Id { get; set; }

        [Required, MaxLength(255, ErrorMessage = "Name cannot exceed 255 characters")]
        public int Directorate_Id { get; set; }
        public string Record_Name { get; set; }

        public bool? Record_Status { get; set; }


        public LocalDate TransactionDate { get; set; }
        
    }
}