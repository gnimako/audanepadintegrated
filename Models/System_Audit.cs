using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NodaTime;


namespace AUDANEPAD_Integrated.Models
{
    public class System_Audit
    {
        [Key]
        public string Transaction_Id { get; set; }
        public int  Employee_Id { get; set; }
        public string AuditStatement { get; set; }
        public LocalDate TransactionDate { get; set; }
        
    }
}