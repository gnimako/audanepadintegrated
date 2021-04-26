using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using NodaTime;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;


namespace AUDANEPAD_Integrated.ViewModels
{
    public class WP_ProcurementToRDocsVM
    {
        public string Transaction_IdVM { get; set; }
        public string WPMainRecord_idVM { get; set; }
        public string WPProcurement_IdVM { get; set; }

        public int  WPStepNumberVM { get; set; }
        
        public string  WPStepNumberLabelVM { get; set; }

        public int  Employee_IdVM { get; set; }

        [Required, MaxLength(300, ErrorMessage = "Title cannot exceed 300 characters")] 
        public string  WPDocDesciptionTitleVM { get; set; }
        public string  WPDocPathVM { get; set; }
        public string  WPDocActualPathVM { get; set; }
        public string  WPDoc_StatusVM { get; set; }

        
    }
}