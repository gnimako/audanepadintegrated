using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;
using NodaTime;


namespace AUDANEPAD_Integrated.Interfaces
{
    public interface IWP_ProcurementRepository
    {

        WP_Procurement GetRecord (string Id);

		IEnumerable<WP_Procurement> GetAllRecords();
        IEnumerable<WP_Procurement> GetRecordsByOutputId (string outputid);
        IEnumerable<WP_Procurement> GetRecordsByOutputIdStartEndRange (string outputid, LocalDate StartDate, LocalDate EndDate);
        IEnumerable<WP_Procurement> GetRecordsByMainRecordIdStartEndRange (string recid, LocalDate StartDate, LocalDate EndDate);
        IEnumerable<WP_Procurement> GetRecordsByMainRecordId (string recid);
        IEnumerable<WP_Procurement> GetRecordsByMainRecordOutputId (string wpmainrecid, string outputid);

        
		WP_Procurement Add(WP_Procurement rec);
		WP_Procurement Update(WP_Procurement recChanges);
		WP_Procurement Delete(string id);
         
    }
}