using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;

namespace AUDANEPAD_Integrated.Interfaces
{
    public interface IStruc_DivisionRepository
    {
        Struc_Division GetRecord(int Id);

        Struc_Division GetRecordByName(string name);
        Struc_Division GetRecordByNameAndDirectorate(string name, int Directorate_Id);
        IEnumerable<Struc_Division> GetAllRecords();

        IEnumerable<Struc_Division> GetAllRecordsByDirectorate(int Directorate_Id);
        Struc_Division Add(Struc_Division rec);
        Struc_Division Update(Struc_Division recChanges);
        Struc_Division Delete(int id);
         
    }
}