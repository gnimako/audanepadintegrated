using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NodaTime;

namespace AUDANEPAD_Integrated.Models
{
    public class WP_Procurement
    {
        [Key]
        public string Transaction_Id { get; set; }
        public string WPMainRecord_id { get; set; }
        public string OutputActivity_Id  { get; set; }
        public int  Project_Id { get; set; }
        public int  FiscalYear_Id { get; set; }
        public int  Period_Id { get; set; }
        public string WPOutput_Id { get; set; }

        public string WPProcurement_Description { get; set; }
        public int  WPProcurementType_Id { get; set; }
        public int  WPProcurementLeadTime_Id { get; set; }
        public LocalDate WPProcurementStartDate { get; set; }
        public LocalDate WPProcurementEndDate { get; set; }

        public LocalDate WPTORSubmissionDate { get; set; }
        public LocalDate WPContractStartDate { get; set; }
        public double  WPProcurementCost { get; set; }
        public string WPProcurement_AdditionalNotes { get; set; }

        public string WPProcurement_SourceOfFundsDescr { get; set; }
        public string WPSAP_PR { get; set; }
        public string WPSAP_PO { get; set; }
        public bool MicroProcurement { get; set; }
        public LocalDate TransactionDate { get; set; }
        
    }
}