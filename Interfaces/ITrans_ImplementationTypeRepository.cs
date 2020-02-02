using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;

namespace AUDANEPAD_Integrated.Interfaces
{
    public interface ITrans_ImplementationTypeRepository
    {
        Trans_ImplementationType GetRecord (string Id);

		IEnumerable<Trans_ImplementationType> GetAllRecords();
		Trans_ImplementationType Add(Trans_ImplementationType rec);
		Trans_ImplementationType Update(Trans_ImplementationType recChanges);
		Trans_ImplementationType Delete(string id);
         
    }
}