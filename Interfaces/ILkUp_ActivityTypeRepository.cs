using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AUDANEPAD_Integrated.Interfaces;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.ViewModels;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NodaTime;




namespace AUDANEPAD_Integrated.Interfaces
{
    public interface ILkUp_ActivityTypeRepository
    {
        LkUp_ActivityType GetActivityType(int Id);

        LkUp_ActivityType GetActivityTypeByName(string name);
		IEnumerable<LkUp_ActivityType> GetAllActivityType();
        LkUp_ActivityType Add(LkUp_ActivityType atype);
        LkUp_ActivityType Update(LkUp_ActivityType atypeChanges);
        LkUp_ActivityType Delete(int id);
         
    }
}