
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NodaTime;
namespace AUDANEPAD_Integrated.Models
{
    public class WP_RiskProfile
    {
        [Key]
        public string Transaction_Id { get; set; }
        public string WPMainRecord_id { get; set; }
        public int  Project_Id { get; set; }
        public int  FiscalYear_Id { get; set; }
        public int  Period_Id { get; set; }
        public string WPOutput_Id { get; set; }

        public string WPRisk_Description { get; set; }
        public int  WPRiskImpactLevel_Id { get; set; }
        public int  WPRiskProbability_Id { get; set; }
        public int  WPFrequencyOfReporting_Id { get; set; }
        public int  WPCategory_Id { get; set; }
        public int  WPRiskOwner_Id { get; set; }
        public int  WPRiskChampion_Id { get; set; }
        public string WPRisk_MitigationMeasures { get; set; }

        public double  WPRiskCost { get; set; }
        public string WPRisk_AdditionalNotes { get; set; }
        public LocalDate TransactionDate { get; set; }
        
    }
}