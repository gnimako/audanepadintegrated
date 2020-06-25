using System;
using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;


namespace AUDANEPAD_Integrated.Services
{
    public class ServiceTrans_RiskCategory: ITrans_RiskCategoryRepository
    {
        private readonly AppDbContext context;
		private readonly ILogger<ServiceTrans_RiskCategory> logger;
		public ServiceTrans_RiskCategory(AppDbContext context, ILogger<ServiceTrans_RiskCategory> logger)
		{
		    this.context = context;
		    this.logger = logger;
		}
		public Trans_RiskCategory Add(Trans_RiskCategory rec)
		{
		    rec.Transaction_Id = Guid.NewGuid().ToString();
		    context.Trans_RiskCategory.Add(rec);
		    context.SaveChanges();
		    return rec;
		}

		public Trans_RiskCategory Delete(string id)
		{
		    Trans_RiskCategory rec = context.Trans_RiskCategory.Find(id);
		    if (rec != null)
		    {
		        context.Trans_RiskCategory.Remove(rec);
		        context.SaveChanges();
		    }
		    return rec;
		}

		public IEnumerable<Trans_RiskCategory> GetAllRecords()
		{
		    return context.Trans_RiskCategory;
		}

		public Trans_RiskCategory GetRecord(string Id)
		{
		    return context.Trans_RiskCategory.Find(Id);
		}

		public Trans_RiskCategory Update(Trans_RiskCategory recChanges)
		{
		    var satype = context.Trans_RiskCategory.Attach(recChanges);
		    satype.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
		    context.SaveChanges();
		    return recChanges;
		}
        
    }
}