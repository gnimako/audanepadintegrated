using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using NodaTime;

namespace AUDANEPAD_Integrated.ViewModels
{
    public class EmployeeViewModel
    {
		public int Id { get; set; }
        public string DispatchCycle_Id { get; set; }
        public int Employee_Id { get; set; }
        public int Programme_Id { get; set; }
        public string Programme_Name { get; set; }
        public int Project_Id { get; set; }
        public string Project_Name { get; set; }

        public string IdentityUserId { get; set; }
		public string Staff_Number { get; set; }

        public string Role_Id { get; set; }

		public int Rank { get; set; }

        public int RankStep { get; set; }

        public string PhotoPath { get; set; }


        public int Directorate_Id { get; set; }
        public int Directorate_Ident { get; set; }
        public int Department_Id { get; set; }

        public int Division_Id { get; set; }

        public int MTP_Id { get; set; }
        public int Priority_Id { get; set; }
        public string Division_Name { get; set; }

        public string Timeline { get; set; }

     
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
        public int FYear { get; set; }
        public string FisYear { get; set; }
        public int FPeriod { get; set; }
        public string FisPeriod { get; set; }
        public bool ContinentalCoverage { get; set; }



        public bool? Mapping_Status { get; set; }

        public string Mapping_Status_String { get; set; }
        public bool? Primary { get; set; }

        public bool? PrimaryMain { get; set; }

        public string Primary_String { get; set; }
        public string SystemMessageContent { get; set; }

        public string CurrentYear { get; set; }

        public string DirectorateName { get; set; }

        //Roles
        public bool Division_Head { get; set; }
        public bool Director { get; set; }
        public bool CEO { get; set; }
        public bool PIPD { get; set; }
        public bool Procurement { get; set; }
        public bool Travel { get; set; }

        //Workplans
        public string WPMainRecordId { get; set; }
        public double PRCThresold_Max { get; set; }
        public double Project_Max { get; set; }

        public string InstitutionalRepPeriod { get; set; }
        public string InstitutionalRepPeriodIdent { get; set; }
        public string InstitutionalWPYear { get; set; }




        public List<DropDownListViewModel> SelectedCountries { get; set; }

        public List<DropDownListViewModel> SelectedRECs { get; set; }





       





    }
}
