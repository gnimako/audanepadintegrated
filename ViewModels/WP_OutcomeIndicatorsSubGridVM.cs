
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using NodaTime;

namespace AUDANEPAD_Integrated.ViewModels
{
    public class WP_OutcomeIndicatorsSubGridVM
    {
        public string Transaction_IdOCIVM { get; set; }
        public string Transaction_Id{ get; set; }

        public string Transaction_IndicatorId{ get; set; }
        public string Outcome_ChildGridId{ get; set; }

        public string IndicatorStatementOCIVM  { get; set; }
        public string  BaselineOCIVM  { get; set; }
        public string  TargetOCIVM  { get; set; }

        public DateTime TransactionDate { get; set; }
        
    }
}