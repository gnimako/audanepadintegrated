using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NodaTime;

namespace AUDANEPAD_Integrated.Models
{
    public class Trans_Programme
    {
        [Key]
        public string Transaction_Id { get; set; }

		public int MainProgramme_Id { get; set; }

		public int Directorate_Id { get; set; }

        public int Division_Id { get; set; }

		public LocalDate TransactionDate { get; set; }
        
    }
}