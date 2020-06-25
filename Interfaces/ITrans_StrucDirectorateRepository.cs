using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;

namespace AUDANEPAD_Integrated.Interfaces
{
    public interface ITrans_StrucDirectorateRepository
    {
        Trans_StrucDirectorate GetRecord (string Id);

        Trans_StrucDirectorate GetRecordByMasterStrucDirectorateId (int Id);

		IEnumerable<Trans_StrucDirectorate> GetAllRecords();
		Trans_StrucDirectorate Add(Trans_StrucDirectorate rec);
		Trans_StrucDirectorate Update(Trans_StrucDirectorate recChanges);
		Trans_StrucDirectorate Delete(string id);
         
    }
}