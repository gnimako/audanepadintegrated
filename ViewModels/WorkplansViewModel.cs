using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using NodaTime;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;



namespace AUDANEPAD_Integrated.ViewModels
{
    public class WorkplansViewModel
    {
        public string Transaction_Id { get; set; }

        public string WPDispatchCycle_Ident { get; set; }
        public string SessionTransaction_Id { get; set; }

        public int Directorate_Id { get; set; }
        public int Division_Id { get; set; }
        public string Division_Name { get; set; }
        public string SAPWBS { get; set; }
        public string SAPDescription{ get; set; }

        public double SAPAmount { get; set; }
        public string SAPWBSLinkedProjects { get; set; }

        public string SelectedRow { get; set; }
        public string EnableRow { get; set; }
        public string WPMainRecord_Ident { get; set; }
        public int Employee_Id { get; set; }

        public int Programme_Id { get; set; }

        public int ProjectId { get; set; }
        public string Project_Name { get; set; }
        public int FYearIdent { get; set; }
        public string FisYear { get; set; }
        public int FPeriodIdent { get; set; }
        public string FisPeriod { get; set; }

        public string FisPeriodHidden { get; set; }
        public bool WPStatus { get; set; }
        public bool WPSAPLinkView { get; set; }
        public string WPStatus_String { get; set; }
        public string WPSAPLinkView_String { get; set; }
        public string WPCEOApproveRole_String { get; set; }

        public int ViewNumbering { get; set; }
        public string Outcome { get; set; }
        
        public string WPOutput_Id { get; set; }
        public string Output { get; set; }

        public double Output_BudgetAmount  { get; set; }

        public string WPSAPLink_Id  { get; set; }
        
        public double UtilizationPercentage { get; set; }

        public int MTP_Ident  { get; set; }
        public int REC_Ident  { get; set; }
        public int Counry_Ident  { get; set; }

        public int Country_Ident  { get; set; }

        public string Statement { get; set; }
        public string MTP_PriorityStatement { get; set; }
        public int AUDAPriority_Ident  { get; set; }
        public string AUDA_PriorityStatement { get; set; }

        public bool? LinkToSAPExecutionVM  { get; set; }
        public string LinkToSAPExecutionStringVM  { get; set; }

        public string LinkToSAPExecutionDisplayVM  { get; set; }

        public DateTime PeriodStart { get; set; }
        public DateTime PeriodEnd { get; set; }

        public DateTime TransactionDate { get; set; }

        [UIHint("ClientPeriodType")]
        public CategoryViewModel PeriodType { get; set; }

        [UIHint("ClientOutputLinkType")]
        public CategoryViewModel OutputLinkType { get; set; }




        public string PeriodTypeSingle  { get; set; }

        
    }
}