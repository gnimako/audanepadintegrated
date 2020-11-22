using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using NodaTime;


namespace AUDANEPAD_Integrated.ViewModels
{
    public class WP_OutputActivitiesVM
    {
        public string Transaction_IdOAVMMain { get; set; }
        public string WPMainRecord_idOAVMMain  { get; set; }
        public string WPOutput_IdOAVMMain  { get; set; }
        public int  Project_IdOAVMMain  { get; set; }
        public int  FiscalYear_IdOAVMMain  { get; set; }
        public int  Period_IdOAVMMain  { get; set; }
  

        public string FisYearOAVMMain { get; set; }
        public string FisPeriodOAVMMain { get; set; }
        public int ActivityType_IdOAVMMain   { get; set; }
        public string ActivityTypeName_IdOAVMMain   { get; set; }
        public string ActivityDescriptionOAVMMain   { get; set; }
        public double  ActivityCostOAVMMain  { get; set; }

        public bool PartnerFundingOAVMMain  { get; set; }
        public string PartnerFundingDescrOAVMMain  { get; set; }
        public DateTime ActivityStartDateOAVMMain  { get; set; }
        public DateTime ActivityEndDateOAVMMain  { get; set; }
        public int ImplementationType_IdOAVMMain   { get; set; }
        public double  BaselineFinancialOAVMMain  { get; set; }
        public double  BaselineTechnicalOAVMMain  { get; set; }
        public int  Employee_IdOAVMMain  { get; set; }
        public DateTime PeriodStartDate  { get; set; }
        public DateTime PeriodEndDate  { get; set; }
        public DateTime TransactionDateOAVMMain  { get; set; }
        
    }
}