using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NodaTime;


namespace AUDANEPAD_Integrated.Models
{
    public class WP_BarCodeIdents
    {
        [Key]
        public string Transaction_Id { get; set; }
        public int Institutional_Id { get; set; }
        public int  Directorate_Id { get; set; }
        public int  Division_Id { get; set; }
        public int  FiscalYear_Id { get; set; }
        public int  Period_Id { get; set; }
        public string BarCode_Id { get; set; }
        public string DispatchCycle_Id { get; set; }

        public LocalDate PeriodStartDate { get; set; }
        public LocalDate PeriodEndDate { get; set; }
        public LocalDate TransactionDate { get; set; }
    

        
    }
}