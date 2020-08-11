using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NodaTime;


namespace AUDANEPAD_Integrated.Models
{
    public class Strategy_OutputIndicators
    {
        [Key]
        public int Record_Id { get; set; }
        public string Record_Name { get; set; }
        public string Indicator_Type { get; set; }
        public bool? Record_Status { get; set; }
        public LocalDate TransactionDate { get; set; }
                
    }
}