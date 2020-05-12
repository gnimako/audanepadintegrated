using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;


namespace AUDANEPAD_Integrated.Interfaces
{
    public interface ITrans_ProgrammeRepository
    {

       	Trans_Programme GetRecord (string Id);

        Trans_Programme GetRecordByMainProgrammeID (int Id);

		IEnumerable<Trans_Programme> GetAllRecords();


        IEnumerable<Trans_Programme> GetAllRecordsByDirectorateID(int Id);
        IEnumerable<Trans_Programme> GetAllRecordsByDivisionID(int Id);
		Trans_Programme Add(Trans_Programme rec);
		Trans_Programme Update(Trans_Programme recChanges);
		Trans_Programme Delete(string id);

         
    }
}