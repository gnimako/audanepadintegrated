using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using NodaTime;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace AUDANEPAD_Integrated.ViewModels
{
    public class WP_InstitutionalGraphsVM
    {
       
        public string DName { get; set; }
        public string DNameOther { get; set; }
        public double DValue{ get; set; }

        //Completeness
        public double DivisionSubmissions { get; set; }
        public double CompletenessOfSubmissions { get; set; }

        //PRC Thresholds
        public double DirectorateMSBudget { get; set; }
        public double DirectorateDPBudget { get; set; }
        public double PRCMSThreshold { get; set; }
        public double PRCDPThreshold { get; set; }

        //MTP Stacked Bars
        public double Economic { get; set; }
        public double Invest { get; set; }

        public double Advancing { get; set; }

        public double Service { get; set; }

        public double Institutional { get; set; }

         //Strategy Stacked Bars
         public double EconomicInt { get; set; }
         public double HumanCap { get; set; }
         public double FoodSys { get; set; }
         public double SystEnergy { get; set; }
         public double ClimateRes { get; set; }

         public double STI { get; set; }
         public double StraInstitutional { get; set; }


         //Implementation Type Stacked Bars
        public double DirectExe { get; set; }

         public double JointExe { get; set; }
         public double SubDelegation { get; set; }


        //Implementation Type Stacked Bars
        public double ExistingProjs { get; set; }

        public double NewProjs { get; set; }





        
    }
}