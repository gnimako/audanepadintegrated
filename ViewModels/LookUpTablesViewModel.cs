using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using NodaTime;

namespace AUDANEPAD_Integrated.ViewModels
{
    public class LookUpTablesViewModel
    {
        public int  LookUp_Id { get; set; }

        public int  ParentLink_Id { get; set; }
        public string  Trans_LookUp_Id { get; set; }
         public string  Trans_Parent_LookUp_Id { get; set; }

        public string LookUp_Name { get; set; }

        public string Parent_LookUp_Name { get; set; }
        public string LookUp_Status { get; set; }

        public bool Show_trans_button { get; set; }
        public DateTime TransactionDate { get; set; }

        [UIHint("ClientCategory")]
        public DropDownListViewModel Category { get; set; }
     
        
    }
}