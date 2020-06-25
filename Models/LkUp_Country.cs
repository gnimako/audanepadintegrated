using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NodaTime;

namespace AUDANEPAD_Integrated.Models
{
    public class LkUp_Country
    {
        [Key]
		public int Country_Id { get; set; }

		[Required, MaxLength(255, ErrorMessage = "Name cannot exceed 255 characters")]
		public string Country_Name { get; set; }

        public string Country_Capital { get; set; }

        public int AfricanCountry { get; set; }

        public bool Country_Status { get; set; }

        public LocalDate TransactionDate { get; set; }
        
    }
}