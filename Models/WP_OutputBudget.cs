using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NodaTime;


namespace AUDANEPAD_Integrated.Models
{
    public class WP_OutputBudget
    {
        [Key]
        public string Transaction_Id { get; set; }
        public string WPMainRecord_id { get; set; }
        public int  Project_Id { get; set; }
        public int  FiscalYear_Id { get; set; }
        public int  Period_Id { get; set; }
        public string WPOutput_Id { get; set; }
        public double Output_BudgetAmount  { get; set; }
        public string WPSAPLink_Id  { get; set; }
        public double UtilizationPercentage { get; set; }
        public LocalDate TransactionDate { get; set; }
        
        
    }
}