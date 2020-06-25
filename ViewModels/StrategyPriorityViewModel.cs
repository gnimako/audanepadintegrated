using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using NodaTime;



namespace AUDANEPAD_Integrated.ViewModels
{
    public class StrategyPriorityViewModel
    {
        public string Transaction_Id { get; set; }

         public int MTPPriority_Id { get; set; }

        public int Priority_Id { get; set; }

        public string Priority_Name { get; set; }

        public DateTime TransactionDate { get; set; }
        
    }
}