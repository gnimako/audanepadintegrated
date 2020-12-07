using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;


namespace AUDANEPAD_Integrated.Interfaces
{
    public interface IWP_ProcurementRepository
    {

        WP_Procurement GetRecord (string Id);

		IEnumerable<WP_Procurement> GetAllRecords();
        IEnumerable<WP_Procurement> GetRecordsByOutputId (string outputid);
        IEnumerable<WP_Procurement> GetRecordsByMainRecordId (string recid);
		WP_Procurement Add(WP_Procurement rec);
		WP_Procurement Update(WP_Procurement recChanges);
		WP_Procurement Delete(string id);
         
    }
}