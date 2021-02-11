using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NodaTime;


namespace AUDANEPAD_Integrated.Models
{
    public class WP_ProcurementTORDocs
    {
        [Key]
        public string Transaction_Id { get; set; }
        public string WPMainRecord_id { get; set; }
        public string WPProcurement_Id { get; set; }

        public int  Employee_Id { get; set; }

        [Required, MaxLength(300, ErrorMessage = "Title cannot exceed 300 characters")] 
        public string WPDocDesciptionTitle { get; set; }
        public string WPDocPath { get; set; }
        


        public string WPDoc_Status { get; set; }
        public LocalDate TransactionDate { get; set; }
        
    }
}