using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;


namespace AUDANEPAD_Integrated.Interfaces
{
    public interface IWP_MainRecordRepository
    {
        WP_MainRecord GetRecord (string Id);

        IEnumerable<WP_MainRecord> GetRecordsByYearAndPeriod (int year, int period);

        WP_MainRecord GetRecordByProjectYearAndPeriod (int projectid, int year, int period);

		IEnumerable<WP_MainRecord> GetAllRecords();

		WP_MainRecord Add(WP_MainRecord rec);
		WP_MainRecord Update(WP_MainRecord recChanges);
		WP_MainRecord Delete(string id);
         
    }
}