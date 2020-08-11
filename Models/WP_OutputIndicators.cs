using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NodaTime;

namespace AUDANEPAD_Integrated.Models
{
    public class WP_OutputIndicators
    {
        [Key]
        public string Transaction_Id { get; set; }
        public string WPMainRecord_id { get; set; }
        public string WPOutput_Id { get; set; }
        public int  Project_Id { get; set; }
        public int  FiscalYear_Id { get; set; }
        public int  Period_Id { get; set; }
        public string IndicatorCategory  { get; set; }
        public string IndicatorType  { get; set; }
        public int OutputIndicator_Id { get; set; }
        public int Priority_Id { get; set; }
        public int KeyPerformanceArea_Id { get; set; }
        public string ProjectBasedIndicatorStatement { get; set; }
        public double  BaselineQuantitative { get; set; }
        public string  BaselineQuanlitative { get; set; }
        public double  TargetQuantitative { get; set; }
        public string  TargetQuanlitative { get; set; }
        public int  Employee_Id { get; set; }
        public LocalDate TransactionDate { get; set; }
        
    }
}