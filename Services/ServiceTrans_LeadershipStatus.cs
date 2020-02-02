using System;
using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;


namespace AUDANEPAD_Integrated.Services
{
    public class ServiceTrans_LeadershipStatus: ITrans_LeadershipStatusRepository
    {
        private readonly AppDbContext context;
		private readonly ILogger<ServiceTrans_LeadershipStatus> logger;
		public ServiceTrans_LeadershipStatus(AppDbContext context, ILogger<ServiceTrans_LeadershipStatus> logger)
		{
		    this.context = context;
		    this.logger = logger;
		}
		public Trans_LeadershipStatus Add(Trans_LeadershipStatus rec)
		{
		    rec.Transaction_Id = Guid.NewGuid().ToString();
		    context.Trans_LeadershipStatus.Add(rec);
		    context.SaveChanges();
		    return rec;
		}

		public Trans_LeadershipStatus Delete(string id)
		{
		    Trans_LeadershipStatus rec = context.Trans_LeadershipStatus.Find(id);
		    if (rec != null)
		    {
		        context.Trans_LeadershipStatus.Remove(rec);
		        context.SaveChanges();
		    }
		    return rec;
		}

		public IEnumerable<Trans_LeadershipStatus> GetAllRecords()
		{
		    return context.Trans_LeadershipStatus;
		}

		public Trans_LeadershipStatus GetRecord(string Id)
		{
		    return context.Trans_LeadershipStatus.Find(Id);
		}

		public Trans_LeadershipStatus Update(Trans_LeadershipStatus recChanges)
		{
		    var satype = context.Trans_LeadershipStatus.Attach(recChanges);
		    satype.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
		    context.SaveChanges();
		    return recChanges;
		}
        
    }
}