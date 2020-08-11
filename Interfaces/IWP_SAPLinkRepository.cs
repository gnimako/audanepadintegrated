using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;

namespace AUDANEPAD_Integrated.Interfaces
{
    public interface IWP_SAPLinkRepository
    {
        WP_SAPLink GetRecord (string Id);


		IEnumerable<WP_SAPLink> GetAllRecords();

        IEnumerable<WP_SAPLink> GetAllRecordsByDirectorateAndWPCycle(int dir_id, string wpcycle_id);
        WP_SAPLink GetAllRecordsByDirectorateWPCycleAndWBS(int dir_id, string wpcycle_id, string wbs);

		WP_SAPLink Add(WP_SAPLink rec);
		WP_SAPLink Update(WP_SAPLink recChanges);
		WP_SAPLink Delete(string id);
         
    }
}