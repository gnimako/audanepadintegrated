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
    public class NEPADStaffController: Controller
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
        private readonly IStrategy_MTPRepository _strategyMTPRepository;
        private readonly IStrategy_MTPPriorityMappingRepository _strategyMTPPriorityMappingRepository ;
        private readonly IStrategy_KeyPerformanceAreaRepository _strategyKeyPerformanceAreaRepository;
        private readonly IStrategy_OutputIndicatorsRepository _strategyOutputIndicatorsRepository ;
        private readonly IStrategy_OutputIndicatorsPriorityMappingRepository _strategyOutputIndicatorsPriorityMappingRepository;
        private readonly IStruc_DirectorateRepository _strucDirectorateRepository ;
        private readonly IStruc_DivisionRepository _strucDivisionRepository;
        private readonly ILkUp_ProgrammeRepository _lkupProgrammeRepository;
        private readonly ILkUp_ProjectRepository _lkupProjectRepository;
        private readonly ILkUp_PeriodRepository _lkupPeriodRepository;
        private readonly ILkUp_IndicatorTypeRepository _lkupIndicatorTypeRepository;


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
        private readonly ITrans_StrategyMTPRepository _transStrategyMTPRepository ;
        private readonly ITrans_StrategyKeyPerformanceAreaRepository _transStrategyKeyPerformanceAreaRepository  ;
        private readonly ITrans_StrategyOutputIndicators _transStrategyOutputIndicators  ;
        private readonly ITrans_StrucDirectorateRepository _transStrucDirectorateRepository  ;
        private readonly ITrans_StrucDivisionRepository _transStrucDivisionRepository  ;
        private readonly ITrans_ProgrammeRepository _transProgrammeRepository ;
        private readonly ITrans_ProjectRepository _transProjectRepository  ;
        private readonly ITrans_PeriodRepository _transPeriodRepository ;
        private readonly ITrans_IndicatorTypeRepository _transIndicatorTypeRepository ;
        private readonly ISystem_AuditRepository _sysSystemAuditRepository;

        


        private readonly IStruc_DirStaffMappingRepository _strucDirStaffMappingRepository  ;
        private readonly IStruc_DivStaffMappingRepository _strucDivStaffMappingRepository  ;

        private readonly IStruc_DirectorRepository _strucDirectorRepository   ;
        private readonly IStruc_DirectorOICRepository _strucDirectorOICRepository   ;
        private readonly IStruc_DivHeadRepository _strucDivHeadRepository   ;
        private readonly IStruc_DivHeadOICRepository _strucDivHeadOICRepository  ;
        private readonly IEmailSender _emailSender  ;

        //Workplans
        private readonly IWP_DispatchCycleRepository _wpDispatchCycleRepository;
        private readonly IWP_MainRecordRepository _wpMainRecordRepository;
        private readonly IWP_OutcomesRepository _wpOutcomesRepository;
        private readonly IWP_MTPRepository _wpMTPRepository;
        private readonly IWP_AUDAPriorityRepository _wpAUDAPriorityRepository;
        private readonly IWP_ApprovalStatusRepository _wpApprovalStatusRepository;
        private readonly IWP_RegionScopeRepository _wpRegionScopeRepository;
        private readonly IWP_CountryScopeRepository _wpCountryScopeRepository ;
        private readonly IWP_OutputsRepository _wpOutputsRepository ;
        private readonly IWP_OutputIndicatorsRepository _wpOutputIndicatorsRepository ;
        private readonly IWP_OutputActivitiesRepository _wpOutputActivitiesRepository ;
        private readonly IWP_SAPLinkRepository _wpSAPLinkRepository  ;
        private readonly IWP_OutputBudgetRepository _wpOutputBudgetRepository ;
        private readonly IWP_OutputActivityCountriesRepository _wpOutputActivityCountriesRepository;




        private readonly AppDbContext _context;

        private readonly IWebHostEnvironment hostingEnvironment;

        public NEPADStaffController(IEmployeeRepository employeeRepository,
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
                                IStrategy_MTPRepository strategyMTPRepository,
                                IStrategy_MTPPriorityMappingRepository strategyMTPPriorityMappingRepository,
                                IStrategy_KeyPerformanceAreaRepository strategyKeyPerformanceAreaRepository,
                                IStrategy_OutputIndicatorsRepository strategyOutputIndicatorsRepository,
                                IStrategy_OutputIndicatorsPriorityMappingRepository strategyOutputIndicatorsPriorityMappingRepository,
                                IStruc_DirectorateRepository strucDirectorateRepository,
                                IStruc_DivisionRepository strucDivisionRepository,
                                ILkUp_ProgrammeRepository lkupProgrammeRepository,
                                ILkUp_ProjectRepository lkupProjectRepository,
                                ILkUp_PeriodRepository lkupPeriodRepository,
                                ILkUp_IndicatorTypeRepository lkupIndicatorTypeRepository,

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
                                ITrans_StrategyMTPRepository transStrategyMTPRepository,
                                ITrans_StrategyKeyPerformanceAreaRepository transStrategyKeyPerformanceAreaRepository,
                                ITrans_StrategyOutputIndicators transStrategyOutputIndicators,
                                ITrans_StrucDirectorateRepository transStrucDirectorateRepository,
                                ITrans_StrucDivisionRepository transStrucDivisionRepository,   
                                ITrans_ProgrammeRepository transProgrammeRepository, 
                                ITrans_ProjectRepository transProjectRepository, 
                                ITrans_PeriodRepository transPeriodRepository,
                                ITrans_IndicatorTypeRepository transIndicatorTypeRepository,
                                ISystem_AuditRepository sysSystemAuditRepository,
                                IStruc_DirStaffMappingRepository strucDirStaffMappingRepository,
                                IStruc_DivStaffMappingRepository strucDivStaffMappingRepository,
                                IStruc_DirectorRepository strucDirectorRepository,
                                IStruc_DirectorOICRepository strucDirectorOICRepository,
                                IStruc_DivHeadRepository strucDivHeadRepository,
                                IStruc_DivHeadOICRepository strucDivHeadOICRepository,
                                IEmailSender emailSender,
                                //workplans
                                IWP_DispatchCycleRepository wpDispatchCycleRepository,
                                IWP_MainRecordRepository wpMainRecordRepository,
                                IWP_OutcomesRepository wpOutcomesRepository,
                                IWP_MTPRepository wpMTPRepository,
                                IWP_AUDAPriorityRepository wpAUDAPriorityRepository,
                                IWP_ApprovalStatusRepository wpApprovalStatusRepository,
                                IWP_RegionScopeRepository wpRegionScopeRepository,
                                IWP_CountryScopeRepository wpCountryScopeRepository,
                                IWP_OutputsRepository wpOutputsRepository,
                                IWP_OutputIndicatorsRepository wpOutputIndicatorsRepository,
                                IWP_OutputActivitiesRepository wpOutputActivitiesRepository,
                                IWP_SAPLinkRepository wpSAPLinkRepository,
                                IWP_OutputBudgetRepository wpOutputBudgetRepository,
                                IWP_OutputActivityCountriesRepository wpOutputActivityCountriesRepository)
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
            _lkupPeriodRepository=lkupPeriodRepository;
            _lkupIndicatorTypeRepository=lkupIndicatorTypeRepository;
            _strategyPriorityRepository=strategyPriorityRepository;
            _strategyMTPRepository=strategyMTPRepository;
            _strategyMTPPriorityMappingRepository=strategyMTPPriorityMappingRepository;
            _strategyKeyPerformanceAreaRepository=strategyKeyPerformanceAreaRepository;
            _strategyOutputIndicatorsRepository=strategyOutputIndicatorsRepository;
            _strategyOutputIndicatorsPriorityMappingRepository=strategyOutputIndicatorsPriorityMappingRepository;
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
            _transStrategyMTPRepository=transStrategyMTPRepository;
            _transStrategyKeyPerformanceAreaRepository=transStrategyKeyPerformanceAreaRepository;
            _transStrategyOutputIndicators=transStrategyOutputIndicators;
            _transStrucDirectorateRepository=transStrucDirectorateRepository;
            _transStrucDivisionRepository=transStrucDivisionRepository;
            _transProgrammeRepository=transProgrammeRepository;
            _transProjectRepository=transProjectRepository;
            _transPeriodRepository=transPeriodRepository;
            _transIndicatorTypeRepository=transIndicatorTypeRepository;
            _sysSystemAuditRepository=sysSystemAuditRepository;
            _strucDirStaffMappingRepository=strucDirStaffMappingRepository;
            _strucDivStaffMappingRepository=strucDivStaffMappingRepository;
            _strucDirectorRepository=strucDirectorRepository;
            _strucDirectorOICRepository=strucDirectorOICRepository;
            _strucDivHeadRepository=strucDivHeadRepository;
            _strucDivHeadOICRepository=strucDivHeadOICRepository;
            _emailSender=emailSender;

            //workplans
            _wpDispatchCycleRepository=wpDispatchCycleRepository;
            _wpMainRecordRepository=wpMainRecordRepository;
            _wpOutcomesRepository=wpOutcomesRepository;
            _wpMTPRepository=wpMTPRepository;
            _wpAUDAPriorityRepository=wpAUDAPriorityRepository;
            _wpApprovalStatusRepository=wpApprovalStatusRepository;
            _wpRegionScopeRepository=wpRegionScopeRepository;
            _wpCountryScopeRepository=wpCountryScopeRepository;
            _wpOutputsRepository=wpOutputsRepository;
            _wpOutputIndicatorsRepository=wpOutputIndicatorsRepository;
            _wpOutputActivitiesRepository=wpOutputActivitiesRepository;
            _wpSAPLinkRepository=wpSAPLinkRepository;
            _wpOutputBudgetRepository=wpOutputBudgetRepository;
            _wpOutputActivityCountriesRepository=wpOutputActivityCountriesRepository;
      



            _context = context;
            
        }
        
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

            if (await userManager.IsInRoleAsync(user, "PIPD"))
                emp_view.PIPD=true;
            else if (await userManager.IsInRoleAsync(user, "Procurement"))
                emp_view.Procurement=true;
            else if (await userManager.IsInRoleAsync(user, "Travel"))
                emp_view.Travel=true;
            else if (await userManager.IsInRoleAsync(user, "Division Head"))
                emp_view.Division_Head=true;
            else if (await userManager.IsInRoleAsync(user, "Director"))
                emp_view.Director=true;
            else if (await userManager.IsInRoleAsync(user, "CEO"))
                emp_view.CEO=true;
            

            return View(emp_view);
        }

        public async Task<ActionResult> Workplan()
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
                ExistingPhotoPath = employee.PhotoPath,
                CurrentYear=DateTime.Now.Year.ToString(),
                DirectorateName=_strucDirectorateRepository.GetRecord(_strucDirStaffMappingRepository.GetRecordByEmployeeAndPrimaryDirectorate(employee.Id).Directorate_Id).Record_Name

            };

            Struc_DivStaffMapping chkrec=_strucDivStaffMappingRepository.GetRecordByEmployeeAndPrimaryDivision(employee.Id);

            if (chkrec==null)
            {
                return RedirectToAction("systemmessage", "nepadstaff");
            }

            if (await userManager.IsInRoleAsync(user, "PIPD"))
                emp_view.PIPD=true;
            else if (await userManager.IsInRoleAsync(user, "Procurement"))
                emp_view.Procurement=true;
            else if (await userManager.IsInRoleAsync(user, "Travel"))
                emp_view.Travel=true;
            else if (await userManager.IsInRoleAsync(user, "Division Head"))
                emp_view.Division_Head=true;
            else if (await userManager.IsInRoleAsync(user, "Director"))
                emp_view.Director=true;
            else if (await userManager.IsInRoleAsync(user, "CEO"))
                emp_view.CEO=true;

            return View(emp_view);

        }

        public async Task<ActionResult> SystemMessage()
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
                ExistingPhotoPath = employee.PhotoPath,
                SystemMessageContent="You have not been assigned to any division or department on this system. Please contact PIPD."

            };

            if (await userManager.IsInRoleAsync(user, "PIPD"))
                emp_view.PIPD=true;
            else if (await userManager.IsInRoleAsync(user, "Procurement"))
                emp_view.Procurement=true;
            else if (await userManager.IsInRoleAsync(user, "Travel"))
                emp_view.Travel=true;
            else if (await userManager.IsInRoleAsync(user, "Division Head"))
                emp_view.Division_Head=true;
            else if (await userManager.IsInRoleAsync(user, "Director"))
                emp_view.Director=true;
            else if (await userManager.IsInRoleAsync(user, "CEO"))
                emp_view.CEO=true;
            return View(emp_view);

        }


        public async Task<ActionResult> ManageWorkplansDraft(string divid, string progid, string projid, string yearid, string periodid)
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
            WP_MainRecord wp_mainrec_check=_wpMainRecordRepository.GetRecordByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(yearid), Int32.Parse(periodid));
            bool continentalstatus;

            if(wp_mainrec_check!=null)
            {
                if(wp_mainrec_check.ContinentalCoverage==true)
                    continentalstatus=true;
                else
                    continentalstatus=false;

            }
            else
            {
                continentalstatus=false;
            }

            // DateTime test = new DateTime(employee.DOB.Year, employee.DOB.Month, employee.DOB.Day);
            EmployeeViewModel emp_view = new EmployeeViewModel
            {
                Id = employee.Id,
                IdentityUserId = employee.IdentityUserId,
                Staff_Number = employee.Staff_Number,
                Employee_Id=employee.Id,
                Address_Street = employee.Address_Street,
                Address_City = employee.Address_City,
                Address_PostCode = employee.Address_PostCode,
                Address_State = employee.Address_State,
                RankStep = employee.RankStep,
                Country = employee.Country,
                //Directorate_Id = employee.Directorate_Id,
                Department_Id = employee.Department_Id,
                // DOB=employee.DOB,
                DOB = new DateTime(employee.DOB.Year, employee.DOB.Month, employee.DOB.Day),
                Email = employee.Email,
                First_Name = employee.First_Name,
                Last_Name = employee.Last_Name,
                Gender = employee.Gender,
                PhotoPath = profilepicpath,
                Rank = employee.Rank,
                ExistingPhotoPath = employee.PhotoPath,
                DirectorateName=_strucDirectorateRepository.GetRecord(_strucDirStaffMappingRepository.GetRecordByEmployeeAndPrimaryDirectorate(employee.Id).Directorate_Id).Record_Name,
                Directorate_Id=_strucDirStaffMappingRepository.GetRecordByEmployeeAndPrimaryDirectorate(employee.Id).Directorate_Id,
                Division_Name=_strucDivisionRepository.GetRecord(Int32.Parse(divid)).Record_Name,
                Division_Id=Int32.Parse(divid),
                Programme_Name=_lkupProgrammeRepository.GetRecord(Int32.Parse(progid)).Record_Name,
                Programme_Id=Int32.Parse(progid),
                Project_Name=_lkupProjectRepository.GetRecord(Int32.Parse(projid)).Record_Name,
                Project_Id=Int32.Parse(projid),
                FisYear=_lkupFiscalYearRepository.GetRecord(Int32.Parse(yearid)).Record_Name,
                FisPeriod=_lkupPeriodRepository.GetRecord(Int32.Parse(periodid)).Record_Name,
                FYear=Int32.Parse(yearid),
                FPeriod=Int32.Parse(periodid),
                ContinentalCoverage=continentalstatus
              


            };


            if (await userManager.IsInRoleAsync(user, "PIPD"))
                emp_view.PIPD=true;
            else if (await userManager.IsInRoleAsync(user, "Procurement"))
                emp_view.Procurement=true;
            else if (await userManager.IsInRoleAsync(user, "Travel"))
                emp_view.Travel=true;
            else if (await userManager.IsInRoleAsync(user, "Division Head"))
                emp_view.Division_Head=true;
            else if (await userManager.IsInRoleAsync(user, "Director"))
                emp_view.Director=true;
            else if (await userManager.IsInRoleAsync(user, "CEO"))
                emp_view.CEO=true;

            WP_MainRecord wp_mainrec=_wpMainRecordRepository.GetRecordByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(yearid), Int32.Parse(periodid));

            if(wp_mainrec!=null)
                emp_view.WPMainRecordId=wp_mainrec.Transaction_Id;
            else
                emp_view.WPMainRecordId="";

            //Selected Country Scope Read
            List<DropDownListViewModel> collection_recs = new List<DropDownListViewModel>();

            var DB_Recs =  _wpCountryScopeRepository.GetRecordsByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(yearid), Int32.Parse(periodid));

            int _count =  DB_Recs.Count();

            if (_count > 0)
            {
                foreach (var rec in DB_Recs)
                {
   
                    DropDownListViewModel srec = new DropDownListViewModel
                    {
                        DropDown_IntId=rec.Country_Id,
                        DropDown_Name=_lkupCountryRepository.GetCountry(rec.Country_Id).Country_Name
                    };

                    collection_recs.Add(srec);
                }
            }

            emp_view.SelectedCountries=collection_recs;


            //Selected REC Scope Read
            List<DropDownListViewModel> collection_records = new List<DropDownListViewModel>();
            var DB_Records =  _wpRegionScopeRepository.GetRecordsByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(yearid), Int32.Parse(periodid));
            int _countrec =  DB_Records.Count();

            if (_countrec > 0)
            {
                foreach (var rec in DB_Records)
                {
   
                    DropDownListViewModel srec = new DropDownListViewModel
                    {
                        DropDown_IntId=rec.Region_Id,
                        DropDown_Name=_lkupRegionScopeRepository.GetRecord(rec.Region_Id).Record_Name
                    };

                    collection_records.Add(srec);
                }
            }

            emp_view.SelectedRECs=collection_records;


            return View(emp_view);

        }

        public async Task<ActionResult> WorkplanCycle()
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

            if (await userManager.IsInRoleAsync(user, "PIPD"))
                emp_view.PIPD=true;
            else if (await userManager.IsInRoleAsync(user, "Procurement"))
                emp_view.Procurement=true;
            else if (await userManager.IsInRoleAsync(user, "Travel"))
                emp_view.Travel=true;
            else if (await userManager.IsInRoleAsync(user, "Division Head"))
                emp_view.Division_Head=true;
            else if (await userManager.IsInRoleAsync(user, "Director"))
                emp_view.Director=true;
            else if (await userManager.IsInRoleAsync(user, "CEO"))
                emp_view.CEO=true;
            

            return View(emp_view);
        }

        public async Task<ActionResult> MtpPriortyMapping()
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

            if (await userManager.IsInRoleAsync(user, "PIPD"))
                emp_view.PIPD=true;
            else if (await userManager.IsInRoleAsync(user, "Procurement"))
                emp_view.Procurement=true;
            else if (await userManager.IsInRoleAsync(user, "Travel"))
                emp_view.Travel=true;
            else if (await userManager.IsInRoleAsync(user, "Division Head"))
                emp_view.Division_Head=true;
            else if (await userManager.IsInRoleAsync(user, "Director"))
                emp_view.Director=true;
            else if (await userManager.IsInRoleAsync(user, "CEO"))
                emp_view.CEO=true;
            

            return View(emp_view);
        }

        //Partial Window Loads
        public async Task<ActionResult> AddWorkplanCycle()
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            WorkplansViewModel model = new WorkplansViewModel
            {
                Employee_Id=user.Employee_Id
            };

            return PartialView("_AddWorkplanCycle", model);
        }

        public async Task<ActionResult> EditWorkplanCycle(string transid)
        {
            WP_DispatchCycle rec = _wpDispatchCycleRepository.GetRecord(transid);
            var user = await userManager.GetUserAsync(HttpContext.User);
            WorkplansViewModel model = new WorkplansViewModel
            {
                Transaction_Id=rec.Transaction_Id,
                Employee_Id = user.Employee_Id,
                FYearIdent=rec.FiscalYear_Id,
                FPeriodIdent =rec.Period_Id,
                FisYear=_lkupFiscalYearRepository.GetRecord(rec.FiscalYear_Id).Record_Name,
                FisPeriod=_lkupPeriodRepository.GetRecord(rec.Period_Id).Record_Name
            };

            if( rec.Dispatch_Status==null)
                model.WPStatus=false;
            else
                model.WPStatus=rec.Dispatch_Status.Value;

            if( rec.LinkToSAPExecution==null)
                model.WPSAPLinkView=false;
            else
                model.WPSAPLinkView=rec.LinkToSAPExecution.Value;

            return PartialView("_EditWorkplanCycle", model);
        }


        public async Task<ActionResult> AddSAPLinkage(string transid)
        {
            WP_DispatchCycle rec = _wpDispatchCycleRepository.GetRecord(transid);
            var user = await userManager.GetUserAsync(HttpContext.User);
            WorkplansViewModel model = new WorkplansViewModel
            {
                WPDispatchCycle_Ident=rec.Transaction_Id,
                Employee_Id = user.Employee_Id,
                FYearIdent=rec.FiscalYear_Id,
                FPeriodIdent =rec.Period_Id,
                FisYear=_lkupFiscalYearRepository.GetRecord(rec.FiscalYear_Id).Record_Name,
                FisPeriod=_lkupPeriodRepository.GetRecord(rec.Period_Id).Record_Name
            };

            if( rec.Dispatch_Status==null)
                model.WPStatus=false;
            else
                model.WPStatus=rec.Dispatch_Status.Value;

            if( rec.LinkToSAPExecution==null)
                model.WPSAPLinkView=false;
            else
                model.WPSAPLinkView=rec.LinkToSAPExecution.Value;

            return PartialView("_AddSAPLinkage", model);
        }


        public async Task<ActionResult> AddOutputIndicator(string transid)
        {
            WP_Outputs rec = _wpOutputsRepository.GetRecord(transid);
            var user = await userManager.GetUserAsync(HttpContext.User);
            
            WP_OutputIndicatorsVM model = new WP_OutputIndicatorsVM
            {
                Transaction_IdOIVM=rec.Transaction_Id,
                WPMainRecord_idOIVM=rec.WPMainRecord_id,
                Employee_IdOIVM = user.Employee_Id,
                FiscalYear_IdOIVM=rec.FiscalYear_Id,
                Period_IdOIVM =rec.Period_Id,
                Project_IdOIVM=rec.Project_Id,
                FisYearOIVM=_lkupFiscalYearRepository.GetRecord(rec.FiscalYear_Id).Record_Name,
                FisPeriodOIVM=_lkupPeriodRepository.GetRecord(rec.Period_Id).Record_Name

            };



            return PartialView("_AddOutputIndicator", model);
        }


        public async Task<ActionResult> AddOutputActivity(string transid)
        {
            WP_Outputs rec = _wpOutputsRepository.GetRecord(transid);
            var user = await userManager.GetUserAsync(HttpContext.User);
            
            WP_OutputActivitiesVM model = new WP_OutputActivitiesVM
            {
                Transaction_IdOAVMMain=rec.Transaction_Id,
                WPMainRecord_idOAVMMain=rec.WPMainRecord_id,
                Employee_IdOAVMMain = user.Employee_Id,
                FiscalYear_IdOAVMMain=rec.FiscalYear_Id,
                Period_IdOAVMMain =rec.Period_Id,
                Project_IdOAVMMain=rec.Project_Id,
                FisYearOAVMMain=_lkupFiscalYearRepository.GetRecord(rec.FiscalYear_Id).Record_Name,
                FisPeriodOAVMMain=_lkupPeriodRepository.GetRecord(rec.Period_Id).Record_Name

            };



            return PartialView("_AddOutputActivity", model);
        }


        public async Task<ActionResult> EditOutputActivity(string transid)
        {
           // WP_Outputs rec = _wpOutputsRepository.GetRecord(transid);

            WP_OutputActivities rec=_wpOutputActivitiesRepository.GetRecord(transid);
            var user = await userManager.GetUserAsync(HttpContext.User);
            
            WP_OutputActivitiesVM model = new WP_OutputActivitiesVM
            {
                Transaction_IdOAVMMain=rec.Transaction_Id,
                WPMainRecord_idOAVMMain=rec.WPMainRecord_id,
                Employee_IdOAVMMain = user.Employee_Id,
                FiscalYear_IdOAVMMain=rec.FiscalYear_Id,
                Period_IdOAVMMain =rec.Period_Id,
                Project_IdOAVMMain=rec.Project_Id,
                ActivityType_IdOAVMMain=rec.ActivityType_Id,
                ActivityDescriptionOAVMMain=rec.ActivityDescription,
                ActivityCostOAVMMain=rec.ActivityCost,
                ActivityStartDateOAVMMain=new DateTime(rec.ActivityStartDate.Year, rec.ActivityStartDate.Month, rec.ActivityStartDate.Day),
                ActivityEndDateOAVMMain=new DateTime(rec.ActivityEndDate.Year, rec.ActivityEndDate.Month, rec.ActivityEndDate.Day),
                ImplementationType_IdOAVMMain=rec.ImplementationType_Id,
                BaselineTechnicalOAVMMain=rec.BaselineTechnical,
                BaselineFinancialOAVMMain=rec.BaselineFinancial,
                FisYearOAVMMain=_lkupFiscalYearRepository.GetRecord(rec.FiscalYear_Id).Record_Name,
                FisPeriodOAVMMain=_lkupPeriodRepository.GetRecord(rec.Period_Id).Record_Name

            };



            return PartialView("_EditOutputActivity", model);
        }

        public async Task<ActionResult> ManageOutputBudgetLink(string projid, string fyear, string fperiod, string mainrecordid,  string outputid)
        {
           // WP_Outputs rec = _wpOutputsRepository.GetRecord(transid);
            var user = await userManager.GetUserAsync(HttpContext.User);

            WP_OutputBudget wpoutputbudget_recfetch=_wpOutputBudgetRepository.GetRecordsByProjectYearPeriodAndOutputId(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod), outputid);
           
            WP_MainRecord mainrec=_wpMainRecordRepository.GetRecord(mainrecordid);
            WP_DispatchCycle wpcycle=_wpDispatchCycleRepository.GetRecordByYearAndPeriod(mainrec.FiscalYear_Id, mainrec.Period_Id);
           
            WP_OutputBudgetVM model = new WP_OutputBudgetVM();
            if(wpoutputbudget_recfetch!=null)
            {
                    model.Transaction_IdOBVM=wpoutputbudget_recfetch.Transaction_Id;
                    model.WPMainRecord_idOBVM=wpoutputbudget_recfetch.WPMainRecord_id;
                    model.Employee_IdOBVM = user.Employee_Id;
                    model.Project_IdOBVM=wpoutputbudget_recfetch.Project_Id;
                    model.FiscalYear_IdOBVM=wpoutputbudget_recfetch.FiscalYear_Id;
                    model.Period_IdOBVM=wpoutputbudget_recfetch.Period_Id;
                    model.WPOutput_IdOBVM=wpoutputbudget_recfetch.WPOutput_Id;
                    model.Output_BudgetAmountOBVM=wpoutputbudget_recfetch.Output_BudgetAmount;
                    model.WPSAPLink_IdOBVM=wpoutputbudget_recfetch.WPSAPLink_Id;
                    //model.WPSAPBudget_WBSOBVM=_wpSAPLinkRepository.GetRecord(wpoutputbudget_recfetch.WPSAPLink_Id).SAP_WBS;
                    model.UtilizationPercentageOBVM=wpoutputbudget_recfetch.UtilizationPercentage;

                    if(mainrec.LinkToSAPExecution==true)
                    {
                        model.LinkToSAPExecution=true;
                        model.LinkToSAPExecutionString="true";
                    }
                    else
                    {
                        model.LinkToSAPExecution=false;
                        model.LinkToSAPExecutionString="false";
                    }
 
            }
            else
            {
                    model.Transaction_IdOBVM="";
                    model.WPMainRecord_idOBVM=mainrecordid;
                    model.Employee_IdOBVM = user.Employee_Id;
                    model.Project_IdOBVM=Int32.Parse(projid);
                    model.FiscalYear_IdOBVM=Int32.Parse(fyear);
                    model.Period_IdOBVM=Int32.Parse(fperiod);
                    model.WPOutput_IdOBVM=outputid;
                    model.Output_BudgetAmountOBVM=0;
                    model.WPSAPLink_IdOBVM="";
                    model.WPSAPBudget_WBSOBVM="";
                    model.UtilizationPercentageOBVM=0;

                    if(mainrec.LinkToSAPExecution==true)
                    {
                        model.LinkToSAPExecution=true;
                        model.LinkToSAPExecutionString="true";
                    }
                    else
                    {
                        model.LinkToSAPExecution=false;
                        model.LinkToSAPExecutionString="false";
                    }

            }



            return PartialView("_ManageOutputBudgetLink", model);
        }

        
    }
}