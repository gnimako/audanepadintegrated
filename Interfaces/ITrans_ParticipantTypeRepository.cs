using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;

namespace AUDANEPAD_Integrated.Interfaces
{
    public interface ITrans_ParticipantTypeRepository
    {
        Trans_ParticipantType GetRecord (string Id);

		IEnumerable<Trans_ParticipantType> GetAllRecords();
		Trans_ParticipantType Add(Trans_ParticipantType rec);
		Trans_ParticipantType Update(Trans_ParticipantType recChanges);
		Trans_ParticipantType Delete(string id);

         
    }
}