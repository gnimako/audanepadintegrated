using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;


namespace AUDANEPAD_Integrated.Interfaces
{
    public interface IWP_OutputIndicatorsRepository
    {
        WP_OutputIndicators GetRecord (string Id);

        IEnumerable<WP_OutputIndicators> GetRecordsByMainRecordId (string recid);

        IEnumerable<WP_OutputIndicators> GetRecordsByMainRecordOutputId (string wpmainrecid, string outputid);

        IEnumerable<WP_OutputIndicators> GetRecordsByOutputId (string outputid);

		IEnumerable<WP_OutputIndicators> GetAllRecords();

        IEnumerable<WP_OutputIndicators>  GetRecordsByProjectYearAndPeriod (int projectid, int year, int period);

        IEnumerable<WP_OutputIndicators>  GetRecordsByProjectYearPeriodAndOutputId (int projectid, int year, int period, string outputid);

        WP_OutputIndicators GetRecordByProjectYearAndPeriodOutputIdIndicatorId (int projectid, int year, int period, string outputid, int indicatorid);

        WP_OutputIndicators GetRecordByProjectYearAndPeriodOutputIdIndicatorId_Dir (int projectid, int year, int period, string outputid, int indicatorid);
		WP_OutputIndicators Add(WP_OutputIndicators rec);
		WP_OutputIndicators Update(WP_OutputIndicators recChanges);
		WP_OutputIndicators Delete(string id);
         
         
    }
}