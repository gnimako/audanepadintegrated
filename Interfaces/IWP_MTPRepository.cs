using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;

namespace AUDANEPAD_Integrated.Interfaces
{
    public interface IWP_MTPRepository
    {
        WP_MTP GetRecord (string Id);
        IEnumerable<WP_MTP> GetRecordsByMainRecordId (string recid);

		IEnumerable<WP_MTP> GetAllRecords();

        IEnumerable<WP_MTP>  GetRecordsByProjectYearAndPeriod (int projectid, int year, int period);
        IEnumerable<WP_MTP>  GetRecordsByYearAndPeriod ( int year, int period);
        IEnumerable<WP_MTP>  GetRecordsByProjectYearPeriodMainRecId (int projectid, int year, int period, string mainrecid );

        WP_MTP  GetRecordsByProjectYearPeriodAndMTP (int projectid, int year, int period, int mtp);
        WP_MTP  GetRecordsByProjectYearPeriodMTPAndMainRecId (int projectid, int year, int period, int mtp, string mainrecid);

		WP_MTP Add(WP_MTP rec);
		WP_MTP Update(WP_MTP recChanges);
		WP_MTP Delete(string id);
         
    }
}