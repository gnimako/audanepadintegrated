using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using NodaTime;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;


namespace AUDANEPAD_Integrated.ViewModels
{
    public class WP_OutputMobilityExternalPartVM
    {
        public string Transaction_IdExtPartVM { get; set; }
        public string WPMainRecord_idExtPartVM { get; set; }
        public string WPOutput_IdExtPartVM { get; set; }
        public string WPMobility_idExtPartVM { get; set; }
        public int  ExternalParticipant_IdExtPartVM { get; set; }
        [Required(ErrorMessage = "Description is required.")]
        public string ExternalParticipant_DescriptionExtPartVM { get; set; }
        public int  ExternalParticipant_NumberExtPartVM { get; set; }

        [UIHint("ClientExternalType")]
        public CategoryViewModel ExternalType { get; set; }

        [UIHint("ClientEmployeeName")]
        public CategoryViewModel EmployeeName { get; set; }
        
    }
}