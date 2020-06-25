using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NodaTime;

namespace AUDANEPAD_Integrated.Models
{
    public class LkUp_DSAType
    {
        [Key]
        public int DSA_Id { get; set; }

        [Required, MaxLength(255, ErrorMessage = "Name cannot exceed 255 characters")]
        public string DSA_Name { get; set; }

        public float DSA_Value { get; set; }

        public bool DSAType_Status { get; set; }

        //public DateTime TransactionDate { get; set; }

        public LocalDate TransactionDate { get; set; }
        
    }
}