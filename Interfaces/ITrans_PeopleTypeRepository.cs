using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;


namespace AUDANEPAD_Integrated.Interfaces
{
    public interface ITrans_PeopleTypeRepository
    {
        Trans_PeopleType GetRecord (string Id);

		IEnumerable<Trans_PeopleType> GetAllRecords();
		Trans_PeopleType Add(Trans_PeopleType rec);
		Trans_PeopleType Update(Trans_PeopleType recChanges);
		Trans_PeopleType Delete(string id);
         
    }
}