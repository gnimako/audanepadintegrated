using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using NodaTime;


namespace AUDANEPAD_Integrated.ViewModels
{
    public class WP_OutputIndicatorsSubGridVM
    {
        public string Transaction_IdOIVM { get; set; }
        public string Transaction_Id{ get; set; }

        public string Transaction_IndicatorId{ get; set; }
        public string Output_ChildGridId{ get; set; }

        public string IndicatorStatementOIVM  { get; set; }
        public string  BaselineOIVM  { get; set; }
        public string  TargetOIVM  { get; set; }

        public DateTime TransactionDate { get; set; }

        
    }
}