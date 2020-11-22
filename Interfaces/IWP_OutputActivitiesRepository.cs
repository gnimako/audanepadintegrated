using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;

namespace AUDANEPAD_Integrated.Interfaces
{
    public interface IWP_OutputActivitiesRepository
    {
        WP_OutputActivities GetRecord (string Id);
        IEnumerable<WP_OutputActivities> GetRecordsByMainRecordId (string recid);
        IEnumerable<WP_OutputActivities> GetRecordsByMainRecordIdMS (string recid);
        IEnumerable<WP_OutputActivities> GetRecordsByMainRecordOutputId (string wpmainrecid, string outputid);
        IEnumerable<WP_OutputActivities> GetRecordsByMainRecordImpType (string wpmainrecid, int implementationtypeid);

        IEnumerable<WP_OutputActivities> GetRecordsByMainRecIDYearAndWithinMonth(string wpmainrecid, int year, int month);
        IEnumerable<WP_OutputActivities> GetRecordsByOutputId (string outputid);
        IEnumerable<WP_OutputActivities> GetRecordsByWPSAPLink_Id (string saplinkid);
        IEnumerable<WP_OutputActivities> GetAllRecords();
        IEnumerable<WP_OutputActivities>  GetRecordsByProjectYearAndPeriod (int projectid, int year, int period);
        IEnumerable<WP_OutputActivities>  GetRecordsByProjectYearPeriodAndOutputId (int projectid, int year, int period, string outputid);
        WP_OutputActivities  GetRecordsByProjectYearPeriodOutputIdActivityTypeAndDescr (int projectid, int year, int period, string outputid, int activitytype, string activitydescr);
        WP_OutputActivities Add(WP_OutputActivities rec);
        WP_OutputActivities Update(WP_OutputActivities recChanges);
        WP_OutputActivities Delete(string id);
    
    }
}