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
        private readonly ILkUp_ProcurementTypeRepository _lkupProcurementTypeRepository ;
        private readonly ILkUp_RiskCategoryRepository _lkupRiskCategoryRepository ;
        private readonly ILkUp_RiskImpactRepository _lkupRiskImpactRepository ;
        private readonly ILkUp_RiskProbabilityRepository _lkupRiskProbabilityRepository ;
        private readonly ILkUp_RiskRTimeframeRepository _lkupRiskRTimeframeRepository ;
        private readonly ILkUp_PeopleTypeRepository _lkupPeopleTypeRepository ;
        private readonly ILkUp_ProcurementLTimeRepository _lkupProcurementLTimeRepository ;
        private readonly ILkUp_ProjectScopeRepository _lkupProjectScopeRepository ;
        private readonly ILkUp_RegionScopeRepository _lkupRegionScopeRepository ;
        private readonly IStrategy_PriorityRepository _strategyPriorityRepository ;
        private readonly IStrategy_KeyPerformanceAreaRepository _strategyKeyPerformanceAreaRepository;
        private readonly IStruc_DirectorateRepository _strucDirectorateRepository ;
        private readonly IStruc_DivisionRepository _strucDivisionRepository;
        private readonly ILkUp_ProgrammeRepository _lkupProgrammeRepository;
        private readonly ILkUp_ProjectRepository _lkupProjectRepository;


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
        private readonly ITrans_ProcurementTypeRepository _transProcurementTypeRepository ;
        private readonly ITrans_RiskCategoryRepository _transRiskCategoryRepository  ;
        private readonly ITrans_RiskImpactRepository _transRiskImpactRepository;
        private readonly ITrans_RiskProbabilityRepository _transRiskProbabilityRepository ;
        private readonly ITrans_RiskRTimeframeRepository _transRiskRTimeframeRepository ;
        private readonly ITrans_PeopleTypeRepository _transPeopleTypeRepository ;
        private readonly ITrans_ProcurementLTimeRepository _transProcurementLTimeRepository;
        private readonly ITrans_ProjectScopeRepository _transProjectScopeRepository ;
        private readonly ITrans_RegionScopeRepository _transRegionScopeRepository ;
        private readonly ITrans_StrategyPriorityRepository _transStrategyPriorityRepository ;
        private readonly ITrans_StrategyKeyPerformanceAreaRepository _transStrategyKeyPerformanceAreaRepository  ;
        private readonly ITrans_StrucDirectorateRepository _transStrucDirectorateRepository  ;
        private readonly ITrans_StrucDivisionRepository _transStrucDivisionRepository  ;
        private readonly ITrans_ProgrammeRepository _transProgrammeRepository ;
        private readonly ITrans_ProjectRepository _transProjectRepository  ;


        private readonly IStruc_DirStaffMappingRepository _strucDirStaffMappingRepository  ;
        private readonly IStruc_DivStaffMappingRepository _strucDivStaffMappingRepository  ;

        private readonly IStruc_DirectorRepository _strucDirectorRepository   ;
        private readonly IStruc_DirectorOICRepository _strucDirectorOICRepository   ;
        private readonly IStruc_DivHeadRepository _strucDivHeadRepository   ;
        private readonly IStruc_DivHeadOICRepository _strucDivHeadOICRepository  ;
        private readonly IEmailSender _emailSender  ;




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
                                ILkUp_ProcurementTypeRepository lkupProcurementTypeRepository, 
                                ILkUp_RiskCategoryRepository lkupRiskCategoryRepository, 
                                ILkUp_RiskImpactRepository lkupRiskImpactRepository, 
                                ILkUp_RiskProbabilityRepository lkupRiskProbabilityRepository,
                                ILkUp_RiskRTimeframeRepository lkupRiskRTimeframeRepository,
                                ILkUp_PeopleTypeRepository lkupPeopleTypeRepository ,
                                ILkUp_ProcurementLTimeRepository lkupProcurementLTimeRepository ,
                                ILkUp_ProjectScopeRepository lkupProjectScopeRepository,
                                ILkUp_RegionScopeRepository lkupRegionScopeRepository ,
                                IStrategy_PriorityRepository strategyPriorityRepository,
                                IStrategy_KeyPerformanceAreaRepository strategyKeyPerformanceAreaRepository,
                                IStruc_DirectorateRepository strucDirectorateRepository,
                                IStruc_DivisionRepository strucDivisionRepository,
                                ILkUp_ProgrammeRepository lkupProgrammeRepository,
                                ILkUp_ProjectRepository lkupProjectRepository,

                                ITrans_ActivityTypeRepository transActivityTypeRepository,
                                ITrans_DSATypeRepository transDSATypeRepository,
                                ITrans_CostCatelogueRepository transCostCatelogueRepository,
                                ITrans_CommsChannelRepository transCommsChannelRepository,
                                ITrans_CountryRepository transCountryRepository,
                                ITrans_ExtParticipantTypeRepository transExtParticipantTypeRepository,
                                ITrans_FiscalYearRepository transFiscalYearRepository,
                                ITrans_ImplementationTypeRepository transImplementationTypeRepository,
                                ITrans_LeadershipStatusRepository transLeadershipStatusRepository,
                                ITrans_ParticipantTypeRepository transParticipantTypeRepository,
                                ITrans_ProcurementTypeRepository transProcurementTypeRepository,
                                ITrans_RiskCategoryRepository transRiskCategoryRepository,
                                ITrans_RiskImpactRepository transRiskImpactRepository,
                                ITrans_RiskProbabilityRepository transRiskProbabilityRepository,
                                ITrans_RiskRTimeframeRepository transRiskRTimeframeRepository,
                                ITrans_PeopleTypeRepository transPeopleTypeRepository ,
                                ITrans_ProcurementLTimeRepository transProcurementLTimeRepository,
                                ITrans_ProjectScopeRepository transProjectScopeRepository,
                                ITrans_RegionScopeRepository transRegionScopeRepository,
                                ITrans_StrategyPriorityRepository transStrategyPriorityRepository,
                                ITrans_StrategyKeyPerformanceAreaRepository transStrategyKeyPerformanceAreaRepository,
                                ITrans_StrucDirectorateRepository transStrucDirectorateRepository,
                                ITrans_StrucDivisionRepository transStrucDivisionRepository,   
                                ITrans_ProgrammeRepository transProgrammeRepository, 
                                ITrans_ProjectRepository transProjectRepository, 
                                IStruc_DirStaffMappingRepository strucDirStaffMappingRepository,
                                IStruc_DivStaffMappingRepository strucDivStaffMappingRepository,
                                IStruc_DirectorRepository strucDirectorRepository,
                                IStruc_DirectorOICRepository strucDirectorOICRepository,
                                IStruc_DivHeadRepository strucDivHeadRepository,
                                IStruc_DivHeadOICRepository strucDivHeadOICRepository,
                                IEmailSender emailSender)
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
            _lkupProcurementTypeRepository=lkupProcurementTypeRepository; 
            _lkupRiskCategoryRepository=lkupRiskCategoryRepository; 
            _lkupRiskImpactRepository=lkupRiskImpactRepository;
            _lkupRiskProbabilityRepository=lkupRiskProbabilityRepository;
            _lkupRiskRTimeframeRepository=lkupRiskRTimeframeRepository;
            _lkupPeopleTypeRepository =lkupPeopleTypeRepository;
            _lkupProcurementLTimeRepository =lkupProcurementLTimeRepository;
            _lkupProjectScopeRepository = lkupProjectScopeRepository;
            _lkupRegionScopeRepository= lkupRegionScopeRepository;
            _lkupProgrammeRepository=lkupProgrammeRepository;
            _lkupProjectRepository=lkupProjectRepository;
            _strategyPriorityRepository=strategyPriorityRepository;
            _strategyKeyPerformanceAreaRepository=strategyKeyPerformanceAreaRepository;
            _strucDirectorateRepository=strucDirectorateRepository;
            _strucDivisionRepository=strucDivisionRepository;


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
            _transProcurementTypeRepository =transProcurementTypeRepository ;
            _transRiskCategoryRepository =transRiskCategoryRepository  ;
            _transRiskImpactRepository =transRiskImpactRepository;
            _transRiskProbabilityRepository =transRiskProbabilityRepository ;
            _transRiskRTimeframeRepository =transRiskRTimeframeRepository ;
            _transPeopleTypeRepository =transPeopleTypeRepository;
            _transProcurementLTimeRepository=transProcurementLTimeRepository;
            _transProjectScopeRepository =transProjectScopeRepository;
            _transRegionScopeRepository= transRegionScopeRepository;
            _transStrategyPriorityRepository=transStrategyPriorityRepository;
            _transStrategyKeyPerformanceAreaRepository=transStrategyKeyPerformanceAreaRepository;
            _transStrucDirectorateRepository=transStrucDirectorateRepository;
            _transStrucDivisionRepository=transStrucDivisionRepository;
            _transProgrammeRepository=transProgrammeRepository;
            _transProjectRepository=transProjectRepository;
            _strucDirStaffMappingRepository=strucDirStaffMappingRepository;
            _strucDivStaffMappingRepository=strucDivStaffMappingRepository;
            _strucDirectorRepository=strucDirectorRepository;
            _strucDirectorOICRepository=strucDirectorOICRepository;
            _strucDivHeadRepository=strucDivHeadRepository;
            _strucDivHeadOICRepository=strucDivHeadOICRepository;
            _emailSender=emailSender;
      



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
                profilepicpath = "/appdirectory/profilepics/" + employee.Staff_Number + "/" + employee.PhotoPath;

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
                profilepicpath = "/appdirectory/profilepics/" + employee.Staff_Number + "/" + employee.PhotoPath;

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
                profilepicpath = "/appdirectory/profilepics/" + employee.Staff_Number + "/" + employee.PhotoPath;

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

        public async Task<ActionResult> ManageStrucDirectorate()
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
                profilepicpath = "/appdirectory/profilepics/" + employee.Staff_Number + "/" + employee.PhotoPath;

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

        public async Task<ActionResult> StaffDirectorateMapping()
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
                profilepicpath = "/appdirectory/profilepics/" + employee.Staff_Number + "/" + employee.PhotoPath;

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

        public async Task<ActionResult> StaffDirectorsMapping()
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
                profilepicpath = "/appdirectory/profilepics/" + employee.Staff_Number + "/" + employee.PhotoPath;

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

        public async Task<ActionResult> StaffDivisionHeadMapping()
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
                profilepicpath = "/appdirectory/profilepics/" + employee.Staff_Number + "/" + employee.PhotoPath;

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

        public async Task<ActionResult> StaffDivisionMapping()
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
                profilepicpath = "/appdirectory/profilepics/" + employee.Staff_Number + "/" + employee.PhotoPath;

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

        public async Task<ActionResult> ManageStrucDivision()
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
                profilepicpath = "/appdirectory/profilepics/" + employee.Staff_Number + "/" + employee.PhotoPath;

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


            PopulateDirectorateDropDownList();

            return View(emp_view);

        }
        private void PopulateDirectorateDropDownList()
        {
           // var dataContext = new SampleEntities();
            var categories = _transStrucDirectorateRepository.GetAllRecords().ToList()
                        .Select(c => new DropDownListViewModel {
                            DropDown_IntId = c.Record_Id,
                            DropDown_Name = _strucDirectorateRepository.GetRecord(c.Record_Id).Record_Name
                        })
                        .OrderBy(e => e.DropDown_Name);

            ViewData["categories"] = categories;
            ViewData["defaultCategory"] = categories.First();            
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

            Chilkat.Csv csv_procurementtype = new Chilkat.Csv();
            Chilkat.Csv csv_riskcategory = new Chilkat.Csv();
            Chilkat.Csv csv_riskimpact = new Chilkat.Csv();
            Chilkat.Csv csv_riskprobability = new Chilkat.Csv();
            Chilkat.Csv csv_riskreptimeframe = new Chilkat.Csv();

            Chilkat.Csv csv_peopletype= new Chilkat.Csv();
            Chilkat.Csv csv_procurementleadtime = new Chilkat.Csv();
            Chilkat.Csv csv_projectscope = new Chilkat.Csv();
            Chilkat.Csv csv_regionscope= new Chilkat.Csv();
            Chilkat.Csv csv_strategypriority= new Chilkat.Csv();
            Chilkat.Csv csv_strategykeyperformancearea= new Chilkat.Csv();
            Chilkat.Csv csv_strucdirectorate= new Chilkat.Csv();
            Chilkat.Csv csv_strucdivision= new Chilkat.Csv();
            Chilkat.Csv csv_programme= new Chilkat.Csv();
            Chilkat.Csv csv_project =new Chilkat.Csv();



            string activitytype_path = Path.Combine(hostingEnvironment.WebRootPath, "appdirectory/lookupcsvs/ActivityType.csv");
            string dsatype_path = Path.Combine(hostingEnvironment.WebRootPath, "appdirectory/lookupcsvs/DSAType.csv");
            string costcatelogue_path = Path.Combine(hostingEnvironment.WebRootPath, "appdirectory/lookupcsvs/CostCatelogue.csv");
            string commschannel_path = Path.Combine(hostingEnvironment.WebRootPath, "appdirectory/lookupcsvs/CommunicationChannels.csv");
            string country_path = Path.Combine(hostingEnvironment.WebRootPath, "appdirectory/lookupcsvs/Country.csv");
            string extparticipanttype_path = Path.Combine(hostingEnvironment.WebRootPath, "appdirectory/lookupcsvs/ExternalPersonsType.csv");
            string fiscalyear_path = Path.Combine(hostingEnvironment.WebRootPath, "appdirectory/lookupcsvs/FiscalYears.csv");
            string implementationtype_path = Path.Combine(hostingEnvironment.WebRootPath, "appdirectory/lookupcsvs/ImplementationTypes.csv");
            string leadershipstatus_path = Path.Combine(hostingEnvironment.WebRootPath, "appdirectory/lookupcsvs/LeadershipStatus.csv");
            string participanttype_path = Path.Combine(hostingEnvironment.WebRootPath, "appdirectory/lookupcsvs/ParticipantType.csv");
            string procurementtype_path = Path.Combine(hostingEnvironment.WebRootPath, "appdirectory/lookupcsvs/ProcurementTypes.csv");
            string riskcategory_path = Path.Combine(hostingEnvironment.WebRootPath, "appdirectory/lookupcsvs/RiskCategories.csv");
            string riskimpact_path = Path.Combine(hostingEnvironment.WebRootPath, "appdirectory/lookupcsvs/RiskImpact.csv");
            string riskprobability_path = Path.Combine(hostingEnvironment.WebRootPath, "appdirectory/lookupcsvs/RiskProbability.csv");
            string riskreptimeframe_path = Path.Combine(hostingEnvironment.WebRootPath, "appdirectory/lookupcsvs/RiskTimeframes.csv");
            string peopletype_path = Path.Combine(hostingEnvironment.WebRootPath, "appdirectory/lookupcsvs/PeopleTypes.csv");
            string procurementleadtime_path = Path.Combine(hostingEnvironment.WebRootPath, "appdirectory/lookupcsvs/ProcurementLeadTimes.csv");
            string projectscope_path = Path.Combine(hostingEnvironment.WebRootPath, "appdirectory/lookupcsvs/ProjectScope.csv");
            string regionscope_path = Path.Combine(hostingEnvironment.WebRootPath, "appdirectory/lookupcsvs/RegionScope.csv");
            string strategypriority_path = Path.Combine(hostingEnvironment.WebRootPath, "appdirectory/lookupcsvs/StrategicPriorities.csv");
            string strategykeyperformancearea_path = Path.Combine(hostingEnvironment.WebRootPath, "appdirectory/lookupcsvs/StrategicPrioritiesKeyPerformanceAreas.csv");
            string strucdirectorate_path = Path.Combine(hostingEnvironment.WebRootPath, "appdirectory/lookupcsvs/Directorates.csv");
            string strucdivision_path = Path.Combine(hostingEnvironment.WebRootPath, "appdirectory/lookupcsvs/Division.csv");
            string programme_path = Path.Combine(hostingEnvironment.WebRootPath, "appdirectory/lookupcsvs/AUDANEPADProgrammes.csv");
            string project_path = Path.Combine(hostingEnvironment.WebRootPath, "appdirectory/lookupcsvs/AUDANEPADProjects.csv");
            


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
                bool success_procurementtype= csv_procurementtype.LoadFile(procurementtype_path);
                bool success_riskcategory = csv_riskcategory.LoadFile(riskcategory_path);
                bool success_riskimpact = csv_riskimpact.LoadFile(riskimpact_path);
                bool success_riskprobability= csv_riskprobability.LoadFile(riskprobability_path);
                bool success_riskreptimeframe = csv_riskreptimeframe.LoadFile(riskreptimeframe_path);
                bool success_peopletype= csv_peopletype.LoadFile(peopletype_path);
                bool success_procurementleadtime = csv_procurementleadtime.LoadFile(procurementleadtime_path);
                bool success_projectscope = csv_projectscope.LoadFile(projectscope_path);
                bool success_regionscope = csv_regionscope.LoadFile(regionscope_path);
                bool success_strategypriority = csv_strategypriority.LoadFile(strategypriority_path);
                bool success_strategykeyperformancearea = csv_strategykeyperformancearea.LoadFile(strategykeyperformancearea_path);
                bool success_strucdirectorate = csv_strucdirectorate.LoadFile(strucdirectorate_path);
                bool success_strucdivision = csv_strucdivision.LoadFile(strucdivision_path);
                bool success_programme = csv_programme.LoadFile(programme_path);
                bool success_project = csv_project.LoadFile(project_path);


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
                                Country_Capital=csv_country.GetCell(row, 2),
                                AfricanCountry=Int32.Parse(csv_country.GetCell(row, 3)),
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

                if (success_procurementtype == true)
                {
                    int _count= _lkupProcurementTypeRepository.GetAllRecords().Count();
                    if (_count <= 0)
                    {
                        int row;
                        int n = csv_procurementtype.NumRows;


                        for (row = 0; row <= n - 1; row++)
                        {

                            LkUp_ProcurementType rec = new LkUp_ProcurementType
                            {

                                Record_Id = Int32.Parse(csv_procurementtype.GetCell(row, 0)),
                                Record_Name = csv_procurementtype.GetCell(row, 1),
                                Record_Status = true,
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _lkupProcurementTypeRepository.Add(rec);

                            Trans_ProcurementType rec_trans = new Trans_ProcurementType
                            {
                                Transaction_Id = Guid.NewGuid().ToString(),
                                Record_Id = Int32.Parse(csv_procurementtype.GetCell(row, 0)),
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _transProcurementTypeRepository.Add(rec_trans);

                        }
                    }
                }

                if (success_riskcategory == true)
                {
                    int _count= _lkupRiskCategoryRepository.GetAllRecords().Count();
                    if (_count <= 0)
                    {
                        int row;
                        int n = csv_riskcategory.NumRows;


                        for (row = 0; row <= n - 1; row++)
                        {

                            LkUp_RiskCategory rec = new LkUp_RiskCategory
                            {

                                Record_Id = Int32.Parse(csv_riskcategory.GetCell(row, 0)),
                                Record_Name = csv_riskcategory.GetCell(row, 1),
                                Record_Status = true,
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _lkupRiskCategoryRepository.Add(rec);

                            Trans_RiskCategory rec_trans = new Trans_RiskCategory
                            {
                                Transaction_Id = Guid.NewGuid().ToString(),
                                Record_Id = Int32.Parse(csv_riskcategory.GetCell(row, 0)),
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _transRiskCategoryRepository.Add(rec_trans);

                        }
                    }
                }

                if (success_riskimpact == true)
                {
                    int _count= _lkupRiskImpactRepository.GetAllRecords().Count();
                    if (_count <= 0)
                    {
                        int row;
                        int n = csv_riskimpact.NumRows;


                        for (row = 0; row <= n - 1; row++)
                        {

                            LkUp_RiskImpact rec = new LkUp_RiskImpact
                            {

                                Record_Id = Int32.Parse(csv_riskimpact.GetCell(row, 0)),
                                Record_Name = csv_riskimpact.GetCell(row, 1),
                                Record_Status = true,
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _lkupRiskImpactRepository.Add(rec);

                            Trans_RiskImpact rec_trans = new Trans_RiskImpact
                            {
                                Transaction_Id = Guid.NewGuid().ToString(),
                                Record_Id = Int32.Parse(csv_riskimpact.GetCell(row, 0)),
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _transRiskImpactRepository.Add(rec_trans);

                        }
                    }
                }

                if (success_riskprobability == true)
                {
                    int _count= _lkupRiskProbabilityRepository.GetAllRecords().Count();
                    if (_count <= 0)
                    {
                        int row;
                        int n = csv_riskprobability.NumRows;


                        for (row = 0; row <= n - 1; row++)
                        {

                            LkUp_RiskProbability rec = new LkUp_RiskProbability
                            {

                                Record_Id = Int32.Parse(csv_riskprobability.GetCell(row, 0)),
                                Record_Name = csv_riskprobability.GetCell(row, 1),
                                Record_Status = true,
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _lkupRiskProbabilityRepository.Add(rec);

                            Trans_RiskProbability rec_trans = new Trans_RiskProbability
                            {
                                Transaction_Id = Guid.NewGuid().ToString(),
                                Record_Id = Int32.Parse(csv_riskprobability.GetCell(row, 0)),
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _transRiskProbabilityRepository.Add(rec_trans);

                        }
                    }
                }

                if (success_riskreptimeframe == true)
                {
                    int _count= _lkupRiskRTimeframeRepository.GetAllRecords().Count();
                    if (_count <= 0)
                    {
                        int row;
                        int n = csv_riskreptimeframe.NumRows;


                        for (row = 0; row <= n - 1; row++)
                        {

                            LkUp_RiskRTimeframe rec = new LkUp_RiskRTimeframe
                            {

                                Record_Id = Int32.Parse(csv_riskreptimeframe.GetCell(row, 0)),
                                Record_Name = csv_riskreptimeframe.GetCell(row, 1),
                                Record_Status = true,
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _lkupRiskRTimeframeRepository.Add(rec);

                            Trans_RiskRTimeframe rec_trans = new Trans_RiskRTimeframe
                            {
                                Transaction_Id = Guid.NewGuid().ToString(),
                                Record_Id = Int32.Parse(csv_riskreptimeframe.GetCell(row, 0)),
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _transRiskRTimeframeRepository.Add(rec_trans);

                        }
                    }
                }

                if (success_peopletype == true)
                {
                    int _count= _lkupPeopleTypeRepository.GetAllRecords().Count();
                    if (_count <= 0)
                    {
                        int row;
                        int n = csv_peopletype.NumRows;


                        for (row = 0; row <= n - 1; row++)
                        {

                            LkUp_PeopleType rec = new LkUp_PeopleType
                            {

                                Record_Id = Int32.Parse(csv_peopletype.GetCell(row, 0)),
                                Record_Name = csv_peopletype.GetCell(row, 1),
                                Record_Status = true,
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _lkupPeopleTypeRepository.Add(rec);

                            Trans_PeopleType rec_trans = new Trans_PeopleType
                            {
                                Transaction_Id = Guid.NewGuid().ToString(),
                                Record_Id = Int32.Parse(csv_peopletype.GetCell(row, 0)),
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _transPeopleTypeRepository.Add(rec_trans);

                        }
                    }
                }

                if (success_procurementleadtime == true)
                {
                    int _count= _lkupProcurementLTimeRepository.GetAllRecords().Count();
                    if (_count <= 0)
                    {
                        int row;
                        int n = csv_procurementleadtime.NumRows;


                        for (row = 0; row <= n - 1; row++)
                        {

                            LkUp_ProcurementLTime rec = new LkUp_ProcurementLTime
                            {

                                Record_Id = Int32.Parse(csv_procurementleadtime.GetCell(row, 0)),
                                Record_Name = csv_procurementleadtime.GetCell(row, 1),
                                Record_Status = true,
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _lkupProcurementLTimeRepository.Add(rec);

                            Trans_ProcurementLTime rec_trans = new Trans_ProcurementLTime
                            {
                                Transaction_Id = Guid.NewGuid().ToString(),
                                Record_Id = Int32.Parse(csv_procurementleadtime.GetCell(row, 0)),
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _transProcurementLTimeRepository.Add(rec_trans);

                        }
                    }
                }

                if (success_projectscope == true)
                {
                    int _count= _lkupProjectScopeRepository.GetAllRecords().Count();
                    if (_count <= 0)
                    {
                        int row;
                        int n = csv_projectscope.NumRows;


                        for (row = 0; row <= n - 1; row++)
                        {

                            LkUp_ProjectScope rec = new LkUp_ProjectScope
                            {

                                Record_Id = Int32.Parse(csv_projectscope.GetCell(row, 0)),
                                Record_Name = csv_projectscope.GetCell(row, 1),
                                Record_Status = true,
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _lkupProjectScopeRepository.Add(rec);

                            Trans_ProjectScope rec_trans = new Trans_ProjectScope
                            {
                                Transaction_Id = Guid.NewGuid().ToString(),
                                Record_Id = Int32.Parse(csv_projectscope.GetCell(row, 0)),
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _transProjectScopeRepository.Add(rec_trans);

                        }
                    }
                }

                if (success_regionscope == true)
                {
                    int _count= _lkupRegionScopeRepository.GetAllRecords().Count();
                    if (_count <= 0)
                    {
                        int row;
                        int n = csv_regionscope.NumRows;


                        for (row = 0; row <= n - 1; row++)
                        {

                            LkUp_RegionScope rec = new LkUp_RegionScope
                            {

                                Record_Id = Int32.Parse(csv_regionscope.GetCell(row, 0)),
                                Record_Name = csv_regionscope.GetCell(row, 1),
                                Record_Status = true,
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _lkupRegionScopeRepository.Add(rec);

                            Trans_RegionScope rec_trans = new Trans_RegionScope
                            {
                                Transaction_Id = Guid.NewGuid().ToString(),
                                Record_Id = Int32.Parse(csv_regionscope.GetCell(row, 0)),
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _transRegionScopeRepository.Add(rec_trans);

                        }
                    }
                }

                if (success_strategypriority == true)
                {
                    int _count= _strategyPriorityRepository.GetAllRecords().Count();
                    if (_count <= 0)
                    {
                        int row;
                        int n = csv_strategypriority.NumRows;


                        for (row = 0; row <= n - 1; row++)
                        {

                            Strategy_Priority rec = new Strategy_Priority
                            {

                                Record_Id = Int32.Parse(csv_strategypriority.GetCell(row, 0)),
                                Record_Name = csv_strategypriority.GetCell(row, 1),
                                Record_Status = true,
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _strategyPriorityRepository.Add(rec);

                            Trans_StrategyPriority rec_trans = new Trans_StrategyPriority
                            {
                                Transaction_Id = Guid.NewGuid().ToString(),
                                Record_Id = Int32.Parse(csv_strategypriority.GetCell(row, 0)),
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _transStrategyPriorityRepository.Add(rec_trans);

                        }
                    }
                }

                if (success_strategykeyperformancearea == true)
                {
                    int _count= _strategyKeyPerformanceAreaRepository.GetAllRecords().Count();
                    if (_count <= 0)
                    {
                        int row;
                        int n = csv_strategykeyperformancearea.NumRows;


                        for (row = 0; row <= n - 1; row++)
                        {

                            Strategy_KeyPerformanceArea rec = new Strategy_KeyPerformanceArea
                            {

                                Record_Id = Int32.Parse(csv_strategykeyperformancearea.GetCell(row, 0)),
                                StrategicPriority_Id=Int32.Parse(csv_strategykeyperformancearea.GetCell(row, 1)),
                                Record_Name = csv_strategykeyperformancearea.GetCell(row, 2),
                                Record_Status = true,
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _strategyKeyPerformanceAreaRepository.Add(rec);

                            Trans_StrategyKeyPerformanceArea rec_trans = new Trans_StrategyKeyPerformanceArea
                            {
                                Transaction_Id = Guid.NewGuid().ToString(),
                                StrategicKeyPerformanceArea_Id = Int32.Parse(csv_strategykeyperformancearea.GetCell(row, 0)),
                                TransStrategicPriority_Id=_transStrategyPriorityRepository.GetRecordByMasterStrategyPriorityId(Int32.Parse(csv_strategykeyperformancearea.GetCell(row, 1))).Transaction_Id,
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _transStrategyKeyPerformanceAreaRepository.Add(rec_trans);

                        }
                    }
                }

                if (success_strucdirectorate == true)
                {
                    int _count= _strucDirectorateRepository.GetAllRecords().Count();
                    if (_count <= 0)
                    {
                        int row;
                        int n = csv_strucdirectorate.NumRows;


                        for (row = 0; row <= n - 1; row++)
                        {

                            Struc_Directorate rec = new Struc_Directorate
                            {

                                Record_Id = Int32.Parse(csv_strucdirectorate.GetCell(row, 0)),
                                Record_Name = csv_strucdirectorate.GetCell(row, 1),
                                Record_Status = true,
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _strucDirectorateRepository.Add(rec);

                            Trans_StrucDirectorate rec_trans = new Trans_StrucDirectorate
                            {
                                Transaction_Id = Guid.NewGuid().ToString(),
                                Record_Id = Int32.Parse(csv_strucdirectorate.GetCell(row, 0)),
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _transStrucDirectorateRepository.Add(rec_trans);

                        }
                    }
                }

                if (success_strucdivision == true)
                {
                    int _count= _strucDivisionRepository.GetAllRecords().Count();
                    if (_count <= 0)
                    {
                        int row;
                        int n = csv_strucdivision.NumRows;


                        for (row = 0; row <= n - 1; row++)
                        {

                            Struc_Division rec = new Struc_Division
                            {

                                Record_Id = Int32.Parse(csv_strucdivision.GetCell(row, 0)),
                                Directorate_Id=Int32.Parse(csv_strucdivision.GetCell(row, 1)),
                                Record_Name = csv_strucdivision.GetCell(row, 2),
                                Record_Status = true,
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _strucDivisionRepository.Add(rec);

                            Trans_StrucDivision rec_trans = new Trans_StrucDivision
                            {
                                Transaction_Id = Guid.NewGuid().ToString(),
                                Division_Id = Int32.Parse(csv_strucdivision.GetCell(row, 0)),
                                TransDirectorate_Id=_transStrucDirectorateRepository.GetRecordByMasterStrucDirectorateId(Int32.Parse(csv_strucdivision.GetCell(row, 1))).Transaction_Id,
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _transStrucDivisionRepository.Add(rec_trans);

                        }
                    }
                }

                if (success_programme == true)
                {
                    int _count= _lkupProgrammeRepository.GetAllRecords().Count();
                    if (_count <= 0)
                    {
                        int row;
                        int n = csv_programme.NumRows;


                        for (row = 0; row <= n - 1; row++)
                        {

                            LkUp_Programme rec = new LkUp_Programme
                            {

                                Record_Id = Int32.Parse(csv_programme.GetCell(row, 0)),
                                Directorate_Id=Int32.Parse(csv_programme.GetCell(row, 1)),
                                Division_Id=Int32.Parse(csv_programme.GetCell(row, 2)),
                                Record_Name = csv_programme.GetCell(row, 3),
                                DocPath="",
                                Record_Status = true,
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _lkupProgrammeRepository.Add(rec);

                            Trans_Programme rec_trans = new Trans_Programme
                            {
                                Transaction_Id = Guid.NewGuid().ToString(),
                                MainProgramme_Id= Int32.Parse(csv_programme.GetCell(row, 0)),
                                Directorate_Id=Int32.Parse(csv_programme.GetCell(row, 1)),
                                Division_Id=Int32.Parse(csv_programme.GetCell(row, 2)),
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _transProgrammeRepository.Add(rec_trans);

                        }
                    }
                }

                if (success_project == true)
                {
                    int _count= _lkupProjectRepository.GetAllRecords().Count();
                    if (_count <= 0)
                    {
                        int row;
                        int n = csv_project.NumRows;


                        for (row = 0; row <= n - 1; row++)
                        {

                            LkUp_Project rec = new LkUp_Project
                            {

                                Record_Id = Int32.Parse(csv_project.GetCell(row, 0)),
                                Programme_Id=Int32.Parse(csv_project.GetCell(row, 1)),
                                Directorate_Id=Int32.Parse(csv_project.GetCell(row, 2)),
                                Division_Id=Int32.Parse(csv_project.GetCell(row, 3)),
                                Record_Name = csv_project.GetCell(row, 4),
                                DocPath="",
                                Record_Status = true,
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _lkupProjectRepository.Add(rec);

                            Trans_Programme transrec=_transProgrammeRepository.GetRecordByMainProgrammeID(Int32.Parse(csv_project.GetCell(row, 1)));
                            if(transrec!=null)
                            {
                                Trans_Project rec_trans = new Trans_Project
                                {
                                    Transaction_Id = Guid.NewGuid().ToString(),
                                    TransProgramme_Id=transrec.Transaction_Id,
                                    MainProject_Id= Int32.Parse(csv_project.GetCell(row, 0)),
                                    MainProgramme_Id= Int32.Parse(csv_project.GetCell(row, 1)),
                                    Directorate_Id=Int32.Parse(csv_project.GetCell(row, 2)),
                                    Division_Id=Int32.Parse(csv_project.GetCell(row, 3)),
                                    TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                                };
                                 _transProjectRepository.Add(rec_trans);
                            }
                            else
                            {
                                Trans_Project rec_trans = new Trans_Project
                                {
                                    Transaction_Id = Guid.NewGuid().ToString(),
                                    TransProgramme_Id="", 
                                    MainProject_Id= Int32.Parse(csv_project.GetCell(row, 0)),
                                    MainProgramme_Id= Int32.Parse(csv_project.GetCell(row, 1)),
                                    Directorate_Id=Int32.Parse(csv_project.GetCell(row, 2)),
                                    Division_Id=Int32.Parse(csv_project.GetCell(row, 3)),
                                    TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                                };
                                 _transProjectRepository.Add(rec_trans);


                            }

                           

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



        [HttpPost]
        public ActionResult SetTestStaffEmails()
        {
            try
            {
                    var recs =  _employeeRepository.GetAllEmployee().ToList();

                    int _count = recs.Count();

                   // List<DropDownListViewModel> collection_recs = new List<DropDownListViewModel>();

                    string staffemail = "";
                    string testmail = "";

                    if (_count > 0)
                    {
                        foreach (var rec in recs)
                        {
                            staffemail=rec.First_Name+rec.Last_Name.Substring(0,2)+"@nepad.org";
                            staffemail=staffemail.ToLower();
                            testmail="gideonn@nepad.org";

                            rec.Email=staffemail;
                            rec.TestEmail=testmail;

                            _employeeRepository.Update(rec);
                            
                        

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

        [AcceptVerbs("Post")]
		public ActionResult Struc_Directorate_Create([DataSourceRequest] DataSourceRequest request, LookUpTablesViewModel record)
        {
            if (record != null && ModelState.IsValid)
            {  
                Struc_Directorate rec = _strucDirectorateRepository.GetRecordByName(record.LookUp_Name);

                if (rec == null && record.LookUp_Name !=null)
                {

                        var DB_Recs = _strucDirectorateRepository.GetAllRecords();
                        int _count = DB_Recs.Count();

                        Struc_Directorate rec_to_add = new Struc_Directorate
                        {
                            Record_Id=_count+1,
                            Record_Name=record.LookUp_Name,
                            Record_Status=null,
                            TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                        };

                        _strucDirectorateRepository.Add(rec_to_add);
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
        [AcceptVerbs("Post")]
		public ActionResult Struc_Directorate_Update([DataSourceRequest] DataSourceRequest request, LookUpTablesViewModel record)
        {
            if (record != null && ModelState.IsValid)
            {  
                Struc_Directorate rec = _strucDirectorateRepository.GetRecord(record.LookUp_Id);
                
                if (rec != null)
                {

                        Struc_Directorate rec_already_exist = _strucDirectorateRepository.GetRecordByName(record.LookUp_Name);

                        if(rec_already_exist==null)
                        {
                            rec.Record_Name=record.LookUp_Name;
                            rec.TransactionDate=new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);


                            _strucDirectorateRepository.Update(rec);
                        }
                }      
                           
            }
            
            return Json(new [] { record }.ToDataSourceResult(request, ModelState));
        }
        [AcceptVerbs("Post")]
		public ActionResult Struc_Division_Update([DataSourceRequest] DataSourceRequest request, LookUpTablesViewModel record)
        {
            if (record != null && ModelState.IsValid)
            {  
                Struc_Division rec = _strucDivisionRepository.GetRecord(record.LookUp_Id);
                
                if (rec != null)
                {

                        Struc_Division rec_already_exist = _strucDivisionRepository.GetRecordByName(record.LookUp_Name);

                        if(rec_already_exist==null)
                        {
                            rec.Record_Name=record.LookUp_Name;
                            rec.TransactionDate=new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);


                            _strucDivisionRepository.Update(rec);
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
		public async Task<ActionResult> Struc_DirStaffMapping_Delete([DataSourceRequest] DataSourceRequest request, EmployeeMappingViewModel record)
        {
            if (record != null && ModelState.IsValid)
            {  
                Struc_DirStaffMapping rec = _strucDirStaffMappingRepository.GetRecord(record.Transaction_Id);
                
                if (rec != null)
                {
                    //Delete all division level mapping related to this directorate
                    var DB_Recs =  _strucDivStaffMappingRepository.GetAllRecordsByEmployeeAndDirectorate(rec.EmployeePK, rec.Directorate_Id);
                    foreach (var recordset in DB_Recs)
                    {
                        _strucDivStaffMappingRepository.Delete(recordset.Transaction_Id);
                    }
                    //If this is the primary directorate, delete all assigned roles
                    Struc_DirStaffMapping thisprimarydir=_strucDirStaffMappingRepository.GetRecordByEmployeeAndThisPrimaryDirectorate(rec.EmployeePK, rec.Directorate_Id);

                    Employee _emp = _employeeRepository.GetEmployee(rec.EmployeePK);
                    var _user = await userManager.FindByIdAsync(_emp.IdentityUserId);

                    var userRoles = await userManager.GetRolesAsync(_user);

                    IdentityResult _result;

                    if(thisprimarydir!=null)
                    {
                        foreach (var userrec in userRoles)
                        {
                            if(userrec !="Admin")
                            {
                                _result = await userManager.RemoveFromRoleAsync(_user, userrec);
                            }
                        }
                        

                    }

                    //Delete directate mapping
                    _strucDirStaffMappingRepository.Delete(rec.Transaction_Id);
                }      
                           
            }
            
            return Json(new [] { record }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs("Post")]
		public async Task<ActionResult> Struc_DivStaffMapping_Delete([DataSourceRequest] DataSourceRequest request, EmployeeMappingViewModel record)
        {
            if (record != null && ModelState.IsValid)
            {  
                Struc_DivStaffMapping rec = _strucDivStaffMappingRepository.GetRecord(record.Transaction_Id);
                
                if (rec != null)
                {
                    //If this is the primary directorate and primary division, delete all assigned roles
                    Struc_DirStaffMapping thisprimarydir=_strucDirStaffMappingRepository.GetRecordByEmployeeAndThisPrimaryDirectorate(rec.EmployeePK, rec.Directorate_Id);
                    Struc_DivStaffMapping thisprimarydiv=_strucDivStaffMappingRepository.GetRecordByEmployeeAndThisPrimaryDivision(rec.EmployeePK, rec.Division_Id);

                    Employee _emp = _employeeRepository.GetEmployee(rec.EmployeePK);
                    var _user = await userManager.FindByIdAsync(_emp.IdentityUserId);

                    var userRoles = await userManager.GetRolesAsync(_user);

                    IdentityResult _result;

                    if(thisprimarydir!=null && thisprimarydiv!=null)
                    {
                        foreach (var userrec in userRoles)
                        {
                            if(userrec =="Division Head" || userrec =="Unit Lead" || userrec =="Programme Lead"  || userrec =="Nepad Staff" )
                            {
                                _result = await userManager.RemoveFromRoleAsync(_user, userrec);
                            }
                        }
                        

                    }

                    //Delete division mapping
                    _strucDivStaffMappingRepository.Delete(rec.Transaction_Id);
                }      
                           
            }
            
            return Json(new [] { record }.ToDataSourceResult(request, ModelState));
        }


        [AcceptVerbs("Post")]
		public ActionResult Struc_Directorate_Delete([DataSourceRequest] DataSourceRequest request, LookUpTablesViewModel record)
        {
            if (record != null && ModelState.IsValid)
            {  
                Struc_Directorate rec = _strucDirectorateRepository.GetRecord(record.LookUp_Id);
                
                if (rec != null)
                {


                        if(rec.Record_Status==null)
                        {
                            _strucDirectorateRepository.Delete(rec.Record_Id);
                        }
                }      
                           
            }
            
            return Json(new [] { record }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs("Post")]
		public ActionResult Struc_Division_Delete([DataSourceRequest] DataSourceRequest request, LookUpTablesViewModel record)
        {
            if (record != null && ModelState.IsValid)
            {  
                Struc_Division rec = _strucDivisionRepository.GetRecord(record.LookUp_Id);
                
                if (rec != null)
                {


                        if(rec.Record_Status==null)
                        {
                            _strucDivisionRepository.Delete(rec.Record_Id);
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
        [AcceptVerbs("Post")]
		public ActionResult Trans_StrucDirectorate_Delete([DataSourceRequest] DataSourceRequest request, LookUpTablesViewModel record)
        {
            if (record != null && ModelState.IsValid)
            {  
                Trans_StrucDirectorate rec = _transStrucDirectorateRepository.GetRecord(record.Trans_LookUp_Id);
                
                if (rec != null)
                {
                    _transStrucDirectorateRepository.Delete(rec.Transaction_Id);

                    Struc_Directorate rec_update=_strucDirectorateRepository.GetRecord(rec.Record_Id);
                    rec_update.Record_Status=false;
                    _strucDirectorateRepository.Update(rec_update);
                }      
                           
            }
            
            return Json(new [] { record }.ToDataSourceResult(request, ModelState));
        }


        [AcceptVerbs("Post")]
		public ActionResult Trans_StrucDivision_Delete([DataSourceRequest] DataSourceRequest request, LookUpTablesViewModel record)
        {
            if (record != null && ModelState.IsValid)
            {  
                Trans_StrucDivision rec = _transStrucDivisionRepository.GetRecord(record.Trans_LookUp_Id);
                
                if (rec != null)
                {
                    _transStrucDivisionRepository.Delete(rec.Transaction_Id);

                    Struc_Division rec_update=_strucDivisionRepository.GetRecord(rec.Division_Id);
                    rec_update.Record_Status=false;
                    _strucDivisionRepository.Update(rec_update);
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

        public ActionResult Struc_Directorate_Read([DataSourceRequest]DataSourceRequest request, string text)
        {


            List<LookUpTablesViewModel> collection_recs = new List<LookUpTablesViewModel>();



            var DB_Recs =  _strucDirectorateRepository.GetAllRecords();




            int _count =  DB_Recs.Count();


            if (_count > 0)
            {
                foreach (var rec in DB_Recs)
                {
   
                    LookUpTablesViewModel srec = new LookUpTablesViewModel
                    {
                        LookUp_Id = rec.Record_Id,
                        LookUp_Name =rec.Record_Name,
                        Show_trans_button=rec.Record_Status.HasValue? rec.Record_Status.Value? false: true: true,
                        LookUp_Status = rec.Record_Status.HasValue? rec.Record_Status.Value? "Transactional": "Active": "Inactive",
                        TransactionDate = new DateTime(rec.TransactionDate.Year, rec.TransactionDate.Month, rec.TransactionDate.Day)
                    };

                    collection_recs.Add(srec);
                }
            }



            return Json(collection_recs.ToDataSourceResult(request));
        }

        public ActionResult Struc_Division_Read([DataSourceRequest]DataSourceRequest request, string text)
        {
            List<LookUpTablesViewModel> collection_recs = new List<LookUpTablesViewModel>();

            var DB_Recs =  _strucDivisionRepository.GetAllRecords().ToList();

            int _count =  DB_Recs.Count();


            if (_count > 0)
            {
                foreach (var rec in DB_Recs)
                {
   
                    LookUpTablesViewModel srec = new LookUpTablesViewModel
                    {
                        LookUp_Id = rec.Record_Id,
                        LookUp_Name =rec.Record_Name,
                        ParentLink_Id=rec.Directorate_Id,
                        Show_trans_button=rec.Record_Status.HasValue? rec.Record_Status.Value? false: true: true,
                        LookUp_Status = rec.Record_Status.HasValue? rec.Record_Status.Value? "Transactional": "Active": "Inactive",
                        Category = new DropDownListViewModel()
                        {
                            DropDown_IntId = rec.Directorate_Id,
                            DropDown_Name = _strucDirectorateRepository.GetRecord(rec.Directorate_Id).Record_Name
                        },
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

        public ActionResult Trans_StrucDirectorate_Read([DataSourceRequest]DataSourceRequest request, string text)
        {


            List<LookUpTablesViewModel> collection_recs = new List<LookUpTablesViewModel>();

            var DB_Recs =  _transStrucDirectorateRepository.GetAllRecords().ToList();

            int _count = DB_Recs.Count();


            if (_count > 0)
            {
                foreach (var rec in DB_Recs)
                {

                    LookUpTablesViewModel srec = new LookUpTablesViewModel
                    {
                        LookUp_Id = rec.Record_Id,
                        Trans_LookUp_Id=rec.Transaction_Id,
                        LookUp_Name =_strucDirectorateRepository.GetRecord(rec.Record_Id).Record_Name,
                        TransactionDate = new DateTime(rec.TransactionDate.Year, rec.TransactionDate.Month, rec.TransactionDate.Day)
                    };

                    collection_recs.Add(srec);
                }
            }



            return Json(collection_recs.ToDataSourceResult(request));
        }

        public ActionResult Trans_StrucDivision_Read([DataSourceRequest]DataSourceRequest request, string text)
        {


            List<LookUpTablesViewModel> collection_recs = new List<LookUpTablesViewModel>();

            var DB_Recs =  _transStrucDivisionRepository.GetAllRecords().ToList();

            int _count = DB_Recs.Count();


            if (_count > 0)
            {
                foreach (var rec in DB_Recs)
                {

                    LookUpTablesViewModel srec = new LookUpTablesViewModel
                    {
                        
                        Trans_LookUp_Id=rec.Transaction_Id,
                        Trans_Parent_LookUp_Id=rec.TransDirectorate_Id,
                        ParentLink_Id=rec.Division_Id,
                        LookUp_Name =_strucDivisionRepository.GetRecord(rec.Division_Id).Record_Name,
                        Category = new DropDownListViewModel()
                        {
                            DropDown_IntId = _transStrucDirectorateRepository.GetRecord(rec.TransDirectorate_Id).Record_Id,
                            DropDown_Name = _strucDirectorateRepository.GetRecord(_transStrucDirectorateRepository.GetRecord(rec.TransDirectorate_Id).Record_Id).Record_Name
                        },
                        TransactionDate = new DateTime(rec.TransactionDate.Year, rec.TransactionDate.Month, rec.TransactionDate.Day)
                    };

                    collection_recs.Add(srec);
                }
            }



            return Json(collection_recs.ToDataSourceResult(request));
        }
        
        public ActionResult DirectorateStaffMapping_Read([DataSourceRequest]DataSourceRequest request, string recid)
        {


            List<EmployeeMappingViewModel> collection_recs = new List<EmployeeMappingViewModel>();

            if (recid != null)
            {
              //  AUDAProgramme prog = _programmeRepository.GetAUDAProgramme(Int32.Parse(programmeid));
                var DB_Recs = _strucDirStaffMappingRepository.GetAllRecordsByDirectorate(Int32.Parse(recid));

                int _count = DB_Recs.Count();
                if (_count > 0)
                {
                    foreach (var rec in DB_Recs)
                    {
                        Employee employee = _employeeRepository.GetEmployee(rec.EmployeePK);

                        string profilepicpath = "";
                        if (employee.PhotoPath == null)
                        {
                            if (employee.Gender == 1)
                                profilepicpath = "appdirectory/profilepics/male_null_profile.jpg";
                            else if (employee.Gender == 2)
                                profilepicpath = "appdirectory/profilepics/female_null_profile.jpg";
                            else
                                profilepicpath = "appdirectory/profilepics/male_null_profile.jpg";
                        }
                        else
                        {
                            profilepicpath = "appdirectory/" + employee.Staff_Number + "/" + employee.PhotoPath;

                        }

                        EmployeeMappingViewModel srec = new EmployeeMappingViewModel
                        {
                            EmployeePK = employee.Id,
                            Transaction_Id=rec.Transaction_Id,
                            EmployeeName = employee.First_Name + " " + employee.Last_Name,
                            Staff_Number = rec.Staff_Number,
                            profilepicpath = profilepicpath,
                            Directorate_Id=rec.Directorate_Id,
                            Mapping_Status_String = rec.Mapping_Status == true ? "Enabled" : "Disabled",
                            Primary_String = rec.PrimaryDirectorate == true ? "Primary" : "Secondary",
                            TransactionDate = new DateTime(rec.TransactionDate.Year, rec.TransactionDate.Month, rec.TransactionDate.Day)

                        };

                        collection_recs.Add(srec);
                    }
                }
            }


            return Json(collection_recs.ToDataSourceResult(request));
        }


        public ActionResult DirectorateDirectorMapping_Read([DataSourceRequest]DataSourceRequest request, string recid)
        {


            List<EmployeeMappingViewModel> collection_recs = new List<EmployeeMappingViewModel>();

            if (recid != null)
            {
              //  AUDAProgramme prog = _programmeRepository.GetAUDAProgramme(Int32.Parse(programmeid));
                var DB_Recs = _strucDirectorRepository.GetAllRecordsByDirectorate(Int32.Parse(recid));

                int _count = DB_Recs.Count();
                if (_count > 0)
                {
                    foreach (var rec in DB_Recs)
                    {
                        Employee employee = _employeeRepository.GetEmployee(rec.EmployeePK);

                        string profilepicpath = "";
                        if (employee.PhotoPath == null)
                        {
                            if (employee.Gender == 1)
                                profilepicpath = "appdirectory/profilepics/male_null_profile.jpg";
                            else if (employee.Gender == 2)
                                profilepicpath = "appdirectory/profilepics/female_null_profile.jpg";
                            else
                                profilepicpath = "appdirectory/profilepics/male_null_profile.jpg";
                        }
                        else
                        {
                            profilepicpath = "appdirectory/" + employee.Staff_Number + "/" + employee.PhotoPath;

                        }

                        EmployeeMappingViewModel srec = new EmployeeMappingViewModel
                        {
                            EmployeePK = employee.Id,
                            Transaction_Id=rec.Transaction_Id,
                            EmployeeName = employee.First_Name + " " + employee.Last_Name,
                            Staff_Number = rec.Staff_Number,
                            profilepicpath = profilepicpath,
                            Directorate_Id=rec.Directorate_Id,
                            Mapping_Status_String = rec.Status.HasValue? rec.Status.Value? "Substantive": "Not Assigned": "Inactive",
                            TransactionDate = new DateTime(rec.TransactionDate.Year, rec.TransactionDate.Month, rec.TransactionDate.Day)

                        };

                        collection_recs.Add(srec);
                    }
                }
            }


            return Json(collection_recs.ToDataSourceResult(request));
        }
        public ActionResult DivisionHeadMapping_Read([DataSourceRequest]DataSourceRequest request, string recid)
        {


            List<EmployeeMappingViewModel> collection_recs = new List<EmployeeMappingViewModel>();

            if (recid != null)
            {
              //  AUDAProgramme prog = _programmeRepository.GetAUDAProgramme(Int32.Parse(programmeid));
               // var DB_Recs = _strucDirectorRepository.GetAllRecordsByDirectorate(Int32.Parse(recid));
                var DB_Recs = _strucDivHeadRepository.GetAllRecordsByDivision(Int32.Parse(recid));


                int _count = DB_Recs.Count();
                if (_count > 0)
                {
                    foreach (var rec in DB_Recs)
                    {
                        Employee employee = _employeeRepository.GetEmployee(rec.EmployeePK);

                        string profilepicpath = "";
                        if (employee.PhotoPath == null)
                        {
                            if (employee.Gender == 1)
                                profilepicpath = "appdirectory/profilepics/male_null_profile.jpg";
                            else if (employee.Gender == 2)
                                profilepicpath = "appdirectory/profilepics/female_null_profile.jpg";
                            else
                                profilepicpath = "appdirectory/profilepics/male_null_profile.jpg";
                        }
                        else
                        {
                            profilepicpath = "appdirectory/" + employee.Staff_Number + "/" + employee.PhotoPath;

                        }

                        EmployeeMappingViewModel srec = new EmployeeMappingViewModel
                        {
                            EmployeePK = employee.Id,
                            Transaction_Id=rec.Transaction_Id,
                            EmployeeName = employee.First_Name + " " + employee.Last_Name,
                            Staff_Number = rec.Staff_Number,
                            profilepicpath = profilepicpath,
                            Directorate_Id=rec.Directorate_Id,
                            Mapping_Status_String = rec.Status.HasValue? rec.Status.Value? "Substantive": "Not Assigned": "Inactive",
                            TransactionDate = new DateTime(rec.TransactionDate.Year, rec.TransactionDate.Month, rec.TransactionDate.Day)

                        };

                        collection_recs.Add(srec);
                    }
                }
            }


            return Json(collection_recs.ToDataSourceResult(request));
        }




        public ActionResult DivisionStaffMapping_Read([DataSourceRequest]DataSourceRequest request, string recid)
        {


            List<EmployeeMappingViewModel> collection_recs = new List<EmployeeMappingViewModel>();

            if (recid != null)
            {
              //  AUDAProgramme prog = _programmeRepository.GetAUDAProgramme(Int32.Parse(programmeid));
                var DB_Recs = _strucDivStaffMappingRepository.GetAllRecordsByDivision(Int32.Parse(recid));

                int _count = DB_Recs.Count();
                if (_count > 0)
                {
                    foreach (var rec in DB_Recs)
                    {
                        Employee employee = _employeeRepository.GetEmployee(rec.EmployeePK);

                        string profilepicpath = "";
                        if (employee.PhotoPath == null)
                        {
                            if (employee.Gender == 1)
                                profilepicpath = "appdirectory/profilepics/male_null_profile.jpg";
                            else if (employee.Gender == 2)
                                profilepicpath = "appdirectory/profilepics/female_null_profile.jpg";
                            else
                                profilepicpath = "appdirectory/profilepics/male_null_profile.jpg";
                        }
                        else
                        {
                            profilepicpath = "appdirectory/" + employee.Staff_Number + "/" + employee.PhotoPath;

                        }

                        EmployeeMappingViewModel srec = new EmployeeMappingViewModel
                        {
                            EmployeePK = employee.Id,
                            Transaction_Id=rec.Transaction_Id,
                            EmployeeName = employee.First_Name + " " + employee.Last_Name,
                            Staff_Number = rec.Staff_Number,
                            profilepicpath = profilepicpath,
                            Directorate_Id=rec.Directorate_Id,
                            Division_Id=rec.Division_Id,
                            Mapping_Status_String = rec.Mapping_Status == true ? "Enabled" : "Disabled",
                            Primary_String = rec.PrimaryDivision == true ? "Primary" : "Secondary",
                            TransactionDate = new DateTime(rec.TransactionDate.Year, rec.TransactionDate.Month, rec.TransactionDate.Day)

                        };

                        collection_recs.Add(srec);
                    }
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

        [HttpPost]
        public ActionResult MakeDirectorateTrans(string recid)
        {
            try
            {
                Struc_Directorate rec = _strucDirectorateRepository.GetRecord(Int32.Parse(recid));
                rec.Record_Status=true;
                _strucDirectorateRepository.Update(rec);

                Trans_StrucDirectorate rec_trans = new Trans_StrucDirectorate
                {
                    Transaction_Id = Guid.NewGuid().ToString(),
                    Record_Id = rec.Record_Id,
                    TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                };
                _transStrucDirectorateRepository.Add(rec_trans);

                 return Json(new { rtnmsg = "success" });
            }
            catch (Exception)
            {
                return Json(new { rtnmsg = "error" });
            }
        }

        [HttpPost]
        public ActionResult MakeDivisionTrans(string recid)
        {
            try
            {
                Struc_Division rec = _strucDivisionRepository.GetRecord(Int32.Parse(recid));
                rec.Record_Status=true;
                _strucDivisionRepository.Update(rec);

                Trans_StrucDivision rec_trans = new Trans_StrucDivision
                {
                    Transaction_Id = Guid.NewGuid().ToString(),
                    Division_Id = rec.Record_Id,
                    TransDirectorate_Id=_transStrucDirectorateRepository.GetRecordByMasterStrucDirectorateId(rec.Directorate_Id).Transaction_Id,
                    TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                };
                _transStrucDivisionRepository.Add(rec_trans);

                 return Json(new { rtnmsg = "success" });
            }
            catch (Exception)
            {
                return Json(new { rtnmsg = "error" });
            }
        }

        //**************KENDO WINDOW PARTIAL VIEWS******************///
        public ActionResult AddStrucDivision()
        {
            LookUpTablesViewModel model = new LookUpTablesViewModel
            {
            };

            return PartialView("_AddStrucDivision", model);
        }


        public ActionResult EditStaffDirectorateMapping(string transid)
        {
            Struc_DirStaffMapping rec = _strucDirStaffMappingRepository.GetRecord(transid);
            EmployeeMappingViewModel model = new EmployeeMappingViewModel
            {
                Transaction_Id=rec.Transaction_Id,
                EmployeePK=rec.EmployeePK,
                Directorate_Id=rec.Directorate_Id,
                Directorate_Name = _strucDirectorateRepository.GetRecord(rec.Directorate_Id).Record_Name,
                EmployeeName=_employeeRepository.GetEmployee(rec.EmployeePK).First_Name+" "+_employeeRepository.GetEmployee(rec.EmployeePK).Last_Name,
                Mapping_Status=rec.Mapping_Status,
                Primary=rec.PrimaryDirectorate


            };




            return PartialView("_EditStaffDirectorateMapping", model);
        }
        public ActionResult EditStaffDivisionMapping(string transid)
        {
            Struc_DivStaffMapping rec = _strucDivStaffMappingRepository.GetRecord(transid);
            EmployeeMappingViewModel model = new EmployeeMappingViewModel
            {
                Transaction_Id=rec.Transaction_Id,
                EmployeePK=rec.EmployeePK,
                Directorate_Id=rec.Directorate_Id,
                Division_Id=rec.Division_Id,
                Directorate_Name = _strucDirectorateRepository.GetRecord(rec.Directorate_Id).Record_Name,
                Division_Name=_strucDivisionRepository.GetRecord(rec.Division_Id).Record_Name,
                EmployeeName=_employeeRepository.GetEmployee(rec.EmployeePK).First_Name+" "+_employeeRepository.GetEmployee(rec.EmployeePK).Last_Name,
                Mapping_Status=rec.Mapping_Status,
                Primary=rec.PrimaryDivision


            };




            return PartialView("_EditStaffDivisionMapping", model);
        }

        [HttpPost]
        public ActionResult EditStaffDirectorateMapping(EmployeeMappingViewModel model)
        {
            
            Struc_DirStaffMapping rec = _strucDirStaffMappingRepository.GetRecord(model.Transaction_Id);

            
            if (rec != null)
            {
                Struc_DirStaffMapping primarydir=_strucDirStaffMappingRepository.GetRecordByEmployeeAndPrimaryDirectorate(rec.EmployeePK);

                Struc_DirStaffMapping thisprimarydir=_strucDirStaffMappingRepository.GetRecordByEmployeeAndThisPrimaryDirectorate(rec.EmployeePK, model.Directorate_Id);

                if(model.Primary==false || (model.Primary==true && primarydir ==null) || thisprimarydir!=null)
                {
                    try
                    {

                        rec.Mapping_Status=model.Mapping_Status;
                        rec.PrimaryDirectorate=model.Primary;

                        _strucDirStaffMappingRepository.Update(rec);

                        Struc_DivStaffMapping primarydivrec=_strucDivStaffMappingRepository.GetRecordByEmployeeAndPrimaryDivision(rec.EmployeePK);

                        if(primarydivrec!=null)
                        {
                            if(primarydivrec.Directorate_Id==model.Directorate_Id)
                            {
                                primarydivrec.PrimaryDivision=false;
                                _strucDivStaffMappingRepository.Update(primarydivrec);

                            }
                        }

                        return Json(new { rtnmsg = "success" });
                    }
                    catch (Exception)
                    {
                        return Json(new { rtnmsg = "error" });
                    }
                }
                else
                {
                    return Json(new { rtnmsg = "otherprimaryalreadyexist" });
                }
            }
            else
            {
                return Json(new { rtnmsg = "doesnotexist" });
            }



        }

        [HttpPost]
        public ActionResult EditStaffDivisionMapping(EmployeeMappingViewModel model)
        {
            
            Struc_DivStaffMapping rec = _strucDivStaffMappingRepository.GetRecord(model.Transaction_Id);


            if (rec != null)
            {
                Struc_DivStaffMapping thisprimarydiv=_strucDivStaffMappingRepository.GetRecordByEmployeeAndThisPrimaryDivision(rec.EmployeePK, model.Division_Id);
                Struc_DivStaffMapping primarydiv=_strucDivStaffMappingRepository.GetRecordByEmployeeAndPrimaryDivision(rec.EmployeePK);

                Struc_DirStaffMapping primarydir=_strucDirStaffMappingRepository.GetRecordByEmployeeAndPrimaryDirectorate(rec.EmployeePK);
                Struc_DirStaffMapping thisprimarydir=_strucDirStaffMappingRepository.GetRecordByEmployeeAndThisPrimaryDirectorate(rec.EmployeePK, model.Directorate_Id);

                

                if(model.Primary==false || (model.Primary==true && thisprimarydir !=null && primarydiv==null) || (thisprimarydiv!=null && thisprimarydir!=null))
                {
                    try
                    {

                        rec.Mapping_Status=model.Mapping_Status;
                        rec.PrimaryDivision=model.Primary;

                        _strucDivStaffMappingRepository.Update(rec);

                        return Json(new { rtnmsg = "success" });
                    }
                    catch (Exception)
                    {
                        return Json(new { rtnmsg = "error" });
                    }
                }
                else
                {
                    return Json(new { rtnmsg = "notprimarydirectorate" });

                }
            }
            else
            {
                return Json(new { rtnmsg = "doesnotexist" });
            }



        }


        //**************AJAX ACTIONS******************///

        [HttpPost]
        public ActionResult AddStrucDivision(LookUpTablesViewModel record)
        {

            string returnmessage = "";


            if (record != null && ModelState.IsValid)
            {  
                Struc_Division rec = _strucDivisionRepository.GetRecordByName(record.LookUp_Name);

                if (rec == null && record.LookUp_Name !=null)
                {

                        var DB_Recs = _strucDivisionRepository.GetAllRecords();
                        int _count = DB_Recs.Count();

                        Struc_Division rec_to_add = new Struc_Division
                        {
                            Record_Id=_count+1,
                            Record_Name=record.LookUp_Name,
                            Directorate_Id=record.ParentLink_Id,
                            Record_Status=null,
                            TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                        };

                        _strucDivisionRepository.Add(rec_to_add);
                        returnmessage = "success";
                }    
                else
                {
                    returnmessage = "alreadyexist";

                }      
                           
            }
            else
            {
                returnmessage = "error";

            }
            
           return Json(new { rtnmsg = returnmessage });
        }
        //public async Task<ActionResult> AddStaffDirectorateMapping(string dirid, string empid, bool primaryid)
        [HttpPost]
        public async Task<ActionResult> AddStaffDirectorateMapping(EmployeeViewModel model)
        {
            Employee emp = _employeeRepository.GetEmployee(model.Employee_Id);
            Struc_DirStaffMapping rec=_strucDirStaffMappingRepository.GetRecordByEmployeeAndDirectorate(model.Employee_Id, model.Directorate_Id);
            IdentityResult _result;

            Struc_DirStaffMapping primarydir=_strucDirStaffMappingRepository.GetRecordByEmployeeAndPrimaryDirectorate(model.Employee_Id);

            if (rec == null)
            {
                if(model.PrimaryMain==false || (model.PrimaryMain==true && primarydir ==null))
                {
                    try
                    {
                        Struc_DirStaffMapping rec_to_add = new Struc_DirStaffMapping
                        {
                            Transaction_Id= Guid.NewGuid().ToString(),
                            EmployeePK= model.Employee_Id,
                            Staff_Number=emp.Staff_Number,
                            IdentityUserId=emp.IdentityUserId,
                            Directorate_Id= model.Directorate_Id,
                            Mapping_Status=true,
                            PrimaryDirectorate=model.PrimaryMain,
                            TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                        };


                        _strucDirStaffMappingRepository.Add(rec_to_add);

                        if(emp.IdentityUserId==null || emp.IdentityUserId=="")
                        {
                            var user = new ApplicationUser
                            {
                                UserName = emp.Email,
                                Email = emp.Email,
                                Staff_Number = emp.Staff_Number,
                                Employee_Id = emp.Id,
                                Admin_Generated = true,
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)

                            };

                            // Store user data in AspNetUsers database table
                            var result = await userManager.CreateAsync(user, "Compute112233");

                            if (result.Succeeded)
                            {
                                //await signInManager.SignInAsync(user, isPersistent: false);


                                emp.IdentityUserId = user.Id;
                                //Update Employee Record
                                var employee = _context.Employees.Attach(emp);
                                employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                                _context.SaveChanges();

                            }
                            //SEND EMAIL WITH CREDENTIALS

                            string content="<p>Dear "+ emp.First_Name+" "+emp.Last_Name+",</p>"+ 
                                        "<p>&nbsp;</p>" +
                                        "<p>Welcome to <strong>AUDA-NEPAD Integrated Planning Data System</strong>. An account has been created for you with the following credentials:</p>"+
                                        "<p>&nbsp;</p>"+
                                        "<p><strong>Username</strong>:"+" "+ emp.Email+"</p>"+
                                        "<p><strong>Password</strong>: Compute112233</p>"+
                                        "<p>&nbsp;</p>"+
                                        "<p>You will be required to change the initial password when you login for the first time. Please ensure the password is not shared.&nbsp;</p>"+
                                        "<p>&nbsp;</p>"+
                                        "<p>Kind regards.</p>"+
                                        "<p>AUDA-NEPAD Integrated Planning Data System Team</p>";

                            var message = new Message(new string[] { emp.TestEmail}, "AUDA-NEPAD Integrated: Password Created", content);
                            await _emailSender.SendEmailAsync(message);
                        }

                        Employee _emp = _employeeRepository.GetEmployee(model.Employee_Id);

                        var _user = await userManager.FindByIdAsync(_emp.IdentityUserId);

                        var isInRole = await userManager.IsInRoleAsync(_user, "Nepad Staff");

                        if (!isInRole)
                        {
                            _result = await userManager.AddToRoleAsync(_user, "Nepad Staff");
                        }


                        return Json(new { rtnmsg = "success" });
                    }
                    catch (Exception)
                    {
                        return Json(new { rtnmsg = "error" });
                    }
                }
                else
                {
                    return Json(new { rtnmsg = "otherprimaryalreadyexist" });

                }
            }
            else
            {
                return Json(new { rtnmsg = "alreadyexist" });
            }



        }



        [HttpPost]
        public async Task<ActionResult> AddDirectorateDirectorMapping(EmployeeViewModel model)
        {
            Employee emp = _employeeRepository.GetEmployee(model.Employee_Id);
            Struc_DirStaffMapping rec=_strucDirStaffMappingRepository.GetRecordByEmployeeAndDirectorate(model.Employee_Id, model.Directorate_Id);
            IdentityResult _result;

            Struc_DirStaffMapping primarydir=_strucDirStaffMappingRepository.GetRecordByEmployeeAndPrimaryDirectorate(model.Employee_Id);


            if(primarydir !=null)
            {
                try
                {
                    Struc_Director rec_to_add = new Struc_Director
                    {
                        Transaction_Id= Guid.NewGuid().ToString(),
                        EmployeePK= model.Employee_Id,
                        Staff_Number=emp.Staff_Number,
                        Directorate_Id= model.Directorate_Id,
                        Status=true,
                        StartDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day),
                        TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                    };


                    _strucDirectorRepository.Add(rec_to_add);

                    Employee _emp = _employeeRepository.GetEmployee(model.Employee_Id);

                    var _user = await userManager.FindByIdAsync(_emp.IdentityUserId);

                    var isInRole = await userManager.IsInRoleAsync(_user, "Director");

                    if (!isInRole)
                    {
                        _result = await userManager.AddToRoleAsync(_user, "Director");
                    }
                            

                    return Json(new { rtnmsg = "success" });
                }
                catch (Exception)
                {
                    return Json(new { rtnmsg = "error" });
                }
            }
            else
            {
                return Json(new { rtnmsg = "otherprimaryalreadyexist" });

            }




        }


        [HttpPost]
        public async Task<ActionResult> AddDivisionHeadMapping(EmployeeViewModel model)
        {
            Employee emp = _employeeRepository.GetEmployee(model.Employee_Id);
           // Struc_DirStaffMapping rec=_strucDirStaffMappingRepository.GetRecordByEmployeeAndDirectorate(model.Employee_Id, model.Directorate_Id);
            Struc_DivStaffMapping rec=_strucDivStaffMappingRepository.GetRecordByEmployeeAndDivision(model.Employee_Id, model.Division_Id);
            IdentityResult _result;

           // Struc_DirStaffMapping primarydir=_strucDirStaffMappingRepository.GetRecordByEmployeeAndPrimaryDirectorate(model.Employee_Id);

            Struc_DivStaffMapping primaryrec=_strucDivStaffMappingRepository.GetRecordByEmployeeAndPrimaryDivision(model.Employee_Id);




            if(primaryrec !=null)
            {
                try
                {
                    Struc_DivHead rec_to_add = new Struc_DivHead
                    {
                        Transaction_Id= Guid.NewGuid().ToString(),
                        EmployeePK= model.Employee_Id,
                        Staff_Number=emp.Staff_Number,
                        Directorate_Id= model.Directorate_Id,
                        Division_Id=model.Division_Id,
                        Status=true,
                        StartDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day),
                        TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                    };

                    _strucDivHeadRepository.Add(rec_to_add);

                    Employee _emp = _employeeRepository.GetEmployee(model.Employee_Id);

                    var _user = await userManager.FindByIdAsync(_emp.IdentityUserId);

                    var isInRole = await userManager.IsInRoleAsync(_user, "Division Head");

                    if (!isInRole)
                    {
                        _result = await userManager.AddToRoleAsync(_user, "Division Head");
                    }
                            

                    return Json(new { rtnmsg = "success" });
                }
                catch (Exception)
                {
                    return Json(new { rtnmsg = "error" });
                }
            }
            else
            {
                return Json(new { rtnmsg = "otherprimaryalreadyexist" });

            }




        }

        [HttpPost]
        public async Task<ActionResult> AddStaffDivisionMapping(EmployeeViewModel model)
        {
            Employee emp = _employeeRepository.GetEmployee(model.Employee_Id);
            Struc_DivStaffMapping rec=_strucDivStaffMappingRepository.GetRecordByEmployeeAndDivision(model.Employee_Id, model.Division_Id);
            IdentityResult _result;

            //Struc_DirStaffMapping primarydir=_strucDirStaffMappingRepository.GetRecordByEmployeeAndPrimaryDirectorate(model.Employee_Id);

            Struc_DirStaffMapping thisprimarydir=_strucDirStaffMappingRepository.GetRecordByEmployeeAndThisPrimaryDirectorate(model.Employee_Id, model.Directorate_Id);

            if (rec == null)
            {
                if(model.PrimaryMain==false || (model.PrimaryMain==true && thisprimarydir !=null))
                {
                    try
                    {

                        Struc_DivStaffMapping rec_to_add = new Struc_DivStaffMapping
                        {
                            Transaction_Id= Guid.NewGuid().ToString(),
                            EmployeePK= model.Employee_Id,
                            Staff_Number=emp.Staff_Number,
                            IdentityUserId=emp.IdentityUserId,
                            Directorate_Id= model.Directorate_Id,
                            Division_Id=model.Division_Id,
                            Mapping_Status=true,
                            PrimaryDivision=model.PrimaryMain,
                            TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                        };


                        _strucDivStaffMappingRepository.Add(rec_to_add);


                        //Check if lowest role exist and add
                        Employee _emp = _employeeRepository.GetEmployee(model.Employee_Id);
                        var _user = await userManager.FindByIdAsync(_emp.IdentityUserId);
                        var isInRole = await userManager.IsInRoleAsync(_user, "Nepad Staff");


                        if (!isInRole)
                        {
                            _result = await userManager.AddToRoleAsync(_user, "Nepad Staff");
                        }

                        return Json(new { rtnmsg = "success" });
                    }
                    catch (Exception)
                    {
                        return Json(new { rtnmsg = "error" });
                    }
                }
                else
                {
                    return Json(new { rtnmsg = "notprimarydirectorate" });

                }
            }
            else
            {
                return Json(new { rtnmsg = "alreadyexist" });
            }



        }

        //**************DROP DOWN READS******************///

        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetAllTransDirectorate()
        {
            // IEnumerable<Employee> DB_Employees = new List<Employee>();
            

            var recs =  _transStrucDirectorateRepository.GetAllRecords().ToList();

            int _count = recs.Count();

            List<DropDownListViewModel> collection_recs = new List<DropDownListViewModel>();



            if (_count > 0)
            {
                foreach (var rec in recs)
                {
                   
                    DropDownListViewModel srec = new DropDownListViewModel
                    {
                            DropDown_IntId = rec.Record_Id,
                            DropDown_Name = _strucDirectorateRepository.GetRecord(rec.Record_Id).Record_Name
                    };
                    // EmployeeDropDownViewModel me = DB_Employees[_count];
                    collection_recs.Add(srec);
                }
            }


            return Json(collection_recs.ToList());

        }

        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetTransDivisionsByDirectorate(int directorate)
        {
            var recs =  _transStrucDivisionRepository.GetAllRecordsByDirectorate(_transStrucDirectorateRepository.GetRecordByMasterStrucDirectorateId(directorate).Transaction_Id).ToList();

            int _count = recs.Count();

            List<DropDownListViewModel> collection_recs = new List<DropDownListViewModel>();



            if (_count > 0)
            {
                foreach (var rec in recs)
                {
                   
                    DropDownListViewModel srec = new DropDownListViewModel
                    {
                            DropDown_IntId = rec.Division_Id,
                            DropDown_Name = _strucDivisionRepository.GetRecord(rec.Division_Id).Record_Name
                    };
                    // EmployeeDropDownViewModel me = DB_Employees[_count];
                    collection_recs.Add(srec);
                }
            }

            return Json(collection_recs.ToList());

        }

        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetDirMappStaff(int recid)
        {
            var recs =  _strucDirStaffMappingRepository.GetAllRecordsByDirectorate(recid).ToList();

            int _count = recs.Count();

            List<DropDownListViewModel> collection_recs = new List<DropDownListViewModel>();



            if (_count > 0)
            {
                foreach (var rec in recs)
                {
                    Employee employee = _employeeRepository.GetEmployee(rec.EmployeePK);
                   
                    DropDownListViewModel srec = new DropDownListViewModel
                    {
                            DropDown_IntId = employee.Id,
                            DropDown_Name = employee.First_Name + " " + employee.Last_Name
                    };
                    // EmployeeDropDownViewModel me = DB_Employees[_count];
                    collection_recs.Add(srec);
                }
            }

            return Json(collection_recs.ToList());

        }

        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetDirPrimaryMappStaff(int recid)
        {
            var recs =  _strucDirStaffMappingRepository.GetAllRecordsByDirectorate(recid).ToList();

            int _count = recs.Count();

            List<DropDownListViewModel> collection_recs = new List<DropDownListViewModel>();



            if (_count > 0)
            {
                foreach (var rec in recs)
                {
                    Struc_DirStaffMapping thisprimarydir=_strucDirStaffMappingRepository.GetRecordByEmployeeAndThisPrimaryDirectorate(rec.EmployeePK, recid);

                    if(thisprimarydir!=null)
                    {
                        Employee employee = _employeeRepository.GetEmployee(rec.EmployeePK);
                    
                        DropDownListViewModel srec = new DropDownListViewModel
                        {
                                DropDown_IntId = employee.Id,
                                DropDown_Name = employee.First_Name + " " + employee.Last_Name
                        };
                        // EmployeeDropDownViewModel me = DB_Employees[_count];
                        collection_recs.Add(srec);
                    }
                }
            }

            return Json(collection_recs.ToList());

        }

        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetDivPrimaryMappStaff(int recid)
        {
           
            var recs =  _strucDivStaffMappingRepository.GetAllRecordsByDivision(recid).ToList();

            int _count = recs.Count();

            List<DropDownListViewModel> collection_recs = new List<DropDownListViewModel>();



            if (_count > 0)
            {
                foreach (var rec in recs)
                {
                    Struc_DivStaffMapping thisprimarydiv=_strucDivStaffMappingRepository.GetRecordByEmployeeAndThisPrimaryDivision(rec.EmployeePK, recid);

                    if(thisprimarydiv!=null)
                    {
                        Employee employee = _employeeRepository.GetEmployee(rec.EmployeePK);
                    
                        DropDownListViewModel srec = new DropDownListViewModel
                        {
                                DropDown_IntId = employee.Id,
                                DropDown_Name = employee.First_Name + " " + employee.Last_Name
                        };
                        // EmployeeDropDownViewModel me = DB_Employees[_count];
                        collection_recs.Add(srec);
                    }
                }
            }

            return Json(collection_recs.ToList());

        }

        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetAllEmployee()
        {
            // IEnumerable<Employee> DB_Employees = new List<Employee>();
            

            var recs =  _employeeRepository.GetAllEmployee().ToList();

            int _count = recs.Count();

            List<DropDownListViewModel> collection_recs = new List<DropDownListViewModel>();



            if (_count > 0)
            {
                foreach (var rec in recs)
                {
                   
                    DropDownListViewModel srec = new DropDownListViewModel
                    {
                            DropDown_IntId = rec.Id,
                            DropDown_Name = rec.First_Name+" "+rec.Last_Name
                    };
                    // EmployeeDropDownViewModel me = DB_Employees[_count];
                    collection_recs.Add(srec);
                }
            }


            return Json(collection_recs.ToList());

        }

    }
}