using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;


namespace AUDANEPAD_Integrated.Interfaces
{
    public interface ILkUp_ProjectRepository
    {
        LkUp_Project GetRecord(int Id);

        LkUp_Project GetRecordByName(string name);
        IEnumerable<LkUp_Project> GetAllRecords();

        IEnumerable<LkUp_Project> GetAllRecordsByProgrammeID(int Id);

        IEnumerable<LkUp_Project> GetAllRecordsByDirectorateID(int Id);
        IEnumerable<LkUp_Project> GetAllRecordsByDivisionID(int Id);
        LkUp_Project Add(LkUp_Project rec);
        LkUp_Project Update(LkUp_Project recChanges);
        LkUp_Project Delete(int id);
         
    }
}