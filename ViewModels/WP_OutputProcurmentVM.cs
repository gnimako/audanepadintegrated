using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using NodaTime;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;


namespace AUDANEPAD_Integrated.ViewModels
{
    public class WP_OutputProcurmentVM
    {
        public string Transaction_IdOPVM { get; set; }
        public string WPMainRecord_idOPVM  { get; set; }
        public int  Project_IdOPVM  { get; set; }
        public int  FiscalYear_IdOPVM  { get; set; }
        public int  Period_IdOPVM  { get; set; }
        public string WPOutput_IdOPVM  { get; set; }

        public string WPOutputProcurement_IdOPVM  { get; set; }

        public string WPProcurement_DescriptionOPVM  { get; set; }        
        public int WPProcurementType_IdOPVM   { get; set; }
        public string WPProcurementType_NameOPVM { get; set; }
        public int  WPProcurementLeadTime_IdOPVM { get; set; }
        public string WPProcurementLeadTime_NameOPVM  { get; set; }
        public DateTime ProcurementStartDateOPVM { get; set; }
        public DateTime ProcurementEndDateOPVM { get; set; }
        public string WPProcurementPeriodOPVM  { get; set; }
        public double  ProcurementCostOPVM { get; set; }
        //Output_ChildGridId
        public string Output_ChildGridIdOPVM  { get; set; }
        public string  ShowGridButtons { get; set; }
        public DateTime TransactionDateOPVM  { get; set; }
        
    }
}