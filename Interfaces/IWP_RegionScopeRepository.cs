using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;

namespace AUDANEPAD_Integrated.Interfaces
{
    public interface IWP_RegionScopeRepository
    {
        WP_RegionScope GetRecord (string Id);
        IEnumerable<WP_RegionScope> GetRecordsByMainRecordId (string recid);

		IEnumerable<WP_RegionScope> GetAllRecords();

        IEnumerable<WP_RegionScope>  GetRecordsByProjectYearAndPeriod (int projectid, int year, int period);

        IEnumerable<WP_RegionScope>  GetRecordsByProjectYearPeriodAndMainRecId (int projectid, int year, int period, string mainrecid);

        WP_RegionScope  GetRecordsByProjectYearPeriodAndRegion (int projectid, int year, int period, int region);

		WP_RegionScope Add(WP_RegionScope rec);
		WP_RegionScope Update(WP_RegionScope recChanges);
		WP_RegionScope Delete(string id);
         
    }
}