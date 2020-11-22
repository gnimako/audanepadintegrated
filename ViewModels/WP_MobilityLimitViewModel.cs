using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using NodaTime;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;



namespace AUDANEPAD_Integrated.ViewModels
{
    public class WP_MobilityLimitViewModel
    {
        public string Transaction_IdVM { get; set; }
        public string WPCycle_idVM { get; set; }
        public int  Project_IdVM { get; set; }
        public int  FiscalYear_IdVM { get; set; }
        public int  Period_IdVM { get; set; }
        public LocalDate PeriodStartDateVM { get; set; }
        public LocalDate PeriodEndDateVM { get; set; }
        public int MonthlyLimitVM { get; set; }
        public int  Employee_IdVM { get; set; }

        [UIHint("ClientCategory")]
        public CategoryViewModel Category { get; set; }
        public LocalDate TransactionDate { get; set; }
        
    }
}