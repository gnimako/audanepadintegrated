using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;
using NodaTime;



namespace AUDANEPAD_Integrated.Interfaces
{
    public interface IWP_MainRecordRepository
    {
        WP_MainRecord GetRecord (string Id);

        IEnumerable<WP_MainRecord> GetRecordsByYearAndPeriod (int year, int period);
        IEnumerable<WP_MainRecord> GetRecordsByDivisionYearAndPeriod (int div, int year, int period);
        IEnumerable<WP_MainRecord> GetRecordsByDivisionYearAndPeriodStartEnd (int div, int year, int period, LocalDate PeriodStartDate, LocalDate PeriodEndDate);


        WP_MainRecord GetRecordByProjectYearAndPeriod (int projectid, int year, int period);
        IEnumerable<WP_MainRecord>  GetRecordsByProjectYearAndPeriodRecs (int projectid, int year, int period);
        IEnumerable<WP_MainRecord>  GetDraftRecordsByDivRecs (int div);
        IEnumerable<WP_MainRecord>  GetRecordsByDivRecs (int div);
        
        //Directorate
        IEnumerable<WP_MainRecord>  GetRecordsByDirRecs (int dir);
        IEnumerable<WP_MainRecord> GetRecordsByDirectorateYearAndPeriod (int dir, int year, int period);
        IEnumerable<WP_MainRecord> GetRecordsByDirectorateYearAndPeriodStartEnd (int dir, int year, int period, LocalDate PeriodStartDate, LocalDate PeriodEndDate);
		IEnumerable<WP_MainRecord> GetAllRecords();

		WP_MainRecord Add(WP_MainRecord rec);
		WP_MainRecord Update(WP_MainRecord recChanges);
		WP_MainRecord Delete(string id);
         
    }
}