using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;

namespace AUDANEPAD_Integrated.Interfaces
{
    public interface ILkUp_LeadershipStatusRepository
    {
        LkUp_LeadershipStatus GetRecord(int Id);

        LkUp_LeadershipStatus GetRecordByName(string name);
        IEnumerable<LkUp_LeadershipStatus> GetAllRecords();
        LkUp_LeadershipStatus Add(LkUp_LeadershipStatus atype);
        LkUp_LeadershipStatus Update(LkUp_LeadershipStatus atypeChanges);
        LkUp_LeadershipStatus Delete(int id);

         
    }
}