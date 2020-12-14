using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;
using NodaTime;

namespace AUDANEPAD_Integrated.Interfaces
{
    public interface IWP_MobilityInternalTeamRepository
    {
        WP_MobilityInternalTeam GetRecord (string Id);

		IEnumerable<WP_MobilityInternalTeam> GetAllRecords();
        IEnumerable<WP_MobilityInternalTeam> GetRecordsByMainRecordId (string recid);

        IEnumerable<WP_MobilityInternalTeam> GetRecordsByMainRecordIdAndEmployee (string recid, int empid);

        IEnumerable<WP_MobilityInternalTeam> GetRecordsByMobilityId (string id);

        IEnumerable<WP_MobilityInternalTeam>   GetRecordsByEmployeeYearPeriod (int empid, int yearid, int periodid);
        IEnumerable<WP_MobilityInternalTeam>   GetRecordsByEmployeeYearPeriodStartEnd (int empid, int yearid, int periodid, LocalDate PeriodStartDate, LocalDate PeriodEndDate);
		WP_MobilityInternalTeam Add(WP_MobilityInternalTeam rec);
		WP_MobilityInternalTeam Update(WP_MobilityInternalTeam recChanges);
		WP_MobilityInternalTeam Delete(string id);
         
    }
}