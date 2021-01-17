using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;
using NodaTime;

namespace AUDANEPAD_Integrated.Interfaces
{
    public interface IWP_MobilityRepository
    {
        WP_Mobility GetRecord (string Id);

		IEnumerable<WP_Mobility> GetAllRecords();
        IEnumerable<WP_Mobility> GetRecordsByOutputId (string outputid);

        IEnumerable<WP_Mobility> GetRecordsByOutputIdStartEndRange (string outputid, LocalDate StartDate, LocalDate EndDate);
        IEnumerable<WP_Mobility> GetRecordsByMainRecordIdStartEndRange (string recid, LocalDate StartDate, LocalDate EndDate);
        IEnumerable<WP_Mobility> GetRecordsByMainRecordId (string recid);
        IEnumerable<WP_Mobility> GetRecordsByMainRecordOutputId (string wpmainrecid, string outputid);
		WP_Mobility Add(WP_Mobility rec);
		WP_Mobility Update(WP_Mobility recChanges);
		WP_Mobility Delete(string id);
         
    }
}