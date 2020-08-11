using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NodaTime;


namespace AUDANEPAD_Integrated.Models
{
    public class WP_SAPLink
    {
        [Key]
        public string Transaction_Id { get; set; }

        public string WPDispatchCycle_Id { get; set; }
        public int  Directorate_Id { get; set; }

        public string SAP_WBS  { get; set; }
        public string SAP_Description  { get; set; }
        public double SAP_BudgetAmount  { get; set; }

        public LocalDate TransactionDate { get; set; }
        
    }
}