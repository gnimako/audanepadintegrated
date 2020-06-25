using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using NodaTime;

namespace AUDANEPAD_Integrated.ViewModels
{
    public class TimelineEventModel
    {
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Description { get; set; }
        public DateTime EventDate { get; set; }
        
    }
}