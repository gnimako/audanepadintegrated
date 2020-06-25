using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NodaTime;


namespace AUDANEPAD_Integrated.Models
{
    public class Strategy_MTPPriorityMapping
    {
        [Key]
        public string Transaction_Id { get; set; }
        public int MTP_Id { get; set; }
        public int Priority_Id { get; set; }

        public bool? Record_Status { get; set; }
        
        public LocalDate TransactionDate { get; set; }
        
    }
}