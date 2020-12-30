using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;
using NodaTime;

namespace AUDANEPAD_Integrated.Interfaces
{
    public interface IWP_AUDAPriorityRepository
    {

        WP_AUDAPriority GetRecord (string Id);

        IEnumerable<WP_AUDAPriority> GetRecordsByMainRecordId (string recid);

        WP_AUDAPriority  GetRecordsByProjectYearPeriodAndPriority (int projectid, int year, int period, int priority);
        WP_AUDAPriority  GetRecordsByProjectYearPeriodPriorityMainRecId (int projectid, int year, int period, int priority, string mainrecid);

        IEnumerable<WP_AUDAPriority>  GetRecordsByProjectYearAndPeriod (int projectid, int year, int period);
        IEnumerable<WP_AUDAPriority>  GetRecordsByYearAndPeriod (int year, int period);

        IEnumerable<WP_AUDAPriority>  GetRecordsByYearPeriodAndPriority (int year, int period, int priority);

       // IEnumerable<WP_MainRecord> GetRecordsByYearPeriodPriorityAndPeriodStartEnd (int year, int period, int priority, LocalDate PeriodStartDate, LocalDate PeriodEndDate);
        IEnumerable<WP_AUDAPriority>  GetRecordsByProjectYearPeriodAndMainRecId (int projectid, int year, int period, string mainrecid);

		IEnumerable<WP_AUDAPriority> GetAllRecords();

		WP_AUDAPriority Add(WP_AUDAPriority rec);
		WP_AUDAPriority Update(WP_AUDAPriority recChanges);
		WP_AUDAPriority Delete(string id);
         
    }
}