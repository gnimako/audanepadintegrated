using System;
using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace AUDANEPAD_Integrated.Services
{
    public class ServiceTrans_StrategyOutputIndicators: ITrans_StrategyOutputIndicators
    {
        private readonly AppDbContext context;
		private readonly ILogger<ServiceTrans_StrategyOutputIndicators> logger;


		public ServiceTrans_StrategyOutputIndicators(AppDbContext context, ILogger<ServiceTrans_StrategyOutputIndicators> logger)
		{
		    this.context = context;
		    this.logger = logger;
		}
		public Trans_StrategyOutputIndicators Add(Trans_StrategyOutputIndicators rec)
		{
		    rec.Transaction_Id = Guid.NewGuid().ToString();
		    context.Trans_StrategyOutputIndicators.Add(rec);
		    context.SaveChanges();
		    return rec;
		}

		public Trans_StrategyOutputIndicators Delete(string id)
		{
        
		    Trans_StrategyOutputIndicators rec = context.Trans_StrategyOutputIndicators.Find(id);

		    if (rec != null)
		    {
		        context.Trans_StrategyOutputIndicators.Remove(rec);
		        context.SaveChanges();
		    }
		    return rec;
		}

		public IEnumerable<Trans_StrategyOutputIndicators> GetAllRecords()
		{
		    return context.Trans_StrategyOutputIndicators;
		}

		public Trans_StrategyOutputIndicators GetRecord(string Id)
		{
		    return context.Trans_StrategyOutputIndicators.Find(Id);
		}

        public Trans_StrategyOutputIndicators Update(Trans_StrategyOutputIndicators recChanges)
		{
		    var satype = context.Trans_StrategyOutputIndicators.Attach(recChanges);
		    satype.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
		    context.SaveChanges();
		    return recChanges;
		}
        
    }
}