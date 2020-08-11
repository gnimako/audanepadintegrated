using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;


namespace AUDANEPAD_Integrated.Interfaces
{
    public interface IWP_OutputActivityCountriesRepository
    {
        WP_OutputActivityCountries GetRecord (string Id);
        IEnumerable<WP_OutputActivityCountries> GetRecordsByMainRecordId (string recid);
        IEnumerable<WP_OutputActivityCountries> GetRecordsByMainRecordOutputId (string wpmainrecid, string outputid);
        IEnumerable<WP_OutputActivityCountries> GetRecordsByOutputId (string outputid);
        IEnumerable<WP_OutputActivityCountries> GetAllRecords();
        IEnumerable<WP_OutputActivityCountries>  GetRecordsByProjectYearAndPeriod (int projectid, int year, int period);
        IEnumerable<WP_OutputActivityCountries>  GetRecordsByProjectYearPeriodOutputIdAndActivityId (int projectid, int year, int period, string outputid, string activityid);
        WP_OutputActivityCountries Add(WP_OutputActivityCountries rec);
        WP_OutputActivityCountries Update(WP_OutputActivityCountries recChanges);
        WP_OutputActivityCountries Delete(string id);
         
    }
}