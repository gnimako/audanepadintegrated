using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;


namespace AUDANEPAD_Integrated.Interfaces
{
    public interface IWP_OutputBudgetRepository
    {
        WP_OutputBudget GetRecord (string Id);

        IEnumerable<WP_OutputBudget> GetRecordsByMainRecordId (string recid);

        IEnumerable<WP_OutputBudget> GetRecordsByMainRecordOutputId (string wpmainrecid, string outputid);

        IEnumerable<WP_OutputBudget> GetRecordsByOutputId (string outputid);

		IEnumerable<WP_OutputBudget> GetAllRecords();

        IEnumerable<WP_OutputBudget>  GetRecordsByProjectYearAndPeriod (int projectid, int year, int period);

        WP_OutputBudget  GetRecordsByProjectYearPeriodAndOutputId (int projectid, int year, int period, string outputid);
        WP_OutputBudget  GetRecordByOutputId (string outputid);

        IEnumerable<WP_OutputBudget>  GetRecordsBySAPLinkId (string saplinkid);

        WP_OutputBudget GetRecordByProjectYearAndPeriodOutputSAPLinkId (int projectid, int year, int period, string outputid, string saplinkid);


		WP_OutputBudget Add(WP_OutputBudget rec);
		WP_OutputBudget Update(WP_OutputBudget recChanges);
		WP_OutputBudget Delete(string id);
         
    }
}