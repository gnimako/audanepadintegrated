using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using NodaTime;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace AUDANEPAD_Integrated.ViewModels
{
    public class WP_OutputsGridVM
    {
     
        public string Transaction_IdGVM { get; set; }
        public string WPMainRecord_idGVM { get; set; }
        public int  Project_IdGVM  { get; set; }
        public string  Project_NameGVM  { get; set; }
        public int  FiscalYear_IdGVM  { get; set; }
        public int  Period_IdGVM  { get; set; }
        public string OutputGVM   { get; set; }
        public int  Employee_IdGVM { get; set; }
        public string WPSAPLink_IdGVM   { get; set; }
        public LocalDate TransactionDateGVM  { get; set; }

        //Other Attributes
        public int Directorate_IdGVM  { get; set; }
        public string Directorate_NameGVM  { get; set; }
        public int Division_IdGVM { get; set; }
        public string Division_NameGVM { get; set; }

        public string Strategic_PrioritiesGVM { get; set; }
        public double  WPOutputCostGVM  { get; set; }

        public string Cycle_IdGVM { get; set; }
        public string InstitutionalSelectdedPeriodGVM  { get; set; }
        public string InstitutionalSelectdedPeriodIdentGVM  { get; set; }
        
    }
}