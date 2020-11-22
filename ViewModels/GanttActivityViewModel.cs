using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using NodaTime;



namespace AUDANEPAD_Integrated.ViewModels
{
    public class GanttActivityViewModel
    {
        public string TaskID { get; set; }
        public string ParentID { get; set; }

        public string Title { get; set; }

        public  DateTime Start { get; set; }
        public  DateTime End { get; set; }
        
    }
}