using System;
using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;


namespace AUDANEPAD_Integrated.Services
{
    public class ServiceTrans_RiskImpact: ITrans_RiskImpactRepository
    {
        private readonly AppDbContext context;
		private readonly ILogger<ServiceTrans_RiskImpact> logger;
		public ServiceTrans_RiskImpact(AppDbContext context, ILogger<ServiceTrans_RiskImpact> logger)
		{
		    this.context = context;
		    this.logger = logger;
		}
		public Trans_RiskImpact Add(Trans_RiskImpact rec)
		{
		    rec.Transaction_Id = Guid.NewGuid().ToString();
		    context.Trans_RiskImpact.Add(rec);
		    context.SaveChanges();
		    return rec;
		}

		public Trans_RiskImpact Delete(string id)
		{
		    Trans_RiskImpact rec = context.Trans_RiskImpact.Find(id);
		    if (rec != null)
		    {
		        context.Trans_RiskImpact.Remove(rec);
		        context.SaveChanges();
		    }
		    return rec;
		}

		public IEnumerable<Trans_RiskImpact> GetAllRecords()
		{
		    return context.Trans_RiskImpact;
		}

		public Trans_RiskImpact GetRecord(string Id)
		{
		    return context.Trans_RiskImpact.Find(Id);
		}

		public Trans_RiskImpact Update(Trans_RiskImpact recChanges)
		{
		    var satype = context.Trans_RiskImpact.Attach(recChanges);
		    satype.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
		    context.SaveChanges();
		    return recChanges;
		}
        
    }
}