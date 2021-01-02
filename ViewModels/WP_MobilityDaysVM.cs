using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NodaTime;


namespace AUDANEPAD_Integrated.ViewModels
{
    public class WP_MobilityDaysVM
    {
        public int EmployeeNumber { get; set; }
        public string EmployeeName { get; set; }
        public double NumberOfDays { get; set; }

        public bool DaysExceeded { get; set; }
        



        
    }
}