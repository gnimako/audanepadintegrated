using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;

namespace AUDANEPAD_Integrated.Interfaces
{
    public interface IWP_CountryScopeRepository
    {
        WP_CountryScope GetRecord (string Id);
        IEnumerable<WP_CountryScope> GetRecordsByMainRecordId (string recid);

		IEnumerable<WP_CountryScope> GetAllRecords();

        IEnumerable<WP_CountryScope>  GetRecordsByProjectYearAndPeriod (int projectid, int year, int period);
        IEnumerable<WP_CountryScope>  GetRecordsByProjectYearPeriodAndMainRecId (int projectid, int year, int period, string mainrecid);

        WP_CountryScope  GetRecordsByProjectYearPeriodAndCountry (int projectid, int year, int period, int country);

		WP_CountryScope Add(WP_CountryScope rec);
		WP_CountryScope Update(WP_CountryScope recChanges);
		WP_CountryScope Delete(string id);
         
    }
}