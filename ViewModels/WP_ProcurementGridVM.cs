using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using NodaTime;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;




namespace AUDANEPAD_Integrated.ViewModels
{
    public class WP_ProcurementGridVM
    {
        [Key]
        public string Transaction_IdGVM { get; set; }
        public string WPMainRecord_idGVM  { get; set; }
        public int  Project_IdGVM  { get; set; }
        public int  FiscalYear_IdGVM  { get; set; }
        public int  Period_IdGVM { get; set; }
        public string WPOutput_IdGVM { get; set; }
        public string WPOutput_StatementGVM { get; set; }

        public string WPProcurement_DescriptionGVM  { get; set; }
        public int  WPProcurementType_IdGVM  { get; set; }
        public string  WPProcurementType_NameGVM  { get; set; }

        public string  WPProcurement_AssignedGVM  { get; set; }
        public string  WPProcurement_CompletedGVM  { get; set; }


        public int  WPProcurementLeadTime_IdGVM  { get; set; }
        public LocalDate WPProcurementStartDateGVM  { get; set; }
        public LocalDate WPProcurementEndDateGVM  { get; set; }

        public LocalDate WPTORSubmissionDateGVM  { get; set; }
        public LocalDate WPContractStartDateGVM  { get; set; }
        public double  WPProcurementCostGVM  { get; set; }
        public string WPProcurement_AdditionalNotesGVM  { get; set; }

        public string WPProcurement_SourceOfFundsDescrGVM  { get; set; }
        public LocalDate TransactionDateGVM  { get; set; }

        //Other Attributes
        public int Directorate_IdGVM  { get; set; }
        public string Directorate_NameGVM  { get; set; }
        public int Division_IdGVM { get; set; }
        public string Division_NameGVM { get; set; }

        public string Cycle_IdGVM { get; set; }
        public string InstitutionalSelectdedPeriodGVM  { get; set; }
        public string InstitutionalSelectdedPeriodIdentGVM  { get; set; }

        public string WPWorkLoadDistributionRole_String  { get; set; }

        //Procurement Task
        public string WPProcurementTask_Id  { get; set; }
        public string WPProcurementTask_Action  { get; set; }


        
    }
}