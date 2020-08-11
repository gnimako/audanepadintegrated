using System;
using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;



namespace AUDANEPAD_Integrated.Services
{
    public class ServiceWP_SAPLink:IWP_SAPLinkRepository
    {
         private readonly AppDbContext context;
		private readonly ILogger<ServiceWP_SAPLink> logger;
		public ServiceWP_SAPLink(AppDbContext context, ILogger<ServiceWP_SAPLink> logger)
		{
		    this.context = context;
		    this.logger = logger;
		}
		public WP_SAPLink Add(WP_SAPLink rec)
		{
		    rec.Transaction_Id = Guid.NewGuid().ToString();
		    context.WP_SAPLink.Add(rec);
		    context.SaveChanges();
		    return rec;
		}

		public WP_SAPLink Delete(string id)
		{
		    WP_SAPLink rec = context.WP_SAPLink.Find(id);
		    if (rec != null)
		    {
		        context.WP_SAPLink.Remove(rec);
		        context.SaveChanges();
		    }
		    return rec;
		}

		public IEnumerable<WP_SAPLink> GetAllRecords()
		{
		    return context.WP_SAPLink;
		}
        public IEnumerable<WP_SAPLink> GetAllRecordsByDirectorateAndWPCycle(int dir_id, string wpcycle_id)
        {
            var rec = context.WP_SAPLink
						.Where(s => s.Directorate_Id == dir_id && s.WPDispatchCycle_Id == wpcycle_id)
						.ToList();
            return rec;
        }
		public WP_SAPLink GetAllRecordsByDirectorateWPCycleAndWBS(int dir_id, string wpcycle_id, string wbs)
        {
            var rec = context.WP_SAPLink
						.Where(s => s.Directorate_Id == dir_id && s.WPDispatchCycle_Id == wpcycle_id && s.SAP_WBS==wbs)
						.SingleOrDefault();
            return rec;
        }



		public WP_SAPLink GetRecord(string Id)
		{
		    return context.WP_SAPLink.Find(Id);
		}



        public WP_SAPLink Update(WP_SAPLink recChanges)
		{
		    var satype = context.WP_SAPLink.Attach(recChanges);
		    satype.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
		    context.SaveChanges();
		    return recChanges;
		}
        
    }
}