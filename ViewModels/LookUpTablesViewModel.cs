using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using NodaTime;

namespace AUDANEPAD_Integrated.ViewModels
{
    public class LookUpTablesViewModel
    {
        public int  LookUp_Id { get; set; }
        public string  Trans_LookUp_Id { get; set; }

        public string LookUp_Name { get; set; }
        public string LookUp_Status { get; set; }

        public bool Show_trans_button { get; set; }
        public DateTime TransactionDate { get; set; }
        
    }
}