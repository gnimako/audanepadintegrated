using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NodaTime;

namespace AUDANEPAD_Integrated.Models
{
    public class WP_ProcurementProcessSteps
    {
        [Key]
        public string Transaction_Id { get; set; }
        public string WPMainRecord_id { get; set; }
        public string WPProcurement_Id { get; set; }

        public int  Employee_Id { get; set; }
        public int  WPStepNumber { get; set; }
        public int  WPStepType_Id{ get; set; }

        public LocalDate WPPlannedDate { get; set; }
        public LocalDate WPActualDate { get; set; }

        public string WPNotes { get; set; }
        


        public string WPStep_Status { get; set; }
        public bool WPAtThisStep { get; set; }
        public LocalDate TransactionDate { get; set; }
        
    }
}