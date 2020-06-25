using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;

namespace AUDANEPAD_Integrated.Interfaces
{
    public interface ITrans_ProjectRepository
    {

       	Trans_Project GetRecord (string Id);

		IEnumerable<Trans_Project> GetAllRecords();

        IEnumerable<Trans_Project> GetAllRecordsByTransProgrammeID(string TransID);
        IEnumerable<Trans_Project> GetAllRecordsByProgrammeID(int Id);
        IEnumerable<Trans_Project> GetAllRecordsByDirectorateID(int Id);
        IEnumerable<Trans_Project> GetAllRecordsByDivisionID(int Id);
		Trans_Project Add(Trans_Project rec);
		Trans_Project Update(Trans_Project recChanges);
		Trans_Project Delete(string id);

         
    }
}