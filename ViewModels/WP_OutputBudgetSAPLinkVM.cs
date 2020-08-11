using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using NodaTime;

namespace AUDANEPAD_Integrated.ViewModels
{
    public class WP_OutputBudgetSAPLinkVM
    {
        public string Transaction_IdSAPVM { get; set; }
        public string WPSAPBudget_WBSSAPVM    { get; set; }
        public double UtilizationPercentageSAPVM   { get; set; }
        
    }
}