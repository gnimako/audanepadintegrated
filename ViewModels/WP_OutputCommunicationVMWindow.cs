using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using NodaTime;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;



namespace AUDANEPAD_Integrated.ViewModels
{
    public class WP_OutputCommunicationVMWindow
    {

        public string Transaction_IdOCVMMain { get; set; }
        public string CommunicationTransaction_IdOCVMMain { get; set; }
        public string WPMainRecord_idOCVMMain   { get; set; }
        public string WPOutput_IdOCVMMain   { get; set; }
        public int  Project_IdOCVMMain   { get; set; }
        public int  FiscalYear_IdOCVMMain  { get; set; }
        public int  Period_IdOCVMMain  { get; set; }
        public int  Employee_IdOCVMMain   { get; set; }
        public string FisYearOCVMMain  { get; set; }
        public string FisPeriodOCVMMain { get; set; }


        public string WPComms_DescriptionOCVMMain { get; set; }
        public int WPCommsChannel_IdOCVMMain   { get; set; }

        public string WPCommunicationChannelOCVMMain { get; set; }

        public DateTime WPCommsStartDateOCVMMain { get; set; }
        public DateTime WPCommsEndDateOCVMMain { get; set; }

        public string WPCommunicationPeriodOCVMMain { get; set; }
         public string WPComms_AdditionalNotesOCVMMain { get; set; }
        public double  WPCommsCostOCVMMain { get; set; }
        
        
        //Output_ChildGridId //
        public string Output_ChildGridIdOCVMMain { get; set; }
       
  
       



        public DateTime PeriodStartDateOCVMMain  { get; set; }
        public DateTime PeriodEndDateOCVMMain   { get; set; }
        public DateTime TransactionDateOCVMMain  { get; set; }

        public List<DropDownListViewModel> SelectedEmployees { get; set; }
        
    }
}