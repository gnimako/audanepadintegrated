using System;
using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;


namespace AUDANEPAD_Integrated.Services
{
    public class ServiceTrans_ImplementationType: ITrans_ImplementationTypeRepository
    {
        private readonly AppDbContext context;
		private readonly ILogger<ServiceTrans_ImplementationType> logger;
		public ServiceTrans_ImplementationType(AppDbContext context, ILogger<ServiceTrans_ImplementationType> logger)
		{
		    this.context = context;
		    this.logger = logger;
		}
		public Trans_ImplementationType Add(Trans_ImplementationType rec)
		{
		    rec.Transaction_Id = Guid.NewGuid().ToString();
		    context.Trans_ImplementationType.Add(rec);
		    context.SaveChanges();
		    return rec;
		}

		public Trans_ImplementationType Delete(string id)
		{
		    Trans_ImplementationType rec = context.Trans_ImplementationType.Find(id);
		    if (rec != null)
		    {
		        context.Trans_ImplementationType.Remove(rec);
		        context.SaveChanges();
		    }
		    return rec;
		}

		public IEnumerable<Trans_ImplementationType> GetAllRecords()
		{
		    return context.Trans_ImplementationType;
		}

		public Trans_ImplementationType GetRecord(string Id)
		{
		    return context.Trans_ImplementationType.Find(Id);
		}

		public Trans_ImplementationType Update(Trans_ImplementationType recChanges)
		{
		    var satype = context.Trans_ImplementationType.Attach(recChanges);
		    satype.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
		    context.SaveChanges();
		    return recChanges;
		}
        
    }
}