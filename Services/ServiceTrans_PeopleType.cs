using System;
using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace AUDANEPAD_Integrated.Services
{
    public class ServiceTrans_PeopleType :ITrans_PeopleTypeRepository
    {
        private readonly AppDbContext context;
		private readonly ILogger<ServiceTrans_PeopleType> logger;
		public ServiceTrans_PeopleType(AppDbContext context, ILogger<ServiceTrans_PeopleType> logger)
		{
		    this.context = context;
		    this.logger = logger;
		}
		public Trans_PeopleType Add(Trans_PeopleType rec)
		{
		    rec.Transaction_Id = Guid.NewGuid().ToString();
		    context.Trans_PeopleType.Add(rec);
		    context.SaveChanges();
		    return rec;
		}

		public Trans_PeopleType Delete(string id)
		{
		    Trans_PeopleType rec = context.Trans_PeopleType.Find(id);
		    if (rec != null)
		    {
		        context.Trans_PeopleType.Remove(rec);
		        context.SaveChanges();
		    }
		    return rec;
		}

		public IEnumerable<Trans_PeopleType> GetAllRecords()
		{
		    return context.Trans_PeopleType;
		}

		public Trans_PeopleType GetRecord(string Id)
		{
		    return context.Trans_PeopleType.Find(Id);
		}

		public Trans_PeopleType Update(Trans_PeopleType recChanges)
		{
		    var satype = context.Trans_PeopleType.Attach(recChanges);
		    satype.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
		    context.SaveChanges();
		    return recChanges;
		}
        
    }
}