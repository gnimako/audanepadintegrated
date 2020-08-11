using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NodaTime;

namespace AUDANEPAD_Integrated.Models
{
    public class WP_MainRecord
    {
        [Key]
        public string Transaction_Id { get; set; }
        public int  Directorate_Id { get; set; }
        public int  Division_Id { get; set; }
        public int  Programme_Id { get; set; }
        public int  Project_Id { get; set; }
        public int  FiscalYear_Id { get; set; }
        public int  Period_Id { get; set; }

        public bool? LinkToSAPExecution  { get; set; }
        public string WP_Status  { get; set; }
        public string WP_ApprovalStatus  { get; set; }
        public bool? ContinentalCoverage { get; set; }

        public int  Employee_Id { get; set; }

        public LocalDate TransactionDate { get; set; }
        
    }
}