using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;
using NodaTime;

namespace AUDANEPAD_Integrated.Interfaces
{
    public interface IWP_DispatchCycleRepository
    {
        WP_DispatchCycle GetRecord (string Id);

        WP_DispatchCycle GetCurrentOpenedCycleRecord ();

        WP_DispatchCycle GetRecordByYearPStartPEnd (int year, LocalDate pstart, LocalDate pend);

        WP_DispatchCycle GetRecordByYearAndPeriod (int year, int period);
        IEnumerable<WP_DispatchCycle> GetRecordsByYearAndPeriodRecs (int year, int period);

		IEnumerable<WP_DispatchCycle> GetAllRecords();
        IEnumerable<WP_DispatchCycle> GetAllCurrentAndInactiveWPDispatch();

        IEnumerable<WP_DispatchCycle> GetAllClosedWPDispatch();

        IEnumerable<WP_DispatchCycle> GetAllCurrentWPDispatch();
        IEnumerable<WP_DispatchCycle> GetAllCurrentWPDispatchByYear(int year);
		WP_DispatchCycle Add(WP_DispatchCycle rec);
		WP_DispatchCycle Update(WP_DispatchCycle recChanges);
		WP_DispatchCycle Delete(string id);

         
    }
}