using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;

namespace AUDANEPAD_Integrated.Interfaces
{
    public interface ILkUp_ImplementationTypeRepository
    {
        LkUp_ImplementationType GetRecord(int Id);

        LkUp_ImplementationType GetRecordByName(string name);
        IEnumerable<LkUp_ImplementationType> GetAllRecords();
        LkUp_ImplementationType Add(LkUp_ImplementationType atype);
        LkUp_ImplementationType Update(LkUp_ImplementationType atypeChanges);
        LkUp_ImplementationType Delete(int id);
         
    }
}