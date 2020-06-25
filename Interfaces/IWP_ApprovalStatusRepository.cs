using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;

namespace AUDANEPAD_Integrated.Interfaces
{
    public interface IWP_ApprovalStatusRepository
    {
        WP_ApprovalStatus GetRecord (string Id);
        IEnumerable<WP_ApprovalStatus> GetRecordsByMainRecordId (string recid);

		IEnumerable<WP_ApprovalStatus> GetAllRecords();

        IEnumerable<WP_ApprovalStatus>  GetRecordsByProjectYearAndPeriod (int projectid, int year, int period);

		WP_ApprovalStatus Add(WP_ApprovalStatus rec);
		WP_ApprovalStatus Update(WP_ApprovalStatus recChanges);
		WP_ApprovalStatus Delete(string id);
         
    }
}