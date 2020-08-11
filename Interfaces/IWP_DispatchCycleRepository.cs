using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;

namespace AUDANEPAD_Integrated.Interfaces
{
    public interface IWP_DispatchCycleRepository
    {
        WP_DispatchCycle GetRecord (string Id);

        WP_DispatchCycle GetRecordByYearAndPeriod (int year, int period);

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