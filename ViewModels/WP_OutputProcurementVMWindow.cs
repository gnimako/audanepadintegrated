using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using NodaTime;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;



namespace AUDANEPAD_Integrated.ViewModels
{
    public class WP_OutputProcurementVMWindow
    {
        public string Transaction_IdOPVMMain { get; set; }
        public string ProcurementTransaction_IdOPVMMain{ get; set; }
        public string WPMainRecord_idOPVMMain   { get; set; }
        public string WPOutput_IdOPVMMain   { get; set; }
        public int  Project_IdOPVMMain   { get; set; }
        public int  FiscalYear_IdOPVMMain  { get; set; }
        public int  Period_IdOPVMMain  { get; set; }
        public int  Employee_IdOPVMMain   { get; set; }
        public string FisYearOPVMMain  { get; set; }
        public string FisPeriodOPVMMain { get; set; }


        public string WPProcurement_DescriptionOPVMMain { get; set; }
        public int WPProcurementType_IdOPVMMain   { get; set; }
        public string WPProcurementType_NameOPVMMain  { get; set; }
        public int  WPProcurementLeadTime_IdOPVMMain { get; set; }
        public string WPProcurementLeadTime_NameOPVMMain  { get; set; }
        public DateTime ProcurementStartDateOPVMMain { get; set; }
        public DateTime ProcurementEndDateOPVMMain { get; set; }

        public DateTime WPTORSubmissionDateOPVMMain { get; set; }
        public DateTime WPContractStartDateOPVMMain { get; set; }
        public string WPProcurementPeriodOPVMMain  { get; set; }
        public string WPProcurement_AdditionalNotesOPVMMain  { get; set; }

        public string WPProcurement_SourceOfFundsDescrOPVMMain  { get; set; }
        public double  ProcurementCostOPVMMain { get; set; }
        
        
        //Output_ChildGridId //
        public string Output_ChildGridIdOPVMMain  { get; set; }

        public string DispatchCycle_IdOPVMMain { get; set; }
        public string InstitutionalRepPeriodIdentOPVMMain  { get; set; }
       
  
       



        public DateTime PeriodStartDateOPVMMain   { get; set; }
        public DateTime PeriodEndDateOPVMMain   { get; set; }
        public DateTime TransactionDateOPVMMain  { get; set; }

        public List<DropDownListViewModel> SelectedEmployees { get; set; }
        
    }
}