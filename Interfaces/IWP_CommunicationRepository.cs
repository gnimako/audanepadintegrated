using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;
using NodaTime;


namespace AUDANEPAD_Integrated.Interfaces
{
    public interface IWP_CommunicationRepository
    {

        WP_Communication GetRecord (string Id);

        IEnumerable<WP_Communication> GetRecordsByMainRecordId (string recid);

		IEnumerable<WP_Communication> GetAllRecords();
        IEnumerable<WP_Communication> GetRecordsByOutputId (string outputid);
        IEnumerable<WP_Communication> GetRecordsByOutputIdStartEndRange (string outputid, LocalDate StartDate, LocalDate EndDate);
        IEnumerable<WP_Communication> GetRecordsByMainRecordIdStartEndRange (string recid, LocalDate StartDate, LocalDate EndDate);
        IEnumerable<WP_Communication> GetRecordsByMainRecordOutputId (string wpmainrecid, string outputid);
        
		WP_Communication Add(WP_Communication rec);
		WP_Communication Update(WP_Communication recChanges);
		WP_Communication Delete(string id);
         
    }
}