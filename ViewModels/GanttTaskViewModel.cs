using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using NodaTime;

namespace AUDANEPAD_Integrated.ViewModels
{
    public class GanttTaskViewModel
    {
        public int ID { get; set; }
        public DateTime End { get; set; }
        public bool Expanded { get; set; }
        public int OrderID { get; set; }
        public int? ParentID { get; set; }
        public decimal PercentComplete { get; set; }
      //  public double PercentComplete2 { get; set; }
        public DateTime Start { get; set; }
        public bool Summary { get; set; }
        public string Title { get; set; }

        
    }
}