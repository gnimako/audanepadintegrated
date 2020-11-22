using System;
using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace AUDANEPAD_Integrated.Services
{
    public class ServiceWP_MobilityExternalTeam: IWP_MobilityExternalTeamRepository
    {
        private readonly AppDbContext context;
		private readonly ILogger<ServiceWP_MobilityExternalTeam> logger;

		public ServiceWP_MobilityExternalTeam(AppDbContext context, ILogger<ServiceWP_MobilityExternalTeam> logger)
		{
		    this.context = context;
		    this.logger = logger;
		}
		public WP_MobilityExternalTeam Add(WP_MobilityExternalTeam rec)
		{
		    rec.Transaction_Id = Guid.NewGuid().ToString();
		    context.WP_MobilityExternalTeam.Add(rec);
		    context.SaveChanges();
		    return rec;
		}

		public WP_MobilityExternalTeam Delete(string id)
		{
		    WP_MobilityExternalTeam rec = context.WP_MobilityExternalTeam.Find(id);
		    if (rec != null)
		    {
		        context.WP_MobilityExternalTeam.Remove(rec);
		        context.SaveChanges();
		    }
		    return rec;
		}

		public IEnumerable<WP_MobilityExternalTeam> GetAllRecords()
		{
		    return context.WP_MobilityExternalTeam;
		}
		public IEnumerable<WP_MobilityExternalTeam> GetRecordsByMobilityId (string id)
        {
            var records = context.WP_MobilityExternalTeam
                                .Where(s => s.WPMobility_id==id)
                                .ToList();

            return records;
        }

		public WP_MobilityExternalTeam GetRecord(string Id)
		{
		    return context.WP_MobilityExternalTeam.Find(Id);
		}

		public WP_MobilityExternalTeam GetRecordByMobilityIdExtPartIdAndDesc (string mobilityid, int extpartid, string descr)
        {
            var rec = context.WP_MobilityExternalTeam
						.Where(s => s.WPMobility_id == mobilityid && s.ExternalParticipant_Id==extpartid && s.ExternalParticipant_Description==descr)
						.FirstOrDefault();
            return rec;
        }

		public WP_MobilityExternalTeam Update(WP_MobilityExternalTeam recChanges)
		{
		    var satype = context.WP_MobilityExternalTeam.Attach(recChanges);
		    satype.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
		    context.SaveChanges();
		    return recChanges;
		}
        
    }
}