
using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;

namespace AUDANEPAD_Integrated.Interfaces
{
    public interface IWP_RiskProfileRepository
    {

        WP_RiskProfile GetRecord (string Id);
        IEnumerable<WP_RiskProfile> GetRecordsByMainRecordId (string recid);

		IEnumerable<WP_RiskProfile> GetAllRecords();
        IEnumerable<WP_RiskProfile> GetRecordsByOutputId (string outputid);
        IEnumerable<WP_RiskProfile> GetRecordsByMainRecordOutputId (string wpmainrecid, string outputid);
		WP_RiskProfile Add(WP_RiskProfile rec);
		WP_RiskProfile Update(WP_RiskProfile recChanges);
		WP_RiskProfile Delete(string id);
         
         
    }
}