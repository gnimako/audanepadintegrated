using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using NodaTime;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace AUDANEPAD_Integrated.ViewModels
{
    public class WP_OutputCommunicationVM
    {
    
        public string Transaction_IdOCVM { get; set; }
        public string WPMainRecord_idOCVM { get; set; }
        public int  Project_IdOCVM  { get; set; }
        public int  FiscalYear_IdOCVM  { get; set; }
        public int  Period_IdOCVM  { get; set; }
        public string WPOutput_IdOCVM { get; set; }

        public string WPOutputCommunication_IdOCVM  { get; set; }

        public string WPComms_DescriptionOCVM { get; set; }
        public int WPCommsChannel_IdOCVM   { get; set; }

        public string WPCommunicationChannelOCVM { get; set; }

        public DateTime WPCommsStartDateOCVM { get; set; }
        public DateTime WPCommsEndDateOCVM { get; set; }

        public string WPCommunicationPeriodOCVM  { get; set; }
         public string WPComms_AdditionalNotesOCVM { get; set; }
        public double  WPCommsCostOCVM { get; set; }


        //Output_ChildGridId
        public string Output_ChildGridIdOCVM { get; set; }
        public string  ShowGridButtons { get; set; }
        public DateTime TransactionDateOCVM  { get; set; }
        
    }
}