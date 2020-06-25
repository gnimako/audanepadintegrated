using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NodaTime;

namespace AUDANEPAD_Integrated.Models
{
    public class LkUp_CommsChannel
    {
        [Key]
		public int CommsChannel_Id { get; set; }

		[Required, MaxLength(255, ErrorMessage = "Name cannot exceed 255 characters")]
		public string CommsChannel_Name { get; set; }

        public bool? CommsChannel_Status { get; set; }

        public LocalDate TransactionDate { get; set; }
        
    }
}