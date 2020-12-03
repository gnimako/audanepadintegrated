using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;
using NodaTime;


namespace AUDANEPAD_Integrated.Interfaces
{
    public interface IWP_PRCBudgetLimitsRepository
    {
        WP_PRCBudgetLimits GetRecord (string Id);

		IEnumerable<WP_PRCBudgetLimits> GetAllRecords();
        IEnumerable<WP_PRCBudgetLimits>  GetRecordsByWPCycle (string wpcycleid);

        WP_PRCBudgetLimits  GetRecordByDirectorateAndCycle (int dirid, string cycleid);

        WP_PRCBudgetLimits  GetRecordByDirectorateearPeriod (int dirid, int yearid, int periodid);
        WP_PRCBudgetLimits  GetRecordByDirectorateYearPeriodStartEnd (int dirid, int yearid, int periodid, LocalDate PeriodStartDate, LocalDate PeriodEndDate);


		WP_PRCBudgetLimits Add(WP_PRCBudgetLimits rec);
		WP_PRCBudgetLimits Update(WP_PRCBudgetLimits recChanges);
		WP_PRCBudgetLimits Delete(string id);
         
    }
}