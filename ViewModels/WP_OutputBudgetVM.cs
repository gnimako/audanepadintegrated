using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using NodaTime;



namespace AUDANEPAD_Integrated.ViewModels
{
    public class WP_OutputBudgetVM
    {
        public string Transaction_IdOBVM { get; set; }
        public string WPMainRecord_idOBVM  { get; set; }
        public int  Project_IdOBVM  { get; set; }
        public int  FiscalYear_IdOBVM  { get; set; }
        public int  Period_IdOBVM  { get; set; }
        public string WPOutput_IdOBVM  { get; set; }
        public double Output_BudgetAmountOBVM   { get; set; }
        public string WPSAPLink_IdOBVM   { get; set; }
        public string WPSAPBudget_WBSOBVM   { get; set; }
        public double UtilizationPercentageOBVM  { get; set; }

        public bool? LinkToSAPExecution  { get; set; }
        public string LinkToSAPExecutionString  { get; set; }


        public int Employee_IdOBVM {get; set;}
        


        
    }
}