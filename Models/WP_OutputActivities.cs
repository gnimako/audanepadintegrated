using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NodaTime;

namespace AUDANEPAD_Integrated.Models
{
    public class WP_OutputActivities
    {
        [Key]
        public string Transaction_Id { get; set; }
        public string WPMainRecord_id { get; set; }
        public string WPOutput_Id { get; set; }
        public int  Project_Id { get; set; }
        public int  FiscalYear_Id { get; set; }
        public int  Period_Id { get; set; }
        public int ActivityType_Id  { get; set; }
        public string ActivityDescription  { get; set; }
        public double  ActivityCost { get; set; }
        public bool? PartnerFunding { get; set; }
        public string PartnerFundingDescr { get; set; }
        public LocalDate ActivityStartDate { get; set; }
        public LocalDate ActivityEndDate { get; set; }
        public int ImplementationType_Id  { get; set; }
        public double  BaselineFinancial { get; set; }
        public double  BaselineTechnical { get; set; }
        public int  Employee_Id { get; set; }
        public string WPSAPLink_Id  { get; set; }

        //Link to Mobility, Procurement and Communication
        public bool MobilityLink { get; set; }
        public bool ProcurementLink { get; set; }
        public bool CommunicationLink { get; set; }
        public LocalDate TransactionDate { get; set; }
        
    }
}