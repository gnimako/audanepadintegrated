using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;

namespace AUDANEPAD_Integrated.Interfaces
{
    public interface ITrans_StrucDivisionRepository
    {
        Trans_StrucDivision GetRecord (string Id);

		IEnumerable<Trans_StrucDivision> GetAllRecords();
        IEnumerable<Trans_StrucDivision> GetAllRecordsByDirectorate(string TransDirectorate_Id);
		Trans_StrucDivision Add(Trans_StrucDivision rec);
		Trans_StrucDivision Update(Trans_StrucDivision recChanges);
		Trans_StrucDivision Delete(string id);
         
    }
}