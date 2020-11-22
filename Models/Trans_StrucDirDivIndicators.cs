using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NodaTime;

namespace AUDANEPAD_Integrated.Models
{
    public class Trans_StrucDirDivIndicators
    {
        [Key]
        public string Transaction_Id { get; set; }

		public int Record_Id { get; set; }

		public int Directorate_Id { get; set; }
        public int Division_Id { get; set; }
        public string Record_Name { get; set; }
        public int Indicator_Type_Id { get; set; }
        public string Indicator_Type { get; set; }

		public LocalDate TransactionDate { get; set; }
        
    }
}