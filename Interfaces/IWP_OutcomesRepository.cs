using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;

namespace AUDANEPAD_Integrated.Interfaces
{
    public interface IWP_OutcomesRepository
    {
        WP_Outcomes GetRecord (string Id);

        IEnumerable<WP_Outcomes> GetRecordsByMainRecordId (string recid);

        WP_Outcomes GetRecordByOutcomeStatement (string outcome);

		IEnumerable<WP_Outcomes> GetAllRecords();

        IEnumerable<WP_Outcomes>  GetRecordsByProjectYearAndPeriod (int projectid, int year, int period);

		WP_Outcomes Add(WP_Outcomes rec);
		WP_Outcomes Update(WP_Outcomes recChanges);
		WP_Outcomes Delete(string id);
         
    }
}