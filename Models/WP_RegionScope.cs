using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NodaTime;



namespace AUDANEPAD_Integrated.Models
{
    public class WP_RegionScope
    {
        [Key]
        public string Transaction_Id { get; set; }
        public string WPMainRecord_id { get; set; }
        public int  Project_Id { get; set; }
        public int  FiscalYear_Id { get; set; }
        public int  Period_Id { get; set; }
        public int Region_Id  { get; set; }
        public int  Employee_Id { get; set; }
        public LocalDate TransactionDate { get; set; }
        
    }
}