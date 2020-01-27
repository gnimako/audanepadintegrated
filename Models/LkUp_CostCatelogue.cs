using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NodaTime;


namespace AUDANEPAD_Integrated.Models
{
    public class LkUp_CostCatelogue
    {
        [Key]
		public int Cost_Id { get; set; }

		public string Cost_Code { get; set; }

		public string Cost_Category { get; set; }

		public string Cost_Description { get; set; }

		public string Unit_Of_Measure { get; set; }

		public float Unit_Cost { get; set; }

        public bool Cost_Status { get; set; }

        public LocalDate TransactionDate { get; set; }
        
    }
}