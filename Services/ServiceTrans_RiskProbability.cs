using System;
using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;


namespace AUDANEPAD_Integrated.Services
{
    public class ServiceTrans_RiskProbability: ITrans_RiskProbabilityRepository
    {
        private readonly AppDbContext context;
		private readonly ILogger<ServiceTrans_RiskProbability> logger;
		public ServiceTrans_RiskProbability(AppDbContext context, ILogger<ServiceTrans_RiskProbability> logger)
		{
		    this.context = context;
		    this.logger = logger;
		}
		public Trans_RiskProbability Add(Trans_RiskProbability rec)
		{
		    rec.Transaction_Id = Guid.NewGuid().ToString();
		    context.Trans_RiskProbability.Add(rec);
		    context.SaveChanges();
		    return rec;
		}

		public Trans_RiskProbability Delete(string id)
		{
		    Trans_RiskProbability rec = context.Trans_RiskProbability.Find(id);
		    if (rec != null)
		    {
		        context.Trans_RiskProbability.Remove(rec);
		        context.SaveChanges();
		    }
		    return rec;
		}

		public IEnumerable<Trans_RiskProbability> GetAllRecords()
		{
		    return context.Trans_RiskProbability;
		}

		public Trans_RiskProbability GetRecord(string Id)
		{
		    return context.Trans_RiskProbability.Find(Id);
		}

		public Trans_RiskProbability Update(Trans_RiskProbability recChanges)
		{
		    var satype = context.Trans_RiskProbability.Attach(recChanges);
		    satype.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
		    context.SaveChanges();
		    return recChanges;
		}
        
    }
}