using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;

namespace AUDANEPAD_Integrated.Interfaces
{
    public interface IStruc_DirectorateRepository
    {
        Struc_Directorate GetRecord(int Id);

        Struc_Directorate GetRecordByName(string name);
        IEnumerable<Struc_Directorate> GetAllRecords();
        Struc_Directorate Add(Struc_Directorate rec);
        Struc_Directorate Update(Struc_Directorate recChanges);
        Struc_Directorate Delete(int id);
         
    }
}