using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;

namespace AUDANEPAD_Integrated.Interfaces
{
    public interface IWP_DispatchRepository
    {
        WP_Dispatch GetRecord (string Id);

        WP_Dispatch GetRecordByYearAndPeriod (int year, int period);

		IEnumerable<WP_Dispatch> GetAllRecords();
        IEnumerable<WP_Dispatch> GetAllCurrentAndInactiveWPDispatch();

        IEnumerable<WP_Dispatch> GetAllClosedWPDispatch();

        IEnumerable<WP_Dispatch> GetAllCurrentWPDispatch();
        IEnumerable<WP_Dispatch> GetAllCurrentWPDispatchByYear(int year);
		WP_Dispatch Add(WP_Dispatch rec);
		WP_Dispatch Update(WP_Dispatch recChanges);
		WP_Dispatch Delete(string id);

         
    }
}