using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using NodaTime;


namespace AUDANEPAD_Integrated.ViewModels
{
    public class DivisionKPIsViewModel
    {
        public string Transaction_Id { get; set; }
        public int Record_Id { get; set; }

        public int Employee_Id { get; set; }
        public int Directorate_Ident { get; set; }
        public int Division_Ident { get; set; }

        public int Division_Ident_Old { get; set; }
        public string Division_Name { get; set; }
        public string Record_Name { get; set; }

        public string Record_Name_Old { get; set; }

         public int Indicator_Type_Ident { get; set; }

         public int Indicator_Type_Ident_Old { get; set; }
        public string Indicator_Type { get; set; }
        public DateTime TransactionDate { get; set; }
        
    }
}