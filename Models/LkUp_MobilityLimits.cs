using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NodaTime;

namespace AUDANEPAD_Integrated.Models
{
    public class LkUp_MobilityLimits
    {
        [Key]
        public int Record_Id { get; set; }

        public int MonthlyLimit { get; set; }

        public bool Record_Status { get; set; }

        public LocalDate TransactionDate { get; set; }
        
        
    }
}