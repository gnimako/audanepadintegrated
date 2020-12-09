using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NodaTime;


namespace AUDANEPAD_Integrated.Models
{
    public class WP_Mobility
    {
        [Key]
        public string Transaction_Id { get; set; }
        public string WPMainRecord_id { get; set; }
        public int  Project_Id { get; set; }
        public int  FiscalYear_Id { get; set; }
        public int  Period_Id { get; set; }
        public string WPOutput_Id { get; set; }

        public string WPOutputActivity_Id { get; set; }

        public string WPMobility_Description { get; set; }
        public int Country_Id  { get; set; }
        public string WPMobility_City  { get; set; }
        public LocalDate MobilityStartDate { get; set; }
        public LocalDate MobilityEndDate { get; set; }
        public double  MobilityCost { get; set; }
        public LocalDate TransactionDate { get; set; }
        
    }
}