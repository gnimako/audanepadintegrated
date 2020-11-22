using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using NodaTime;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace AUDANEPAD_Integrated.ViewModels
{
    public class WP_OutputMobilityVMWindow
    {
        public string Transaction_IdOMVMMain { get; set; }
        public string MobilityTransaction_IdOMVMMain { get; set; }
        public string WPMainRecord_idOMVMMain   { get; set; }
        public string WPOutput_IdOMVMMain   { get; set; }
        public int  Project_IdOMVMMain   { get; set; }
        public int  FiscalYear_IdOMVMMain   { get; set; }
        public int  Period_IdOMVMMain   { get; set; }
        public int  Employee_IdOMVMMain   { get; set; }
        public string FisYearOMVMMain  { get; set; }
        public string FisPeriodOMVMMain  { get; set; }


        public string WPMobility_DescriptionOMVMMain { get; set; }
        public int Country_IdOMVMMain   { get; set; }
        public string Country_NameOMVMMain  { get; set; }
        public DateTime MobilityStartDateOMVMMain { get; set; }
        public DateTime MobilityEndDateOMVMMain  { get; set; }
        public string WPMobilityPeriodOMVMMain  { get; set; }
        public int No_DaysOMVMMain   { get; set; }
        public string InternalParticipantsOMVMMain { get; set; }
        public string ExternalParticipantsOMVMMain  { get; set; }
        //Output_ChildGridId //
        public string Output_ChildGridIdOMVMMain  { get; set; }
       
  
        public double  MobilityCostOMVMMain { get; set; }



        public DateTime PeriodStartDateOMVMMain   { get; set; }
        public DateTime PeriodEndDateOMVMMain   { get; set; }
        public DateTime TransactionDateOMVMMain  { get; set; }

         public List<DropDownListViewModel> SelectedEmployees { get; set; }
        
    }
}