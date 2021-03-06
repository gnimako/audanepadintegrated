using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NodaTime;

namespace AUDANEPAD_Integrated.Models
{
    public class WP_DispatchCycle
    {
        [Key]
        public string Transaction_Id { get; set; }
        public int  FiscalYear_Id { get; set; }
        public int  Period_Id { get; set; }
        public bool? Dispatch_Status  { get; set; }

        public bool? LinkToSAPExecution  { get; set; }

        public int  Employee_Id { get; set; }

        public LocalDate PeriodStartDate { get; set; }
        public LocalDate PeriodEndDate { get; set; }


        public LocalDate TransactionDate { get; set; }
    }
}