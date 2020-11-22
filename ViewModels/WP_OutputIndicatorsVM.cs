using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using NodaTime;


namespace AUDANEPAD_Integrated.ViewModels
{
    public class WP_OutputIndicatorsVM
    {
        public string Transaction_IdOIVM { get; set; }
        public string WPMainRecord_idOIVM  { get; set; }
        public string WPOutput_IdOIVM  { get; set; }
        public int  Project_IdOIVM  { get; set; }
        public int  FiscalYear_IdOIVM  { get; set; }
          public string FisYearOIVM  { get; set; }
        public int  Period_IdOIVM  { get; set; }
        public string FisPeriodOIVM  { get; set; }

        public string IndicatorCategoryOIVM   { get; set; }
        public string IndicatorTypeOIVM   { get; set; }
        public int OutputIndicator_IdOIVM  { get; set; }
        public int Priority_IdOIVM  { get; set; }
        public int KeyPerformanceArea_IdOIVM  { get; set; }

        public double  BaselineQuantitativeOIVM  { get; set; }
        public string  BaselineQuanlitativeOIVM  { get; set; }
        public double  TargetQuantitativeOIVM  { get; set; }
        public string  TargetQuanlitativeOIVM  { get; set; }
        public int  Employee_IdOIVM  { get; set; }

        //Project Level

        public int IndicatorTypeOIVM_Proj   { get; set; }
        public string ProjectBasedIndicatorStatementOIVM  { get; set; }
        public double  BaselineQuantitativeOIVM_Proj { get; set; }
        public string  BaselineQuanlitativeOIVM_Proj  { get; set; }
        public double  TargetQuantitativeOIVM_Proj  { get; set; }
        public string  TargetQuanlitativeOIVM_Proj  { get; set; }


        //Directorat Level
        public int IndicatorIDOIVM_Dir   { get; set; }

        public int IndicatorTypeOIVM_Dir   { get; set; }
        public string IndicatorStatementOIVM_Dir  { get; set; }
        public double  BaselineQuantitativeOIVM_Dir { get; set; }
        public string  BaselineQuanlitativeOIVM_Dir  { get; set; }
        public double  TargetQuantitativeOIVM_Dir  { get; set; }
        public string  TargetQuanlitativeOIVM_Dir  { get; set; }



        public DateTime TransactionDate { get; set; }

        
    }
}