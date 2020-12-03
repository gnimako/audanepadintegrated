using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NodaTime;

namespace AUDANEPAD_Integrated.Models
{
    public class WP_PRCBudgetLimits
    {
        [Key]
        public string Transaction_Id { get; set; }
        public string WPCycle_id { get; set; }
        public int Institutional_Id { get; set; }
        public int  Directorate_Id { get; set; }
        public int  FiscalYear_Id { get; set; }
        public int  Period_Id { get; set; }

        public LocalDate PeriodStartDate { get; set; }
        public LocalDate PeriodEndDate { get; set; }

        public double MS_Limit { get; set; }
        public double DP_Limit { get; set; }

        public LocalDate TransactionDate { get; set; }
    
        
    }
}