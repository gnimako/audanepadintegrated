using System;
using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using NodaTime;


namespace AUDANEPAD_Integrated.Services
{
    public class ServiceWP_Communication: IWP_CommunicationRepository
    {
        private readonly AppDbContext context;
		private readonly ILogger<ServiceWP_Communication> logger;
		public ServiceWP_Communication(AppDbContext context, ILogger<ServiceWP_Communication> logger)
		{
		    this.context = context;
		    this.logger = logger;
		}
		public WP_Communication Add(WP_Communication rec)
		{
		    rec.Transaction_Id = Guid.NewGuid().ToString();
		    context.WP_Communication.Add(rec);
		    context.SaveChanges();
		    return rec;
		}

		public WP_Communication Delete(string id)
		{
		    WP_Communication rec = context.WP_Communication.Find(id);
		    if (rec != null)
		    {
		        context.WP_Communication.Remove(rec);
		        context.SaveChanges();
		    }
		    return rec;
		}

		public IEnumerable<WP_Communication> GetAllRecords()
		{
		    return context.WP_Communication;
		}
        public IEnumerable<WP_Communication> GetRecordsByMainRecordId (string recid)
        {
            var records = context.WP_Communication
                                .Where(s => s.WPMainRecord_id==recid)
                                .ToList();

            return records;
        }
		public IEnumerable<WP_Communication> GetRecordsByMainRecordOutputId (string wpmainrecid, string outputid)
        {
            var records = context.WP_Communication
                                .Where(s => s.WPMainRecord_id==wpmainrecid && s.WPOutput_Id==outputid)
                                .ToList();

            return records;
        }
		public IEnumerable<WP_Communication> GetRecordsByOutputId (string outputid)
        {
            var records = context.WP_Communication
                                .Where(s => s.WPOutput_Id==outputid)
                                .ToList();

            return records;
        }

		public IEnumerable<WP_Communication> GetRecordsByOutputIdStartEndRange (string outputid, LocalDate StartDate, LocalDate EndDate)
		{
			var records = context.WP_Communication
								.Where(s => s.WPOutput_Id==outputid && s.WPCommsStartDate>=StartDate && s.WPCommsStartDate<=EndDate)
								.ToList();

			return records;
		}

		public WP_Communication GetRecord(string Id)
		{
		    return context.WP_Communication.Find(Id);
		}

		public WP_Communication Update(WP_Communication recChanges)
		{
		    var satype = context.WP_Communication.Attach(recChanges);
		    satype.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
		    context.SaveChanges();
		    return recChanges;
		}

        
    }
}