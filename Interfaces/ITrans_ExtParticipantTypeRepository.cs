using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;

namespace AUDANEPAD_Integrated.Interfaces
{
    public interface ITrans_ExtParticipantTypeRepository
    {
        Trans_ExtParticipantType GetRecord (string Id);

		IEnumerable<Trans_ExtParticipantType> GetAllRecords();
        Trans_ExtParticipantType Add(Trans_ExtParticipantType rec);
        Trans_ExtParticipantType Update(Trans_ExtParticipantType recChanges);
        Trans_ExtParticipantType Delete(string id);
         
    }
}