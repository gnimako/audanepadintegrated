using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using NodaTime;


namespace AUDANEPAD_Integrated.ViewModels
{
    public class EmployeeMappingViewModel
    {
        public string Transaction_Id { get; set; }

        public string ProjectTransaction_Id { get; set; }

        public string ProgrammeTransaction_Id { get; set; }
        public  int Project_IdGM { get; set; }
        public  int Programme_IdGM { get; set; }

        public string Project_Name { get; set; }
        public string Programme_Name { get; set; }
        public  int EmployeePK { get; set; }
        public string IdentityUserId { get; set; }
        public string EmployeeName { get; set; }
        public string Staff_Number { get; set; }

        public string profilepicpath { get; set; }

        public int Directorate_Id { get; set; }
        public int Directorate_IdGM { get; set; }
        public string Directorate_Name { get; set; }

        public int Division_Id { get; set; }
        public int Division_IdGM { get; set; }
        public string Division_Name { get; set; }

        public bool? Mapping_Status { get; set; }

        public string Mapping_Status_String { get; set; }
        public bool? Primary { get; set; }

        public string Primary_String { get; set; }

        public DateTime TransactionDate { get; set; }
        
    }
}