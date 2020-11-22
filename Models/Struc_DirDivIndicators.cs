
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NodaTime;


namespace AUDANEPAD_Integrated.Models
{
    public class Struc_DirDivIndicators
    {
        [Key]
        public int Record_Id { get; set; }
        public int Directorate_Id { get; set; }
        public int Division_Id { get; set; }
        public string Record_Name { get; set; }

        public int Indicator_Type_Id { get; set; }
        public string Indicator_Type { get; set; }
        public bool? Record_Status { get; set; }
        public LocalDate TransactionDate { get; set; }
                
        
    }
}