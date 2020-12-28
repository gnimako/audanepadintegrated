using System;
using Kendo.Mvc.UI;
using System.ComponentModel.DataAnnotations;

using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using NodaTime;


namespace AUDANEPAD_Integrated.ViewModels
{
    public class TaskViewModel : IGanttTask
    {
        public string Output_Id { get; set; }
        public string Activity_Id { get; set; }
        public string Mobility_Id { get; set; }
        public string Procurement_Id { get; set; }
        public string Communication_Id { get; set; }
        public string RiskProfile_Id { get; set; }


        public int TaskID { get; set; }
        public int? ParentID { get; set; }

        public string Title { get; set; }

        private DateTime start;
        [Display(Name ="Start Time")]
        [DisplayFormat(DataFormatString="{0:MM/dd/yyyy}")]
        public DateTime Start
        {
            get
            {
                return start;
            }
            set
            {
                start = value.ToUniversalTime();
            }
        }

        private DateTime end;
        [Display(Name = "End Time")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime End
        {
            get
            {
                return end;
            }
            set
            {
                end = value.ToUniversalTime();
            }
        }

        public bool Summary { get; set; }
        public bool Expanded { get; set; }
        public decimal PercentComplete { get; set; }
        public int OrderId { get; set; }

        public GanttTask ToEntity()
        {
            return new GanttTask
            {
                ID = TaskID,
                ParentID = ParentID,
                Title = Title,
                Start = Start,
                End = End,
                Summary = Summary,
                Expanded = Expanded,
                PercentComplete = PercentComplete,
                OrderID = OrderId
            };
        }
        
    }
}