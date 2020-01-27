using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;

namespace AUDANEPAD_Integrated.Interfaces
{
    public interface ILkUp_DSATypeRepository
    {
        LkUp_DSAType GetDSAType(int Id);

        LkUp_DSAType GetDSATypeByName(string name);
        IEnumerable<LkUp_DSAType> GetAllDSAType();
        LkUp_DSAType Add(LkUp_DSAType rec);
        LkUp_DSAType Update(LkUp_DSAType recChanges);
        LkUp_DSAType Delete(int id);
         
    }
}