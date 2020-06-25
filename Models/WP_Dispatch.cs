using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NodaTime;

namespace AUDANEPAD_Integrated.Models
{
    public class WP_Dispatch
    {
        [Key]
        public string Transaction_Id { get; set; }
        public int  FiscalYear_Id { get; set; }
        public int  Period_Id { get; set; }
        public bool? Dispatch_Status  { get; set; }

        public int  Employee_Id { get; set; }

        public LocalDate TransactionDate { get; set; }
    }
}