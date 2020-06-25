using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;

namespace AUDANEPAD_Integrated.Interfaces
{
    public interface IWP_OutputsRepository
    {
        WP_Outputs GetRecord (string Id);

        IEnumerable<WP_Outputs> GetRecordsByMainRecordId (string recid);

        WP_Outputs GetRecordByOutputStatement (string output);

		IEnumerable<WP_Outputs> GetAllRecords();

        IEnumerable<WP_Outputs>  GetRecordsByProjectYearAndPeriod (int projectid, int year, int period);

		WP_Outputs Add(WP_Outputs rec);
		WP_Outputs Update(WP_Outputs recChanges);
		WP_Outputs Delete(string id);
         
    }
}