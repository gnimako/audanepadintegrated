using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NodaTime;

namespace AUDANEPAD_Integrated.Models
{
    public class Trans_Country
    {
        [Key]
		public string Transaction_Id { get; set; }

		public int Country_Id { get; set; }
        public LocalDate TransactionDate { get; set; }
        
    }
}