using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NodaTime;

namespace AUDANEPAD_Integrated.Models
{
    public class WP_ProcurementWorkLoadAssignment
    {
        [Key]
        public string Transaction_Id { get; set; }
        public string WPMainRecord_id { get; set; }
        public string WPProcurement_Id { get; set; }

        public int  Employee_Id { get; set; }
        public int  ProcurementApprovalAuthority_Id { get; set; }//Automatic

        public string WPProcurement_Status { get; set; }
        public LocalDate TransactionDate { get; set; }

        
    }
}