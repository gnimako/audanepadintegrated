using System;
using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;


namespace AUDANEPAD_Integrated.Services
{
    public class ServiceTrans_RiskRTimeframe: ITrans_RiskRTimeframeRepository
    {
        private readonly AppDbContext context;
		private readonly ILogger<ServiceTrans_RiskRTimeframe> logger;
		public ServiceTrans_RiskRTimeframe(AppDbContext context, ILogger<ServiceTrans_RiskRTimeframe> logger)
		{
		    this.context = context;
		    this.logger = logger;
		}
		public Trans_RiskRTimeframe Add(Trans_RiskRTimeframe rec)
		{
		    rec.Transaction_Id = Guid.NewGuid().ToString();
		    context.Trans_RiskRTimeframe.Add(rec);
		    context.SaveChanges();
		    return rec;
		}

		public Trans_RiskRTimeframe Delete(string id)
		{
		    Trans_RiskRTimeframe rec = context.Trans_RiskRTimeframe.Find(id);
		    if (rec != null)
		    {
		        context.Trans_RiskRTimeframe.Remove(rec);
		        context.SaveChanges();
		    }
		    return rec;
		}

		public IEnumerable<Trans_RiskRTimeframe> GetAllRecords()
		{
		    return context.Trans_RiskRTimeframe;
		}

		public Trans_RiskRTimeframe GetRecord(string Id)
		{
		    return context.Trans_RiskRTimeframe.Find(Id);
		}

		public Trans_RiskRTimeframe Update(Trans_RiskRTimeframe recChanges)
		{
		    var satype = context.Trans_RiskRTimeframe.Attach(recChanges);
		    satype.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
		    context.SaveChanges();
		    return recChanges;
		}
        
    }
}