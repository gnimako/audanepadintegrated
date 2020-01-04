using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using NodaTime;

namespace AUDANEPAD_Integrated.ViewModels
{
    public class EmployeeViewModel
    {
        		public int Id { get; set; }
        public int Employee_Id { get; set; }
        public int Programme_Id { get; set; }
        public string IdentityUserId { get; set; }
		public string Staff_Number { get; set; }

		public int Rank { get; set; }

        public int RankStep { get; set; }

        public string PhotoPath { get; set; }


        public int Directorate_Id { get; set; }
        public int Department_Id { get; set; }

     
        public int Unit_Id { get; set; }


        public string First_Name { get; set; }
		public string Last_Name { get; set; }
		public string Email { get; set; }

        public DateTime DOB { get; set; }
       // public LocalDate DOB { get; set; }

        public int Gender { get; set; }
        public string Address_Street { get; set; }
        public string Address_City { get; set; }
        public string Address_State { get; set; }
        public string Address_PostCode { get; set; }
        public int Country { get; set; }

        //public IEnumerable<IFormFile> files { get; set; }

        public IFormFile Photo { get; set; }

        public string ExistingPhotoPath { get; set; }

        public int Data_Id { get; set; }
        public string Data_Text { get; set; }

        public string Data_Id_StringType { get; set; }

        public string tabstrip { get; set; }

        //Draft Annual WorkPlan
        public string TransAWP_TransId { get; set; }
        public string FiscalYear { get; set; }
       
        
    }
}