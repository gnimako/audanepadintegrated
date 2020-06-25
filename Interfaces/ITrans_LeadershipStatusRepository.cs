using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;


namespace AUDANEPAD_Integrated.Interfaces
{
    public interface ITrans_LeadershipStatusRepository
    {
        Trans_LeadershipStatus GetRecord (string Id);

		IEnumerable<Trans_LeadershipStatus> GetAllRecords();
		Trans_LeadershipStatus Add(Trans_LeadershipStatus rec);
		Trans_LeadershipStatus Update(Trans_LeadershipStatus recChanges);
		Trans_LeadershipStatus Delete(string id);
         
    }
}