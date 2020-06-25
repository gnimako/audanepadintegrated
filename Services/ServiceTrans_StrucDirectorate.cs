using System;
using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace AUDANEPAD_Integrated.Services
{
    public class ServiceTrans_StrucDirectorate: ITrans_StrucDirectorateRepository
    {
        private readonly AppDbContext context;
		private readonly ILogger<ServiceTrans_StrucDirectorate> logger;

        private readonly ITrans_StrucDivisionRepository _transStrucDivisionRepository  ;
		public ServiceTrans_StrucDirectorate(AppDbContext context, ILogger<ServiceTrans_StrucDirectorate> logger,
                                                ITrans_StrucDivisionRepository transStrucDivisionRepository)
		{
		    this.context = context;
		    this.logger = logger;
            _transStrucDivisionRepository=transStrucDivisionRepository;
		}
		public Trans_StrucDirectorate Add(Trans_StrucDirectorate rec)
		{
		    rec.Transaction_Id = Guid.NewGuid().ToString();
		    context.Trans_StrucDirectorate.Add(rec);
		    context.SaveChanges();
		    return rec;
		}

		public Trans_StrucDirectorate Delete(string id)
		{
            var dependent_recs=_transStrucDivisionRepository.GetAllRecordsByDirectorate(id).ToList();
            foreach (var record in dependent_recs)
            {
                if (record != null)
                {
                    context.Trans_StrucDivision.Remove(record);
                    context.SaveChanges();
                }
            }
		    Trans_StrucDirectorate rec = context.Trans_StrucDirectorate.Find(id);
		    if (rec != null)
		    {
		        context.Trans_StrucDirectorate.Remove(rec);
		        context.SaveChanges();
		    }
		    return rec;
		}

		public IEnumerable<Trans_StrucDirectorate> GetAllRecords()
		{
		    return context.Trans_StrucDirectorate;
		}

		public Trans_StrucDirectorate GetRecord(string Id)
		{
		    return context.Trans_StrucDirectorate.Find(Id);
		}

        public Trans_StrucDirectorate GetRecordByMasterStrucDirectorateId (int Id)
        {
                        var rec = context.Trans_StrucDirectorate
                                  .Where(s => s.Record_Id == Id)
                                  .FirstOrDefault();
                        return rec;
        }

        public Trans_StrucDirectorate Update(Trans_StrucDirectorate recChanges)
		{
		    var satype = context.Trans_StrucDirectorate.Attach(recChanges);
		    satype.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
		    context.SaveChanges();
		    return recChanges;
		}
        
    }
}