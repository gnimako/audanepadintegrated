using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NodaTime;

namespace AUDANEPAD_Integrated.Models
{
    public class Trans_ActivityType
    {
        [Key]
		public string Transaction_Id { get; set; }

        public int Activity_Id { get; set; }
        public LocalDate TransactionDate { get; set; }
        
    }
}