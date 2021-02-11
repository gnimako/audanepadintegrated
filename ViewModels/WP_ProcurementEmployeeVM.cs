using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using NodaTime;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;


namespace AUDANEPAD_Integrated.ViewModels
{
    public class WP_ProcurementEmployeeVM
    {
        public string Transaction_IdExtPartVM { get; set; }
        public string WPMainRecord_idExtPartVM { get; set; }
        public string WPOutput_IdExtPartVM { get; set; }
        

        [UIHint("ClientEmployeeName")]
        public CategoryViewModel EmployeeName { get; set; }
        
    }
}