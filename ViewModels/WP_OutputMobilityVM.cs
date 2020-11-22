
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using NodaTime;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace AUDANEPAD_Integrated.ViewModels
{
    public class WP_OutputMobilityVM
    {
        public string Transaction_IdOMVM { get; set; }
        public string WPMainRecord_idOMVM  { get; set; }
        public int  Project_IdOMVM  { get; set; }
        public int  FiscalYear_IdOMVM  { get; set; }
        public int  Period_IdOMVM  { get; set; }
        public string WPOutput_IdOMVM  { get; set; }

        public string WPOutputActivity_IdOMVM  { get; set; }

        public string WPMobility_DescriptionOMVM  { get; set; }
        public int Country_IdOMVM   { get; set; }
        public string Country_NameOMVM   { get; set; }
        public DateTime MobilityStartDateOMVM  { get; set; }
        public DateTime MobilityEndDateOMVM  { get; set; }
        public string WPMobilityPeriodOMVM  { get; set; }
        public int No_DaysOMVM   { get; set; }
        public string InternalParticipantsOMVM  { get; set; }
        public string ExternalParticipantsOMVM  { get; set; }
        //Output_ChildGridId
        public string Output_ChildGridIdOMVM  { get; set; }
        public string  ShowGridButtons { get; set; }
        public double  MobilityCostOMVM  { get; set; }
        public DateTime TransactionDateOMVM  { get; set; }
        
    }
}