using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;


namespace AUDANEPAD_Integrated.Interfaces
{
    public interface ILkUp_PeopleTypeRepository
    {
        LkUp_PeopleType GetRecord(int Id);

        LkUp_PeopleType GetRecordByName(string name);
        IEnumerable<LkUp_PeopleType> GetAllRecords();
        LkUp_PeopleType Add(LkUp_PeopleType atype);
        LkUp_PeopleType Update(LkUp_PeopleType atypeChanges);
        LkUp_PeopleType Delete(int id);
         
    }
}