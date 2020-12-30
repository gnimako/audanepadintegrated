using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;

namespace AUDANEPAD_Integrated.Interfaces
{
    public interface IWP_RiskProfileCountriesRepository
    {
        WP_RiskProfileCountries GetRecord (string Id);

		IEnumerable<WP_RiskProfileCountries> GetAllRecords();
        IEnumerable<WP_RiskProfileCountries> GetRecordsByOutputId (string outputid);
        IEnumerable<WP_RiskProfileCountries> GetRecordsByMainRecordId (string recid);
        IEnumerable<WP_RiskProfileCountries> GetRecordsByOutputIdAndRiskId (string outputid, string riskid);
        IEnumerable<WP_RiskProfileCountries> GetRecordsByRiskId (string riskid);
		WP_RiskProfileCountries Add(WP_RiskProfileCountries rec);
		WP_RiskProfileCountries Update(WP_RiskProfileCountries recChanges);
		WP_RiskProfileCountries Delete(string id);
         
    }
}