using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NodaTime;


namespace AUDANEPAD_Integrated.Models
{
    public class LkUp_RegionScope
    {
        [Key]
        public int Record_Id { get; set; }

        [Required, MaxLength(255, ErrorMessage = "Name cannot exceed 255 characters")]
        public string Record_Name { get; set; }

        public bool Record_Status { get; set; }


        public LocalDate TransactionDate { get; set; }
        
    }
}