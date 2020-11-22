using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;

namespace AUDANEPAD_Integrated.Interfaces
{
    public interface IWP_MobilityRepository
    {
        WP_Mobility GetRecord (string Id);

		IEnumerable<WP_Mobility> GetAllRecords();
        IEnumerable<WP_Mobility> GetRecordsByOutputId (string outputid);
		WP_Mobility Add(WP_Mobility rec);
		WP_Mobility Update(WP_Mobility recChanges);
		WP_Mobility Delete(string id);
         
    }
}