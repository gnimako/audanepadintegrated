using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;


namespace AUDANEPAD_Integrated.Interfaces
{
    public interface ILkUp_ProgrammeRepository
    {
        LkUp_Programme GetRecord(int Id);

        LkUp_Programme GetRecordByName(string name);
        IEnumerable<LkUp_Programme> GetAllRecords();
        IEnumerable<LkUp_Programme> GetAllRecordsByDirectorateID(int Id);
        IEnumerable<LkUp_Programme> GetAllRecordsByDivisionID(int Id);
        LkUp_Programme Add(LkUp_Programme rec);
        LkUp_Programme Update(LkUp_Programme recChanges);
        LkUp_Programme Delete(int id);
         
    }
}