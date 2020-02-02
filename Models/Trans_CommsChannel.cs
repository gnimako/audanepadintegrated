using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NodaTime;

namespace AUDANEPAD_Integrated.Models
{
    public class Trans_CommsChannel
    {
        [Key]
		public string Transaction_Id { get; set; }

		public int CommsChannel_Id { get; set; }
        public LocalDate TransactionDate { get; set; }
        
    }
}