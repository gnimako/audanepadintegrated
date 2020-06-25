using System;
using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace AUDANEPAD_Integrated.Services
{
    public class ServiceTrans_Country : ITrans_CountryRepository
    {
        private readonly AppDbContext context;
        private readonly ILogger<ServiceTrans_Country> logger;
        public ServiceTrans_Country(AppDbContext context, ILogger<ServiceTrans_Country> logger)
        {
            this.context = context;
            this.logger = logger;
        }
        public Trans_Country Add(Trans_Country rec)
        {
            rec.Transaction_Id = Guid.NewGuid().ToString();
            context.Trans_Country.Add(rec);
            context.SaveChanges();
            return rec;
        }

        public Trans_Country Delete(string id)
        {
            Trans_Country rec = context.Trans_Country.Find(id);
            if (rec != null)
            {
                context.Trans_Country.Remove(rec);
                context.SaveChanges();
            }
            return rec;
        }

        public IEnumerable<Trans_Country> GetAllTrans_Country()
        {
            return context.Trans_Country;
        }

        public Trans_Country GetTrans_Country(string Id)
        {
            return context.Trans_Country.Find(Id);
        }

        public Trans_Country Update(Trans_Country recChanges)
        {
            var satype = context.Trans_Country.Attach(recChanges);
            satype.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return recChanges;
        }
    }
}