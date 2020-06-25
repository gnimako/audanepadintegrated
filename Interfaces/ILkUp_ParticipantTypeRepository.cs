using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;


namespace AUDANEPAD_Integrated.Interfaces
{
    public interface ILkUp_ParticipantTypeRepository
    {
        LkUp_ParticipantType GetRecord(int Id);

        LkUp_ParticipantType GetRecordByName(string name);
        IEnumerable<LkUp_ParticipantType> GetAllRecords();
        LkUp_ParticipantType Add(LkUp_ParticipantType atype);
        LkUp_ParticipantType Update(LkUp_ParticipantType atypeChanges);
        LkUp_ParticipantType Delete(int id);

         
    }
}