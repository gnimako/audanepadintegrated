using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;


namespace AUDANEPAD_Integrated.Interfaces
{
    public interface IWP_OutcomeIndicatorsRepository
    {
        WP_OutcomeIndicators GetRecord (string Id);

        IEnumerable<WP_OutcomeIndicators> GetRecordsByMainRecordId (string recid);

        IEnumerable<WP_OutcomeIndicators> GetRecordsByMainRecordOutcomeId (string wpmainrecid, string outcomeid);

        IEnumerable<WP_OutcomeIndicators> GetRecordsByOutcomeId (string outcomeid);

		IEnumerable<WP_OutcomeIndicators> GetAllRecords();

        IEnumerable<WP_OutcomeIndicators>  GetRecordsByProjectYearAndPeriod (int projectid, int year, int period);

        IEnumerable<WP_OutcomeIndicators>  GetRecordsByProjectYearPeriodAndOutcomeId (int projectid, int year, int period, string outcomeid);

        WP_OutcomeIndicators GetRecordByProjectYearAndPeriodOutcomeIdIndicatorId (int projectid, int year, int period, string outcomeid, int indicatorid);

        WP_OutcomeIndicators GetRecordByProjectYearAndPeriodOutcomeIdIndicatorId_Dir (int projectid, int year, int period, string outcomeid, int indicatorid);
		WP_OutcomeIndicators Add(WP_OutcomeIndicators rec);
		WP_OutcomeIndicators Update(WP_OutcomeIndicators recChanges);
		WP_OutcomeIndicators Delete(string id);
         
    }
}