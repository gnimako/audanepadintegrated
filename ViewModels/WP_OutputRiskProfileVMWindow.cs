using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using NodaTime;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;



namespace AUDANEPAD_Integrated.ViewModels
{
    public class WP_OutputRiskProfileVMWindow
    {
        public string Transaction_IdORVMMain { get; set; }
        public string CommunicationTransaction_IdORVMMain { get; set; }
        public string WPMainRecord_idORVMMain   { get; set; }
        public string WPOutput_IdORVMMain   { get; set; }
        public int  Project_IdORVMMain   { get; set; }
        public int  FiscalYear_IdORVMMain  { get; set; }
        public int  Period_IdORVMMain  { get; set; }
        public int  Employee_IdORVMMain   { get; set; }
        public string FisYearORVMMain  { get; set; }
        public string FisPeriodORVMMain { get; set; }

        public string WPOutputRiskProfile_IdORVMMain  { get; set; }

        public string WPRisk_DescriptionORVMMain { get; set; }        
        public int WPRiskImpactLevel_IdORVMMain    { get; set; }
        public int WPRiskProbability_IdORVMMain   { get; set; }
        public int WPFrequencyOfReporting_IdORVMMain    { get; set; }
        public int WPCategory_IdORVMMain   { get; set; }
        public int  WPRiskOwner_IdORVMMain  { get; set; }
        public int  WPRiskChampion_IdORVMMain  { get; set; }
        public string WPRisk_MitigationMeasuresORVMMain  { get; set; }


        public string WPRiskImpactLevel_NameORVMMain  { get; set; }
        public string WPRiskProbability_NameORVMMain   { get; set; }
        public string WPFrequencyOfReporting_NameORVMMain   { get; set; }
        public string WPCategory_NameORVMMain   { get; set; }


        public string WPRisk_AdditionalNotesORVMMain { get; set; }
        public double  WPRiskCostORVMMain { get; set; }
        
        
        //Output_ChildGridId //
        public string Output_ChildGridIdORVMMain { get; set; }
       
  
       



        public DateTime PeriodStartDateORVMMain  { get; set; }
        public DateTime PeriodEndDateORVMMain   { get; set; }
        public DateTime TransactionDateORVMMain { get; set; }

        public List<DropDownListViewModel> SelectedEmployees { get; set; }

        public List<DropDownListViewModel> SelectedCountries { get; set; }
        
    }
}