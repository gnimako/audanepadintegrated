using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using NodaTime;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;


namespace AUDANEPAD_Integrated.ViewModels
{
    public class WP_CycleVM
    {
        public string WPCycle_Id { get; set; }
        public int Period_Id { get; set; }
        public int Directorate_Id { get; set; }
      
        
    }
}