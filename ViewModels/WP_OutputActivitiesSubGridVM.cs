using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using NodaTime;


namespace AUDANEPAD_Integrated.ViewModels
{
    public class WP_OutputActivitiesSubGridVM
    {
        public string Transaction_IdOAVM { get; set; }
        public string WPMainRecord_idOAVM { get; set; }
        public string WPOutput_IdOAVM { get; set; }
        public int  Project_IdOAVM { get; set; }
        public int  FiscalYear_IdOAVM { get; set; }
        public int  Period_IdOAVM { get; set; }
        public int ActivityType_IdOAVM  { get; set; }
        public string ActivityTypeName_IdOAVM  { get; set; }
        public string ActivityDescriptionOAVM  { get; set; }
        public double  ActivityCostOAVM { get; set; }
        public DateTime ActivityStartDateOAVM { get; set; }
        public DateTime ActivityEndDateOAVM { get; set; }
        public int ImplementationType_IdOAVM  { get; set; }
        public double  BaselineFinancialOAVM { get; set; }
        public double  BaselineTechnicalOAVM { get; set; }
        public int  Employee_IdOAVM { get; set; }
         public string  ShowGridButtons { get; set; }
        public DateTime TransactionDateOAVM { get; set; }
        
    }
}