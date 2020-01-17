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


namespace AUDANEPAD_Integrated.Controllers
{

    public class AdminController: Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly ILkUp_ActivityTypeRepository _activityTypeRepository;
        private readonly AppDbContext context;

        private readonly IWebHostEnvironment hostingEnvironment;

         public AdminController(IEmployeeRepository employeeRepository,
                                        UserManager<ApplicationUser> userManager,
                               RoleManager<IdentityRole> roleManager,
                               SignInManager<ApplicationUser> signInManager,
                               AppDbContext context,
                               IWebHostEnvironment hostingEnvironment,
                               ILkUp_ActivityTypeRepository activityTypeRepository)
        {
            this._employeeRepository = employeeRepository;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.signInManager = signInManager;
            this.hostingEnvironment = hostingEnvironment;

            _activityTypeRepository=activityTypeRepository;

            this.context = context;
            
        }

        // GET: /<controller>/

        public async Task<ActionResult> Index()
        {
            var user = await userManager.GetUserAsync(HttpContext.User);

            string profilepicpath = "";



            Employee employee = _employeeRepository.GetEmployeeByLoginIdentAndStaffNumber(user.Id, user.Staff_Number);

            if (employee.PhotoPath == null)
            {
                if (employee.Gender == 1)
                    profilepicpath = "/appdirectory/profilepics/male_null_profile.jpg";
                else
                    profilepicpath = "/appdirectory/profilepics/female_null_profile.jpg";
            }
            else
            {
                profilepicpath = "/appdirectory/" + employee.Staff_Number + "/" + employee.PhotoPath;

            }

            EmployeeViewModel emp_view = new EmployeeViewModel
            {
                Id = employee.Id,
                IdentityUserId = employee.IdentityUserId,
                Staff_Number = employee.Staff_Number,
                Address_Street = employee.Address_Street,
                Address_City = employee.Address_City,
                Address_PostCode = employee.Address_PostCode,
                Address_State = employee.Address_State,
                RankStep = employee.RankStep,
                Country = employee.Country,
                Directorate_Id = employee.Directorate_Id,
                Department_Id = employee.Department_Id,
                //DOB=employee.DOB,
                DOB = new DateTime(employee.DOB.Year, employee.DOB.Month, employee.DOB.Day),
                Email = employee.Email,
                First_Name = employee.First_Name,
                Last_Name = employee.Last_Name,
                Gender = employee.Gender,
                PhotoPath = profilepicpath,
                Rank = employee.Rank
            };

            
            return View(emp_view);
        }

        public async Task<ActionResult> LoadLookUps()
        {

            var user = await userManager.GetUserAsync(HttpContext.User);

            string profilepicpath = "";



            Employee employee = _employeeRepository.GetEmployeeByLoginIdentAndStaffNumber(user.Id, user.Staff_Number);
            if (employee.PhotoPath == null)
            {
                if (employee.Gender == 1)
                    profilepicpath = "/appdirectory/profilepics/male_null_profile.jpg";
                else
                    profilepicpath = "/appdirectory/profilepics/female_null_profile.jpg";
            }
            else
            {
                profilepicpath = "/appdirectory/" + employee.Staff_Number + "/" + employee.PhotoPath;

            }

            // DateTime test = new DateTime(employee.DOB.Year, employee.DOB.Month, employee.DOB.Day);

            EmployeeViewModel emp_view = new EmployeeViewModel
            {
                Id = employee.Id,
                IdentityUserId = employee.IdentityUserId,
                Staff_Number = employee.Staff_Number,
                Address_Street = employee.Address_Street,
                Address_City = employee.Address_City,
                Address_PostCode = employee.Address_PostCode,
                Address_State = employee.Address_State,
                RankStep = employee.RankStep,
                Country = employee.Country,
                Directorate_Id = employee.Directorate_Id,
                Department_Id = employee.Department_Id,
                // DOB=employee.DOB,
                DOB = new DateTime(employee.DOB.Year, employee.DOB.Month, employee.DOB.Day),
                Email = employee.Email,
                First_Name = employee.First_Name,
                Last_Name = employee.Last_Name,
                Gender = employee.Gender,
                PhotoPath = profilepicpath,
                Rank = employee.Rank,
                ExistingPhotoPath = employee.PhotoPath

            };



            return View(emp_view);

        }


        public async Task<ActionResult> LookUpActivityType()
        {

            var user = await userManager.GetUserAsync(HttpContext.User);

            string profilepicpath = "";



            Employee employee = _employeeRepository.GetEmployeeByLoginIdentAndStaffNumber(user.Id, user.Staff_Number);
            if (employee.PhotoPath == null)
            {
                if (employee.Gender == 1)
                    profilepicpath = "/appdirectory/profilepics/male_null_profile.jpg";
                else
                    profilepicpath = "/appdirectory/profilepics/female_null_profile.jpg";
            }
            else
            {
                profilepicpath = "/appdirectory/" + employee.Staff_Number + "/" + employee.PhotoPath;

            }

            // DateTime test = new DateTime(employee.DOB.Year, employee.DOB.Month, employee.DOB.Day);

            EmployeeViewModel emp_view = new EmployeeViewModel
            {
                Id = employee.Id,
                IdentityUserId = employee.IdentityUserId,
                Staff_Number = employee.Staff_Number,
                Address_Street = employee.Address_Street,
                Address_City = employee.Address_City,
                Address_PostCode = employee.Address_PostCode,
                Address_State = employee.Address_State,
                RankStep = employee.RankStep,
                Country = employee.Country,
                Directorate_Id = employee.Directorate_Id,
                Department_Id = employee.Department_Id,
                // DOB=employee.DOB,
                DOB = new DateTime(employee.DOB.Year, employee.DOB.Month, employee.DOB.Day),
                Email = employee.Email,
                First_Name = employee.First_Name,
                Last_Name = employee.Last_Name,
                Gender = employee.Gender,
                PhotoPath = profilepicpath,
                Rank = employee.Rank,
                ExistingPhotoPath = employee.PhotoPath

            };



            return View(emp_view);

        }
        [HttpPost]
        public ActionResult LoadAllLookUps()
        {
            Chilkat.Csv csv_activitytype = new Chilkat.Csv();


            string activitytype_path = Path.Combine(hostingEnvironment.WebRootPath, "appdirectory/lookupcsvs/ActivityType.csv");


            try
            {
                bool success_activitytype = csv_activitytype.LoadFile(activitytype_path);

                if (success_activitytype == true)
                {

                    // IEnumerable <EmployeeCountry> countries= _empcountryRepository.GetAllEmployeeCountry();
                    int count_activitytypes = _activityTypeRepository.GetAllActivityType().Count();
                    if (count_activitytypes <= 0)
                    {
                        int row;
                        int n = csv_activitytype.NumRows;


                        for (row = 0; row <= n - 1; row++)
                        {

                            LkUp_ActivityType sActivityType = new LkUp_ActivityType
                            {

                                Activity_Id = Int32.Parse(csv_activitytype.GetCell(row, 0)),
                                Activity_Name = csv_activitytype.GetCell(row, 1),
                                ActivityType_Status = true,
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _activityTypeRepository.Add(sActivityType);
                        }
                    }
                } 

                return Json(new { rtnmsg = "success" });
            }
            catch (Exception)
            {
                return Json(new { rtnmsg = "error" });
            }

        }


        //**************GRID DATA READS******************///

        public ActionResult LkUp_ActivityType_Read([DataSourceRequest]DataSourceRequest request, string text)
        {


            List<LookUpTablesViewModel> collection_recs = new List<LookUpTablesViewModel>();



            var DB_Recs = _activityTypeRepository.GetAllActivityType();

            int _count = DB_Recs.Count();
            if (_count > 0)
            {
                foreach (var rec in DB_Recs)
                {
   
                    LookUpTablesViewModel srec = new LookUpTablesViewModel
                    {
                        LookUp_Id = rec.Activity_Id,
                        LookUp_Name =rec.Activity_Name,
                        LookUp_Status = rec.ActivityType_Status == true ? "Active" : "Inactive",
                        TransactionDate = new DateTime(rec.TransactionDate.Year, rec.TransactionDate.Month, rec.TransactionDate.Day)
                    };

                    collection_recs.Add(srec);
                }
            }



            return Json(collection_recs.ToDataSourceResult(request));
        }
        
    }
}