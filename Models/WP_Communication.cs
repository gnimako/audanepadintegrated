using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NodaTime;

namespace AUDANEPAD_Integrated.Models
{
    public class WP_Communication
    {
        [Key]
        public string Transaction_Id { get; set; }
        public string WPMainRecord_id { get; set; }
        public string OutputActivity_Id  { get; set; }
        public int  Project_Id { get; set; }
        public int  FiscalYear_Id { get; set; }
        public int  Period_Id { get; set; }
        public string WPOutput_Id { get; set; }
        public int ActivityType_Id  { get; set; }

        public string WPComms_Description { get; set; }
        public int  WPCommsChannel_Id { get; set; }
        public LocalDate WPCommsStartDate { get; set; }
        public LocalDate WPCommsEndDate { get; set; }
        public double  WPCommsCost { get; set; }
        public string WPComms_AdditionalNotes { get; set; }
        public LocalDate TransactionDate { get; set; }
        
    }
}