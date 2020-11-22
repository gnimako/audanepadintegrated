using System;
using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;




namespace AUDANEPAD_Integrated.Services
{
    public class ServiceTrans_StrucDirDivIndicators: ITrans_StrucDirDivIndicatorsRepository
    {
        private readonly AppDbContext context;
		private readonly ILogger<Trans_StrucDirDivIndicators> logger;
        
		public ServiceTrans_StrucDirDivIndicators(AppDbContext context, ILogger<Trans_StrucDirDivIndicators> logger)
		{
		    this.context = context;
		    this.logger = logger;
		}
		public Trans_StrucDirDivIndicators Add(Trans_StrucDirDivIndicators rec)
		{
		    rec.Transaction_Id = Guid.NewGuid().ToString();
		    context.Trans_StrucDirDivIndicators.Add(rec);
		    context.SaveChanges();
		    return rec;
		}

		public Trans_StrucDirDivIndicators Delete(string id)
		{
        
		    Trans_StrucDirDivIndicators rec = context.Trans_StrucDirDivIndicators.Find(id);

		    if (rec != null)
		    {
		        context.Trans_StrucDirDivIndicators.Remove(rec);
		        context.SaveChanges();
		    }
		    return rec;
		}

		public IEnumerable<Trans_StrucDirDivIndicators> GetAllRecords()
		{
		    return context.Trans_StrucDirDivIndicators;
		}

        public IEnumerable<Trans_StrucDirDivIndicators> GetAllRecordsByDirectorate(int Directorate_Id)
        {
            var records = context.Trans_StrucDirDivIndicators
                                .Where(s => s.Directorate_Id == Directorate_Id)
                                .ToList();

            return records;
        }

        public IEnumerable<Trans_StrucDirDivIndicators> GetAllRecordsByDivision(int Division_Id)
        {
            var records = context.Trans_StrucDirDivIndicators
                                .Where(s => s.Division_Id == Division_Id)
                                .ToList();

            return records;
        }

        public IEnumerable<Trans_StrucDirDivIndicators> GetAllRecordsByDirectorateAndDivision(int Directorate_Id, int Division_Id)
        {
            var records = context.Trans_StrucDirDivIndicators
                                .Where(s => s.Directorate_Id==Directorate_Id && s.Division_Id == Division_Id)
                                .ToList();

            return records;
        }

        public Trans_StrucDirDivIndicators GetRecord(string Id)
		{
		    return context.Trans_StrucDirDivIndicators.Find(Id);
		}

		public Trans_StrucDirDivIndicators Update(Trans_StrucDirDivIndicators recChanges)
		{
		    var satype = context.Trans_StrucDirDivIndicators.Attach(recChanges);
		    satype.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
		    context.SaveChanges();
		    return recChanges;
		}
        
    }
}