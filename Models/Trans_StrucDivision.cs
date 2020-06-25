using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NodaTime;

namespace AUDANEPAD_Integrated.Models
{
    public class Trans_StrucDivision
    {
        [Key]
        public string Transaction_Id { get; set; }

        public string TransDirectorate_Id { get; set; } //for delete purposes

        public int Division_Id { get; set; } //this mapps to Division Entity
		public LocalDate TransactionDate { get; set; }
        
    }
}