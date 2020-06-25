
using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;

namespace AUDANEPAD_Integrated.Interfaces
{
    public interface ILkUp_ExtParticipantTypeRepository
    {
        LkUp_ExtParticipantType GetRecord(int Id);

        LkUp_ExtParticipantType GetRecordByName(string name);
		IEnumerable<LkUp_ExtParticipantType> GetAllRecords();
        LkUp_ExtParticipantType Add(LkUp_ExtParticipantType atype);
        LkUp_ExtParticipantType Update(LkUp_ExtParticipantType atypeChanges);
        LkUp_ExtParticipantType Delete(int id);
         
    }
}