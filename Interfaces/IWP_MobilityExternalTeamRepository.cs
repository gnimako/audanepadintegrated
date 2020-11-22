using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;

namespace AUDANEPAD_Integrated.Interfaces
{
    public interface IWP_MobilityExternalTeamRepository
    {
        WP_MobilityExternalTeam GetRecord (string Id);

        WP_MobilityExternalTeam GetRecordByMobilityIdExtPartIdAndDesc (string mobilityid, int extpartid, string descr);

		IEnumerable<WP_MobilityExternalTeam> GetAllRecords();
        IEnumerable<WP_MobilityExternalTeam> GetRecordsByMobilityId (string id);
		WP_MobilityExternalTeam Add(WP_MobilityExternalTeam rec);
		WP_MobilityExternalTeam Update(WP_MobilityExternalTeam recChanges);
		WP_MobilityExternalTeam Delete(string id);
         
         
    }
}