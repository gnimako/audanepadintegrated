using System;
using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace AUDANEPAD_Integrated.Services
{
    public class ServiceTrans_Programme: ITrans_ProgrammeRepository
    {
        private readonly AppDbContext context;
		private readonly ILogger<ServiceTrans_Programme> logger;
        
		public ServiceTrans_Programme(AppDbContext context, ILogger<ServiceTrans_Programme> logger)
		{
		    this.context = context;
		    this.logger = logger;
		}
		public Trans_Programme Add(Trans_Programme rec)
		{
		    rec.Transaction_Id = Guid.NewGuid().ToString();
		    context.Trans_Programme.Add(rec);
		    context.SaveChanges();
		    return rec;
		}

		public Trans_Programme Delete(string id)
		{
        
		    Trans_Programme rec = context.Trans_Programme.Find(id);

		    if (rec != null)
		    {
		        context.Trans_Programme.Remove(rec);
		        context.SaveChanges();
		    }
		    return rec;
		}

		public IEnumerable<Trans_Programme> GetAllRecords()
		{
		    return context.Trans_Programme;
		}

        public IEnumerable<Trans_Programme> GetAllRecordsByDirectorateID(int Id)
        {
            var records = context.Trans_Programme
                                .Where(s => s.Directorate_Id == Id)
                                .ToList();

            return records;
        }

        public IEnumerable<Trans_Programme> GetAllRecordsByDivisionID(int Id)
        {
            var records = context.Trans_Programme
                                .Where(s => s.Division_Id == Id)
                                .ToList();

            return records;
        }

        public Trans_Programme GetRecord(string Id)
		{
		    return context.Trans_Programme.Find(Id);
		}

        public Trans_Programme GetRecordByMainProgrammeID(int Id)
        {
                        var rec = context.Trans_Programme
                                .Where(s => s.MainProgramme_Id == Id)
                                .FirstOrDefault();

                        return rec;
        }

        public Trans_Programme Update(Trans_Programme recChanges)
		{
		    var satype = context.Trans_Programme.Attach(recChanges);
		    satype.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
		    context.SaveChanges();
		    return recChanges;
		}
        
    }
}