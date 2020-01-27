using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;

namespace AUDANEPAD_Integrated.Interfaces
{
    public interface ITrans_DSATypeRepository
    {
        Trans_DSAType GetTrans_DSAType(string Id);

		IEnumerable<Trans_DSAType> GetAllTransDSAType();
        Trans_DSAType Add(Trans_DSAType rec);
        Trans_DSAType Update(Trans_DSAType recChanges);
        Trans_DSAType Delete(string id);
         
    }
}