using System;
using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace AUDANEPAD_Integrated.Services
{
    public class ServiceTrans_StrucDivision:ITrans_StrucDivisionRepository
    {
        private readonly AppDbContext context;
		private readonly ILogger<ServiceTrans_StrucDivision> logger;
        
		public ServiceTrans_StrucDivision(AppDbContext context, ILogger<ServiceTrans_StrucDivision> logger)
		{
		    this.context = context;
		    this.logger = logger;
		}
		public Trans_StrucDivision Add(Trans_StrucDivision rec)
		{
		    rec.Transaction_Id = Guid.NewGuid().ToString();
		    context.Trans_StrucDivision.Add(rec);
		    context.SaveChanges();
		    return rec;
		}

		public Trans_StrucDivision Delete(string id)
		{
        
		    Trans_StrucDivision rec = context.Trans_StrucDivision.Find(id);

		    if (rec != null)
		    {
		        context.Trans_StrucDivision.Remove(rec);
		        context.SaveChanges();
		    }
		    return rec;
		}

		public IEnumerable<Trans_StrucDivision> GetAllRecords()
		{
		    return context.Trans_StrucDivision;
		}

        public IEnumerable<Trans_StrucDivision> GetAllRecordsByDirectorate(string TransDirectorate_Id)
        {
            var records = context.Trans_StrucDivision
                                .Where(s => s.TransDirectorate_Id == TransDirectorate_Id)
                                .ToList();

            return records;
        }

        public Trans_StrucDivision GetRecord(string Id)
		{
		    return context.Trans_StrucDivision.Find(Id);
		}

		public Trans_StrucDivision Update(Trans_StrucDivision recChanges)
		{
		    var satype = context.Trans_StrucDivision.Attach(recChanges);
		    satype.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
		    context.SaveChanges();
		    return recChanges;
		}
        
    }
}