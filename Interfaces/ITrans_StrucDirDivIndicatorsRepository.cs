using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;


namespace AUDANEPAD_Integrated.Interfaces
{
    public interface ITrans_StrucDirDivIndicatorsRepository
    {
        Trans_StrucDirDivIndicators GetRecord (string Id);

		IEnumerable<Trans_StrucDirDivIndicators> GetAllRecords();
        IEnumerable<Trans_StrucDirDivIndicators> GetAllRecordsByDirectorate(int Directorate_Id);
        IEnumerable<Trans_StrucDirDivIndicators> GetAllRecordsByDivision(int Division_Id);
        IEnumerable<Trans_StrucDirDivIndicators> GetAllRecordsByDirectorateAndDivision(int Directorate_Id, int Division_Id);
		Trans_StrucDirDivIndicators Add(Trans_StrucDirDivIndicators rec);
		Trans_StrucDirDivIndicators Update(Trans_StrucDirDivIndicators recChanges);
		Trans_StrucDirDivIndicators Delete(string id);
         
    }
}