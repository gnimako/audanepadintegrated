using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;
using NodaTime;


namespace AUDANEPAD_Integrated.Interfaces
{
    public interface IWP_MobilityLimitRepository
    {
        WP_MobilityLimit GetRecord (string Id);

        WP_MobilityLimit  GetRecordByEmployeeAndCycle (int empid, string cycleid);

        WP_MobilityLimit  GetRecordByEmployeeYearPeriod (int empid, int yearid, int periodid);
        WP_MobilityLimit  GetRecordByEmployeeYearPeriodStartEnd (int empid, int yearid, int periodid, LocalDate PeriodStartDate, LocalDate PeriodEndDate);



		IEnumerable<WP_MobilityLimit> GetAllRecords();
        IEnumerable<WP_MobilityLimit>  GetRecordsByWPCycle (string wpcycleid);
		WP_MobilityLimit Add(WP_MobilityLimit rec);
		WP_MobilityLimit Update(WP_MobilityLimit recChanges);
		WP_MobilityLimit Delete(string id);
         
         
    }
}