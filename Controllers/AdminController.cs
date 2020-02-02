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
        private readonly ILkUp_ActivityTypeRepository _lkupActivityTypeRepository;
        private readonly ILkUp_DSATypeRepository _lkupDSATypeRepository;
        private readonly ILkUp_CostCatelogueRepository _lkupCostCatelogueRepository ;
        private readonly ILkUp_CommsChannelRepository _lkupCommsChannelRepository ;
        private readonly ILkUp_CountryRepository _lkupCountryRepository ;
        private readonly ILkUp_ExtParticipantTypeRepository _lkupExtParticipantTypeRepository ;
        private readonly ILkUp_FiscalYearRepository _lkupFiscalYearRepository ;
        private readonly ILkUp_ImplementationTypeRepository _lkupImplementationTypeRepository  ;
        private readonly ILkUp_LeadershipStatusRepository _lkupLeadershipStatusRepository ;
        private readonly ILkUp_ParticipantTypeRepository _lkupParticipantTypeRepository ;


        private readonly ITrans_ActivityTypeRepository _transActivityTypeRepository;
        private readonly ITrans_DSATypeRepository _transDSATypeRepository;
        private readonly ITrans_CostCatelogueRepository _transCostCatelogueRepository;
        private readonly ITrans_CommsChannelRepository _transCommsChannelRepository;
        private readonly ITrans_CountryRepository _transCountryRepository;
        private readonly ITrans_ExtParticipantTypeRepository _transExtParticipantTypeRepository ;
        private readonly ITrans_FiscalYearRepository _transFiscalYearRepository ;
        private readonly ITrans_ImplementationTypeRepository _transImplementationTypeRepository  ;
        private readonly ITrans_LeadershipStatusRepository _transLeadershipStatusRepository ;
        private readonly ITrans_ParticipantTypeRepository _transParticipantTypeRepository ;



        private readonly AppDbContext _context;

        private readonly IWebHostEnvironment hostingEnvironment;

         public AdminController(IEmployeeRepository employeeRepository,
                                UserManager<ApplicationUser> userManager,
                                RoleManager<IdentityRole> roleManager,
                                SignInManager<ApplicationUser> signInManager,
                                AppDbContext context,
                                IWebHostEnvironment hostingEnvironment,
                                ILkUp_ActivityTypeRepository lkupActivityTypeRepository,
                                ILkUp_DSATypeRepository lkupDSATypeRepository,
                                ILkUp_CostCatelogueRepository lkupCostCatelogueRepository,
                                ILkUp_CommsChannelRepository lkupCommsChannelRepository,
                                ILkUp_CountryRepository lkupCountryRepository,
                                ILkUp_ExtParticipantTypeRepository lkupExtParticipantTypeRepository,
                                ILkUp_FiscalYearRepository lkupFiscalYearRepository,
                                ILkUp_ImplementationTypeRepository lkupImplementationTypeRepository,
                                ILkUp_LeadershipStatusRepository lkupLeadershipStatusRepository,
                                ILkUp_ParticipantTypeRepository lkupParticipantTypeRepository,

                                ITrans_ActivityTypeRepository transActivityTypeRepository,
                                ITrans_DSATypeRepository transDSATypeRepository,
                                ITrans_CostCatelogueRepository transCostCatelogueRepository,
                                ITrans_CommsChannelRepository transCommsChannelRepository,
                                ITrans_CountryRepository transCountryRepository,
                                ITrans_ExtParticipantTypeRepository transExtParticipantTypeRepository,
                                ITrans_FiscalYearRepository transFiscalYearRepository,
                                ITrans_ImplementationTypeRepository transImplementationTypeRepository,
                                ITrans_LeadershipStatusRepository transLeadershipStatusRepository,
                                ITrans_ParticipantTypeRepository transParticipantTypeRepository)
        {
            this._employeeRepository = employeeRepository;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.signInManager = signInManager;
            this.hostingEnvironment = hostingEnvironment;

            _lkupActivityTypeRepository=lkupActivityTypeRepository;
            _lkupDSATypeRepository=lkupDSATypeRepository;
            _lkupCostCatelogueRepository=lkupCostCatelogueRepository;
            _lkupCommsChannelRepository=lkupCommsChannelRepository;
            _lkupCountryRepository=lkupCountryRepository;
            _lkupExtParticipantTypeRepository=lkupExtParticipantTypeRepository;
            _lkupFiscalYearRepository=lkupFiscalYearRepository;
            _lkupImplementationTypeRepository=lkupImplementationTypeRepository;
            _lkupLeadershipStatusRepository=lkupLeadershipStatusRepository;
            _lkupParticipantTypeRepository=lkupParticipantTypeRepository;


            _transActivityTypeRepository=transActivityTypeRepository;
            _transDSATypeRepository=transDSATypeRepository;
            _transCostCatelogueRepository=transCostCatelogueRepository;
            _transCommsChannelRepository=transCommsChannelRepository;
            _transCountryRepository=transCountryRepository;
            _transExtParticipantTypeRepository=transExtParticipantTypeRepository;
            _transFiscalYearRepository=transFiscalYearRepository;
            _transImplementationTypeRepository=transImplementationTypeRepository;
            _transLeadershipStatusRepository=transLeadershipStatusRepository;
            _transParticipantTypeRepository=transParticipantTypeRepository;
            



            _context = context;
            
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

        //**************LOAD LOOK-UPS TABLES******************///

        [HttpPost]
        public ActionResult LoadAllLookUps()
        {
            Chilkat.Csv csv_activitytype = new Chilkat.Csv();
            Chilkat.Csv csv_dsatype = new Chilkat.Csv();
            Chilkat.Csv csv_costcatelogue = new Chilkat.Csv();
            Chilkat.Csv csv_commschannel = new Chilkat.Csv();
            Chilkat.Csv csv_country = new Chilkat.Csv();
            Chilkat.Csv csv_extparticipanttype= new Chilkat.Csv();
            Chilkat.Csv csv_fiscalyear = new Chilkat.Csv();
            Chilkat.Csv csv_implementationtype = new Chilkat.Csv();
            Chilkat.Csv csv_leadershipstatus = new Chilkat.Csv();
            Chilkat.Csv csv_participanttype = new Chilkat.Csv();



            string activitytype_path = Path.Combine(hostingEnvironment.WebRootPath, "appdirectory/lookupcsvs/ActivityType.csv");
            string dsatype_path = Path.Combine(hostingEnvironment.WebRootPath, "appdirectory/lookupcsvs/DSAType.csv");
            string costcatelogue_path = Path.Combine(hostingEnvironment.WebRootPath, "appdirectory/lookupcsvs/CostCatelogue.csv");
            string commschannel_path = Path.Combine(hostingEnvironment.WebRootPath, "appdirectory/lookupcsvs/CommunicationChannels.csv");
            string country_path = Path.Combine(hostingEnvironment.WebRootPath, "appdirectory/lookupcsvs/Countries.csv");
            string extparticipanttype_path = Path.Combine(hostingEnvironment.WebRootPath, "appdirectory/lookupcsvs/ExternalPersonsType.csv");
            string fiscalyear_path = Path.Combine(hostingEnvironment.WebRootPath, "appdirectory/lookupcsvs/FiscalYears.csv");
            string implementationtype_path = Path.Combine(hostingEnvironment.WebRootPath, "appdirectory/lookupcsvs/ImplementationTypes.csv");
            string leadershipstatus_path = Path.Combine(hostingEnvironment.WebRootPath, "appdirectory/lookupcsvs/LeadershipStatus.csv");
            string participanttype_path = Path.Combine(hostingEnvironment.WebRootPath, "appdirectory/lookupcsvs/ParticipantType.csv");
            


            try
            {
                bool success_activitytype = csv_activitytype.LoadFile(activitytype_path);
                bool success_dsatype = csv_dsatype.LoadFile(dsatype_path);
                bool success_costcatelogue = csv_costcatelogue.LoadFile(costcatelogue_path);
                bool success_commschannel = csv_commschannel.LoadFile(commschannel_path);
                bool success_country = csv_country.LoadFile(country_path);
                bool success_extparticipanttype = csv_extparticipanttype.LoadFile(extparticipanttype_path);
                bool success_fiscalyear = csv_fiscalyear.LoadFile(fiscalyear_path);
                bool success_implementationtype = csv_implementationtype.LoadFile(implementationtype_path);
                bool success_leadershipstatus= csv_leadershipstatus.LoadFile(leadershipstatus_path);
                bool success_participanttype = csv_participanttype.LoadFile(participanttype_path);

                if (success_activitytype == true)
                {

                    // IEnumerable <EmployeeCountry> countries= _empcountryRepository.GetAllEmployeeCountry();
                    int count_activitytypes = _lkupActivityTypeRepository.GetAllActivityType().Count();
                    if (count_activitytypes <= 0)
                    {
                        int row;
                        int n = csv_activitytype.NumRows;


                        for (row = 0; row <= n - 1; row++)
                        {

                            LkUp_ActivityType rec = new LkUp_ActivityType
                            {

                                Activity_Id = Int32.Parse(csv_activitytype.GetCell(row, 0)),
                                Activity_Name = csv_activitytype.GetCell(row, 1),
                                ActivityType_Status = true,
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _lkupActivityTypeRepository.Add(rec);

                            Trans_ActivityType rec_trans = new Trans_ActivityType
                            {
                                Transaction_Id = Guid.NewGuid().ToString(),
                                Activity_Id = Int32.Parse(csv_activitytype.GetCell(row, 0)),
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _transActivityTypeRepository.Add(rec_trans);

                        }
                    }
                }

                if (success_dsatype == true)
                {

                    // IEnumerable <EmployeeCountry> countries= _empcountryRepository.GetAllEmployeeCountry();
                    int count_dsatypes = _lkupDSATypeRepository.GetAllDSAType().Count();
                    if (count_dsatypes <= 0)
                    {
                        int row;
                        int n = csv_dsatype.NumRows;


                        for (row = 0; row <= n - 1; row++)
                        {

                            LkUp_DSAType sDSAType = new LkUp_DSAType
                            {

                                DSA_Id = Int32.Parse(csv_dsatype.GetCell(row, 0)),
                                DSA_Name = csv_dsatype.GetCell(row, 1),
                                DSA_Value = float.Parse(csv_dsatype.GetCell(row, 2)),
                                DSAType_Status = true,
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _lkupDSATypeRepository.Add(sDSAType);

                            Trans_DSAType rec_trans = new Trans_DSAType
                            {
                                Transaction_Id = Guid.NewGuid().ToString(),
                                DSA_Id = Int32.Parse(csv_dsatype.GetCell(row, 0)),
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _transDSATypeRepository.Add(rec_trans);
                        }
                    }
                } 
                if (success_costcatelogue == true)
                {

                    // IEnumerable <EmployeeCountry> countries= _empcountryRepository.GetAllEmployeeCountry();
                    int count_costcatelogue = _lkupCostCatelogueRepository.GetAllCostCatelogue().Count();
                    if (count_costcatelogue <= 0)
                    {
                        int row;
                        int n = csv_costcatelogue.NumRows;


                        for (row = 0; row <= n - 1; row++)
                        {

                            LkUp_CostCatelogue rec = new LkUp_CostCatelogue
                            {

                                Cost_Id = Int32.Parse(csv_costcatelogue.GetCell(row, 0)),
                                Cost_Code = csv_costcatelogue.GetCell(row, 1),
                                Cost_Category = csv_costcatelogue.GetCell(row, 2),
                                Cost_Description = csv_costcatelogue.GetCell(row, 3),
                                Unit_Of_Measure = csv_costcatelogue.GetCell(row, 4),
                                Unit_Cost = float.Parse(csv_costcatelogue.GetCell(row, 5)),
                                Cost_Status = true,
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _lkupCostCatelogueRepository.Add(rec);

                            Trans_CostCatelogue rec_trans = new Trans_CostCatelogue
                            {
                                Transaction_Id = Guid.NewGuid().ToString(),
                                Cost_Id = Int32.Parse(csv_costcatelogue.GetCell(row, 0)),
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _transCostCatelogueRepository.Add(rec_trans);
                        }
                    }
                }

                if (success_commschannel == true)
                {

                    // IEnumerable <EmployeeCountry> countries= _empcountryRepository.GetAllEmployeeCountry();
                    int count_commschannel = _lkupCommsChannelRepository.GetAllCommsChannel().Count();
                    if (count_commschannel <= 0)
                    {
                        int row;
                        int n = csv_commschannel.NumRows;


                        for (row = 0; row <= n - 1; row++)
                        {

                            LkUp_CommsChannel rec = new LkUp_CommsChannel
                            {

                                CommsChannel_Id = Int32.Parse(csv_commschannel.GetCell(row, 0)),
                                CommsChannel_Name = csv_commschannel.GetCell(row, 1),
                                CommsChannel_Status = true,
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _lkupCommsChannelRepository.Add(rec);

                            Trans_CommsChannel rec_trans = new Trans_CommsChannel
                            {
                                Transaction_Id = Guid.NewGuid().ToString(),
                                CommsChannel_Id = Int32.Parse(csv_commschannel.GetCell(row, 0)),
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _transCommsChannelRepository.Add(rec_trans);

                        }
                    }
                }

                if (success_country== true)
                {
                    int count_country = _lkupCountryRepository.GetAllCountry().Count();
                    if (count_country <= 0)
                    {
                        int row;
                        int n = csv_country.NumRows;


                        for (row = 0; row <= n - 1; row++)
                        {

                            LkUp_Country rec = new LkUp_Country
                            {

                                Country_Id = Int32.Parse(csv_country.GetCell(row, 0)),
                                Country_Name = csv_country.GetCell(row, 1),
                                Country_Status = true,
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _lkupCountryRepository.Add(rec);

                            Trans_Country rec_trans = new Trans_Country
                            {
                                Transaction_Id = Guid.NewGuid().ToString(),
                                Country_Id = Int32.Parse(csv_country.GetCell(row, 0)),
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _transCountryRepository.Add(rec_trans);

                        }
                    }
                }

                if (success_extparticipanttype == true)
                {
                    int _count= _lkupExtParticipantTypeRepository.GetAllRecords().Count();
                    if (_count <= 0)
                    {
                        int row;
                        int n = csv_extparticipanttype.NumRows;


                        for (row = 0; row <= n - 1; row++)
                        {

                            LkUp_ExtParticipantType rec = new LkUp_ExtParticipantType
                            {

                                Record_Id = Int32.Parse(csv_extparticipanttype.GetCell(row, 0)),
                                Record_Name = csv_extparticipanttype.GetCell(row, 1),
                                Record_Status = true,
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _lkupExtParticipantTypeRepository.Add(rec);

                            Trans_ExtParticipantType rec_trans = new Trans_ExtParticipantType
                            {
                                Transaction_Id = Guid.NewGuid().ToString(),
                                Record_Id = Int32.Parse(csv_extparticipanttype.GetCell(row, 0)),
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _transExtParticipantTypeRepository.Add(rec_trans);

                        }
                    }
                }

                if (success_fiscalyear == true)
                {
                    int _count= _lkupFiscalYearRepository.GetAllRecords().Count();
                    if (_count <= 0)
                    {
                        int row;
                        int n = csv_fiscalyear.NumRows;


                        for (row = 0; row <= n - 1; row++)
                        {

                            LkUp_FiscalYear rec = new LkUp_FiscalYear
                            {

                                Record_Id = Int32.Parse(csv_fiscalyear.GetCell(row, 0)),
                                Record_Name = csv_fiscalyear.GetCell(row, 1),
                                Record_Status = true,
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _lkupFiscalYearRepository.Add(rec);

                            Trans_FiscalYear rec_trans = new Trans_FiscalYear
                            {
                                Transaction_Id = Guid.NewGuid().ToString(),
                                Record_Id = Int32.Parse(csv_fiscalyear.GetCell(row, 0)),
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _transFiscalYearRepository.Add(rec_trans);

                        }
                    }
                }

                if (success_implementationtype == true)
                {
                    int _count= _lkupImplementationTypeRepository.GetAllRecords().Count();
                    if (_count <= 0)
                    {
                        int row;
                        int n = csv_implementationtype.NumRows;


                        for (row = 0; row <= n - 1; row++)
                        {

                            LkUp_ImplementationType rec = new LkUp_ImplementationType
                            {

                                Record_Id = Int32.Parse(csv_implementationtype.GetCell(row, 0)),
                                Record_Name = csv_implementationtype.GetCell(row, 1),
                                Record_Status = true,
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _lkupImplementationTypeRepository.Add(rec);

                            Trans_ImplementationType rec_trans = new Trans_ImplementationType
                            {
                                Transaction_Id = Guid.NewGuid().ToString(),
                                Record_Id = Int32.Parse(csv_implementationtype.GetCell(row, 0)),
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _transImplementationTypeRepository.Add(rec_trans);

                        }
                    }
                }


                if (success_leadershipstatus == true)
                {
                    int _count= _lkupLeadershipStatusRepository.GetAllRecords().Count();
                    if (_count <= 0)
                    {
                        int row;
                        int n = csv_leadershipstatus.NumRows;


                        for (row = 0; row <= n - 1; row++)
                        {

                            LkUp_LeadershipStatus rec = new LkUp_LeadershipStatus
                            {

                                Record_Id = Int32.Parse(csv_leadershipstatus.GetCell(row, 0)),
                                Record_Name = csv_leadershipstatus.GetCell(row, 1),
                                Record_Status = true,
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _lkupLeadershipStatusRepository.Add(rec);

                            Trans_LeadershipStatus rec_trans = new Trans_LeadershipStatus
                            {
                                Transaction_Id = Guid.NewGuid().ToString(),
                                Record_Id = Int32.Parse(csv_leadershipstatus.GetCell(row, 0)),
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _transLeadershipStatusRepository.Add(rec_trans);

                        }
                    }
                }

                if (success_participanttype == true)
                {
                    int _count= _lkupParticipantTypeRepository.GetAllRecords().Count();
                    if (_count <= 0)
                    {
                        int row;
                        int n = csv_participanttype.NumRows;


                        for (row = 0; row <= n - 1; row++)
                        {

                            LkUp_ParticipantType rec = new LkUp_ParticipantType
                            {

                                Record_Id = Int32.Parse(csv_participanttype.GetCell(row, 0)),
                                Record_Name = csv_participanttype.GetCell(row, 1),
                                Record_Status = true,
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _lkupParticipantTypeRepository.Add(rec);

                            Trans_ParticipantType rec_trans = new Trans_ParticipantType
                            {
                                Transaction_Id = Guid.NewGuid().ToString(),
                                Record_Id = Int32.Parse(csv_participanttype.GetCell(row, 0)),
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _transParticipantTypeRepository.Add(rec_trans);

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
        //**************GRID CREATE RECORDS******************///
        [AcceptVerbs("Post")]
		public ActionResult LkUp_ActivityType_Create([DataSourceRequest] DataSourceRequest request, LookUpTablesViewModel record)
        {
            if (record != null && ModelState.IsValid)
            {  
                LkUp_ActivityType rec = _lkupActivityTypeRepository.GetActivityTypeByName(record.LookUp_Name);

                if (rec == null && record.LookUp_Name !=null)
                {

                        var DB_Recs = _lkupActivityTypeRepository.GetAllActivityType();
                        int _count = DB_Recs.Count();

                        LkUp_ActivityType rec_to_add = new LkUp_ActivityType
                        {
                            Activity_Id=_count+1,
                            Activity_Name=record.LookUp_Name,
                            ActivityType_Status=null,
                            TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                        };

                        _lkupActivityTypeRepository.Add(rec_to_add);
                }      
                           
            }
            
            return Json(new [] { record }.ToDataSourceResult(request, ModelState));
        }
        //**************GRID UPDATE RECORDS******************///
        [AcceptVerbs("Post")]
		public ActionResult LkUp_ActivityType_Update([DataSourceRequest] DataSourceRequest request, LookUpTablesViewModel record)
        {
            if (record != null && ModelState.IsValid)
            {  
                LkUp_ActivityType rec = _lkupActivityTypeRepository.GetActivityType(record.LookUp_Id);
                
                if (rec != null)
                {

                        LkUp_ActivityType rec_already_exist = _lkupActivityTypeRepository.GetActivityTypeByName(record.LookUp_Name);

                        if(rec_already_exist==null)
                        {
                            rec.Activity_Name=record.LookUp_Name;
                            rec.TransactionDate=new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);


                            _lkupActivityTypeRepository.Update(rec);
                        }
                }      
                           
            }
            
            return Json(new [] { record }.ToDataSourceResult(request, ModelState));
        }
        //**************GRID DELETE RECORDS******************///
        [AcceptVerbs("Post")]
		public ActionResult LkUp_ActivityType_Delete([DataSourceRequest] DataSourceRequest request, LookUpTablesViewModel record)
        {
            if (record != null && ModelState.IsValid)
            {  
                LkUp_ActivityType rec = _lkupActivityTypeRepository.GetActivityType(record.LookUp_Id);
                
                if (rec != null)
                {


                        if(rec.ActivityType_Status==null)
                        {
                            _lkupActivityTypeRepository.Delete(rec.Activity_Id);
                        }
                }      
                           
            }
            
            return Json(new [] { record }.ToDataSourceResult(request, ModelState));
        }


        [AcceptVerbs("Post")]
		public ActionResult Trans_ActivityType_Delete([DataSourceRequest] DataSourceRequest request, LookUpTablesViewModel record)
        {
            if (record != null && ModelState.IsValid)
            {  
                Trans_ActivityType rec = _transActivityTypeRepository.GetTrans_ActivityType(record.Trans_LookUp_Id);
                
                if (rec != null)
                {
                    _transActivityTypeRepository.Delete(rec.Transaction_Id);

                    LkUp_ActivityType rec_update=_lkupActivityTypeRepository.GetActivityType(rec.Activity_Id);
                    rec_update.ActivityType_Status=false;
                    _lkupActivityTypeRepository.Update(rec_update);
                }      
                           
            }
            
            return Json(new [] { record }.ToDataSourceResult(request, ModelState));
        }
        //**************GRID DATA READS******************///

        public ActionResult LkUp_ActivityType_Read([DataSourceRequest]DataSourceRequest request, string text)
        {


            List<LookUpTablesViewModel> collection_recs = new List<LookUpTablesViewModel>();



            var DB_Recs =  _lkupActivityTypeRepository.GetAllActivityType();




            int _count =  DB_Recs.Count();


            if (_count > 0)
            {
                foreach (var rec in DB_Recs)
                {
   
                    LookUpTablesViewModel srec = new LookUpTablesViewModel
                    {
                        LookUp_Id = rec.Activity_Id,
                        LookUp_Name =rec.Activity_Name,
                        Show_trans_button=rec.ActivityType_Status.HasValue? rec.ActivityType_Status.Value? false: true: true,
                        LookUp_Status = rec.ActivityType_Status.HasValue? rec.ActivityType_Status.Value? "Transactional": "Active": "Inactive",
                        TransactionDate = new DateTime(rec.TransactionDate.Year, rec.TransactionDate.Month, rec.TransactionDate.Day)
                    };

                    collection_recs.Add(srec);
                }
            }



            return Json(collection_recs.ToDataSourceResult(request));
        }

        public ActionResult Trans_ActivityType_Read([DataSourceRequest]DataSourceRequest request, string text)
        {


            List<LookUpTablesViewModel> collection_recs = new List<LookUpTablesViewModel>();

            var DB_Recs =  _transActivityTypeRepository.GetAllTransActivityType().ToList();

            int _count = DB_Recs.Count();


            if (_count > 0)
            {
                foreach (var rec in DB_Recs)
                {

                    LookUpTablesViewModel srec = new LookUpTablesViewModel
                    {
                        LookUp_Id = rec.Activity_Id,
                        Trans_LookUp_Id=rec.Transaction_Id,
                        LookUp_Name =_lkupActivityTypeRepository.GetActivityType(rec.Activity_Id).Activity_Name,
                        TransactionDate = new DateTime(rec.TransactionDate.Year, rec.TransactionDate.Month, rec.TransactionDate.Day)
                    };

                    collection_recs.Add(srec);
                }
            }



            return Json(collection_recs.ToDataSourceResult(request));
        }

        //**************GRID COMMAND ACTIONS******************///
        [HttpPost]
        public ActionResult MakeActivityTypeTrans(string recid)
        {
            try
            {
                LkUp_ActivityType rec = _lkupActivityTypeRepository.GetActivityType(Int32.Parse(recid));
                rec.ActivityType_Status=true;
                _lkupActivityTypeRepository.Update(rec);

                Trans_ActivityType rec_trans = new Trans_ActivityType
                {
                    Transaction_Id = Guid.NewGuid().ToString(),
                    Activity_Id = rec.Activity_Id,
                    TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                };
                _transActivityTypeRepository.Add(rec_trans);

                 return Json(new { rtnmsg = "success" });
            }
            catch (Exception)
            {
                return Json(new { rtnmsg = "error" });
            }
        }

    }
}