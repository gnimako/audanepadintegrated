using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using NodaTime;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;


namespace AUDANEPAD_Integrated.ViewModels
{
    public class WP_OutputRiskProfileVM
    {

        public string Transaction_IdORVM { get; set; }
        public string WPMainRecord_idORVM  { get; set; }
        public int  Project_IdORVM   { get; set; }
        public int  FiscalYear_IdORVM   { get; set; }
        public int  Period_IdORVM  { get; set; }
        public string WPOutput_IdORVM  { get; set; }

        public string WPOutputRiskProfile_IdORVM  { get; set; }

        public string WPRisk_DescriptionORVM { get; set; }        
        public int WPRiskImpactLevel_IdORVM   { get; set; }
        public int WPRiskProbability_IdORVM  { get; set; }
        public int WPFrequencyOfReporting_IdORVM   { get; set; }
        public int WPCategory_IdORVM   { get; set; }



        public string WPRiskImpactLevel_NameORVM   { get; set; }
        public string WPRiskProbability_NameORVM   { get; set; }
        public string WPFrequencyOfReporting_NameORVM   { get; set; }
        public string WPCategory_NameORVM   { get; set; }
        public string WPRisk_AdditionalNotesORVM  { get; set; }
        public double  WPRiskCostORVM { get; set; }
        //Output_ChildGridId
        public string Output_ChildGridIdORVM  { get; set; }
        public string  ShowGridButtons { get; set; }
        public DateTime TransactionDateORVM  { get; set; }
        
    }
}