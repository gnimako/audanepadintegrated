using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;

namespace AUDANEPAD_Integrated.Interfaces
{
    public interface IStruc_DirDivIndicatorsRepository
    {
        Struc_DirDivIndicators GetRecord(int Id);

        Struc_DirDivIndicators GetRecordByName(string name);
        Struc_DirDivIndicators GetRecordByNameAndDirectorate(string name, int Directorate_Id);
        Struc_DirDivIndicators GetRecordByRecordNameDirectorateDivisionAndIndicatorType(string name, int Directorate_Id, int Division_Id, int Indicatory_Type_Id);
        IEnumerable<Struc_DirDivIndicators> GetAllRecords();

        IEnumerable<Struc_DirDivIndicators> GetAllDeactivatedRecordsByDivision(int Division_Id);

        IEnumerable<Struc_DirDivIndicators> GetAllRecordsByDirectorate(int Directorate_Id);
        IEnumerable<Struc_DirDivIndicators> GetAllRecordsByDivision(int Division_Id);
        IEnumerable<Struc_DirDivIndicators> GetAllRecordsByDirectorateAndDivision(int Directorate_Id, int Division_Id);
        Struc_DirDivIndicators Add(Struc_DirDivIndicators rec);
        Struc_DirDivIndicators Update(Struc_DirDivIndicators recChanges);
        Struc_DirDivIndicators Delete(int id);

         
    }
}