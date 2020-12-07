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
using System.Threading;
using iText.IO.Image;
using iText.IO.Font;
using iText.IO.Font.Constants;
using iText.Kernel.Colors;
using iText.Kernel.Events;
using iText.Kernel.Pdf;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf.Action;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Kernel.Pdf.Canvas;
//using iText.Kernel
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Borders;
using iText.Layout.Properties;

using iText.Barcodes;


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
        private readonly ILkUp_MobilityLimitsRepository _lkupMobilityLimitsRepository ;
        private readonly IStrategy_PriorityRepository _strategyPriorityRepository ;
        private readonly IStrategy_MTPRepository _strategyMTPRepository;
        private readonly IStrategy_MTPPriorityMappingRepository _strategyMTPPriorityMappingRepository ;
        private readonly IStrategy_KeyPerformanceAreaRepository _strategyKeyPerformanceAreaRepository;
        private readonly IStrategy_OutputIndicatorsRepository _strategyOutputIndicatorsRepository ;
        private readonly IStrategy_OutputIndicatorsPriorityMappingRepository _strategyOutputIndicatorsPriorityMappingRepository;
        private readonly IStruc_DirectorateRepository _strucDirectorateRepository ;
        private readonly IStruc_DivisionRepository _strucDivisionRepository;
        private readonly IStruc_DirDivIndicatorsRepository _strucDirDivIndicatorsRepository;
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
        private readonly ITrans_MobilityLimitsRepository _transMobilityLimitsRepository ;
        private readonly ITrans_StrategyPriorityRepository _transStrategyPriorityRepository ;
        private readonly ITrans_StrategyMTPRepository _transStrategyMTPRepository ;
        private readonly ITrans_StrategyKeyPerformanceAreaRepository _transStrategyKeyPerformanceAreaRepository  ;
        private readonly ITrans_StrategyOutputIndicators _transStrategyOutputIndicators  ;
        private readonly ITrans_StrucDirectorateRepository _transStrucDirectorateRepository  ;
        private readonly ITrans_StrucDivisionRepository _transStrucDivisionRepository  ;
        private readonly ITrans_StrucDirDivIndicatorsRepository _transStrucDirDivIndicatorsRepository  ;
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
        private readonly IWP_OutcomeIndicatorsRepository _wpOutcomeIndicatorsRepository ;
        private readonly IWP_OutputIndicatorsRepository _wpOutputIndicatorsRepository ;
        private readonly IWP_OutputActivitiesRepository _wpOutputActivitiesRepository ;
        private readonly IWP_SAPLinkRepository _wpSAPLinkRepository  ;
        private readonly IWP_OutputBudgetRepository _wpOutputBudgetRepository ;
        private readonly IWP_OutputActivityCountriesRepository _wpOutputActivityCountriesRepository;
        private readonly IWP_MobilityRepository _wpMobilityRepository;
        private readonly IWP_MobilityInternalTeamRepository _wpMobilityInternalTeamRepository;
        private readonly IWP_MobilityExternalTeamRepository _wpMobilityExternalTeamRepository;
        private readonly IWP_MobilityLimitRepository _wpMobilityLimitRepository;
        private readonly IWP_BarCodeIdentsRepository _wpBarCodeIdentsRepository;
        private readonly IWP_CommunicationRepository _wpCommunicationRepository;
        private readonly IWP_PRCBudgetLimitsRepository _wpPRCBudgetLimitsRepository;
        private readonly IWP_ProcurementRepository _wpProcurementRepository;
        private readonly IWP_RiskProfileRepository _wpRiskProfileRepository;
        private readonly IWP_RiskProfileCountriesRepository _wpRiskProfileCountriesRepository;



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
                                ILkUp_MobilityLimitsRepository lkupMobilityLimitsRepository ,
                                IStrategy_PriorityRepository strategyPriorityRepository,
                                IStrategy_MTPRepository strategyMTPRepository,
                                IStrategy_MTPPriorityMappingRepository strategyMTPPriorityMappingRepository,
                                IStrategy_KeyPerformanceAreaRepository strategyKeyPerformanceAreaRepository,
                                IStrategy_OutputIndicatorsRepository strategyOutputIndicatorsRepository,
                                IStrategy_OutputIndicatorsPriorityMappingRepository strategyOutputIndicatorsPriorityMappingRepository,
                                IStruc_DirectorateRepository strucDirectorateRepository,
                                IStruc_DivisionRepository strucDivisionRepository,
                                IStruc_DirDivIndicatorsRepository strucDirDivIndicatorsRepository,
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
                                ITrans_MobilityLimitsRepository transMobilityLimitsRepository,
                                ITrans_StrategyPriorityRepository transStrategyPriorityRepository,
                                ITrans_StrategyMTPRepository transStrategyMTPRepository,
                                ITrans_StrategyKeyPerformanceAreaRepository transStrategyKeyPerformanceAreaRepository,
                                ITrans_StrategyOutputIndicators transStrategyOutputIndicators,
                                ITrans_StrucDirectorateRepository transStrucDirectorateRepository,
                                ITrans_StrucDivisionRepository transStrucDivisionRepository,   
                                ITrans_StrucDirDivIndicatorsRepository transStrucDirDivIndicatorsRepository ,
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
                                IWP_OutcomeIndicatorsRepository wpOutcomeIndicatorsRepository,
                                IWP_OutputIndicatorsRepository wpOutputIndicatorsRepository,
                                IWP_OutputActivitiesRepository wpOutputActivitiesRepository,
                                IWP_SAPLinkRepository wpSAPLinkRepository,
                                IWP_OutputBudgetRepository wpOutputBudgetRepository,
                                IWP_OutputActivityCountriesRepository wpOutputActivityCountriesRepository,
                                IWP_MobilityRepository wpMobilityRepository,
                                IWP_MobilityInternalTeamRepository wpMobilityInternalTeamRepository,
                                IWP_MobilityExternalTeamRepository wpMobilityExternalTeamRepository,
                                IWP_MobilityLimitRepository wpMobilityLimitRepository,
                                IWP_BarCodeIdentsRepository wpBarCodeIdentsRepository,
                                IWP_CommunicationRepository wpCommunicationRepository,
                                IWP_PRCBudgetLimitsRepository wpPRCBudgetLimitsRepository,
                                IWP_ProcurementRepository wpProcurementRepository,
                                IWP_RiskProfileRepository wpRiskProfileRepository,
                                IWP_RiskProfileCountriesRepository wpRiskProfileCountriesRepository)
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
            _lkupMobilityLimitsRepository=lkupMobilityLimitsRepository;
            _strategyPriorityRepository=strategyPriorityRepository;
            _strategyMTPRepository=strategyMTPRepository;
            _strategyMTPPriorityMappingRepository=strategyMTPPriorityMappingRepository;
            _strategyKeyPerformanceAreaRepository=strategyKeyPerformanceAreaRepository;
            _strategyOutputIndicatorsRepository=strategyOutputIndicatorsRepository;
            _strategyOutputIndicatorsPriorityMappingRepository=strategyOutputIndicatorsPriorityMappingRepository;
            _strucDirectorateRepository=strucDirectorateRepository;
            _strucDivisionRepository=strucDivisionRepository;
            _strucDirDivIndicatorsRepository=strucDirDivIndicatorsRepository;


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
            _transMobilityLimitsRepository= transMobilityLimitsRepository;
            _transStrategyPriorityRepository=transStrategyPriorityRepository;
            _transStrategyMTPRepository=transStrategyMTPRepository;
            _transStrategyKeyPerformanceAreaRepository=transStrategyKeyPerformanceAreaRepository;
            _transStrategyOutputIndicators=transStrategyOutputIndicators;
            _transStrucDirectorateRepository=transStrucDirectorateRepository;
            _transStrucDivisionRepository=transStrucDivisionRepository;
            _transStrucDirDivIndicatorsRepository=transStrucDirDivIndicatorsRepository;
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
            _wpOutcomeIndicatorsRepository=wpOutcomeIndicatorsRepository;
            _wpOutputIndicatorsRepository=wpOutputIndicatorsRepository;
            _wpOutputActivitiesRepository=wpOutputActivitiesRepository;
            _wpSAPLinkRepository=wpSAPLinkRepository;
            _wpOutputBudgetRepository=wpOutputBudgetRepository;
            _wpOutputActivityCountriesRepository=wpOutputActivityCountriesRepository;
            _wpMobilityRepository=wpMobilityRepository;
            _wpMobilityInternalTeamRepository=wpMobilityInternalTeamRepository;
            _wpMobilityExternalTeamRepository=wpMobilityExternalTeamRepository;
            _wpMobilityLimitRepository=wpMobilityLimitRepository;
            _wpBarCodeIdentsRepository=wpBarCodeIdentsRepository;
            _wpCommunicationRepository=wpCommunicationRepository;
            _wpPRCBudgetLimitsRepository=wpPRCBudgetLimitsRepository;
            _wpProcurementRepository=wpProcurementRepository;
            _wpRiskProfileRepository=wpRiskProfileRepository;
            _wpRiskProfileCountriesRepository=wpRiskProfileCountriesRepository;
        



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
                Directorate_Ident=_strucDirStaffMappingRepository.GetRecordByEmployeeAndPrimaryDirectorate(employee.Id).Directorate_Id,
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


        public async Task<ActionResult> InstitutionalWorkplanDraft(string transid)
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
                Directorate_Ident=_strucDirStaffMappingRepository.GetRecordByEmployeeAndPrimaryDirectorate(employee.Id).Directorate_Id,
                Department_Id = employee.Department_Id,
                // DOB=employee.DOB,
                DOB = new DateTime(employee.DOB.Year, employee.DOB.Month, employee.DOB.Day),
                Email = employee.Email,
                First_Name = employee.First_Name,
                Last_Name = employee.Last_Name,
                Gender = employee.Gender,
                PhotoPath = profilepicpath,
                Rank = employee.Rank,
                DispatchCycle_Id=transid,
                ExistingPhotoPath = employee.PhotoPath,
                CurrentYear=DateTime.Now.Year.ToString(),
               // PRCThresold_Max=3.0, 
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


            WP_DispatchCycle currentcyclerec=_wpDispatchCycleRepository.GetRecord(transid);

            var DB_Records = _transStrucDirectorateRepository.GetAllRecords().ToList();

            int _countrecs =  DB_Records.Count();

            double maxprc=0.0;
            double maxproj=0;
          

            if(_countrecs>0)
            {
                foreach (var rec_set in DB_Records)
                {
                    double directorate_total_budget=0;
                    double directoratemaxproj=0;
                    //double directorate_total_prcthreshold=0;
                    var DB_RecordsDivs=_transStrucDivisionRepository.GetAllRecordsByDirectorate(rec_set.Transaction_Id).ToList();
                
                    foreach (var rec_div in DB_RecordsDivs)
                    {
                        var DivMainRecs=_wpMainRecordRepository.GetRecordsByDivRecs(rec_div.Division_Id).ToList();
                        

                        //Fetch the Division Records that correspond the cycle 
                        if(currentcyclerec.Period_Id==8)
                        {
                            DivMainRecs=_wpMainRecordRepository.GetRecordsByDivisionYearAndPeriodStartEnd(rec_div.Division_Id, currentcyclerec.FiscalYear_Id,currentcyclerec.Period_Id, currentcyclerec.PeriodStartDate, currentcyclerec.PeriodEndDate).ToList();
                        }
                        else
                        {
                            DivMainRecs=_wpMainRecordRepository.GetRecordsByDivisionYearAndPeriod(rec_div.Division_Id, currentcyclerec.FiscalYear_Id,currentcyclerec.Period_Id).ToList();
                        }
                        directoratemaxproj=directoratemaxproj+DivMainRecs.Count();


                        foreach (var rec_proj_main in DivMainRecs)
                        { 
                            var DB_ActivitiesRecs=_wpOutputActivitiesRepository.GetRecordsByMainRecordId(rec_proj_main.Transaction_Id).ToList();
                            foreach (var rec_proj_act in DB_ActivitiesRecs)
                            {
                                directorate_total_budget=directorate_total_budget+rec_proj_act.ActivityCost;
                            }

                        }


                    }
                    if(directorate_total_budget>maxprc)
                        maxprc=directorate_total_budget;


                    //Now Check PRC Threshold Max  directorate_total_prcthreshold
                    WP_PRCBudgetLimits prccyclelimit=_wpPRCBudgetLimitsRepository.GetRecordByDirectorateAndCycle(rec_set.Record_Id,currentcyclerec.Transaction_Id);

                  //  directorate_total_prcthreshold=directorate_total_prcthreshold+(prccyclelimit.MS_Limit+prccyclelimit.DP_Limit);

                    if(prccyclelimit.MS_Limit>maxprc)
                        maxprc=prccyclelimit.MS_Limit;

                    if(prccyclelimit.DP_Limit>maxprc)
                        maxprc=prccyclelimit.DP_Limit;

                    
                    if(directoratemaxproj>maxproj)
                        maxproj=directoratemaxproj;

                }

            }
            double rtnmaxprc=Math.Truncate(maxprc/1000000)+1.0;

            emp_view.PRCThresold_Max=rtnmaxprc;
            emp_view.FisYear=_lkupFiscalYearRepository.GetRecord(currentcyclerec.FiscalYear_Id).Record_Name;

            emp_view.Project_Max=maxproj;
            



            string periodname="";
            
            if(currentcyclerec.Period_Id==8)
            {
                DateTime pstart=new DateTime(currentcyclerec.PeriodStartDate.Year, currentcyclerec.PeriodStartDate.Month, currentcyclerec.PeriodStartDate.Day);
                DateTime pend=new DateTime(currentcyclerec.PeriodEndDate.Year, currentcyclerec.PeriodEndDate.Month, currentcyclerec.PeriodEndDate.Day);
                periodname=pstart.Date.ToString("MMM d, yyyy") + " - "+ pend.Date.ToString("MMM d, yyyy"); 
            }
            else
            {
                periodname=_lkupPeriodRepository.GetRecord(currentcyclerec.Period_Id).Record_Name;
            }
            emp_view.FisPeriod=periodname;

            return View(emp_view);

        }

        public async Task<ActionResult> WorkplanDraftList()
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
                Directorate_Ident=_strucDirStaffMappingRepository.GetRecordByEmployeeAndPrimaryDirectorate(employee.Id).Directorate_Id,
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

        public async Task<ActionResult> DivisionKPIs()
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
        public async Task<ActionResult> WorkplanGanttChart(string mainrecid, string divid, string progid, string projid, string yearid, string periodid, string periodtxt)
        {

            var user = await userManager.GetUserAsync(HttpContext.User);

            string profilepicpath = "";
            WP_MainRecord wp_mainrec_check=null;

            if(mainrecid==null)
            {
                if(Int32.Parse(periodid)==8)
                {
                    var DB_Records8 =  _wpMainRecordRepository.GetRecordsByProjectYearAndPeriodRecs(Int32.Parse(projid), Int32.Parse(yearid), Int32.Parse(periodid));

                    int _countrecs =  DB_Records8.Count();
                    if(_countrecs>0)
                    {
                        foreach (var rec in DB_Records8)
                        {
                            DateTime pstart=new DateTime(rec.PeriodStartDate.Year, rec.PeriodStartDate.Month, rec.PeriodStartDate.Day);
                            DateTime pend=new DateTime(rec.PeriodEndDate.Year, rec.PeriodEndDate.Month, rec.PeriodEndDate.Day);
                            string periodinmain=pstart.Date.ToString("MMMM dd, yyyy") + " - "+ pend.Date.ToString("MMMM dd, yyyy"); 

                            if(periodinmain==periodtxt)
                            wp_mainrec_check=rec;
                        }
                    }

                }
                else
                {
                    wp_mainrec_check=_wpMainRecordRepository.GetRecordByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(yearid), Int32.Parse(periodid));
                }

            }
            else
            {
                wp_mainrec_check=_wpMainRecordRepository.GetRecord(mainrecid);

            }



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
                WPMainRecordId=wp_mainrec_check.Transaction_Id,
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

        public async Task<ActionResult> WorkplanDraftActivityPDF(string mainrecid, string divid, string progid, string projid, string yearid, string periodid, string periodtxt)
        {

            var user = await userManager.GetUserAsync(HttpContext.User);

            string profilepicpath = "";

            WP_MainRecord wp_mainrec_check=null;

            if(mainrecid==null)
            {
                if(Int32.Parse(periodid)==8)
                {
                    var DB_Records8 =  _wpMainRecordRepository.GetRecordsByProjectYearAndPeriodRecs(Int32.Parse(projid), Int32.Parse(yearid), Int32.Parse(periodid));

                    int _countrecs =  DB_Records8.Count();
                    if(_countrecs>0)
                    {
                        foreach (var rec in DB_Records8)
                        {
                            DateTime pstart=new DateTime(rec.PeriodStartDate.Year, rec.PeriodStartDate.Month, rec.PeriodStartDate.Day);
                            DateTime pend=new DateTime(rec.PeriodEndDate.Year, rec.PeriodEndDate.Month, rec.PeriodEndDate.Day);
                            string periodinmain=pstart.Date.ToString("MMMM dd, yyyy") + " - "+ pend.Date.ToString("MMMM dd, yyyy"); 

                            if(periodinmain==periodtxt)
                            wp_mainrec_check=rec;
                        }
                    }

                }
                else
                {
                    wp_mainrec_check=_wpMainRecordRepository.GetRecordByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(yearid), Int32.Parse(periodid));
                }

            }
            else
            {
                wp_mainrec_check=_wpMainRecordRepository.GetRecord(mainrecid);

            }

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
                WPMainRecordId=wp_mainrec_check.Transaction_Id,
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



        public async Task<ActionResult> InstitutionalWorkplanDraftPDF(string cycleid)
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
                DispatchCycle_Id=cycleid,
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


        public FileResult WorkplanActivityReportPDF(string id)
        {

            string contentType = "application/pdf";
            WP_MainRecord mainrec=_wpMainRecordRepository.GetRecord(id);

            MemoryStream workStream=GetMemoryStreamActivityPlan(mainrec);

            byte[] byte1 = workStream.ToArray();

            return File(byte1, contentType, _lkupProjectRepository.GetRecord(mainrec.Project_Id).Record_Name + "_" 
                                            + _lkupFiscalYearRepository.GetRecord(mainrec.FiscalYear_Id).Record_Name +"_"+ 
                                            _lkupPeriodRepository.GetRecord(mainrec.Period_Id).Record_Name+".pdf");

        }
        public string RandomDigits(int length)
        {
            var random = new Random();
            string s = string.Empty;
            for (int i = 0; i < length; i++)
                s = String.Concat(s, random.Next(10).ToString());
            return s;
        }
        public MemoryStream GetMemoryStreamActivityPlan(WP_MainRecord mainrec)
        {
             MemoryStream workStream = new MemoryStream();
            
            PdfWriter writer = new PdfWriter(workStream);
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf, PageSize.A3.Rotate());
            int n = pdf.GetNumberOfPages();

            pdf.AddEventHandler(PdfDocumentEvent.END_PAGE, new NEPADStaffController.MyEventHandlerA3(this));

            document.SetBottomMargin(70);

            //PdfFontFactory.Register(@"wwwroot/reports/fonts/FaktSlabPro-Blond.ttf");Montserrat-ExtraBold Montserrat-Italic Montserrat-Light Montserrat-Bold Montserrat-Medium Montserrat-Italic
                string fontpath = @"wwwroot/reports/fonts/FaktSlabPro-Blond.ttf";
                string fontpath_montserrat_medium= @"wwwroot/reports/fonts/Montserrat-Medium.ttf";
                string fontpath_montserrat_bold= @"wwwroot/reports/fonts/Montserrat-Bold.ttf";
                string fontpath_montserrat_semibold= @"wwwroot/reports/fonts/Montserrat-SemiBold.ttf";
                string fontpath_montserrat_thick= @"wwwroot/reports/fonts/Montserrat-ExtraBold.ttf";
                string fontpath_montserrat_reg= @"wwwroot/reports/fonts/Montserrat-Regular.ttf";
                string fontpath_montserrat_reg_italic= @"wwwroot/reports/fonts/Montserrat-Italic.ttf";
                string fontpath_montserrat_light= @"wwwroot/reports/fonts/Montserrat-Light.ttf";
                string fontpath_materialicons_fonts= @"wwwroot/reports/fonts/MaterialIcons-Regular.ttf";
                string fontpath_helveticaneue= @"wwwroot/reports/fonts/HelveticaNeueLt.ttf";

                PdfFont ft = PdfFontFactory.CreateFont(fontpath, PdfEncodings.WINANSI, true);
                PdfFont ft_montserrat_medium = PdfFontFactory.CreateFont(fontpath_montserrat_medium, PdfEncodings.WINANSI, true);
                PdfFont ft_montserrat_semibold = PdfFontFactory.CreateFont(fontpath_montserrat_semibold, PdfEncodings.WINANSI, true);
                PdfFont ft_montserrat_bold = PdfFontFactory.CreateFont(fontpath_montserrat_bold, PdfEncodings.WINANSI, true);
                PdfFont ft_montserrat_thick = PdfFontFactory.CreateFont(fontpath_montserrat_thick, PdfEncodings.WINANSI, true);
                PdfFont ft_montserrat_reg = PdfFontFactory.CreateFont(fontpath_montserrat_reg, PdfEncodings.WINANSI, true);
                PdfFont ft_montserrat_reg_it = PdfFontFactory.CreateFont(fontpath_montserrat_reg_italic, PdfEncodings.WINANSI, true);
                PdfFont ft_montserrat_light= PdfFontFactory.CreateFont(fontpath_montserrat_light, PdfEncodings.WINANSI, true);
                PdfFont ft_materialicons_fonts= PdfFontFactory.CreateFont(fontpath_materialicons_fonts, "Identity-H", true);
                PdfFont ft_helveticaneue= PdfFontFactory.CreateFont(fontpath_helveticaneue, PdfEncodings.WINANSI, true);
                PdfFont ft_regular = PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFonts.HELVETICA);
                PdfFont ft_bold = PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFonts.HELVETICA_BOLD);

                Color cl=new DeviceRgb(18, 50, 89);
                Color cl_lightblue=new DeviceRgb(45, 80, 122);
                Color cl_green=new DeviceRgb(5, 71, 27);
                Color cl_gray=new DeviceRgb(132, 134, 135);
                Color cl_grayD=new DeviceRgb(98, 99, 99);
                Color cl_grayDark=new DeviceRgb(51, 52, 54);
                Color cl_red=new DeviceRgb(120, 60, 62);
                Color cl_tableheaderupper=new DeviceRgb(199, 198, 197);
                Color cl_tableheader=new DeviceRgb(219, 217, 215);
                Color cl_tablecontent1=new DeviceRgb(250, 245, 240);
                Color cl_tablecontent_1=new DeviceRgb(232, 233, 235);
                Color cl_tablecontent_2=new DeviceRgb(252, 252, 252);
                Color cl_tablecontent_22=new DeviceRgb(246, 246, 246);

               

                         // Add Logo
                Image img = new Image(ImageDataFactory
                    .Create(@"wwwroot/frontpage/images/logo-dark_for_reports.png"))
                    //.SetTextAlignment(TextAlignment.CENTER)
                    .SetHorizontalAlignment(HorizontalAlignment.CENTER)
                    .SetHeight(55)
                    .SetWidth(230);
                document.Add(img);

                Paragraph txt_gap=new Paragraph(new Text("\n"));
                Paragraph txt=new Paragraph(new Text(" "))
                                .SetFixedLeading(1f);

                document.Add(txt);

               

               
                
                SolidLine line = new SolidLine(0.5f);
                line.SetColor(cl_gray);
                LineSeparator ls = new LineSeparator(line);


                DottedLine dottedline = new DottedLine(0.5f);
                dottedline.SetColor(cl_gray);
                LineSeparator ls_dotted = new LineSeparator(dottedline);

                DashedLine dashedline = new DashedLine(0.5f);
                dashedline.SetColor(cl_gray);
                LineSeparator ls_dashed= new LineSeparator(dashedline);


                Paragraph header = new Paragraph("Integrated Planning and Reporting System"+ Convert.ToChar(174))
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetFont(ft)
                    .SetFontColor(cl)
                    .SetFontSize(16);
                    
                document.Add(header);


               // document.Add(txt);

           
                Paragraph sub_header = new Paragraph("Activity Plan")
                    .SetFixedLeading(14f)
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetFont(ft_montserrat_thick)
                    
                    .SetFontColor(cl_gray)
                    .SetFontSize(14);
                document.Add(sub_header);
                document.Add(txt);




            string barcodestring="";
            if(mainrec.BarCode_Id!=null)
            {
                barcodestring=mainrec.BarCode_Id;
            }
            else
            {
                barcodestring=RandomDigits(12);
                mainrec.BarCode_Id=barcodestring;
                _wpMainRecordRepository.Update(mainrec);

            }
            
            //Bar Code
            var bar = new BarcodeInter25(pdf);
            bar.SetCode(barcodestring);
           //bar.SetCode("000600123456");
   //Computing Total Budget for Project



            //Here's how to add barcode to PDF with IText7
            var barcodeImg = new Image(bar.CreateFormXObject(pdf))
                                .SetHorizontalAlignment(HorizontalAlignment.CENTER);
            document.Add(barcodeImg);   
            //document.Add(txt);

            //Get Period Name
            string periodname="";
            if(mainrec.Period_Id==8)
            {
                DateTime pstart=new DateTime(mainrec.PeriodStartDate.Year, mainrec.PeriodStartDate.Month, mainrec.PeriodStartDate.Day);
                DateTime pend=new DateTime(mainrec.PeriodEndDate.Year, mainrec.PeriodEndDate.Month, mainrec.PeriodEndDate.Day);
                periodname=pstart.Date.ToString("MMM d, yyyy") + " - "+ pend.Date.ToString("MMM d, yyyy"); 
            }
            else
            {
                periodname=_lkupPeriodRepository.GetRecord(mainrec.Period_Id).Record_Name;
            }


            var DB_Budgets =  _wpOutputActivitiesRepository.GetRecordsByMainRecordId(mainrec.Transaction_Id).ToList();
            var DB_BudgetsMS =  _wpOutputActivitiesRepository.GetRecordsByMainRecordIdMS(mainrec.Transaction_Id).ToList();
            double totalbudget=0;
            double msbudget=0;
            double dpbudget=0;

            foreach (var budget_record in DB_Budgets)
            {
                totalbudget=totalbudget+budget_record.ActivityCost;
            }

            foreach (var budget_record in DB_BudgetsMS)
            {
                msbudget=msbudget+budget_record.ActivityCost;
            }
            dpbudget=totalbudget-msbudget;

            //document.Add(txt);
                float subtractmargins=document.GetLeftMargin()+document.GetRightMargin();
                //Table table = new Table(2, false)
                Table table = new Table(UnitValue.CreatePercentArray(new float[]{8, 92}), false)
                .SetWidth(PageSize.A3.GetHeight()-subtractmargins)
                .SetHorizontalAlignment(HorizontalAlignment.LEFT);

                //Row 1
                Cell cell11 = new Cell(1, 1)
                    .SetTextAlignment(TextAlignment.LEFT)
                    .Add(new Paragraph("Directorate ")
                                   // .SetFont(ft_montserrat_reg)
                                    .SetFixedLeading(9f)
                                    .SetFontSize(11))
                    .SetBackgroundColor(cl_tableheader)
                    .SetBorderLeft(Border.NO_BORDER)
                    .SetBorderRight(Border.NO_BORDER)
                    .SetBorderBottom(Border.NO_BORDER);
               
                  
               Cell cell12 = new Cell(1, 1)
                  .SetTextAlignment(TextAlignment.LEFT)
                  .Add(new Paragraph(_strucDirectorateRepository.GetRecord(mainrec.Directorate_Id).Record_Name)
                                .SetFont(ft_montserrat_reg)
                                .SetFixedLeading(9f)
                                .SetFontColor(cl_grayDark)
                                .SetFontSize(10))
                .SetBackgroundColor(cl_tablecontent_22)
                .SetBorderLeft(Border.NO_BORDER)
                .SetBorderRight(Border.NO_BORDER)
                .SetBorderBottom(Border.NO_BORDER);

                //Row 2
                Cell cell21 = new Cell(1, 1)
                  .SetTextAlignment(TextAlignment.LEFT)
                  .Add(new Paragraph("Division ")
                              //  .SetFont(ft_montserrat_reg)
                                .SetFixedLeading(9f)
                                .SetFontSize(11))
                .SetBackgroundColor(cl_tableheader)
                .SetBorderLeft(Border.NO_BORDER)
                .SetBorderRight(Border.NO_BORDER)
                .SetBorderTop(Border.NO_BORDER)
                .SetBorderBottom(Border.NO_BORDER);

               Cell cell22 = new Cell(1, 1)
                  .SetTextAlignment(TextAlignment.LEFT)
                  .Add(new Paragraph(_strucDivisionRepository.GetRecord(mainrec.Division_Id).Record_Name)
                                .SetFont(ft_montserrat_reg)
                                .SetFixedLeading(9f)
                                .SetFontColor(cl_grayDark)
                                .SetFontSize(10))
                .SetBackgroundColor(cl_tablecontent_22)
                .SetBorderLeft(Border.NO_BORDER)
                .SetBorderRight(Border.NO_BORDER)
                .SetBorderTop(Border.NO_BORDER)
                .SetBorderBottom(Border.NO_BORDER);

                //Row 3
                Cell cell31 = new Cell(1, 1)
                  .SetTextAlignment(TextAlignment.LEFT)
                  .Add(new Paragraph("Programme ")
                                //.SetFont(ft_montserrat_reg)
                                .SetFixedLeading(9f)
                                .SetFontSize(11))
                .SetBackgroundColor(cl_tableheader)
                .SetBorderLeft(Border.NO_BORDER)
                .SetBorderRight(Border.NO_BORDER)
                .SetBorderTop(Border.NO_BORDER)
                .SetBorderBottom(Border.NO_BORDER);

               Cell cell32 = new Cell(1, 1)
                  .SetTextAlignment(TextAlignment.LEFT)
                  .Add(new Paragraph(_lkupProgrammeRepository.GetRecord(mainrec.Programme_Id).Record_Name)
                                .SetFont(ft_montserrat_reg)
                                .SetFixedLeading(9f)
                                .SetFontColor(cl_grayDark)
                                .SetFontSize(10))
                .SetBackgroundColor(cl_tablecontent_22)
                .SetBorderLeft(Border.NO_BORDER)
                .SetBorderRight(Border.NO_BORDER)
                .SetBorderTop(Border.NO_BORDER)
                .SetBorderBottom(Border.NO_BORDER);


                //Row 4
                Cell cell41 = new Cell(1, 1)
                  .SetTextAlignment(TextAlignment.LEFT)
                  .Add(new Paragraph("Project ")
                                //.SetFont(ft_montserrat_reg)
                                .SetFixedLeading(9f)
                                .SetFontSize(11))
                .SetBackgroundColor(cl_tableheader)
                .SetBorderLeft(Border.NO_BORDER)
                .SetBorderRight(Border.NO_BORDER)
                .SetBorderTop(Border.NO_BORDER)
                .SetBorderBottom(Border.NO_BORDER);

               Cell cell42 = new Cell(1, 1);
                if(_lkupProjectRepository.GetRecord(mainrec.Project_Id).Record_Status==true)
                {
                    cell42.SetTextAlignment(TextAlignment.LEFT)
                    .Add(new Paragraph(_lkupProjectRepository.GetRecord(mainrec.Project_Id).Record_Name)
                                    .SetFont(ft_montserrat_reg)
                                    .SetFixedLeading(9f)
                                    .SetFontColor(cl_grayDark)
                                    .SetFontSize(10))
                    .SetBackgroundColor(cl_tablecontent_22)
                    .SetBorderLeft(Border.NO_BORDER)
                    .SetBorderRight(Border.NO_BORDER)
                    .SetBorderTop(Border.NO_BORDER)
                    .SetBorderBottom(Border.NO_BORDER);
                }
                else
                {
                    cell42.SetTextAlignment(TextAlignment.LEFT)
                    .Add(new Paragraph(_lkupProjectRepository.GetRecord(mainrec.Project_Id).Record_Name+"   <-- New Project (Inception)")
                                    .SetFont(ft_montserrat_reg)
                                    .SetFixedLeading(9f)
                                    .SetFontColor(cl_grayDark)
                                    .SetFontSize(10))
                    .SetBackgroundColor(cl_tablecontent_22)
                    .SetBorderLeft(Border.NO_BORDER)
                    .SetBorderRight(Border.NO_BORDER)
                    .SetBorderTop(Border.NO_BORDER)
                    .SetBorderBottom(Border.NO_BORDER);

                }

                //Row 5
                Cell cell51 = new Cell(1, 1)
                  .SetTextAlignment(TextAlignment.LEFT)
                  .Add(new Paragraph("Year ")
                               // .SetFont(ft_montserrat_reg)
                                .SetFixedLeading(9f)
                                .SetFontSize(11))
                .SetBackgroundColor(cl_tableheader)
                .SetBorderLeft(Border.NO_BORDER)
                .SetBorderRight(Border.NO_BORDER)
                .SetBorderTop(Border.NO_BORDER)
                .SetBorderBottom(Border.NO_BORDER);

               Cell cell52 = new Cell(1, 1)
                  .SetTextAlignment(TextAlignment.LEFT)
                  .Add(new Paragraph(_lkupFiscalYearRepository.GetRecord(mainrec.FiscalYear_Id).Record_Name)
                                .SetFont(ft_montserrat_reg)
                                .SetFixedLeading(9f)
                                .SetFontColor(cl_grayDark)
                                .SetFontSize(10))
                .SetBackgroundColor(cl_tablecontent_22)
                .SetBorderLeft(Border.NO_BORDER)
                .SetBorderRight(Border.NO_BORDER)
                .SetBorderTop(Border.NO_BORDER)
                .SetBorderBottom(Border.NO_BORDER);


                //Row 6
                Cell cell61 = new Cell(1, 1)
                  .SetTextAlignment(TextAlignment.LEFT)
                  .Add(new Paragraph("Period ")
                               // .SetFont(ft_montserrat_reg)
                                .SetFixedLeading(9f)
                                .SetFontSize(11))
                .SetBackgroundColor(cl_tableheader)
                .SetBorderLeft(Border.NO_BORDER)
                .SetBorderRight(Border.NO_BORDER)
                .SetBorderTop(Border.NO_BORDER)
                .SetBorderBottom(Border.NO_BORDER);

               Cell cell62 = new Cell(1, 1)
                  .SetTextAlignment(TextAlignment.LEFT)
                  .Add(new Paragraph(periodname)
                                .SetFont(ft_montserrat_reg)
                                .SetFixedLeading(9f)
                                .SetFontColor(cl_grayDark)
                                .SetFontSize(10))
                .SetBackgroundColor(cl_tablecontent_22)
                .SetBorderLeft(Border.NO_BORDER)
                .SetBorderRight(Border.NO_BORDER)
                .SetBorderTop(Border.NO_BORDER)
                .SetBorderBottom(Border.NO_BORDER);

                //Row 7
                Cell cell71 = new Cell(1, 1)
                  .SetTextAlignment(TextAlignment.LEFT)
                  .Add(new Paragraph("Date ")
                                //.SetFont(ft_montserrat_reg)
                                .SetFixedLeading(9f)
                                .SetFontSize(11))
                .SetBackgroundColor(cl_tableheader)
                .SetBorderLeft(Border.NO_BORDER)
                .SetBorderRight(Border.NO_BORDER)
                .SetBorderTop(Border.NO_BORDER)
                .SetBorderBottom(Border.NO_BORDER);

               Cell cell72 = new Cell(1, 1)
                  .SetTextAlignment(TextAlignment.LEFT)
                  .Add(new Paragraph(DateTime.Now.Date.ToString("dd/MM/yyyy"))
                                .SetFont(ft_montserrat_reg)
                                .SetFixedLeading(9f)
                                .SetFontColor(cl_grayDark)
                                .SetFontSize(10))
                .SetBackgroundColor(cl_tablecontent_22)
                .SetBorderLeft(Border.NO_BORDER)
                .SetBorderRight(Border.NO_BORDER)
                .SetBorderTop(Border.NO_BORDER)
                .SetBorderBottom(Border.NO_BORDER);

                //Row 8a
                Cell cell81a = new Cell(1, 1)
                  .SetTextAlignment(TextAlignment.LEFT)
                  .Add(new Paragraph("MS Budget ")
                               // .SetFont(ft_montserrat_reg)
                                .SetFixedLeading(9f)
                                .SetFontSize(11))
                .SetBackgroundColor(cl_tableheader)
                .SetBorderLeft(Border.NO_BORDER)
                .SetBorderRight(Border.NO_BORDER)
                .SetBorderTop(Border.NO_BORDER)
                .SetBorderBottom(Border.NO_BORDER);

               Cell cell82a = new Cell(1, 1)
                  .SetTextAlignment(TextAlignment.LEFT)
                  .Add(new Paragraph(string.Format("{0:N2}", msbudget)+" USD")
                                .SetFont(ft_montserrat_reg)
                                .SetFixedLeading(9f)
                                .SetFontColor(cl_grayDark)
                                .SetFontSize(10))
                .SetBackgroundColor(cl_tablecontent_22)
                .SetBorderLeft(Border.NO_BORDER)
                .SetBorderRight(Border.NO_BORDER)
                .SetBorderTop(Border.NO_BORDER)
                .SetBorderBottom(Border.NO_BORDER);


                //Row 8b
                Cell cell81b = new Cell(1, 1)
                  .SetTextAlignment(TextAlignment.LEFT)
                  .Add(new Paragraph("DP Budget ")
                               // .SetFont(ft_montserrat_reg)
                                .SetFixedLeading(9f)
                                .SetFontSize(11))
                .SetBackgroundColor(cl_tableheader)
                .SetBorderLeft(Border.NO_BORDER)
                .SetBorderRight(Border.NO_BORDER)
                .SetBorderTop(Border.NO_BORDER)
                .SetBorderBottom(Border.NO_BORDER);

               Cell cell82b = new Cell(1, 1)
                  .SetTextAlignment(TextAlignment.LEFT)
                  .Add(new Paragraph(string.Format("{0:N2}", dpbudget)+" USD")
                                .SetFont(ft_montserrat_reg)
                                .SetFixedLeading(9f)
                                .SetFontColor(cl_grayDark)
                                .SetFontSize(10))
                .SetBackgroundColor(cl_tablecontent_22)
                .SetBorderLeft(Border.NO_BORDER)
                .SetBorderRight(Border.NO_BORDER)
                .SetBorderTop(Border.NO_BORDER)
                .SetBorderBottom(Border.NO_BORDER);



                //Row 8
                Cell cell81 = new Cell(1, 1)
                  .SetTextAlignment(TextAlignment.LEFT)
                  .Add(new Paragraph("Total Budget ")
                               // .SetFont(ft_montserrat_reg)
                                .SetFixedLeading(9f)
                                .SetFontSize(11))
                .SetBackgroundColor(cl_tableheader)
                .SetBorderLeft(Border.NO_BORDER)
                .SetBorderRight(Border.NO_BORDER)
                .SetBorderTop(Border.NO_BORDER)
                .SetBorderBottom(Border.NO_BORDER);

               Cell cell82 = new Cell(1, 1)
                  .SetTextAlignment(TextAlignment.LEFT)
                  .Add(new Paragraph(string.Format("{0:N2}", totalbudget)+" USD")
                                .SetFont(ft_montserrat_reg)
                                .SetFixedLeading(9f)
                                .SetFontColor(cl_grayDark)
                                .SetFontSize(10))
                .SetBackgroundColor(cl_tablecontent_22)
                .SetBorderLeft(Border.NO_BORDER)
                .SetBorderRight(Border.NO_BORDER)
                .SetBorderTop(Border.NO_BORDER)
                .SetBorderBottom(Border.NO_BORDER);





                //Row last
                Cell celllast1 = new Cell(1, 1)
                  .SetTextAlignment(TextAlignment.LEFT)
                  .Add(new Paragraph("Status ")
                               // .SetFont(ft_montserrat_reg)
                                .SetFixedLeading(12f)
                                .SetFontSize(11))
                .SetBackgroundColor(cl_tableheader)
                .SetBorderLeft(Border.NO_BORDER)
                .SetBorderRight(Border.NO_BORDER)
                .SetBorderTop(Border.NO_BORDER);

               Cell celllast2 = new Cell(1, 1)
                  .SetTextAlignment(TextAlignment.LEFT)
                  .Add(new Paragraph(mainrec.WP_ApprovalStatus)
                                .SetFont(ft_montserrat_reg)
                                .SetFixedLeading(12f)
                                .SetFontColor(cl_grayDark)
                                //.SetFontColor(cl_red)
                                .SetFontSize(10))
                .SetBackgroundColor(cl_tablecontent_22)
                .SetBorderLeft(Border.NO_BORDER)
                .SetBorderRight(Border.NO_BORDER)
                .SetBorderTop(Border.NO_BORDER);


               table.AddCell(cell11);
               table.AddCell(cell12);

               table.AddCell(cell21);
               table.AddCell(cell22);

               table.AddCell(cell31);
               table.AddCell(cell32);

               table.AddCell(cell41);
               table.AddCell(cell42);

                table.AddCell(cell51);
               table.AddCell(cell52);

                table.AddCell(cell61);
               table.AddCell(cell62);

                table.AddCell(cell71);
               table.AddCell(cell72);

                table.AddCell(cell81a);
               table.AddCell(cell82a);

                table.AddCell(cell81b);
               table.AddCell(cell82b);

                table.AddCell(cell81);
               table.AddCell(cell82);


               table.AddCell(celllast1);
               table.AddCell(celllast2);


               document.Add(table);


               Paragraph printing_info = new Paragraph("Please, Print on A3 for Better Resolution")
						.SetTextAlignment(TextAlignment.CENTER)
						.SetFont(ft_montserrat_reg_it)
						.SetFontColor(cl_grayDark)
						.SetFontSize(8);
                document.Add(printing_info);



               //Shared Variables
                int outeriter=0;
                int inneriter=0;
                bool row_alt=true;

                document.Add(txt_gap);

                /*Paragraph picons = new Paragraph();
                picons.Add(new Text("\ue000\ue0bb\ue14d").SetFont(ft_materialicons_fonts).SetFontSize(12).SetFontColor(cl));
                picons.Add(new Text(" This is cool").SetFont(ft).SetFontSize(12).SetFontColor(cl));
               // Paragraph picons = new Paragraph("\ue000\ue0bb\ue14d").SetFont(ft_materialicons_fonts).SetFontSize(12).SetFontColor(cl);
                
                document.Add(picons);
                document.Add(txt_gap);*/
                //Group by Outputs
               
               Paragraph wpoutcomes = new Paragraph("Workplan Outcomes")
                .SetTextAlignment(TextAlignment.LEFT)
                .SetFont(ft)
                .SetFontColor(cl)
                .SetFixedLeading(11f)
                .SetFontSize(15);
                document.Add(wpoutcomes);


                 var DB_Outcomes =  _wpOutcomesRepository.GetRecordsByMainRecordId(mainrec.Transaction_Id).ToList();

                
                foreach (var recordset in DB_Outcomes)
                {


                   float indentmargin_outer=document.GetLeftMargin()+49;
                    Table tableactivity_outer = new Table(UnitValue.CreatePercentArray(new float[]{2, 98}), false)
                                        .SetWidth(PageSize.A3.GetHeight()-indentmargin_outer)
                                        .SetMarginLeft(14)
                                        .SetHorizontalAlignment(HorizontalAlignment.LEFT);

                        Cell cellbullet = new Cell(1, 1)
                        .SetTextAlignment(TextAlignment.LEFT)
                        .Add(new Paragraph("\ue837")
                                        .SetFont(ft_materialicons_fonts)
                                        .SetFixedLeading(14f)
                                        .SetFontColor(cl_green)
                                        .SetFontSize(11))
                            .SetBorder(Border.NO_BORDER);

                        Cell celltxt= new Cell(1, 1)
                        .SetTextAlignment(TextAlignment.JUSTIFIED)
                        .Add(new Paragraph(recordset.Outcome)
                                        .SetFixedLeading(14f)
                                       // .SetFont(ft_helveticaneue)
                                        .SetFontColor(cl_green)
                                        .SetFontSize(11))
                            
                            .SetBorder(Border.NO_BORDER);

                    tableactivity_outer.AddCell(cellbullet);
                    tableactivity_outer.AddCell(celltxt);

                    document.Add(tableactivity_outer);
                    document.Add(txt);



                    float indentmargin=document.GetLeftMargin()+77;
                    Table tableindicators = new Table(UnitValue.CreatePercentArray(new float[]{40, 8, 14, 19, 19}), false)
                                        .SetWidth(PageSize.A3.GetHeight()-indentmargin)
                                        .SetMarginLeft(40)
                                        .SetHorizontalAlignment(HorizontalAlignment.LEFT);

                    var DB_Indicators=_wpOutcomeIndicatorsRepository.GetRecordsByMainRecordOutcomeId(mainrec.Transaction_Id, recordset.Transaction_Id);

                    if(DB_Indicators.Count()>=1)
                    {
                        



                        //Row Header
                        Cell cellheader01 = new Cell(1, 1)
                        .SetTextAlignment(TextAlignment.LEFT)
                        .Add(new Paragraph("Indicator")
                                        .SetFont(ft_bold)
                                        .SetFixedLeading(14f)
                                        .SetFontColor(cl_grayDark)
                                        .SetBackgroundColor(cl_tableheader)
                                        .SetFontSize(10))
                            .SetBackgroundColor(cl_tableheader);

                        tableindicators.AddCell(cellheader01);

                        Cell cellheader02 = new Cell(1, 1)
                            .SetTextAlignment(TextAlignment.LEFT)
                            .Add(new Paragraph("Type")
                                            .SetFont(ft_bold)
                                            .SetFixedLeading(14f)
                                            .SetFontColor(cl_grayDark)
                                            .SetBackgroundColor(cl_tableheader)
                                            .SetFontSize(11))
                            .SetBackgroundColor(cl_tableheader);
                        tableindicators.AddCell(cellheader02);

                        Cell cellheader02b = new Cell(1, 1)
                            .SetTextAlignment(TextAlignment.LEFT)
                            .Add(new Paragraph("Category of Indicator")
                                            .SetFont(ft_bold)
                                            .SetFixedLeading(14f)
                                            .SetFontColor(cl_grayDark)
                                            .SetBackgroundColor(cl_tableheader)
                                            .SetFontSize(10))
                            .SetBackgroundColor(cl_tableheader);
                        tableindicators.AddCell(cellheader02b);


                        Cell cellheader03 = new Cell(1, 1)
                            .SetTextAlignment(TextAlignment.LEFT)
                            .Add(new Paragraph("Baseline")
                                            .SetFont(ft_bold)
                                            .SetFixedLeading(14f)
                                            .SetFontColor(cl_grayDark)
                                            .SetBackgroundColor(cl_tableheader)
                                            .SetFontSize(10))
                            .SetBackgroundColor(cl_tableheader);
                        tableindicators.AddCell(cellheader03);

                        Cell cellheader04 = new Cell(1, 1)
                            .SetTextAlignment(TextAlignment.LEFT)
                            .Add(new Paragraph("Target")
                                            .SetFont(ft_bold)
                                            .SetFixedLeading(14f)
                                            .SetFontColor(cl_grayDark)
                                            .SetBackgroundColor(cl_tableheader)
                                            .SetFontSize(10))
                            .SetBackgroundColor(cl_tableheader);
                        tableindicators.AddCell(cellheader04);

                        int activitycount=DB_Indicators.Count();




                        foreach (var indicator in DB_Indicators)
                        {
                            inneriter=inneriter+1;

                            Cell cell1 = new Cell(1, 1);
                            Cell cell2 = new Cell(1, 1);
                            Cell cell2b = new Cell(1, 1);
                            Cell cell3 = new Cell(1, 1);
                            Cell cell4 = new Cell(1, 1);
    
                            string indicatorname="";

                            if(indicator.IndicatorCategory=="Institutional-Level")
                            {
                                indicatorname=_strategyOutputIndicatorsRepository.GetRecord(indicator.OutcomeIndicator_Id).Record_Name;

                            }
                            else if (indicator.IndicatorCategory=="Directorate-Level")
                            {
                                indicatorname=_strucDirDivIndicatorsRepository.GetRecord(indicator.OutcomeIndicator_Id).Record_Name;

                            }
                            else
                            {
                                indicatorname=indicator.ProjectBasedIndicatorStatement;
                            }



                            string baselinename="";
                            string targetname="";


                            if(indicator.IndicatorType=="Quantitative")
                            {
                                baselinename=indicator.BaselineQuantitative.ToString();
                                targetname=indicator.TargetQuantitative.ToString();

                            }
                            else
                            {
                                baselinename=indicator.BaselineQuanlitative;
                                targetname=indicator.TargetQuanlitative;
                            }

                            if(row_alt==false)
                            {
                                //Row Rows
                                cell1.SetTextAlignment(TextAlignment.JUSTIFIED)
                                .Add(new Paragraph(indicatorname)
                                                //.SetFont(ft_montserrat_reg)
                                                .SetFixedLeading(14f)
                                                .SetFontColor(cl_grayDark)
                                                .SetBackgroundColor(cl_tablecontent_1)
                                                .SetFontSize(10))
                                    .SetBackgroundColor(cl_tablecontent_1)
                                    .SetBorderTop(Border.NO_BORDER)
                                    .SetBorderBottom(Border.NO_BORDER);


                             
                                    cell2.SetTextAlignment(TextAlignment.LEFT)
                                    .Add(new Paragraph(indicator.IndicatorType)
                                                    //.SetFont(ft_montserrat_reg)
                                                    .SetFixedLeading(14f)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tablecontent_1)
                                                    .SetFontSize(10))
                                    .SetBackgroundColor(cl_tablecontent_1)
                                    .SetBorderTop(Border.NO_BORDER)
                                    .SetBorderBottom(Border.NO_BORDER);

                                    cell2b.SetTextAlignment(TextAlignment.LEFT)
                                    .Add(new Paragraph(indicator.IndicatorCategory)
                                                    //.SetFont(ft_montserrat_reg)
                                                    .SetFixedLeading(14f)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tablecontent_1)
                                                    .SetFontSize(10))
                                    .SetBackgroundColor(cl_tablecontent_1)
                                    .SetBorderTop(Border.NO_BORDER)
                                    .SetBorderBottom(Border.NO_BORDER);




                                    cell3.SetTextAlignment(TextAlignment.LEFT)
                                    .Add(new Paragraph(baselinename)
                                                   // .SetFont(ft_montserrat_reg)
                                                    .SetFixedLeading(14f)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tablecontent_1)
                                                    .SetFontSize(10))
                                    .SetBackgroundColor(cl_tablecontent_1)
                                    .SetBorderTop(Border.NO_BORDER)
                                    .SetBorderBottom(Border.NO_BORDER);



                                cell4.SetTextAlignment(TextAlignment.LEFT)
                                    .Add(new Paragraph(targetname)
                                                   // .SetFont(ft_montserrat_reg)
                                                    .SetFixedLeading(14f)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tablecontent_1)
                                                    .SetFontSize(10))
                                    .SetBackgroundColor(cl_tablecontent_1)
                                    .SetBorderTop(Border.NO_BORDER)
                                    .SetBorderBottom(Border.NO_BORDER);

                            }
                            else
                            {
                                //Row Rows

                                cell1.SetTextAlignment(TextAlignment.JUSTIFIED)
                                    .Add(new Paragraph(indicatorname)
                                                   // .SetFont(ft_montserrat_reg)
                                                    .SetFixedLeading(14f)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tablecontent_2)
                                                    .SetFontSize(10))
                                        .SetBackgroundColor(cl_tablecontent_2)
                                        .SetBorderTop(Border.NO_BORDER)
                                        .SetBorderBottom(Border.NO_BORDER);



                                cell2.SetTextAlignment(TextAlignment.LEFT)
                                    .Add(new Paragraph(indicator.IndicatorType)
                                                   // .SetFont(ft_montserrat_reg)
                                                    .SetFixedLeading(14f)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tablecontent_2)
                                                    .SetFontSize(10))
                                    .SetBackgroundColor(cl_tablecontent_2)
                                    .SetBorderTop(Border.NO_BORDER)
                                    .SetBorderBottom(Border.NO_BORDER);

                                cell2b.SetTextAlignment(TextAlignment.LEFT)
                                    .Add(new Paragraph(indicator.IndicatorCategory)
                                                   // .SetFont(ft_montserrat_reg)
                                                    .SetFixedLeading(14f)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tablecontent_2)
                                                    .SetFontSize(10))
                                    .SetBackgroundColor(cl_tablecontent_2)
                                    .SetBorderTop(Border.NO_BORDER)
                                    .SetBorderBottom(Border.NO_BORDER);
    



                                cell3.SetTextAlignment(TextAlignment.LEFT)
                                    .Add(new Paragraph(baselinename)
                                                   // .SetFont(ft_montserrat_reg)
                                                    .SetFixedLeading(14f)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tablecontent_2)
                                                    .SetFontSize(10))
                                    .SetBackgroundColor(cl_tablecontent_2)
                                    .SetBorderTop(Border.NO_BORDER)
                                    .SetBorderBottom(Border.NO_BORDER);
   


                                cell4.SetTextAlignment(TextAlignment.LEFT)
                                    .Add(new Paragraph(targetname)
                                                    //.SetFont(ft_montserrat_reg)
                                                    .SetFixedLeading(14f)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tablecontent_2)
                                                    .SetFontSize(10))
                                    .SetBackgroundColor(cl_tablecontent_2)
                                    .SetBorderTop(Border.NO_BORDER)
                                    .SetBorderBottom(Border.NO_BORDER);
                                

                            }

                            row_alt=ToggleBoolean(row_alt);
                            if(inneriter==activitycount)
                            {
                                cell1.SetBorderBottom(new SolidBorder(1f));
                                cell2.SetBorderBottom(new SolidBorder(1f));
                                cell2b.SetBorderBottom(new SolidBorder(1f));
                                cell3.SetBorderBottom(new SolidBorder(1f));
                                cell4.SetBorderBottom(new SolidBorder(1f));

                            }

                            tableindicators.AddCell(cell1);
                            tableindicators.AddCell(cell2);
                            tableindicators.AddCell(cell2b);
                            tableindicators.AddCell(cell3);   
                            tableindicators.AddCell(cell4);

                            

                        }

                       

                        inneriter=0;
                        row_alt=true;
                        document.Add(tableindicators);

                       
                    }



                    document.Add(txt);
                    document.Add(txt);


                    
                }

            

                document.Add(txt_gap);

                Paragraph wpoutputsstatements = new Paragraph("Workplan Outputs")
                .SetTextAlignment(TextAlignment.LEFT)
                .SetFont(ft)
                .SetFontColor(cl)
                .SetFixedLeading(11f)
                .SetFontSize(15);
                document.Add(wpoutputsstatements);

                document.Add(txt);


                var DB_Outputs =  _wpOutputsRepository.GetRecordsByMainRecordId(mainrec.Transaction_Id).ToList();

                outeriter=0;

               
                
                foreach (var recordset in DB_Outputs)
                {
                    outeriter=outeriter+1;


                    float indentmargin_outer=document.GetLeftMargin()+49;
                    Table tableactivity_outer = new Table(UnitValue.CreatePercentArray(new float[]{2, 98}), false)
                                        .SetWidth(PageSize.A3.GetHeight()-indentmargin_outer)
                                        .SetMarginLeft(14)
                                        .SetHorizontalAlignment(HorizontalAlignment.LEFT);

                        Cell cellbullet = new Cell(1, 1)
                        .SetTextAlignment(TextAlignment.LEFT)
                        .Add(new Paragraph("\ue837")
                                        .SetFont(ft_materialicons_fonts)
                                        .SetFixedLeading(14f)
                                        .SetFontColor(cl_green)
                                        .SetFontSize(11))
                            .SetBorder(Border.NO_BORDER);

                        Cell celltxt= new Cell(1, 1)
                        .SetTextAlignment(TextAlignment.JUSTIFIED)
                        .Add(new Paragraph(recordset.Output)
                                        .SetFixedLeading(14f)
                                       // .SetFont(ft_helveticaneue)
                                        .SetFontColor(cl_green)
                                        .SetFontSize(11))
                            
                            .SetBorder(Border.NO_BORDER);

                    tableactivity_outer.AddCell(cellbullet);
                    tableactivity_outer.AddCell(celltxt);

                    document.Add(tableactivity_outer);
                    document.Add(txt);





                    float indentmargin=document.GetLeftMargin()+77;
                    Table tableindicators = new Table(UnitValue.CreatePercentArray(new float[]{40, 8, 14, 19, 19}), false)
                                        .SetWidth(PageSize.A3.GetHeight()-indentmargin)
                                        .SetMarginLeft(40)
                                        .SetHorizontalAlignment(HorizontalAlignment.LEFT);

                    var DB_Indicators=_wpOutputIndicatorsRepository.GetRecordsByMainRecordOutputId(mainrec.Transaction_Id, recordset.Transaction_Id);

                    if(DB_Indicators.Count()>=1)
                    {
                        



                        //Row Header
                        Cell cellheader01 = new Cell(1, 1)
                        .SetTextAlignment(TextAlignment.LEFT)
                        .Add(new Paragraph("Indicator")
                                        .SetFont(ft_bold)
                                        .SetFixedLeading(14f)
                                        .SetFontColor(cl_grayDark)
                                        .SetBackgroundColor(cl_tableheader)
                                        .SetFontSize(10))
                            .SetBackgroundColor(cl_tableheader);

                        tableindicators.AddCell(cellheader01);

                        Cell cellheader02 = new Cell(1, 1)
                            .SetTextAlignment(TextAlignment.LEFT)
                            .Add(new Paragraph("Type")
                                            .SetFont(ft_bold)
                                            .SetFixedLeading(14f)
                                            .SetFontColor(cl_grayDark)
                                            .SetBackgroundColor(cl_tableheader)
                                            .SetFontSize(11))
                            .SetBackgroundColor(cl_tableheader);
                        tableindicators.AddCell(cellheader02);

                        Cell cellheader02b = new Cell(1, 1)
                            .SetTextAlignment(TextAlignment.LEFT)
                            .Add(new Paragraph("Category of Indicator")
                                            .SetFont(ft_bold)
                                            .SetFixedLeading(14f)
                                            .SetFontColor(cl_grayDark)
                                            .SetBackgroundColor(cl_tableheader)
                                            .SetFontSize(10))
                            .SetBackgroundColor(cl_tableheader);
                        tableindicators.AddCell(cellheader02b);


                        Cell cellheader03 = new Cell(1, 1)
                            .SetTextAlignment(TextAlignment.LEFT)
                            .Add(new Paragraph("Baseline")
                                            .SetFont(ft_bold)
                                            .SetFixedLeading(14f)
                                            .SetFontColor(cl_grayDark)
                                            .SetBackgroundColor(cl_tableheader)
                                            .SetFontSize(10))
                            .SetBackgroundColor(cl_tableheader);
                        tableindicators.AddCell(cellheader03);

                        Cell cellheader04 = new Cell(1, 1)
                            .SetTextAlignment(TextAlignment.LEFT)
                            .Add(new Paragraph("Target")
                                            .SetFont(ft_bold)
                                            .SetFixedLeading(14f)
                                            .SetFontColor(cl_grayDark)
                                            .SetBackgroundColor(cl_tableheader)
                                            .SetFontSize(10))
                            .SetBackgroundColor(cl_tableheader);
                        tableindicators.AddCell(cellheader04);

                        int activitycount=DB_Indicators.Count();




                        foreach (var indicator in DB_Indicators)
                        {
                            inneriter=inneriter+1;

                            Cell cell1 = new Cell(1, 1);
                            Cell cell2 = new Cell(1, 1);
                            Cell cell2b = new Cell(1, 1);
                            Cell cell3 = new Cell(1, 1);
                            Cell cell4 = new Cell(1, 1);
    
                            string indicatorname="";

                            if(indicator.IndicatorCategory=="Institutional-Level")
                            {
                                indicatorname=_strategyOutputIndicatorsRepository.GetRecord(indicator.OutputIndicator_Id).Record_Name;

                            }
                            else if (indicator.IndicatorCategory=="Directorate-Level")
                            {
                                indicatorname=_strucDirDivIndicatorsRepository.GetRecord(indicator.OutputIndicator_Id).Record_Name;

                            }
                            else
                            {
                                indicatorname=indicator.ProjectBasedIndicatorStatement;
                            }



                            string baselinename="";
                            string targetname="";


                            if(indicator.IndicatorType=="Quantitative")
                            {
                                baselinename=indicator.BaselineQuantitative.ToString();
                                targetname=indicator.TargetQuantitative.ToString();

                            }
                            else
                            {
                                baselinename=indicator.BaselineQuanlitative;
                                targetname=indicator.TargetQuanlitative;
                            }

                            if(row_alt==false)
                            {
                                //Row Rows
                                cell1.SetTextAlignment(TextAlignment.JUSTIFIED)
                                .Add(new Paragraph(indicatorname)
                                                //.SetFont(ft_montserrat_reg)
                                                .SetFixedLeading(14f)
                                                .SetFontColor(cl_grayDark)
                                                .SetBackgroundColor(cl_tablecontent_1)
                                                .SetFontSize(10))
                                    .SetBackgroundColor(cl_tablecontent_1)
                                    .SetBorderTop(Border.NO_BORDER)
                                    .SetBorderBottom(Border.NO_BORDER);


                             
                                    cell2.SetTextAlignment(TextAlignment.LEFT)
                                    .Add(new Paragraph(indicator.IndicatorType)
                                                    //.SetFont(ft_montserrat_reg)
                                                    .SetFixedLeading(14f)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tablecontent_1)
                                                    .SetFontSize(10))
                                    .SetBackgroundColor(cl_tablecontent_1)
                                    .SetBorderTop(Border.NO_BORDER)
                                    .SetBorderBottom(Border.NO_BORDER);

                                    cell2b.SetTextAlignment(TextAlignment.LEFT)
                                    .Add(new Paragraph(indicator.IndicatorCategory)
                                                    //.SetFont(ft_montserrat_reg)
                                                    .SetFixedLeading(14f)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tablecontent_1)
                                                    .SetFontSize(10))
                                    .SetBackgroundColor(cl_tablecontent_1)
                                    .SetBorderTop(Border.NO_BORDER)
                                    .SetBorderBottom(Border.NO_BORDER);




                                    cell3.SetTextAlignment(TextAlignment.LEFT)
                                    .Add(new Paragraph(baselinename)
                                                   // .SetFont(ft_montserrat_reg)
                                                    .SetFixedLeading(14f)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tablecontent_1)
                                                    .SetFontSize(10))
                                    .SetBackgroundColor(cl_tablecontent_1)
                                    .SetBorderTop(Border.NO_BORDER)
                                    .SetBorderBottom(Border.NO_BORDER);



                                cell4.SetTextAlignment(TextAlignment.LEFT)
                                    .Add(new Paragraph(targetname)
                                                   // .SetFont(ft_montserrat_reg)
                                                    .SetFixedLeading(14f)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tablecontent_1)
                                                    .SetFontSize(10))
                                    .SetBackgroundColor(cl_tablecontent_1)
                                    .SetBorderTop(Border.NO_BORDER)
                                    .SetBorderBottom(Border.NO_BORDER);

                            }
                            else
                            {
                                //Row Rows

                                cell1.SetTextAlignment(TextAlignment.JUSTIFIED)
                                    .Add(new Paragraph(indicatorname)
                                                   // .SetFont(ft_montserrat_reg)
                                                    .SetFixedLeading(14f)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tablecontent_2)
                                                    .SetFontSize(10))
                                        .SetBackgroundColor(cl_tablecontent_2)
                                        .SetBorderTop(Border.NO_BORDER)
                                        .SetBorderBottom(Border.NO_BORDER);



                                cell2.SetTextAlignment(TextAlignment.LEFT)
                                    .Add(new Paragraph(indicator.IndicatorType)
                                                   // .SetFont(ft_montserrat_reg)
                                                    .SetFixedLeading(14f)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tablecontent_2)
                                                    .SetFontSize(10))
                                    .SetBackgroundColor(cl_tablecontent_2)
                                    .SetBorderTop(Border.NO_BORDER)
                                    .SetBorderBottom(Border.NO_BORDER);

                                cell2b.SetTextAlignment(TextAlignment.LEFT)
                                    .Add(new Paragraph(indicator.IndicatorCategory)
                                                   // .SetFont(ft_montserrat_reg)
                                                    .SetFixedLeading(14f)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tablecontent_2)
                                                    .SetFontSize(10))
                                    .SetBackgroundColor(cl_tablecontent_2)
                                    .SetBorderTop(Border.NO_BORDER)
                                    .SetBorderBottom(Border.NO_BORDER);
    



                                cell3.SetTextAlignment(TextAlignment.LEFT)
                                    .Add(new Paragraph(baselinename)
                                                   // .SetFont(ft_montserrat_reg)
                                                    .SetFixedLeading(14f)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tablecontent_2)
                                                    .SetFontSize(10))
                                    .SetBackgroundColor(cl_tablecontent_2)
                                    .SetBorderTop(Border.NO_BORDER)
                                    .SetBorderBottom(Border.NO_BORDER);
   


                                cell4.SetTextAlignment(TextAlignment.LEFT)
                                    .Add(new Paragraph(targetname)
                                                    //.SetFont(ft_montserrat_reg)
                                                    .SetFixedLeading(14f)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tablecontent_2)
                                                    .SetFontSize(10))
                                    .SetBackgroundColor(cl_tablecontent_2)
                                    .SetBorderTop(Border.NO_BORDER)
                                    .SetBorderBottom(Border.NO_BORDER);
                                

                            }

                            row_alt=ToggleBoolean(row_alt);
                            if(inneriter==activitycount)
                            {
                                cell1.SetBorderBottom(new SolidBorder(1f));
                                cell2.SetBorderBottom(new SolidBorder(1f));
                                cell2b.SetBorderBottom(new SolidBorder(1f));
                                cell3.SetBorderBottom(new SolidBorder(1f));
                                cell4.SetBorderBottom(new SolidBorder(1f));

                            }

                            tableindicators.AddCell(cell1);
                            tableindicators.AddCell(cell2);
                            tableindicators.AddCell(cell2b);
                            tableindicators.AddCell(cell3);   
                            tableindicators.AddCell(cell4);

                            

                        }

                       

                        inneriter=0;
                        row_alt=true;
                        document.Add(tableindicators);

                       
                    }



                    document.Add(txt);
                    document.Add(txt);
                    
                    
                    
                }

                document.Add(txt_gap);





                //Group by Outputs
                Paragraph grpbyoutputs = new Paragraph("Workplan Activities Grouped by Outputs")
                .SetTextAlignment(TextAlignment.LEFT)
                .SetFont(ft)
                .SetFontColor(cl)
                .SetFixedLeading(11f)
                .SetFontSize(15);
                document.Add(grpbyoutputs);


                outeriter=0;

        
                foreach (var recordset in DB_Outputs)
                {
                    outeriter=outeriter+1;


                    float indentmargin_outer=document.GetLeftMargin()+49;
                    Table tableactivity_outer = new Table(UnitValue.CreatePercentArray(new float[]{2, 98}), false)
                                        .SetWidth(PageSize.A3.GetHeight()-indentmargin_outer)
                                        .SetMarginLeft(14)
                                        .SetHorizontalAlignment(HorizontalAlignment.LEFT);

                        Cell cellbullet = new Cell(1, 1)
                        .SetTextAlignment(TextAlignment.LEFT)
                        .Add(new Paragraph("\ue837")
                                        .SetFont(ft_materialicons_fonts)
                                        .SetFixedLeading(14f)
                                        .SetFontColor(cl_green)
                                        .SetFontSize(11))
                            .SetBorder(Border.NO_BORDER);

                        Cell celltxt= new Cell(1, 1)
                        .SetTextAlignment(TextAlignment.JUSTIFIED)
                        .Add(new Paragraph(recordset.Output)
                                        .SetFixedLeading(14f)
                                       // .SetFont(ft_helveticaneue)
                                        .SetFontColor(cl_green)
                                        .SetFontSize(11))
                            
                            .SetBorder(Border.NO_BORDER);

                    tableactivity_outer.AddCell(cellbullet);
                    tableactivity_outer.AddCell(celltxt);

                    document.Add(tableactivity_outer);
                    document.Add(txt);





                    float indentmargin=document.GetLeftMargin()+77;
                    float tablewidth=PageSize.A4.GetWidth()-indentmargin;
                    //Table tableactivity = new Table(UnitValue.CreatePercentArray(new float[]{40, 20, 20, 20}), false)
                    Table tableactivity = new Table(UnitValue.CreatePercentArray(new float[]{25, 13, 13, 20, 7, 7, 7, 8}), false)
                                        .SetWidth(PageSize.A3.GetHeight()-indentmargin)
                                        .SetMarginLeft(40)
                                        .SetHorizontalAlignment(HorizontalAlignment.LEFT);

                    var DB_Activities=_wpOutputActivitiesRepository.GetRecordsByOutputId(recordset.Transaction_Id);

                    if(DB_Activities.Count()>=1)
                    {
                        



                        //Row Header
                        Cell cellheader01 = new Cell(1, 1)
                        .SetTextAlignment(TextAlignment.LEFT)
                        .Add(new Paragraph("Activity")
                                        .SetFont(ft_bold)
                                        .SetFixedLeading(14f)
                                        .SetFontColor(cl_grayDark)
                                        .SetBackgroundColor(cl_tableheader)
                                        .SetFontSize(10))
                            .SetBackgroundColor(cl_tableheader);

                        tableactivity.AddCell(cellheader01);

                        Cell cellheader02 = new Cell(1, 1)
                            .SetTextAlignment(TextAlignment.LEFT)
                            .Add(new Paragraph("Type of Activity")
                                            .SetFont(ft_bold)
                                            .SetFixedLeading(14f)
                                            .SetFontColor(cl_grayDark)
                                            .SetBackgroundColor(cl_tableheader)
                                            .SetFontSize(10))
                            .SetBackgroundColor(cl_tableheader);
                        tableactivity.AddCell(cellheader02);

                        Cell cellheader03 = new Cell(1, 1)
                            .SetTextAlignment(TextAlignment.LEFT)
                            .Add(new Paragraph("Type of Implementation")
                                            .SetFont(ft_bold)
                                            .SetFixedLeading(14f)
                                            .SetFontColor(cl_grayDark)
                                            .SetBackgroundColor(cl_tableheader)
                                            .SetFontSize(10))
                            .SetBackgroundColor(cl_tableheader);
                        tableactivity.AddCell(cellheader03);


                        Cell cellheader04 = new Cell(1, 1)
                            .SetTextAlignment(TextAlignment.LEFT)
                            .Add(new Paragraph("Activity Period")
                                            .SetFont(ft_bold)
                                            .SetFixedLeading(14f)
                                            .SetFontColor(cl_grayDark)
                                            .SetBackgroundColor(cl_tableheader)
                                            .SetFontSize(10))
                            .SetBackgroundColor(cl_tableheader);
                        tableactivity.AddCell(cellheader04);

                        Cell cellheader05 = new Cell(1, 1)
                            .SetTextAlignment(TextAlignment.RIGHT)
                            .Add(new Paragraph("BTE Rate (%)")
                                            .SetFont(ft_bold)
                                            .SetFixedLeading(14f)
                                            .SetFontColor(cl_grayDark)
                                            .SetBackgroundColor(cl_tableheader)
                                            .SetFontSize(10))
                            .SetBackgroundColor(cl_tableheader);
                        tableactivity.AddCell(cellheader05);

                        Cell cellheader06 = new Cell(1, 1)
                            .SetTextAlignment(TextAlignment.RIGHT)
                            .Add(new Paragraph("BFE Rate (%)")
                                            .SetFont(ft_bold)
                                            .SetFixedLeading(14f)
                                            .SetFontColor(cl_grayDark)
                                            .SetBackgroundColor(cl_tableheader)
                                            .SetFontSize(10))
                            .SetBackgroundColor(cl_tableheader);
                        tableactivity.AddCell(cellheader06);

                        Cell cellheader07 = new Cell(1, 1)
                            .SetTextAlignment(TextAlignment.RIGHT)
                            .Add(new Paragraph("Amount (USD)")
                                            .SetFont(ft_bold)
                                            .SetFixedLeading(14f)
                                            .SetFontColor(cl_grayDark)
                                            .SetBackgroundColor(cl_tableheader)
                                            .SetFontSize(10))
                            .SetBackgroundColor(cl_tableheader);
                        tableactivity.AddCell(cellheader07);


                        Cell cellheader07a = new Cell(1, 1)
                            .SetTextAlignment(TextAlignment.LEFT)
                            .Add(new Paragraph("Source of Funds")
                                            .SetFont(ft_bold)
                                            .SetFixedLeading(14f)
                                            .SetFontColor(cl_grayDark)
                                            .SetBackgroundColor(cl_tableheader)
                                            .SetFontSize(10))
                            .SetBackgroundColor(cl_tableheader);
                        tableactivity.AddCell(cellheader07a);

    

                        int activitycount=DB_Activities.Count();




                        foreach (var activity in DB_Activities)
                        {
                            inneriter=inneriter+1;

                            Cell cell1 = new Cell(1, 1);
                            Cell cell2 = new Cell(1, 1);
                            Cell cell3 = new Cell(1, 1);
                            Cell cell4 = new Cell(1, 1);
                            Cell cell5 = new Cell(1, 1);
                            Cell cell6 = new Cell(1, 1);
                            Cell cell7 = new Cell(1, 1);
                            Cell cell7a = new Cell(1, 1);

                            DateTime start= new  DateTime(activity.ActivityStartDate.Year, activity.ActivityStartDate.Month, activity.ActivityStartDate.Day);
                            DateTime end= new  DateTime(activity.ActivityEndDate.Year, activity.ActivityEndDate.Month, activity.ActivityEndDate.Day);
                            string period=start.Date.ToString("MMMM d, yyyy")+" - "+end.Date.ToString("MMMM d, yyyy");

                            string fundssource="";
                            
                            if(activity.PartnerFunding==true && activity.PartnerFundingDescr!=null)
                            {
                                fundssource="DP ("+activity.PartnerFundingDescr+")";
                            }
                            else if (activity.PartnerFunding==true && activity.PartnerFundingDescr!=null)
                            {
                                fundssource="DP";
                            }
                            else
                            {
                                fundssource="MS";
                            }

                            if(row_alt==false)
                            {
                                //Row Rows
                                cell1.SetTextAlignment(TextAlignment.JUSTIFIED)
                                .Add(new Paragraph(activity.ActivityDescription)
                                                //.SetFont(ft_montserrat_reg)
                                                .SetFixedLeading(14f)
                                                .SetFontColor(cl_grayDark)
                                                .SetBackgroundColor(cl_tablecontent_1)
                                                .SetFontSize(10))
                                    .SetBackgroundColor(cl_tablecontent_1)
                                    .SetBorderTop(Border.NO_BORDER)
                                    .SetBorderBottom(Border.NO_BORDER);


                             
                                    cell2.SetTextAlignment(TextAlignment.LEFT)
                                    .Add(new Paragraph(_lkupActivityTypeRepository.GetActivityType(activity.ActivityType_Id).Activity_Name)
                                                    //.SetFont(ft_montserrat_reg)
                                                    .SetFixedLeading(14f)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tablecontent_1)
                                                    .SetFontSize(9))
                                    .SetBackgroundColor(cl_tablecontent_1)
                                    .SetBorderTop(Border.NO_BORDER)
                                    .SetBorderBottom(Border.NO_BORDER);


                                    cell3.SetTextAlignment(TextAlignment.LEFT)
                                    .Add(new Paragraph(_lkupImplementationTypeRepository.GetRecord(activity.ImplementationType_Id).Record_Name)
                                                   // .SetFont(ft_montserrat_reg)
                                                    .SetFixedLeading(14f)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tablecontent_1)
                                                    .SetFontSize(10))
                                    .SetBackgroundColor(cl_tablecontent_1)
                                    .SetBorderTop(Border.NO_BORDER)
                                    .SetBorderBottom(Border.NO_BORDER);


                                    cell4.SetTextAlignment(TextAlignment.LEFT)
                                    .Add(new Paragraph(period)
                                                   // .SetFont(ft_montserrat_reg)
                                                    .SetFixedLeading(14f)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tablecontent_1)
                                                    .SetFontSize(10))
                                    .SetBackgroundColor(cl_tablecontent_1)
                                    .SetBorderTop(Border.NO_BORDER)
                                    .SetBorderBottom(Border.NO_BORDER);

                                cell5.SetTextAlignment(TextAlignment.RIGHT)
                                    .Add(new Paragraph(string.Format("{0:N2}", activity.BaselineTechnical))
                                                   // .SetFont(ft_montserrat_reg)
                                                    .SetFixedLeading(14f)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tablecontent_1)
                                                    .SetFontSize(10))
                                    .SetBackgroundColor(cl_tablecontent_1)
                                    .SetBorderTop(Border.NO_BORDER)
                                    .SetBorderBottom(Border.NO_BORDER);

                                cell6.SetTextAlignment(TextAlignment.RIGHT)
                                    .Add(new Paragraph(string.Format("{0:N2}", activity.BaselineFinancial))
                                                   // .SetFont(ft_montserrat_reg)
                                                    .SetFixedLeading(14f)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tablecontent_1)
                                                    .SetFontSize(10))
                                    .SetBackgroundColor(cl_tablecontent_1)
                                    .SetBorderTop(Border.NO_BORDER)
                                    .SetBorderBottom(Border.NO_BORDER);


                                cell7.SetTextAlignment(TextAlignment.RIGHT)
                                    .Add(new Paragraph(string.Format("{0:N2}", activity.ActivityCost))
                                                   // .SetFont(ft_montserrat_reg)
                                                    .SetFixedLeading(14f)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tablecontent_1)
                                                    .SetFontSize(10))
                                    .SetBackgroundColor(cl_tablecontent_1)
                                    .SetBorderTop(Border.NO_BORDER)
                                    .SetBorderBottom(Border.NO_BORDER);

                                
                                cell7a.SetTextAlignment(TextAlignment.LEFT)
                                    .Add(new Paragraph(fundssource)
                                                   // .SetFont(ft_montserrat_reg)
                                                    .SetFixedLeading(14f)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tablecontent_1)
                                                    .SetFontSize(10))
                                    .SetBackgroundColor(cl_tablecontent_1)
                                    .SetBorderTop(Border.NO_BORDER)
                                    .SetBorderBottom(Border.NO_BORDER);

                            }
                            else
                            {
                                //Row Rows

                                cell1.SetTextAlignment(TextAlignment.JUSTIFIED)
                                    .Add(new Paragraph(activity.ActivityDescription)
                                                   // .SetFont(ft_montserrat_reg)
                                                    .SetFixedLeading(14f)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tablecontent_2)
                                                    .SetFontSize(10))
                                        .SetBackgroundColor(cl_tablecontent_2)
                                        .SetBorderTop(Border.NO_BORDER)
                                        .SetBorderBottom(Border.NO_BORDER);



                                cell2.SetTextAlignment(TextAlignment.LEFT)
                                    .Add(new Paragraph(_lkupActivityTypeRepository.GetActivityType(activity.ActivityType_Id).Activity_Name)
                                                   // .SetFont(ft_montserrat_reg)
                                                    .SetFixedLeading(14f)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tablecontent_2)
                                                    .SetFontSize(10))
                                    .SetBackgroundColor(cl_tablecontent_2)
                                    .SetBorderTop(Border.NO_BORDER)
                                    .SetBorderBottom(Border.NO_BORDER);

                                cell3.SetTextAlignment(TextAlignment.LEFT)
                                    .Add(new Paragraph(_lkupImplementationTypeRepository.GetRecord(activity.ImplementationType_Id).Record_Name)
                                                   // .SetFont(ft_montserrat_reg)
                                                    .SetFixedLeading(14f)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tablecontent_2)
                                                    .SetFontSize(10))
                                    .SetBackgroundColor(cl_tablecontent_2)
                                    .SetBorderTop(Border.NO_BORDER)
                                    .SetBorderBottom(Border.NO_BORDER);
    



                                cell4.SetTextAlignment(TextAlignment.LEFT)
                                    .Add(new Paragraph(period)
                                                   // .SetFont(ft_montserrat_reg)
                                                    .SetFixedLeading(14f)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tablecontent_2)
                                                    .SetFontSize(10))
                                    .SetBackgroundColor(cl_tablecontent_2)
                                    .SetBorderTop(Border.NO_BORDER)
                                    .SetBorderBottom(Border.NO_BORDER);

                                cell5.SetTextAlignment(TextAlignment.RIGHT)
                                    .Add(new Paragraph(string.Format("{0:N2}", activity.BaselineTechnical))
                                                    //.SetFont(ft_montserrat_reg)
                                                    .SetFixedLeading(14f)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tablecontent_2)
                                                    .SetFontSize(10))
                                    .SetBackgroundColor(cl_tablecontent_2)
                                    .SetBorderTop(Border.NO_BORDER)
                                    .SetBorderBottom(Border.NO_BORDER);

                                cell6.SetTextAlignment(TextAlignment.RIGHT)
                                    .Add(new Paragraph(string.Format("{0:N2}", activity.BaselineFinancial))
                                                    //.SetFont(ft_montserrat_reg)
                                                    .SetFixedLeading(14f)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tablecontent_2)
                                                    .SetFontSize(10))
                                    .SetBackgroundColor(cl_tablecontent_2)
                                    .SetBorderTop(Border.NO_BORDER)
                                    .SetBorderBottom(Border.NO_BORDER);

   


                                cell7.SetTextAlignment(TextAlignment.RIGHT)
                                    .Add(new Paragraph(string.Format("{0:N2}", activity.ActivityCost))
                                                    //.SetFont(ft_montserrat_reg)
                                                    .SetFixedLeading(14f)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tablecontent_2)
                                                    .SetFontSize(10))
                                    .SetBackgroundColor(cl_tablecontent_2)
                                    .SetBorderTop(Border.NO_BORDER)
                                    .SetBorderBottom(Border.NO_BORDER);


                                

                                cell7a.SetTextAlignment(TextAlignment.LEFT)
                                    .Add(new Paragraph(fundssource)
                                                    //.SetFont(ft_montserrat_reg)
                                                    .SetFixedLeading(14f)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tablecontent_2)
                                                    .SetFontSize(10))
                                    .SetBackgroundColor(cl_tablecontent_2)
                                    .SetBorderTop(Border.NO_BORDER)
                                    .SetBorderBottom(Border.NO_BORDER);
                                

                            }

                            row_alt=ToggleBoolean(row_alt);
                            if(inneriter==activitycount)
                            {
                                cell1.SetBorderBottom(new SolidBorder(1f));
                                cell2.SetBorderBottom(new SolidBorder(1f));
                                cell3.SetBorderBottom(new SolidBorder(1f));
                                cell4.SetBorderBottom(new SolidBorder(1f));
                                cell5.SetBorderBottom(new SolidBorder(1f));
                                cell6.SetBorderBottom(new SolidBorder(1f));
                                cell7.SetBorderBottom(new SolidBorder(1f));
                                cell7a.SetBorderBottom(new SolidBorder(1f));

                            }

                            tableactivity.AddCell(cell1);
                            tableactivity.AddCell(cell2);
                            tableactivity.AddCell(cell3);   
                            tableactivity.AddCell(cell4);
                            tableactivity.AddCell(cell5);
                            tableactivity.AddCell(cell6);
                            tableactivity.AddCell(cell7);
                            tableactivity.AddCell(cell7a);

                            

                        }

                        //Row WBS
                        if(recordset.WPSAPLink_Id!=null)
                        {
                            Cell cellheader0WBS = new Cell(1, 8)
                            .SetTextAlignment(TextAlignment.LEFT)
                            .Add(new Paragraph("SAP WBS: "+_wpSAPLinkRepository.GetRecord(recordset.WPSAPLink_Id).SAP_WBS+",  BTE: Baseline Technical Execution Rate,  BFE: Baseline Financial Execution Rate")
                                            .SetFont(ft_montserrat_reg_it)
                                            .SetFixedLeading(6f)
                                            .SetFontColor(cl_grayDark)
                                            .SetFontSize(8))
                                .SetBorderLeft(Border.NO_BORDER)
                                .SetBorderRight(Border.NO_BORDER)
                                .SetBorderBottom(Border.NO_BORDER)
                                .SetBorderTop(Border.NO_BORDER);

                            tableactivity.AddCell(cellheader0WBS);


                            

                           
                        }
                        else{
                            Cell cellheader0WBS = new Cell(1, 8)
                            .SetTextAlignment(TextAlignment.LEFT)
                            .Add(new Paragraph("SAP WBS: (SAP WBS Not Assigned to Output),  BTE: Baseline Technical Execution Rate,  BFE: Baseline Financial Execution Rate")
                                            .SetFont(ft_montserrat_reg_it)
                                            .SetFixedLeading(6f)
                                            .SetFontColor(cl_grayDark)
                                            .SetFontSize(8))
                                .SetBorderLeft(Border.NO_BORDER)
                                .SetBorderRight(Border.NO_BORDER)
                                .SetBorderBottom(Border.NO_BORDER)
                                .SetBorderTop(Border.NO_BORDER);

                            tableactivity.AddCell(cellheader0WBS);

                            


                        }

                        inneriter=0;
                        row_alt=true;
                        document.Add(tableactivity);

                       
                    }
                    else
                    {
                        /*
                        Paragraph outputtextnoact = new Paragraph("No Activity Recorded")
                        .SetTextAlignment(TextAlignment.LEFT)
                        .SetFont(ft_montserrat_reg)
                        .SetFixedLeading(9f)
                        .SetFontColor(cl_grayDark)
                        .SetMarginLeft(37)
                        .SetFontSize(9);
                        document.Add(outputtextnoact);*/

                    }


                    document.Add(txt);
                    document.Add(txt);
                    
                    
                    
                }

                document.Add(txt_gap);
                


                









            document.Close();
            return workStream;

        }


        public MemoryStream GetMemoryInstitutionalWorkplanDraft(WP_DispatchCycle cyclerec)
        {
            MemoryStream workStream = new MemoryStream();
            
            PdfWriter writer = new PdfWriter(workStream);
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf, PageSize.A3);
            int n = pdf.GetNumberOfPages();

            pdf.AddEventHandler(PdfDocumentEvent.END_PAGE, new NEPADStaffController.MyEventHandlerA3Portrait(this));

            document.SetBottomMargin(70);

            //PdfFontFactory.Register(@"wwwroot/reports/fonts/FaktSlabPro-Blond.ttf");Montserrat-ExtraBold Montserrat-Italic Montserrat-Light Montserrat-Bold Montserrat-Medium Montserrat-Italic
                string fontpath = @"wwwroot/reports/fonts/FaktSlabPro-Blond.ttf";
                string fontpath_montserrat_medium= @"wwwroot/reports/fonts/Montserrat-Medium.ttf";
                string fontpath_montserrat_bold= @"wwwroot/reports/fonts/Montserrat-Bold.ttf";
                string fontpath_montserrat_semibold= @"wwwroot/reports/fonts/Montserrat-SemiBold.ttf";
                string fontpath_montserrat_thick= @"wwwroot/reports/fonts/Montserrat-ExtraBold.ttf";
                string fontpath_montserrat_reg= @"wwwroot/reports/fonts/Montserrat-Regular.ttf";
                string fontpath_montserrat_reg_italic= @"wwwroot/reports/fonts/Montserrat-Italic.ttf";
                string fontpath_montserrat_light= @"wwwroot/reports/fonts/Montserrat-Light.ttf";
                string fontpath_materialicons_fonts= @"wwwroot/reports/fonts/MaterialIcons-Regular.ttf";
                string fontpath_helveticaneue= @"wwwroot/reports/fonts/HelveticaNeueLt.ttf";

                PdfFont ft = PdfFontFactory.CreateFont(fontpath, PdfEncodings.WINANSI, true);
                PdfFont ft_montserrat_medium = PdfFontFactory.CreateFont(fontpath_montserrat_medium, PdfEncodings.WINANSI, true);
                PdfFont ft_montserrat_semibold = PdfFontFactory.CreateFont(fontpath_montserrat_semibold, PdfEncodings.WINANSI, true);
                PdfFont ft_montserrat_bold = PdfFontFactory.CreateFont(fontpath_montserrat_bold, PdfEncodings.WINANSI, true);
                PdfFont ft_montserrat_thick = PdfFontFactory.CreateFont(fontpath_montserrat_thick, PdfEncodings.WINANSI, true);
                PdfFont ft_montserrat_reg = PdfFontFactory.CreateFont(fontpath_montserrat_reg, PdfEncodings.WINANSI, true);
                PdfFont ft_montserrat_reg_it = PdfFontFactory.CreateFont(fontpath_montserrat_reg_italic, PdfEncodings.WINANSI, true);
                PdfFont ft_montserrat_light= PdfFontFactory.CreateFont(fontpath_montserrat_light, PdfEncodings.WINANSI, true);
                PdfFont ft_materialicons_fonts= PdfFontFactory.CreateFont(fontpath_materialicons_fonts, "Identity-H", true);
                PdfFont ft_helveticaneue= PdfFontFactory.CreateFont(fontpath_helveticaneue, PdfEncodings.WINANSI, true);
                PdfFont ft_regular = PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFonts.HELVETICA);
                PdfFont ft_bold = PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFonts.HELVETICA_BOLD);Color cl=new DeviceRgb(18, 50, 89);
                
                Color cl_lightblue=new DeviceRgb(45, 80, 122);
                Color cl_green=new DeviceRgb(5, 71, 27);
                Color cl_gray=new DeviceRgb(132, 134, 135);
                Color cl_grayD=new DeviceRgb(98, 99, 99);
                Color cl_grayDark=new DeviceRgb(51, 52, 54);
                Color cl_white=new DeviceRgb(255, 255, 255);
                Color cl_red=new DeviceRgb(120, 60, 62);
                Color cl_tableheaderupper=new DeviceRgb(199, 198, 197);
                Color cl_tableheader=new DeviceRgb(219, 217, 215);
                Color cl_tableheaderblack=new DeviceRgb(0, 0, 0);
                Color cl_tableheaderblackdiv=new DeviceRgb(110, 109, 107);
                Color cl_tableheaderblackproj=new DeviceRgb(162, 162, 163);
                Color cl_tableheaderdarker=new DeviceRgb(82, 82, 82);
                Color cl_tablecontent1=new DeviceRgb(250, 245, 240);
                Color cl_tablecontent_1=new DeviceRgb(232, 233, 235);
                Color cl_tablecontent_2=new DeviceRgb(252, 252, 252);
                Color cl_tablecontent_22=new DeviceRgb(246, 246, 246);

               

                         // Add Logo
                Image img = new Image(ImageDataFactory
                    .Create(@"wwwroot/frontpage/images/logo-dark_for_reports.png"))
                    //.SetTextAlignment(TextAlignment.CENTER)
                    .SetHorizontalAlignment(HorizontalAlignment.CENTER)
                    .SetHeight(55)
                    .SetWidth(230);
                document.Add(img);

                Paragraph txt_gap=new Paragraph(new Text("\n"));
                Paragraph txt=new Paragraph(new Text(" "))
                                .SetFixedLeading(1f);

                document.Add(txt);

               

               
                
                SolidLine line = new SolidLine(0.5f);
                line.SetColor(cl_gray);
                LineSeparator ls = new LineSeparator(line);


                DottedLine dottedline = new DottedLine(0.5f);
                dottedline.SetColor(cl_gray);
                LineSeparator ls_dotted = new LineSeparator(dottedline);

                DashedLine dashedline = new DashedLine(0.5f);
                dashedline.SetColor(cl_gray);
                LineSeparator ls_dashed= new LineSeparator(dashedline);


                Paragraph header = new Paragraph("Integrated Planning and Reporting System"+ Convert.ToChar(174))
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetFont(ft)
                    .SetFontColor(cl)
                    .SetFontSize(16);
                    
                document.Add(header);


               // document.Add(txt);

           
                Paragraph sub_header = new Paragraph("Institutional Workplan (Draft)")
                    .SetFixedLeading(14f)
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetFont(ft_montserrat_thick)
                    
                    .SetFontColor(cl_gray)
                    .SetFontSize(14);
                document.Add(sub_header);
                document.Add(txt);




            string barcodestring="";
            WP_BarCodeIdents barcoderec=_wpBarCodeIdentsRepository.GetRecordByDispatchCycle(cyclerec.Transaction_Id);

            if(barcoderec!=null)
            {
                barcodestring=barcoderec.BarCode_Id;
            }
            else
            {
                barcodestring=RandomDigits(12);

                
                
                WP_BarCodeIdents rec_barcodeident_to_add = new WP_BarCodeIdents
                {
                    Transaction_Id = Guid.NewGuid().ToString(),
                    Institutional_Id = 99,
                    FiscalYear_Id=cyclerec.FiscalYear_Id,
                    Period_Id=cyclerec.Period_Id,
                    BarCode_Id=barcodestring,
                    DispatchCycle_Id=cyclerec.Transaction_Id,
                    PeriodStartDate=cyclerec.PeriodStartDate,
                    PeriodEndDate=cyclerec.PeriodEndDate,
                    TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                };
                _wpBarCodeIdentsRepository.Add(rec_barcodeident_to_add);

            }
            
            //Bar Code
            var bar = new BarcodeInter25(pdf);
            bar.SetCode(barcodestring);
           //bar.SetCode("000600123456");
   //Computing Total Budget for Project



            //Here's how to add barcode to PDF with IText7
            var barcodeImg = new Image(bar.CreateFormXObject(pdf))
                                .SetHorizontalAlignment(HorizontalAlignment.CENTER);
            document.Add(barcodeImg);   
            //document.Add(txt);

            //Get Period Name
            string periodname="";
            
            if(cyclerec.Period_Id==8)
            {
                DateTime pstart=new DateTime(cyclerec.PeriodStartDate.Year, cyclerec.PeriodStartDate.Month, cyclerec.PeriodStartDate.Day);
                DateTime pend=new DateTime(cyclerec.PeriodEndDate.Year, cyclerec.PeriodEndDate.Month, cyclerec.PeriodEndDate.Day);
                periodname=pstart.Date.ToString("MMM d, yyyy") + " - "+ pend.Date.ToString("MMM d, yyyy"); 
            }
            else
            {
                periodname=_lkupPeriodRepository.GetRecord(cyclerec.Period_Id).Record_Name;
            }


            var DB_Records = _transStrucDirectorateRepository.GetAllRecords().ToList();
            int _countrecs =  DB_Records.Count();
   
            double institutional_dp_budget=0;
            double institutional_ms_budget=0;
            double institutional_total_budget=0;
   
            if(_countrecs>0)
            {



                    foreach (var rec_set in DB_Records)
                    {
                        //**********Compute Total MS and DP Budgets of Institution***********// 
                        var DB_RecordsDivs=_transStrucDivisionRepository.GetAllRecordsByDirectorate(rec_set.Transaction_Id).ToList();


                        //Check if the division have any submission GetRecordsByDivRecs
                        foreach (var rec_div in DB_RecordsDivs)
                        {
                            var DivMainRecs=_wpMainRecordRepository.GetRecordsByDivRecs(rec_div.Division_Id).ToList();
                            //Fetch the Division Records that correspond the cycle 
                            if(cyclerec.Period_Id==8)
                            {
                                DivMainRecs=_wpMainRecordRepository.GetRecordsByDivisionYearAndPeriodStartEnd(rec_div.Division_Id, cyclerec.FiscalYear_Id,cyclerec.Period_Id, cyclerec.PeriodStartDate, cyclerec.PeriodEndDate).ToList();
                            }
                            else
                            {
                                DivMainRecs=_wpMainRecordRepository.GetRecordsByDivisionYearAndPeriod(rec_div.Division_Id, cyclerec.FiscalYear_Id,cyclerec.Period_Id).ToList();
                            }

                            foreach (var rec_proj_main in DivMainRecs)
                            {
                                var DB_ActivitiesRecs=_wpOutputActivitiesRepository.GetRecordsByMainRecordId(rec_proj_main.Transaction_Id).ToList();
                                foreach (var rec_proj_act in DB_ActivitiesRecs)
                                {
                                    institutional_total_budget=institutional_total_budget+rec_proj_act.ActivityCost;
                                
                                    if(rec_proj_act.PartnerFunding==true)
                                    {
                                        institutional_dp_budget=institutional_dp_budget+rec_proj_act.ActivityCost;
                                    }

                                }
                            }

                        }


                    }
                    institutional_ms_budget=institutional_total_budget-institutional_dp_budget;

            }

            //document.Add(txt);
                float subtractmargins=document.GetLeftMargin()+document.GetRightMargin();
                //Table table = new Table(2, false)
                Table table = new Table(UnitValue.CreatePercentArray(new float[]{12, 88}), false)
                .SetWidth(PageSize.A3.GetWidth()-subtractmargins)
                .SetHorizontalAlignment(HorizontalAlignment.LEFT);

                

                //Row 5
                Cell cell51 = new Cell(1, 1)
                  .SetTextAlignment(TextAlignment.LEFT)
                  .Add(new Paragraph("Year ")
                               // .SetFont(ft_montserrat_reg)
                                .SetFixedLeading(9f)
                                .SetFontSize(11))
                .SetBackgroundColor(cl_tableheader)
                  .SetBorderLeft(Border.NO_BORDER)
                    .SetBorderRight(Border.NO_BORDER)
                    .SetBorderBottom(Border.NO_BORDER);
               

               Cell cell52 = new Cell(1, 1)
                  .SetTextAlignment(TextAlignment.LEFT)
                  .Add(new Paragraph(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name)
                                .SetFont(ft_montserrat_reg)
                                .SetFixedLeading(9f)
                                .SetFontColor(cl_grayDark)
                                .SetFontSize(10))
                .SetBackgroundColor(cl_tablecontent_22)
                    .SetBorderLeft(Border.NO_BORDER)
                    .SetBorderRight(Border.NO_BORDER)
                    .SetBorderBottom(Border.NO_BORDER);
               


                //Row 6
                Cell cell61 = new Cell(1, 1)
                  .SetTextAlignment(TextAlignment.LEFT)
                  .Add(new Paragraph("Period ")
                               // .SetFont(ft_montserrat_reg)
                                .SetFixedLeading(9f)
                                .SetFontSize(11))
                .SetBackgroundColor(cl_tableheader)
                .SetBorderLeft(Border.NO_BORDER)
                .SetBorderRight(Border.NO_BORDER)
                .SetBorderTop(Border.NO_BORDER)
                .SetBorderBottom(Border.NO_BORDER);

               Cell cell62 = new Cell(1, 1)
                  .SetTextAlignment(TextAlignment.LEFT)
                  .Add(new Paragraph(periodname)
                                .SetFont(ft_montserrat_reg)
                                .SetFixedLeading(9f)
                                .SetFontColor(cl_grayDark)
                                .SetFontSize(10))
                .SetBackgroundColor(cl_tablecontent_22)
                .SetBorderLeft(Border.NO_BORDER)
                .SetBorderRight(Border.NO_BORDER)
                .SetBorderTop(Border.NO_BORDER)
                .SetBorderBottom(Border.NO_BORDER);

                //Row 7
                Cell cell71 = new Cell(1, 1)
                  .SetTextAlignment(TextAlignment.LEFT)
                  .Add(new Paragraph("Date ")
                                //.SetFont(ft_montserrat_reg)
                                .SetFixedLeading(9f)
                                .SetFontSize(11))
                .SetBackgroundColor(cl_tableheader)
                .SetBorderLeft(Border.NO_BORDER)
                .SetBorderRight(Border.NO_BORDER)
                .SetBorderTop(Border.NO_BORDER)
                .SetBorderBottom(Border.NO_BORDER);

               Cell cell72 = new Cell(1, 1)
                  .SetTextAlignment(TextAlignment.LEFT)
                  .Add(new Paragraph(DateTime.Now.Date.ToString("dd/MM/yyyy"))
                                .SetFont(ft_montserrat_reg)
                                .SetFixedLeading(9f)
                                .SetFontColor(cl_grayDark)
                                .SetFontSize(10))
                .SetBackgroundColor(cl_tablecontent_22)
                .SetBorderLeft(Border.NO_BORDER)
                .SetBorderRight(Border.NO_BORDER)
                .SetBorderTop(Border.NO_BORDER)
                .SetBorderBottom(Border.NO_BORDER);

                //Row 8a
                Cell cell81a = new Cell(1, 1)
                  .SetTextAlignment(TextAlignment.LEFT)
                  .Add(new Paragraph("MS Budget ")
                               // .SetFont(ft_montserrat_reg)
                                .SetFixedLeading(9f)
                                .SetFontSize(11))
                .SetBackgroundColor(cl_tableheader)
                .SetBorderLeft(Border.NO_BORDER)
                .SetBorderRight(Border.NO_BORDER)
                .SetBorderTop(Border.NO_BORDER)
                .SetBorderBottom(Border.NO_BORDER);

               Cell cell82a = new Cell(1, 1)
                  .SetTextAlignment(TextAlignment.LEFT)
                  .Add(new Paragraph("US$ "+string.Format("{0:N0}", institutional_ms_budget))
                                .SetFont(ft_montserrat_reg)
                                .SetFixedLeading(9f)
                                .SetFontColor(cl_grayDark)
                                .SetFontSize(10))
                .SetBackgroundColor(cl_tablecontent_22)
                .SetBorderLeft(Border.NO_BORDER)
                .SetBorderRight(Border.NO_BORDER)
                .SetBorderTop(Border.NO_BORDER)
                .SetBorderBottom(Border.NO_BORDER);


                //Row 8b
                Cell cell81b = new Cell(1, 1)
                  .SetTextAlignment(TextAlignment.LEFT)
                  .Add(new Paragraph("DP Budget ")
                               // .SetFont(ft_montserrat_reg)
                                .SetFixedLeading(9f)
                                .SetFontSize(11))
                .SetBackgroundColor(cl_tableheader)
                .SetBorderLeft(Border.NO_BORDER)
                .SetBorderRight(Border.NO_BORDER)
                .SetBorderTop(Border.NO_BORDER)
                .SetBorderBottom(Border.NO_BORDER);

               Cell cell82b = new Cell(1, 1)
                  .SetTextAlignment(TextAlignment.LEFT)
                  .Add(new Paragraph("US$ "+string.Format("{0:N0}", institutional_dp_budget))
                                .SetFont(ft_montserrat_reg)
                                .SetFixedLeading(9f)
                                .SetFontColor(cl_grayDark)
                                .SetFontSize(10))
                .SetBackgroundColor(cl_tablecontent_22)
                .SetBorderLeft(Border.NO_BORDER)
                .SetBorderRight(Border.NO_BORDER)
                .SetBorderTop(Border.NO_BORDER)
                .SetBorderBottom(Border.NO_BORDER);



                //Row 8
                Cell cell81 = new Cell(1, 1)
                  .SetTextAlignment(TextAlignment.LEFT)
                  .Add(new Paragraph("Total Budget ")
                               // .SetFont(ft_montserrat_reg)
                                .SetFixedLeading(9f)
                                .SetFontSize(11))
                .SetBackgroundColor(cl_tableheader)
                .SetBorderLeft(Border.NO_BORDER)
                .SetBorderRight(Border.NO_BORDER)
                .SetBorderTop(Border.NO_BORDER)
                .SetBorderBottom(Border.NO_BORDER);

               Cell cell82 = new Cell(1, 1)
                  .SetTextAlignment(TextAlignment.LEFT)
                  .Add(new Paragraph("US$ "+string.Format("{0:N0}", institutional_total_budget))
                                .SetFont(ft_montserrat_reg)
                                .SetFixedLeading(9f)
                                .SetFontColor(cl_grayDark)
                                .SetFontSize(10))
                .SetBackgroundColor(cl_tablecontent_22)
                .SetBorderLeft(Border.NO_BORDER)
                .SetBorderRight(Border.NO_BORDER)
                .SetBorderTop(Border.NO_BORDER)
                .SetBorderBottom(Border.NO_BORDER);





                //Row last
                Cell celllast1 = new Cell(1, 1)
                  .SetTextAlignment(TextAlignment.LEFT)
                  .Add(new Paragraph("Status ")
                               // .SetFont(ft_montserrat_reg)
                                .SetFixedLeading(12f)
                                .SetFontSize(11))
                .SetBackgroundColor(cl_tableheader)
                .SetBorderLeft(Border.NO_BORDER)
                .SetBorderRight(Border.NO_BORDER)
                .SetBorderTop(Border.NO_BORDER);

               Cell celllast2 = new Cell(1, 1)
                  .SetTextAlignment(TextAlignment.LEFT)
                  .Add(new Paragraph("Draft")
                                .SetFont(ft_montserrat_reg)
                                .SetFixedLeading(12f)
                                .SetFontColor(cl_grayDark)
                                //.SetFontColor(cl_red)
                                .SetFontSize(10))
                .SetBackgroundColor(cl_tablecontent_22)
                .SetBorderLeft(Border.NO_BORDER)
                .SetBorderRight(Border.NO_BORDER)
                .SetBorderTop(Border.NO_BORDER);


          

                table.AddCell(cell51);
               table.AddCell(cell52);

                table.AddCell(cell61);
               table.AddCell(cell62);

                table.AddCell(cell71);
               table.AddCell(cell72);

                table.AddCell(cell81a);
               table.AddCell(cell82a);

                table.AddCell(cell81b);
               table.AddCell(cell82b);

                table.AddCell(cell81);
               table.AddCell(cell82);


               table.AddCell(celllast1);
               table.AddCell(celllast2);


               document.Add(table);


               Paragraph printing_info = new Paragraph("Please, Print on A3 for Better Resolution")
						.SetTextAlignment(TextAlignment.CENTER)
						.SetFont(ft_montserrat_reg_it)
						.SetFontColor(cl_grayDark)
						.SetFontSize(8);
                document.Add(printing_info);



               //Shared Variables
                //int outeriter=0;
                int inneriter=0;
                bool row_alt=true;

                document.Add(txt_gap);

                Paragraph Summary_header = new Paragraph("Summary")
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetUnderline()
                    .SetFont(ft)
                    .SetFontColor(cl_green)
                    .SetFontSize(14);
                    
                document.Add(Summary_header);

                 document.Add(txt_gap);


                float indentmargin=document.GetLeftMargin()+0;
                Table tabledirectoratebudget = new Table(UnitValue.CreatePercentArray(new float[]{16, 16, 16, 16, 16, 20}), false)
                                        .SetWidth(PageSize.A3.GetWidth()-subtractmargins)
                                        .SetMarginLeft(0)
                                        .SetHorizontalAlignment(HorizontalAlignment.LEFT);



                if(_countrecs>=1)
                {
                    



                    //Row Header
                    Cell cellheader01 = new Cell(1, 1)
                    .SetTextAlignment(TextAlignment.LEFT)
                    .Add(new Paragraph("Directorate")
                                    .SetFont(ft_bold)
                                    .SetFixedLeading(14f)
                                    .SetFontColor(cl_white)
                                    .SetBackgroundColor(cl_tableheaderblack)
                                    .SetFontSize(10))
                        .SetBackgroundColor(cl_tableheaderblack);

                    tabledirectoratebudget.AddCell(cellheader01);

                    Cell cellheader02 = new Cell(1, 1)
                        .SetTextAlignment(TextAlignment.RIGHT)
                        .Add(new Paragraph("MS Budget (US$)")
                                        .SetFont(ft_bold)
                                        .SetFixedLeading(14f)
                                        .SetFontColor(cl_white)
                                        .SetBackgroundColor(cl_tableheaderblack)
                                        .SetFontSize(11))
                        .SetBackgroundColor(cl_tableheaderblack);
                    tabledirectoratebudget.AddCell(cellheader02);

                    Cell cellheader02b = new Cell(1, 1)
                        .SetTextAlignment(TextAlignment.RIGHT)
                        .Add(new Paragraph("PRC MS (US$)")
                                        .SetFont(ft_bold)
                                        .SetFixedLeading(14f)
                                        .SetFontColor(cl_white)
                                        .SetBackgroundColor(cl_tableheaderblack)
                                        .SetFontSize(10))
                        .SetBackgroundColor(cl_tableheaderblack);
                    tabledirectoratebudget.AddCell(cellheader02b);


                    Cell cellheader03 = new Cell(1, 1)
                        .SetTextAlignment(TextAlignment.RIGHT)
                        .Add(new Paragraph("DP Budget (US$)")
                                        .SetFont(ft_bold)
                                        .SetFixedLeading(14f)
                                        .SetFontColor(cl_white)
                                        .SetBackgroundColor(cl_tableheaderblack)
                                        .SetFontSize(10))
                        .SetBackgroundColor(cl_tableheaderblack);
                    tabledirectoratebudget.AddCell(cellheader03);

                    Cell cellheader04 = new Cell(1, 1)
                        .SetTextAlignment(TextAlignment.RIGHT)
                        .Add(new Paragraph("PRC DP (US$)")
                                        .SetFont(ft_bold)
                                        .SetFixedLeading(14f)
                                        .SetFontColor(cl_white)
                                        .SetBackgroundColor(cl_tableheaderblack)
                                        .SetFontSize(10))
                        .SetBackgroundColor(cl_tableheaderblack);
                    tabledirectoratebudget.AddCell(cellheader04);


                    Cell cellheader05 = new Cell(1, 1)
                        .SetTextAlignment(TextAlignment.RIGHT)
                        .Add(new Paragraph("Total Budget (US$)")
                                        .SetFont(ft_bold)
                                        .SetFixedLeading(14f)
                                        .SetFontColor(cl_white)
                                        .SetBackgroundColor(cl_tableheaderblack)
                                        .SetFontSize(10))
                        .SetBackgroundColor(cl_tableheaderblack);
                    tabledirectoratebudget.AddCell(cellheader05);


                    double grand_directorate_ms_budget=0;
                    double grand_directorate_ms_prc=0;
                    double grand_directorate_dp_budget=0;
                    double grand_directorate_dp_prc=0;
                    double grand_directorate_total_budget=0;


                    foreach (var rec_set in DB_Records)
                    {
                        //**********Compute Total MS and DP Budgets of Directorates***********// 

                        Struc_Directorate dir=_strucDirectorateRepository.GetRecord(rec_set.Record_Id);

                        var DB_RecordsDivs=_transStrucDivisionRepository.GetAllRecordsByDirectorate(rec_set.Transaction_Id).ToList();

                        double directorate_dp_budget=0;
                        double directorate_ms_budget=0;
                        double directorate_total_budget=0;
    
                        //Check if the division have any submission GetRecordsByDivRecs
                        foreach (var rec_div in DB_RecordsDivs)
                        {
                            var DivMainRecs=_wpMainRecordRepository.GetRecordsByDivRecs(rec_div.Division_Id).ToList();
                                                    //Fetch the Division Records that correspond the cycle 
                            if(cyclerec.Period_Id==8)
                            {
                                DivMainRecs=_wpMainRecordRepository.GetRecordsByDivisionYearAndPeriodStartEnd(rec_div.Division_Id, cyclerec.FiscalYear_Id,cyclerec.Period_Id, cyclerec.PeriodStartDate, cyclerec.PeriodEndDate).ToList();
                            }
                            else
                            {
                                DivMainRecs=_wpMainRecordRepository.GetRecordsByDivisionYearAndPeriod(rec_div.Division_Id, cyclerec.FiscalYear_Id,cyclerec.Period_Id).ToList();
                            }

                            foreach (var rec_proj_main in DivMainRecs)
                            {
                                var DB_ActivitiesRecs=_wpOutputActivitiesRepository.GetRecordsByMainRecordId(rec_proj_main.Transaction_Id).ToList();
                                foreach (var rec_proj_act in DB_ActivitiesRecs)
                                {
                                    directorate_total_budget=directorate_total_budget+rec_proj_act.ActivityCost;
                                    grand_directorate_total_budget=grand_directorate_total_budget+rec_proj_act.ActivityCost;
                                
                                    if(rec_proj_act.PartnerFunding==true)
                                    {
                                        directorate_dp_budget=directorate_dp_budget+rec_proj_act.ActivityCost;
                                        grand_directorate_dp_budget=grand_directorate_dp_budget+rec_proj_act.ActivityCost;
                                    }

                                }
                            }

                        }

                        directorate_ms_budget=directorate_total_budget-directorate_dp_budget;

                




                        //**********Retrieve  PRC Thresholds***********// 

                    // Retrieve PRC Thresholds  
            

                        WP_PRCBudgetLimits prccyclelimit=_wpPRCBudgetLimitsRepository.GetRecordByDirectorateAndCycle(rec_set.Record_Id,cyclerec.Transaction_Id);

                    
                        double directorate_dp_prc=0;//change this
                        double directorate_ms_prc=0;//change this 

                        if(prccyclelimit!=null)
                        {
                            directorate_dp_prc=prccyclelimit.DP_Limit;
                            grand_directorate_dp_prc=grand_directorate_dp_prc+prccyclelimit.DP_Limit;


                            directorate_ms_prc=prccyclelimit.MS_Limit;
                            grand_directorate_ms_prc=grand_directorate_ms_prc+prccyclelimit.MS_Limit;
                        }





                        inneriter=inneriter+1;

                        Cell cell1 = new Cell(1, 1);
                        Cell cell2 = new Cell(1, 1);
                        Cell cell2b = new Cell(1, 1);
                        Cell cell3 = new Cell(1, 1);
                        Cell cell4 = new Cell(1, 1);
                        Cell cell5 = new Cell(1, 1);



                        if(row_alt==false)
                        {
                            //Row Rows
                            cell1.SetTextAlignment(TextAlignment.JUSTIFIED)
                            .Add(new Paragraph(dir.AcronymName)
                                            //.SetFont(ft_montserrat_reg)
                                            .SetFixedLeading(14f)
                                            .SetFontColor(cl_grayDark)
                                            .SetBackgroundColor(cl_tablecontent_1)
                                            .SetFontSize(10))
                                .SetBackgroundColor(cl_tablecontent_1)
                                .SetBorderTop(Border.NO_BORDER)
                                .SetBorderBottom(Border.NO_BORDER);


                            
                                cell2.SetTextAlignment(TextAlignment.RIGHT)
                                .Add(new Paragraph(string.Format("{0:N0}", directorate_ms_budget))
                                                //.SetFont(ft_montserrat_reg)
                                                .SetFixedLeading(14f)
                                                .SetFontColor(cl_grayDark)
                                                .SetBackgroundColor(cl_tablecontent_1)
                                                .SetFontSize(10))
                                .SetBackgroundColor(cl_tablecontent_1)
                                .SetBorderTop(Border.NO_BORDER)
                                .SetBorderBottom(Border.NO_BORDER);

                                cell2b.SetTextAlignment(TextAlignment.RIGHT)
                                .Add(new Paragraph(string.Format("{0:N0}", directorate_ms_prc))
                                                //.SetFont(ft_montserrat_reg)
                                                .SetFixedLeading(14f)
                                                .SetFontColor(cl_grayDark)
                                                .SetBackgroundColor(cl_tablecontent_1)
                                                .SetFontSize(10))
                                .SetBackgroundColor(cl_tablecontent_1)
                                .SetBorderTop(Border.NO_BORDER)
                                .SetBorderBottom(Border.NO_BORDER);




                                cell3.SetTextAlignment(TextAlignment.RIGHT)
                                .Add(new Paragraph(string.Format("{0:N0}", directorate_dp_budget))
                                                // .SetFont(ft_montserrat_reg)
                                                .SetFixedLeading(14f)
                                                .SetFontColor(cl_grayDark)
                                                .SetBackgroundColor(cl_tablecontent_1)
                                                .SetFontSize(10))
                                .SetBackgroundColor(cl_tablecontent_1)
                                .SetBorderTop(Border.NO_BORDER)
                                .SetBorderBottom(Border.NO_BORDER);



                            cell4.SetTextAlignment(TextAlignment.RIGHT)
                                .Add(new Paragraph(string.Format("{0:N0}", directorate_dp_prc))
                                                // .SetFont(ft_montserrat_reg)
                                                .SetFixedLeading(14f)
                                                .SetFontColor(cl_grayDark)
                                                .SetBackgroundColor(cl_tablecontent_1)
                                                .SetFontSize(10))
                                .SetBackgroundColor(cl_tablecontent_1)
                                .SetBorderTop(Border.NO_BORDER)
                                .SetBorderBottom(Border.NO_BORDER);

                            cell5.SetTextAlignment(TextAlignment.RIGHT)
                                .Add(new Paragraph(string.Format("{0:N0}", directorate_total_budget))
                                                // .SetFont(ft_montserrat_reg)
                                                .SetFixedLeading(14f)
                                                .SetFontColor(cl_grayDark)
                                                .SetBackgroundColor(cl_tablecontent_1)
                                                .SetFontSize(10))
                                .SetBackgroundColor(cl_tablecontent_1)
                                .SetBorderTop(Border.NO_BORDER)
                                .SetBorderBottom(Border.NO_BORDER);

                        }
                        else
                        {
                            //Row Rows

                            cell1.SetTextAlignment(TextAlignment.JUSTIFIED)
                                .Add(new Paragraph(dir.AcronymName)
                                                // .SetFont(ft_montserrat_reg)
                                                .SetFixedLeading(14f)
                                                .SetFontColor(cl_grayDark)
                                                .SetBackgroundColor(cl_tablecontent_2)
                                                .SetFontSize(10))
                                    .SetBackgroundColor(cl_tablecontent_2)
                                    .SetBorderTop(Border.NO_BORDER)
                                    .SetBorderBottom(Border.NO_BORDER);



                            cell2.SetTextAlignment(TextAlignment.RIGHT)
                                .Add(new Paragraph(string.Format("{0:N0}", directorate_ms_budget))
                                                // .SetFont(ft_montserrat_reg)
                                                .SetFixedLeading(14f)
                                                .SetFontColor(cl_grayDark)
                                                .SetBackgroundColor(cl_tablecontent_2)
                                                .SetFontSize(10))
                                .SetBackgroundColor(cl_tablecontent_2)
                                .SetBorderTop(Border.NO_BORDER)
                                .SetBorderBottom(Border.NO_BORDER);

                            cell2b.SetTextAlignment(TextAlignment.RIGHT)
                                .Add(new Paragraph(string.Format("{0:N0}", directorate_ms_prc))
                                                // .SetFont(ft_montserrat_reg)
                                                .SetFixedLeading(14f)
                                                .SetFontColor(cl_grayDark)
                                                .SetBackgroundColor(cl_tablecontent_2)
                                                .SetFontSize(10))
                                .SetBackgroundColor(cl_tablecontent_2)
                                .SetBorderTop(Border.NO_BORDER)
                                .SetBorderBottom(Border.NO_BORDER);




                            cell3.SetTextAlignment(TextAlignment.RIGHT)
                                .Add(new Paragraph(string.Format("{0:N0}", directorate_dp_budget))
                                                // .SetFont(ft_montserrat_reg)
                                                .SetFixedLeading(14f)
                                                .SetFontColor(cl_grayDark)
                                                .SetBackgroundColor(cl_tablecontent_2)
                                                .SetFontSize(10))
                                .SetBackgroundColor(cl_tablecontent_2)
                                .SetBorderTop(Border.NO_BORDER)
                                .SetBorderBottom(Border.NO_BORDER);



                            cell4.SetTextAlignment(TextAlignment.RIGHT)
                                    .Add(new Paragraph(string.Format("{0:N0}", directorate_dp_prc))
                                                //.SetFont(ft_montserrat_reg)
                                                .SetFixedLeading(14f)
                                                .SetFontColor(cl_grayDark)
                                                .SetBackgroundColor(cl_tablecontent_2)
                                                .SetFontSize(10))
                                .SetBackgroundColor(cl_tablecontent_2)
                                .SetBorderTop(Border.NO_BORDER)
                                .SetBorderBottom(Border.NO_BORDER);

                            cell5.SetTextAlignment(TextAlignment.RIGHT)
                                    .Add(new Paragraph(string.Format("{0:N0}", directorate_total_budget))
                                                //.SetFont(ft_montserrat_reg)
                                                .SetFixedLeading(14f)
                                                .SetFontColor(cl_grayDark)
                                                .SetBackgroundColor(cl_tablecontent_2)
                                                .SetFontSize(10))
                                .SetBackgroundColor(cl_tablecontent_2)
                                .SetBorderTop(Border.NO_BORDER)
                                .SetBorderBottom(Border.NO_BORDER);
                            

                        }

                        row_alt=ToggleBoolean(row_alt);
                        if(inneriter==_countrecs)
                        {
                            cell1.SetBorderBottom(new SolidBorder(1f));
                            cell2.SetBorderBottom(new SolidBorder(1f));
                            cell2b.SetBorderBottom(new SolidBorder(1f));
                            cell3.SetBorderBottom(new SolidBorder(1f));
                            cell4.SetBorderBottom(new SolidBorder(1f));
                            cell5.SetBorderBottom(new SolidBorder(1f));

                        }

                        tabledirectoratebudget.AddCell(cell1);
                        tabledirectoratebudget.AddCell(cell2);
                        tabledirectoratebudget.AddCell(cell2b);
                        tabledirectoratebudget.AddCell(cell3);   
                        tabledirectoratebudget.AddCell(cell4);
                        tabledirectoratebudget.AddCell(cell5);




    

                    }

                    grand_directorate_ms_budget=grand_directorate_total_budget-grand_directorate_dp_budget;


                     //Total Footer
                    Cell cellheader01t = new Cell(1, 1)
                    .SetTextAlignment(TextAlignment.LEFT)
                    .Add(new Paragraph("TOTAL")
                                   // .SetFont(ft_bold)
                                    .SetFixedLeading(14f)
                                    .SetFontColor(cl_white)
                                    .SetBackgroundColor(cl_tableheaderdarker)
                                    .SetFontSize(10))
                        .SetBorderBottom(new SolidBorder(1f))
                        .SetBackgroundColor(cl_tableheaderdarker);

                    tabledirectoratebudget.AddCell(cellheader01t);

                    Cell cellheader02t = new Cell(1, 1)
                        .SetTextAlignment(TextAlignment.RIGHT)
                        .Add(new Paragraph(string.Format("{0:N0}", grand_directorate_ms_budget))
                                      //  .SetFont(ft_bold)
                                        .SetFixedLeading(14f)
                                        .SetFontColor(cl_white)
                                        .SetBackgroundColor(cl_tableheaderdarker)
                                        .SetFontSize(11))
                        .SetBorderBottom(new SolidBorder(1f))
                        .SetBackgroundColor(cl_tableheaderdarker);
                    tabledirectoratebudget.AddCell(cellheader02t);

                    Cell cellheader02bt = new Cell(1, 1)
                        .SetTextAlignment(TextAlignment.RIGHT)
                        .Add(new Paragraph(string.Format("{0:N0}", grand_directorate_ms_prc))
                                       // .SetFont(ft_bold)
                                        .SetFixedLeading(14f)
                                        .SetFontColor(cl_white)
                                        .SetBackgroundColor(cl_tableheaderdarker)
                                        .SetFontSize(10))
                        .SetBorderBottom(new SolidBorder(1f))
                        .SetBackgroundColor(cl_tableheaderdarker);
                    tabledirectoratebudget.AddCell(cellheader02bt);


                    Cell cellheader03t = new Cell(1, 1)
                        .SetTextAlignment(TextAlignment.RIGHT)
                        .Add(new Paragraph(string.Format("{0:N0}", grand_directorate_dp_budget))
                                       // .SetFont(ft_bold)
                                        .SetFixedLeading(14f)
                                        .SetFontColor(cl_white)
                                        .SetBackgroundColor(cl_tableheaderdarker)
                                        .SetFontSize(10))
                        .SetBorderBottom(new SolidBorder(1f))
                        .SetBackgroundColor(cl_tableheaderdarker);
                    tabledirectoratebudget.AddCell(cellheader03t);

                    Cell cellheader04t = new Cell(1, 1)
                        .SetTextAlignment(TextAlignment.RIGHT)
                        .Add(new Paragraph(string.Format("{0:N0}", grand_directorate_dp_prc))
                                       // .SetFont(ft_bold)
                                        .SetFixedLeading(14f)
                                        .SetFontColor(cl_white)
                                        .SetBackgroundColor(cl_tableheaderdarker)
                                        .SetFontSize(10))
                        .SetBorderBottom(new SolidBorder(1f))
                        .SetBackgroundColor(cl_tableheaderdarker);
                    tabledirectoratebudget.AddCell(cellheader04t);


                    Cell cellheader05t = new Cell(1, 1)
                        .SetTextAlignment(TextAlignment.RIGHT)
                        .Add(new Paragraph(string.Format("{0:N0}", grand_directorate_total_budget))
                                        //.SetFont(ft_bold)
                                        .SetFixedLeading(14f)
                                        .SetFontColor(cl_white)
                                        .SetBackgroundColor(cl_tableheaderdarker)
                                        .SetFontSize(10))
                        .SetBorderBottom(new SolidBorder(1f))
                        .SetBackgroundColor(cl_tableheaderdarker);
                    tabledirectoratebudget.AddCell(cellheader05t);



                    inneriter=0;
                    row_alt=true;
                    document.Add(tabledirectoratebudget);

                }

                document.Add(txt_gap);

                Table table1stgraph = new Table(UnitValue.CreatePercentArray(new float[]{50, 50}), false)
                            .SetWidth(PageSize.A3.GetWidth()-subtractmargins)
                            .SetMarginLeft(0)
                            .SetHorizontalAlignment(HorizontalAlignment.LEFT);



                Image img11 = new Image(ImageDataFactory
                        .Create(@"wwwroot/appdirectory/pdfreports/institutional/"+cyclerec.Transaction_Id+"Complete.png"))
                        //.SetTextAlignment(TextAlignment.CENTER)
                        .SetHorizontalAlignment(HorizontalAlignment.CENTER)
                       // .SetBorder(new SolidBorder(1f))
                        .SetAutoScale(true);
                        //.SetHeight(270)
                    // .SetWidth(370);
                Image img12 = new Image(ImageDataFactory
                .Create(@"wwwroot/appdirectory/pdfreports/institutional/"+cyclerec.Transaction_Id+"PRC.png"))
                        //.SetTextAlignment(TextAlignment.CENTER)
                        
                        .SetHorizontalAlignment(HorizontalAlignment.CENTER)
                     //   .SetBorder(new SolidBorder(1f))
                        .SetAutoScale(true);
            
                //Add title
                Cell celltitle11 = new Cell(1, 1)
                    .SetTextAlignment(TextAlignment.CENTER)
                    .Add(new Paragraph("Completion Level of Workplans By Directorate")
                                    // .SetFont(ft_bold)
                                    .SetFixedLeading(14f)
                                // .SetFontColor(cl_white)
                                    .SetFontSize(10))
                    .SetBorderTop(Border.NO_BORDER)
                    .SetBorderLeft(Border.NO_BORDER)
                    .SetBorderRight(Border.NO_BORDER)
                    .SetBorderBottom(Border.NO_BORDER);
                table1stgraph.AddCell(celltitle11);


                Cell celltitle12 = new Cell(1, 1)
                    .SetTextAlignment(TextAlignment.CENTER)
                    .Add(new Paragraph("Approved PRC Budget")
                                    // .SetFont(ft_bold)
                                    .SetFixedLeading(14f)
                                // .SetFontColor(cl_white)
                                    .SetFontSize(10))
                    .SetBorderTop(Border.NO_BORDER)
                    .SetBorderLeft(Border.NO_BORDER)
                    .SetBorderRight(Border.NO_BORDER)
                    .SetBorderBottom(Border.NO_BORDER);
                table1stgraph.AddCell(celltitle12);



                    
                        Cell cellgraph101 = new Cell(1, 1)
                        .Add(img11)
                        .SetBorderTop(Border.NO_BORDER)
                    .SetBorderLeft(Border.NO_BORDER)
                    .SetBorderRight(Border.NO_BORDER)
                    .SetBorderBottom(Border.NO_BORDER);
                        table1stgraph.AddCell(cellgraph101);

                Cell cellgraph102 = new Cell(1, 1)
                    .Add(img12)
                    .SetBorderTop(Border.NO_BORDER)
                    .SetBorderLeft(Border.NO_BORDER)
                    .SetBorderRight(Border.NO_BORDER)
                    .SetBorderBottom(Border.NO_BORDER);
                table1stgraph.AddCell(cellgraph102);

                document.Add(table1stgraph);


                document.Add(txt_gap);
                document.Add(txt_gap);


                Table table2ndgraph = new Table(UnitValue.CreatePercentArray(new float[]{50, 50}), false)
                    .SetWidth(PageSize.A3.GetWidth()-subtractmargins)
                    .SetMarginLeft(0)
                    .SetHorizontalAlignment(HorizontalAlignment.LEFT);



                Image img21 = new Image(ImageDataFactory
                        .Create(@"wwwroot/appdirectory/pdfreports/institutional/"+cyclerec.Transaction_Id+"MTPContr.png"))
                        //.SetTextAlignment(TextAlignment.CENTER)
                        .SetHorizontalAlignment(HorizontalAlignment.CENTER)
                     //   .SetBorder(new SolidBorder(1f))
                        .SetAutoScale(true);
                        //.SetHeight(270)
                    // .SetWidth(370);
                Image img22 = new Image(ImageDataFactory
                .Create(@"wwwroot/appdirectory/pdfreports/institutional/"+cyclerec.Transaction_Id+"MTPContrDir.png"))
                        //.SetTextAlignment(TextAlignment.CENTER)
                        
                        .SetHorizontalAlignment(HorizontalAlignment.CENTER)
                    
                       // .SetBorder(new SolidBorder(1f))
                        .SetAutoScale(true);
            
                //Add title
                Cell celltitle21 = new Cell(1, 1)
                    .SetTextAlignment(TextAlignment.CENTER)
                    .Add(new Paragraph("Distribution of Contributions to MTP Priorities")
                                    // .SetFont(ft_bold)
                                    .SetFixedLeading(14f)
                                // .SetFontColor(cl_white)
                                    .SetFontSize(10))
                    .SetBorderTop(Border.NO_BORDER)
                    .SetBorderLeft(Border.NO_BORDER)
                    .SetBorderRight(Border.NO_BORDER)
                    .SetBorderBottom(Border.NO_BORDER);
                table2ndgraph.AddCell(celltitle21);


                Cell celltitle22 = new Cell(1, 1)
                    .SetTextAlignment(TextAlignment.CENTER)
                    .Add(new Paragraph("Contributions to MTP Priorities by Directorates")
                                    // .SetFont(ft_bold)
                                    .SetFixedLeading(14f)
                                // .SetFontColor(cl_white)
                                    .SetFontSize(10))
                    .SetBorderTop(Border.NO_BORDER)
                    .SetBorderLeft(Border.NO_BORDER)
                    .SetBorderRight(Border.NO_BORDER)
                    .SetBorderBottom(Border.NO_BORDER);
                table2ndgraph.AddCell(celltitle22);



                    
                Cell cellgraph201 = new Cell(1, 1)
                    .Add(img21)
                    .SetBorderTop(Border.NO_BORDER)
                    .SetBorderLeft(Border.NO_BORDER)
                    .SetBorderRight(Border.NO_BORDER)
                    .SetBorderBottom(Border.NO_BORDER);
                table2ndgraph.AddCell(cellgraph201);

                Cell cellgraph202 = new Cell(1, 1)
                    .Add(img22)
                    .SetBorderTop(Border.NO_BORDER)
                    .SetBorderLeft(Border.NO_BORDER)
                    .SetBorderRight(Border.NO_BORDER)
                    .SetBorderBottom(Border.NO_BORDER);
                table2ndgraph.AddCell(cellgraph202);

                document.Add(table2ndgraph);


                document.Add(txt_gap);

                Table table3rdgraph = new Table(UnitValue.CreatePercentArray(new float[]{50, 50}), false)
                    .SetWidth(PageSize.A3.GetWidth()-subtractmargins)
                    .SetMarginLeft(0)
                    .SetHorizontalAlignment(HorizontalAlignment.LEFT);



                Image img31 = new Image(ImageDataFactory
                        .Create(@"wwwroot/appdirectory/pdfreports/institutional/"+cyclerec.Transaction_Id+"StraContr.png"))
                        //.SetTextAlignment(TextAlignment.CENTER)
                        .SetHorizontalAlignment(HorizontalAlignment.CENTER)
                     //   .SetBorder(new SolidBorder(1f))
                        .SetAutoScale(true);
                        //.SetHeight(270)
                    // .SetWidth(370);
                Image img32 = new Image(ImageDataFactory
                .Create(@"wwwroot/appdirectory/pdfreports/institutional/"+cyclerec.Transaction_Id+"StraContrDir.png"))
                        //.SetTextAlignment(TextAlignment.CENTER)
                        
                        .SetHorizontalAlignment(HorizontalAlignment.CENTER)
                    
                       // .SetBorder(new SolidBorder(1f))
                        .SetAutoScale(true);
            
                //Add title
                Cell celltitle31 = new Cell(1, 1)
                    .SetTextAlignment(TextAlignment.CENTER)
                    .Add(new Paragraph("Distribution of Contributions to Strategic Priorities")
                                    // .SetFont(ft_bold)
                                    .SetFixedLeading(14f)
                                // .SetFontColor(cl_white)
                                    .SetFontSize(10))
                    .SetBorderTop(Border.NO_BORDER)
                    .SetBorderLeft(Border.NO_BORDER)
                    .SetBorderRight(Border.NO_BORDER)
                    .SetBorderBottom(Border.NO_BORDER);
                table3rdgraph.AddCell(celltitle31);


                Cell celltitle32 = new Cell(1, 1)
                    .SetTextAlignment(TextAlignment.CENTER)
                    .Add(new Paragraph("Contributions to Strategic Priorities by Directorates")
                                    // .SetFont(ft_bold)
                                    .SetFixedLeading(14f)
                                // .SetFontColor(cl_white)
                                    .SetFontSize(10))
                    .SetBorderTop(Border.NO_BORDER)
                    .SetBorderLeft(Border.NO_BORDER)
                    .SetBorderRight(Border.NO_BORDER)
                    .SetBorderBottom(Border.NO_BORDER);
                table3rdgraph.AddCell(celltitle32);



                    
                Cell cellgraph301 = new Cell(1, 1)
                    .Add(img31)
                    .SetBorderTop(Border.NO_BORDER)
                    .SetBorderLeft(Border.NO_BORDER)
                    .SetBorderRight(Border.NO_BORDER)
                    .SetBorderBottom(Border.NO_BORDER);
                table3rdgraph.AddCell(cellgraph301);

                Cell cellgraph302 = new Cell(1, 1)
                    .Add(img32)
                    .SetBorderTop(Border.NO_BORDER)
                    .SetBorderLeft(Border.NO_BORDER)
                    .SetBorderRight(Border.NO_BORDER)
                    .SetBorderBottom(Border.NO_BORDER);
                table3rdgraph.AddCell(cellgraph302);

                document.Add(table3rdgraph);


                document.Add(txt_gap);
                document.Add(txt_gap);


                 Table table4thgraph = new Table(UnitValue.CreatePercentArray(new float[]{50, 50}), false)
                    .SetWidth(PageSize.A3.GetWidth()-subtractmargins)
                    .SetMarginLeft(0)
                    .SetHorizontalAlignment(HorizontalAlignment.LEFT);



                Image img41 = new Image(ImageDataFactory
                        .Create(@"wwwroot/appdirectory/pdfreports/institutional/"+cyclerec.Transaction_Id+"ImpDistr.png"))
                        //.SetTextAlignment(TextAlignment.CENTER)
                        .SetHorizontalAlignment(HorizontalAlignment.CENTER)
                     //   .SetBorder(new SolidBorder(1f))
                        .SetAutoScale(true);
                        //.SetHeight(270)
                    // .SetWidth(370);
                Image img42 = new Image(ImageDataFactory
                .Create(@"wwwroot/appdirectory/pdfreports/institutional/"+cyclerec.Transaction_Id+"NewProj.png"))
                        //.SetTextAlignment(TextAlignment.CENTER)
                        
                        .SetHorizontalAlignment(HorizontalAlignment.CENTER)
                    
                       // .SetBorder(new SolidBorder(1f))
                        .SetAutoScale(true);
            
                //Add title
                Cell celltitle41 = new Cell(1, 1)
                    .SetTextAlignment(TextAlignment.CENTER)
                    .Add(new Paragraph("Distribution of Implementation Type")
                                    // .SetFont(ft_bold)
                                    .SetFixedLeading(14f)
                                // .SetFontColor(cl_white)
                                    .SetFontSize(10))
                    .SetBorderTop(Border.NO_BORDER)
                    .SetBorderLeft(Border.NO_BORDER)
                    .SetBorderRight(Border.NO_BORDER)
                    .SetBorderBottom(Border.NO_BORDER);
                table4thgraph.AddCell(celltitle41);


                Cell celltitle42 = new Cell(1, 1)
                    .SetTextAlignment(TextAlignment.CENTER)
                    .Add(new Paragraph("Existing and New Projects for "+ _lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name+" ("+periodname+")")
                                    // .SetFont(ft_bold)
                                    .SetFixedLeading(14f)
                                // .SetFontColor(cl_white)
                                    .SetFontSize(10))
                    .SetBorderTop(Border.NO_BORDER)
                    .SetBorderLeft(Border.NO_BORDER)
                    .SetBorderRight(Border.NO_BORDER)
                    .SetBorderBottom(Border.NO_BORDER);
                table4thgraph.AddCell(celltitle42);



                    
                Cell cellgraph401 = new Cell(1, 1)
                    .Add(img41)
                    .SetBorderTop(Border.NO_BORDER)
                    .SetBorderLeft(Border.NO_BORDER)
                    .SetBorderRight(Border.NO_BORDER)
                    .SetBorderBottom(Border.NO_BORDER);
                table4thgraph.AddCell(cellgraph401);

                Cell cellgraph402 = new Cell(1, 1)
                    .Add(img42)
                    .SetBorderTop(Border.NO_BORDER)
                    .SetBorderLeft(Border.NO_BORDER)
                    .SetBorderRight(Border.NO_BORDER)
                    .SetBorderBottom(Border.NO_BORDER);
                table4thgraph.AddCell(cellgraph402);

                document.Add(table4thgraph);

                document.Add(txt_gap);
                document.Add(txt_gap);

    
                Table tabledirectoratecountriesrecs = new Table(UnitValue.CreatePercentArray(new float[]{10, 12, 40, 38}), false)
                                        .SetWidth(PageSize.A3.GetWidth()-subtractmargins)
                                        .SetMarginLeft(0)
                                        .SetHorizontalAlignment(HorizontalAlignment.LEFT);


                if(_countrecs>=1)
                {
                    



                    //Row Header
                    Cell cellheader01 = new Cell(1, 1)
                    .SetTextAlignment(TextAlignment.LEFT)
                    .Add(new Paragraph("Directorate")
                                    .SetFont(ft_bold)
                                    .SetFixedLeading(14f)
                                    .SetFontColor(cl_white)
                                    .SetBackgroundColor(cl_tableheaderblack)
                                    .SetFontSize(10))
                        .SetBackgroundColor(cl_tableheaderblack);

                    tabledirectoratecountriesrecs.AddCell(cellheader01);

                    Cell cellheader02 = new Cell(1, 1)
                        .SetTextAlignment(TextAlignment.CENTER)
                        .Add(new Paragraph("No. of Projects")
                                        .SetFont(ft_bold)
                                        .SetFixedLeading(14f)
                                        .SetFontColor(cl_white)
                                        .SetBackgroundColor(cl_tableheaderblack)
                                        .SetFontSize(11))
                        .SetBackgroundColor(cl_tableheaderblack);
                    tabledirectoratecountriesrecs.AddCell(cellheader02);

                    Cell cellheader02b = new Cell(1, 1)
                        .SetTextAlignment(TextAlignment.LEFT)
                        .Add(new Paragraph("Will Be Implemented in MS...")
                                        .SetFont(ft_bold)
                                        .SetFixedLeading(14f)
                                        .SetFontColor(cl_white)
                                        .SetBackgroundColor(cl_tableheaderblack)
                                        .SetFontSize(10))
                        .SetBackgroundColor(cl_tableheaderblack);
                    tabledirectoratecountriesrecs.AddCell(cellheader02b);


                    Cell cellheader03 = new Cell(1, 1)
                        .SetTextAlignment(TextAlignment.LEFT)
                        .Add(new Paragraph("Will Be Implemented in RECs...")
                                        .SetFont(ft_bold)
                                        .SetFixedLeading(14f)
                                        .SetFontColor(cl_white)
                                        .SetBackgroundColor(cl_tableheaderblack)
                                        .SetFontSize(10))
                        .SetBackgroundColor(cl_tableheaderblack);
                    tabledirectoratecountriesrecs.AddCell(cellheader03);
                        


                    foreach (var rec_set in DB_Records)
                    {
                        //**********Compute Total MS and DP Budgets of Directorates***********// 

                        Struc_Directorate dir=_strucDirectorateRepository.GetRecord(rec_set.Record_Id);

                        var DB_RecordsDivs=_transStrucDivisionRepository.GetAllRecordsByDirectorate(rec_set.Transaction_Id).ToList();

                        double directorate_total_projects=0;
                        string rtnstringCountries = string.Empty;
                        string rtnstringRECs = string.Empty;

                        int _countint =  DB_RecordsDivs.Count();
                        int inntercount=0;
                        
    
    
                        //Check if the division have any submission GetRecordsByDivRecs
                        foreach (var rec_div in DB_RecordsDivs)
                        {
                            inntercount=inntercount+1;
                            var DivMainRecs=_wpMainRecordRepository.GetRecordsByDivRecs(rec_div.Division_Id).ToList();
                                                    //Fetch the Division Records that correspond the cycle 
                            if(cyclerec.Period_Id==8)
                            {
                                DivMainRecs=_wpMainRecordRepository.GetRecordsByDivisionYearAndPeriodStartEnd(rec_div.Division_Id, cyclerec.FiscalYear_Id,cyclerec.Period_Id, cyclerec.PeriodStartDate, cyclerec.PeriodEndDate).ToList();
                            }
                            else
                            {
                                DivMainRecs=_wpMainRecordRepository.GetRecordsByDivisionYearAndPeriod(rec_div.Division_Id, cyclerec.FiscalYear_Id,cyclerec.Period_Id).ToList();
                            }

           
                            directorate_total_projects=directorate_total_projects+DivMainRecs.Count();
                  


                            foreach (var mainrec in DivMainRecs)
                            {
                                var DB_CountryScopeRecs=_wpCountryScopeRepository.GetRecordsByMainRecordId(mainrec.Transaction_Id).GroupBy(x => x.Country_Id).Select(x => x.First()).ToList();
                                var DB_RECScopeRecs=_wpRegionScopeRepository.GetRecordsByMainRecordId(mainrec.Transaction_Id).GroupBy(x => x.Region_Id).Select(x => x.First()).ToList();

                               //inntercount=inntercount+1;

                                int _countrycount=DB_CountryScopeRecs.Count();
                                int _reccount=DB_RECScopeRecs.Count();

                                int _countryinter=0;
                                int _recinter=0;

                                foreach(var countryrec in DB_CountryScopeRecs)
                                {
                                    LkUp_Country country=_lkupCountryRepository.GetCountry(countryrec.Country_Id);
                                    _countryinter=_countryinter+1;
                                    
                                    if((inntercount==_countint) &&(_countryinter==_countrycount))
                                    {
                                        rtnstringCountries += country.Country_Name.TrimEnd();  
                                    }
                                    else
                                    {
                                        rtnstringCountries += country.Country_Name.TrimEnd()+", ";  

                                    }

                                }


                                foreach(var recrec in DB_RECScopeRecs)
                                {
                                    LkUp_RegionScope region=_lkupRegionScopeRepository.GetRecord(recrec.Region_Id);
                                    _recinter=_recinter+1;
                                    
                                    if((inntercount==_countint) &&(_recinter==_reccount))
                                    {
                                        rtnstringRECs += region.Record_Name.TrimEnd();  
                                    }
                                    else
                                    {
                                        rtnstringRECs += region.Record_Name.TrimEnd()+", ";  

                                    }

                                }


                            }


                            

                        }

          





                        inneriter=inneriter+1;

                        Cell cell1 = new Cell(1, 1);
                        Cell cell2 = new Cell(1, 1);
                        Cell cell2b = new Cell(1, 1);
                        Cell cell3 = new Cell(1, 1);




                        if(row_alt==false)
                        {
                            //Row Rows
                            cell1.SetTextAlignment(TextAlignment.JUSTIFIED)
                            .Add(new Paragraph(dir.AcronymName)
                                            //.SetFont(ft_montserrat_reg)
                                            .SetFixedLeading(14f)
                                            .SetFontColor(cl_grayDark)
                                            .SetBackgroundColor(cl_tablecontent_1)
                                            .SetFontSize(10))
                                .SetBackgroundColor(cl_tablecontent_1)
                                .SetBorderTop(Border.NO_BORDER)
                                .SetBorderBottom(Border.NO_BORDER);


                            
                                cell2.SetTextAlignment(TextAlignment.CENTER)
                                .Add(new Paragraph(directorate_total_projects.ToString())
                                                //.SetFont(ft_montserrat_reg)
                                                .SetFixedLeading(14f)
                                                .SetFontColor(cl_grayDark)
                                                .SetBackgroundColor(cl_tablecontent_1)
                                                .SetFontSize(10))
                                .SetBackgroundColor(cl_tablecontent_1)
                                .SetBorderTop(Border.NO_BORDER)
                                .SetBorderBottom(Border.NO_BORDER);

                                cell2b.SetTextAlignment(TextAlignment.LEFT)
                                .Add(new Paragraph(rtnstringCountries)
                                                //.SetFont(ft_montserrat_reg)
                                                .SetFixedLeading(14f)
                                                .SetFontColor(cl_grayDark)
                                                .SetBackgroundColor(cl_tablecontent_1)
                                                .SetFontSize(10))
                                .SetBackgroundColor(cl_tablecontent_1)
                                .SetBorderTop(Border.NO_BORDER)
                                .SetBorderBottom(Border.NO_BORDER);




                                cell3.SetTextAlignment(TextAlignment.LEFT)
                                .Add(new Paragraph(rtnstringRECs)
                                                // .SetFont(ft_montserrat_reg)
                                                .SetFixedLeading(14f)
                                                .SetFontColor(cl_grayDark)
                                                .SetBackgroundColor(cl_tablecontent_1)
                                                .SetFontSize(10))
                                .SetBackgroundColor(cl_tablecontent_1)
                                .SetBorderTop(Border.NO_BORDER)
                                .SetBorderBottom(Border.NO_BORDER);

                        }
                        else
                        {
                            //Row Rows

                            cell1.SetTextAlignment(TextAlignment.JUSTIFIED)
                                .Add(new Paragraph(dir.AcronymName)
                                                // .SetFont(ft_montserrat_reg)
                                                .SetFixedLeading(14f)
                                                .SetFontColor(cl_grayDark)
                                                .SetBackgroundColor(cl_tablecontent_2)
                                                .SetFontSize(10))
                                    .SetBackgroundColor(cl_tablecontent_2)
                                    .SetBorderTop(Border.NO_BORDER)
                                    .SetBorderBottom(Border.NO_BORDER);



                            cell2.SetTextAlignment(TextAlignment.CENTER)
                                .Add(new Paragraph(directorate_total_projects.ToString())
                                                // .SetFont(ft_montserrat_reg)
                                                .SetFixedLeading(14f)
                                                .SetFontColor(cl_grayDark)
                                                .SetBackgroundColor(cl_tablecontent_2)
                                                .SetFontSize(10))
                                .SetBackgroundColor(cl_tablecontent_2)
                                .SetBorderTop(Border.NO_BORDER)
                                .SetBorderBottom(Border.NO_BORDER);

                            cell2b.SetTextAlignment(TextAlignment.LEFT)
                                .Add(new Paragraph(rtnstringCountries)
                                                // .SetFont(ft_montserrat_reg)
                                                .SetFixedLeading(14f)
                                                .SetFontColor(cl_grayDark)
                                                .SetBackgroundColor(cl_tablecontent_2)
                                                .SetFontSize(10))
                                .SetBackgroundColor(cl_tablecontent_2)
                                .SetBorderTop(Border.NO_BORDER)
                                .SetBorderBottom(Border.NO_BORDER);




                            cell3.SetTextAlignment(TextAlignment.LEFT)
                                .Add(new Paragraph(rtnstringRECs)
                                                // .SetFont(ft_montserrat_reg)
                                                .SetFixedLeading(14f)
                                                .SetFontColor(cl_grayDark)
                                                .SetBackgroundColor(cl_tablecontent_2)
                                                .SetFontSize(10))
                                .SetBackgroundColor(cl_tablecontent_2)
                                .SetBorderTop(Border.NO_BORDER)
                                .SetBorderBottom(Border.NO_BORDER);



                            

                        }

                        row_alt=ToggleBoolean(row_alt);
                        if(inneriter==_countrecs)
                        {
                            cell1.SetBorderBottom(new SolidBorder(1f));
                            cell2.SetBorderBottom(new SolidBorder(1f));
                            cell2b.SetBorderBottom(new SolidBorder(1f));
                            cell3.SetBorderBottom(new SolidBorder(1f));


                        }

                        tabledirectoratecountriesrecs.AddCell(cell1);
                        tabledirectoratecountriesrecs.AddCell(cell2);
                        tabledirectoratecountriesrecs.AddCell(cell2b);
                        tabledirectoratecountriesrecs.AddCell(cell3);   
    




    

                    }

                    



                    inneriter=0;
                    row_alt=true;
                    document.Add(tabledirectoratecountriesrecs);

                }

          //  document.AddNewPage();
            document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));


            Paragraph Details_header = new Paragraph("Details")
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetUnderline()
                    .SetFont(ft)
                    .SetFontColor(cl_green)
                    .SetFontSize(14);
                    
            document.Add(Details_header);

            document.Add(txt_gap);

            foreach (var rec_set in DB_Records)
            {

                Table tabledirdetails = new Table(UnitValue.CreatePercentArray(new float[]{30, 20, 20, 15, 15}), false)
                    .SetWidth(PageSize.A3.GetWidth()-subtractmargins)
                    .SetMarginLeft(0)
                    .SetHorizontalAlignment(HorizontalAlignment.LEFT);
                
                Struc_Directorate directorate=_strucDirectorateRepository.GetRecord(rec_set.Record_Id);

                //Directorate Names
                    Cell cellheader01 = new Cell(1, 5)
                    .SetTextAlignment(TextAlignment.LEFT)
                    .Add(new Paragraph(directorate.Record_Name.ToUpper())
                                    .SetFont(ft_bold)
                                    .SetFixedLeading(14f)
                                    .SetFontColor(cl_white)
                                    .SetBackgroundColor(cl_tableheaderblack)
                                    .SetFontSize(10))
                        .SetBackgroundColor(cl_tableheaderblack);
                    tabledirdetails.AddCell(cellheader01);

                //Division Names
                var DB_RecordsDivs=_transStrucDivisionRepository.GetAllRecordsByDirectorate(rec_set.Transaction_Id).OrderByDescending(x => x.Division_Id).ToList();
                foreach (var rec_div in DB_RecordsDivs)
                {
                    Struc_Division division=_strucDivisionRepository.GetRecord(rec_div.Division_Id);

                    Cell cellheader02 = new Cell(1, 5)
                    .SetTextAlignment(TextAlignment.LEFT)
                    .Add(new Paragraph(division.Record_Name.ToUpper())
                                    .SetFont(ft_bold)
                                    .SetFixedLeading(14f)
                                    .SetFontColor(cl_white)
                                    .SetBackgroundColor(cl_tableheaderblackdiv)
                                    .SetFontSize(10))
                        .SetBackgroundColor(cl_tableheaderblackdiv);
                    tabledirdetails.AddCell(cellheader02);

                    var DivMainRecs=_wpMainRecordRepository.GetRecordsByDivRecs(rec_div.Division_Id).ToList();

                    int innter_proj_count=0;
                    int firstdecimalpoint=0;
                    if(DivMainRecs.Count()>0)
                    {
                        foreach (var rec_proj in DivMainRecs)
                        {
                            innter_proj_count=innter_proj_count+1;
                            firstdecimalpoint=firstdecimalpoint+1;
                            

                            LkUp_Project project= _lkupProjectRepository.GetRecord(rec_proj.Project_Id);

                            if(project.Record_Status==true)
                            {
                                Cell cellheader03 = new Cell(1, 5)
                                .SetTextAlignment(TextAlignment.LEFT)
                                .Add(new Paragraph("Project ".ToUpper()+innter_proj_count.ToString().ToUpper()+": "+project.Record_Name)
                                                .SetFont(ft_bold)
                                                .SetFixedLeading(14f)
                                                //.SetFontColor(cl_white)
                                                .SetBackgroundColor(cl_tableheaderblackproj)
                                                .SetFontSize(10))
                                    .SetBackgroundColor(cl_tableheaderblackproj);
                                tabledirdetails.AddCell(cellheader03);
                            }
                            else
                            {

                                Cell cellheader03 = new Cell(1, 5)
                                .SetTextAlignment(TextAlignment.LEFT)
                                .Add(new Paragraph("Project ".ToUpper()+innter_proj_count.ToString().ToUpper()+": "+project.Record_Name+"   <-- New Project (Inception)")
                                                .SetFont(ft_bold)
                                                .SetFixedLeading(14f)
                                            //  .SetFontColor(cl_white)
                                                .SetBackgroundColor(cl_tableheaderblackproj)
                                                .SetFontSize(10))
                                    .SetBackgroundColor(cl_tableheaderblackproj);
                                tabledirdetails.AddCell(cellheader03);

                            }

                            


                            //Outcomes
                           // firstdecimalpoint=firstdecimalpoint+1;

                            var DB_OutcomeRecs=_wpOutcomesRepository.GetRecordsByMainRecordId(rec_proj.Transaction_Id).ToList();
                            
                            Cell cellheader11= new Cell(1, 5)
                                .SetTextAlignment(TextAlignment.LEFT)
                                .Add(new Paragraph(innter_proj_count.ToString()+"."+firstdecimalpoint.ToString()+". Outcomes")
                                                .SetFont(ft_bold)
                                                .SetFixedLeading(14f)
                                                //.SetFontColor(cl_white)
                                                .SetBackgroundColor(cl_tableheader)
                                                .SetFontSize(10))
                                   .SetBackgroundColor(cl_tableheader);
                                tabledirdetails.AddCell(cellheader11);


                            row_alt=true;
                            inneriter=0;
                           
                            if(DB_OutcomeRecs.Count()>0)
                            {
                                foreach (var rec_outcomes in DB_OutcomeRecs)
                                {
                                    inneriter=inneriter+1;


                                    if(row_alt==false)
                                    {
                                        Cell cell11row = new Cell(1, 5)
                                        .SetTextAlignment(TextAlignment.LEFT)
                                        .Add(new Paragraph(innter_proj_count.ToString()+"."+firstdecimalpoint.ToString()+"."+inneriter.ToString()+". "+rec_outcomes.Outcome)
                                                        .SetFont(ft_regular)
                                                        .SetFixedLeading(14f)
                                                        //.SetFontColor(cl_white)
                                                        .SetFontColor(cl_grayDark)
                                                        .SetBackgroundColor(cl_tablecontent_1)
                                                        .SetFontSize(10))
                                        .SetBackgroundColor(cl_tablecontent_1);
                                        tabledirdetails.AddCell(cell11row);
                                    }
                                    else
                                    {
                                        Cell cell11row = new Cell(1, 5)
                                        .SetTextAlignment(TextAlignment.LEFT)
                                        .Add(new Paragraph(innter_proj_count.ToString()+"."+firstdecimalpoint.ToString()+"."+inneriter.ToString()+". "+rec_outcomes.Outcome)
                                                        .SetFont(ft_regular)
                                                        .SetFixedLeading(14f)
                                                        //.SetFontColor(cl_white)
                                                        .SetFontColor(cl_grayDark)
                                                        .SetBackgroundColor(cl_tablecontent_2)
                                                        .SetFontSize(10))
                                        .SetBackgroundColor(cl_tablecontent_2);
                                        tabledirdetails.AddCell(cell11row);

                                    }

                                    row_alt=ToggleBoolean(row_alt);

                                }
                            }
                            else
                            {
                                Cell cell11row = new Cell(1, 5)
                                    .SetTextAlignment(TextAlignment.LEFT)
                                    .Add(new Paragraph("No Outcome Captured")
                                                    .SetFont(ft_regular)
                                                    .SetFixedLeading(14f)
                                                    //.SetFontColor(cl_white)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tablecontent_1)
                                                    .SetFontSize(10))
                                    .SetBackgroundColor(cl_tablecontent_1);
                                    tabledirdetails.AddCell(cell11row);

                            }

                            inneriter=0;
                            row_alt=true;

                            //Outputs
                            var DB_OutputsRecs=_wpOutputsRepository.GetRecordsByMainRecordId(rec_proj.Transaction_Id).ToList();

                           firstdecimalpoint=firstdecimalpoint+1;
                           /* Cell cellheader12= new Cell(1, 5)
                                .SetTextAlignment(TextAlignment.LEFT)
                                .Add(new Paragraph(innter_proj_count.ToString()+"."+firstdecimalpoint.ToString()+". Outputs")
                                                .SetFont(ft_bold)
                                                .SetFixedLeading(14f)
                                                //.SetFontColor(cl_white)
                                                .SetBackgroundColor(cl_tableheader)
                                                .SetFontSize(10))
                                   .SetBackgroundColor(cl_tableheader);
                                tabledirdetails.AddCell(cellheader12);*/

                            Cell cellheader12a= new Cell(1, 4)
                                .SetTextAlignment(TextAlignment.LEFT)
                                .Add(new Paragraph(innter_proj_count.ToString()+"."+firstdecimalpoint.ToString()+". Outputs")
                                                .SetFont(ft_bold)
                                                .SetFixedLeading(14f)
                                                //.SetFontColor(cl_white)
                                                .SetBackgroundColor(cl_tableheader)
                                                .SetFontSize(10))
                                   .SetBackgroundColor(cl_tableheader);
                                tabledirdetails.AddCell(cellheader12a);

                            Cell cellheader12b= new Cell(1, 1)
                                .SetTextAlignment(TextAlignment.RIGHT)
                                .Add(new Paragraph("Amount (US$)")
                                                .SetFont(ft_bold)
                                                .SetFixedLeading(14f)
                                                //.SetFontColor(cl_white)
                                                .SetBackgroundColor(cl_tableheader)
                                                .SetFontSize(10))
                                   .SetBackgroundColor(cl_tableheader);
                                tabledirdetails.AddCell(cellheader12b);


                            if(DB_OutputsRecs.Count()>0)
                            {
                                foreach (var rec_output in DB_OutputsRecs)
                                {
                                    inneriter=inneriter+1;

                                    //Compute Total Output Budget
                                    var DB_ActivitiesRecs=_wpOutputActivitiesRepository.GetRecordsByOutputId(rec_output.Transaction_Id).ToList();
                                    double totalbudget_for_output=0;
                                    
                                    foreach (var act in DB_ActivitiesRecs)
                                    {
                                        totalbudget_for_output=totalbudget_for_output+act.ActivityCost;
                                    }




                                    if(row_alt==false)
                                    {
                                        Cell cell12rowa = new Cell(1, 4)
                                        .SetTextAlignment(TextAlignment.LEFT)
                                        .Add(new Paragraph(innter_proj_count.ToString()+"."+firstdecimalpoint.ToString()+"."+inneriter.ToString()+". "+rec_output.Output)
                                                        .SetFont(ft_regular)
                                                        .SetFixedLeading(14f)
                                                        //.SetFontColor(cl_white)
                                                        .SetFontColor(cl_grayDark)
                                                        .SetBackgroundColor(cl_tablecontent_1)
                                                        .SetFontSize(10))
                                        .SetBackgroundColor(cl_tablecontent_1)
                                        .SetBorderTop(Border.NO_BORDER)
                                        .SetBorderBottom(Border.NO_BORDER);
                                        tabledirdetails.AddCell(cell12rowa);

                                        
                                        Cell cell12rowb = new Cell(1, 1)
                                        .SetTextAlignment(TextAlignment.RIGHT)
                                        .Add(new Paragraph(string.Format("{0:N0}", totalbudget_for_output))
                                                        .SetFont(ft_regular)
                                                        .SetFixedLeading(14f)
                                                        //.SetFontColor(cl_white)
                                                        .SetFontColor(cl_grayDark)
                                                        .SetBackgroundColor(cl_tablecontent_1)
                                                        .SetFontSize(10))
                                        .SetBackgroundColor(cl_tablecontent_1)
                                        .SetBorderTop(Border.NO_BORDER)
                                        .SetBorderBottom(Border.NO_BORDER);
                                        tabledirdetails.AddCell(cell12rowb);
                                    }
                                    else
                                    {
                                        Cell cell12rowa = new Cell(1, 4)
                                        .SetTextAlignment(TextAlignment.LEFT)
                                        .Add(new Paragraph(innter_proj_count.ToString()+"."+firstdecimalpoint.ToString()+"."+inneriter.ToString()+". "+rec_output.Output)
                                                        .SetFont(ft_regular)
                                                        .SetFixedLeading(14f)
                                                        //.SetFontColor(cl_white)
                                                        .SetFontColor(cl_grayDark)
                                                        .SetBackgroundColor(cl_tablecontent_2)
                                                        .SetFontSize(10))
                                        .SetBackgroundColor(cl_tablecontent_2)
                                        .SetBorderTop(Border.NO_BORDER)
                                        .SetBorderBottom(Border.NO_BORDER);
                                        tabledirdetails.AddCell(cell12rowa);

                                        Cell cell12rowb = new Cell(1, 1)
                                        .SetTextAlignment(TextAlignment.RIGHT)
                                        .Add(new Paragraph(string.Format("{0:N0}", totalbudget_for_output))
                                                        .SetFont(ft_regular)
                                                        .SetFixedLeading(14f)
                                                        //.SetFontColor(cl_white)
                                                        .SetFontColor(cl_grayDark)
                                                        .SetBackgroundColor(cl_tablecontent_2)
                                                        .SetFontSize(10))
                                        .SetBackgroundColor(cl_tablecontent_2)
                                        .SetBorderTop(Border.NO_BORDER)
                                        .SetBorderBottom(Border.NO_BORDER);
                                        tabledirdetails.AddCell(cell12rowb);

                                    }

                                    row_alt=ToggleBoolean(row_alt);


                                }
                            }
                            else
                            {
                                Cell cell12rowa = new Cell(1, 5)
                                    .SetTextAlignment(TextAlignment.LEFT)
                                    .Add(new Paragraph("No Output Captured")
                                                    .SetFont(ft_regular)
                                                    .SetFixedLeading(14f)
                                                    //.SetFontColor(cl_white)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tablecontent_1)
                                                    .SetFontSize(10))
                                    .SetBackgroundColor(cl_tablecontent_1);
                                    tabledirdetails.AddCell(cell12rowa);

                            }

                            inneriter=0;
                            row_alt=true;
                            //Activities
                            var DB_Activities=_wpOutputActivitiesRepository.GetRecordsByMainRecordId(rec_proj.Transaction_Id).ToList();


                            firstdecimalpoint=firstdecimalpoint+1;
                           /*     Cell cellheader13= new Cell(1, 5)
                                    .SetTextAlignment(TextAlignment.LEFT)
                                    .Add(new Paragraph(innter_proj_count.ToString()+"."+firstdecimalpoint.ToString()+". Activity Plan")
                                                    .SetFont(ft_bold)
                                                    .SetFixedLeading(14f)
                                                    //.SetFontColor(cl_white)
                                                    .SetBackgroundColor(cl_tableheader)
                                                    .SetFontSize(10))
                                    .SetBackgroundColor(cl_tableheader);
                                    tabledirdetails.AddCell(cellheader13);*/
                            
                            //Row Header
                                Cell cellheader13a = new Cell(1, 1)
                                .SetTextAlignment(TextAlignment.LEFT)
                                .Add(new Paragraph(innter_proj_count.ToString()+"."+firstdecimalpoint.ToString()+". Activity Plan")
                                                .SetFont(ft_bold)
                                                .SetFixedLeading(14f)
                                                .SetFontColor(cl_grayDark)
                                                .SetBackgroundColor(cl_tableheader)
                                                .SetFontSize(10))
                                    .SetBackgroundColor(cl_tableheader);
                                tabledirdetails.AddCell(cellheader13a);

                                Cell cellheader13b = new Cell(1, 1)
                                    .SetTextAlignment(TextAlignment.LEFT)
                                    .Add(new Paragraph("Type of Activity")
                                                    .SetFont(ft_bold)
                                                    .SetFixedLeading(14f)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tableheader)
                                                    .SetFontSize(10))
                                    .SetBackgroundColor(cl_tableheader);
                                tabledirdetails.AddCell(cellheader13b);

            
                                Cell cellheader13c = new Cell(1, 1)
                                    .SetTextAlignment(TextAlignment.LEFT)
                                    .Add(new Paragraph("Activity Period")
                                                    .SetFont(ft_bold)
                                                    .SetFixedLeading(14f)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tableheader)
                                                    .SetFontSize(10))
                                    .SetBackgroundColor(cl_tableheader);
                                tabledirdetails.AddCell(cellheader13c);

                            Cell cellheader13e = new Cell(1, 1)
                                    .SetTextAlignment(TextAlignment.LEFT)
                                    .Add(new Paragraph("Source of Funds")
                                                    .SetFont(ft_bold)
                                                    .SetFixedLeading(14f)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tableheader)
                                                    .SetFontSize(10))
                                    .SetBackgroundColor(cl_tableheader);
                                tabledirdetails.AddCell(cellheader13e);

                                Cell cellheader13d = new Cell(1, 1)
                                    .SetTextAlignment(TextAlignment.RIGHT)
                                    .Add(new Paragraph("Amount (USD)")
                                                    .SetFont(ft_bold)
                                                    .SetFixedLeading(14f)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tableheader)
                                                    .SetFontSize(10))
                                    .SetBackgroundColor(cl_tableheader);
                                tabledirdetails.AddCell(cellheader13d);




                            if(DB_Activities.Count()>=1)
                            {
                            

                                foreach (var activity in DB_Activities)
                                {
                                    inneriter=inneriter+1;

                                    Cell cell1 = new Cell(1, 1);
                                    Cell cell2 = new Cell(1, 1);
                                    Cell cell3 = new Cell(1, 1);
                                    Cell cell4 = new Cell(1, 1);
                                    Cell cell5 = new Cell(1, 1);
                                    

                                    DateTime start= new  DateTime(activity.ActivityStartDate.Year, activity.ActivityStartDate.Month, activity.ActivityStartDate.Day);
                                    DateTime end= new  DateTime(activity.ActivityEndDate.Year, activity.ActivityEndDate.Month, activity.ActivityEndDate.Day);
                                    string period=start.Date.ToString("MMM d, yyyy")+" - "+end.Date.ToString("MMM d, yyyy");

                                    string fundssource="";
                                    
                                    if(activity.PartnerFunding==true && activity.PartnerFundingDescr!=null)
                                    {
                                        fundssource="DP ("+activity.PartnerFundingDescr+")";
                                    }
                                    else if (activity.PartnerFunding==true && activity.PartnerFundingDescr!=null)
                                    {
                                        fundssource="DP";
                                    }
                                    else
                                    {
                                        fundssource="MS";
                                    }

                                    if(row_alt==false)
                                    {
                                        //Row Rows
                                        cell1.SetTextAlignment(TextAlignment.JUSTIFIED)
                                        .Add(new Paragraph(innter_proj_count.ToString()+"."+firstdecimalpoint.ToString()+"."+inneriter.ToString()+". "+ activity.ActivityDescription)
                                                        //.SetFont(ft_montserrat_reg)
                                                        .SetFixedLeading(14f)
                                                        .SetFontColor(cl_grayDark)
                                                        .SetBackgroundColor(cl_tablecontent_1)
                                                        .SetFontSize(10))
                                            .SetBackgroundColor(cl_tablecontent_1)
                                            .SetBorderTop(Border.NO_BORDER)
                                            .SetBorderBottom(Border.NO_BORDER);
                                        tabledirdetails.AddCell(cell1);

                                    
                                        cell2.SetTextAlignment(TextAlignment.LEFT)
                                            .Add(new Paragraph(_lkupActivityTypeRepository.GetActivityType(activity.ActivityType_Id).Activity_Name)
                                                            //.SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_1)
                                                            .SetFontSize(9))
                                            .SetBackgroundColor(cl_tablecontent_1)
                                            .SetBorderTop(Border.NO_BORDER)
                                            .SetBorderBottom(Border.NO_BORDER);
                                        tabledirdetails.AddCell(cell2);


                                          


                                        cell3.SetTextAlignment(TextAlignment.LEFT)
                                            .Add(new Paragraph(period)
                                                        // .SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_1)
                                                            .SetFontSize(10))
                                            .SetBackgroundColor(cl_tablecontent_1)
                                            .SetBorderTop(Border.NO_BORDER)
                                            .SetBorderBottom(Border.NO_BORDER);
                                        tabledirdetails.AddCell(cell3);

                                       cell5.SetTextAlignment(TextAlignment.LEFT)
                                            .Add(new Paragraph(fundssource)
                                                        // .SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_1)
                                                            .SetFontSize(10))
                                            .SetBackgroundColor(cl_tablecontent_1)
                                            .SetBorderTop(Border.NO_BORDER)
                                            .SetBorderBottom(Border.NO_BORDER);
                                        tabledirdetails.AddCell(cell5);

                                        


                                        cell4.SetTextAlignment(TextAlignment.RIGHT)
                                            .Add(new Paragraph(string.Format("{0:N2}", activity.ActivityCost))
                                                        // .SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_1)
                                                            .SetFontSize(10))
                                            .SetBackgroundColor(cl_tablecontent_1)
                                            .SetBorderTop(Border.NO_BORDER)
                                            .SetBorderBottom(Border.NO_BORDER);
                                        tabledirdetails.AddCell(cell4);

                                        


                                    }
                                    else
                                    {
                                        //Row Rows

                                        cell1.SetTextAlignment(TextAlignment.JUSTIFIED)
                                        .Add(new Paragraph(innter_proj_count.ToString()+"."+firstdecimalpoint.ToString()+"."+inneriter.ToString()+". "+activity.ActivityDescription)
                                                        //.SetFont(ft_montserrat_reg)
                                                        .SetFixedLeading(14f)
                                                        .SetFontColor(cl_grayDark)
                                                        .SetBackgroundColor(cl_tablecontent_2)
                                                        .SetFontSize(10))
                                            .SetBackgroundColor(cl_tablecontent_2)
                                            .SetBorderTop(Border.NO_BORDER)
                                            .SetBorderBottom(Border.NO_BORDER);
                                        tabledirdetails.AddCell(cell1);

                                    
                                        cell2.SetTextAlignment(TextAlignment.LEFT)
                                            .Add(new Paragraph(_lkupActivityTypeRepository.GetActivityType(activity.ActivityType_Id).Activity_Name)
                                                            //.SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_2)
                                                            .SetFontSize(9))
                                            .SetBackgroundColor(cl_tablecontent_2)
                                            .SetBorderTop(Border.NO_BORDER)
                                            .SetBorderBottom(Border.NO_BORDER);
                                        tabledirdetails.AddCell(cell2);


                                          


                                        cell3.SetTextAlignment(TextAlignment.LEFT)
                                            .Add(new Paragraph(period)
                                                        // .SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_2)
                                                            .SetFontSize(10))
                                            .SetBackgroundColor(cl_tablecontent_2)
                                            .SetBorderTop(Border.NO_BORDER)
                                            .SetBorderBottom(Border.NO_BORDER);
                                        tabledirdetails.AddCell(cell3);

                                        cell5.SetTextAlignment(TextAlignment.LEFT)
                                            .Add(new Paragraph(fundssource)
                                                        // .SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_2)
                                                            .SetFontSize(10))
                                            .SetBackgroundColor(cl_tablecontent_2)
                                            .SetBorderTop(Border.NO_BORDER)
                                            .SetBorderBottom(Border.NO_BORDER);
                                        tabledirdetails.AddCell(cell5);


                                        cell4.SetTextAlignment(TextAlignment.RIGHT)
                                            .Add(new Paragraph(string.Format("{0:N2}", activity.ActivityCost))
                                                        // .SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_2)
                                                            .SetFontSize(10))
                                            .SetBackgroundColor(cl_tablecontent_2)
                                            .SetBorderTop(Border.NO_BORDER)
                                            .SetBorderBottom(Border.NO_BORDER);
                                        tabledirdetails.AddCell(cell4);

                                        

                                        

                                    }

                                    row_alt=ToggleBoolean(row_alt);
                                    

                                    

                                }

                                

                            
                            }
                            else
                            {
                                Cell cell12rowa = new Cell(1, 5)
                                    .SetTextAlignment(TextAlignment.LEFT)
                                    .Add(new Paragraph("No Activity Captured")
                                                    .SetFont(ft_regular)
                                                    .SetFixedLeading(14f)
                                                    //.SetFontColor(cl_white)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tablecontent_1)
                                                    .SetFontSize(10))
                                    .SetBackgroundColor(cl_tablecontent_1);
                                    tabledirdetails.AddCell(cell12rowa);

                            }




                            inneriter=0;
                            row_alt=true;
                            //Mobility
                            var DB_Mobilities=_wpMobilityRepository.GetRecordsByMainRecordId(rec_proj.Transaction_Id).ToList();


                            firstdecimalpoint=firstdecimalpoint+1;
                           /*     Cell cellheader13= new Cell(1, 5)
                                    .SetTextAlignment(TextAlignment.LEFT)
                                    .Add(new Paragraph(innter_proj_count.ToString()+"."+firstdecimalpoint.ToString()+". Activity Plan")
                                                    .SetFont(ft_bold)
                                                    .SetFixedLeading(14f)
                                                    //.SetFontColor(cl_white)
                                                    .SetBackgroundColor(cl_tableheader)
                                                    .SetFontSize(10))
                                    .SetBackgroundColor(cl_tableheader);
                                    tabledirdetails.AddCell(cellheader13);*/
                            
                            //Row Header
                                Cell cellheader14a = new Cell(1, 1)
                                .SetTextAlignment(TextAlignment.LEFT)
                                .Add(new Paragraph(innter_proj_count.ToString()+"."+firstdecimalpoint.ToString()+". Mobility Plan")
                                                .SetFont(ft_bold)
                                                .SetFixedLeading(14f)
                                                .SetFontColor(cl_grayDark)
                                                .SetBackgroundColor(cl_tableheader)
                                                .SetFontSize(10))
                                    .SetBackgroundColor(cl_tableheader);
                                tabledirdetails.AddCell(cellheader14a);

                                Cell cellheader14b = new Cell(1, 1)
                                    .SetTextAlignment(TextAlignment.LEFT)
                                    .Add(new Paragraph("Country")
                                                    .SetFont(ft_bold)
                                                    .SetFixedLeading(14f)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tableheader)
                                                    .SetFontSize(10))
                                    .SetBackgroundColor(cl_tableheader);
                                tabledirdetails.AddCell(cellheader14b);

            
                                Cell cellheader14c = new Cell(1, 1)
                                    .SetTextAlignment(TextAlignment.LEFT)
                                    .Add(new Paragraph("Mobility Period")
                                                    .SetFont(ft_bold)
                                                    .SetFixedLeading(14f)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tableheader)
                                                    .SetFontSize(10))
                                    .SetBackgroundColor(cl_tableheader);
                                tabledirdetails.AddCell(cellheader14c);

                            Cell cellheader14d = new Cell(1, 1)
                                    .SetTextAlignment(TextAlignment.LEFT)
                                    .Add(new Paragraph("AUDA-NEPAD Staff")
                                                    .SetFont(ft_bold)
                                                    .SetFixedLeading(14f)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tableheader)
                                                    .SetFontSize(10))
                                    .SetBackgroundColor(cl_tableheader);
                                tabledirdetails.AddCell(cellheader14d);

                                Cell cellheader14e = new Cell(1, 1)
                                    .SetTextAlignment(TextAlignment.LEFT)
                                    .Add(new Paragraph("External Participants")
                                                    .SetFont(ft_bold)
                                                    .SetFixedLeading(14f)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tableheader)
                                                    .SetFontSize(10))
                                    .SetBackgroundColor(cl_tableheader);
                                tabledirdetails.AddCell(cellheader14e);




                            if(DB_Mobilities.Count()>=1)
                            {
                            

                                //Currently Not Implemented
                                Cell cell12rowa = new Cell(1, 5)
                                    .SetTextAlignment(TextAlignment.LEFT)
                                    .Add(new Paragraph("No Mobility Plan Captured")
                                                    .SetFont(ft_regular)
                                                    .SetFixedLeading(14f)
                                                    //.SetFontColor(cl_white)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tablecontent_2)
                                                    .SetFontSize(10))
                                    .SetBackgroundColor(cl_tablecontent_2);
                                    tabledirdetails.AddCell(cell12rowa);
                                

                                

                            
                            }
                            else
                            {
                                Cell cell12rowa = new Cell(1, 5)
                                    .SetTextAlignment(TextAlignment.LEFT)
                                    .Add(new Paragraph("No Mobility Plan Captured")
                                                    .SetFont(ft_regular)
                                                    .SetFixedLeading(14f)
                                                    //.SetFontColor(cl_white)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tablecontent_2)
                                                    .SetFontSize(10))
                                    .SetBackgroundColor(cl_tablecontent_2);
                                    tabledirdetails.AddCell(cell12rowa);

                            }

                            inneriter=0;
                            row_alt=true;
                            //Procurement
                            var DB_Procurement=_wpProcurementRepository.GetRecordsByMainRecordId(rec_proj.Transaction_Id).ToList();


                            firstdecimalpoint=firstdecimalpoint+1;
                           /*     Cell cellheader13= new Cell(1, 5)
                                    .SetTextAlignment(TextAlignment.LEFT)
                                    .Add(new Paragraph(innter_proj_count.ToString()+"."+firstdecimalpoint.ToString()+". Activity Plan")
                                                    .SetFont(ft_bold)
                                                    .SetFixedLeading(14f)
                                                    //.SetFontColor(cl_white)
                                                    .SetBackgroundColor(cl_tableheader)
                                                    .SetFontSize(10))
                                    .SetBackgroundColor(cl_tableheader);
                                    tabledirdetails.AddCell(cellheader13);*/
                            
                            //Row Header
                                Cell cellheader15a = new Cell(1, 1)
                                .SetTextAlignment(TextAlignment.LEFT)
                                .Add(new Paragraph(innter_proj_count.ToString()+"."+firstdecimalpoint.ToString()+". Procurement Plan")
                                                .SetFont(ft_bold)
                                                .SetFixedLeading(14f)
                                                .SetFontColor(cl_grayDark)
                                                .SetBackgroundColor(cl_tableheader)
                                                .SetFontSize(10))
                                    .SetBackgroundColor(cl_tableheader);
                                tabledirdetails.AddCell(cellheader15a);

                                Cell cellheader15b = new Cell(1, 1)
                                    .SetTextAlignment(TextAlignment.LEFT)
                                    .Add(new Paragraph("Type of Procurement")
                                                    .SetFont(ft_bold)
                                                    .SetFixedLeading(14f)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tableheader)
                                                    .SetFontSize(10))
                                    .SetBackgroundColor(cl_tableheader);
                                tabledirdetails.AddCell(cellheader15b);

            
                                Cell cellheader15c = new Cell(1, 1)
                                    .SetTextAlignment(TextAlignment.LEFT)
                                    .Add(new Paragraph("Procurement Period")
                                                    .SetFont(ft_bold)
                                                    .SetFixedLeading(14f)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tableheader)
                                                    .SetFontSize(10))
                                    .SetBackgroundColor(cl_tableheader);
                                tabledirdetails.AddCell(cellheader15c);

                            Cell cellheader15d = new Cell(1, 1)
                                    .SetTextAlignment(TextAlignment.LEFT)
                                    .Add(new Paragraph("Additional Notes")
                                                    .SetFont(ft_bold)
                                                    .SetFixedLeading(14f)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tableheader)
                                                    .SetFontSize(10))
                                    .SetBackgroundColor(cl_tableheader);
                                tabledirdetails.AddCell(cellheader15d);

                                Cell cellheader15e = new Cell(1, 1)
                                    .SetTextAlignment(TextAlignment.RIGHT)
                                    .Add(new Paragraph("Amount (USD)")
                                                    .SetFont(ft_bold)
                                                    .SetFixedLeading(14f)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tableheader)
                                                    .SetFontSize(10))
                                    .SetBackgroundColor(cl_tableheader);
                                tabledirdetails.AddCell(cellheader15e);




                            if(DB_Procurement.Count()>=1)
                            {
                            

                                //Currently Not Implemented
                                Cell cell12rowa = new Cell(1, 5)
                                    .SetTextAlignment(TextAlignment.LEFT)
                                    .Add(new Paragraph("No Procurement Plan Captured")
                                                    .SetFont(ft_regular)
                                                    .SetFixedLeading(14f)
                                                    //.SetFontColor(cl_white)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tablecontent_2)
                                                    .SetFontSize(10))
                                    .SetBackgroundColor(cl_tablecontent_2);
                                    tabledirdetails.AddCell(cell12rowa);
                                

                                

                            
                            }
                            else
                            {
                                Cell cell12rowa = new Cell(1, 5)
                                    .SetTextAlignment(TextAlignment.LEFT)
                                    .Add(new Paragraph("No Procurement Plan Captured")
                                                    .SetFont(ft_regular)
                                                    .SetFixedLeading(14f)
                                                    //.SetFontColor(cl_white)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tablecontent_2)
                                                    .SetFontSize(10))
                                    .SetBackgroundColor(cl_tablecontent_2);
                                    tabledirdetails.AddCell(cell12rowa);

                            }




                            inneriter=0;
                            row_alt=true;
                            //Communications
                            var DB_Comms=_wpCommunicationRepository.GetRecordsByMainRecordId(rec_proj.Transaction_Id).ToList();


                            firstdecimalpoint=firstdecimalpoint+1;
                           /*     Cell cellheader13= new Cell(1, 5)
                                    .SetTextAlignment(TextAlignment.LEFT)
                                    .Add(new Paragraph(innter_proj_count.ToString()+"."+firstdecimalpoint.ToString()+". Activity Plan")
                                                    .SetFont(ft_bold)
                                                    .SetFixedLeading(14f)
                                                    //.SetFontColor(cl_white)
                                                    .SetBackgroundColor(cl_tableheader)
                                                    .SetFontSize(10))
                                    .SetBackgroundColor(cl_tableheader);
                                    tabledirdetails.AddCell(cellheader13);*/
                            
                            //Row Header
                                Cell cellheader16a = new Cell(1, 1)
                                .SetTextAlignment(TextAlignment.LEFT)
                                .Add(new Paragraph(innter_proj_count.ToString()+"."+firstdecimalpoint.ToString()+". Communication Plan")
                                                .SetFont(ft_bold)
                                                .SetFixedLeading(14f)
                                                .SetFontColor(cl_grayDark)
                                                .SetBackgroundColor(cl_tableheader)
                                                .SetFontSize(10))
                                    .SetBackgroundColor(cl_tableheader);
                                tabledirdetails.AddCell(cellheader16a);

                                Cell cellheader16b = new Cell(1, 1)
                                    .SetTextAlignment(TextAlignment.LEFT)
                                    .Add(new Paragraph("Communication Channel")
                                                    .SetFont(ft_bold)
                                                    .SetFixedLeading(14f)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tableheader)
                                                    .SetFontSize(10))
                                    .SetBackgroundColor(cl_tableheader);
                                tabledirdetails.AddCell(cellheader16b);

            
                                Cell cellheader16c = new Cell(1, 1)
                                    .SetTextAlignment(TextAlignment.LEFT)
                                    .Add(new Paragraph("Communication Period")
                                                    .SetFont(ft_bold)
                                                    .SetFixedLeading(14f)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tableheader)
                                                    .SetFontSize(10))
                                    .SetBackgroundColor(cl_tableheader);
                                tabledirdetails.AddCell(cellheader16c);

                            Cell cellheader16d = new Cell(1, 1)
                                    .SetTextAlignment(TextAlignment.LEFT)
                                    .Add(new Paragraph("Additional Notes")
                                                    .SetFont(ft_bold)
                                                    .SetFixedLeading(14f)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tableheader)
                                                    .SetFontSize(10))
                                    .SetBackgroundColor(cl_tableheader);
                                tabledirdetails.AddCell(cellheader16d);

                                Cell cellheader16e = new Cell(1, 1)
                                    .SetTextAlignment(TextAlignment.RIGHT)
                                    .Add(new Paragraph("Amount (USD)")
                                                    .SetFont(ft_bold)
                                                    .SetFixedLeading(14f)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tableheader)
                                                    .SetFontSize(10))
                                    .SetBackgroundColor(cl_tableheader);
                                tabledirdetails.AddCell(cellheader16e);




                            if(DB_Comms.Count()>=1)
                            {
                            

                                //Currently Not Implemented
                                Cell cell12rowa = new Cell(1, 5)
                                    .SetTextAlignment(TextAlignment.LEFT)
                                    .Add(new Paragraph("No Communication Plan Captured")
                                                    .SetFont(ft_regular)
                                                    .SetFixedLeading(14f)
                                                    //.SetFontColor(cl_white)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tablecontent_2)
                                                    .SetFontSize(10))
                                    .SetBackgroundColor(cl_tablecontent_2);
                                    tabledirdetails.AddCell(cell12rowa);
                                

                                

                            
                            }
                            else
                            {
                                Cell cell12rowa = new Cell(1, 5)
                                    .SetTextAlignment(TextAlignment.LEFT)
                                    .Add(new Paragraph("No Communication Plan Captured")
                                                    .SetFont(ft_regular)
                                                    .SetFixedLeading(14f)
                                                    //.SetFontColor(cl_white)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tablecontent_2)
                                                    .SetFontSize(10))
                                    .SetBackgroundColor(cl_tablecontent_2);
                                    tabledirdetails.AddCell(cell12rowa);

                            }


                             inneriter=0;
                            row_alt=true;
                            //Communications
                            var DB_Risk=_wpRiskProfileRepository.GetRecordsByMainRecordId(rec_proj.Transaction_Id).ToList();


                            firstdecimalpoint=firstdecimalpoint+1;
                           /*     Cell cellheader13= new Cell(1, 5)
                                    .SetTextAlignment(TextAlignment.LEFT)
                                    .Add(new Paragraph(innter_proj_count.ToString()+"."+firstdecimalpoint.ToString()+". Activity Plan")
                                                    .SetFont(ft_bold)
                                                    .SetFixedLeading(14f)
                                                    //.SetFontColor(cl_white)
                                                    .SetBackgroundColor(cl_tableheader)
                                                    .SetFontSize(10))
                                    .SetBackgroundColor(cl_tableheader);
                                    tabledirdetails.AddCell(cellheader13);*/
                            
                            //Row Header
                                Cell cellheader17a = new Cell(1, 1)
                                .SetTextAlignment(TextAlignment.LEFT)
                                .Add(new Paragraph(innter_proj_count.ToString()+"."+firstdecimalpoint.ToString()+". Risk Profile")
                                                .SetFont(ft_bold)
                                                .SetFixedLeading(14f)
                                                .SetFontColor(cl_grayDark)
                                                .SetBackgroundColor(cl_tableheader)
                                                .SetFontSize(10))
                                    .SetBackgroundColor(cl_tableheader);
                                tabledirdetails.AddCell(cellheader17a);

                                Cell cellheader17b = new Cell(1, 1)
                                    .SetTextAlignment(TextAlignment.LEFT)
                                    .Add(new Paragraph("Impact Level")
                                                    .SetFont(ft_bold)
                                                    .SetFixedLeading(14f)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tableheader)
                                                    .SetFontSize(10))
                                    .SetBackgroundColor(cl_tableheader);
                                tabledirdetails.AddCell(cellheader17b);

            
                                Cell cellheader17c = new Cell(1, 1)
                                    .SetTextAlignment(TextAlignment.LEFT)
                                    .Add(new Paragraph("Probability")
                                                    .SetFont(ft_bold)
                                                    .SetFixedLeading(14f)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tableheader)
                                                    .SetFontSize(10))
                                    .SetBackgroundColor(cl_tableheader);
                                tabledirdetails.AddCell(cellheader17c);

                            Cell cellheader17d = new Cell(1, 1)
                                    .SetTextAlignment(TextAlignment.LEFT)
                                    .Add(new Paragraph("Frequency")
                                                    .SetFont(ft_bold)
                                                    .SetFixedLeading(14f)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tableheader)
                                                    .SetFontSize(10))
                                    .SetBackgroundColor(cl_tableheader);
                                tabledirdetails.AddCell(cellheader17d);

                                Cell cellheader17e = new Cell(1, 1)
                                    .SetTextAlignment(TextAlignment.RIGHT)
                                    .Add(new Paragraph("Risk Cost (USD)")
                                                    .SetFont(ft_bold)
                                                    .SetFixedLeading(14f)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tableheader)
                                                    .SetFontSize(10))
                                    .SetBackgroundColor(cl_tableheader);
                                tabledirdetails.AddCell(cellheader17e);




                            if(DB_Risk.Count()>=1)
                            {
                            

                                //Currently Not Implemented
                                Cell cell12rowa = new Cell(1, 5)
                                    .SetTextAlignment(TextAlignment.LEFT)
                                    .Add(new Paragraph("No Risk Profile Captured")
                                                    .SetFont(ft_regular)
                                                    .SetFixedLeading(14f)
                                                    //.SetFontColor(cl_white)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tablecontent_2)
                                                    .SetFontSize(10))
                                    .SetBackgroundColor(cl_tablecontent_2);
                                    tabledirdetails.AddCell(cell12rowa);
                                

                                

                            
                            }
                            else
                            {
                                Cell cell12rowa = new Cell(1, 5)
                                    .SetTextAlignment(TextAlignment.LEFT)
                                    .Add(new Paragraph("No Risk Profile Captured")
                                                    .SetFont(ft_regular)
                                                    .SetFixedLeading(14f)
                                                    //.SetFontColor(cl_white)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tablecontent_2)
                                                    .SetFontSize(10))
                                    .SetBackgroundColor(cl_tablecontent_2);
                                    tabledirdetails.AddCell(cell12rowa);

                            }















                            //Target Countries and RECs
                            string rtnstringCountries = string.Empty;
                            string rtnstringRECs = string.Empty;


                            var DB_CountryScopeRecs=_wpCountryScopeRepository.GetRecordsByMainRecordId(rec_proj.Transaction_Id).GroupBy(x => x.Country_Id).Select(x => x.First()).ToList();
                            var DB_RECScopeRecs=_wpRegionScopeRepository.GetRecordsByMainRecordId(rec_proj.Transaction_Id).GroupBy(x => x.Region_Id).Select(x => x.First()).ToList();

                            int _countrycount=DB_CountryScopeRecs.Count();
                            int _reccount=DB_RECScopeRecs.Count();

                            int countryiter=0;
                            int reciter=0;

                            foreach(var countryrec in DB_CountryScopeRecs)
                            {
                                countryiter=countryiter+1;
                                LkUp_Country country=_lkupCountryRepository.GetCountry(countryrec.Country_Id);
                    
                               

                                if(countryiter==_countrycount)
                                {
                                    rtnstringCountries += country.Country_Name.TrimEnd();  
                                }
                                else
                                {
                                    rtnstringCountries += country.Country_Name.TrimEnd()+", ";  
                                }
                            }

                            foreach(var recrec in DB_RECScopeRecs)
                            {
                                LkUp_RegionScope region=_lkupRegionScopeRepository.GetRecord(recrec.Region_Id);
                                reciter=reciter+1;
                                
                                if(reciter==_reccount)
                                {
                                    rtnstringRECs += region.Record_Name.TrimEnd();  
                                }
                                else
                                {
                                    rtnstringRECs += region.Record_Name.TrimEnd()+", ";  

                                }

                            }


                            firstdecimalpoint=firstdecimalpoint+1;
                            //Countries
                            Cell cellheaderc1= new Cell(1, 5)
                                .SetTextAlignment(TextAlignment.LEFT)
                                .Add(new Paragraph(innter_proj_count.ToString()+"."+firstdecimalpoint.ToString()+". Target Countries")
                                                .SetFont(ft_bold)
                                                .SetFixedLeading(14f)
                                                //.SetFontColor(cl_white)
                                                .SetBackgroundColor(cl_tableheader)
                                                .SetFontSize(10))
                                   .SetBackgroundColor(cl_tableheader);
                                tabledirdetails.AddCell(cellheaderc1);

                            if(_countrycount>0)
                            {
                                Cell cellheaderc1row = new Cell(1, 5)
                                    .SetTextAlignment(TextAlignment.LEFT)
                                    .Add(new Paragraph(rtnstringCountries)
                                                    .SetFont(ft_regular)
                                                    .SetFixedLeading(14f)
                                                    //.SetFontColor(cl_white)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tablecontent_2)
                                                    .SetFontSize(10))
                                    .SetBackgroundColor(cl_tablecontent_2);
                                    tabledirdetails.AddCell(cellheaderc1row);
                            }
                            else
                            {
                                 Cell cellheaderc1row = new Cell(1, 5)
                                    .SetTextAlignment(TextAlignment.LEFT)
                                    .Add(new Paragraph("No Target Country Captured")
                                                    .SetFont(ft_regular)
                                                    .SetFixedLeading(14f)
                                                    //.SetFontColor(cl_white)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tablecontent_2)
                                                    .SetFontSize(10))
                                    .SetBackgroundColor(cl_tablecontent_2);
                                    tabledirdetails.AddCell(cellheaderc1row);

                            }


                            firstdecimalpoint=firstdecimalpoint+1;
                            //RECs
                           

                            Cell cellheaderr1= new Cell(1, 5)
                                .SetTextAlignment(TextAlignment.LEFT)
                                .Add(new Paragraph(innter_proj_count.ToString()+"."+firstdecimalpoint.ToString()+". Target RECs")
                                                .SetFont(ft_bold)
                                                .SetFixedLeading(14f)
                                                //.SetFontColor(cl_white)
                                                .SetBackgroundColor(cl_tableheader)
                                                .SetFontSize(10))
                                   .SetBackgroundColor(cl_tableheader);
                                tabledirdetails.AddCell(cellheaderr1);
                        

                            if(_reccount>0)
                            {
                                Cell cellheaderr1row = new Cell(1, 5)
                                    .SetTextAlignment(TextAlignment.LEFT)
                                    .Add(new Paragraph(rtnstringRECs)
                                                    .SetFont(ft_regular)
                                                    .SetFixedLeading(14f)
                                                    //.SetFontColor(cl_white)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tablecontent_2)
                                                    .SetFontSize(10))
                                    .SetBackgroundColor(cl_tablecontent_2);
                                    tabledirdetails.AddCell(cellheaderr1row);
                            }
                            else
                            {
                                Cell cellheaderr1row = new Cell(1, 5)
                                    .SetTextAlignment(TextAlignment.LEFT)
                                    .Add(new Paragraph("No Target REC Captured")
                                                    .SetFont(ft_regular)
                                                    .SetFixedLeading(14f)
                                                    //.SetFontColor(cl_white)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tablecontent_2)
                                                    .SetFontSize(10))
                                    .SetBackgroundColor(cl_tablecontent_2);
                                    tabledirdetails.AddCell(cellheaderr1row);

                            }

                            inneriter=0;
                            row_alt=true;




                        
                            //Set decimal point to zero
                            firstdecimalpoint=0;
                        }
                    }
                    else
                    {
                            Cell cellheader03 = new Cell(1, 5)
                                .SetTextAlignment(TextAlignment.LEFT)
                                .Add(new Paragraph("No Project Workplan Captured or Submitted")
                                                .SetFont(ft_regular)
                                                .SetFixedLeading(14f)
                                            //  .SetFontColor(cl_white)
                                                .SetBackgroundColor(cl_tableheaderblackproj)
                                                .SetFontSize(10))
                                    .SetBackgroundColor(cl_tableheaderblackproj);

                                tabledirdetails.AddCell(cellheader03);

                    }



                }
                
                
                
                document.Add(tabledirdetails);

                document.Add(txt_gap);
                document.Add(txt_gap);



            }











            document.Close();
            return workStream;

        }





        public MemoryStream GetMemoryStream(WP_MainRecord mainrec)
        {
            
            MemoryStream workStream = new MemoryStream();

            PdfWriter writer = new PdfWriter(workStream);
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);
            int n = pdf.GetNumberOfPages();

            pdf.AddEventHandler(PdfDocumentEvent.END_PAGE, new NEPADStaffController.MyEventHandler(this));

            document.SetBottomMargin(70);
                
                
                
                //PdfFontFactory.Register(@"wwwroot/reports/fonts/FaktSlabPro-Blond.ttf");Montserrat-ExtraBold Montserrat-Italic Montserrat-Light Montserrat-Bold Montserrat-Medium Montserrat-Italic
                string fontpath = @"wwwroot/reports/fonts/FaktSlabPro-Blond.ttf";
                string fontpath_montserrat_medium= @"wwwroot/reports/fonts/Montserrat-Medium.ttf";
                string fontpath_montserrat_bold= @"wwwroot/reports/fonts/Montserrat-Bold.ttf";
                string fontpath_montserrat_semibold= @"wwwroot/reports/fonts/Montserrat-SemiBold.ttf";
                string fontpath_montserrat_thick= @"wwwroot/reports/fonts/Montserrat-ExtraBold.ttf";
                string fontpath_montserrat_reg= @"wwwroot/reports/fonts/Montserrat-Regular.ttf";
                string fontpath_montserrat_reg_italic= @"wwwroot/reports/fonts/Montserrat-Italic.ttf";
                string fontpath_montserrat_light= @"wwwroot/reports/fonts/Montserrat-Light.ttf";
                string fontpath_materialicons_fonts= @"wwwroot/reports/fonts/MaterialIcons-Regular.ttf";
                string fontpath_helveticaneue= @"wwwroot/reports/fonts/HelveticaNeueLt.ttf";

                PdfFont ft = PdfFontFactory.CreateFont(fontpath, PdfEncodings.WINANSI, true);
                PdfFont ft_montserrat_medium = PdfFontFactory.CreateFont(fontpath_montserrat_medium, PdfEncodings.WINANSI, true);
                PdfFont ft_montserrat_semibold = PdfFontFactory.CreateFont(fontpath_montserrat_semibold, PdfEncodings.WINANSI, true);
                PdfFont ft_montserrat_bold = PdfFontFactory.CreateFont(fontpath_montserrat_bold, PdfEncodings.WINANSI, true);
                PdfFont ft_montserrat_thick = PdfFontFactory.CreateFont(fontpath_montserrat_thick, PdfEncodings.WINANSI, true);
                PdfFont ft_montserrat_reg = PdfFontFactory.CreateFont(fontpath_montserrat_reg, PdfEncodings.WINANSI, true);
                PdfFont ft_montserrat_reg_it = PdfFontFactory.CreateFont(fontpath_montserrat_reg_italic, PdfEncodings.WINANSI, true);
                PdfFont ft_montserrat_light= PdfFontFactory.CreateFont(fontpath_montserrat_light, PdfEncodings.WINANSI, true);
                PdfFont ft_materialicons_fonts= PdfFontFactory.CreateFont(fontpath_materialicons_fonts, "Identity-H", true);
                PdfFont ft_helveticaneue= PdfFontFactory.CreateFont(fontpath_helveticaneue, PdfEncodings.WINANSI, true);

                Color cl=new DeviceRgb(18, 50, 89);
                Color cl_lightblue=new DeviceRgb(45, 80, 122);
                Color cl_green=new DeviceRgb(5, 71, 27);
                Color cl_gray=new DeviceRgb(132, 134, 135);
                Color cl_grayD=new DeviceRgb(98, 99, 99);
                Color cl_grayDark=new DeviceRgb(51, 52, 54);
                Color cl_white=new DeviceRgb(255, 255, 255);
                Color cl_red=new DeviceRgb(120, 60, 62);
                Color cl_tableheaderupper=new DeviceRgb(199, 198, 197);
                Color cl_tableheader=new DeviceRgb(219, 217, 215);
                Color cl_tableheaderblack=new DeviceRgb(0, 0, 0);
                Color cl_tablecontent1=new DeviceRgb(250, 245, 240);
                Color cl_tablecontent_1=new DeviceRgb(232, 233, 235);
                Color cl_tablecontent_2=new DeviceRgb(252, 252, 252);
                Color cl_tablecontent_22=new DeviceRgb(246, 246, 246);

               

                         // Add Logo
                Image img = new Image(ImageDataFactory
                    .Create(@"wwwroot/frontpage/images/logo-dark_for_reports.png"))
                    //.SetTextAlignment(TextAlignment.CENTER)
                    .SetHorizontalAlignment(HorizontalAlignment.CENTER)
                    .SetHeight(55)
                    .SetWidth(230);
                document.Add(img);

                Paragraph txt_gap=new Paragraph(new Text("\n"));
                Paragraph txt=new Paragraph(new Text(" "))
                                .SetFixedLeading(1f);

                document.Add(txt);

               

               
                
                SolidLine line = new SolidLine(0.5f);
                line.SetColor(cl_gray);
                LineSeparator ls = new LineSeparator(line);


                DottedLine dottedline = new DottedLine(0.5f);
                dottedline.SetColor(cl_gray);
                LineSeparator ls_dotted = new LineSeparator(dottedline);

                DashedLine dashedline = new DashedLine(0.5f);
                dashedline.SetColor(cl_gray);
                LineSeparator ls_dashed= new LineSeparator(dashedline);


                Paragraph header = new Paragraph("Integrated Planning and Reporting System"+ Convert.ToChar(174))
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetFont(ft)
                    .SetFontColor(cl)
                    .SetFontSize(16);
                    
                document.Add(header);


               // document.Add(txt);

           
                Paragraph sub_header = new Paragraph("Activity Plan")
                    .SetFixedLeading(14f)
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetFont(ft_montserrat_thick)
                    
                    .SetFontColor(cl_gray)
                    .SetFontSize(14);
                document.Add(sub_header);
                document.Add(txt);




            string barcodestring="";
            if(mainrec.BarCode_Id!=null)
            {
                barcodestring=mainrec.BarCode_Id;
            }
            else
            {
                barcodestring=RandomDigits(12);
                mainrec.BarCode_Id=barcodestring;
                _wpMainRecordRepository.Update(mainrec);

            }
            
            //Bar Code
            var bar = new BarcodeInter25(pdf);
            bar.SetCode(barcodestring);
           //bar.SetCode("000600123456");

           //Computing Total Budget for Project
            var DB_Budgets =  _wpOutputActivitiesRepository.GetRecordsByMainRecordId(mainrec.Transaction_Id).ToList();
            double totalbudget=0;

            foreach (var budget_record in DB_Budgets)
            {
                totalbudget=totalbudget+budget_record.ActivityCost;
            }


            //Here's how to add barcode to PDF with IText7
            var barcodeImg = new Image(bar.CreateFormXObject(pdf))
                                .SetHorizontalAlignment(HorizontalAlignment.CENTER);
            document.Add(barcodeImg);   
            //document.Add(txt);

            //Get Period Name
            string periodname="";
            if(mainrec.Period_Id==8)
            {
                DateTime pstart=new DateTime(mainrec.PeriodStartDate.Year, mainrec.PeriodStartDate.Month, mainrec.PeriodStartDate.Day);
                DateTime pend=new DateTime(mainrec.PeriodEndDate.Year, mainrec.PeriodEndDate.Month, mainrec.PeriodEndDate.Day);
                periodname=pstart.Date.ToString("MMM d, yyyy") + " - "+ pend.Date.ToString("MMM d, yyyy"); 
            }
            else
            {
                periodname=_lkupPeriodRepository.GetRecord(mainrec.Period_Id).Record_Name;
            }

           // document.Add(ls);
                //document.Add(txt);
                float subtractmargins=document.GetLeftMargin()+document.GetRightMargin();
                //Table table = new Table(2, false)
                Table table = new Table(UnitValue.CreatePercentArray(new float[]{15, 85}), false)
                .SetWidth(PageSize.A4.GetWidth()-subtractmargins)
                .SetHorizontalAlignment(HorizontalAlignment.LEFT);

                //Row 1
                Cell cell11 = new Cell(1, 1)
                    .SetTextAlignment(TextAlignment.LEFT)
                    .Add(new Paragraph("Directorate ")
                                   // .SetFont(ft_montserrat_reg)
                                    .SetFixedLeading(9f)
                                    .SetFontSize(9))
                    .SetBackgroundColor(cl_tableheader)
                    .SetBorderLeft(Border.NO_BORDER)
                    .SetBorderRight(Border.NO_BORDER)
                    .SetBorderBottom(Border.NO_BORDER);
               
                  
               Cell cell12 = new Cell(1, 1)
                  .SetTextAlignment(TextAlignment.LEFT)
                  .Add(new Paragraph(_strucDirectorateRepository.GetRecord(mainrec.Directorate_Id).Record_Name)
                                .SetFont(ft_montserrat_reg)
                                .SetFixedLeading(9f)
                                .SetFontColor(cl_grayDark)
                                .SetFontSize(9))
                .SetBackgroundColor(cl_tablecontent_22)
                .SetBorderLeft(Border.NO_BORDER)
                .SetBorderRight(Border.NO_BORDER)
                .SetBorderBottom(Border.NO_BORDER);

                //Row 2
                Cell cell21 = new Cell(1, 1)
                  .SetTextAlignment(TextAlignment.LEFT)
                  .Add(new Paragraph("Division ")
                              //  .SetFont(ft_montserrat_reg)
                                .SetFixedLeading(9f)
                                .SetFontSize(9))
                .SetBackgroundColor(cl_tableheader)
                .SetBorderLeft(Border.NO_BORDER)
                .SetBorderRight(Border.NO_BORDER)
                .SetBorderTop(Border.NO_BORDER)
                .SetBorderBottom(Border.NO_BORDER);

               Cell cell22 = new Cell(1, 1)
                  .SetTextAlignment(TextAlignment.LEFT)
                  .Add(new Paragraph(_strucDivisionRepository.GetRecord(mainrec.Division_Id).Record_Name)
                                .SetFont(ft_montserrat_reg)
                                .SetFixedLeading(9f)
                                .SetFontColor(cl_grayDark)
                                .SetFontSize(9))
                .SetBackgroundColor(cl_tablecontent_22)
                .SetBorderLeft(Border.NO_BORDER)
                .SetBorderRight(Border.NO_BORDER)
                .SetBorderTop(Border.NO_BORDER)
                .SetBorderBottom(Border.NO_BORDER);

                //Row 3
                Cell cell31 = new Cell(1, 1)
                  .SetTextAlignment(TextAlignment.LEFT)
                  .Add(new Paragraph("Programme ")
                                //.SetFont(ft_montserrat_reg)
                                .SetFixedLeading(9f)
                                .SetFontSize(9))
                .SetBackgroundColor(cl_tableheader)
                .SetBorderLeft(Border.NO_BORDER)
                .SetBorderRight(Border.NO_BORDER)
                .SetBorderTop(Border.NO_BORDER)
                .SetBorderBottom(Border.NO_BORDER);

               Cell cell32 = new Cell(1, 1)
                  .SetTextAlignment(TextAlignment.LEFT)
                  .Add(new Paragraph(_lkupProgrammeRepository.GetRecord(mainrec.Programme_Id).Record_Name)
                                .SetFont(ft_montserrat_reg)
                                .SetFixedLeading(9f)
                                .SetFontColor(cl_grayDark)
                                .SetFontSize(9))
                .SetBackgroundColor(cl_tablecontent_22)
                .SetBorderLeft(Border.NO_BORDER)
                .SetBorderRight(Border.NO_BORDER)
                .SetBorderTop(Border.NO_BORDER)
                .SetBorderBottom(Border.NO_BORDER);


                //Row 4
                Cell cell41 = new Cell(1, 1)
                  .SetTextAlignment(TextAlignment.LEFT)
                  .Add(new Paragraph("Project ")
                                //.SetFont(ft_montserrat_reg)
                                .SetFixedLeading(9f)
                                .SetFontSize(9))
                .SetBackgroundColor(cl_tableheader)
                .SetBorderLeft(Border.NO_BORDER)
                .SetBorderRight(Border.NO_BORDER)
                .SetBorderTop(Border.NO_BORDER)
                .SetBorderBottom(Border.NO_BORDER);

               Cell cell42 = new Cell(1, 1)
                  .SetTextAlignment(TextAlignment.LEFT)
                  .Add(new Paragraph(_lkupProjectRepository.GetRecord(mainrec.Project_Id).Record_Name)
                                .SetFont(ft_montserrat_reg)
                                .SetFixedLeading(9f)
                                .SetFontColor(cl_grayDark)
                                .SetFontSize(9))
                .SetBackgroundColor(cl_tablecontent_22)
                .SetBorderLeft(Border.NO_BORDER)
                .SetBorderRight(Border.NO_BORDER)
                .SetBorderTop(Border.NO_BORDER)
                .SetBorderBottom(Border.NO_BORDER);

                //Row 5
                Cell cell51 = new Cell(1, 1)
                  .SetTextAlignment(TextAlignment.LEFT)
                  .Add(new Paragraph("Year ")
                               // .SetFont(ft_montserrat_reg)
                                .SetFixedLeading(9f)
                                .SetFontSize(9))
                .SetBackgroundColor(cl_tableheader)
                .SetBorderLeft(Border.NO_BORDER)
                .SetBorderRight(Border.NO_BORDER)
                .SetBorderTop(Border.NO_BORDER)
                .SetBorderBottom(Border.NO_BORDER);

               Cell cell52 = new Cell(1, 1)
                  .SetTextAlignment(TextAlignment.LEFT)
                  .Add(new Paragraph(_lkupFiscalYearRepository.GetRecord(mainrec.FiscalYear_Id).Record_Name)
                                .SetFont(ft_montserrat_reg)
                                .SetFixedLeading(9f)
                                .SetFontColor(cl_grayDark)
                                .SetFontSize(10))
                .SetBackgroundColor(cl_tablecontent_22)
                .SetBorderLeft(Border.NO_BORDER)
                .SetBorderRight(Border.NO_BORDER)
                .SetBorderTop(Border.NO_BORDER)
                .SetBorderBottom(Border.NO_BORDER);


                //Row 6
                Cell cell61 = new Cell(1, 1)
                  .SetTextAlignment(TextAlignment.LEFT)
                  .Add(new Paragraph("Period ")
                               // .SetFont(ft_montserrat_reg)
                                .SetFixedLeading(9f)
                                .SetFontSize(9))
                .SetBackgroundColor(cl_tableheader)
                .SetBorderLeft(Border.NO_BORDER)
                .SetBorderRight(Border.NO_BORDER)
                .SetBorderTop(Border.NO_BORDER)
                .SetBorderBottom(Border.NO_BORDER);

               Cell cell62 = new Cell(1, 1)
                  .SetTextAlignment(TextAlignment.LEFT)
                  .Add(new Paragraph(periodname)
                                .SetFont(ft_montserrat_reg)
                                .SetFixedLeading(9f)
                                .SetFontColor(cl_grayDark)
                                .SetFontSize(9))
                .SetBackgroundColor(cl_tablecontent_22)
                .SetBorderLeft(Border.NO_BORDER)
                .SetBorderRight(Border.NO_BORDER)
                .SetBorderTop(Border.NO_BORDER)
                .SetBorderBottom(Border.NO_BORDER);

                //Row 7
                Cell cell71 = new Cell(1, 1)
                  .SetTextAlignment(TextAlignment.LEFT)
                  .Add(new Paragraph("Date ")
                                //.SetFont(ft_montserrat_reg)
                                .SetFixedLeading(9f)
                                .SetFontSize(9))
                .SetBackgroundColor(cl_tableheader)
                .SetBorderLeft(Border.NO_BORDER)
                .SetBorderRight(Border.NO_BORDER)
                .SetBorderTop(Border.NO_BORDER)
                .SetBorderBottom(Border.NO_BORDER);

               Cell cell72 = new Cell(1, 1)
                  .SetTextAlignment(TextAlignment.LEFT)
                  .Add(new Paragraph(DateTime.Now.Date.ToString("dd/MM/yyyy"))
                                .SetFont(ft_montserrat_reg)
                                .SetFixedLeading(9f)
                                .SetFontColor(cl_grayDark)
                                .SetFontSize(9))
                .SetBackgroundColor(cl_tablecontent_22)
                .SetBorderLeft(Border.NO_BORDER)
                .SetBorderRight(Border.NO_BORDER)
                .SetBorderTop(Border.NO_BORDER)
                .SetBorderBottom(Border.NO_BORDER);



                //Row 8
                Cell cell81 = new Cell(1, 1)
                  .SetTextAlignment(TextAlignment.LEFT)
                  .Add(new Paragraph("Total Budget ")
                               // .SetFont(ft_montserrat_reg)
                                .SetFixedLeading(9f)
                                .SetFontSize(9))
                .SetBackgroundColor(cl_tableheader)
                .SetBorderLeft(Border.NO_BORDER)
                .SetBorderRight(Border.NO_BORDER)
                .SetBorderTop(Border.NO_BORDER)
                .SetBorderBottom(Border.NO_BORDER);

               Cell cell82 = new Cell(1, 1)
                  .SetTextAlignment(TextAlignment.LEFT)
                  .Add(new Paragraph(string.Format("{0:N2}", totalbudget)+" USD")
                                .SetFont(ft_montserrat_reg)
                                .SetFixedLeading(9f)
                                .SetFontColor(cl_grayDark)
                                .SetFontSize(9))
                .SetBackgroundColor(cl_tablecontent_22)
                .SetBorderLeft(Border.NO_BORDER)
                .SetBorderRight(Border.NO_BORDER)
                .SetBorderTop(Border.NO_BORDER)
                .SetBorderBottom(Border.NO_BORDER);





                //Row last
                Cell celllast1 = new Cell(1, 1)
                  .SetTextAlignment(TextAlignment.LEFT)
                  .Add(new Paragraph("Status ")
                               // .SetFont(ft_montserrat_reg)
                                .SetFixedLeading(12f)
                                .SetFontSize(10))
                .SetBackgroundColor(cl_tableheader)
                .SetBorderLeft(Border.NO_BORDER)
                .SetBorderRight(Border.NO_BORDER)
                .SetBorderTop(Border.NO_BORDER);

               Cell celllast2 = new Cell(1, 1)
                  .SetTextAlignment(TextAlignment.LEFT)
                  .Add(new Paragraph(mainrec.WP_ApprovalStatus)
                                .SetFont(ft_montserrat_reg)
                                .SetFixedLeading(12f)
                                .SetFontColor(cl_grayDark)
                                //.SetFontColor(cl_red)
                                .SetFontSize(9))
                .SetBackgroundColor(cl_tablecontent_22)
                .SetBorderLeft(Border.NO_BORDER)
                .SetBorderRight(Border.NO_BORDER)
                .SetBorderTop(Border.NO_BORDER);


               table.AddCell(cell11);
               table.AddCell(cell12);

               table.AddCell(cell21);
               table.AddCell(cell22);

               table.AddCell(cell31);
               table.AddCell(cell32);

               table.AddCell(cell41);
               table.AddCell(cell42);

                table.AddCell(cell51);
               table.AddCell(cell52);

                table.AddCell(cell61);
               table.AddCell(cell62);

                table.AddCell(cell71);
               table.AddCell(cell72);

                table.AddCell(cell81);
               table.AddCell(cell82);


               table.AddCell(celllast1);
               table.AddCell(celllast2);


               document.Add(table);


               //Shared Variables
                int outeriter=0;
                int inneriter=0;
                bool row_alt=true;

                document.Add(txt_gap);

                /*Paragraph picons = new Paragraph();
                picons.Add(new Text("\ue000\ue0bb\ue14d").SetFont(ft_materialicons_fonts).SetFontSize(12).SetFontColor(cl));
                picons.Add(new Text(" This is cool").SetFont(ft).SetFontSize(12).SetFontColor(cl));
               // Paragraph picons = new Paragraph("\ue000\ue0bb\ue14d").SetFont(ft_materialicons_fonts).SetFontSize(12).SetFontColor(cl);
                
                document.Add(picons);
                document.Add(txt_gap);*/
                //Group by Outputs
               
               Paragraph wpoutcomes = new Paragraph("SECTION A: Workplan Outcomes")
                .SetTextAlignment(TextAlignment.LEFT)
                .SetFont(ft)
                .SetFontColor(cl)
                .SetFixedLeading(11f)
                .SetFontSize(15);
                document.Add(wpoutcomes);



                var DB_Outcomes =  _wpOutcomesRepository.GetRecordsByMainRecordId(mainrec.Transaction_Id).ToList();

                


                foreach (var recordset in DB_Outcomes)
                {


                   float indentmargin_outer=document.GetLeftMargin()+49;
                    Table tableactivity_outer = new Table(UnitValue.CreatePercentArray(new float[]{4, 96}), false)
                                        .SetWidth(PageSize.A4.GetWidth()-indentmargin_outer)
                                        .SetMarginLeft(14)
                                        .SetHorizontalAlignment(HorizontalAlignment.LEFT);

                        Cell cellbullet = new Cell(1, 1)
                        .SetTextAlignment(TextAlignment.LEFT)
                        .Add(new Paragraph("\ue837")
                                        .SetFont(ft_materialicons_fonts)
                                        .SetFixedLeading(14f)
                                        .SetFontColor(cl_green)
                                        .SetFontSize(10))
                            .SetBorder(Border.NO_BORDER);

                        Cell celltxt= new Cell(1, 1)
                        .SetTextAlignment(TextAlignment.JUSTIFIED)
                        .Add(new Paragraph(recordset.Outcome)
                                        .SetFixedLeading(14f)
                                       // .SetFont(ft_helveticaneue)
                                        .SetFontColor(cl_green)
                                        .SetFontSize(10))
                            
                            .SetBorder(Border.NO_BORDER);

                    tableactivity_outer.AddCell(cellbullet);
                    tableactivity_outer.AddCell(celltxt);

                    document.Add(tableactivity_outer);
                    document.Add(txt);


                    
                }

              


                document.Add(txt_gap);



                //Group by Outputs
                Paragraph grpbyoutputs = new Paragraph("SECTION B: Activities Grouped by Outputs")
                .SetTextAlignment(TextAlignment.LEFT)
                .SetFont(ft)
                .SetFontColor(cl)
                .SetFixedLeading(11f)
                .SetFontSize(15);
                document.Add(grpbyoutputs);

                var DB_Outputs =  _wpOutputsRepository.GetRecordsByMainRecordId(mainrec.Transaction_Id).ToList();

                outeriter=0;

               
                
                foreach (var recordset in DB_Outputs)
                {
                    outeriter=outeriter+1;


                    float indentmargin_outer=document.GetLeftMargin()+49;
                    Table tableactivity_outer = new Table(UnitValue.CreatePercentArray(new float[]{4, 96}), false)
                                        .SetWidth(PageSize.A4.GetWidth()-indentmargin_outer)
                                        .SetMarginLeft(14)
                                        .SetHorizontalAlignment(HorizontalAlignment.LEFT);

                        Cell cellbullet = new Cell(1, 1)
                        .SetTextAlignment(TextAlignment.LEFT)
                        .Add(new Paragraph("\ue837")
                                        .SetFont(ft_materialicons_fonts)
                                        .SetFixedLeading(14f)
                                        .SetFontColor(cl_green)
                                        .SetFontSize(10))
                            .SetBorder(Border.NO_BORDER);

                        Cell celltxt= new Cell(1, 1)
                        .SetTextAlignment(TextAlignment.JUSTIFIED)
                        .Add(new Paragraph(recordset.Output)
                                        .SetFixedLeading(14f)
                                       // .SetFont(ft_helveticaneue)
                                        .SetFontColor(cl_green)
                                        .SetFontSize(10))
                            
                            .SetBorder(Border.NO_BORDER);

                    tableactivity_outer.AddCell(cellbullet);
                    tableactivity_outer.AddCell(celltxt);

                    document.Add(tableactivity_outer);
                    document.Add(txt);





                    float indentmargin=document.GetLeftMargin()+74;
                    float tablewidth=PageSize.A4.GetWidth()-indentmargin;
                    Table tableactivity = new Table(UnitValue.CreatePercentArray(new float[]{35, 20, 27, 18}), false)
                                        .SetWidth(PageSize.A4.GetWidth()-indentmargin)
                                        .SetMarginLeft(37)
                                        .SetHorizontalAlignment(HorizontalAlignment.LEFT);

                    var DB_Activities=_wpOutputActivitiesRepository.GetRecordsByOutputId(recordset.Transaction_Id);

                    if(DB_Activities.Count()>=1)
                    {
                        



                        //Row Header
                        Cell cellheader01 = new Cell(1, 1)
                        .SetTextAlignment(TextAlignment.LEFT)
                        .Add(new Paragraph("ACTIVITY")
                                        //.SetFont(ft_montserrat_medium)
                                        .SetFixedLeading(14f)
                                        .SetFontColor(cl_grayDark)
                                        .SetBackgroundColor(cl_tableheader)
                                        .SetFontSize(10))
                            .SetBackgroundColor(cl_tableheader);

                        tableactivity.AddCell(cellheader01);

                        Cell cellheader02 = new Cell(1, 1)
                            .SetTextAlignment(TextAlignment.LEFT)
                            .Add(new Paragraph("TYPE")
                                          //  .SetFont(ft_montserrat_medium)
                                            .SetFixedLeading(14f)
                                            .SetFontColor(cl_grayDark)
                                            .SetBackgroundColor(cl_tableheader)
                                            .SetFontSize(10))
                            .SetBackgroundColor(cl_tableheader);
                        tableactivity.AddCell(cellheader02);


                        Cell cellheader03 = new Cell(1, 1)
                            .SetTextAlignment(TextAlignment.LEFT)
                            .Add(new Paragraph("PERIOD")
                                           // .SetFont(ft_montserrat_medium)
                                            .SetFixedLeading(14f)
                                            .SetFontColor(cl_grayDark)
                                            .SetBackgroundColor(cl_tableheader)
                                            .SetFontSize(10))
                            .SetBackgroundColor(cl_tableheader);
                        tableactivity.AddCell(cellheader03);

                        Cell cellheader04 = new Cell(1, 1)
                            .SetTextAlignment(TextAlignment.RIGHT)
                            .Add(new Paragraph("AMOUNT (USD)")
                                           // .SetFont(ft_montserrat_medium)
                                            .SetFixedLeading(14f)
                                            .SetFontColor(cl_grayDark)
                                            .SetBackgroundColor(cl_tableheader)
                                            .SetFontSize(10))
                            .SetBackgroundColor(cl_tableheader);
                        tableactivity.AddCell(cellheader04);

                        int activitycount=DB_Activities.Count();




                        foreach (var activity in DB_Activities)
                        {
                            inneriter=inneriter+1;

                            Cell cell1 = new Cell(1, 1);
                            Cell cell2 = new Cell(1, 1);
                            Cell cell3 = new Cell(1, 1);
                            Cell cell4 = new Cell(1, 1);

                            DateTime start= new  DateTime(activity.ActivityStartDate.Year, activity.ActivityStartDate.Month, activity.ActivityStartDate.Day);
                            DateTime end= new  DateTime(activity.ActivityEndDate.Year, activity.ActivityEndDate.Month, activity.ActivityEndDate.Day);
                            string period=start.Date.ToString("MMM. d, yyyy")+" - "+end.Date.ToString("MMM. d, yyyy");

                            if(row_alt==false)
                            {
                                //Row Rows
                                cell1.SetTextAlignment(TextAlignment.JUSTIFIED)
                                .Add(new Paragraph(activity.ActivityDescription)
                                                //.SetFont(ft_montserrat_reg)
                                                .SetFixedLeading(14f)
                                                .SetFontColor(cl_grayDark)
                                                .SetBackgroundColor(cl_tablecontent_1)
                                                .SetFontSize(9))
                                    .SetBackgroundColor(cl_tablecontent_1)
                                    .SetBorderTop(Border.NO_BORDER)
                                    .SetBorderBottom(Border.NO_BORDER);


                             
                                    cell2.SetTextAlignment(TextAlignment.LEFT)
                                    .Add(new Paragraph(_lkupActivityTypeRepository.GetActivityType(activity.ActivityType_Id).Activity_Name)
                                                    //.SetFont(ft_montserrat_reg)
                                                    .SetFixedLeading(14f)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tablecontent_1)
                                                    .SetFontSize(9))
                                    .SetBackgroundColor(cl_tablecontent_1)
                                    .SetBorderTop(Border.NO_BORDER)
                                    .SetBorderBottom(Border.NO_BORDER);




                                    cell3.SetTextAlignment(TextAlignment.LEFT)
                                    .Add(new Paragraph(period)
                                                   // .SetFont(ft_montserrat_reg)
                                                    .SetFixedLeading(14f)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tablecontent_1)
                                                    .SetFontSize(9))
                                    .SetBackgroundColor(cl_tablecontent_1)
                                    .SetBorderTop(Border.NO_BORDER)
                                    .SetBorderBottom(Border.NO_BORDER);



                                cell4.SetTextAlignment(TextAlignment.RIGHT)
                                    .Add(new Paragraph(string.Format("{0:N2}", activity.ActivityCost))
                                                   // .SetFont(ft_montserrat_reg)
                                                    .SetFixedLeading(14f)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tablecontent_1)
                                                    .SetFontSize(9))
                                    .SetBackgroundColor(cl_tablecontent_1)
                                    .SetBorderTop(Border.NO_BORDER)
                                    .SetBorderBottom(Border.NO_BORDER);

                            }
                            else
                            {
                                //Row Rows

                                cell1.SetTextAlignment(TextAlignment.JUSTIFIED)
                                    .Add(new Paragraph(activity.ActivityDescription)
                                                   // .SetFont(ft_montserrat_reg)
                                                    .SetFixedLeading(14f)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tablecontent_2)
                                                    .SetFontSize(9))
                                        .SetBackgroundColor(cl_tablecontent_2)
                                        .SetBorderTop(Border.NO_BORDER)
                                        .SetBorderBottom(Border.NO_BORDER);



                                cell2.SetTextAlignment(TextAlignment.LEFT)
                                    .Add(new Paragraph(_lkupActivityTypeRepository.GetActivityType(activity.ActivityType_Id).Activity_Name)
                                                   // .SetFont(ft_montserrat_reg)
                                                    .SetFixedLeading(14f)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tablecontent_2)
                                                    .SetFontSize(9))
                                    .SetBackgroundColor(cl_tablecontent_2)
                                    .SetBorderTop(Border.NO_BORDER)
                                    .SetBorderBottom(Border.NO_BORDER);
    



                                cell3.SetTextAlignment(TextAlignment.LEFT)
                                    .Add(new Paragraph(period)
                                                   // .SetFont(ft_montserrat_reg)
                                                    .SetFixedLeading(14f)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tablecontent_2)
                                                    .SetFontSize(9))
                                    .SetBackgroundColor(cl_tablecontent_2)
                                    .SetBorderTop(Border.NO_BORDER)
                                    .SetBorderBottom(Border.NO_BORDER);
   


                                cell4.SetTextAlignment(TextAlignment.RIGHT)
                                    .Add(new Paragraph(string.Format("{0:N2}", activity.ActivityCost))
                                                    //.SetFont(ft_montserrat_reg)
                                                    .SetFixedLeading(14f)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tablecontent_2)
                                                    .SetFontSize(9))
                                    .SetBackgroundColor(cl_tablecontent_2)
                                    .SetBorderTop(Border.NO_BORDER)
                                    .SetBorderBottom(Border.NO_BORDER);
                                

                            }

                            row_alt=ToggleBoolean(row_alt);
                            if(inneriter==activitycount)
                            {
                                cell1.SetBorderBottom(new SolidBorder(1f));
                                cell2.SetBorderBottom(new SolidBorder(1f));
                                cell3.SetBorderBottom(new SolidBorder(1f));
                                cell4.SetBorderBottom(new SolidBorder(1f));

                            }

                            tableactivity.AddCell(cell1);
                            tableactivity.AddCell(cell2);
                            tableactivity.AddCell(cell3);   
                            tableactivity.AddCell(cell4);

                            

                        }

                        //Row WBS
                        if(recordset.WPSAPLink_Id!=null)
                        {
                            Cell cellheader0WBS = new Cell(1, 4)
                            .SetTextAlignment(TextAlignment.LEFT)
                            .Add(new Paragraph("SAP WBS: "+_wpSAPLinkRepository.GetRecord(recordset.WPSAPLink_Id).SAP_WBS)
                                            .SetFont(ft_montserrat_reg_it)
                                            .SetFixedLeading(14f)
                                            .SetFontColor(cl_grayDark)
                                            .SetFontSize(6))
                                .SetBorderLeft(Border.NO_BORDER)
                                .SetBorderRight(Border.NO_BORDER)
                                .SetBorderBottom(Border.NO_BORDER)
                                .SetBorderTop(Border.NO_BORDER);

                            tableactivity.AddCell(cellheader0WBS);
                        }
                        else{
                            Cell cellheader0WBS = new Cell(1, 4)
                            .SetTextAlignment(TextAlignment.LEFT)
                            .Add(new Paragraph("SAP WBS: (SAP WBS Not Assigned to Output)")
                                            .SetFont(ft_montserrat_reg_it)
                                            .SetFixedLeading(14f)
                                            .SetFontColor(cl_grayDark)
                                            .SetFontSize(6))
                                .SetBorderLeft(Border.NO_BORDER)
                                .SetBorderRight(Border.NO_BORDER)
                                .SetBorderBottom(Border.NO_BORDER)
                                .SetBorderTop(Border.NO_BORDER);

                            tableactivity.AddCell(cellheader0WBS);


                        }

                        inneriter=0;
                        row_alt=true;
                        document.Add(tableactivity);

                       
                    }
                    else
                    {
                        /*
                        Paragraph outputtextnoact = new Paragraph("No Activity Recorded")
                        .SetTextAlignment(TextAlignment.LEFT)
                        .SetFont(ft_montserrat_reg)
                        .SetFixedLeading(9f)
                        .SetFontColor(cl_grayDark)
                        .SetMarginLeft(37)
                        .SetFontSize(9);
                        document.Add(outputtextnoact);*/

                    }


                    document.Add(txt);
                    document.Add(txt);
                    
                    
                    
                }

                document.Add(txt_gap);

            //Begin** Group by Implementation Type
                Paragraph grpbyimptype = new Paragraph("SECTION C: Activities Grouped by Implementation Type")
                .SetTextAlignment(TextAlignment.LEFT)
                .SetFont(ft)
                .SetFontColor(cl)
                .SetFixedLeading(11f)
                .SetFontSize(15);
                document.Add(grpbyimptype);
                var DB_ImplementationTypes =  _transImplementationTypeRepository.GetAllRecords().ToList();

                foreach (var recordset in DB_ImplementationTypes)
                {

                    float indentmargin_outer=document.GetLeftMargin()+49;
                    Table tableactivity_outer = new Table(UnitValue.CreatePercentArray(new float[]{4, 96}), false)
                                        .SetWidth(PageSize.A4.GetWidth()-indentmargin_outer)
                                        .SetMarginLeft(14)
                                        .SetHorizontalAlignment(HorizontalAlignment.LEFT);

                        Cell cellbullet = new Cell(1, 1)
                        .SetTextAlignment(TextAlignment.LEFT)
                        .Add(new Paragraph("\ue837")
                                        .SetFont(ft_materialicons_fonts)
                                        .SetFixedLeading(14f)
                                        .SetFontColor(cl_green)
                                        .SetFontSize(10))
                            .SetBorder(Border.NO_BORDER);

                        Cell celltxt= new Cell(1, 1)
                        .SetTextAlignment(TextAlignment.JUSTIFIED)
                        .Add(new Paragraph(_lkupImplementationTypeRepository.GetRecord(recordset.Record_Id).Record_Name)
                                        .SetFixedLeading(14f)
                                        .SetFontColor(cl_green)
                                        .SetFontSize(10))
                            .SetBorder(Border.NO_BORDER);

                    tableactivity_outer.AddCell(cellbullet);
                    tableactivity_outer.AddCell(celltxt);

                    document.Add(tableactivity_outer);
                    document.Add(txt);

                    float indentmargin=document.GetLeftMargin()+74;
                    float tablewidth=PageSize.A4.GetWidth()-indentmargin;
                    Table tableactivity = new Table(UnitValue.CreatePercentArray(new float[]{35, 20, 27, 18}), false)
                                        .SetWidth(PageSize.A4.GetWidth()-indentmargin)
                                        .SetMarginLeft(37)
                                        .SetHorizontalAlignment(HorizontalAlignment.LEFT);

                    var DB_Activities=_wpOutputActivitiesRepository.GetRecordsByMainRecordImpType(mainrec.Transaction_Id, recordset.Record_Id);

                    if(DB_Activities.Count()>=1)
                    {
                        
                        //Row Header
                        Cell cellheader01 = new Cell(1, 1)
                        .SetTextAlignment(TextAlignment.LEFT)
                        .Add(new Paragraph("ACTIVITY")
                                      //  .SetFont(ft_montserrat_medium)
                                        .SetFixedLeading(14f)
                                        .SetFontColor(cl_grayDark)
                                        .SetBackgroundColor(cl_tableheader)
                                        .SetFontSize(10))
                            .SetBackgroundColor(cl_tableheader);

                        tableactivity.AddCell(cellheader01);

                        Cell cellheader02 = new Cell(1, 1)
                            .SetTextAlignment(TextAlignment.LEFT)
                            .Add(new Paragraph("TYPE")
                                            //.SetFont(ft_montserrat_medium)
                                            .SetFixedLeading(14f)
                                            .SetFontColor(cl_grayDark)
                                            .SetBackgroundColor(cl_tableheader)
                                            .SetFontSize(10))
                            .SetBackgroundColor(cl_tableheader);

                        tableactivity.AddCell(cellheader02);


                        Cell cellheader03 = new Cell(1, 1)
                            .SetTextAlignment(TextAlignment.LEFT)
                            .Add(new Paragraph("PERIOD")
                                            //.SetFont(ft_montserrat_medium)
                                            .SetFixedLeading(14f)
                                            .SetFontColor(cl_grayDark)
                                            .SetBackgroundColor(cl_tableheader)
                                            .SetFontSize(10))
                            .SetBackgroundColor(cl_tableheader);
          
                        tableactivity.AddCell(cellheader03);

                        Cell cellheader04 = new Cell(1, 1)
                            .SetTextAlignment(TextAlignment.RIGHT)
                            .Add(new Paragraph("AMOUNT (USD)")
                                            //.SetFont(ft_montserrat_medium)
                                            .SetFixedLeading(14f)
                                            .SetFontColor(cl_grayDark)
                                            .SetBackgroundColor(cl_tableheader)
                                            .SetFontSize(10))
                            .SetBackgroundColor(cl_tableheader);

                        tableactivity.AddCell(cellheader04);

                        int activitycount=DB_Activities.Count();




                        foreach (var activity in DB_Activities)
                        {
                            inneriter=inneriter+1;

                            Cell cell1 = new Cell(1, 1);
                            Cell cell2 = new Cell(1, 1);
                            Cell cell3 = new Cell(1, 1);
                            Cell cell4 = new Cell(1, 1);

                            DateTime start= new  DateTime(activity.ActivityStartDate.Year, activity.ActivityStartDate.Month, activity.ActivityStartDate.Day);
                            DateTime end= new  DateTime(activity.ActivityEndDate.Year, activity.ActivityEndDate.Month, activity.ActivityEndDate.Day);
                            string period=start.Date.ToString("MMM. d, yyyy")+" - "+end.Date.ToString("MMM. d, yyyy");

                            if(row_alt==false)
                            {
                                //Row Rows
                                cell1.SetTextAlignment(TextAlignment.LEFT)
                                .Add(new Paragraph(activity.ActivityDescription)
                                               // .SetFont(ft_montserrat_reg)
                                                .SetFixedLeading(14f)
                                                .SetFontColor(cl_grayDark)
                                                .SetBackgroundColor(cl_tablecontent_1)
                                                .SetFontSize(9))
                                    .SetBackgroundColor(cl_tablecontent_1)
                                    .SetBorderTop(Border.NO_BORDER)
                                    .SetBorderBottom(Border.NO_BORDER);


                             
                                    cell2.SetTextAlignment(TextAlignment.LEFT)
                                    .Add(new Paragraph(_lkupActivityTypeRepository.GetActivityType(activity.ActivityType_Id).Activity_Name)
                                                   // .SetFont(ft_montserrat_reg)
                                                    .SetFixedLeading(14f)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tablecontent_1)
                                                    .SetFontSize(9))
                                    .SetBackgroundColor(cl_tablecontent_1)
                                    .SetBorderTop(Border.NO_BORDER)
                                    .SetBorderBottom(Border.NO_BORDER);


                                    cell3.SetTextAlignment(TextAlignment.LEFT)
                                    .Add(new Paragraph(period)
                                                   // .SetFont(ft_montserrat_reg)
                                                    .SetFixedLeading(14f)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tablecontent_1)
                                                    .SetFontSize(9))
                                    .SetBackgroundColor(cl_tablecontent_1)
                                    .SetBorderTop(Border.NO_BORDER)
                                    .SetBorderBottom(Border.NO_BORDER);



                                cell4.SetTextAlignment(TextAlignment.RIGHT)
                                    .Add(new Paragraph(string.Format("{0:N2}", activity.ActivityCost))
                                                   // .SetFont(ft_montserrat_reg)
                                                    .SetFixedLeading(14f)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tablecontent_1)
                                                    .SetFontSize(9))
                                    .SetBackgroundColor(cl_tablecontent_1)
                                    .SetBorderTop(Border.NO_BORDER)
                                    .SetBorderBottom(Border.NO_BORDER);

                            }
                            else
                            {
                                //Row Rows

                                cell1.SetTextAlignment(TextAlignment.LEFT)
                                    .Add(new Paragraph(activity.ActivityDescription)
                                                   // .SetFont(ft_montserrat_reg)
                                                    .SetFixedLeading(14f)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tablecontent_2)
                                                    .SetFontSize(9))
                                        .SetBackgroundColor(cl_tablecontent_2)
                                        .SetBorderTop(Border.NO_BORDER)
                                        .SetBorderBottom(Border.NO_BORDER);



                                cell2.SetTextAlignment(TextAlignment.LEFT)
                                    .Add(new Paragraph(_lkupActivityTypeRepository.GetActivityType(activity.ActivityType_Id).Activity_Name)
                                                   // .SetFont(ft_montserrat_reg)
                                                    .SetFixedLeading(14f)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tablecontent_2)
                                                    .SetFontSize(9))
                                    .SetBackgroundColor(cl_tablecontent_2)
                                    .SetBorderTop(Border.NO_BORDER)
                                    .SetBorderBottom(Border.NO_BORDER);

                                cell3.SetTextAlignment(TextAlignment.LEFT)
                                    .Add(new Paragraph(period)
                                                  //  .SetFont(ft_montserrat_reg)
                                                    .SetFixedLeading(14f)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tablecontent_2)
                                                    .SetFontSize(9))
                                    .SetBackgroundColor(cl_tablecontent_2)
                                    .SetBorderTop(Border.NO_BORDER)
                                    .SetBorderBottom(Border.NO_BORDER);
   


                                cell4.SetTextAlignment(TextAlignment.RIGHT)
                                    .Add(new Paragraph(string.Format("{0:N2}", activity.ActivityCost))
                                                    //.SetFont(ft_montserrat_reg)
                                                    .SetFixedLeading(14f)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tablecontent_2)
                                                    .SetFontSize(9))
                                    .SetBackgroundColor(cl_tablecontent_2)
                                    .SetBorderTop(Border.NO_BORDER)
                                    .SetBorderBottom(Border.NO_BORDER);
                                

                            }

                            row_alt=ToggleBoolean(row_alt);
                            if(inneriter==activitycount)
                            {
                                cell1.SetBorderBottom(new SolidBorder(1f));
                                cell2.SetBorderBottom(new SolidBorder(1f));
                                cell3.SetBorderBottom(new SolidBorder(1f));
                                cell4.SetBorderBottom(new SolidBorder(1f));

                            }

                            tableactivity.AddCell(cell1);
                            tableactivity.AddCell(cell2);
                            tableactivity.AddCell(cell3);   
                            tableactivity.AddCell(cell4);

                            

                        }

                        

                        inneriter=0;
                        row_alt=true;
                        document.Add(tableactivity);

                       
                    }
                    else
                    {
                        /*Paragraph outputtextnoact = new Paragraph("No Activity Recorded")
                        .SetTextAlignment(TextAlignment.LEFT)
                        .SetFont(ft_montserrat_reg)
                        .SetFixedLeading(9f)
                        .SetFontColor(cl_grayDark)
                        .SetMarginLeft(37)
                        .SetFontSize(9);
                        document.Add(outputtextnoact);*/

                    }

                    document.Add(txt);
                    document.Add(txt);

                }


                document.Add(txt_gap);



                //Get Period Name for section head
                string periodnamesection="";
                if(mainrec.Period_Id==8)
                {
                    DateTime pstart=new DateTime(mainrec.PeriodStartDate.Year, mainrec.PeriodStartDate.Month, mainrec.PeriodStartDate.Day);
                    DateTime pend=new DateTime(mainrec.PeriodEndDate.Year, mainrec.PeriodEndDate.Month, mainrec.PeriodEndDate.Day);
                    periodnamesection=pstart.Date.ToString("MMM d, yy") + " - "+ pend.Date.ToString("MMM d, yy"); 
                }
                else
                {
                    periodnamesection=_lkupPeriodRepository.GetRecord(mainrec.Period_Id).Record_Name;
                }

                
                if(mainrec.Period_Id==7)
                {
                                            
                    //Group by Months
                    Paragraph grpbymonths = new Paragraph("SECTION D: Activities Grouped by Months in "+_lkupFiscalYearRepository.GetRecord(mainrec.FiscalYear_Id).Record_Name)
                    .SetTextAlignment(TextAlignment.LEFT)
                    .SetFont(ft)
                    .SetFontColor(cl)
                    .SetFixedLeading(11f)
                    .SetFontSize(15);
                    document.Add(grpbymonths);
                }
                else
                {
                    //Group by Months
                    Paragraph grpbymonths = new Paragraph("SECTION D: Activities Grouped by Months in "+_lkupFiscalYearRepository.GetRecord(mainrec.FiscalYear_Id).Record_Name+" ("+periodnamesection+")")
                    .SetTextAlignment(TextAlignment.LEFT)
                    .SetFont(ft)
                    .SetFontColor(cl)
                    .SetFixedLeading(11f)
                    .SetFontSize(15);
                    document.Add(grpbymonths);

                }


                switch(mainrec.Period_Id)
                {
                    case 1 :
                        int[] months_1 = { 1, 2, 3 };

                        foreach (var i in months_1)
                        {
                            float indentmargin_outer11=document.GetLeftMargin()+49;
                            Table tableactivity_outer11 = new Table(UnitValue.CreatePercentArray(new float[]{4, 96}), false)
                                                .SetWidth(PageSize.A4.GetWidth()-indentmargin_outer11)
                                                .SetMarginLeft(14)
                                                .SetHorizontalAlignment(HorizontalAlignment.LEFT);

                                Cell cellbullet11 = new Cell(1, 1)
                                .SetTextAlignment(TextAlignment.LEFT)
                                .Add(new Paragraph("\ue837")
                                                .SetFont(ft_materialicons_fonts)
                                                .SetFixedLeading(14f)
                                                .SetFontColor(cl_green)
                                                .SetFontSize(10))
                                    .SetBorder(Border.NO_BORDER);

                                Cell celltxt11= new Cell(1, 1)
                                .SetTextAlignment(TextAlignment.JUSTIFIED)
                                .Add(new Paragraph(System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i))
                                                .SetFixedLeading(14f)
                                                .SetFontColor(cl_green)
                                                .SetFontSize(10))
                                    .SetBorder(Border.NO_BORDER);

                            tableactivity_outer11.AddCell(cellbullet11);
                            tableactivity_outer11.AddCell(celltxt11);

                            document.Add(tableactivity_outer11);
                            document.Add(txt);

                            float indentmargin=document.GetLeftMargin()+74;
                            float tablewidth=PageSize.A4.GetWidth()-indentmargin;
                            Table tableactivity_11 = new Table(UnitValue.CreatePercentArray(new float[]{35, 20, 27, 18}), false)
                                .SetWidth(PageSize.A4.GetWidth()-indentmargin)
                                .SetMarginLeft(37)
                                .SetHorizontalAlignment(HorizontalAlignment.LEFT);


                            var DB_Activities11=_wpOutputActivitiesRepository.GetRecordsByMainRecordId(mainrec.Transaction_Id);

                            int actualrecords11=0;
                            foreach (var activity in DB_Activities11)
                            {
                                if(WithinMonth(mainrec.FiscalYear_Id, i, new DateTime(activity.ActivityStartDate.Year, activity.ActivityStartDate.Month, activity.ActivityStartDate.Day), new DateTime(activity.ActivityEndDate.Year, activity.ActivityEndDate.Month, activity.ActivityEndDate.Day))==true)
                                    actualrecords11=actualrecords11+1;
                            }

                            if(actualrecords11>=1)
                            {
                                //Row Header
                                Cell cellheader01 = new Cell(1, 1)
                                .SetTextAlignment(TextAlignment.LEFT)
                                .Add(new Paragraph("ACTIVITY")
                                                //.SetFont(ft_montserrat_medium)
                                                .SetFixedLeading(14f)
                                                .SetFontColor(cl_grayDark)
                                                .SetBackgroundColor(cl_tableheader)
                                                .SetFontSize(10))
                                    .SetBackgroundColor(cl_tableheader);

                                tableactivity_11.AddCell(cellheader01);

                                Cell cellheader02 = new Cell(1, 1)
                                    .SetTextAlignment(TextAlignment.LEFT)
                                    .Add(new Paragraph("TYPE")
                                                // .SetFont(ft_montserrat_medium)
                                                    .SetFixedLeading(14f)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tableheader)
                                                    .SetFontSize(10))
                                    .SetBackgroundColor(cl_tableheader);

                                tableactivity_11.AddCell(cellheader02);


                                Cell cellheader03 = new Cell(1, 1)
                                    .SetTextAlignment(TextAlignment.LEFT)
                                    .Add(new Paragraph("PERIOD")
                                                    .SetFont(ft_montserrat_medium)
                                                    .SetFixedLeading(14f)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tableheader)
                                                    .SetFontSize(10))
                                    .SetBackgroundColor(cl_tableheader);

                                tableactivity_11.AddCell(cellheader03);

                                Cell cellheader04 = new Cell(1, 1)
                                    .SetTextAlignment(TextAlignment.RIGHT)
                                    .Add(new Paragraph("AMOOUNT (USD)")
                                                // .SetFont(ft_montserrat_medium)
                                                    .SetFixedLeading(14f)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tableheader)
                                                    .SetFontSize(10))
                                    .SetBackgroundColor(cl_tableheader);

                                tableactivity_11.AddCell(cellheader04);

                                int activitycount=actualrecords11;

                                foreach (var activity in DB_Activities11)
                                {
                                    if(WithinMonth(mainrec.FiscalYear_Id, i, new DateTime(activity.ActivityStartDate.Year, activity.ActivityStartDate.Month, activity.ActivityStartDate.Day), new DateTime(activity.ActivityEndDate.Year, activity.ActivityEndDate.Month, activity.ActivityEndDate.Day)))
                                    {
                                        inneriter=inneriter+1;

                                        Cell cell1 = new Cell(1, 1);
                                        Cell cell2 = new Cell(1, 1);
                                        Cell cell3 = new Cell(1, 1);
                                        Cell cell4 = new Cell(1, 1);

                                        DateTime start= new  DateTime(activity.ActivityStartDate.Year, activity.ActivityStartDate.Month, activity.ActivityStartDate.Day);
                                        DateTime end= new  DateTime(activity.ActivityEndDate.Year, activity.ActivityEndDate.Month, activity.ActivityEndDate.Day);
                                        string period=start.Date.ToString("MMM. d, yyyy")+" - "+end.Date.ToString("MMM. d, yyyy");

                                        if(row_alt==false)
                                        {
                                            //Row Rows
                                            cell1.SetTextAlignment(TextAlignment.LEFT)
                                            .Add(new Paragraph(activity.ActivityDescription)
                                                        // .SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_1)
                                                            .SetFontSize(9))
                                                .SetBackgroundColor(cl_tablecontent_1)
                                                .SetBorderTop(Border.NO_BORDER)
                                                .SetBorderBottom(Border.NO_BORDER);


                                        
                                                cell2.SetTextAlignment(TextAlignment.LEFT)
                                                .Add(new Paragraph(_lkupActivityTypeRepository.GetActivityType(activity.ActivityType_Id).Activity_Name)
                                                            // .SetFont(ft_montserrat_reg)
                                                                .SetFixedLeading(14f)
                                                                .SetFontColor(cl_grayDark)
                                                                .SetBackgroundColor(cl_tablecontent_1)
                                                                .SetFontSize(9))
                                                .SetBackgroundColor(cl_tablecontent_1)
                                                .SetBorderTop(Border.NO_BORDER)
                                                .SetBorderBottom(Border.NO_BORDER);


                                                cell3.SetTextAlignment(TextAlignment.LEFT)
                                                .Add(new Paragraph(period)
                                                                //.SetFont(ft_montserrat_reg)
                                                                .SetFixedLeading(14f)
                                                                .SetFontColor(cl_grayDark)
                                                                .SetBackgroundColor(cl_tablecontent_1)
                                                                .SetFontSize(9))
                                                .SetBackgroundColor(cl_tablecontent_1)
                                                .SetBorderTop(Border.NO_BORDER)
                                                .SetBorderBottom(Border.NO_BORDER);



                                            cell4.SetTextAlignment(TextAlignment.RIGHT)
                                                .Add(new Paragraph(string.Format("{0:N2}", activity.ActivityCost))
                                                                //.SetFont(ft_montserrat_reg)
                                                                .SetFixedLeading(14f)
                                                                .SetFontColor(cl_grayDark)
                                                                .SetBackgroundColor(cl_tablecontent_1)
                                                                .SetFontSize(9))
                                                .SetBackgroundColor(cl_tablecontent_1)
                                                .SetBorderTop(Border.NO_BORDER)
                                                .SetBorderBottom(Border.NO_BORDER);


                                        }
                                        else
                                        {
                                            //Row Rows

                                            cell1.SetTextAlignment(TextAlignment.LEFT)
                                                .Add(new Paragraph(activity.ActivityDescription)
                                                                //.SetFont(ft_montserrat_reg)
                                                                .SetFixedLeading(14f)
                                                                .SetFontColor(cl_grayDark)
                                                                .SetBackgroundColor(cl_tablecontent_2)
                                                                .SetFontSize(9))
                                                    .SetBackgroundColor(cl_tablecontent_2)
                                                    .SetBorderTop(Border.NO_BORDER)
                                                    .SetBorderBottom(Border.NO_BORDER);



                                            cell2.SetTextAlignment(TextAlignment.LEFT)
                                                .Add(new Paragraph(_lkupActivityTypeRepository.GetActivityType(activity.ActivityType_Id).Activity_Name)
                                                                //.SetFont(ft_montserrat_reg)
                                                                .SetFixedLeading(14f)
                                                                .SetFontColor(cl_grayDark)
                                                                .SetBackgroundColor(cl_tablecontent_2)
                                                                .SetFontSize(9))
                                                .SetBackgroundColor(cl_tablecontent_2)
                                                .SetBorderTop(Border.NO_BORDER)
                                                .SetBorderBottom(Border.NO_BORDER);




                                            cell3.SetTextAlignment(TextAlignment.LEFT)
                                                .Add(new Paragraph(period)
                                                                //.SetFont(ft_montserrat_reg)
                                                                .SetFixedLeading(14f)
                                                                .SetFontColor(cl_grayDark)
                                                                .SetBackgroundColor(cl_tablecontent_2)
                                                                .SetFontSize(9))
                                                .SetBackgroundColor(cl_tablecontent_2)
                                                .SetBorderTop(Border.NO_BORDER)
                                                .SetBorderBottom(Border.NO_BORDER);



                                            cell4.SetTextAlignment(TextAlignment.RIGHT)
                                                .Add(new Paragraph(string.Format("{0:N2}", activity.ActivityCost))
                                                                //.SetFont(ft_montserrat_reg)
                                                                .SetFixedLeading(14f)
                                                                .SetFontColor(cl_grayDark)
                                                                .SetBackgroundColor(cl_tablecontent_2)
                                                                .SetFontSize(9))
                                                .SetBackgroundColor(cl_tablecontent_2)
                                                .SetBorderTop(Border.NO_BORDER)
                                                .SetBorderBottom(Border.NO_BORDER);
                                            

                                        }

                                        row_alt=ToggleBoolean(row_alt);
                                        if(inneriter==activitycount)
                                        {
                                            cell1.SetBorderBottom(new SolidBorder(1f));
                                            cell2.SetBorderBottom(new SolidBorder(1f));
                                            cell3.SetBorderBottom(new SolidBorder(1f));
                                            cell4.SetBorderBottom(new SolidBorder(1f));

                                        }

                                        tableactivity_11.AddCell(cell1);
                                        tableactivity_11.AddCell(cell2);
                                        tableactivity_11.AddCell(cell3);   
                                        tableactivity_11.AddCell(cell4);

                                    }

                                }

                                inneriter=0;
                                row_alt=true;
                                document.Add(tableactivity_11);

                                
                            }

                            document.Add(txt);
                            document.Add(txt);
                        }
            

                        float indentmargin_outer112=document.GetLeftMargin()+49;
                        Table tableactivity_outer112 = new Table(UnitValue.CreatePercentArray(new float[]{4, 96}), false)
                                            .SetWidth(PageSize.A4.GetWidth()-indentmargin_outer112)
                                            .SetMarginLeft(14)
                                            .SetHorizontalAlignment(HorizontalAlignment.LEFT);

                            Cell cellbullet112 = new Cell(1, 1)
                            .SetTextAlignment(TextAlignment.LEFT)
                            .Add(new Paragraph("\ue837")
                                            .SetFont(ft_materialicons_fonts)
                                            .SetFixedLeading(14f)
                                            .SetFontColor(cl_green)
                                            .SetFontSize(10))
                                .SetBorder(Border.NO_BORDER);

                            Cell celltxt112= new Cell(1, 1)
                            .SetTextAlignment(TextAlignment.JUSTIFIED)
                            .Add(new Paragraph("Activities Spanning Multiple Months")
                                            .SetFixedLeading(14f)
                                            .SetFontColor(cl_green)
                                            .SetFontSize(10))
                                .SetBorder(Border.NO_BORDER);

                        tableactivity_outer112.AddCell(cellbullet112);
                        tableactivity_outer112.AddCell(celltxt112);

                        document.Add(tableactivity_outer112);
                        document.Add(txt);

                        

                        float indentmargin_spanning112=document.GetLeftMargin()+74;
                        Table tableactivity_spanning112 = new Table(UnitValue.CreatePercentArray(new float[]{35, 20, 27, 18}), false)
                            .SetWidth(PageSize.A4.GetWidth()-indentmargin_spanning112)
                            .SetMarginLeft(37)
                            .SetHorizontalAlignment(HorizontalAlignment.LEFT);


                        var DB_Activities_spanning112=_wpOutputActivitiesRepository.GetRecordsByMainRecordId(mainrec.Transaction_Id);

                        DateTime startperiod_spanning112=new DateTime(Int32.Parse(_lkupFiscalYearRepository.GetRecord(mainrec.FiscalYear_Id).Record_Name) , 1, 1);
                        DateTime endperiod_spanning112=new DateTime(Int32.Parse(_lkupFiscalYearRepository.GetRecord(mainrec.FiscalYear_Id).Record_Name) , 3, DateTime.DaysInMonth(mainrec.FiscalYear_Id, 3));

                        int actualrecords_spanning112=0;
                        foreach (var activity in DB_Activities_spanning112)
                        {
                            if(IsActivitySpanningMultipleMonths(mainrec.FiscalYear_Id, months_1, new DateTime(activity.ActivityStartDate.Year, activity.ActivityStartDate.Month, activity.ActivityStartDate.Day), new DateTime(activity.ActivityEndDate.Year, activity.ActivityEndDate.Month, activity.ActivityEndDate.Day), startperiod_spanning112, endperiod_spanning112)==true)
                                actualrecords_spanning112=actualrecords_spanning112+1;
                        }
                        if(actualrecords_spanning112>=1)
                        {
                            //Row Header
                            Cell cellheader01 = new Cell(1, 1)
                            .SetTextAlignment(TextAlignment.LEFT)
                            .Add(new Paragraph("ACTIVITY")
                                            //.SetFont(ft_montserrat_medium)
                                            .SetFixedLeading(14f)
                                            .SetFontColor(cl_grayDark)
                                            .SetBackgroundColor(cl_tableheader)
                                            .SetFontSize(10))
                                .SetBackgroundColor(cl_tableheader);
                            tableactivity_spanning112.AddCell(cellheader01);

                            Cell cellheader02 = new Cell(1, 1)
                                .SetTextAlignment(TextAlignment.LEFT)
                                .Add(new Paragraph("TYPE")
                                                // .SetFont(ft_montserrat_medium)
                                                .SetFixedLeading(14f)
                                                .SetFontColor(cl_grayDark)
                                                .SetBackgroundColor(cl_tableheader)
                                                .SetFontSize(10))
                                .SetBackgroundColor(cl_tableheader);
                            tableactivity_spanning112.AddCell(cellheader02);


                            Cell cellheader03 = new Cell(1, 1)
                                .SetTextAlignment(TextAlignment.LEFT)
                                .Add(new Paragraph("PERIOD")
                                                //.SetFont(ft_montserrat_medium)
                                                .SetFixedLeading(14f)
                                                .SetFontColor(cl_grayDark)
                                                .SetBackgroundColor(cl_tableheader)
                                                .SetFontSize(10))
                                .SetBackgroundColor(cl_tableheader);
                            tableactivity_spanning112.AddCell(cellheader03);

                            Cell cellheader04 = new Cell(1, 1)
                                .SetTextAlignment(TextAlignment.RIGHT)
                                .Add(new Paragraph("AMOUNT (USD)")
                                                //.SetFont(ft_montserrat_medium)
                                                .SetFixedLeading(14f)
                                                .SetFontColor(cl_grayDark)
                                                .SetBackgroundColor(cl_tableheader)
                                                .SetFontSize(10))
                                .SetBackgroundColor(cl_tableheader);

                            tableactivity_spanning112.AddCell(cellheader04);

                            int activitycount=actualrecords_spanning112;

                            foreach (var activity in DB_Activities_spanning112)
                            {
                                if(IsActivitySpanningMultipleMonths(mainrec.FiscalYear_Id, months_1, new DateTime(activity.ActivityStartDate.Year, activity.ActivityStartDate.Month, activity.ActivityStartDate.Day), new DateTime(activity.ActivityEndDate.Year, activity.ActivityEndDate.Month, activity.ActivityEndDate.Day), startperiod_spanning112, endperiod_spanning112))
                                {
                                    inneriter=inneriter+1;

                                    Cell cell1 = new Cell(1, 1);
                                    Cell cell2 = new Cell(1, 1);
                                    Cell cell3 = new Cell(1, 1);
                                    Cell cell4 = new Cell(1, 1);

                                    DateTime start= new  DateTime(activity.ActivityStartDate.Year, activity.ActivityStartDate.Month, activity.ActivityStartDate.Day);
                                    DateTime end= new  DateTime(activity.ActivityEndDate.Year, activity.ActivityEndDate.Month, activity.ActivityEndDate.Day);
                                    string period=start.Date.ToString("MMM. d, yyyy")+" - "+end.Date.ToString("MMM. d, yyyy");

                                    if(row_alt==false)
                                    {
                                        //Row Rows
                                        cell1.SetTextAlignment(TextAlignment.LEFT)
                                        .Add(new Paragraph(activity.ActivityDescription)
                                                        // .SetFont(ft_montserrat_reg)
                                                        .SetFixedLeading(14f)
                                                        .SetFontColor(cl_grayDark)
                                                        .SetBackgroundColor(cl_tablecontent_1)
                                                        .SetFontSize(9))
                                            .SetBackgroundColor(cl_tablecontent_1)
                                            .SetBorderTop(Border.NO_BORDER)
                                            .SetBorderBottom(Border.NO_BORDER);


                                    
                                            cell2.SetTextAlignment(TextAlignment.LEFT)
                                            .Add(new Paragraph(_lkupActivityTypeRepository.GetActivityType(activity.ActivityType_Id).Activity_Name)
                                                            // .SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_1)
                                                            .SetFontSize(9))
                                            .SetBackgroundColor(cl_tablecontent_1)
                                            .SetBorderTop(Border.NO_BORDER)
                                            .SetBorderBottom(Border.NO_BORDER);


                                            cell3.SetTextAlignment(TextAlignment.LEFT)
                                            .Add(new Paragraph(period)
                                                            //.SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_1)
                                                            .SetFontSize(9))
                                            .SetBackgroundColor(cl_tablecontent_1)
                                            .SetBorderTop(Border.NO_BORDER)
                                            .SetBorderBottom(Border.NO_BORDER);



                                        cell4.SetTextAlignment(TextAlignment.RIGHT)
                                            .Add(new Paragraph(string.Format("{0:N2}", activity.ActivityCost))
                                                            //.SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_1)
                                                            .SetFontSize(9))
                                            .SetBackgroundColor(cl_tablecontent_1)
                                            .SetBorderTop(Border.NO_BORDER)
                                            .SetBorderBottom(Border.NO_BORDER);
                                    }
                                    else
                                    {
                                        //Row Rows

                                        cell1.SetTextAlignment(TextAlignment.LEFT)
                                            .Add(new Paragraph(activity.ActivityDescription)
                                                            // .SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_2)
                                                            .SetFontSize(9))
                                                .SetBackgroundColor(cl_tablecontent_2)
                                                .SetBorderTop(Border.NO_BORDER)
                                                .SetBorderBottom(Border.NO_BORDER);



                                        cell2.SetTextAlignment(TextAlignment.LEFT)
                                            .Add(new Paragraph(_lkupActivityTypeRepository.GetActivityType(activity.ActivityType_Id).Activity_Name)
                                                            //.SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_2)
                                                            .SetFontSize(9))
                                            .SetBackgroundColor(cl_tablecontent_2)
                                            .SetBorderTop(Border.NO_BORDER)
                                            .SetBorderBottom(Border.NO_BORDER);


                                        cell3.SetTextAlignment(TextAlignment.LEFT)
                                            .Add(new Paragraph(period)
                                                            // .SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_2)
                                                            .SetFontSize(9))
                                            .SetBackgroundColor(cl_tablecontent_2)
                                            .SetBorderTop(Border.NO_BORDER)
                                            .SetBorderBottom(Border.NO_BORDER);
        


                                        cell4.SetTextAlignment(TextAlignment.RIGHT)
                                            .Add(new Paragraph(string.Format("{0:N2}", activity.ActivityCost))
                                                            // .SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_2)
                                                            .SetFontSize(9))
                                            .SetBackgroundColor(cl_tablecontent_2)
                                            .SetBorderTop(Border.NO_BORDER)
                                            .SetBorderBottom(Border.NO_BORDER);
                                        

                                    }

                                    row_alt=ToggleBoolean(row_alt);
                                    if(inneriter==activitycount)
                                    {
                                        cell1.SetBorderBottom(new SolidBorder(1f));
                                        cell2.SetBorderBottom(new SolidBorder(1f));
                                        cell3.SetBorderBottom(new SolidBorder(1f));
                                        cell4.SetBorderBottom(new SolidBorder(1f));

                                    }

                                    tableactivity_spanning112.AddCell(cell1);
                                    tableactivity_spanning112.AddCell(cell2);
                                    tableactivity_spanning112.AddCell(cell3);   
                                    tableactivity_spanning112.AddCell(cell4);

                                }

                            }
                            inneriter=0;
                            row_alt=true;
                            document.Add(tableactivity_spanning112);
                        }

                        document.Add(txt);
                        document.Add(txt);

                        float indentmargin_outer113=document.GetLeftMargin()+49;
                        Table tableactivity_outer113= new Table(UnitValue.CreatePercentArray(new float[]{4, 96}), false)
                                            .SetWidth(PageSize.A4.GetWidth()-indentmargin_outer113)
                                            .SetMarginLeft(14)
                                            .SetHorizontalAlignment(HorizontalAlignment.LEFT);

                            Cell cellbullet113 = new Cell(1, 1)
                            .SetTextAlignment(TextAlignment.LEFT)
                            .Add(new Paragraph("\ue837")
                                            .SetFont(ft_materialicons_fonts)
                                            .SetFixedLeading(14f)
                                            .SetFontColor(cl_green)
                                            .SetFontSize(10))
                                .SetBorder(Border.NO_BORDER);

                            Cell celltxt113= new Cell(1, 1)
                            .SetTextAlignment(TextAlignment.JUSTIFIED)
                            .Add(new Paragraph("Activities Outside of Workplan Period")
                                            .SetFixedLeading(14f)
                                            .SetFontColor(cl_green)
                                            .SetFontSize(10))
                                .SetBorder(Border.NO_BORDER);

                        tableactivity_outer113.AddCell(cellbullet113);
                        tableactivity_outer113.AddCell(celltxt113);

                        document.Add(tableactivity_outer113);
                        document.Add(txt);

                        float indentmargin_outside113=document.GetLeftMargin()+74;
                        Table tableactivity_outside113 = new Table(UnitValue.CreatePercentArray(new float[]{35, 20, 27, 18}), false)
                            .SetWidth(PageSize.A4.GetWidth()-indentmargin_outside113)
                            .SetMarginLeft(37)
                            .SetHorizontalAlignment(HorizontalAlignment.LEFT);


                        var DB_Activities_outside113=_wpOutputActivitiesRepository.GetRecordsByMainRecordId(mainrec.Transaction_Id);

                        DateTime startperiod_outside113=new DateTime(Int32.Parse(_lkupFiscalYearRepository.GetRecord(mainrec.FiscalYear_Id).Record_Name) , 1, 1);
                        DateTime endperiod_outside113=new DateTime(Int32.Parse(_lkupFiscalYearRepository.GetRecord(mainrec.FiscalYear_Id).Record_Name) , 3, DateTime.DaysInMonth(mainrec.FiscalYear_Id, 3));

                        int actualrecords_outside113=0;
                        foreach (var activity in DB_Activities_outside113)
                        {
                            if(IsActivityOutsideWPPeriod(new DateTime(activity.ActivityStartDate.Year, activity.ActivityStartDate.Month, activity.ActivityStartDate.Day), new DateTime(activity.ActivityEndDate.Year, activity.ActivityEndDate.Month, activity.ActivityEndDate.Day), startperiod_outside113, endperiod_outside113)==true)
                                actualrecords_outside113=actualrecords_outside113+1;
                        }
                        if(actualrecords_outside113>=1)
                        {
                            //Row Header
                            Cell cellheader01 = new Cell(1, 1)
                            .SetTextAlignment(TextAlignment.LEFT)
                            .Add(new Paragraph("ACTIVITY")
                                            //.SetFont(ft_montserrat_medium)
                                            .SetFixedLeading(14f)
                                            .SetFontColor(cl_grayDark)
                                            .SetBackgroundColor(cl_tableheader)
                                            .SetFontSize(10))
                                .SetBackgroundColor(cl_tableheader);

                            tableactivity_outside113.AddCell(cellheader01);

                            Cell cellheader02 = new Cell(1, 1)
                                .SetTextAlignment(TextAlignment.LEFT)
                                .Add(new Paragraph("TYPE")
                                                // .SetFont(ft_montserrat_medium)
                                                .SetFixedLeading(14f)
                                                .SetFontColor(cl_grayDark)
                                                .SetBackgroundColor(cl_tableheader)
                                                .SetFontSize(10))
                                .SetBackgroundColor(cl_tableheader);

                            tableactivity_outside113.AddCell(cellheader02);


                            Cell cellheader03 = new Cell(1, 1)
                                .SetTextAlignment(TextAlignment.LEFT)
                                .Add(new Paragraph("PERIOD")
                                                // .SetFont(ft_montserrat_medium)
                                                .SetFixedLeading(14f)
                                                .SetFontColor(cl_grayDark)
                                                .SetBackgroundColor(cl_tableheader)
                                                .SetFontSize(10))
                                .SetBackgroundColor(cl_tableheader);
                            tableactivity_outside113.AddCell(cellheader03);

                            Cell cellheader04 = new Cell(1, 1)
                                .SetTextAlignment(TextAlignment.RIGHT)
                                .Add(new Paragraph("AMOUNT (USD)")
                                                // .SetFont(ft_montserrat_medium)
                                                .SetFixedLeading(14f)
                                                .SetFontColor(cl_grayDark)
                                                .SetBackgroundColor(cl_tableheader)
                                                .SetFontSize(10))
                                .SetBackgroundColor(cl_tableheader);

                            tableactivity_outside113.AddCell(cellheader04);

                            int activitycount=actualrecords_outside113;

                            foreach (var activity in DB_Activities_outside113)
                            {
                                if(IsActivityOutsideWPPeriod(new DateTime(activity.ActivityStartDate.Year, activity.ActivityStartDate.Month, activity.ActivityStartDate.Day), new DateTime(activity.ActivityEndDate.Year, activity.ActivityEndDate.Month, activity.ActivityEndDate.Day), startperiod_outside113, endperiod_outside113)==true)
                                {
                                    inneriter=inneriter+1;

                                    Cell cell1 = new Cell(1, 1);
                                    Cell cell2 = new Cell(1, 1);
                                    Cell cell3 = new Cell(1, 1);
                                    Cell cell4 = new Cell(1, 1);

                                    DateTime start= new  DateTime(activity.ActivityStartDate.Year, activity.ActivityStartDate.Month, activity.ActivityStartDate.Day);
                                    DateTime end= new  DateTime(activity.ActivityEndDate.Year, activity.ActivityEndDate.Month, activity.ActivityEndDate.Day);
                                    string period=start.Date.ToString("MMM. d, yyyy")+" - "+end.Date.ToString("MMM. d, yyyy");

                                    if(row_alt==false)
                                    {
                                        //Row Rows
                                        cell1.SetTextAlignment(TextAlignment.LEFT)
                                        .Add(new Paragraph(activity.ActivityDescription)
                                                        //.SetFont(ft_montserrat_reg)
                                                        .SetFixedLeading(14f)
                                                        .SetFontColor(cl_grayDark)
                                                        .SetBackgroundColor(cl_tablecontent_1)
                                                        .SetFontSize(9))
                                            .SetBackgroundColor(cl_tablecontent_1)
                                            .SetBorderTop(Border.NO_BORDER)
                                            .SetBorderBottom(Border.NO_BORDER);


                                    
                                            cell2.SetTextAlignment(TextAlignment.LEFT)
                                            .Add(new Paragraph(_lkupActivityTypeRepository.GetActivityType(activity.ActivityType_Id).Activity_Name)
                                                            //.SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_1)
                                                            .SetFontSize(9))
                                            .SetBackgroundColor(cl_tablecontent_1)
                                            .SetBorderTop(Border.NO_BORDER)
                                            .SetBorderBottom(Border.NO_BORDER);


                                            cell3.SetTextAlignment(TextAlignment.LEFT)
                                            .Add(new Paragraph(period)
                                                            //.SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_1)
                                                            .SetFontSize(9))
                                            .SetBackgroundColor(cl_tablecontent_1)
                                            .SetBorderTop(Border.NO_BORDER)
                                            .SetBorderBottom(Border.NO_BORDER);


                                        cell4.SetTextAlignment(TextAlignment.RIGHT)
                                            .Add(new Paragraph(string.Format("{0:N2}", activity.ActivityCost))
                                                            //.SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_1)
                                                            .SetFontSize(9))
                                            .SetBackgroundColor(cl_tablecontent_1)
                                            .SetBorderTop(Border.NO_BORDER)
                                            .SetBorderBottom(Border.NO_BORDER);


                                    }
                                    else
                                    {
                                        //Row Rows

                                        cell1.SetTextAlignment(TextAlignment.LEFT)
                                            .Add(new Paragraph(activity.ActivityDescription)
                                                            //.SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_2)
                                                            .SetFontSize(9))
                                                .SetBackgroundColor(cl_tablecontent_2)
                                                .SetBorderTop(Border.NO_BORDER)
                                                .SetBorderBottom(Border.NO_BORDER);



                                        cell2.SetTextAlignment(TextAlignment.LEFT)
                                            .Add(new Paragraph(_lkupActivityTypeRepository.GetActivityType(activity.ActivityType_Id).Activity_Name)
                                                            //.SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_2)
                                                            .SetFontSize(9))
                                            .SetBackgroundColor(cl_tablecontent_2)
                                            .SetBorderTop(Border.NO_BORDER)
                                            .SetBorderBottom(Border.NO_BORDER);



                                        cell3.SetTextAlignment(TextAlignment.LEFT)
                                            .Add(new Paragraph(period)
                                                            //.SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_2)
                                                            .SetFontSize(9))
                                            .SetBackgroundColor(cl_tablecontent_2)
                                            .SetBorderTop(Border.NO_BORDER)
                                            .SetBorderBottom(Border.NO_BORDER);


                                        cell4.SetTextAlignment(TextAlignment.RIGHT)
                                            .Add(new Paragraph(string.Format("{0:N2}", activity.ActivityCost))
                                                            //.SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_2)
                                                            .SetFontSize(9))
                                            .SetBackgroundColor(cl_tablecontent_2)
                                            .SetBorderTop(Border.NO_BORDER)
                                            .SetBorderBottom(Border.NO_BORDER);

                                    }

                                    row_alt=ToggleBoolean(row_alt);
                                    if(inneriter==activitycount)
                                    {
                                        cell1.SetBorderBottom(new SolidBorder(1f));
                                        cell2.SetBorderBottom(new SolidBorder(1f));
                                        cell3.SetBorderBottom(new SolidBorder(1f));
                                        cell4.SetBorderBottom(new SolidBorder(1f));

                                    }

                                    tableactivity_outside113.AddCell(cell1);
                                    tableactivity_outside113.AddCell(cell2);
                                    tableactivity_outside113.AddCell(cell3);   
                                    tableactivity_outside113.AddCell(cell4);

                                }

                            }
                            inneriter=0;
                            row_alt=true;
                            document.Add(tableactivity_outside113);

                        }
                            


                    break;
                    case 2 :
                        int[] months_2 = { 4, 5, 6 };

                        foreach (var i in months_2)
                        {
                            float indentmargin_outer221=document.GetLeftMargin()+49;
                            Table tableactivity_outer221 = new Table(UnitValue.CreatePercentArray(new float[]{4, 96}), false)
                                                .SetWidth(PageSize.A4.GetWidth()-indentmargin_outer221)
                                                .SetMarginLeft(14)
                                                .SetHorizontalAlignment(HorizontalAlignment.LEFT);

                                Cell cellbullet221 = new Cell(1, 1)
                                .SetTextAlignment(TextAlignment.LEFT)
                                .Add(new Paragraph("\ue837")
                                                .SetFont(ft_materialicons_fonts)
                                                .SetFixedLeading(14f)
                                                .SetFontColor(cl_green)
                                                .SetFontSize(10))
                                    .SetBorder(Border.NO_BORDER);

                                Cell celltxt221= new Cell(1, 1)
                                .SetTextAlignment(TextAlignment.JUSTIFIED)
                                .Add(new Paragraph(System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i))
                                                .SetFixedLeading(14f)
                                                .SetFontColor(cl_green)
                                                .SetFontSize(10))
                                    .SetBorder(Border.NO_BORDER);

                            tableactivity_outer221.AddCell(cellbullet221);
                            tableactivity_outer221.AddCell(celltxt221);

                            document.Add(tableactivity_outer221);
                            document.Add(txt);

                            float indentmargin221=document.GetLeftMargin()+74;
                            float tablewidth221=PageSize.A4.GetWidth()-indentmargin221;
                            Table tableactivity_221 = new Table(UnitValue.CreatePercentArray(new float[]{35, 20, 27, 18}), false)
                                .SetWidth(PageSize.A4.GetWidth()-indentmargin221)
                                .SetMarginLeft(37)
                                .SetHorizontalAlignment(HorizontalAlignment.LEFT);


                            var DB_Activities221=_wpOutputActivitiesRepository.GetRecordsByMainRecordId(mainrec.Transaction_Id);

                            int actualrecords221=0;
                            foreach (var activity in DB_Activities221)
                            {
                                if(WithinMonth(mainrec.FiscalYear_Id, i, new DateTime(activity.ActivityStartDate.Year, activity.ActivityStartDate.Month, activity.ActivityStartDate.Day), new DateTime(activity.ActivityEndDate.Year, activity.ActivityEndDate.Month, activity.ActivityEndDate.Day))==true)
                                    actualrecords221=actualrecords221+1;
                            }

                            if(actualrecords221>=1)
                            {
                                //Row Header
                                Cell cellheader01 = new Cell(1, 1)
                                .SetTextAlignment(TextAlignment.LEFT)
                                .Add(new Paragraph("ACTIVITY")
                                                //.SetFont(ft_montserrat_medium)
                                                .SetFixedLeading(14f)
                                                .SetFontColor(cl_grayDark)
                                                .SetBackgroundColor(cl_tableheader)
                                                .SetFontSize(10))
                                    .SetBackgroundColor(cl_tableheader);

                                tableactivity_221.AddCell(cellheader01);

                                Cell cellheader02 = new Cell(1, 1)
                                    .SetTextAlignment(TextAlignment.LEFT)
                                    .Add(new Paragraph("TYPE")
                                                // .SetFont(ft_montserrat_medium)
                                                    .SetFixedLeading(14f)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tableheader)
                                                    .SetFontSize(10))
                                    .SetBackgroundColor(cl_tableheader);

                                tableactivity_221.AddCell(cellheader02);


                                Cell cellheader03 = new Cell(1, 1)
                                    .SetTextAlignment(TextAlignment.LEFT)
                                    .Add(new Paragraph("PERIOD")
                                                    .SetFont(ft_montserrat_medium)
                                                    .SetFixedLeading(14f)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tableheader)
                                                    .SetFontSize(10))
                                    .SetBackgroundColor(cl_tableheader);

                                tableactivity_221.AddCell(cellheader03);

                                Cell cellheader04 = new Cell(1, 1)
                                    .SetTextAlignment(TextAlignment.RIGHT)
                                    .Add(new Paragraph("AMOOUNT (USD)")
                                                // .SetFont(ft_montserrat_medium)
                                                    .SetFixedLeading(14f)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tableheader)
                                                    .SetFontSize(10))
                                    .SetBackgroundColor(cl_tableheader);

                                tableactivity_221.AddCell(cellheader04);

                                int activitycount=actualrecords221;

                                foreach (var activity in DB_Activities221)
                                {
                                    if(WithinMonth(mainrec.FiscalYear_Id, i, new DateTime(activity.ActivityStartDate.Year, activity.ActivityStartDate.Month, activity.ActivityStartDate.Day), new DateTime(activity.ActivityEndDate.Year, activity.ActivityEndDate.Month, activity.ActivityEndDate.Day)))
                                    {
                                        inneriter=inneriter+1;

                                        Cell cell1 = new Cell(1, 1);
                                        Cell cell2 = new Cell(1, 1);
                                        Cell cell3 = new Cell(1, 1);
                                        Cell cell4 = new Cell(1, 1);

                                        DateTime start= new  DateTime(activity.ActivityStartDate.Year, activity.ActivityStartDate.Month, activity.ActivityStartDate.Day);
                                        DateTime end= new  DateTime(activity.ActivityEndDate.Year, activity.ActivityEndDate.Month, activity.ActivityEndDate.Day);
                                        string period=start.Date.ToString("MMM. d, yyyy")+" - "+end.Date.ToString("MMM. d, yyyy");

                                        if(row_alt==false)
                                        {
                                            //Row Rows
                                            cell1.SetTextAlignment(TextAlignment.LEFT)
                                            .Add(new Paragraph(activity.ActivityDescription)
                                                        // .SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_1)
                                                            .SetFontSize(9))
                                                .SetBackgroundColor(cl_tablecontent_1)
                                                .SetBorderTop(Border.NO_BORDER)
                                                .SetBorderBottom(Border.NO_BORDER);


                                        
                                                cell2.SetTextAlignment(TextAlignment.LEFT)
                                                .Add(new Paragraph(_lkupActivityTypeRepository.GetActivityType(activity.ActivityType_Id).Activity_Name)
                                                            // .SetFont(ft_montserrat_reg)
                                                                .SetFixedLeading(14f)
                                                                .SetFontColor(cl_grayDark)
                                                                .SetBackgroundColor(cl_tablecontent_1)
                                                                .SetFontSize(9))
                                                .SetBackgroundColor(cl_tablecontent_1)
                                                .SetBorderTop(Border.NO_BORDER)
                                                .SetBorderBottom(Border.NO_BORDER);


                                                cell3.SetTextAlignment(TextAlignment.LEFT)
                                                .Add(new Paragraph(period)
                                                                //.SetFont(ft_montserrat_reg)
                                                                .SetFixedLeading(14f)
                                                                .SetFontColor(cl_grayDark)
                                                                .SetBackgroundColor(cl_tablecontent_1)
                                                                .SetFontSize(9))
                                                .SetBackgroundColor(cl_tablecontent_1)
                                                .SetBorderTop(Border.NO_BORDER)
                                                .SetBorderBottom(Border.NO_BORDER);



                                            cell4.SetTextAlignment(TextAlignment.RIGHT)
                                                .Add(new Paragraph(string.Format("{0:N2}", activity.ActivityCost))
                                                                //.SetFont(ft_montserrat_reg)
                                                                .SetFixedLeading(14f)
                                                                .SetFontColor(cl_grayDark)
                                                                .SetBackgroundColor(cl_tablecontent_1)
                                                                .SetFontSize(9))
                                                .SetBackgroundColor(cl_tablecontent_1)
                                                .SetBorderTop(Border.NO_BORDER)
                                                .SetBorderBottom(Border.NO_BORDER);


                                        }
                                        else
                                        {
                                            //Row Rows

                                            cell1.SetTextAlignment(TextAlignment.LEFT)
                                                .Add(new Paragraph(activity.ActivityDescription)
                                                                //.SetFont(ft_montserrat_reg)
                                                                .SetFixedLeading(14f)
                                                                .SetFontColor(cl_grayDark)
                                                                .SetBackgroundColor(cl_tablecontent_2)
                                                                .SetFontSize(9))
                                                    .SetBackgroundColor(cl_tablecontent_2)
                                                    .SetBorderTop(Border.NO_BORDER)
                                                    .SetBorderBottom(Border.NO_BORDER);



                                            cell2.SetTextAlignment(TextAlignment.LEFT)
                                                .Add(new Paragraph(_lkupActivityTypeRepository.GetActivityType(activity.ActivityType_Id).Activity_Name)
                                                                //.SetFont(ft_montserrat_reg)
                                                                .SetFixedLeading(14f)
                                                                .SetFontColor(cl_grayDark)
                                                                .SetBackgroundColor(cl_tablecontent_2)
                                                                .SetFontSize(9))
                                                .SetBackgroundColor(cl_tablecontent_2)
                                                .SetBorderTop(Border.NO_BORDER)
                                                .SetBorderBottom(Border.NO_BORDER);




                                            cell3.SetTextAlignment(TextAlignment.LEFT)
                                                .Add(new Paragraph(period)
                                                                //.SetFont(ft_montserrat_reg)
                                                                .SetFixedLeading(14f)
                                                                .SetFontColor(cl_grayDark)
                                                                .SetBackgroundColor(cl_tablecontent_2)
                                                                .SetFontSize(9))
                                                .SetBackgroundColor(cl_tablecontent_2)
                                                .SetBorderTop(Border.NO_BORDER)
                                                .SetBorderBottom(Border.NO_BORDER);



                                            cell4.SetTextAlignment(TextAlignment.RIGHT)
                                                .Add(new Paragraph(string.Format("{0:N2}", activity.ActivityCost))
                                                                //.SetFont(ft_montserrat_reg)
                                                                .SetFixedLeading(14f)
                                                                .SetFontColor(cl_grayDark)
                                                                .SetBackgroundColor(cl_tablecontent_2)
                                                                .SetFontSize(9))
                                                .SetBackgroundColor(cl_tablecontent_2)
                                                .SetBorderTop(Border.NO_BORDER)
                                                .SetBorderBottom(Border.NO_BORDER);
                                            

                                        }

                                        row_alt=ToggleBoolean(row_alt);
                                        if(inneriter==activitycount)
                                        {
                                            cell1.SetBorderBottom(new SolidBorder(1f));
                                            cell2.SetBorderBottom(new SolidBorder(1f));
                                            cell3.SetBorderBottom(new SolidBorder(1f));
                                            cell4.SetBorderBottom(new SolidBorder(1f));

                                        }

                                        tableactivity_221.AddCell(cell1);
                                        tableactivity_221.AddCell(cell2);
                                        tableactivity_221.AddCell(cell3);   
                                        tableactivity_221.AddCell(cell4);

                                    }

                                }

                                inneriter=0;
                                row_alt=true;
                                document.Add(tableactivity_221);

                                
                            }

                            document.Add(txt);
                            document.Add(txt);
                        }
            

                        float indentmargin_outer222=document.GetLeftMargin()+49;
                        Table tableactivity_outer222 = new Table(UnitValue.CreatePercentArray(new float[]{4, 96}), false)
                                            .SetWidth(PageSize.A4.GetWidth()-indentmargin_outer222)
                                            .SetMarginLeft(14)
                                            .SetHorizontalAlignment(HorizontalAlignment.LEFT);

                            Cell cellbullet222 = new Cell(1, 1)
                            .SetTextAlignment(TextAlignment.LEFT)
                            .Add(new Paragraph("\ue837")
                                            .SetFont(ft_materialicons_fonts)
                                            .SetFixedLeading(14f)
                                            .SetFontColor(cl_green)
                                            .SetFontSize(10))
                                .SetBorder(Border.NO_BORDER);

                            Cell celltxt222= new Cell(1, 1)
                            .SetTextAlignment(TextAlignment.JUSTIFIED)
                            .Add(new Paragraph("Activities Spanning Multiple Months")
                                            .SetFixedLeading(14f)
                                            .SetFontColor(cl_green)
                                            .SetFontSize(10))
                                .SetBorder(Border.NO_BORDER);

                        tableactivity_outer222.AddCell(cellbullet222);
                        tableactivity_outer222.AddCell(celltxt222);

                        document.Add(tableactivity_outer222);
                        document.Add(txt);

                        

                        float indentmargin_spanning222=document.GetLeftMargin()+74;
                        Table tableactivity_spanning222 = new Table(UnitValue.CreatePercentArray(new float[]{35, 20, 27, 18}), false)
                            .SetWidth(PageSize.A4.GetWidth()-indentmargin_spanning222)
                            .SetMarginLeft(37)
                            .SetHorizontalAlignment(HorizontalAlignment.LEFT);


                        var DB_Activities_spanning222=_wpOutputActivitiesRepository.GetRecordsByMainRecordId(mainrec.Transaction_Id);

                        DateTime startperiod_spanning222=new DateTime(Int32.Parse(_lkupFiscalYearRepository.GetRecord(mainrec.FiscalYear_Id).Record_Name) , 4, 1);
                        DateTime endperiod_spanning222=new DateTime(Int32.Parse(_lkupFiscalYearRepository.GetRecord(mainrec.FiscalYear_Id).Record_Name) , 6, DateTime.DaysInMonth(mainrec.FiscalYear_Id, 6));

                        int actualrecords_spanning222=0;
                        foreach (var activity in DB_Activities_spanning222)
                        {
                            if(IsActivitySpanningMultipleMonths(mainrec.FiscalYear_Id, months_2, new DateTime(activity.ActivityStartDate.Year, activity.ActivityStartDate.Month, activity.ActivityStartDate.Day), new DateTime(activity.ActivityEndDate.Year, activity.ActivityEndDate.Month, activity.ActivityEndDate.Day), startperiod_spanning222, endperiod_spanning222)==true)
                                actualrecords_spanning222=actualrecords_spanning222+1;
                        }
                        if(actualrecords_spanning222>=1)
                        {
                            //Row Header
                            Cell cellheader01 = new Cell(1, 1)
                            .SetTextAlignment(TextAlignment.LEFT)
                            .Add(new Paragraph("ACTIVITY")
                                            //.SetFont(ft_montserrat_medium)
                                            .SetFixedLeading(14f)
                                            .SetFontColor(cl_grayDark)
                                            .SetBackgroundColor(cl_tableheader)
                                            .SetFontSize(10))
                                .SetBackgroundColor(cl_tableheader);
                            tableactivity_spanning222.AddCell(cellheader01);

                            Cell cellheader02 = new Cell(1, 1)
                                .SetTextAlignment(TextAlignment.LEFT)
                                .Add(new Paragraph("TYPE")
                                                // .SetFont(ft_montserrat_medium)
                                                .SetFixedLeading(14f)
                                                .SetFontColor(cl_grayDark)
                                                .SetBackgroundColor(cl_tableheader)
                                                .SetFontSize(10))
                                .SetBackgroundColor(cl_tableheader);
                            tableactivity_spanning222.AddCell(cellheader02);


                            Cell cellheader03 = new Cell(1, 1)
                                .SetTextAlignment(TextAlignment.LEFT)
                                .Add(new Paragraph("PERIOD")
                                                //.SetFont(ft_montserrat_medium)
                                                .SetFixedLeading(14f)
                                                .SetFontColor(cl_grayDark)
                                                .SetBackgroundColor(cl_tableheader)
                                                .SetFontSize(10))
                                .SetBackgroundColor(cl_tableheader);
                            tableactivity_spanning222.AddCell(cellheader03);

                            Cell cellheader04 = new Cell(1, 1)
                                .SetTextAlignment(TextAlignment.RIGHT)
                                .Add(new Paragraph("AMOUNT (USD)")
                                                //.SetFont(ft_montserrat_medium)
                                                .SetFixedLeading(14f)
                                                .SetFontColor(cl_grayDark)
                                                .SetBackgroundColor(cl_tableheader)
                                                .SetFontSize(10))
                                .SetBackgroundColor(cl_tableheader);

                            tableactivity_spanning222.AddCell(cellheader04);

                            int activitycount=actualrecords_spanning222;

                            foreach (var activity in DB_Activities_spanning222)
                            {
                                if(IsActivitySpanningMultipleMonths(mainrec.FiscalYear_Id, months_2, new DateTime(activity.ActivityStartDate.Year, activity.ActivityStartDate.Month, activity.ActivityStartDate.Day), new DateTime(activity.ActivityEndDate.Year, activity.ActivityEndDate.Month, activity.ActivityEndDate.Day), startperiod_spanning222, endperiod_spanning222))
                                {
                                    inneriter=inneriter+1;

                                    Cell cell1 = new Cell(1, 1);
                                    Cell cell2 = new Cell(1, 1);
                                    Cell cell3 = new Cell(1, 1);
                                    Cell cell4 = new Cell(1, 1);

                                    DateTime start= new  DateTime(activity.ActivityStartDate.Year, activity.ActivityStartDate.Month, activity.ActivityStartDate.Day);
                                    DateTime end= new  DateTime(activity.ActivityEndDate.Year, activity.ActivityEndDate.Month, activity.ActivityEndDate.Day);
                                    string period=start.Date.ToString("MMM. d, yyyy")+" - "+end.Date.ToString("MMM. d, yyyy");

                                    if(row_alt==false)
                                    {
                                        //Row Rows
                                        cell1.SetTextAlignment(TextAlignment.LEFT)
                                        .Add(new Paragraph(activity.ActivityDescription)
                                                        // .SetFont(ft_montserrat_reg)
                                                        .SetFixedLeading(14f)
                                                        .SetFontColor(cl_grayDark)
                                                        .SetBackgroundColor(cl_tablecontent_1)
                                                        .SetFontSize(9))
                                            .SetBackgroundColor(cl_tablecontent_1)
                                            .SetBorderTop(Border.NO_BORDER)
                                            .SetBorderBottom(Border.NO_BORDER);


                                    
                                            cell2.SetTextAlignment(TextAlignment.LEFT)
                                            .Add(new Paragraph(_lkupActivityTypeRepository.GetActivityType(activity.ActivityType_Id).Activity_Name)
                                                            // .SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_1)
                                                            .SetFontSize(9))
                                            .SetBackgroundColor(cl_tablecontent_1)
                                            .SetBorderTop(Border.NO_BORDER)
                                            .SetBorderBottom(Border.NO_BORDER);


                                            cell3.SetTextAlignment(TextAlignment.LEFT)
                                            .Add(new Paragraph(period)
                                                            //.SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_1)
                                                            .SetFontSize(9))
                                            .SetBackgroundColor(cl_tablecontent_1)
                                            .SetBorderTop(Border.NO_BORDER)
                                            .SetBorderBottom(Border.NO_BORDER);



                                        cell4.SetTextAlignment(TextAlignment.RIGHT)
                                            .Add(new Paragraph(string.Format("{0:N2}", activity.ActivityCost))
                                                            //.SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_1)
                                                            .SetFontSize(9))
                                            .SetBackgroundColor(cl_tablecontent_1)
                                            .SetBorderTop(Border.NO_BORDER)
                                            .SetBorderBottom(Border.NO_BORDER);
                                    }
                                    else
                                    {
                                        //Row Rows

                                        cell1.SetTextAlignment(TextAlignment.LEFT)
                                            .Add(new Paragraph(activity.ActivityDescription)
                                                            // .SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_2)
                                                            .SetFontSize(9))
                                                .SetBackgroundColor(cl_tablecontent_2)
                                                .SetBorderTop(Border.NO_BORDER)
                                                .SetBorderBottom(Border.NO_BORDER);



                                        cell2.SetTextAlignment(TextAlignment.LEFT)
                                            .Add(new Paragraph(_lkupActivityTypeRepository.GetActivityType(activity.ActivityType_Id).Activity_Name)
                                                            //.SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_2)
                                                            .SetFontSize(9))
                                            .SetBackgroundColor(cl_tablecontent_2)
                                            .SetBorderTop(Border.NO_BORDER)
                                            .SetBorderBottom(Border.NO_BORDER);


                                        cell3.SetTextAlignment(TextAlignment.LEFT)
                                            .Add(new Paragraph(period)
                                                            // .SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_2)
                                                            .SetFontSize(9))
                                            .SetBackgroundColor(cl_tablecontent_2)
                                            .SetBorderTop(Border.NO_BORDER)
                                            .SetBorderBottom(Border.NO_BORDER);
        


                                        cell4.SetTextAlignment(TextAlignment.RIGHT)
                                            .Add(new Paragraph(string.Format("{0:N2}", activity.ActivityCost))
                                                            // .SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_2)
                                                            .SetFontSize(9))
                                            .SetBackgroundColor(cl_tablecontent_2)
                                            .SetBorderTop(Border.NO_BORDER)
                                            .SetBorderBottom(Border.NO_BORDER);
                                        

                                    }

                                    row_alt=ToggleBoolean(row_alt);
                                    if(inneriter==activitycount)
                                    {
                                        cell1.SetBorderBottom(new SolidBorder(1f));
                                        cell2.SetBorderBottom(new SolidBorder(1f));
                                        cell3.SetBorderBottom(new SolidBorder(1f));
                                        cell4.SetBorderBottom(new SolidBorder(1f));

                                    }

                                    tableactivity_spanning222.AddCell(cell1);
                                    tableactivity_spanning222.AddCell(cell2);
                                    tableactivity_spanning222.AddCell(cell3);   
                                    tableactivity_spanning222.AddCell(cell4);

                                }

                            }
                            inneriter=0;
                            row_alt=true;
                            document.Add(tableactivity_spanning222);
                        }

                        document.Add(txt);
                        document.Add(txt);

                        float indentmargin_outer223=document.GetLeftMargin()+49;
                        Table tableactivity_outer223= new Table(UnitValue.CreatePercentArray(new float[]{4, 96}), false)
                                            .SetWidth(PageSize.A4.GetWidth()-indentmargin_outer223)
                                            .SetMarginLeft(14)
                                            .SetHorizontalAlignment(HorizontalAlignment.LEFT);

                            Cell cellbullet223 = new Cell(1, 1)
                            .SetTextAlignment(TextAlignment.LEFT)
                            .Add(new Paragraph("\ue837")
                                            .SetFont(ft_materialicons_fonts)
                                            .SetFixedLeading(14f)
                                            .SetFontColor(cl_green)
                                            .SetFontSize(10))
                                .SetBorder(Border.NO_BORDER);

                            Cell celltxt223= new Cell(1, 1)
                            .SetTextAlignment(TextAlignment.JUSTIFIED)
                            .Add(new Paragraph("Activities Outside of Workplan Period")
                                            .SetFixedLeading(14f)
                                            .SetFontColor(cl_green)
                                            .SetFontSize(10))
                                .SetBorder(Border.NO_BORDER);

                        tableactivity_outer223.AddCell(cellbullet223);
                        tableactivity_outer223.AddCell(celltxt223);

                        document.Add(tableactivity_outer223);
                        document.Add(txt);

                        float indentmargin_outside223=document.GetLeftMargin()+74;
                        Table tableactivity_outside223 = new Table(UnitValue.CreatePercentArray(new float[]{35, 20, 27, 18}), false)
                            .SetWidth(PageSize.A4.GetWidth()-indentmargin_outside223)
                            .SetMarginLeft(37)
                            .SetHorizontalAlignment(HorizontalAlignment.LEFT);


                        var DB_Activities_outside223=_wpOutputActivitiesRepository.GetRecordsByMainRecordId(mainrec.Transaction_Id);

                        DateTime startperiod_outside223=new DateTime(Int32.Parse(_lkupFiscalYearRepository.GetRecord(mainrec.FiscalYear_Id).Record_Name) , 4, 1);
                        DateTime endperiod_outside223=new DateTime(Int32.Parse(_lkupFiscalYearRepository.GetRecord(mainrec.FiscalYear_Id).Record_Name) , 6, DateTime.DaysInMonth(mainrec.FiscalYear_Id, 6));

                        int actualrecords_outside223=0;
                        foreach (var activity in DB_Activities_outside223)
                        {
                            if(IsActivityOutsideWPPeriod(new DateTime(activity.ActivityStartDate.Year, activity.ActivityStartDate.Month, activity.ActivityStartDate.Day), new DateTime(activity.ActivityEndDate.Year, activity.ActivityEndDate.Month, activity.ActivityEndDate.Day), startperiod_outside223, endperiod_outside223)==true)
                                actualrecords_outside223=actualrecords_outside223+1;
                        }
                        if(actualrecords_outside223>=1)
                        {
                            //Row Header
                            Cell cellheader01 = new Cell(1, 1)
                            .SetTextAlignment(TextAlignment.LEFT)
                            .Add(new Paragraph("ACTIVITY")
                                            //.SetFont(ft_montserrat_medium)
                                            .SetFixedLeading(14f)
                                            .SetFontColor(cl_grayDark)
                                            .SetBackgroundColor(cl_tableheader)
                                            .SetFontSize(10))
                                .SetBackgroundColor(cl_tableheader);

                            tableactivity_outside223.AddCell(cellheader01);

                            Cell cellheader02 = new Cell(1, 1)
                                .SetTextAlignment(TextAlignment.LEFT)
                                .Add(new Paragraph("TYPE")
                                                // .SetFont(ft_montserrat_medium)
                                                .SetFixedLeading(14f)
                                                .SetFontColor(cl_grayDark)
                                                .SetBackgroundColor(cl_tableheader)
                                                .SetFontSize(10))
                                .SetBackgroundColor(cl_tableheader);

                            tableactivity_outside223.AddCell(cellheader02);


                            Cell cellheader03 = new Cell(1, 1)
                                .SetTextAlignment(TextAlignment.LEFT)
                                .Add(new Paragraph("PERIOD")
                                                // .SetFont(ft_montserrat_medium)
                                                .SetFixedLeading(14f)
                                                .SetFontColor(cl_grayDark)
                                                .SetBackgroundColor(cl_tableheader)
                                                .SetFontSize(10))
                                .SetBackgroundColor(cl_tableheader);
                            tableactivity_outside223.AddCell(cellheader03);

                            Cell cellheader04 = new Cell(1, 1)
                                .SetTextAlignment(TextAlignment.RIGHT)
                                .Add(new Paragraph("AMOUNT (USD)")
                                                // .SetFont(ft_montserrat_medium)
                                                .SetFixedLeading(14f)
                                                .SetFontColor(cl_grayDark)
                                                .SetBackgroundColor(cl_tableheader)
                                                .SetFontSize(10))
                                .SetBackgroundColor(cl_tableheader);

                            tableactivity_outside223.AddCell(cellheader04);

                            int activitycount=actualrecords_outside223;

                            foreach (var activity in DB_Activities_outside223)
                            {
                                if(IsActivityOutsideWPPeriod(new DateTime(activity.ActivityStartDate.Year, activity.ActivityStartDate.Month, activity.ActivityStartDate.Day), new DateTime(activity.ActivityEndDate.Year, activity.ActivityEndDate.Month, activity.ActivityEndDate.Day), startperiod_outside223, endperiod_outside223)==true)
                                {
                                    inneriter=inneriter+1;

                                    Cell cell1 = new Cell(1, 1);
                                    Cell cell2 = new Cell(1, 1);
                                    Cell cell3 = new Cell(1, 1);
                                    Cell cell4 = new Cell(1, 1);

                                    DateTime start= new  DateTime(activity.ActivityStartDate.Year, activity.ActivityStartDate.Month, activity.ActivityStartDate.Day);
                                    DateTime end= new  DateTime(activity.ActivityEndDate.Year, activity.ActivityEndDate.Month, activity.ActivityEndDate.Day);
                                    string period=start.Date.ToString("MMM. d, yyyy")+" - "+end.Date.ToString("MMM. d, yyyy");

                                    if(row_alt==false)
                                    {
                                        //Row Rows
                                        cell1.SetTextAlignment(TextAlignment.LEFT)
                                        .Add(new Paragraph(activity.ActivityDescription)
                                                        //.SetFont(ft_montserrat_reg)
                                                        .SetFixedLeading(14f)
                                                        .SetFontColor(cl_grayDark)
                                                        .SetBackgroundColor(cl_tablecontent_1)
                                                        .SetFontSize(9))
                                            .SetBackgroundColor(cl_tablecontent_1)
                                            .SetBorderTop(Border.NO_BORDER)
                                            .SetBorderBottom(Border.NO_BORDER);


                                    
                                            cell2.SetTextAlignment(TextAlignment.LEFT)
                                            .Add(new Paragraph(_lkupActivityTypeRepository.GetActivityType(activity.ActivityType_Id).Activity_Name)
                                                            //.SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_1)
                                                            .SetFontSize(9))
                                            .SetBackgroundColor(cl_tablecontent_1)
                                            .SetBorderTop(Border.NO_BORDER)
                                            .SetBorderBottom(Border.NO_BORDER);


                                            cell3.SetTextAlignment(TextAlignment.LEFT)
                                            .Add(new Paragraph(period)
                                                            //.SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_1)
                                                            .SetFontSize(9))
                                            .SetBackgroundColor(cl_tablecontent_1)
                                            .SetBorderTop(Border.NO_BORDER)
                                            .SetBorderBottom(Border.NO_BORDER);


                                        cell4.SetTextAlignment(TextAlignment.RIGHT)
                                            .Add(new Paragraph(string.Format("{0:N2}", activity.ActivityCost))
                                                            //.SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_1)
                                                            .SetFontSize(9))
                                            .SetBackgroundColor(cl_tablecontent_1)
                                            .SetBorderTop(Border.NO_BORDER)
                                            .SetBorderBottom(Border.NO_BORDER);


                                    }
                                    else
                                    {
                                        //Row Rows

                                        cell1.SetTextAlignment(TextAlignment.LEFT)
                                            .Add(new Paragraph(activity.ActivityDescription)
                                                            //.SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_2)
                                                            .SetFontSize(9))
                                                .SetBackgroundColor(cl_tablecontent_2)
                                                .SetBorderTop(Border.NO_BORDER)
                                                .SetBorderBottom(Border.NO_BORDER);



                                        cell2.SetTextAlignment(TextAlignment.LEFT)
                                            .Add(new Paragraph(_lkupActivityTypeRepository.GetActivityType(activity.ActivityType_Id).Activity_Name)
                                                            //.SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_2)
                                                            .SetFontSize(9))
                                            .SetBackgroundColor(cl_tablecontent_2)
                                            .SetBorderTop(Border.NO_BORDER)
                                            .SetBorderBottom(Border.NO_BORDER);



                                        cell3.SetTextAlignment(TextAlignment.LEFT)
                                            .Add(new Paragraph(period)
                                                            //.SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_2)
                                                            .SetFontSize(9))
                                            .SetBackgroundColor(cl_tablecontent_2)
                                            .SetBorderTop(Border.NO_BORDER)
                                            .SetBorderBottom(Border.NO_BORDER);


                                        cell4.SetTextAlignment(TextAlignment.RIGHT)
                                            .Add(new Paragraph(string.Format("{0:N2}", activity.ActivityCost))
                                                            //.SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_2)
                                                            .SetFontSize(9))
                                            .SetBackgroundColor(cl_tablecontent_2)
                                            .SetBorderTop(Border.NO_BORDER)
                                            .SetBorderBottom(Border.NO_BORDER);

                                    }

                                    row_alt=ToggleBoolean(row_alt);
                                    if(inneriter==activitycount)
                                    {
                                        cell1.SetBorderBottom(new SolidBorder(1f));
                                        cell2.SetBorderBottom(new SolidBorder(1f));
                                        cell3.SetBorderBottom(new SolidBorder(1f));
                                        cell4.SetBorderBottom(new SolidBorder(1f));

                                    }

                                    tableactivity_outside223.AddCell(cell1);
                                    tableactivity_outside223.AddCell(cell2);
                                    tableactivity_outside223.AddCell(cell3);   
                                    tableactivity_outside223.AddCell(cell4);

                                }

                            }
                            inneriter=0;
                            row_alt=true;
                            document.Add(tableactivity_outside223);

                        }
                        
                    break;
                    case 3 :
                        int[] months_3 = { 7, 8, 9 };

                        foreach (var i in months_3)
                        {
                            float indentmargin_outer321=document.GetLeftMargin()+49;
                            Table tableactivity_outer321 = new Table(UnitValue.CreatePercentArray(new float[]{4, 96}), false)
                                                .SetWidth(PageSize.A4.GetWidth()-indentmargin_outer321)
                                                .SetMarginLeft(14)
                                                .SetHorizontalAlignment(HorizontalAlignment.LEFT);

                                Cell cellbullet321 = new Cell(1, 1)
                                .SetTextAlignment(TextAlignment.LEFT)
                                .Add(new Paragraph("\ue837")
                                                .SetFont(ft_materialicons_fonts)
                                                .SetFixedLeading(14f)
                                                .SetFontColor(cl_green)
                                                .SetFontSize(10))
                                    .SetBorder(Border.NO_BORDER);

                                Cell celltxt321= new Cell(1, 1)
                                .SetTextAlignment(TextAlignment.JUSTIFIED)
                                .Add(new Paragraph(System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i))
                                                .SetFixedLeading(14f)
                                                .SetFontColor(cl_green)
                                                .SetFontSize(10))
                                    .SetBorder(Border.NO_BORDER);

                            tableactivity_outer321.AddCell(cellbullet321);
                            tableactivity_outer321.AddCell(celltxt321);

                            document.Add(tableactivity_outer321);
                            document.Add(txt);

                            float indentmargin321=document.GetLeftMargin()+74;
                            float tablewidth221=PageSize.A4.GetWidth()-indentmargin321;
                            Table tableactivity_321 = new Table(UnitValue.CreatePercentArray(new float[]{35, 20, 27, 18}), false)
                                .SetWidth(PageSize.A4.GetWidth()-indentmargin321)
                                .SetMarginLeft(37)
                                .SetHorizontalAlignment(HorizontalAlignment.LEFT);


                            var DB_Activities321=_wpOutputActivitiesRepository.GetRecordsByMainRecordId(mainrec.Transaction_Id);

                            int actualrecords321=0;
                            foreach (var activity in DB_Activities321)
                            {
                                if(WithinMonth(mainrec.FiscalYear_Id, i, new DateTime(activity.ActivityStartDate.Year, activity.ActivityStartDate.Month, activity.ActivityStartDate.Day), new DateTime(activity.ActivityEndDate.Year, activity.ActivityEndDate.Month, activity.ActivityEndDate.Day))==true)
                                    actualrecords321=actualrecords321+1;
                            }

                            if(actualrecords321>=1)
                            {
                                //Row Header
                                Cell cellheader01 = new Cell(1, 1)
                                .SetTextAlignment(TextAlignment.LEFT)
                                .Add(new Paragraph("ACTIVITY")
                                                //.SetFont(ft_montserrat_medium)
                                                .SetFixedLeading(14f)
                                                .SetFontColor(cl_grayDark)
                                                .SetBackgroundColor(cl_tableheader)
                                                .SetFontSize(10))
                                    .SetBackgroundColor(cl_tableheader);

                                tableactivity_321.AddCell(cellheader01);

                                Cell cellheader02 = new Cell(1, 1)
                                    .SetTextAlignment(TextAlignment.LEFT)
                                    .Add(new Paragraph("TYPE")
                                                // .SetFont(ft_montserrat_medium)
                                                    .SetFixedLeading(14f)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tableheader)
                                                    .SetFontSize(10))
                                    .SetBackgroundColor(cl_tableheader);

                                tableactivity_321.AddCell(cellheader02);


                                Cell cellheader03 = new Cell(1, 1)
                                    .SetTextAlignment(TextAlignment.LEFT)
                                    .Add(new Paragraph("PERIOD")
                                                    .SetFont(ft_montserrat_medium)
                                                    .SetFixedLeading(14f)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tableheader)
                                                    .SetFontSize(10))
                                    .SetBackgroundColor(cl_tableheader);

                                tableactivity_321.AddCell(cellheader03);

                                Cell cellheader04 = new Cell(1, 1)
                                    .SetTextAlignment(TextAlignment.RIGHT)
                                    .Add(new Paragraph("AMOOUNT (USD)")
                                                // .SetFont(ft_montserrat_medium)
                                                    .SetFixedLeading(14f)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tableheader)
                                                    .SetFontSize(10))
                                    .SetBackgroundColor(cl_tableheader);

                                tableactivity_321.AddCell(cellheader04);

                                int activitycount=actualrecords321;

                                foreach (var activity in DB_Activities321)
                                {
                                    if(WithinMonth(mainrec.FiscalYear_Id, i, new DateTime(activity.ActivityStartDate.Year, activity.ActivityStartDate.Month, activity.ActivityStartDate.Day), new DateTime(activity.ActivityEndDate.Year, activity.ActivityEndDate.Month, activity.ActivityEndDate.Day)))
                                    {
                                        inneriter=inneriter+1;

                                        Cell cell1 = new Cell(1, 1);
                                        Cell cell2 = new Cell(1, 1);
                                        Cell cell3 = new Cell(1, 1);
                                        Cell cell4 = new Cell(1, 1);

                                        DateTime start= new  DateTime(activity.ActivityStartDate.Year, activity.ActivityStartDate.Month, activity.ActivityStartDate.Day);
                                        DateTime end= new  DateTime(activity.ActivityEndDate.Year, activity.ActivityEndDate.Month, activity.ActivityEndDate.Day);
                                        string period=start.Date.ToString("MMM. d, yyyy")+" - "+end.Date.ToString("MMM. d, yyyy");

                                        if(row_alt==false)
                                        {
                                            //Row Rows
                                            cell1.SetTextAlignment(TextAlignment.LEFT)
                                            .Add(new Paragraph(activity.ActivityDescription)
                                                        // .SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_1)
                                                            .SetFontSize(9))
                                                .SetBackgroundColor(cl_tablecontent_1)
                                                .SetBorderTop(Border.NO_BORDER)
                                                .SetBorderBottom(Border.NO_BORDER);


                                        
                                                cell2.SetTextAlignment(TextAlignment.LEFT)
                                                .Add(new Paragraph(_lkupActivityTypeRepository.GetActivityType(activity.ActivityType_Id).Activity_Name)
                                                            // .SetFont(ft_montserrat_reg)
                                                                .SetFixedLeading(14f)
                                                                .SetFontColor(cl_grayDark)
                                                                .SetBackgroundColor(cl_tablecontent_1)
                                                                .SetFontSize(9))
                                                .SetBackgroundColor(cl_tablecontent_1)
                                                .SetBorderTop(Border.NO_BORDER)
                                                .SetBorderBottom(Border.NO_BORDER);


                                                cell3.SetTextAlignment(TextAlignment.LEFT)
                                                .Add(new Paragraph(period)
                                                                //.SetFont(ft_montserrat_reg)
                                                                .SetFixedLeading(14f)
                                                                .SetFontColor(cl_grayDark)
                                                                .SetBackgroundColor(cl_tablecontent_1)
                                                                .SetFontSize(9))
                                                .SetBackgroundColor(cl_tablecontent_1)
                                                .SetBorderTop(Border.NO_BORDER)
                                                .SetBorderBottom(Border.NO_BORDER);



                                            cell4.SetTextAlignment(TextAlignment.RIGHT)
                                                .Add(new Paragraph(string.Format("{0:N2}", activity.ActivityCost))
                                                                //.SetFont(ft_montserrat_reg)
                                                                .SetFixedLeading(14f)
                                                                .SetFontColor(cl_grayDark)
                                                                .SetBackgroundColor(cl_tablecontent_1)
                                                                .SetFontSize(9))
                                                .SetBackgroundColor(cl_tablecontent_1)
                                                .SetBorderTop(Border.NO_BORDER)
                                                .SetBorderBottom(Border.NO_BORDER);


                                        }
                                        else
                                        {
                                            //Row Rows

                                            cell1.SetTextAlignment(TextAlignment.LEFT)
                                                .Add(new Paragraph(activity.ActivityDescription)
                                                                //.SetFont(ft_montserrat_reg)
                                                                .SetFixedLeading(14f)
                                                                .SetFontColor(cl_grayDark)
                                                                .SetBackgroundColor(cl_tablecontent_2)
                                                                .SetFontSize(9))
                                                    .SetBackgroundColor(cl_tablecontent_2)
                                                    .SetBorderTop(Border.NO_BORDER)
                                                    .SetBorderBottom(Border.NO_BORDER);



                                            cell2.SetTextAlignment(TextAlignment.LEFT)
                                                .Add(new Paragraph(_lkupActivityTypeRepository.GetActivityType(activity.ActivityType_Id).Activity_Name)
                                                                //.SetFont(ft_montserrat_reg)
                                                                .SetFixedLeading(14f)
                                                                .SetFontColor(cl_grayDark)
                                                                .SetBackgroundColor(cl_tablecontent_2)
                                                                .SetFontSize(9))
                                                .SetBackgroundColor(cl_tablecontent_2)
                                                .SetBorderTop(Border.NO_BORDER)
                                                .SetBorderBottom(Border.NO_BORDER);




                                            cell3.SetTextAlignment(TextAlignment.LEFT)
                                                .Add(new Paragraph(period)
                                                                //.SetFont(ft_montserrat_reg)
                                                                .SetFixedLeading(14f)
                                                                .SetFontColor(cl_grayDark)
                                                                .SetBackgroundColor(cl_tablecontent_2)
                                                                .SetFontSize(9))
                                                .SetBackgroundColor(cl_tablecontent_2)
                                                .SetBorderTop(Border.NO_BORDER)
                                                .SetBorderBottom(Border.NO_BORDER);



                                            cell4.SetTextAlignment(TextAlignment.RIGHT)
                                                .Add(new Paragraph(string.Format("{0:N2}", activity.ActivityCost))
                                                                //.SetFont(ft_montserrat_reg)
                                                                .SetFixedLeading(14f)
                                                                .SetFontColor(cl_grayDark)
                                                                .SetBackgroundColor(cl_tablecontent_2)
                                                                .SetFontSize(9))
                                                .SetBackgroundColor(cl_tablecontent_2)
                                                .SetBorderTop(Border.NO_BORDER)
                                                .SetBorderBottom(Border.NO_BORDER);
                                            

                                        }

                                        row_alt=ToggleBoolean(row_alt);
                                        if(inneriter==activitycount)
                                        {
                                            cell1.SetBorderBottom(new SolidBorder(1f));
                                            cell2.SetBorderBottom(new SolidBorder(1f));
                                            cell3.SetBorderBottom(new SolidBorder(1f));
                                            cell4.SetBorderBottom(new SolidBorder(1f));

                                        }

                                        tableactivity_321.AddCell(cell1);
                                        tableactivity_321.AddCell(cell2);
                                        tableactivity_321.AddCell(cell3);   
                                        tableactivity_321.AddCell(cell4);

                                    }

                                }

                                inneriter=0;
                                row_alt=true;
                                document.Add(tableactivity_321);

                                
                            }

                            document.Add(txt);
                            document.Add(txt);
                        }
            

                        float indentmargin_outer322=document.GetLeftMargin()+49;
                        Table tableactivity_outer322 = new Table(UnitValue.CreatePercentArray(new float[]{4, 96}), false)
                                            .SetWidth(PageSize.A4.GetWidth()-indentmargin_outer322)
                                            .SetMarginLeft(14)
                                            .SetHorizontalAlignment(HorizontalAlignment.LEFT);

                            Cell cellbullet322 = new Cell(1, 1)
                            .SetTextAlignment(TextAlignment.LEFT)
                            .Add(new Paragraph("\ue837")
                                            .SetFont(ft_materialicons_fonts)
                                            .SetFixedLeading(14f)
                                            .SetFontColor(cl_green)
                                            .SetFontSize(10))
                                .SetBorder(Border.NO_BORDER);

                            Cell celltxt322= new Cell(1, 1)
                            .SetTextAlignment(TextAlignment.JUSTIFIED)
                            .Add(new Paragraph("Activities Spanning Multiple Months")
                                            .SetFixedLeading(14f)
                                            .SetFontColor(cl_green)
                                            .SetFontSize(10))
                                .SetBorder(Border.NO_BORDER);

                        tableactivity_outer322.AddCell(cellbullet322);
                        tableactivity_outer322.AddCell(celltxt322);

                        document.Add(tableactivity_outer322);
                        document.Add(txt);

                        

                        float indentmargin_spanning322=document.GetLeftMargin()+74;
                        Table tableactivity_spanning322 = new Table(UnitValue.CreatePercentArray(new float[]{35, 20, 27, 18}), false)
                            .SetWidth(PageSize.A4.GetWidth()-indentmargin_spanning322)
                            .SetMarginLeft(37)
                            .SetHorizontalAlignment(HorizontalAlignment.LEFT);


                        var DB_Activities_spanning322=_wpOutputActivitiesRepository.GetRecordsByMainRecordId(mainrec.Transaction_Id);

                        DateTime startperiod_spanning322=new DateTime(Int32.Parse(_lkupFiscalYearRepository.GetRecord(mainrec.FiscalYear_Id).Record_Name) , 7, 1);
                        DateTime endperiod_spanning322=new DateTime(Int32.Parse(_lkupFiscalYearRepository.GetRecord(mainrec.FiscalYear_Id).Record_Name) , 9, DateTime.DaysInMonth(mainrec.FiscalYear_Id, 9));

                        int actualrecords_spanning322=0;
                        foreach (var activity in DB_Activities_spanning322)
                        {
                            if(IsActivitySpanningMultipleMonths(mainrec.FiscalYear_Id, months_3, new DateTime(activity.ActivityStartDate.Year, activity.ActivityStartDate.Month, activity.ActivityStartDate.Day), new DateTime(activity.ActivityEndDate.Year, activity.ActivityEndDate.Month, activity.ActivityEndDate.Day), startperiod_spanning322, endperiod_spanning322)==true)
                                actualrecords_spanning322=actualrecords_spanning322+1;
                        }
                        if(actualrecords_spanning322>=1)
                        {
                            //Row Header
                            Cell cellheader01 = new Cell(1, 1)
                            .SetTextAlignment(TextAlignment.LEFT)
                            .Add(new Paragraph("ACTIVITY")
                                            //.SetFont(ft_montserrat_medium)
                                            .SetFixedLeading(14f)
                                            .SetFontColor(cl_grayDark)
                                            .SetBackgroundColor(cl_tableheader)
                                            .SetFontSize(10))
                                .SetBackgroundColor(cl_tableheader);
                            tableactivity_spanning322.AddCell(cellheader01);

                            Cell cellheader02 = new Cell(1, 1)
                                .SetTextAlignment(TextAlignment.LEFT)
                                .Add(new Paragraph("TYPE")
                                                // .SetFont(ft_montserrat_medium)
                                                .SetFixedLeading(14f)
                                                .SetFontColor(cl_grayDark)
                                                .SetBackgroundColor(cl_tableheader)
                                                .SetFontSize(10))
                                .SetBackgroundColor(cl_tableheader);
                            tableactivity_spanning322.AddCell(cellheader02);


                            Cell cellheader03 = new Cell(1, 1)
                                .SetTextAlignment(TextAlignment.LEFT)
                                .Add(new Paragraph("PERIOD")
                                                //.SetFont(ft_montserrat_medium)
                                                .SetFixedLeading(14f)
                                                .SetFontColor(cl_grayDark)
                                                .SetBackgroundColor(cl_tableheader)
                                                .SetFontSize(10))
                                .SetBackgroundColor(cl_tableheader);
                            tableactivity_spanning322.AddCell(cellheader03);

                            Cell cellheader04 = new Cell(1, 1)
                                .SetTextAlignment(TextAlignment.RIGHT)
                                .Add(new Paragraph("AMOUNT (USD)")
                                                //.SetFont(ft_montserrat_medium)
                                                .SetFixedLeading(14f)
                                                .SetFontColor(cl_grayDark)
                                                .SetBackgroundColor(cl_tableheader)
                                                .SetFontSize(10))
                                .SetBackgroundColor(cl_tableheader);

                            tableactivity_spanning322.AddCell(cellheader04);

                            int activitycount=actualrecords_spanning322;

                            foreach (var activity in DB_Activities_spanning322)
                            {
                                if(IsActivitySpanningMultipleMonths(mainrec.FiscalYear_Id, months_3, new DateTime(activity.ActivityStartDate.Year, activity.ActivityStartDate.Month, activity.ActivityStartDate.Day), new DateTime(activity.ActivityEndDate.Year, activity.ActivityEndDate.Month, activity.ActivityEndDate.Day), startperiod_spanning322, endperiod_spanning322))
                                {
                                    inneriter=inneriter+1;

                                    Cell cell1 = new Cell(1, 1);
                                    Cell cell2 = new Cell(1, 1);
                                    Cell cell3 = new Cell(1, 1);
                                    Cell cell4 = new Cell(1, 1);

                                    DateTime start= new  DateTime(activity.ActivityStartDate.Year, activity.ActivityStartDate.Month, activity.ActivityStartDate.Day);
                                    DateTime end= new  DateTime(activity.ActivityEndDate.Year, activity.ActivityEndDate.Month, activity.ActivityEndDate.Day);
                                    string period=start.Date.ToString("MMM. d, yyyy")+" - "+end.Date.ToString("MMM. d, yyyy");

                                    if(row_alt==false)
                                    {
                                        //Row Rows
                                        cell1.SetTextAlignment(TextAlignment.LEFT)
                                        .Add(new Paragraph(activity.ActivityDescription)
                                                        // .SetFont(ft_montserrat_reg)
                                                        .SetFixedLeading(14f)
                                                        .SetFontColor(cl_grayDark)
                                                        .SetBackgroundColor(cl_tablecontent_1)
                                                        .SetFontSize(9))
                                            .SetBackgroundColor(cl_tablecontent_1)
                                            .SetBorderTop(Border.NO_BORDER)
                                            .SetBorderBottom(Border.NO_BORDER);


                                    
                                            cell2.SetTextAlignment(TextAlignment.LEFT)
                                            .Add(new Paragraph(_lkupActivityTypeRepository.GetActivityType(activity.ActivityType_Id).Activity_Name)
                                                            // .SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_1)
                                                            .SetFontSize(9))
                                            .SetBackgroundColor(cl_tablecontent_1)
                                            .SetBorderTop(Border.NO_BORDER)
                                            .SetBorderBottom(Border.NO_BORDER);


                                            cell3.SetTextAlignment(TextAlignment.LEFT)
                                            .Add(new Paragraph(period)
                                                            //.SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_1)
                                                            .SetFontSize(9))
                                            .SetBackgroundColor(cl_tablecontent_1)
                                            .SetBorderTop(Border.NO_BORDER)
                                            .SetBorderBottom(Border.NO_BORDER);



                                        cell4.SetTextAlignment(TextAlignment.RIGHT)
                                            .Add(new Paragraph(string.Format("{0:N2}", activity.ActivityCost))
                                                            //.SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_1)
                                                            .SetFontSize(9))
                                            .SetBackgroundColor(cl_tablecontent_1)
                                            .SetBorderTop(Border.NO_BORDER)
                                            .SetBorderBottom(Border.NO_BORDER);
                                    }
                                    else
                                    {
                                        //Row Rows

                                        cell1.SetTextAlignment(TextAlignment.LEFT)
                                            .Add(new Paragraph(activity.ActivityDescription)
                                                            // .SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_2)
                                                            .SetFontSize(9))
                                                .SetBackgroundColor(cl_tablecontent_2)
                                                .SetBorderTop(Border.NO_BORDER)
                                                .SetBorderBottom(Border.NO_BORDER);



                                        cell2.SetTextAlignment(TextAlignment.LEFT)
                                            .Add(new Paragraph(_lkupActivityTypeRepository.GetActivityType(activity.ActivityType_Id).Activity_Name)
                                                            //.SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_2)
                                                            .SetFontSize(9))
                                            .SetBackgroundColor(cl_tablecontent_2)
                                            .SetBorderTop(Border.NO_BORDER)
                                            .SetBorderBottom(Border.NO_BORDER);


                                        cell3.SetTextAlignment(TextAlignment.LEFT)
                                            .Add(new Paragraph(period)
                                                            // .SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_2)
                                                            .SetFontSize(9))
                                            .SetBackgroundColor(cl_tablecontent_2)
                                            .SetBorderTop(Border.NO_BORDER)
                                            .SetBorderBottom(Border.NO_BORDER);
        


                                        cell4.SetTextAlignment(TextAlignment.RIGHT)
                                            .Add(new Paragraph(string.Format("{0:N2}", activity.ActivityCost))
                                                            // .SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_2)
                                                            .SetFontSize(9))
                                            .SetBackgroundColor(cl_tablecontent_2)
                                            .SetBorderTop(Border.NO_BORDER)
                                            .SetBorderBottom(Border.NO_BORDER);
                                        

                                    }

                                    row_alt=ToggleBoolean(row_alt);
                                    if(inneriter==activitycount)
                                    {
                                        cell1.SetBorderBottom(new SolidBorder(1f));
                                        cell2.SetBorderBottom(new SolidBorder(1f));
                                        cell3.SetBorderBottom(new SolidBorder(1f));
                                        cell4.SetBorderBottom(new SolidBorder(1f));

                                    }

                                    tableactivity_spanning322.AddCell(cell1);
                                    tableactivity_spanning322.AddCell(cell2);
                                    tableactivity_spanning322.AddCell(cell3);   
                                    tableactivity_spanning322.AddCell(cell4);

                                }

                            }
                            inneriter=0;
                            row_alt=true;
                            document.Add(tableactivity_spanning322);
                        }

                        document.Add(txt);
                        document.Add(txt);

                        float indentmargin_outer323=document.GetLeftMargin()+49;
                        Table tableactivity_outer323= new Table(UnitValue.CreatePercentArray(new float[]{4, 96}), false)
                                            .SetWidth(PageSize.A4.GetWidth()-indentmargin_outer323)
                                            .SetMarginLeft(14)
                                            .SetHorizontalAlignment(HorizontalAlignment.LEFT);

                            Cell cellbullet323 = new Cell(1, 1)
                            .SetTextAlignment(TextAlignment.LEFT)
                            .Add(new Paragraph("\ue837")
                                            .SetFont(ft_materialicons_fonts)
                                            .SetFixedLeading(14f)
                                            .SetFontColor(cl_green)
                                            .SetFontSize(10))
                                .SetBorder(Border.NO_BORDER);

                            Cell celltxt323= new Cell(1, 1)
                            .SetTextAlignment(TextAlignment.JUSTIFIED)
                            .Add(new Paragraph("Activities Outside of Workplan Period")
                                            .SetFixedLeading(14f)
                                            .SetFontColor(cl_green)
                                            .SetFontSize(10))
                                .SetBorder(Border.NO_BORDER);

                        tableactivity_outer323.AddCell(cellbullet323);
                        tableactivity_outer323.AddCell(celltxt323);

                        document.Add(tableactivity_outer323);
                        document.Add(txt);

                        float indentmargin_outside323=document.GetLeftMargin()+74;
                        Table tableactivity_outside323 = new Table(UnitValue.CreatePercentArray(new float[]{35, 20, 27, 18}), false)
                            .SetWidth(PageSize.A4.GetWidth()-indentmargin_outside323)
                            .SetMarginLeft(37)
                            .SetHorizontalAlignment(HorizontalAlignment.LEFT);


                        var DB_Activities_outside323=_wpOutputActivitiesRepository.GetRecordsByMainRecordId(mainrec.Transaction_Id);

                        DateTime startperiod_outside323=new DateTime(Int32.Parse(_lkupFiscalYearRepository.GetRecord(mainrec.FiscalYear_Id).Record_Name) , 7, 1);
                        DateTime endperiod_outside323=new DateTime(Int32.Parse(_lkupFiscalYearRepository.GetRecord(mainrec.FiscalYear_Id).Record_Name) , 9, DateTime.DaysInMonth(mainrec.FiscalYear_Id, 9));

                        int actualrecords_outside323=0;
                        foreach (var activity in DB_Activities_outside323)
                        {
                            if(IsActivityOutsideWPPeriod(new DateTime(activity.ActivityStartDate.Year, activity.ActivityStartDate.Month, activity.ActivityStartDate.Day), new DateTime(activity.ActivityEndDate.Year, activity.ActivityEndDate.Month, activity.ActivityEndDate.Day), startperiod_outside323, endperiod_outside323)==true)
                                actualrecords_outside323=actualrecords_outside323+1;
                        }
                        if(actualrecords_outside323>=1)
                        {
                            //Row Header
                            Cell cellheader01 = new Cell(1, 1)
                            .SetTextAlignment(TextAlignment.LEFT)
                            .Add(new Paragraph("ACTIVITY")
                                            //.SetFont(ft_montserrat_medium)
                                            .SetFixedLeading(14f)
                                            .SetFontColor(cl_grayDark)
                                            .SetBackgroundColor(cl_tableheader)
                                            .SetFontSize(10))
                                .SetBackgroundColor(cl_tableheader);

                            tableactivity_outside323.AddCell(cellheader01);

                            Cell cellheader02 = new Cell(1, 1)
                                .SetTextAlignment(TextAlignment.LEFT)
                                .Add(new Paragraph("TYPE")
                                                // .SetFont(ft_montserrat_medium)
                                                .SetFixedLeading(14f)
                                                .SetFontColor(cl_grayDark)
                                                .SetBackgroundColor(cl_tableheader)
                                                .SetFontSize(10))
                                .SetBackgroundColor(cl_tableheader);

                            tableactivity_outside323.AddCell(cellheader02);


                            Cell cellheader03 = new Cell(1, 1)
                                .SetTextAlignment(TextAlignment.LEFT)
                                .Add(new Paragraph("PERIOD")
                                                // .SetFont(ft_montserrat_medium)
                                                .SetFixedLeading(14f)
                                                .SetFontColor(cl_grayDark)
                                                .SetBackgroundColor(cl_tableheader)
                                                .SetFontSize(10))
                                .SetBackgroundColor(cl_tableheader);
                            tableactivity_outside323.AddCell(cellheader03);

                            Cell cellheader04 = new Cell(1, 1)
                                .SetTextAlignment(TextAlignment.RIGHT)
                                .Add(new Paragraph("AMOUNT (USD)")
                                                // .SetFont(ft_montserrat_medium)
                                                .SetFixedLeading(14f)
                                                .SetFontColor(cl_grayDark)
                                                .SetBackgroundColor(cl_tableheader)
                                                .SetFontSize(10))
                                .SetBackgroundColor(cl_tableheader);

                            tableactivity_outside323.AddCell(cellheader04);

                            int activitycount=actualrecords_outside323;

                            foreach (var activity in DB_Activities_outside323)
                            {
                                if(IsActivityOutsideWPPeriod(new DateTime(activity.ActivityStartDate.Year, activity.ActivityStartDate.Month, activity.ActivityStartDate.Day), new DateTime(activity.ActivityEndDate.Year, activity.ActivityEndDate.Month, activity.ActivityEndDate.Day), startperiod_outside323, endperiod_outside323)==true)
                                {
                                    inneriter=inneriter+1;

                                    Cell cell1 = new Cell(1, 1);
                                    Cell cell2 = new Cell(1, 1);
                                    Cell cell3 = new Cell(1, 1);
                                    Cell cell4 = new Cell(1, 1);

                                    DateTime start= new  DateTime(activity.ActivityStartDate.Year, activity.ActivityStartDate.Month, activity.ActivityStartDate.Day);
                                    DateTime end= new  DateTime(activity.ActivityEndDate.Year, activity.ActivityEndDate.Month, activity.ActivityEndDate.Day);
                                    string period=start.Date.ToString("MMM. d, yyyy")+" - "+end.Date.ToString("MMM. d, yyyy");

                                    if(row_alt==false)
                                    {
                                        //Row Rows
                                        cell1.SetTextAlignment(TextAlignment.LEFT)
                                        .Add(new Paragraph(activity.ActivityDescription)
                                                        //.SetFont(ft_montserrat_reg)
                                                        .SetFixedLeading(14f)
                                                        .SetFontColor(cl_grayDark)
                                                        .SetBackgroundColor(cl_tablecontent_1)
                                                        .SetFontSize(9))
                                            .SetBackgroundColor(cl_tablecontent_1)
                                            .SetBorderTop(Border.NO_BORDER)
                                            .SetBorderBottom(Border.NO_BORDER);


                                    
                                            cell2.SetTextAlignment(TextAlignment.LEFT)
                                            .Add(new Paragraph(_lkupActivityTypeRepository.GetActivityType(activity.ActivityType_Id).Activity_Name)
                                                            //.SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_1)
                                                            .SetFontSize(9))
                                            .SetBackgroundColor(cl_tablecontent_1)
                                            .SetBorderTop(Border.NO_BORDER)
                                            .SetBorderBottom(Border.NO_BORDER);


                                            cell3.SetTextAlignment(TextAlignment.LEFT)
                                            .Add(new Paragraph(period)
                                                            //.SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_1)
                                                            .SetFontSize(9))
                                            .SetBackgroundColor(cl_tablecontent_1)
                                            .SetBorderTop(Border.NO_BORDER)
                                            .SetBorderBottom(Border.NO_BORDER);


                                        cell4.SetTextAlignment(TextAlignment.RIGHT)
                                            .Add(new Paragraph(string.Format("{0:N2}", activity.ActivityCost))
                                                            //.SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_1)
                                                            .SetFontSize(9))
                                            .SetBackgroundColor(cl_tablecontent_1)
                                            .SetBorderTop(Border.NO_BORDER)
                                            .SetBorderBottom(Border.NO_BORDER);


                                    }
                                    else
                                    {
                                        //Row Rows

                                        cell1.SetTextAlignment(TextAlignment.LEFT)
                                            .Add(new Paragraph(activity.ActivityDescription)
                                                            //.SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_2)
                                                            .SetFontSize(9))
                                                .SetBackgroundColor(cl_tablecontent_2)
                                                .SetBorderTop(Border.NO_BORDER)
                                                .SetBorderBottom(Border.NO_BORDER);



                                        cell2.SetTextAlignment(TextAlignment.LEFT)
                                            .Add(new Paragraph(_lkupActivityTypeRepository.GetActivityType(activity.ActivityType_Id).Activity_Name)
                                                            //.SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_2)
                                                            .SetFontSize(9))
                                            .SetBackgroundColor(cl_tablecontent_2)
                                            .SetBorderTop(Border.NO_BORDER)
                                            .SetBorderBottom(Border.NO_BORDER);



                                        cell3.SetTextAlignment(TextAlignment.LEFT)
                                            .Add(new Paragraph(period)
                                                            //.SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_2)
                                                            .SetFontSize(9))
                                            .SetBackgroundColor(cl_tablecontent_2)
                                            .SetBorderTop(Border.NO_BORDER)
                                            .SetBorderBottom(Border.NO_BORDER);


                                        cell4.SetTextAlignment(TextAlignment.RIGHT)
                                            .Add(new Paragraph(string.Format("{0:N2}", activity.ActivityCost))
                                                            //.SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_2)
                                                            .SetFontSize(9))
                                            .SetBackgroundColor(cl_tablecontent_2)
                                            .SetBorderTop(Border.NO_BORDER)
                                            .SetBorderBottom(Border.NO_BORDER);

                                    }

                                    row_alt=ToggleBoolean(row_alt);
                                    if(inneriter==activitycount)
                                    {
                                        cell1.SetBorderBottom(new SolidBorder(1f));
                                        cell2.SetBorderBottom(new SolidBorder(1f));
                                        cell3.SetBorderBottom(new SolidBorder(1f));
                                        cell4.SetBorderBottom(new SolidBorder(1f));

                                    }

                                    tableactivity_outside323.AddCell(cell1);
                                    tableactivity_outside323.AddCell(cell2);
                                    tableactivity_outside323.AddCell(cell3);   
                                    tableactivity_outside323.AddCell(cell4);

                                }

                            }
                            inneriter=0;
                            row_alt=true;
                            document.Add(tableactivity_outside323);

                        }
                    
                    break;
                    case 4 :
                        int[] months_4 = { 10, 11, 12 };
                        foreach (var i in months_4)
                        {
                            float indentmargin_outer421=document.GetLeftMargin()+49;
                            Table tableactivity_outer421 = new Table(UnitValue.CreatePercentArray(new float[]{4, 96}), false)
                                                .SetWidth(PageSize.A4.GetWidth()-indentmargin_outer421)
                                                .SetMarginLeft(14)
                                                .SetHorizontalAlignment(HorizontalAlignment.LEFT);

                                Cell cellbullet421 = new Cell(1, 1)
                                .SetTextAlignment(TextAlignment.LEFT)
                                .Add(new Paragraph("\ue837")
                                                .SetFont(ft_materialicons_fonts)
                                                .SetFixedLeading(14f)
                                                .SetFontColor(cl_green)
                                                .SetFontSize(10))
                                    .SetBorder(Border.NO_BORDER);

                                Cell celltxt421= new Cell(1, 1)
                                .SetTextAlignment(TextAlignment.JUSTIFIED)
                                .Add(new Paragraph(System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i))
                                                .SetFixedLeading(14f)
                                                .SetFontColor(cl_green)
                                                .SetFontSize(10))
                                    .SetBorder(Border.NO_BORDER);

                            tableactivity_outer421.AddCell(cellbullet421);
                            tableactivity_outer421.AddCell(celltxt421);

                            document.Add(tableactivity_outer421);
                            document.Add(txt);

                            float indentmargin421=document.GetLeftMargin()+74;
                            float tablewidth421=PageSize.A4.GetWidth()-indentmargin421;
                            Table tableactivity_421 = new Table(UnitValue.CreatePercentArray(new float[]{35, 20, 27, 18}), false)
                                .SetWidth(PageSize.A4.GetWidth()-indentmargin421)
                                .SetMarginLeft(37)
                                .SetHorizontalAlignment(HorizontalAlignment.LEFT);


                            var DB_Activities421=_wpOutputActivitiesRepository.GetRecordsByMainRecordId(mainrec.Transaction_Id);

                            int actualrecords421=0;
                            foreach (var activity in DB_Activities421)
                            {
                                if(WithinMonth(mainrec.FiscalYear_Id, i, new DateTime(activity.ActivityStartDate.Year, activity.ActivityStartDate.Month, activity.ActivityStartDate.Day), new DateTime(activity.ActivityEndDate.Year, activity.ActivityEndDate.Month, activity.ActivityEndDate.Day))==true)
                                    actualrecords421=actualrecords421+1;
                            }

                            if(actualrecords421>=1)
                            {
                                //Row Header
                                Cell cellheader01 = new Cell(1, 1)
                                .SetTextAlignment(TextAlignment.LEFT)
                                .Add(new Paragraph("ACTIVITY")
                                                //.SetFont(ft_montserrat_medium)
                                                .SetFixedLeading(14f)
                                                .SetFontColor(cl_grayDark)
                                                .SetBackgroundColor(cl_tableheader)
                                                .SetFontSize(10))
                                    .SetBackgroundColor(cl_tableheader);

                                tableactivity_421.AddCell(cellheader01);

                                Cell cellheader02 = new Cell(1, 1)
                                    .SetTextAlignment(TextAlignment.LEFT)
                                    .Add(new Paragraph("TYPE")
                                                // .SetFont(ft_montserrat_medium)
                                                    .SetFixedLeading(14f)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tableheader)
                                                    .SetFontSize(10))
                                    .SetBackgroundColor(cl_tableheader);

                                tableactivity_421.AddCell(cellheader02);


                                Cell cellheader03 = new Cell(1, 1)
                                    .SetTextAlignment(TextAlignment.LEFT)
                                    .Add(new Paragraph("PERIOD")
                                                    .SetFont(ft_montserrat_medium)
                                                    .SetFixedLeading(14f)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tableheader)
                                                    .SetFontSize(10))
                                    .SetBackgroundColor(cl_tableheader);

                                tableactivity_421.AddCell(cellheader03);

                                Cell cellheader04 = new Cell(1, 1)
                                    .SetTextAlignment(TextAlignment.RIGHT)
                                    .Add(new Paragraph("AMOOUNT (USD)")
                                                // .SetFont(ft_montserrat_medium)
                                                    .SetFixedLeading(14f)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tableheader)
                                                    .SetFontSize(10))
                                    .SetBackgroundColor(cl_tableheader);

                                tableactivity_421.AddCell(cellheader04);

                                int activitycount=actualrecords421;

                                foreach (var activity in DB_Activities421)
                                {
                                    if(WithinMonth(mainrec.FiscalYear_Id, i, new DateTime(activity.ActivityStartDate.Year, activity.ActivityStartDate.Month, activity.ActivityStartDate.Day), new DateTime(activity.ActivityEndDate.Year, activity.ActivityEndDate.Month, activity.ActivityEndDate.Day)))
                                    {
                                        inneriter=inneriter+1;

                                        Cell cell1 = new Cell(1, 1);
                                        Cell cell2 = new Cell(1, 1);
                                        Cell cell3 = new Cell(1, 1);
                                        Cell cell4 = new Cell(1, 1);

                                        DateTime start= new  DateTime(activity.ActivityStartDate.Year, activity.ActivityStartDate.Month, activity.ActivityStartDate.Day);
                                        DateTime end= new  DateTime(activity.ActivityEndDate.Year, activity.ActivityEndDate.Month, activity.ActivityEndDate.Day);
                                        string period=start.Date.ToString("MMM. d, yyyy")+" - "+end.Date.ToString("MMM. d, yyyy");

                                        if(row_alt==false)
                                        {
                                            //Row Rows
                                            cell1.SetTextAlignment(TextAlignment.LEFT)
                                            .Add(new Paragraph(activity.ActivityDescription)
                                                        // .SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_1)
                                                            .SetFontSize(9))
                                                .SetBackgroundColor(cl_tablecontent_1)
                                                .SetBorderTop(Border.NO_BORDER)
                                                .SetBorderBottom(Border.NO_BORDER);


                                        
                                                cell2.SetTextAlignment(TextAlignment.LEFT)
                                                .Add(new Paragraph(_lkupActivityTypeRepository.GetActivityType(activity.ActivityType_Id).Activity_Name)
                                                            // .SetFont(ft_montserrat_reg)
                                                                .SetFixedLeading(14f)
                                                                .SetFontColor(cl_grayDark)
                                                                .SetBackgroundColor(cl_tablecontent_1)
                                                                .SetFontSize(9))
                                                .SetBackgroundColor(cl_tablecontent_1)
                                                .SetBorderTop(Border.NO_BORDER)
                                                .SetBorderBottom(Border.NO_BORDER);


                                                cell3.SetTextAlignment(TextAlignment.LEFT)
                                                .Add(new Paragraph(period)
                                                                //.SetFont(ft_montserrat_reg)
                                                                .SetFixedLeading(14f)
                                                                .SetFontColor(cl_grayDark)
                                                                .SetBackgroundColor(cl_tablecontent_1)
                                                                .SetFontSize(9))
                                                .SetBackgroundColor(cl_tablecontent_1)
                                                .SetBorderTop(Border.NO_BORDER)
                                                .SetBorderBottom(Border.NO_BORDER);



                                            cell4.SetTextAlignment(TextAlignment.RIGHT)
                                                .Add(new Paragraph(string.Format("{0:N2}", activity.ActivityCost))
                                                                //.SetFont(ft_montserrat_reg)
                                                                .SetFixedLeading(14f)
                                                                .SetFontColor(cl_grayDark)
                                                                .SetBackgroundColor(cl_tablecontent_1)
                                                                .SetFontSize(9))
                                                .SetBackgroundColor(cl_tablecontent_1)
                                                .SetBorderTop(Border.NO_BORDER)
                                                .SetBorderBottom(Border.NO_BORDER);


                                        }
                                        else
                                        {
                                            //Row Rows

                                            cell1.SetTextAlignment(TextAlignment.LEFT)
                                                .Add(new Paragraph(activity.ActivityDescription)
                                                                //.SetFont(ft_montserrat_reg)
                                                                .SetFixedLeading(14f)
                                                                .SetFontColor(cl_grayDark)
                                                                .SetBackgroundColor(cl_tablecontent_2)
                                                                .SetFontSize(9))
                                                    .SetBackgroundColor(cl_tablecontent_2)
                                                    .SetBorderTop(Border.NO_BORDER)
                                                    .SetBorderBottom(Border.NO_BORDER);



                                            cell2.SetTextAlignment(TextAlignment.LEFT)
                                                .Add(new Paragraph(_lkupActivityTypeRepository.GetActivityType(activity.ActivityType_Id).Activity_Name)
                                                                //.SetFont(ft_montserrat_reg)
                                                                .SetFixedLeading(14f)
                                                                .SetFontColor(cl_grayDark)
                                                                .SetBackgroundColor(cl_tablecontent_2)
                                                                .SetFontSize(9))
                                                .SetBackgroundColor(cl_tablecontent_2)
                                                .SetBorderTop(Border.NO_BORDER)
                                                .SetBorderBottom(Border.NO_BORDER);




                                            cell3.SetTextAlignment(TextAlignment.LEFT)
                                                .Add(new Paragraph(period)
                                                                //.SetFont(ft_montserrat_reg)
                                                                .SetFixedLeading(14f)
                                                                .SetFontColor(cl_grayDark)
                                                                .SetBackgroundColor(cl_tablecontent_2)
                                                                .SetFontSize(9))
                                                .SetBackgroundColor(cl_tablecontent_2)
                                                .SetBorderTop(Border.NO_BORDER)
                                                .SetBorderBottom(Border.NO_BORDER);



                                            cell4.SetTextAlignment(TextAlignment.RIGHT)
                                                .Add(new Paragraph(string.Format("{0:N2}", activity.ActivityCost))
                                                                //.SetFont(ft_montserrat_reg)
                                                                .SetFixedLeading(14f)
                                                                .SetFontColor(cl_grayDark)
                                                                .SetBackgroundColor(cl_tablecontent_2)
                                                                .SetFontSize(9))
                                                .SetBackgroundColor(cl_tablecontent_2)
                                                .SetBorderTop(Border.NO_BORDER)
                                                .SetBorderBottom(Border.NO_BORDER);
                                            

                                        }

                                        row_alt=ToggleBoolean(row_alt);
                                        if(inneriter==activitycount)
                                        {
                                            cell1.SetBorderBottom(new SolidBorder(1f));
                                            cell2.SetBorderBottom(new SolidBorder(1f));
                                            cell3.SetBorderBottom(new SolidBorder(1f));
                                            cell4.SetBorderBottom(new SolidBorder(1f));

                                        }

                                        tableactivity_421.AddCell(cell1);
                                        tableactivity_421.AddCell(cell2);
                                        tableactivity_421.AddCell(cell3);   
                                        tableactivity_421.AddCell(cell4);

                                    }

                                }

                                inneriter=0;
                                row_alt=true;
                                document.Add(tableactivity_421);

                                
                            }

                            document.Add(txt);
                            document.Add(txt);
                        }
            

                        float indentmargin_outer422=document.GetLeftMargin()+49;
                        Table tableactivity_outer422 = new Table(UnitValue.CreatePercentArray(new float[]{4, 96}), false)
                                            .SetWidth(PageSize.A4.GetWidth()-indentmargin_outer422)
                                            .SetMarginLeft(14)
                                            .SetHorizontalAlignment(HorizontalAlignment.LEFT);

                            Cell cellbullet422 = new Cell(1, 1)
                            .SetTextAlignment(TextAlignment.LEFT)
                            .Add(new Paragraph("\ue837")
                                            .SetFont(ft_materialicons_fonts)
                                            .SetFixedLeading(14f)
                                            .SetFontColor(cl_green)
                                            .SetFontSize(10))
                                .SetBorder(Border.NO_BORDER);

                            Cell celltxt422= new Cell(1, 1)
                            .SetTextAlignment(TextAlignment.JUSTIFIED)
                            .Add(new Paragraph("Activities Spanning Multiple Months")
                                            .SetFixedLeading(14f)
                                            .SetFontColor(cl_green)
                                            .SetFontSize(10))
                                .SetBorder(Border.NO_BORDER);

                        tableactivity_outer422.AddCell(cellbullet422);
                        tableactivity_outer422.AddCell(celltxt422);

                        document.Add(tableactivity_outer422);
                        document.Add(txt);

                        

                        float indentmargin_spanning422=document.GetLeftMargin()+74;
                        Table tableactivity_spanning422 = new Table(UnitValue.CreatePercentArray(new float[]{35, 20, 27, 18}), false)
                            .SetWidth(PageSize.A4.GetWidth()-indentmargin_spanning422)
                            .SetMarginLeft(37)
                            .SetHorizontalAlignment(HorizontalAlignment.LEFT);


                        var DB_Activities_spanning422=_wpOutputActivitiesRepository.GetRecordsByMainRecordId(mainrec.Transaction_Id);

                        DateTime startperiod_spanning422=new DateTime(Int32.Parse(_lkupFiscalYearRepository.GetRecord(mainrec.FiscalYear_Id).Record_Name) , 10, 1);
                        DateTime endperiod_spanning422=new DateTime(Int32.Parse(_lkupFiscalYearRepository.GetRecord(mainrec.FiscalYear_Id).Record_Name) , 12, DateTime.DaysInMonth(mainrec.FiscalYear_Id, 12));

                        int actualrecords_spanning422=0;
                        foreach (var activity in DB_Activities_spanning422)
                        {
                            if(IsActivitySpanningMultipleMonths(mainrec.FiscalYear_Id, months_4, new DateTime(activity.ActivityStartDate.Year, activity.ActivityStartDate.Month, activity.ActivityStartDate.Day), new DateTime(activity.ActivityEndDate.Year, activity.ActivityEndDate.Month, activity.ActivityEndDate.Day), startperiod_spanning422, endperiod_spanning422)==true)
                                actualrecords_spanning422=actualrecords_spanning422+1;
                        }
                        if(actualrecords_spanning422>=1)
                        {
                            //Row Header
                            Cell cellheader01 = new Cell(1, 1)
                            .SetTextAlignment(TextAlignment.LEFT)
                            .Add(new Paragraph("ACTIVITY")
                                            //.SetFont(ft_montserrat_medium)
                                            .SetFixedLeading(14f)
                                            .SetFontColor(cl_grayDark)
                                            .SetBackgroundColor(cl_tableheader)
                                            .SetFontSize(10))
                                .SetBackgroundColor(cl_tableheader);
                            tableactivity_spanning422.AddCell(cellheader01);

                            Cell cellheader02 = new Cell(1, 1)
                                .SetTextAlignment(TextAlignment.LEFT)
                                .Add(new Paragraph("TYPE")
                                                // .SetFont(ft_montserrat_medium)
                                                .SetFixedLeading(14f)
                                                .SetFontColor(cl_grayDark)
                                                .SetBackgroundColor(cl_tableheader)
                                                .SetFontSize(10))
                                .SetBackgroundColor(cl_tableheader);
                            tableactivity_spanning422.AddCell(cellheader02);


                            Cell cellheader03 = new Cell(1, 1)
                                .SetTextAlignment(TextAlignment.LEFT)
                                .Add(new Paragraph("PERIOD")
                                                //.SetFont(ft_montserrat_medium)
                                                .SetFixedLeading(14f)
                                                .SetFontColor(cl_grayDark)
                                                .SetBackgroundColor(cl_tableheader)
                                                .SetFontSize(10))
                                .SetBackgroundColor(cl_tableheader);
                            tableactivity_spanning422.AddCell(cellheader03);

                            Cell cellheader04 = new Cell(1, 1)
                                .SetTextAlignment(TextAlignment.RIGHT)
                                .Add(new Paragraph("AMOUNT (USD)")
                                                //.SetFont(ft_montserrat_medium)
                                                .SetFixedLeading(14f)
                                                .SetFontColor(cl_grayDark)
                                                .SetBackgroundColor(cl_tableheader)
                                                .SetFontSize(10))
                                .SetBackgroundColor(cl_tableheader);

                            tableactivity_spanning422.AddCell(cellheader04);

                            int activitycount=actualrecords_spanning422;

                            foreach (var activity in DB_Activities_spanning422)
                            {
                                if(IsActivitySpanningMultipleMonths(mainrec.FiscalYear_Id, months_4, new DateTime(activity.ActivityStartDate.Year, activity.ActivityStartDate.Month, activity.ActivityStartDate.Day), new DateTime(activity.ActivityEndDate.Year, activity.ActivityEndDate.Month, activity.ActivityEndDate.Day), startperiod_spanning422, endperiod_spanning422))
                                {
                                    inneriter=inneriter+1;

                                    Cell cell1 = new Cell(1, 1);
                                    Cell cell2 = new Cell(1, 1);
                                    Cell cell3 = new Cell(1, 1);
                                    Cell cell4 = new Cell(1, 1);

                                    DateTime start= new  DateTime(activity.ActivityStartDate.Year, activity.ActivityStartDate.Month, activity.ActivityStartDate.Day);
                                    DateTime end= new  DateTime(activity.ActivityEndDate.Year, activity.ActivityEndDate.Month, activity.ActivityEndDate.Day);
                                    string period=start.Date.ToString("MMM. d, yyyy")+" - "+end.Date.ToString("MMM. d, yyyy");

                                    if(row_alt==false)
                                    {
                                        //Row Rows
                                        cell1.SetTextAlignment(TextAlignment.LEFT)
                                        .Add(new Paragraph(activity.ActivityDescription)
                                                        // .SetFont(ft_montserrat_reg)
                                                        .SetFixedLeading(14f)
                                                        .SetFontColor(cl_grayDark)
                                                        .SetBackgroundColor(cl_tablecontent_1)
                                                        .SetFontSize(9))
                                            .SetBackgroundColor(cl_tablecontent_1)
                                            .SetBorderTop(Border.NO_BORDER)
                                            .SetBorderBottom(Border.NO_BORDER);


                                    
                                            cell2.SetTextAlignment(TextAlignment.LEFT)
                                            .Add(new Paragraph(_lkupActivityTypeRepository.GetActivityType(activity.ActivityType_Id).Activity_Name)
                                                            // .SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_1)
                                                            .SetFontSize(9))
                                            .SetBackgroundColor(cl_tablecontent_1)
                                            .SetBorderTop(Border.NO_BORDER)
                                            .SetBorderBottom(Border.NO_BORDER);


                                            cell3.SetTextAlignment(TextAlignment.LEFT)
                                            .Add(new Paragraph(period)
                                                            //.SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_1)
                                                            .SetFontSize(9))
                                            .SetBackgroundColor(cl_tablecontent_1)
                                            .SetBorderTop(Border.NO_BORDER)
                                            .SetBorderBottom(Border.NO_BORDER);



                                        cell4.SetTextAlignment(TextAlignment.RIGHT)
                                            .Add(new Paragraph(string.Format("{0:N2}", activity.ActivityCost))
                                                            //.SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_1)
                                                            .SetFontSize(9))
                                            .SetBackgroundColor(cl_tablecontent_1)
                                            .SetBorderTop(Border.NO_BORDER)
                                            .SetBorderBottom(Border.NO_BORDER);
                                    }
                                    else
                                    {
                                        //Row Rows

                                        cell1.SetTextAlignment(TextAlignment.LEFT)
                                            .Add(new Paragraph(activity.ActivityDescription)
                                                            // .SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_2)
                                                            .SetFontSize(9))
                                                .SetBackgroundColor(cl_tablecontent_2)
                                                .SetBorderTop(Border.NO_BORDER)
                                                .SetBorderBottom(Border.NO_BORDER);



                                        cell2.SetTextAlignment(TextAlignment.LEFT)
                                            .Add(new Paragraph(_lkupActivityTypeRepository.GetActivityType(activity.ActivityType_Id).Activity_Name)
                                                            //.SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_2)
                                                            .SetFontSize(9))
                                            .SetBackgroundColor(cl_tablecontent_2)
                                            .SetBorderTop(Border.NO_BORDER)
                                            .SetBorderBottom(Border.NO_BORDER);


                                        cell3.SetTextAlignment(TextAlignment.LEFT)
                                            .Add(new Paragraph(period)
                                                            // .SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_2)
                                                            .SetFontSize(9))
                                            .SetBackgroundColor(cl_tablecontent_2)
                                            .SetBorderTop(Border.NO_BORDER)
                                            .SetBorderBottom(Border.NO_BORDER);
        


                                        cell4.SetTextAlignment(TextAlignment.RIGHT)
                                            .Add(new Paragraph(string.Format("{0:N2}", activity.ActivityCost))
                                                            // .SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_2)
                                                            .SetFontSize(9))
                                            .SetBackgroundColor(cl_tablecontent_2)
                                            .SetBorderTop(Border.NO_BORDER)
                                            .SetBorderBottom(Border.NO_BORDER);
                                        

                                    }

                                    row_alt=ToggleBoolean(row_alt);
                                    if(inneriter==activitycount)
                                    {
                                        cell1.SetBorderBottom(new SolidBorder(1f));
                                        cell2.SetBorderBottom(new SolidBorder(1f));
                                        cell3.SetBorderBottom(new SolidBorder(1f));
                                        cell4.SetBorderBottom(new SolidBorder(1f));

                                    }

                                    tableactivity_spanning422.AddCell(cell1);
                                    tableactivity_spanning422.AddCell(cell2);
                                    tableactivity_spanning422.AddCell(cell3);   
                                    tableactivity_spanning422.AddCell(cell4);

                                }

                            }
                            inneriter=0;
                            row_alt=true;
                            document.Add(tableactivity_spanning422);
                        }

                        document.Add(txt);
                        document.Add(txt);

                        float indentmargin_outer423=document.GetLeftMargin()+49;
                        Table tableactivity_outer423= new Table(UnitValue.CreatePercentArray(new float[]{4, 96}), false)
                                            .SetWidth(PageSize.A4.GetWidth()-indentmargin_outer423)
                                            .SetMarginLeft(14)
                                            .SetHorizontalAlignment(HorizontalAlignment.LEFT);

                            Cell cellbullet423 = new Cell(1, 1)
                            .SetTextAlignment(TextAlignment.LEFT)
                            .Add(new Paragraph("\ue837")
                                            .SetFont(ft_materialicons_fonts)
                                            .SetFixedLeading(14f)
                                            .SetFontColor(cl_green)
                                            .SetFontSize(10))
                                .SetBorder(Border.NO_BORDER);

                            Cell celltxt423= new Cell(1, 1)
                            .SetTextAlignment(TextAlignment.JUSTIFIED)
                            .Add(new Paragraph("Activities Outside of Workplan Period")
                                            .SetFixedLeading(14f)
                                            .SetFontColor(cl_green)
                                            .SetFontSize(10))
                                .SetBorder(Border.NO_BORDER);

                        tableactivity_outer423.AddCell(cellbullet423);
                        tableactivity_outer423.AddCell(celltxt423);

                        document.Add(tableactivity_outer423);
                        document.Add(txt);

                        float indentmargin_outside423=document.GetLeftMargin()+74;
                        Table tableactivity_outside423 = new Table(UnitValue.CreatePercentArray(new float[]{35, 20, 27, 18}), false)
                            .SetWidth(PageSize.A4.GetWidth()-indentmargin_outside423)
                            .SetMarginLeft(37)
                            .SetHorizontalAlignment(HorizontalAlignment.LEFT);


                        var DB_Activities_outside423=_wpOutputActivitiesRepository.GetRecordsByMainRecordId(mainrec.Transaction_Id);

                        DateTime startperiod_outside423=new DateTime(Int32.Parse(_lkupFiscalYearRepository.GetRecord(mainrec.FiscalYear_Id).Record_Name) , 10, 1);
                        DateTime endperiod_outside423=new DateTime(Int32.Parse(_lkupFiscalYearRepository.GetRecord(mainrec.FiscalYear_Id).Record_Name) , 12, DateTime.DaysInMonth(mainrec.FiscalYear_Id, 12));

                        int actualrecords_outside423=0;
                        foreach (var activity in DB_Activities_outside423)
                        {
                            if(IsActivityOutsideWPPeriod(new DateTime(activity.ActivityStartDate.Year, activity.ActivityStartDate.Month, activity.ActivityStartDate.Day), new DateTime(activity.ActivityEndDate.Year, activity.ActivityEndDate.Month, activity.ActivityEndDate.Day), startperiod_outside423, endperiod_outside423)==true)
                                actualrecords_outside423=actualrecords_outside423+1;
                        }
                        if(actualrecords_outside423>=1)
                        {
                            //Row Header
                            Cell cellheader01 = new Cell(1, 1)
                            .SetTextAlignment(TextAlignment.LEFT)
                            .Add(new Paragraph("ACTIVITY")
                                            //.SetFont(ft_montserrat_medium)
                                            .SetFixedLeading(14f)
                                            .SetFontColor(cl_grayDark)
                                            .SetBackgroundColor(cl_tableheader)
                                            .SetFontSize(10))
                                .SetBackgroundColor(cl_tableheader);

                            tableactivity_outside423.AddCell(cellheader01);

                            Cell cellheader02 = new Cell(1, 1)
                                .SetTextAlignment(TextAlignment.LEFT)
                                .Add(new Paragraph("TYPE")
                                                // .SetFont(ft_montserrat_medium)
                                                .SetFixedLeading(14f)
                                                .SetFontColor(cl_grayDark)
                                                .SetBackgroundColor(cl_tableheader)
                                                .SetFontSize(10))
                                .SetBackgroundColor(cl_tableheader);

                            tableactivity_outside423.AddCell(cellheader02);


                            Cell cellheader03 = new Cell(1, 1)
                                .SetTextAlignment(TextAlignment.LEFT)
                                .Add(new Paragraph("PERIOD")
                                                // .SetFont(ft_montserrat_medium)
                                                .SetFixedLeading(14f)
                                                .SetFontColor(cl_grayDark)
                                                .SetBackgroundColor(cl_tableheader)
                                                .SetFontSize(10))
                                .SetBackgroundColor(cl_tableheader);
                            tableactivity_outside423.AddCell(cellheader03);

                            Cell cellheader04 = new Cell(1, 1)
                                .SetTextAlignment(TextAlignment.RIGHT)
                                .Add(new Paragraph("AMOUNT (USD)")
                                                // .SetFont(ft_montserrat_medium)
                                                .SetFixedLeading(14f)
                                                .SetFontColor(cl_grayDark)
                                                .SetBackgroundColor(cl_tableheader)
                                                .SetFontSize(10))
                                .SetBackgroundColor(cl_tableheader);

                            tableactivity_outside423.AddCell(cellheader04);

                            int activitycount=actualrecords_outside423;

                            foreach (var activity in DB_Activities_outside423)
                            {
                                if(IsActivityOutsideWPPeriod(new DateTime(activity.ActivityStartDate.Year, activity.ActivityStartDate.Month, activity.ActivityStartDate.Day), new DateTime(activity.ActivityEndDate.Year, activity.ActivityEndDate.Month, activity.ActivityEndDate.Day), startperiod_outside423, endperiod_outside423)==true)
                                {
                                    inneriter=inneriter+1;

                                    Cell cell1 = new Cell(1, 1);
                                    Cell cell2 = new Cell(1, 1);
                                    Cell cell3 = new Cell(1, 1);
                                    Cell cell4 = new Cell(1, 1);

                                    DateTime start= new  DateTime(activity.ActivityStartDate.Year, activity.ActivityStartDate.Month, activity.ActivityStartDate.Day);
                                    DateTime end= new  DateTime(activity.ActivityEndDate.Year, activity.ActivityEndDate.Month, activity.ActivityEndDate.Day);
                                    string period=start.Date.ToString("MMM. d, yyyy")+" - "+end.Date.ToString("MMM. d, yyyy");

                                    if(row_alt==false)
                                    {
                                        //Row Rows
                                        cell1.SetTextAlignment(TextAlignment.LEFT)
                                        .Add(new Paragraph(activity.ActivityDescription)
                                                        //.SetFont(ft_montserrat_reg)
                                                        .SetFixedLeading(14f)
                                                        .SetFontColor(cl_grayDark)
                                                        .SetBackgroundColor(cl_tablecontent_1)
                                                        .SetFontSize(9))
                                            .SetBackgroundColor(cl_tablecontent_1)
                                            .SetBorderTop(Border.NO_BORDER)
                                            .SetBorderBottom(Border.NO_BORDER);


                                    
                                            cell2.SetTextAlignment(TextAlignment.LEFT)
                                            .Add(new Paragraph(_lkupActivityTypeRepository.GetActivityType(activity.ActivityType_Id).Activity_Name)
                                                            //.SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_1)
                                                            .SetFontSize(9))
                                            .SetBackgroundColor(cl_tablecontent_1)
                                            .SetBorderTop(Border.NO_BORDER)
                                            .SetBorderBottom(Border.NO_BORDER);


                                            cell3.SetTextAlignment(TextAlignment.LEFT)
                                            .Add(new Paragraph(period)
                                                            //.SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_1)
                                                            .SetFontSize(9))
                                            .SetBackgroundColor(cl_tablecontent_1)
                                            .SetBorderTop(Border.NO_BORDER)
                                            .SetBorderBottom(Border.NO_BORDER);


                                        cell4.SetTextAlignment(TextAlignment.RIGHT)
                                            .Add(new Paragraph(string.Format("{0:N2}", activity.ActivityCost))
                                                            //.SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_1)
                                                            .SetFontSize(9))
                                            .SetBackgroundColor(cl_tablecontent_1)
                                            .SetBorderTop(Border.NO_BORDER)
                                            .SetBorderBottom(Border.NO_BORDER);


                                    }
                                    else
                                    {
                                        //Row Rows

                                        cell1.SetTextAlignment(TextAlignment.LEFT)
                                            .Add(new Paragraph(activity.ActivityDescription)
                                                            //.SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_2)
                                                            .SetFontSize(9))
                                                .SetBackgroundColor(cl_tablecontent_2)
                                                .SetBorderTop(Border.NO_BORDER)
                                                .SetBorderBottom(Border.NO_BORDER);



                                        cell2.SetTextAlignment(TextAlignment.LEFT)
                                            .Add(new Paragraph(_lkupActivityTypeRepository.GetActivityType(activity.ActivityType_Id).Activity_Name)
                                                            //.SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_2)
                                                            .SetFontSize(9))
                                            .SetBackgroundColor(cl_tablecontent_2)
                                            .SetBorderTop(Border.NO_BORDER)
                                            .SetBorderBottom(Border.NO_BORDER);



                                        cell3.SetTextAlignment(TextAlignment.LEFT)
                                            .Add(new Paragraph(period)
                                                            //.SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_2)
                                                            .SetFontSize(9))
                                            .SetBackgroundColor(cl_tablecontent_2)
                                            .SetBorderTop(Border.NO_BORDER)
                                            .SetBorderBottom(Border.NO_BORDER);


                                        cell4.SetTextAlignment(TextAlignment.RIGHT)
                                            .Add(new Paragraph(string.Format("{0:N2}", activity.ActivityCost))
                                                            //.SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_2)
                                                            .SetFontSize(9))
                                            .SetBackgroundColor(cl_tablecontent_2)
                                            .SetBorderTop(Border.NO_BORDER)
                                            .SetBorderBottom(Border.NO_BORDER);

                                    }

                                    row_alt=ToggleBoolean(row_alt);
                                    if(inneriter==activitycount)
                                    {
                                        cell1.SetBorderBottom(new SolidBorder(1f));
                                        cell2.SetBorderBottom(new SolidBorder(1f));
                                        cell3.SetBorderBottom(new SolidBorder(1f));
                                        cell4.SetBorderBottom(new SolidBorder(1f));

                                    }

                                    tableactivity_outside423.AddCell(cell1);
                                    tableactivity_outside423.AddCell(cell2);
                                    tableactivity_outside423.AddCell(cell3);   
                                    tableactivity_outside423.AddCell(cell4);

                                }

                            }
                            inneriter=0;
                            row_alt=true;
                            document.Add(tableactivity_outside423);

                        }
                    break;
                    case 5 :
                        int[] months_5 = { 1, 2, 3, 4, 5, 6 };
                        foreach (var i in months_5)
                        {
                            float indentmargin_outer521=document.GetLeftMargin()+49;
                            Table tableactivity_outer521 = new Table(UnitValue.CreatePercentArray(new float[]{4, 96}), false)
                                                .SetWidth(PageSize.A4.GetWidth()-indentmargin_outer521)
                                                .SetMarginLeft(14)
                                                .SetHorizontalAlignment(HorizontalAlignment.LEFT);

                                Cell cellbullet521 = new Cell(1, 1)
                                .SetTextAlignment(TextAlignment.LEFT)
                                .Add(new Paragraph("\ue837")
                                                .SetFont(ft_materialicons_fonts)
                                                .SetFixedLeading(14f)
                                                .SetFontColor(cl_green)
                                                .SetFontSize(10))
                                    .SetBorder(Border.NO_BORDER);

                                Cell celltxt521= new Cell(1, 1)
                                .SetTextAlignment(TextAlignment.JUSTIFIED)
                                .Add(new Paragraph(System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i))
                                                .SetFixedLeading(14f)
                                                .SetFontColor(cl_green)
                                                .SetFontSize(10))
                                    .SetBorder(Border.NO_BORDER);

                            tableactivity_outer521.AddCell(cellbullet521);
                            tableactivity_outer521.AddCell(celltxt521);

                            document.Add(tableactivity_outer521);
                            document.Add(txt);

                            float indentmargin521=document.GetLeftMargin()+74;
                            float tablewidth521=PageSize.A4.GetWidth()-indentmargin521;
                            Table tableactivity_521 = new Table(UnitValue.CreatePercentArray(new float[]{35, 20, 27, 18}), false)
                                .SetWidth(PageSize.A4.GetWidth()-indentmargin521)
                                .SetMarginLeft(37)
                                .SetHorizontalAlignment(HorizontalAlignment.LEFT);


                            var DB_Activities521=_wpOutputActivitiesRepository.GetRecordsByMainRecordId(mainrec.Transaction_Id);

                            int actualrecords521=0;
                            foreach (var activity in DB_Activities521)
                            {
                                if(WithinMonth(mainrec.FiscalYear_Id, i, new DateTime(activity.ActivityStartDate.Year, activity.ActivityStartDate.Month, activity.ActivityStartDate.Day), new DateTime(activity.ActivityEndDate.Year, activity.ActivityEndDate.Month, activity.ActivityEndDate.Day))==true)
                                    actualrecords521=actualrecords521+1;
                            }

                            if(actualrecords521>=1)
                            {
                                //Row Header
                                Cell cellheader01 = new Cell(1, 1)
                                .SetTextAlignment(TextAlignment.LEFT)
                                .Add(new Paragraph("ACTIVITY")
                                                //.SetFont(ft_montserrat_medium)
                                                .SetFixedLeading(14f)
                                                .SetFontColor(cl_grayDark)
                                                .SetBackgroundColor(cl_tableheader)
                                                .SetFontSize(10))
                                    .SetBackgroundColor(cl_tableheader);

                                tableactivity_521.AddCell(cellheader01);

                                Cell cellheader02 = new Cell(1, 1)
                                    .SetTextAlignment(TextAlignment.LEFT)
                                    .Add(new Paragraph("TYPE")
                                                // .SetFont(ft_montserrat_medium)
                                                    .SetFixedLeading(14f)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tableheader)
                                                    .SetFontSize(10))
                                    .SetBackgroundColor(cl_tableheader);

                                tableactivity_521.AddCell(cellheader02);


                                Cell cellheader03 = new Cell(1, 1)
                                    .SetTextAlignment(TextAlignment.LEFT)
                                    .Add(new Paragraph("PERIOD")
                                                    .SetFont(ft_montserrat_medium)
                                                    .SetFixedLeading(14f)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tableheader)
                                                    .SetFontSize(10))
                                    .SetBackgroundColor(cl_tableheader);

                                tableactivity_521.AddCell(cellheader03);

                                Cell cellheader04 = new Cell(1, 1)
                                    .SetTextAlignment(TextAlignment.RIGHT)
                                    .Add(new Paragraph("AMOOUNT (USD)")
                                                // .SetFont(ft_montserrat_medium)
                                                    .SetFixedLeading(14f)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tableheader)
                                                    .SetFontSize(10))
                                    .SetBackgroundColor(cl_tableheader);

                                tableactivity_521.AddCell(cellheader04);

                                int activitycount=actualrecords521;

                                foreach (var activity in DB_Activities521)
                                {
                                    if(WithinMonth(mainrec.FiscalYear_Id, i, new DateTime(activity.ActivityStartDate.Year, activity.ActivityStartDate.Month, activity.ActivityStartDate.Day), new DateTime(activity.ActivityEndDate.Year, activity.ActivityEndDate.Month, activity.ActivityEndDate.Day)))
                                    {
                                        inneriter=inneriter+1;

                                        Cell cell1 = new Cell(1, 1);
                                        Cell cell2 = new Cell(1, 1);
                                        Cell cell3 = new Cell(1, 1);
                                        Cell cell4 = new Cell(1, 1);

                                        DateTime start= new  DateTime(activity.ActivityStartDate.Year, activity.ActivityStartDate.Month, activity.ActivityStartDate.Day);
                                        DateTime end= new  DateTime(activity.ActivityEndDate.Year, activity.ActivityEndDate.Month, activity.ActivityEndDate.Day);
                                        string period=start.Date.ToString("MMM. d, yyyy")+" - "+end.Date.ToString("MMM. d, yyyy");

                                        if(row_alt==false)
                                        {
                                            //Row Rows
                                            cell1.SetTextAlignment(TextAlignment.LEFT)
                                            .Add(new Paragraph(activity.ActivityDescription)
                                                        // .SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_1)
                                                            .SetFontSize(9))
                                                .SetBackgroundColor(cl_tablecontent_1)
                                                .SetBorderTop(Border.NO_BORDER)
                                                .SetBorderBottom(Border.NO_BORDER);


                                        
                                                cell2.SetTextAlignment(TextAlignment.LEFT)
                                                .Add(new Paragraph(_lkupActivityTypeRepository.GetActivityType(activity.ActivityType_Id).Activity_Name)
                                                            // .SetFont(ft_montserrat_reg)
                                                                .SetFixedLeading(14f)
                                                                .SetFontColor(cl_grayDark)
                                                                .SetBackgroundColor(cl_tablecontent_1)
                                                                .SetFontSize(9))
                                                .SetBackgroundColor(cl_tablecontent_1)
                                                .SetBorderTop(Border.NO_BORDER)
                                                .SetBorderBottom(Border.NO_BORDER);


                                                cell3.SetTextAlignment(TextAlignment.LEFT)
                                                .Add(new Paragraph(period)
                                                                //.SetFont(ft_montserrat_reg)
                                                                .SetFixedLeading(14f)
                                                                .SetFontColor(cl_grayDark)
                                                                .SetBackgroundColor(cl_tablecontent_1)
                                                                .SetFontSize(9))
                                                .SetBackgroundColor(cl_tablecontent_1)
                                                .SetBorderTop(Border.NO_BORDER)
                                                .SetBorderBottom(Border.NO_BORDER);



                                            cell4.SetTextAlignment(TextAlignment.RIGHT)
                                                .Add(new Paragraph(string.Format("{0:N2}", activity.ActivityCost))
                                                                //.SetFont(ft_montserrat_reg)
                                                                .SetFixedLeading(14f)
                                                                .SetFontColor(cl_grayDark)
                                                                .SetBackgroundColor(cl_tablecontent_1)
                                                                .SetFontSize(9))
                                                .SetBackgroundColor(cl_tablecontent_1)
                                                .SetBorderTop(Border.NO_BORDER)
                                                .SetBorderBottom(Border.NO_BORDER);


                                        }
                                        else
                                        {
                                            //Row Rows

                                            cell1.SetTextAlignment(TextAlignment.LEFT)
                                                .Add(new Paragraph(activity.ActivityDescription)
                                                                //.SetFont(ft_montserrat_reg)
                                                                .SetFixedLeading(14f)
                                                                .SetFontColor(cl_grayDark)
                                                                .SetBackgroundColor(cl_tablecontent_2)
                                                                .SetFontSize(9))
                                                    .SetBackgroundColor(cl_tablecontent_2)
                                                    .SetBorderTop(Border.NO_BORDER)
                                                    .SetBorderBottom(Border.NO_BORDER);



                                            cell2.SetTextAlignment(TextAlignment.LEFT)
                                                .Add(new Paragraph(_lkupActivityTypeRepository.GetActivityType(activity.ActivityType_Id).Activity_Name)
                                                                //.SetFont(ft_montserrat_reg)
                                                                .SetFixedLeading(14f)
                                                                .SetFontColor(cl_grayDark)
                                                                .SetBackgroundColor(cl_tablecontent_2)
                                                                .SetFontSize(9))
                                                .SetBackgroundColor(cl_tablecontent_2)
                                                .SetBorderTop(Border.NO_BORDER)
                                                .SetBorderBottom(Border.NO_BORDER);




                                            cell3.SetTextAlignment(TextAlignment.LEFT)
                                                .Add(new Paragraph(period)
                                                                //.SetFont(ft_montserrat_reg)
                                                                .SetFixedLeading(14f)
                                                                .SetFontColor(cl_grayDark)
                                                                .SetBackgroundColor(cl_tablecontent_2)
                                                                .SetFontSize(9))
                                                .SetBackgroundColor(cl_tablecontent_2)
                                                .SetBorderTop(Border.NO_BORDER)
                                                .SetBorderBottom(Border.NO_BORDER);



                                            cell4.SetTextAlignment(TextAlignment.RIGHT)
                                                .Add(new Paragraph(string.Format("{0:N2}", activity.ActivityCost))
                                                                //.SetFont(ft_montserrat_reg)
                                                                .SetFixedLeading(14f)
                                                                .SetFontColor(cl_grayDark)
                                                                .SetBackgroundColor(cl_tablecontent_2)
                                                                .SetFontSize(9))
                                                .SetBackgroundColor(cl_tablecontent_2)
                                                .SetBorderTop(Border.NO_BORDER)
                                                .SetBorderBottom(Border.NO_BORDER);
                                            

                                        }

                                        row_alt=ToggleBoolean(row_alt);
                                        if(inneriter==activitycount)
                                        {
                                            cell1.SetBorderBottom(new SolidBorder(1f));
                                            cell2.SetBorderBottom(new SolidBorder(1f));
                                            cell3.SetBorderBottom(new SolidBorder(1f));
                                            cell4.SetBorderBottom(new SolidBorder(1f));

                                        }

                                        tableactivity_521.AddCell(cell1);
                                        tableactivity_521.AddCell(cell2);
                                        tableactivity_521.AddCell(cell3);   
                                        tableactivity_521.AddCell(cell4);

                                    }

                                }

                                inneriter=0;
                                row_alt=true;
                                document.Add(tableactivity_521);

                                
                            }

                            document.Add(txt);
                            document.Add(txt);
                        }
            

                        float indentmargin_outer522=document.GetLeftMargin()+49;
                        Table tableactivity_outer522 = new Table(UnitValue.CreatePercentArray(new float[]{4, 96}), false)
                                            .SetWidth(PageSize.A4.GetWidth()-indentmargin_outer522)
                                            .SetMarginLeft(14)
                                            .SetHorizontalAlignment(HorizontalAlignment.LEFT);

                            Cell cellbullet522 = new Cell(1, 1)
                            .SetTextAlignment(TextAlignment.LEFT)
                            .Add(new Paragraph("\ue837")
                                            .SetFont(ft_materialicons_fonts)
                                            .SetFixedLeading(14f)
                                            .SetFontColor(cl_green)
                                            .SetFontSize(10))
                                .SetBorder(Border.NO_BORDER);

                            Cell celltxt522= new Cell(1, 1)
                            .SetTextAlignment(TextAlignment.JUSTIFIED)
                            .Add(new Paragraph("Activities Spanning Multiple Months")
                                            .SetFixedLeading(14f)
                                            .SetFontColor(cl_green)
                                            .SetFontSize(10))
                                .SetBorder(Border.NO_BORDER);

                        tableactivity_outer522.AddCell(cellbullet522);
                        tableactivity_outer522.AddCell(celltxt522);

                        document.Add(tableactivity_outer522);
                        document.Add(txt);

                        

                        float indentmargin_spanning522=document.GetLeftMargin()+74;
                        Table tableactivity_spanning522 = new Table(UnitValue.CreatePercentArray(new float[]{35, 20, 27, 18}), false)
                            .SetWidth(PageSize.A4.GetWidth()-indentmargin_spanning522)
                            .SetMarginLeft(37)
                            .SetHorizontalAlignment(HorizontalAlignment.LEFT);


                        var DB_Activities_spanning522=_wpOutputActivitiesRepository.GetRecordsByMainRecordId(mainrec.Transaction_Id);

                        DateTime startperiod_spanning522=new DateTime(Int32.Parse(_lkupFiscalYearRepository.GetRecord(mainrec.FiscalYear_Id).Record_Name) , 1, 1);
                        DateTime endperiod_spanning522=new DateTime(Int32.Parse(_lkupFiscalYearRepository.GetRecord(mainrec.FiscalYear_Id).Record_Name) , 6, DateTime.DaysInMonth(mainrec.FiscalYear_Id, 6));

                        int actualrecords_spanning522=0;
                        foreach (var activity in DB_Activities_spanning522)
                        {
                            if(IsActivitySpanningMultipleMonths(mainrec.FiscalYear_Id, months_5, new DateTime(activity.ActivityStartDate.Year, activity.ActivityStartDate.Month, activity.ActivityStartDate.Day), new DateTime(activity.ActivityEndDate.Year, activity.ActivityEndDate.Month, activity.ActivityEndDate.Day), startperiod_spanning522, endperiod_spanning522)==true)
                                actualrecords_spanning522=actualrecords_spanning522+1;
                        }
                        if(actualrecords_spanning522>=1)
                        {
                            //Row Header
                            Cell cellheader01 = new Cell(1, 1)
                            .SetTextAlignment(TextAlignment.LEFT)
                            .Add(new Paragraph("ACTIVITY")
                                            //.SetFont(ft_montserrat_medium)
                                            .SetFixedLeading(14f)
                                            .SetFontColor(cl_grayDark)
                                            .SetBackgroundColor(cl_tableheader)
                                            .SetFontSize(10))
                                .SetBackgroundColor(cl_tableheader);
                            tableactivity_spanning522.AddCell(cellheader01);

                            Cell cellheader02 = new Cell(1, 1)
                                .SetTextAlignment(TextAlignment.LEFT)
                                .Add(new Paragraph("TYPE")
                                                // .SetFont(ft_montserrat_medium)
                                                .SetFixedLeading(14f)
                                                .SetFontColor(cl_grayDark)
                                                .SetBackgroundColor(cl_tableheader)
                                                .SetFontSize(10))
                                .SetBackgroundColor(cl_tableheader);
                            tableactivity_spanning522.AddCell(cellheader02);


                            Cell cellheader03 = new Cell(1, 1)
                                .SetTextAlignment(TextAlignment.LEFT)
                                .Add(new Paragraph("PERIOD")
                                                //.SetFont(ft_montserrat_medium)
                                                .SetFixedLeading(14f)
                                                .SetFontColor(cl_grayDark)
                                                .SetBackgroundColor(cl_tableheader)
                                                .SetFontSize(10))
                                .SetBackgroundColor(cl_tableheader);
                            tableactivity_spanning522.AddCell(cellheader03);

                            Cell cellheader04 = new Cell(1, 1)
                                .SetTextAlignment(TextAlignment.RIGHT)
                                .Add(new Paragraph("AMOUNT (USD)")
                                                //.SetFont(ft_montserrat_medium)
                                                .SetFixedLeading(14f)
                                                .SetFontColor(cl_grayDark)
                                                .SetBackgroundColor(cl_tableheader)
                                                .SetFontSize(10))
                                .SetBackgroundColor(cl_tableheader);

                            tableactivity_spanning522.AddCell(cellheader04);

                            int activitycount=actualrecords_spanning522;

                            foreach (var activity in DB_Activities_spanning522)
                            {
                                if(IsActivitySpanningMultipleMonths(mainrec.FiscalYear_Id, months_5, new DateTime(activity.ActivityStartDate.Year, activity.ActivityStartDate.Month, activity.ActivityStartDate.Day), new DateTime(activity.ActivityEndDate.Year, activity.ActivityEndDate.Month, activity.ActivityEndDate.Day), startperiod_spanning522, endperiod_spanning522))
                                {
                                    inneriter=inneriter+1;

                                    Cell cell1 = new Cell(1, 1);
                                    Cell cell2 = new Cell(1, 1);
                                    Cell cell3 = new Cell(1, 1);
                                    Cell cell4 = new Cell(1, 1);

                                    DateTime start= new  DateTime(activity.ActivityStartDate.Year, activity.ActivityStartDate.Month, activity.ActivityStartDate.Day);
                                    DateTime end= new  DateTime(activity.ActivityEndDate.Year, activity.ActivityEndDate.Month, activity.ActivityEndDate.Day);
                                    string period=start.Date.ToString("MMM. d, yyyy")+" - "+end.Date.ToString("MMM. d, yyyy");

                                    if(row_alt==false)
                                    {
                                        //Row Rows
                                        cell1.SetTextAlignment(TextAlignment.LEFT)
                                        .Add(new Paragraph(activity.ActivityDescription)
                                                        // .SetFont(ft_montserrat_reg)
                                                        .SetFixedLeading(14f)
                                                        .SetFontColor(cl_grayDark)
                                                        .SetBackgroundColor(cl_tablecontent_1)
                                                        .SetFontSize(9))
                                            .SetBackgroundColor(cl_tablecontent_1)
                                            .SetBorderTop(Border.NO_BORDER)
                                            .SetBorderBottom(Border.NO_BORDER);


                                    
                                            cell2.SetTextAlignment(TextAlignment.LEFT)
                                            .Add(new Paragraph(_lkupActivityTypeRepository.GetActivityType(activity.ActivityType_Id).Activity_Name)
                                                            // .SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_1)
                                                            .SetFontSize(9))
                                            .SetBackgroundColor(cl_tablecontent_1)
                                            .SetBorderTop(Border.NO_BORDER)
                                            .SetBorderBottom(Border.NO_BORDER);


                                            cell3.SetTextAlignment(TextAlignment.LEFT)
                                            .Add(new Paragraph(period)
                                                            //.SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_1)
                                                            .SetFontSize(9))
                                            .SetBackgroundColor(cl_tablecontent_1)
                                            .SetBorderTop(Border.NO_BORDER)
                                            .SetBorderBottom(Border.NO_BORDER);



                                        cell4.SetTextAlignment(TextAlignment.RIGHT)
                                            .Add(new Paragraph(string.Format("{0:N2}", activity.ActivityCost))
                                                            //.SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_1)
                                                            .SetFontSize(9))
                                            .SetBackgroundColor(cl_tablecontent_1)
                                            .SetBorderTop(Border.NO_BORDER)
                                            .SetBorderBottom(Border.NO_BORDER);
                                    }
                                    else
                                    {
                                        //Row Rows

                                        cell1.SetTextAlignment(TextAlignment.LEFT)
                                            .Add(new Paragraph(activity.ActivityDescription)
                                                            // .SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_2)
                                                            .SetFontSize(9))
                                                .SetBackgroundColor(cl_tablecontent_2)
                                                .SetBorderTop(Border.NO_BORDER)
                                                .SetBorderBottom(Border.NO_BORDER);



                                        cell2.SetTextAlignment(TextAlignment.LEFT)
                                            .Add(new Paragraph(_lkupActivityTypeRepository.GetActivityType(activity.ActivityType_Id).Activity_Name)
                                                            //.SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_2)
                                                            .SetFontSize(9))
                                            .SetBackgroundColor(cl_tablecontent_2)
                                            .SetBorderTop(Border.NO_BORDER)
                                            .SetBorderBottom(Border.NO_BORDER);


                                        cell3.SetTextAlignment(TextAlignment.LEFT)
                                            .Add(new Paragraph(period)
                                                            // .SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_2)
                                                            .SetFontSize(9))
                                            .SetBackgroundColor(cl_tablecontent_2)
                                            .SetBorderTop(Border.NO_BORDER)
                                            .SetBorderBottom(Border.NO_BORDER);
        


                                        cell4.SetTextAlignment(TextAlignment.RIGHT)
                                            .Add(new Paragraph(string.Format("{0:N2}", activity.ActivityCost))
                                                            // .SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_2)
                                                            .SetFontSize(9))
                                            .SetBackgroundColor(cl_tablecontent_2)
                                            .SetBorderTop(Border.NO_BORDER)
                                            .SetBorderBottom(Border.NO_BORDER);
                                        

                                    }

                                    row_alt=ToggleBoolean(row_alt);
                                    if(inneriter==activitycount)
                                    {
                                        cell1.SetBorderBottom(new SolidBorder(1f));
                                        cell2.SetBorderBottom(new SolidBorder(1f));
                                        cell3.SetBorderBottom(new SolidBorder(1f));
                                        cell4.SetBorderBottom(new SolidBorder(1f));

                                    }

                                    tableactivity_spanning522.AddCell(cell1);
                                    tableactivity_spanning522.AddCell(cell2);
                                    tableactivity_spanning522.AddCell(cell3);   
                                    tableactivity_spanning522.AddCell(cell4);

                                }

                            }
                            inneriter=0;
                            row_alt=true;
                            document.Add(tableactivity_spanning522);
                        }

                        document.Add(txt);
                        document.Add(txt);

                        float indentmargin_outer523=document.GetLeftMargin()+49;
                        Table tableactivity_outer523= new Table(UnitValue.CreatePercentArray(new float[]{4, 96}), false)
                                            .SetWidth(PageSize.A4.GetWidth()-indentmargin_outer523)
                                            .SetMarginLeft(14)
                                            .SetHorizontalAlignment(HorizontalAlignment.LEFT);

                            Cell cellbullet523 = new Cell(1, 1)
                            .SetTextAlignment(TextAlignment.LEFT)
                            .Add(new Paragraph("\ue837")
                                            .SetFont(ft_materialicons_fonts)
                                            .SetFixedLeading(14f)
                                            .SetFontColor(cl_green)
                                            .SetFontSize(10))
                                .SetBorder(Border.NO_BORDER);

                            Cell celltxt523= new Cell(1, 1)
                            .SetTextAlignment(TextAlignment.JUSTIFIED)
                            .Add(new Paragraph("Activities Outside of Workplan Period")
                                            .SetFixedLeading(14f)
                                            .SetFontColor(cl_green)
                                            .SetFontSize(10))
                                .SetBorder(Border.NO_BORDER);

                        tableactivity_outer523.AddCell(cellbullet523);
                        tableactivity_outer523.AddCell(celltxt523);

                        document.Add(tableactivity_outer523);
                        document.Add(txt);

                        float indentmargin_outside523=document.GetLeftMargin()+74;
                        Table tableactivity_outside523 = new Table(UnitValue.CreatePercentArray(new float[]{35, 20, 27, 18}), false)
                            .SetWidth(PageSize.A4.GetWidth()-indentmargin_outside523)
                            .SetMarginLeft(37)
                            .SetHorizontalAlignment(HorizontalAlignment.LEFT);


                        var DB_Activities_outside523=_wpOutputActivitiesRepository.GetRecordsByMainRecordId(mainrec.Transaction_Id);

                        DateTime startperiod_outside523=new DateTime(Int32.Parse(_lkupFiscalYearRepository.GetRecord(mainrec.FiscalYear_Id).Record_Name) , 1, 1);
                        DateTime endperiod_outside523=new DateTime(Int32.Parse(_lkupFiscalYearRepository.GetRecord(mainrec.FiscalYear_Id).Record_Name) , 6, DateTime.DaysInMonth(mainrec.FiscalYear_Id, 6));

                        int actualrecords_outside523=0;
                        foreach (var activity in DB_Activities_outside523)
                        {
                            if(IsActivityOutsideWPPeriod(new DateTime(activity.ActivityStartDate.Year, activity.ActivityStartDate.Month, activity.ActivityStartDate.Day), new DateTime(activity.ActivityEndDate.Year, activity.ActivityEndDate.Month, activity.ActivityEndDate.Day), startperiod_outside523, endperiod_outside523)==true)
                                actualrecords_outside523=actualrecords_outside523+1;
                        }
                        if(actualrecords_outside523>=1)
                        {
                            //Row Header
                            Cell cellheader01 = new Cell(1, 1)
                            .SetTextAlignment(TextAlignment.LEFT)
                            .Add(new Paragraph("ACTIVITY")
                                            //.SetFont(ft_montserrat_medium)
                                            .SetFixedLeading(14f)
                                            .SetFontColor(cl_grayDark)
                                            .SetBackgroundColor(cl_tableheader)
                                            .SetFontSize(10))
                                .SetBackgroundColor(cl_tableheader);

                            tableactivity_outside523.AddCell(cellheader01);

                            Cell cellheader02 = new Cell(1, 1)
                                .SetTextAlignment(TextAlignment.LEFT)
                                .Add(new Paragraph("TYPE")
                                                // .SetFont(ft_montserrat_medium)
                                                .SetFixedLeading(14f)
                                                .SetFontColor(cl_grayDark)
                                                .SetBackgroundColor(cl_tableheader)
                                                .SetFontSize(10))
                                .SetBackgroundColor(cl_tableheader);

                            tableactivity_outside523.AddCell(cellheader02);


                            Cell cellheader03 = new Cell(1, 1)
                                .SetTextAlignment(TextAlignment.LEFT)
                                .Add(new Paragraph("PERIOD")
                                                // .SetFont(ft_montserrat_medium)
                                                .SetFixedLeading(14f)
                                                .SetFontColor(cl_grayDark)
                                                .SetBackgroundColor(cl_tableheader)
                                                .SetFontSize(10))
                                .SetBackgroundColor(cl_tableheader);
                            tableactivity_outside523.AddCell(cellheader03);

                            Cell cellheader04 = new Cell(1, 1)
                                .SetTextAlignment(TextAlignment.RIGHT)
                                .Add(new Paragraph("AMOUNT (USD)")
                                                // .SetFont(ft_montserrat_medium)
                                                .SetFixedLeading(14f)
                                                .SetFontColor(cl_grayDark)
                                                .SetBackgroundColor(cl_tableheader)
                                                .SetFontSize(10))
                                .SetBackgroundColor(cl_tableheader);

                            tableactivity_outside523.AddCell(cellheader04);

                            int activitycount=actualrecords_outside523;

                            foreach (var activity in DB_Activities_outside523)
                            {
                                if(IsActivityOutsideWPPeriod(new DateTime(activity.ActivityStartDate.Year, activity.ActivityStartDate.Month, activity.ActivityStartDate.Day), new DateTime(activity.ActivityEndDate.Year, activity.ActivityEndDate.Month, activity.ActivityEndDate.Day), startperiod_outside523, endperiod_outside523)==true)
                                {
                                    inneriter=inneriter+1;

                                    Cell cell1 = new Cell(1, 1);
                                    Cell cell2 = new Cell(1, 1);
                                    Cell cell3 = new Cell(1, 1);
                                    Cell cell4 = new Cell(1, 1);

                                    DateTime start= new  DateTime(activity.ActivityStartDate.Year, activity.ActivityStartDate.Month, activity.ActivityStartDate.Day);
                                    DateTime end= new  DateTime(activity.ActivityEndDate.Year, activity.ActivityEndDate.Month, activity.ActivityEndDate.Day);
                                    string period=start.Date.ToString("MMM. d, yyyy")+" - "+end.Date.ToString("MMM. d, yyyy");

                                    if(row_alt==false)
                                    {
                                        //Row Rows
                                        cell1.SetTextAlignment(TextAlignment.LEFT)
                                        .Add(new Paragraph(activity.ActivityDescription)
                                                        //.SetFont(ft_montserrat_reg)
                                                        .SetFixedLeading(14f)
                                                        .SetFontColor(cl_grayDark)
                                                        .SetBackgroundColor(cl_tablecontent_1)
                                                        .SetFontSize(9))
                                            .SetBackgroundColor(cl_tablecontent_1)
                                            .SetBorderTop(Border.NO_BORDER)
                                            .SetBorderBottom(Border.NO_BORDER);


                                    
                                            cell2.SetTextAlignment(TextAlignment.LEFT)
                                            .Add(new Paragraph(_lkupActivityTypeRepository.GetActivityType(activity.ActivityType_Id).Activity_Name)
                                                            //.SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_1)
                                                            .SetFontSize(9))
                                            .SetBackgroundColor(cl_tablecontent_1)
                                            .SetBorderTop(Border.NO_BORDER)
                                            .SetBorderBottom(Border.NO_BORDER);


                                            cell3.SetTextAlignment(TextAlignment.LEFT)
                                            .Add(new Paragraph(period)
                                                            //.SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_1)
                                                            .SetFontSize(9))
                                            .SetBackgroundColor(cl_tablecontent_1)
                                            .SetBorderTop(Border.NO_BORDER)
                                            .SetBorderBottom(Border.NO_BORDER);


                                        cell4.SetTextAlignment(TextAlignment.RIGHT)
                                            .Add(new Paragraph(string.Format("{0:N2}", activity.ActivityCost))
                                                            //.SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_1)
                                                            .SetFontSize(9))
                                            .SetBackgroundColor(cl_tablecontent_1)
                                            .SetBorderTop(Border.NO_BORDER)
                                            .SetBorderBottom(Border.NO_BORDER);


                                    }
                                    else
                                    {
                                        //Row Rows

                                        cell1.SetTextAlignment(TextAlignment.LEFT)
                                            .Add(new Paragraph(activity.ActivityDescription)
                                                            //.SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_2)
                                                            .SetFontSize(9))
                                                .SetBackgroundColor(cl_tablecontent_2)
                                                .SetBorderTop(Border.NO_BORDER)
                                                .SetBorderBottom(Border.NO_BORDER);



                                        cell2.SetTextAlignment(TextAlignment.LEFT)
                                            .Add(new Paragraph(_lkupActivityTypeRepository.GetActivityType(activity.ActivityType_Id).Activity_Name)
                                                            //.SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_2)
                                                            .SetFontSize(9))
                                            .SetBackgroundColor(cl_tablecontent_2)
                                            .SetBorderTop(Border.NO_BORDER)
                                            .SetBorderBottom(Border.NO_BORDER);



                                        cell3.SetTextAlignment(TextAlignment.LEFT)
                                            .Add(new Paragraph(period)
                                                            //.SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_2)
                                                            .SetFontSize(9))
                                            .SetBackgroundColor(cl_tablecontent_2)
                                            .SetBorderTop(Border.NO_BORDER)
                                            .SetBorderBottom(Border.NO_BORDER);


                                        cell4.SetTextAlignment(TextAlignment.RIGHT)
                                            .Add(new Paragraph(string.Format("{0:N2}", activity.ActivityCost))
                                                            //.SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_2)
                                                            .SetFontSize(9))
                                            .SetBackgroundColor(cl_tablecontent_2)
                                            .SetBorderTop(Border.NO_BORDER)
                                            .SetBorderBottom(Border.NO_BORDER);

                                    }

                                    row_alt=ToggleBoolean(row_alt);
                                    if(inneriter==activitycount)
                                    {
                                        cell1.SetBorderBottom(new SolidBorder(1f));
                                        cell2.SetBorderBottom(new SolidBorder(1f));
                                        cell3.SetBorderBottom(new SolidBorder(1f));
                                        cell4.SetBorderBottom(new SolidBorder(1f));

                                    }

                                    tableactivity_outside523.AddCell(cell1);
                                    tableactivity_outside523.AddCell(cell2);
                                    tableactivity_outside523.AddCell(cell3);   
                                    tableactivity_outside523.AddCell(cell4);

                                }

                            }
                            inneriter=0;
                            row_alt=true;
                            document.Add(tableactivity_outside523);

                        }
                    break;
                    case 6 :
                        int[] months_6 = { 6, 7, 8, 9, 10, 11, 12 };

                        foreach (var i in months_6)
                        {
                            float indentmargin_outer=document.GetLeftMargin()+49;
                            Table tableactivity_outer = new Table(UnitValue.CreatePercentArray(new float[]{4, 96}), false)
                                                .SetWidth(PageSize.A4.GetWidth()-indentmargin_outer)
                                                .SetMarginLeft(14)
                                                .SetHorizontalAlignment(HorizontalAlignment.LEFT);

                                Cell cellbullet = new Cell(1, 1)
                                .SetTextAlignment(TextAlignment.LEFT)
                                .Add(new Paragraph("\ue837")
                                                .SetFont(ft_materialicons_fonts)
                                                .SetFixedLeading(14f)
                                                .SetFontColor(cl_green)
                                                .SetFontSize(10))
                                    .SetBorder(Border.NO_BORDER);

                                Cell celltxt= new Cell(1, 1)
                                .SetTextAlignment(TextAlignment.JUSTIFIED)
                                .Add(new Paragraph(System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i))
                                                .SetFixedLeading(14f)
                                                .SetFontColor(cl_green)
                                                .SetFontSize(10))
                                    .SetBorder(Border.NO_BORDER);

                            tableactivity_outer.AddCell(cellbullet);
                            tableactivity_outer.AddCell(celltxt);

                            document.Add(tableactivity_outer);
                            document.Add(txt);

                            float indentmargin=document.GetLeftMargin()+74;
                            float tablewidth=PageSize.A4.GetWidth()-indentmargin;
                            Table tableactivity_6 = new Table(UnitValue.CreatePercentArray(new float[]{35, 20, 27, 18}), false)
                                .SetWidth(PageSize.A4.GetWidth()-indentmargin)
                                .SetMarginLeft(37)
                                .SetHorizontalAlignment(HorizontalAlignment.LEFT);


                            var DB_Activities=_wpOutputActivitiesRepository.GetRecordsByMainRecordId(mainrec.Transaction_Id);

                            int actualrecords=0;
                            foreach (var activity in DB_Activities)
                            {
                                if(WithinMonth(mainrec.FiscalYear_Id, i, new DateTime(activity.ActivityStartDate.Year, activity.ActivityStartDate.Month, activity.ActivityStartDate.Day), new DateTime(activity.ActivityEndDate.Year, activity.ActivityEndDate.Month, activity.ActivityEndDate.Day))==true)
                                    actualrecords=actualrecords+1;
                            }

                            if(actualrecords>=1)
                            {
                                //Row Header
                                Cell cellheader01 = new Cell(1, 1)
                                .SetTextAlignment(TextAlignment.LEFT)
                                .Add(new Paragraph("ACTIVITY")
                                                //.SetFont(ft_montserrat_medium)
                                                .SetFixedLeading(14f)
                                                .SetFontColor(cl_grayDark)
                                                .SetBackgroundColor(cl_tableheader)
                                                .SetFontSize(10))
                                    .SetBackgroundColor(cl_tableheader);

                                tableactivity_6.AddCell(cellheader01);

                                Cell cellheader02 = new Cell(1, 1)
                                    .SetTextAlignment(TextAlignment.LEFT)
                                    .Add(new Paragraph("TYPE")
                                                   // .SetFont(ft_montserrat_medium)
                                                    .SetFixedLeading(14f)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tableheader)
                                                    .SetFontSize(10))
                                    .SetBackgroundColor(cl_tableheader);

                                tableactivity_6.AddCell(cellheader02);


                                Cell cellheader03 = new Cell(1, 1)
                                    .SetTextAlignment(TextAlignment.LEFT)
                                    .Add(new Paragraph("PERIOD")
                                                    .SetFont(ft_montserrat_medium)
                                                    .SetFixedLeading(14f)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tableheader)
                                                    .SetFontSize(10))
                                    .SetBackgroundColor(cl_tableheader);
  
                                tableactivity_6.AddCell(cellheader03);

                                Cell cellheader04 = new Cell(1, 1)
                                    .SetTextAlignment(TextAlignment.RIGHT)
                                    .Add(new Paragraph("AMOOUNT (USD)")
                                                   // .SetFont(ft_montserrat_medium)
                                                    .SetFixedLeading(14f)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tableheader)
                                                    .SetFontSize(10))
                                    .SetBackgroundColor(cl_tableheader);

                                tableactivity_6.AddCell(cellheader04);

                                int activitycount=actualrecords;

                                foreach (var activity in DB_Activities)
                                {
                                    if(WithinMonth(mainrec.FiscalYear_Id, i, new DateTime(activity.ActivityStartDate.Year, activity.ActivityStartDate.Month, activity.ActivityStartDate.Day), new DateTime(activity.ActivityEndDate.Year, activity.ActivityEndDate.Month, activity.ActivityEndDate.Day)))
                                    {
                                        inneriter=inneriter+1;

                                        Cell cell1 = new Cell(1, 1);
                                        Cell cell2 = new Cell(1, 1);
                                        Cell cell3 = new Cell(1, 1);
                                        Cell cell4 = new Cell(1, 1);

                                        DateTime start= new  DateTime(activity.ActivityStartDate.Year, activity.ActivityStartDate.Month, activity.ActivityStartDate.Day);
                                        DateTime end= new  DateTime(activity.ActivityEndDate.Year, activity.ActivityEndDate.Month, activity.ActivityEndDate.Day);
                                        string period=start.Date.ToString("MMM. d, yyyy")+" - "+end.Date.ToString("MMM. d, yyyy");

                                        if(row_alt==false)
                                        {
                                            //Row Rows
                                            cell1.SetTextAlignment(TextAlignment.LEFT)
                                            .Add(new Paragraph(activity.ActivityDescription)
                                                           // .SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_1)
                                                            .SetFontSize(9))
                                                .SetBackgroundColor(cl_tablecontent_1)
                                                .SetBorderTop(Border.NO_BORDER)
                                                .SetBorderBottom(Border.NO_BORDER);


                                        
                                                cell2.SetTextAlignment(TextAlignment.LEFT)
                                                .Add(new Paragraph(_lkupActivityTypeRepository.GetActivityType(activity.ActivityType_Id).Activity_Name)
                                                               // .SetFont(ft_montserrat_reg)
                                                                .SetFixedLeading(14f)
                                                                .SetFontColor(cl_grayDark)
                                                                .SetBackgroundColor(cl_tablecontent_1)
                                                                .SetFontSize(9))
                                                .SetBackgroundColor(cl_tablecontent_1)
                                                .SetBorderTop(Border.NO_BORDER)
                                                .SetBorderBottom(Border.NO_BORDER);
 

                                                cell3.SetTextAlignment(TextAlignment.LEFT)
                                                .Add(new Paragraph(period)
                                                                //.SetFont(ft_montserrat_reg)
                                                                .SetFixedLeading(14f)
                                                                .SetFontColor(cl_grayDark)
                                                                .SetBackgroundColor(cl_tablecontent_1)
                                                                .SetFontSize(9))
                                                .SetBackgroundColor(cl_tablecontent_1)
                                                .SetBorderTop(Border.NO_BORDER)
                                                .SetBorderBottom(Border.NO_BORDER);



                                            cell4.SetTextAlignment(TextAlignment.RIGHT)
                                                .Add(new Paragraph(string.Format("{0:N2}", activity.ActivityCost))
                                                                //.SetFont(ft_montserrat_reg)
                                                                .SetFixedLeading(14f)
                                                                .SetFontColor(cl_grayDark)
                                                                .SetBackgroundColor(cl_tablecontent_1)
                                                                .SetFontSize(9))
                                                .SetBackgroundColor(cl_tablecontent_1)
                                                .SetBorderTop(Border.NO_BORDER)
                                                .SetBorderBottom(Border.NO_BORDER);


                                        }
                                        else
                                        {
                                            //Row Rows

                                            cell1.SetTextAlignment(TextAlignment.LEFT)
                                                .Add(new Paragraph(activity.ActivityDescription)
                                                                //.SetFont(ft_montserrat_reg)
                                                                .SetFixedLeading(14f)
                                                                .SetFontColor(cl_grayDark)
                                                                .SetBackgroundColor(cl_tablecontent_2)
                                                                .SetFontSize(9))
                                                    .SetBackgroundColor(cl_tablecontent_2)
                                                    .SetBorderTop(Border.NO_BORDER)
                                                    .SetBorderBottom(Border.NO_BORDER);



                                            cell2.SetTextAlignment(TextAlignment.LEFT)
                                                .Add(new Paragraph(_lkupActivityTypeRepository.GetActivityType(activity.ActivityType_Id).Activity_Name)
                                                                //.SetFont(ft_montserrat_reg)
                                                                .SetFixedLeading(14f)
                                                                .SetFontColor(cl_grayDark)
                                                                .SetBackgroundColor(cl_tablecontent_2)
                                                                .SetFontSize(9))
                                                .SetBackgroundColor(cl_tablecontent_2)
                                                .SetBorderTop(Border.NO_BORDER)
                                                .SetBorderBottom(Border.NO_BORDER);
                



                                            cell3.SetTextAlignment(TextAlignment.LEFT)
                                                .Add(new Paragraph(period)
                                                                //.SetFont(ft_montserrat_reg)
                                                                .SetFixedLeading(14f)
                                                                .SetFontColor(cl_grayDark)
                                                                .SetBackgroundColor(cl_tablecontent_2)
                                                                .SetFontSize(9))
                                                .SetBackgroundColor(cl_tablecontent_2)
                                                .SetBorderTop(Border.NO_BORDER)
                                                .SetBorderBottom(Border.NO_BORDER);
            


                                            cell4.SetTextAlignment(TextAlignment.RIGHT)
                                                .Add(new Paragraph(string.Format("{0:N2}", activity.ActivityCost))
                                                                //.SetFont(ft_montserrat_reg)
                                                                .SetFixedLeading(14f)
                                                                .SetFontColor(cl_grayDark)
                                                                .SetBackgroundColor(cl_tablecontent_2)
                                                                .SetFontSize(9))
                                                .SetBackgroundColor(cl_tablecontent_2)
                                                .SetBorderTop(Border.NO_BORDER)
                                                .SetBorderBottom(Border.NO_BORDER);
                                            

                                        }

                                        row_alt=ToggleBoolean(row_alt);
                                        if(inneriter==activitycount)
                                        {
                                            cell1.SetBorderBottom(new SolidBorder(1f));
                                            cell2.SetBorderBottom(new SolidBorder(1f));
                                            cell3.SetBorderBottom(new SolidBorder(1f));
                                            cell4.SetBorderBottom(new SolidBorder(1f));

                                        }

                                        tableactivity_6.AddCell(cell1);
                                        tableactivity_6.AddCell(cell2);
                                        tableactivity_6.AddCell(cell3);   
                                        tableactivity_6.AddCell(cell4);

                                    }

                                }

                                inneriter=0;
                                row_alt=true;
                                document.Add(tableactivity_6);

                                
                            }
                            else
                            {
                               /* Paragraph outputtextnoact = new Paragraph("No Activity Recorded")
                                .SetTextAlignment(TextAlignment.LEFT)
                                .SetFont(ft_montserrat_reg)
                                .SetFixedLeading(9f)
                                .SetFontColor(cl_grayDark)
                                .SetMarginLeft(37)
                                .SetFontSize(9);
                                document.Add(outputtextnoact);*/

                            }

                            document.Add(txt);
                            document.Add(txt);

                        }

                            float indentmargin_outer1=document.GetLeftMargin()+49;
                            Table tableactivity_outer1 = new Table(UnitValue.CreatePercentArray(new float[]{4, 96}), false)
                                                .SetWidth(PageSize.A4.GetWidth()-indentmargin_outer1)
                                                .SetMarginLeft(14)
                                                .SetHorizontalAlignment(HorizontalAlignment.LEFT);

                                Cell cellbullet1 = new Cell(1, 1)
                                .SetTextAlignment(TextAlignment.LEFT)
                                .Add(new Paragraph("\ue837")
                                                .SetFont(ft_materialicons_fonts)
                                                .SetFixedLeading(14f)
                                                .SetFontColor(cl_green)
                                                .SetFontSize(10))
                                    .SetBorder(Border.NO_BORDER);

                                Cell celltxt1= new Cell(1, 1)
                                .SetTextAlignment(TextAlignment.JUSTIFIED)
                                .Add(new Paragraph("Activities Spanning Multiple Months")
                                                .SetFixedLeading(14f)
                                                .SetFontColor(cl_green)
                                                .SetFontSize(10))
                                    .SetBorder(Border.NO_BORDER);

                            tableactivity_outer1.AddCell(cellbullet1);
                            tableactivity_outer1.AddCell(celltxt1);

                            document.Add(tableactivity_outer1);
                            document.Add(txt);

                            

                            float indentmargin_spanning=document.GetLeftMargin()+74;
                            Table tableactivity_spanning = new Table(UnitValue.CreatePercentArray(new float[]{35, 20, 27, 18}), false)
                                .SetWidth(PageSize.A4.GetWidth()-indentmargin_spanning)
                                .SetMarginLeft(37)
                                .SetHorizontalAlignment(HorizontalAlignment.LEFT);


                            var DB_Activities_spanning=_wpOutputActivitiesRepository.GetRecordsByMainRecordId(mainrec.Transaction_Id);

                            DateTime startperiod_spanning=new DateTime(Int32.Parse(_lkupFiscalYearRepository.GetRecord(mainrec.FiscalYear_Id).Record_Name) , 6, 1);
                            DateTime endperiod_spanning=new DateTime(Int32.Parse(_lkupFiscalYearRepository.GetRecord(mainrec.FiscalYear_Id).Record_Name) , 12, DateTime.DaysInMonth(mainrec.FiscalYear_Id, 12));

                            int actualrecords_spanning=0;
                            foreach (var activity in DB_Activities_spanning)
                            {
                                if(IsActivitySpanningMultipleMonths(mainrec.FiscalYear_Id, months_6, new DateTime(activity.ActivityStartDate.Year, activity.ActivityStartDate.Month, activity.ActivityStartDate.Day), new DateTime(activity.ActivityEndDate.Year, activity.ActivityEndDate.Month, activity.ActivityEndDate.Day), startperiod_spanning, endperiod_spanning)==true)
                                    actualrecords_spanning=actualrecords_spanning+1;
                            }
                            if(actualrecords_spanning>=1)
                            {
                                //Row Header
                                Cell cellheader01 = new Cell(1, 1)
                                .SetTextAlignment(TextAlignment.LEFT)
                                .Add(new Paragraph("ACTIVITY")
                                                //.SetFont(ft_montserrat_medium)
                                                .SetFixedLeading(14f)
                                                .SetFontColor(cl_grayDark)
                                                .SetBackgroundColor(cl_tableheader)
                                                .SetFontSize(10))
                                    .SetBackgroundColor(cl_tableheader);
                                tableactivity_spanning.AddCell(cellheader01);

                                Cell cellheader02 = new Cell(1, 1)
                                    .SetTextAlignment(TextAlignment.LEFT)
                                    .Add(new Paragraph("TYPE")
                                                   // .SetFont(ft_montserrat_medium)
                                                    .SetFixedLeading(14f)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tableheader)
                                                    .SetFontSize(10))
                                    .SetBackgroundColor(cl_tableheader);
                                tableactivity_spanning.AddCell(cellheader02);


                                Cell cellheader03 = new Cell(1, 1)
                                    .SetTextAlignment(TextAlignment.LEFT)
                                    .Add(new Paragraph("PERIOD")
                                                    //.SetFont(ft_montserrat_medium)
                                                    .SetFixedLeading(14f)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tableheader)
                                                    .SetFontSize(10))
                                    .SetBackgroundColor(cl_tableheader);
                                tableactivity_spanning.AddCell(cellheader03);

                                Cell cellheader04 = new Cell(1, 1)
                                    .SetTextAlignment(TextAlignment.RIGHT)
                                    .Add(new Paragraph("AMOUNT (USD)")
                                                    //.SetFont(ft_montserrat_medium)
                                                    .SetFixedLeading(14f)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tableheader)
                                                    .SetFontSize(10))
                                    .SetBackgroundColor(cl_tableheader);

                                tableactivity_spanning.AddCell(cellheader04);

                                int activitycount=actualrecords_spanning;

                                foreach (var activity in DB_Activities_spanning)
                                {
                                    if(IsActivitySpanningMultipleMonths(mainrec.FiscalYear_Id, months_6, new DateTime(activity.ActivityStartDate.Year, activity.ActivityStartDate.Month, activity.ActivityStartDate.Day), new DateTime(activity.ActivityEndDate.Year, activity.ActivityEndDate.Month, activity.ActivityEndDate.Day), startperiod_spanning, endperiod_spanning))
                                    {
                                        inneriter=inneriter+1;

                                        Cell cell1 = new Cell(1, 1);
                                        Cell cell2 = new Cell(1, 1);
                                        Cell cell3 = new Cell(1, 1);
                                        Cell cell4 = new Cell(1, 1);

                                        DateTime start= new  DateTime(activity.ActivityStartDate.Year, activity.ActivityStartDate.Month, activity.ActivityStartDate.Day);
                                        DateTime end= new  DateTime(activity.ActivityEndDate.Year, activity.ActivityEndDate.Month, activity.ActivityEndDate.Day);
                                        string period=start.Date.ToString("MMM. d, yyyy")+" - "+end.Date.ToString("MMM. d, yyyy");

                                        if(row_alt==false)
                                        {
                                            //Row Rows
                                            cell1.SetTextAlignment(TextAlignment.LEFT)
                                            .Add(new Paragraph(activity.ActivityDescription)
                                                           // .SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_1)
                                                            .SetFontSize(9))
                                                .SetBackgroundColor(cl_tablecontent_1)
                                                .SetBorderTop(Border.NO_BORDER)
                                                .SetBorderBottom(Border.NO_BORDER);


                                        
                                                cell2.SetTextAlignment(TextAlignment.LEFT)
                                                .Add(new Paragraph(_lkupActivityTypeRepository.GetActivityType(activity.ActivityType_Id).Activity_Name)
                                                               // .SetFont(ft_montserrat_reg)
                                                                .SetFixedLeading(14f)
                                                                .SetFontColor(cl_grayDark)
                                                                .SetBackgroundColor(cl_tablecontent_1)
                                                                .SetFontSize(9))
                                                .SetBackgroundColor(cl_tablecontent_1)
                                                .SetBorderTop(Border.NO_BORDER)
                                                .SetBorderBottom(Border.NO_BORDER);


                                                cell3.SetTextAlignment(TextAlignment.LEFT)
                                                .Add(new Paragraph(period)
                                                                //.SetFont(ft_montserrat_reg)
                                                                .SetFixedLeading(14f)
                                                                .SetFontColor(cl_grayDark)
                                                                .SetBackgroundColor(cl_tablecontent_1)
                                                                .SetFontSize(9))
                                                .SetBackgroundColor(cl_tablecontent_1)
                                                .SetBorderTop(Border.NO_BORDER)
                                                .SetBorderBottom(Border.NO_BORDER);



                                            cell4.SetTextAlignment(TextAlignment.RIGHT)
                                                .Add(new Paragraph(string.Format("{0:N2}", activity.ActivityCost))
                                                                //.SetFont(ft_montserrat_reg)
                                                                .SetFixedLeading(14f)
                                                                .SetFontColor(cl_grayDark)
                                                                .SetBackgroundColor(cl_tablecontent_1)
                                                                .SetFontSize(9))
                                                .SetBackgroundColor(cl_tablecontent_1)
                                                .SetBorderTop(Border.NO_BORDER)
                                                .SetBorderBottom(Border.NO_BORDER);
                                        }
                                        else
                                        {
                                            //Row Rows

                                            cell1.SetTextAlignment(TextAlignment.LEFT)
                                                .Add(new Paragraph(activity.ActivityDescription)
                                                               // .SetFont(ft_montserrat_reg)
                                                                .SetFixedLeading(14f)
                                                                .SetFontColor(cl_grayDark)
                                                                .SetBackgroundColor(cl_tablecontent_2)
                                                                .SetFontSize(9))
                                                    .SetBackgroundColor(cl_tablecontent_2)
                                                    .SetBorderTop(Border.NO_BORDER)
                                                    .SetBorderBottom(Border.NO_BORDER);



                                            cell2.SetTextAlignment(TextAlignment.LEFT)
                                                .Add(new Paragraph(_lkupActivityTypeRepository.GetActivityType(activity.ActivityType_Id).Activity_Name)
                                                                //.SetFont(ft_montserrat_reg)
                                                                .SetFixedLeading(14f)
                                                                .SetFontColor(cl_grayDark)
                                                                .SetBackgroundColor(cl_tablecontent_2)
                                                                .SetFontSize(9))
                                                .SetBackgroundColor(cl_tablecontent_2)
                                                .SetBorderTop(Border.NO_BORDER)
                                                .SetBorderBottom(Border.NO_BORDER);


                                            cell3.SetTextAlignment(TextAlignment.LEFT)
                                                .Add(new Paragraph(period)
                                                               // .SetFont(ft_montserrat_reg)
                                                                .SetFixedLeading(14f)
                                                                .SetFontColor(cl_grayDark)
                                                                .SetBackgroundColor(cl_tablecontent_2)
                                                                .SetFontSize(9))
                                                .SetBackgroundColor(cl_tablecontent_2)
                                                .SetBorderTop(Border.NO_BORDER)
                                                .SetBorderBottom(Border.NO_BORDER);
            


                                            cell4.SetTextAlignment(TextAlignment.RIGHT)
                                                .Add(new Paragraph(string.Format("{0:N2}", activity.ActivityCost))
                                                               // .SetFont(ft_montserrat_reg)
                                                                .SetFixedLeading(14f)
                                                                .SetFontColor(cl_grayDark)
                                                                .SetBackgroundColor(cl_tablecontent_2)
                                                                .SetFontSize(9))
                                                .SetBackgroundColor(cl_tablecontent_2)
                                                .SetBorderTop(Border.NO_BORDER)
                                                .SetBorderBottom(Border.NO_BORDER);
                                            

                                        }

                                        row_alt=ToggleBoolean(row_alt);
                                        if(inneriter==activitycount)
                                        {
                                            cell1.SetBorderBottom(new SolidBorder(1f));
                                            cell2.SetBorderBottom(new SolidBorder(1f));
                                            cell3.SetBorderBottom(new SolidBorder(1f));
                                            cell4.SetBorderBottom(new SolidBorder(1f));

                                        }

                                        tableactivity_spanning.AddCell(cell1);
                                        tableactivity_spanning.AddCell(cell2);
                                        tableactivity_spanning.AddCell(cell3);   
                                        tableactivity_spanning.AddCell(cell4);

                                    }

                                }
                                inneriter=0;
                                row_alt=true;
                                document.Add(tableactivity_spanning);




                            }
                            else
                            {
                                /*Paragraph outputtextnoact_spanning = new Paragraph("No Activity Recorded")
                                .SetTextAlignment(TextAlignment.LEFT)
                                .SetFont(ft_montserrat_reg)
                                .SetFixedLeading(9f)
                                .SetFontColor(cl_grayDark)
                                .SetMarginLeft(37)
                                .SetFontSize(9);
                                document.Add(outputtextnoact_spanning);*/

                            }
                            document.Add(txt);
                            document.Add(txt);


                            float indentmargin_outer2=document.GetLeftMargin()+49;
                            Table tableactivity_outer2= new Table(UnitValue.CreatePercentArray(new float[]{4, 96}), false)
                                                .SetWidth(PageSize.A4.GetWidth()-indentmargin_outer2)
                                                .SetMarginLeft(14)
                                                .SetHorizontalAlignment(HorizontalAlignment.LEFT);

                                Cell cellbullet2 = new Cell(1, 1)
                                .SetTextAlignment(TextAlignment.LEFT)
                                .Add(new Paragraph("\ue837")
                                                .SetFont(ft_materialicons_fonts)
                                                .SetFixedLeading(14f)
                                                .SetFontColor(cl_green)
                                                .SetFontSize(10))
                                    .SetBorder(Border.NO_BORDER);

                                Cell celltxt2= new Cell(1, 1)
                                .SetTextAlignment(TextAlignment.JUSTIFIED)
                                .Add(new Paragraph("Activities Outside of Workplan Period")
                                                .SetFixedLeading(14f)
                                                .SetFontColor(cl_green)
                                                .SetFontSize(10))
                                    .SetBorder(Border.NO_BORDER);

                            tableactivity_outer2.AddCell(cellbullet2);
                            tableactivity_outer2.AddCell(celltxt2);

                            document.Add(tableactivity_outer2);
                            document.Add(txt);

                             float indentmargin_outside=document.GetLeftMargin()+74;
                            Table tableactivity_outside = new Table(UnitValue.CreatePercentArray(new float[]{35, 20, 27, 18}), false)
                                .SetWidth(PageSize.A4.GetWidth()-indentmargin_outside)
                                .SetMarginLeft(37)
                                .SetHorizontalAlignment(HorizontalAlignment.LEFT);


                            var DB_Activities_outside=_wpOutputActivitiesRepository.GetRecordsByMainRecordId(mainrec.Transaction_Id);

                            DateTime startperiod_outside=new DateTime(Int32.Parse(_lkupFiscalYearRepository.GetRecord(mainrec.FiscalYear_Id).Record_Name) , 6, 1);
                            DateTime endperiod_outside=new DateTime(Int32.Parse(_lkupFiscalYearRepository.GetRecord(mainrec.FiscalYear_Id).Record_Name) , 12, DateTime.DaysInMonth(mainrec.FiscalYear_Id, 12));

                            int actualrecords_outside=0;
                            foreach (var activity in DB_Activities_outside)
                            {
                                if(IsActivityOutsideWPPeriod(new DateTime(activity.ActivityStartDate.Year, activity.ActivityStartDate.Month, activity.ActivityStartDate.Day), new DateTime(activity.ActivityEndDate.Year, activity.ActivityEndDate.Month, activity.ActivityEndDate.Day), startperiod_outside, endperiod_outside)==true)
                                    actualrecords_outside=actualrecords_outside+1;
                            }
                            if(actualrecords_outside>=1)
                            {
                                //Row Header
                                Cell cellheader01 = new Cell(1, 1)
                                .SetTextAlignment(TextAlignment.LEFT)
                                .Add(new Paragraph("ACTIVITY")
                                                //.SetFont(ft_montserrat_medium)
                                                .SetFixedLeading(14f)
                                                .SetFontColor(cl_grayDark)
                                                .SetBackgroundColor(cl_tableheader)
                                                .SetFontSize(10))
                                    .SetBackgroundColor(cl_tableheader);

                                tableactivity_outside.AddCell(cellheader01);

                                Cell cellheader02 = new Cell(1, 1)
                                    .SetTextAlignment(TextAlignment.LEFT)
                                    .Add(new Paragraph("TYPE")
                                                   // .SetFont(ft_montserrat_medium)
                                                    .SetFixedLeading(14f)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tableheader)
                                                    .SetFontSize(10))
                                    .SetBackgroundColor(cl_tableheader);

                                tableactivity_outside.AddCell(cellheader02);


                                Cell cellheader03 = new Cell(1, 1)
                                    .SetTextAlignment(TextAlignment.LEFT)
                                    .Add(new Paragraph("PERIOD")
                                                   // .SetFont(ft_montserrat_medium)
                                                    .SetFixedLeading(14f)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tableheader)
                                                    .SetFontSize(10))
                                    .SetBackgroundColor(cl_tableheader);
                                tableactivity_outside.AddCell(cellheader03);

                                Cell cellheader04 = new Cell(1, 1)
                                    .SetTextAlignment(TextAlignment.RIGHT)
                                    .Add(new Paragraph("AMOUNT (USD)")
                                                   // .SetFont(ft_montserrat_medium)
                                                    .SetFixedLeading(14f)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tableheader)
                                                    .SetFontSize(10))
                                    .SetBackgroundColor(cl_tableheader);

                                tableactivity_outside.AddCell(cellheader04);

                                int activitycount=actualrecords_outside;

                                foreach (var activity in DB_Activities_outside)
                                {
                                    if(IsActivityOutsideWPPeriod(new DateTime(activity.ActivityStartDate.Year, activity.ActivityStartDate.Month, activity.ActivityStartDate.Day), new DateTime(activity.ActivityEndDate.Year, activity.ActivityEndDate.Month, activity.ActivityEndDate.Day), startperiod_outside, endperiod_outside)==true)
                                    {
                                        inneriter=inneriter+1;

                                        Cell cell1 = new Cell(1, 1);
                                        Cell cell2 = new Cell(1, 1);
                                        Cell cell3 = new Cell(1, 1);
                                        Cell cell4 = new Cell(1, 1);

                                        DateTime start= new  DateTime(activity.ActivityStartDate.Year, activity.ActivityStartDate.Month, activity.ActivityStartDate.Day);
                                        DateTime end= new  DateTime(activity.ActivityEndDate.Year, activity.ActivityEndDate.Month, activity.ActivityEndDate.Day);
                                        string period=start.Date.ToString("MMM. d, yyyy")+" - "+end.Date.ToString("MMM. d, yyyy");

                                        if(row_alt==false)
                                        {
                                            //Row Rows
                                            cell1.SetTextAlignment(TextAlignment.LEFT)
                                            .Add(new Paragraph(activity.ActivityDescription)
                                                            //.SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_1)
                                                            .SetFontSize(9))
                                                .SetBackgroundColor(cl_tablecontent_1)
                                                .SetBorderTop(Border.NO_BORDER)
                                                .SetBorderBottom(Border.NO_BORDER);


                                        
                                                cell2.SetTextAlignment(TextAlignment.LEFT)
                                                .Add(new Paragraph(_lkupActivityTypeRepository.GetActivityType(activity.ActivityType_Id).Activity_Name)
                                                                //.SetFont(ft_montserrat_reg)
                                                                .SetFixedLeading(14f)
                                                                .SetFontColor(cl_grayDark)
                                                                .SetBackgroundColor(cl_tablecontent_1)
                                                                .SetFontSize(9))
                                                .SetBackgroundColor(cl_tablecontent_1)
                                                .SetBorderTop(Border.NO_BORDER)
                                                .SetBorderBottom(Border.NO_BORDER);


                                                cell3.SetTextAlignment(TextAlignment.LEFT)
                                                .Add(new Paragraph(period)
                                                                //.SetFont(ft_montserrat_reg)
                                                                .SetFixedLeading(14f)
                                                                .SetFontColor(cl_grayDark)
                                                                .SetBackgroundColor(cl_tablecontent_1)
                                                                .SetFontSize(9))
                                                .SetBackgroundColor(cl_tablecontent_1)
                                                .SetBorderTop(Border.NO_BORDER)
                                                .SetBorderBottom(Border.NO_BORDER);


                                            cell4.SetTextAlignment(TextAlignment.RIGHT)
                                                .Add(new Paragraph(string.Format("{0:N2}", activity.ActivityCost))
                                                                //.SetFont(ft_montserrat_reg)
                                                                .SetFixedLeading(14f)
                                                                .SetFontColor(cl_grayDark)
                                                                .SetBackgroundColor(cl_tablecontent_1)
                                                                .SetFontSize(9))
                                                .SetBackgroundColor(cl_tablecontent_1)
                                                .SetBorderTop(Border.NO_BORDER)
                                                .SetBorderBottom(Border.NO_BORDER);


                                        }
                                        else
                                        {
                                            //Row Rows

                                            cell1.SetTextAlignment(TextAlignment.LEFT)
                                                .Add(new Paragraph(activity.ActivityDescription)
                                                                //.SetFont(ft_montserrat_reg)
                                                                .SetFixedLeading(14f)
                                                                .SetFontColor(cl_grayDark)
                                                                .SetBackgroundColor(cl_tablecontent_2)
                                                                .SetFontSize(9))
                                                    .SetBackgroundColor(cl_tablecontent_2)
                                                    .SetBorderTop(Border.NO_BORDER)
                                                    .SetBorderBottom(Border.NO_BORDER);



                                            cell2.SetTextAlignment(TextAlignment.LEFT)
                                                .Add(new Paragraph(_lkupActivityTypeRepository.GetActivityType(activity.ActivityType_Id).Activity_Name)
                                                                //.SetFont(ft_montserrat_reg)
                                                                .SetFixedLeading(14f)
                                                                .SetFontColor(cl_grayDark)
                                                                .SetBackgroundColor(cl_tablecontent_2)
                                                                .SetFontSize(9))
                                                .SetBackgroundColor(cl_tablecontent_2)
                                                .SetBorderTop(Border.NO_BORDER)
                                                .SetBorderBottom(Border.NO_BORDER);



                                            cell3.SetTextAlignment(TextAlignment.LEFT)
                                                .Add(new Paragraph(period)
                                                                //.SetFont(ft_montserrat_reg)
                                                                .SetFixedLeading(14f)
                                                                .SetFontColor(cl_grayDark)
                                                                .SetBackgroundColor(cl_tablecontent_2)
                                                                .SetFontSize(9))
                                                .SetBackgroundColor(cl_tablecontent_2)
                                                .SetBorderTop(Border.NO_BORDER)
                                                .SetBorderBottom(Border.NO_BORDER);


                                            cell4.SetTextAlignment(TextAlignment.RIGHT)
                                                .Add(new Paragraph(string.Format("{0:N2}", activity.ActivityCost))
                                                                //.SetFont(ft_montserrat_reg)
                                                                .SetFixedLeading(14f)
                                                                .SetFontColor(cl_grayDark)
                                                                .SetBackgroundColor(cl_tablecontent_2)
                                                                .SetFontSize(9))
                                                .SetBackgroundColor(cl_tablecontent_2)
                                                .SetBorderTop(Border.NO_BORDER)
                                                .SetBorderBottom(Border.NO_BORDER);

                                        }

                                        row_alt=ToggleBoolean(row_alt);
                                        if(inneriter==activitycount)
                                        {
                                            cell1.SetBorderBottom(new SolidBorder(1f));
                                            cell2.SetBorderBottom(new SolidBorder(1f));
                                            cell3.SetBorderBottom(new SolidBorder(1f));
                                            cell4.SetBorderBottom(new SolidBorder(1f));

                                        }

                                        tableactivity_outside.AddCell(cell1);
                                        tableactivity_outside.AddCell(cell2);
                                        tableactivity_outside.AddCell(cell3);   
                                        tableactivity_outside.AddCell(cell4);

                                    }

                                }
                                inneriter=0;
                                row_alt=true;
                                document.Add(tableactivity_outside);




                            }
                            else
                            {
                               /* Paragraph outputtextnoact_spanning = new Paragraph("No Activity Recorded")
                                .SetTextAlignment(TextAlignment.LEFT)
                                .SetFont(ft_montserrat_reg)
                                .SetFixedLeading(9f)
                                .SetFontColor(cl_grayDark)
                                .SetMarginLeft(37)
                                .SetFontSize(9);
                                document.Add(outputtextnoact_spanning);*/

                            }

                    break;
                    case 7 :
                        int[] months_7 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
                        //for (int i=0;i<months_6.Length;i++)
                        foreach (var i in months_7)
                        {
                            float indentmargin_outer=document.GetLeftMargin()+49;
                            Table tableactivity_outer = new Table(UnitValue.CreatePercentArray(new float[]{4, 96}), false)
                                                .SetWidth(PageSize.A4.GetWidth()-indentmargin_outer)
                                                .SetMarginLeft(14)
                                                .SetHorizontalAlignment(HorizontalAlignment.LEFT);

                                Cell cellbullet = new Cell(1, 1)
                                .SetTextAlignment(TextAlignment.LEFT)
                                .Add(new Paragraph("\ue837")
                                                .SetFont(ft_materialicons_fonts)
                                                .SetFixedLeading(14f)
                                                .SetFontColor(cl_green)
                                                .SetFontSize(10))
                                    .SetBorder(Border.NO_BORDER);

                                Cell celltxt= new Cell(1, 1)
                                .SetTextAlignment(TextAlignment.JUSTIFIED)
                                .Add(new Paragraph(System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i))
                                                .SetFixedLeading(14f)
                                                .SetFontColor(cl_green)
                                                .SetFontSize(10))
                                    .SetBorder(Border.NO_BORDER);

                            tableactivity_outer.AddCell(cellbullet);
                            tableactivity_outer.AddCell(celltxt);

                            document.Add(tableactivity_outer);
                            document.Add(txt);

                            float indentmargin=document.GetLeftMargin()+74;
                            float tablewidth=PageSize.A4.GetWidth()-indentmargin;
                            Table tableactivity_6 = new Table(UnitValue.CreatePercentArray(new float[]{35, 20, 27, 18}), false)
                                .SetWidth(PageSize.A4.GetWidth()-indentmargin)
                                .SetMarginLeft(37)
                                .SetHorizontalAlignment(HorizontalAlignment.LEFT);


                            var DB_Activities=_wpOutputActivitiesRepository.GetRecordsByMainRecordId(mainrec.Transaction_Id);

                            int actualrecords=0;
                            foreach (var activity in DB_Activities)
                            {
                                if(WithinMonth(mainrec.FiscalYear_Id, i, new DateTime(activity.ActivityStartDate.Year, activity.ActivityStartDate.Month, activity.ActivityStartDate.Day), new DateTime(activity.ActivityEndDate.Year, activity.ActivityEndDate.Month, activity.ActivityEndDate.Day))==true)
                                    actualrecords=actualrecords+1;
                            }

                            if(actualrecords>=1)
                            {
                                //Row Header
                                Cell cellheader01 = new Cell(1, 1)
                                .SetTextAlignment(TextAlignment.LEFT)
                                .Add(new Paragraph("ACTIVITY")
                                                //.SetFont(ft_montserrat_medium)
                                                .SetFixedLeading(14f)
                                                .SetFontColor(cl_grayDark)
                                                .SetBackgroundColor(cl_tableheader)
                                                .SetFontSize(10))
                                    .SetBackgroundColor(cl_tableheader);

                                tableactivity_6.AddCell(cellheader01);

                                Cell cellheader02 = new Cell(1, 1)
                                    .SetTextAlignment(TextAlignment.LEFT)
                                    .Add(new Paragraph("TYPE")
                                                // .SetFont(ft_montserrat_medium)
                                                    .SetFixedLeading(14f)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tableheader)
                                                    .SetFontSize(10))
                                    .SetBackgroundColor(cl_tableheader);

                                tableactivity_6.AddCell(cellheader02);


                                Cell cellheader03 = new Cell(1, 1)
                                    .SetTextAlignment(TextAlignment.LEFT)
                                    .Add(new Paragraph("PERIOD")
                                                    .SetFont(ft_montserrat_medium)
                                                    .SetFixedLeading(14f)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tableheader)
                                                    .SetFontSize(10))
                                    .SetBackgroundColor(cl_tableheader);

                                tableactivity_6.AddCell(cellheader03);

                                Cell cellheader04 = new Cell(1, 1)
                                    .SetTextAlignment(TextAlignment.RIGHT)
                                    .Add(new Paragraph("AMOOUNT (USD)")
                                                // .SetFont(ft_montserrat_medium)
                                                    .SetFixedLeading(14f)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tableheader)
                                                    .SetFontSize(10))
                                    .SetBackgroundColor(cl_tableheader);

                                tableactivity_6.AddCell(cellheader04);

                                int activitycount=actualrecords;

                                foreach (var activity in DB_Activities)
                                {
                                    if(WithinMonth(mainrec.FiscalYear_Id, i, new DateTime(activity.ActivityStartDate.Year, activity.ActivityStartDate.Month, activity.ActivityStartDate.Day), new DateTime(activity.ActivityEndDate.Year, activity.ActivityEndDate.Month, activity.ActivityEndDate.Day)))
                                    {
                                        inneriter=inneriter+1;

                                        Cell cell1 = new Cell(1, 1);
                                        Cell cell2 = new Cell(1, 1);
                                        Cell cell3 = new Cell(1, 1);
                                        Cell cell4 = new Cell(1, 1);

                                        DateTime start= new  DateTime(activity.ActivityStartDate.Year, activity.ActivityStartDate.Month, activity.ActivityStartDate.Day);
                                        DateTime end= new  DateTime(activity.ActivityEndDate.Year, activity.ActivityEndDate.Month, activity.ActivityEndDate.Day);
                                        string period=start.Date.ToString("MMM. d, yyyy")+" - "+end.Date.ToString("MMM. d, yyyy");

                                        if(row_alt==false)
                                        {
                                            //Row Rows
                                            cell1.SetTextAlignment(TextAlignment.LEFT)
                                            .Add(new Paragraph(activity.ActivityDescription)
                                                        // .SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_1)
                                                            .SetFontSize(9))
                                                .SetBackgroundColor(cl_tablecontent_1)
                                                .SetBorderTop(Border.NO_BORDER)
                                                .SetBorderBottom(Border.NO_BORDER);


                                        
                                                cell2.SetTextAlignment(TextAlignment.LEFT)
                                                .Add(new Paragraph(_lkupActivityTypeRepository.GetActivityType(activity.ActivityType_Id).Activity_Name)
                                                            // .SetFont(ft_montserrat_reg)
                                                                .SetFixedLeading(14f)
                                                                .SetFontColor(cl_grayDark)
                                                                .SetBackgroundColor(cl_tablecontent_1)
                                                                .SetFontSize(9))
                                                .SetBackgroundColor(cl_tablecontent_1)
                                                .SetBorderTop(Border.NO_BORDER)
                                                .SetBorderBottom(Border.NO_BORDER);


                                                cell3.SetTextAlignment(TextAlignment.LEFT)
                                                .Add(new Paragraph(period)
                                                                //.SetFont(ft_montserrat_reg)
                                                                .SetFixedLeading(14f)
                                                                .SetFontColor(cl_grayDark)
                                                                .SetBackgroundColor(cl_tablecontent_1)
                                                                .SetFontSize(9))
                                                .SetBackgroundColor(cl_tablecontent_1)
                                                .SetBorderTop(Border.NO_BORDER)
                                                .SetBorderBottom(Border.NO_BORDER);



                                            cell4.SetTextAlignment(TextAlignment.RIGHT)
                                                .Add(new Paragraph(string.Format("{0:N2}", activity.ActivityCost))
                                                                //.SetFont(ft_montserrat_reg)
                                                                .SetFixedLeading(14f)
                                                                .SetFontColor(cl_grayDark)
                                                                .SetBackgroundColor(cl_tablecontent_1)
                                                                .SetFontSize(9))
                                                .SetBackgroundColor(cl_tablecontent_1)
                                                .SetBorderTop(Border.NO_BORDER)
                                                .SetBorderBottom(Border.NO_BORDER);


                                        }
                                        else
                                        {
                                            //Row Rows

                                            cell1.SetTextAlignment(TextAlignment.LEFT)
                                                .Add(new Paragraph(activity.ActivityDescription)
                                                                //.SetFont(ft_montserrat_reg)
                                                                .SetFixedLeading(14f)
                                                                .SetFontColor(cl_grayDark)
                                                                .SetBackgroundColor(cl_tablecontent_2)
                                                                .SetFontSize(9))
                                                    .SetBackgroundColor(cl_tablecontent_2)
                                                    .SetBorderTop(Border.NO_BORDER)
                                                    .SetBorderBottom(Border.NO_BORDER);



                                            cell2.SetTextAlignment(TextAlignment.LEFT)
                                                .Add(new Paragraph(_lkupActivityTypeRepository.GetActivityType(activity.ActivityType_Id).Activity_Name)
                                                                //.SetFont(ft_montserrat_reg)
                                                                .SetFixedLeading(14f)
                                                                .SetFontColor(cl_grayDark)
                                                                .SetBackgroundColor(cl_tablecontent_2)
                                                                .SetFontSize(9))
                                                .SetBackgroundColor(cl_tablecontent_2)
                                                .SetBorderTop(Border.NO_BORDER)
                                                .SetBorderBottom(Border.NO_BORDER);




                                            cell3.SetTextAlignment(TextAlignment.LEFT)
                                                .Add(new Paragraph(period)
                                                                //.SetFont(ft_montserrat_reg)
                                                                .SetFixedLeading(14f)
                                                                .SetFontColor(cl_grayDark)
                                                                .SetBackgroundColor(cl_tablecontent_2)
                                                                .SetFontSize(9))
                                                .SetBackgroundColor(cl_tablecontent_2)
                                                .SetBorderTop(Border.NO_BORDER)
                                                .SetBorderBottom(Border.NO_BORDER);



                                            cell4.SetTextAlignment(TextAlignment.RIGHT)
                                                .Add(new Paragraph(string.Format("{0:N2}", activity.ActivityCost))
                                                                //.SetFont(ft_montserrat_reg)
                                                                .SetFixedLeading(14f)
                                                                .SetFontColor(cl_grayDark)
                                                                .SetBackgroundColor(cl_tablecontent_2)
                                                                .SetFontSize(9))
                                                .SetBackgroundColor(cl_tablecontent_2)
                                                .SetBorderTop(Border.NO_BORDER)
                                                .SetBorderBottom(Border.NO_BORDER);
                                            

                                        }

                                        row_alt=ToggleBoolean(row_alt);
                                        if(inneriter==activitycount)
                                        {
                                            cell1.SetBorderBottom(new SolidBorder(1f));
                                            cell2.SetBorderBottom(new SolidBorder(1f));
                                            cell3.SetBorderBottom(new SolidBorder(1f));
                                            cell4.SetBorderBottom(new SolidBorder(1f));

                                        }

                                        tableactivity_6.AddCell(cell1);
                                        tableactivity_6.AddCell(cell2);
                                        tableactivity_6.AddCell(cell3);   
                                        tableactivity_6.AddCell(cell4);

                                    }

                                }

                                inneriter=0;
                                row_alt=true;
                                document.Add(tableactivity_6);

                                
                            }

                            document.Add(txt);
                            document.Add(txt);


                        }

                        //Activities Spanning Multiple Months
                        float indentmargin_outer17=document.GetLeftMargin()+49;
                        Table tableactivity_outer17 = new Table(UnitValue.CreatePercentArray(new float[]{4, 96}), false)
                                            .SetWidth(PageSize.A4.GetWidth()-indentmargin_outer17)
                                            .SetMarginLeft(14)
                                            .SetHorizontalAlignment(HorizontalAlignment.LEFT);

                            Cell cellbullet17 = new Cell(1, 1)
                            .SetTextAlignment(TextAlignment.LEFT)
                            .Add(new Paragraph("\ue837")
                                            .SetFont(ft_materialicons_fonts)
                                            .SetFixedLeading(14f)
                                            .SetFontColor(cl_green)
                                            .SetFontSize(10))
                                .SetBorder(Border.NO_BORDER);

                            Cell celltxt17= new Cell(1, 1)
                            .SetTextAlignment(TextAlignment.JUSTIFIED)
                            .Add(new Paragraph("Activities Spanning Multiple Months")
                                            .SetFixedLeading(14f)
                                            .SetFontColor(cl_green)
                                            .SetFontSize(10))
                                .SetBorder(Border.NO_BORDER);

                        tableactivity_outer17.AddCell(cellbullet17);
                        tableactivity_outer17.AddCell(celltxt17);

                        document.Add(tableactivity_outer17);
                        document.Add(txt);

                        

                        float indentmargin_spanning17=document.GetLeftMargin()+74;
                        Table tableactivity_spanning17 = new Table(UnitValue.CreatePercentArray(new float[]{35, 20, 27, 18}), false)
                            .SetWidth(PageSize.A4.GetWidth()-indentmargin_spanning17)
                            .SetMarginLeft(37)
                            .SetHorizontalAlignment(HorizontalAlignment.LEFT);


                        var DB_Activities_spanning17=_wpOutputActivitiesRepository.GetRecordsByMainRecordId(mainrec.Transaction_Id);

                        DateTime startperiod_spanning17=new DateTime(Int32.Parse(_lkupFiscalYearRepository.GetRecord(mainrec.FiscalYear_Id).Record_Name) , 1, 1);
                        DateTime endperiod_spanning17=new DateTime(Int32.Parse(_lkupFiscalYearRepository.GetRecord(mainrec.FiscalYear_Id).Record_Name) , 12, DateTime.DaysInMonth(mainrec.FiscalYear_Id, 12));

                        int actualrecords_spanning17=0;
                        foreach (var activity in DB_Activities_spanning17)
                        {
                            if(IsActivitySpanningMultipleMonths(mainrec.FiscalYear_Id, months_7, new DateTime(activity.ActivityStartDate.Year, activity.ActivityStartDate.Month, activity.ActivityStartDate.Day), new DateTime(activity.ActivityEndDate.Year, activity.ActivityEndDate.Month, activity.ActivityEndDate.Day), startperiod_spanning17, endperiod_spanning17)==true)
                                actualrecords_spanning17=actualrecords_spanning17+1;
                        }
                        if(actualrecords_spanning17>=1)
                        {
                            //Row Header
                            Cell cellheader01 = new Cell(1, 1)
                            .SetTextAlignment(TextAlignment.LEFT)
                            .Add(new Paragraph("ACTIVITY")
                                            //.SetFont(ft_montserrat_medium)
                                            .SetFixedLeading(14f)
                                            .SetFontColor(cl_grayDark)
                                            .SetBackgroundColor(cl_tableheader)
                                            .SetFontSize(10))
                                .SetBackgroundColor(cl_tableheader);
                            tableactivity_spanning17.AddCell(cellheader01);

                            Cell cellheader02 = new Cell(1, 1)
                                .SetTextAlignment(TextAlignment.LEFT)
                                .Add(new Paragraph("TYPE")
                                                // .SetFont(ft_montserrat_medium)
                                                .SetFixedLeading(14f)
                                                .SetFontColor(cl_grayDark)
                                                .SetBackgroundColor(cl_tableheader)
                                                .SetFontSize(10))
                                .SetBackgroundColor(cl_tableheader);
                            tableactivity_spanning17.AddCell(cellheader02);


                            Cell cellheader03 = new Cell(1, 1)
                                .SetTextAlignment(TextAlignment.LEFT)
                                .Add(new Paragraph("PERIOD")
                                                //.SetFont(ft_montserrat_medium)
                                                .SetFixedLeading(14f)
                                                .SetFontColor(cl_grayDark)
                                                .SetBackgroundColor(cl_tableheader)
                                                .SetFontSize(10))
                                .SetBackgroundColor(cl_tableheader);
                            tableactivity_spanning17.AddCell(cellheader03);

                            Cell cellheader04 = new Cell(1, 1)
                                .SetTextAlignment(TextAlignment.RIGHT)
                                .Add(new Paragraph("AMOUNT (USD)")
                                                //.SetFont(ft_montserrat_medium)
                                                .SetFixedLeading(14f)
                                                .SetFontColor(cl_grayDark)
                                                .SetBackgroundColor(cl_tableheader)
                                                .SetFontSize(10))
                                .SetBackgroundColor(cl_tableheader);

                            tableactivity_spanning17.AddCell(cellheader04);

                            int activitycount=actualrecords_spanning17;

                            foreach (var activity in DB_Activities_spanning17)
                            {
                                if(IsActivitySpanningMultipleMonths(mainrec.FiscalYear_Id, months_7, new DateTime(activity.ActivityStartDate.Year, activity.ActivityStartDate.Month, activity.ActivityStartDate.Day), new DateTime(activity.ActivityEndDate.Year, activity.ActivityEndDate.Month, activity.ActivityEndDate.Day), startperiod_spanning17, endperiod_spanning17))
                                {
                                    inneriter=inneriter+1;

                                    Cell cell1 = new Cell(1, 1);
                                    Cell cell2 = new Cell(1, 1);
                                    Cell cell3 = new Cell(1, 1);
                                    Cell cell4 = new Cell(1, 1);

                                    DateTime start= new  DateTime(activity.ActivityStartDate.Year, activity.ActivityStartDate.Month, activity.ActivityStartDate.Day);
                                    DateTime end= new  DateTime(activity.ActivityEndDate.Year, activity.ActivityEndDate.Month, activity.ActivityEndDate.Day);
                                    string period=start.Date.ToString("MMM. d, yyyy")+" - "+end.Date.ToString("MMM. d, yyyy");

                                    if(row_alt==false)
                                    {
                                        //Row Rows
                                        cell1.SetTextAlignment(TextAlignment.LEFT)
                                        .Add(new Paragraph(activity.ActivityDescription)
                                                        // .SetFont(ft_montserrat_reg)
                                                        .SetFixedLeading(14f)
                                                        .SetFontColor(cl_grayDark)
                                                        .SetBackgroundColor(cl_tablecontent_1)
                                                        .SetFontSize(9))
                                            .SetBackgroundColor(cl_tablecontent_1)
                                            .SetBorderTop(Border.NO_BORDER)
                                            .SetBorderBottom(Border.NO_BORDER);


                                    
                                            cell2.SetTextAlignment(TextAlignment.LEFT)
                                            .Add(new Paragraph(_lkupActivityTypeRepository.GetActivityType(activity.ActivityType_Id).Activity_Name)
                                                            // .SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_1)
                                                            .SetFontSize(9))
                                            .SetBackgroundColor(cl_tablecontent_1)
                                            .SetBorderTop(Border.NO_BORDER)
                                            .SetBorderBottom(Border.NO_BORDER);


                                            cell3.SetTextAlignment(TextAlignment.LEFT)
                                            .Add(new Paragraph(period)
                                                            //.SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_1)
                                                            .SetFontSize(9))
                                            .SetBackgroundColor(cl_tablecontent_1)
                                            .SetBorderTop(Border.NO_BORDER)
                                            .SetBorderBottom(Border.NO_BORDER);



                                        cell4.SetTextAlignment(TextAlignment.RIGHT)
                                            .Add(new Paragraph(string.Format("{0:N2}", activity.ActivityCost))
                                                            //.SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_1)
                                                            .SetFontSize(9))
                                            .SetBackgroundColor(cl_tablecontent_1)
                                            .SetBorderTop(Border.NO_BORDER)
                                            .SetBorderBottom(Border.NO_BORDER);
                                    }
                                    else
                                    {
                                        //Row Rows

                                        cell1.SetTextAlignment(TextAlignment.LEFT)
                                            .Add(new Paragraph(activity.ActivityDescription)
                                                            // .SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_2)
                                                            .SetFontSize(9))
                                                .SetBackgroundColor(cl_tablecontent_2)
                                                .SetBorderTop(Border.NO_BORDER)
                                                .SetBorderBottom(Border.NO_BORDER);



                                        cell2.SetTextAlignment(TextAlignment.LEFT)
                                            .Add(new Paragraph(_lkupActivityTypeRepository.GetActivityType(activity.ActivityType_Id).Activity_Name)
                                                            //.SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_2)
                                                            .SetFontSize(9))
                                            .SetBackgroundColor(cl_tablecontent_2)
                                            .SetBorderTop(Border.NO_BORDER)
                                            .SetBorderBottom(Border.NO_BORDER);


                                        cell3.SetTextAlignment(TextAlignment.LEFT)
                                            .Add(new Paragraph(period)
                                                            // .SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_2)
                                                            .SetFontSize(9))
                                            .SetBackgroundColor(cl_tablecontent_2)
                                            .SetBorderTop(Border.NO_BORDER)
                                            .SetBorderBottom(Border.NO_BORDER);
        


                                        cell4.SetTextAlignment(TextAlignment.RIGHT)
                                            .Add(new Paragraph(string.Format("{0:N2}", activity.ActivityCost))
                                                            // .SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_2)
                                                            .SetFontSize(9))
                                            .SetBackgroundColor(cl_tablecontent_2)
                                            .SetBorderTop(Border.NO_BORDER)
                                            .SetBorderBottom(Border.NO_BORDER);
                                        

                                    }

                                    row_alt=ToggleBoolean(row_alt);
                                    if(inneriter==activitycount)
                                    {
                                        cell1.SetBorderBottom(new SolidBorder(1f));
                                        cell2.SetBorderBottom(new SolidBorder(1f));
                                        cell3.SetBorderBottom(new SolidBorder(1f));
                                        cell4.SetBorderBottom(new SolidBorder(1f));

                                    }

                                    tableactivity_spanning17.AddCell(cell1);
                                    tableactivity_spanning17.AddCell(cell2);
                                    tableactivity_spanning17.AddCell(cell3);   
                                    tableactivity_spanning17.AddCell(cell4);

                                }

                            }
                            inneriter=0;
                            row_alt=true;
                            document.Add(tableactivity_spanning17);




                        }
                        document.Add(txt);
                        document.Add(txt);


                        //Activities Outside of Workplan Period
                        float indentmargin_outer27=document.GetLeftMargin()+49;
                        Table tableactivity_outer27= new Table(UnitValue.CreatePercentArray(new float[]{4, 96}), false)
                                            .SetWidth(PageSize.A4.GetWidth()-indentmargin_outer27)
                                            .SetMarginLeft(14)
                                            .SetHorizontalAlignment(HorizontalAlignment.LEFT);

                            Cell cellbullet27 = new Cell(1, 1)
                            .SetTextAlignment(TextAlignment.LEFT)
                            .Add(new Paragraph("\ue837")
                                            .SetFont(ft_materialicons_fonts)
                                            .SetFixedLeading(14f)
                                            .SetFontColor(cl_green)
                                            .SetFontSize(10))
                                .SetBorder(Border.NO_BORDER);

                            Cell celltxt27= new Cell(1, 1)
                            .SetTextAlignment(TextAlignment.JUSTIFIED)
                            .Add(new Paragraph("Activities Outside of Workplan Period")
                                            .SetFixedLeading(14f)
                                            .SetFontColor(cl_green)
                                            .SetFontSize(10))
                                .SetBorder(Border.NO_BORDER);

                        tableactivity_outer27.AddCell(cellbullet27);
                        tableactivity_outer27.AddCell(celltxt27);

                        document.Add(tableactivity_outer27);
                        document.Add(txt);

                            float indentmargin_outside27=document.GetLeftMargin()+74;
                        Table tableactivity_outside27 = new Table(UnitValue.CreatePercentArray(new float[]{35, 20, 27, 18}), false)
                            .SetWidth(PageSize.A4.GetWidth()-indentmargin_outside27)
                            .SetMarginLeft(37)
                            .SetHorizontalAlignment(HorizontalAlignment.LEFT);


                        var DB_Activities_outside27=_wpOutputActivitiesRepository.GetRecordsByMainRecordId(mainrec.Transaction_Id);

                        DateTime startperiod_outside27=new DateTime(Int32.Parse(_lkupFiscalYearRepository.GetRecord(mainrec.FiscalYear_Id).Record_Name) , 1, 1);
                        DateTime endperiod_outside27=new DateTime(Int32.Parse(_lkupFiscalYearRepository.GetRecord(mainrec.FiscalYear_Id).Record_Name) , 12, DateTime.DaysInMonth(mainrec.FiscalYear_Id, 12));

                        int actualrecords_outside27=0;
                        foreach (var activity in DB_Activities_outside27)
                        {
                            if(IsActivityOutsideWPPeriod(new DateTime(activity.ActivityStartDate.Year, activity.ActivityStartDate.Month, activity.ActivityStartDate.Day), new DateTime(activity.ActivityEndDate.Year, activity.ActivityEndDate.Month, activity.ActivityEndDate.Day), startperiod_outside27, endperiod_outside27)==true)
                                actualrecords_outside27=actualrecords_outside27+1;
                        }
                        if(actualrecords_outside27>=1)
                        {
                            //Row Header
                            Cell cellheader01 = new Cell(1, 1)
                            .SetTextAlignment(TextAlignment.LEFT)
                            .Add(new Paragraph("ACTIVITY")
                                            //.SetFont(ft_montserrat_medium)
                                            .SetFixedLeading(14f)
                                            .SetFontColor(cl_grayDark)
                                            .SetBackgroundColor(cl_tableheader)
                                            .SetFontSize(10))
                                .SetBackgroundColor(cl_tableheader);

                            tableactivity_outside27.AddCell(cellheader01);

                            Cell cellheader02 = new Cell(1, 1)
                                .SetTextAlignment(TextAlignment.LEFT)
                                .Add(new Paragraph("TYPE")
                                                // .SetFont(ft_montserrat_medium)
                                                .SetFixedLeading(14f)
                                                .SetFontColor(cl_grayDark)
                                                .SetBackgroundColor(cl_tableheader)
                                                .SetFontSize(10))
                                .SetBackgroundColor(cl_tableheader);

                            tableactivity_outside27.AddCell(cellheader02);


                            Cell cellheader03 = new Cell(1, 1)
                                .SetTextAlignment(TextAlignment.LEFT)
                                .Add(new Paragraph("PERIOD")
                                                // .SetFont(ft_montserrat_medium)
                                                .SetFixedLeading(14f)
                                                .SetFontColor(cl_grayDark)
                                                .SetBackgroundColor(cl_tableheader)
                                                .SetFontSize(10))
                                .SetBackgroundColor(cl_tableheader);
                            tableactivity_outside27.AddCell(cellheader03);

                            Cell cellheader04 = new Cell(1, 1)
                                .SetTextAlignment(TextAlignment.RIGHT)
                                .Add(new Paragraph("AMOUNT (USD)")
                                                // .SetFont(ft_montserrat_medium)
                                                .SetFixedLeading(14f)
                                                .SetFontColor(cl_grayDark)
                                                .SetBackgroundColor(cl_tableheader)
                                                .SetFontSize(10))
                                .SetBackgroundColor(cl_tableheader);

                            tableactivity_outside27.AddCell(cellheader04);

                            int activitycount=actualrecords_outside27;

                            foreach (var activity in DB_Activities_outside27)
                            {
                                if(IsActivityOutsideWPPeriod(new DateTime(activity.ActivityStartDate.Year, activity.ActivityStartDate.Month, activity.ActivityStartDate.Day), new DateTime(activity.ActivityEndDate.Year, activity.ActivityEndDate.Month, activity.ActivityEndDate.Day), startperiod_outside27, endperiod_outside27)==true)
                                {
                                    inneriter=inneriter+1;

                                    Cell cell1 = new Cell(1, 1);
                                    Cell cell2 = new Cell(1, 1);
                                    Cell cell3 = new Cell(1, 1);
                                    Cell cell4 = new Cell(1, 1);

                                    DateTime start= new  DateTime(activity.ActivityStartDate.Year, activity.ActivityStartDate.Month, activity.ActivityStartDate.Day);
                                    DateTime end= new  DateTime(activity.ActivityEndDate.Year, activity.ActivityEndDate.Month, activity.ActivityEndDate.Day);
                                    string period=start.Date.ToString("MMM. d, yyyy")+" - "+end.Date.ToString("MMM. d, yyyy");

                                    if(row_alt==false)
                                    {
                                        //Row Rows
                                        cell1.SetTextAlignment(TextAlignment.LEFT)
                                        .Add(new Paragraph(activity.ActivityDescription)
                                                        //.SetFont(ft_montserrat_reg)
                                                        .SetFixedLeading(14f)
                                                        .SetFontColor(cl_grayDark)
                                                        .SetBackgroundColor(cl_tablecontent_1)
                                                        .SetFontSize(9))
                                            .SetBackgroundColor(cl_tablecontent_1)
                                            .SetBorderTop(Border.NO_BORDER)
                                            .SetBorderBottom(Border.NO_BORDER);


                                    
                                            cell2.SetTextAlignment(TextAlignment.LEFT)
                                            .Add(new Paragraph(_lkupActivityTypeRepository.GetActivityType(activity.ActivityType_Id).Activity_Name)
                                                            //.SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_1)
                                                            .SetFontSize(9))
                                            .SetBackgroundColor(cl_tablecontent_1)
                                            .SetBorderTop(Border.NO_BORDER)
                                            .SetBorderBottom(Border.NO_BORDER);


                                            cell3.SetTextAlignment(TextAlignment.LEFT)
                                            .Add(new Paragraph(period)
                                                            //.SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_1)
                                                            .SetFontSize(9))
                                            .SetBackgroundColor(cl_tablecontent_1)
                                            .SetBorderTop(Border.NO_BORDER)
                                            .SetBorderBottom(Border.NO_BORDER);


                                        cell4.SetTextAlignment(TextAlignment.RIGHT)
                                            .Add(new Paragraph(string.Format("{0:N2}", activity.ActivityCost))
                                                            //.SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_1)
                                                            .SetFontSize(9))
                                            .SetBackgroundColor(cl_tablecontent_1)
                                            .SetBorderTop(Border.NO_BORDER)
                                            .SetBorderBottom(Border.NO_BORDER);


                                    }
                                    else
                                    {
                                        //Row Rows

                                        cell1.SetTextAlignment(TextAlignment.LEFT)
                                            .Add(new Paragraph(activity.ActivityDescription)
                                                            //.SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_2)
                                                            .SetFontSize(9))
                                                .SetBackgroundColor(cl_tablecontent_2)
                                                .SetBorderTop(Border.NO_BORDER)
                                                .SetBorderBottom(Border.NO_BORDER);



                                        cell2.SetTextAlignment(TextAlignment.LEFT)
                                            .Add(new Paragraph(_lkupActivityTypeRepository.GetActivityType(activity.ActivityType_Id).Activity_Name)
                                                            //.SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_2)
                                                            .SetFontSize(9))
                                            .SetBackgroundColor(cl_tablecontent_2)
                                            .SetBorderTop(Border.NO_BORDER)
                                            .SetBorderBottom(Border.NO_BORDER);



                                        cell3.SetTextAlignment(TextAlignment.LEFT)
                                            .Add(new Paragraph(period)
                                                            //.SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_2)
                                                            .SetFontSize(9))
                                            .SetBackgroundColor(cl_tablecontent_2)
                                            .SetBorderTop(Border.NO_BORDER)
                                            .SetBorderBottom(Border.NO_BORDER);


                                        cell4.SetTextAlignment(TextAlignment.RIGHT)
                                            .Add(new Paragraph(string.Format("{0:N2}", activity.ActivityCost))
                                                            //.SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_2)
                                                            .SetFontSize(9))
                                            .SetBackgroundColor(cl_tablecontent_2)
                                            .SetBorderTop(Border.NO_BORDER)
                                            .SetBorderBottom(Border.NO_BORDER);

                                    }

                                    row_alt=ToggleBoolean(row_alt);
                                    if(inneriter==activitycount)
                                    {
                                        cell1.SetBorderBottom(new SolidBorder(1f));
                                        cell2.SetBorderBottom(new SolidBorder(1f));
                                        cell3.SetBorderBottom(new SolidBorder(1f));
                                        cell4.SetBorderBottom(new SolidBorder(1f));

                                    }

                                    tableactivity_outside27.AddCell(cell1);
                                    tableactivity_outside27.AddCell(cell2);
                                    tableactivity_outside27.AddCell(cell3);   
                                    tableactivity_outside27.AddCell(cell4);

                                }

                            }
                            inneriter=0;
                            row_alt=true;
                            document.Add(tableactivity_outside27);




                        }
                    break;

                    case 8 :

                        DateTime pstart=new DateTime(mainrec.PeriodStartDate.Year, mainrec.PeriodStartDate.Month, mainrec.PeriodStartDate.Day);
                        DateTime pend=new DateTime(mainrec.PeriodEndDate.Year, mainrec.PeriodEndDate.Month, mainrec.PeriodEndDate.Day);
                        periodnamesection=pstart.Date.ToString("MMM d, yy") + " - "+ pend.Date.ToString("MMM d, yy"); 

                        List<string> months=MonthNames(pstart, pend);
                        List<MonthAndYear> months_in_range=GetMonthsInPeriodRange(pstart, pend);

                        foreach (var i in months_in_range)
                        {
                            float indentmargin_outer=document.GetLeftMargin()+49;
                            Table tableactivity_outer = new Table(UnitValue.CreatePercentArray(new float[]{4, 96}), false)
                                                .SetWidth(PageSize.A4.GetWidth()-indentmargin_outer)
                                                .SetMarginLeft(14)
                                                .SetHorizontalAlignment(HorizontalAlignment.LEFT);

                                Cell cellbullet = new Cell(1, 1)
                                .SetTextAlignment(TextAlignment.LEFT)
                                .Add(new Paragraph("\ue837")
                                                .SetFont(ft_materialicons_fonts)
                                                .SetFixedLeading(14f)
                                                .SetFontColor(cl_green)
                                                .SetFontSize(10))
                                    .SetBorder(Border.NO_BORDER);

                                Cell celltxt= new Cell(1, 1)
                                .SetTextAlignment(TextAlignment.JUSTIFIED)
                                .Add(new Paragraph(System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i.PMonth)+", "+i.PYear.ToString())
                                                .SetFixedLeading(14f)
                                                .SetFontColor(cl_green)
                                                .SetFontSize(10))
                                    .SetBorder(Border.NO_BORDER);

                            tableactivity_outer.AddCell(cellbullet);
                            tableactivity_outer.AddCell(celltxt);

                            document.Add(tableactivity_outer);
                            document.Add(txt);

                            float indentmargin=document.GetLeftMargin()+74;
                            float tablewidth=PageSize.A4.GetWidth()-indentmargin;
                            Table tableactivity_6 = new Table(UnitValue.CreatePercentArray(new float[]{35, 20, 27, 18}), false)
                                .SetWidth(PageSize.A4.GetWidth()-indentmargin)
                                .SetMarginLeft(37)
                                .SetHorizontalAlignment(HorizontalAlignment.LEFT);


                            var DB_Activities=_wpOutputActivitiesRepository.GetRecordsByMainRecordId(mainrec.Transaction_Id);

                            int actualrecords=0;
                            foreach (var activity in DB_Activities)
                            {
                                if(WithinMonthforOther8(i.PYear, i.PMonth, new DateTime(activity.ActivityStartDate.Year, activity.ActivityStartDate.Month, activity.ActivityStartDate.Day), new DateTime(activity.ActivityEndDate.Year, activity.ActivityEndDate.Month, activity.ActivityEndDate.Day))==true)
                                    actualrecords=actualrecords+1;
                            }

                            if(actualrecords>=1)
                            {
                                //Row Header
                                Cell cellheader01 = new Cell(1, 1)
                                .SetTextAlignment(TextAlignment.LEFT)
                                .Add(new Paragraph("ACTIVITY")
                                                //.SetFont(ft_montserrat_medium)
                                                .SetFixedLeading(14f)
                                                .SetFontColor(cl_grayDark)
                                                .SetBackgroundColor(cl_tableheader)
                                                .SetFontSize(10))
                                    .SetBackgroundColor(cl_tableheader);

                                tableactivity_6.AddCell(cellheader01);

                                Cell cellheader02 = new Cell(1, 1)
                                    .SetTextAlignment(TextAlignment.LEFT)
                                    .Add(new Paragraph("TYPE")
                                                // .SetFont(ft_montserrat_medium)
                                                    .SetFixedLeading(14f)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tableheader)
                                                    .SetFontSize(10))
                                    .SetBackgroundColor(cl_tableheader);

                                tableactivity_6.AddCell(cellheader02);


                                Cell cellheader03 = new Cell(1, 1)
                                    .SetTextAlignment(TextAlignment.LEFT)
                                    .Add(new Paragraph("PERIOD")
                                                    .SetFont(ft_montserrat_medium)
                                                    .SetFixedLeading(14f)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tableheader)
                                                    .SetFontSize(10))
                                    .SetBackgroundColor(cl_tableheader);

                                tableactivity_6.AddCell(cellheader03);

                                Cell cellheader04 = new Cell(1, 1)
                                    .SetTextAlignment(TextAlignment.RIGHT)
                                    .Add(new Paragraph("AMOOUNT (USD)")
                                                // .SetFont(ft_montserrat_medium)
                                                    .SetFixedLeading(14f)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tableheader)
                                                    .SetFontSize(10))
                                    .SetBackgroundColor(cl_tableheader);

                                tableactivity_6.AddCell(cellheader04);

                                int activitycount=actualrecords;

                                foreach (var activity in DB_Activities)
                                {
                                    if(WithinMonthforOther8(i.PYear, i.PMonth, new DateTime(activity.ActivityStartDate.Year, activity.ActivityStartDate.Month, activity.ActivityStartDate.Day), new DateTime(activity.ActivityEndDate.Year, activity.ActivityEndDate.Month, activity.ActivityEndDate.Day)))
                                    {
                                        inneriter=inneriter+1;

                                        Cell cell1 = new Cell(1, 1);
                                        Cell cell2 = new Cell(1, 1);
                                        Cell cell3 = new Cell(1, 1);
                                        Cell cell4 = new Cell(1, 1);

                                        DateTime start= new  DateTime(activity.ActivityStartDate.Year, activity.ActivityStartDate.Month, activity.ActivityStartDate.Day);
                                        DateTime end= new  DateTime(activity.ActivityEndDate.Year, activity.ActivityEndDate.Month, activity.ActivityEndDate.Day);
                                        string period=start.Date.ToString("MMM. d, yyyy")+" - "+end.Date.ToString("MMM. d, yyyy");

                                        if(row_alt==false)
                                        {
                                            //Row Rows
                                            cell1.SetTextAlignment(TextAlignment.LEFT)
                                            .Add(new Paragraph(activity.ActivityDescription)
                                                        // .SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_1)
                                                            .SetFontSize(9))
                                                .SetBackgroundColor(cl_tablecontent_1)
                                                .SetBorderTop(Border.NO_BORDER)
                                                .SetBorderBottom(Border.NO_BORDER);


                                        
                                                cell2.SetTextAlignment(TextAlignment.LEFT)
                                                .Add(new Paragraph(_lkupActivityTypeRepository.GetActivityType(activity.ActivityType_Id).Activity_Name)
                                                            // .SetFont(ft_montserrat_reg)
                                                                .SetFixedLeading(14f)
                                                                .SetFontColor(cl_grayDark)
                                                                .SetBackgroundColor(cl_tablecontent_1)
                                                                .SetFontSize(9))
                                                .SetBackgroundColor(cl_tablecontent_1)
                                                .SetBorderTop(Border.NO_BORDER)
                                                .SetBorderBottom(Border.NO_BORDER);


                                                cell3.SetTextAlignment(TextAlignment.LEFT)
                                                .Add(new Paragraph(period)
                                                                //.SetFont(ft_montserrat_reg)
                                                                .SetFixedLeading(14f)
                                                                .SetFontColor(cl_grayDark)
                                                                .SetBackgroundColor(cl_tablecontent_1)
                                                                .SetFontSize(9))
                                                .SetBackgroundColor(cl_tablecontent_1)
                                                .SetBorderTop(Border.NO_BORDER)
                                                .SetBorderBottom(Border.NO_BORDER);



                                            cell4.SetTextAlignment(TextAlignment.RIGHT)
                                                .Add(new Paragraph(string.Format("{0:N2}", activity.ActivityCost))
                                                                //.SetFont(ft_montserrat_reg)
                                                                .SetFixedLeading(14f)
                                                                .SetFontColor(cl_grayDark)
                                                                .SetBackgroundColor(cl_tablecontent_1)
                                                                .SetFontSize(9))
                                                .SetBackgroundColor(cl_tablecontent_1)
                                                .SetBorderTop(Border.NO_BORDER)
                                                .SetBorderBottom(Border.NO_BORDER);


                                        }
                                        else
                                        {
                                            //Row Rows

                                            cell1.SetTextAlignment(TextAlignment.LEFT)
                                                .Add(new Paragraph(activity.ActivityDescription)
                                                                //.SetFont(ft_montserrat_reg)
                                                                .SetFixedLeading(14f)
                                                                .SetFontColor(cl_grayDark)
                                                                .SetBackgroundColor(cl_tablecontent_2)
                                                                .SetFontSize(9))
                                                    .SetBackgroundColor(cl_tablecontent_2)
                                                    .SetBorderTop(Border.NO_BORDER)
                                                    .SetBorderBottom(Border.NO_BORDER);



                                            cell2.SetTextAlignment(TextAlignment.LEFT)
                                                .Add(new Paragraph(_lkupActivityTypeRepository.GetActivityType(activity.ActivityType_Id).Activity_Name)
                                                                //.SetFont(ft_montserrat_reg)
                                                                .SetFixedLeading(14f)
                                                                .SetFontColor(cl_grayDark)
                                                                .SetBackgroundColor(cl_tablecontent_2)
                                                                .SetFontSize(9))
                                                .SetBackgroundColor(cl_tablecontent_2)
                                                .SetBorderTop(Border.NO_BORDER)
                                                .SetBorderBottom(Border.NO_BORDER);




                                            cell3.SetTextAlignment(TextAlignment.LEFT)
                                                .Add(new Paragraph(period)
                                                                //.SetFont(ft_montserrat_reg)
                                                                .SetFixedLeading(14f)
                                                                .SetFontColor(cl_grayDark)
                                                                .SetBackgroundColor(cl_tablecontent_2)
                                                                .SetFontSize(9))
                                                .SetBackgroundColor(cl_tablecontent_2)
                                                .SetBorderTop(Border.NO_BORDER)
                                                .SetBorderBottom(Border.NO_BORDER);



                                            cell4.SetTextAlignment(TextAlignment.RIGHT)
                                                .Add(new Paragraph(string.Format("{0:N2}", activity.ActivityCost))
                                                                //.SetFont(ft_montserrat_reg)
                                                                .SetFixedLeading(14f)
                                                                .SetFontColor(cl_grayDark)
                                                                .SetBackgroundColor(cl_tablecontent_2)
                                                                .SetFontSize(9))
                                                .SetBackgroundColor(cl_tablecontent_2)
                                                .SetBorderTop(Border.NO_BORDER)
                                                .SetBorderBottom(Border.NO_BORDER);
                                            

                                        }

                                        row_alt=ToggleBoolean(row_alt);
                                        if(inneriter==activitycount)
                                        {
                                            cell1.SetBorderBottom(new SolidBorder(1f));
                                            cell2.SetBorderBottom(new SolidBorder(1f));
                                            cell3.SetBorderBottom(new SolidBorder(1f));
                                            cell4.SetBorderBottom(new SolidBorder(1f));

                                        }

                                        tableactivity_6.AddCell(cell1);
                                        tableactivity_6.AddCell(cell2);
                                        tableactivity_6.AddCell(cell3);   
                                        tableactivity_6.AddCell(cell4);

                                    }

                                }

                                inneriter=0;
                                row_alt=true;
                                document.Add(tableactivity_6);

                                
                            }
                            document.Add(txt);
                            document.Add(txt);




                        }

                        float indentmargin_outer18=document.GetLeftMargin()+49;
                        Table tableactivity_outer18 = new Table(UnitValue.CreatePercentArray(new float[]{4, 96}), false)
                                            .SetWidth(PageSize.A4.GetWidth()-indentmargin_outer18)
                                            .SetMarginLeft(14)
                                            .SetHorizontalAlignment(HorizontalAlignment.LEFT);

                            Cell cellbullet18 = new Cell(1, 1)
                            .SetTextAlignment(TextAlignment.LEFT)
                            .Add(new Paragraph("\ue837")
                                            .SetFont(ft_materialicons_fonts)
                                            .SetFixedLeading(14f)
                                            .SetFontColor(cl_green)
                                            .SetFontSize(10))
                                .SetBorder(Border.NO_BORDER);

                            Cell celltxt18= new Cell(1, 1)
                            .SetTextAlignment(TextAlignment.JUSTIFIED)
                            .Add(new Paragraph("Activities Spanning Multiple Months")
                                            .SetFixedLeading(14f)
                                            .SetFontColor(cl_green)
                                            .SetFontSize(10))
                                .SetBorder(Border.NO_BORDER);

                        tableactivity_outer18.AddCell(cellbullet18);
                        tableactivity_outer18.AddCell(celltxt18);

                        document.Add(tableactivity_outer18);
                        document.Add(txt);

                        

                        float indentmargin_spanning8=document.GetLeftMargin()+74;
                        Table tableactivity_spanning8 = new Table(UnitValue.CreatePercentArray(new float[]{35, 20, 27, 18}), false)
                            .SetWidth(PageSize.A4.GetWidth()-indentmargin_spanning8)
                            .SetMarginLeft(37)
                            .SetHorizontalAlignment(HorizontalAlignment.LEFT);


                        var DB_Activities_spanning8=_wpOutputActivitiesRepository.GetRecordsByMainRecordId(mainrec.Transaction_Id);

                        DateTime startperiod_spanning8=new DateTime(mainrec.PeriodStartDate.Year, mainrec.PeriodStartDate.Month, 1);
                        DateTime endperiod_spanning8=new DateTime(mainrec.PeriodEndDate.Year , mainrec.PeriodEndDate.Month, DateTime.DaysInMonth(mainrec.PeriodEndDate.Year, mainrec.PeriodEndDate.Month));

                        int actualrecords_spanning8=0;
                        foreach (var activity in DB_Activities_spanning8)
                        {
                            if(IsActivitySpanningMultipleMonthsforOther8(months_in_range, new DateTime(activity.ActivityStartDate.Year, activity.ActivityStartDate.Month, activity.ActivityStartDate.Day), new DateTime(activity.ActivityEndDate.Year, activity.ActivityEndDate.Month, activity.ActivityEndDate.Day), startperiod_spanning8, endperiod_spanning8)==true)
                                actualrecords_spanning8=actualrecords_spanning8+1;
                        }

                        if(actualrecords_spanning8>=1)
                        {
                            //Row Header
                            Cell cellheader01 = new Cell(1, 1)
                            .SetTextAlignment(TextAlignment.LEFT)
                            .Add(new Paragraph("ACTIVITY")
                                            //.SetFont(ft_montserrat_medium)
                                            .SetFixedLeading(14f)
                                            .SetFontColor(cl_grayDark)
                                            .SetBackgroundColor(cl_tableheader)
                                            .SetFontSize(10))
                                .SetBackgroundColor(cl_tableheader);
                            tableactivity_spanning8.AddCell(cellheader01);

                            Cell cellheader02 = new Cell(1, 1)
                                .SetTextAlignment(TextAlignment.LEFT)
                                .Add(new Paragraph("TYPE")
                                                // .SetFont(ft_montserrat_medium)
                                                .SetFixedLeading(14f)
                                                .SetFontColor(cl_grayDark)
                                                .SetBackgroundColor(cl_tableheader)
                                                .SetFontSize(10))
                                .SetBackgroundColor(cl_tableheader);
                            tableactivity_spanning8.AddCell(cellheader02);


                            Cell cellheader03 = new Cell(1, 1)
                                .SetTextAlignment(TextAlignment.LEFT)
                                .Add(new Paragraph("PERIOD")
                                                //.SetFont(ft_montserrat_medium)
                                                .SetFixedLeading(14f)
                                                .SetFontColor(cl_grayDark)
                                                .SetBackgroundColor(cl_tableheader)
                                                .SetFontSize(10))
                                .SetBackgroundColor(cl_tableheader);
                            tableactivity_spanning8.AddCell(cellheader03);

                            Cell cellheader04 = new Cell(1, 1)
                                .SetTextAlignment(TextAlignment.RIGHT)
                                .Add(new Paragraph("AMOUNT (USD)")
                                                //.SetFont(ft_montserrat_medium)
                                                .SetFixedLeading(14f)
                                                .SetFontColor(cl_grayDark)
                                                .SetBackgroundColor(cl_tableheader)
                                                .SetFontSize(10))
                                .SetBackgroundColor(cl_tableheader);

                            tableactivity_spanning8.AddCell(cellheader04);

                            int activitycount8=actualrecords_spanning8;

                            foreach (var activity in DB_Activities_spanning8)
                            {
                                if(IsActivitySpanningMultipleMonthsforOther8(months_in_range, new DateTime(activity.ActivityStartDate.Year, activity.ActivityStartDate.Month, activity.ActivityStartDate.Day), new DateTime(activity.ActivityEndDate.Year, activity.ActivityEndDate.Month, activity.ActivityEndDate.Day), startperiod_spanning8, endperiod_spanning8)==true)
                                {
                                    inneriter=inneriter+1;

                                    Cell cell1 = new Cell(1, 1);
                                    Cell cell2 = new Cell(1, 1);
                                    Cell cell3 = new Cell(1, 1);
                                    Cell cell4 = new Cell(1, 1);

                                    DateTime start= new  DateTime(activity.ActivityStartDate.Year, activity.ActivityStartDate.Month, activity.ActivityStartDate.Day);
                                    DateTime end= new  DateTime(activity.ActivityEndDate.Year, activity.ActivityEndDate.Month, activity.ActivityEndDate.Day);
                                    string period=start.Date.ToString("MMM. d, yyyy")+" - "+end.Date.ToString("MMM. d, yyyy");

                                    if(row_alt==false)
                                    {
                                        //Row Rows
                                        cell1.SetTextAlignment(TextAlignment.LEFT)
                                        .Add(new Paragraph(activity.ActivityDescription)
                                                        // .SetFont(ft_montserrat_reg)
                                                        .SetFixedLeading(14f)
                                                        .SetFontColor(cl_grayDark)
                                                        .SetBackgroundColor(cl_tablecontent_1)
                                                        .SetFontSize(9))
                                            .SetBackgroundColor(cl_tablecontent_1)
                                            .SetBorderTop(Border.NO_BORDER)
                                            .SetBorderBottom(Border.NO_BORDER);


                                    
                                            cell2.SetTextAlignment(TextAlignment.LEFT)
                                            .Add(new Paragraph(_lkupActivityTypeRepository.GetActivityType(activity.ActivityType_Id).Activity_Name)
                                                            // .SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_1)
                                                            .SetFontSize(9))
                                            .SetBackgroundColor(cl_tablecontent_1)
                                            .SetBorderTop(Border.NO_BORDER)
                                            .SetBorderBottom(Border.NO_BORDER);


                                            cell3.SetTextAlignment(TextAlignment.LEFT)
                                            .Add(new Paragraph(period)
                                                            //.SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_1)
                                                            .SetFontSize(9))
                                            .SetBackgroundColor(cl_tablecontent_1)
                                            .SetBorderTop(Border.NO_BORDER)
                                            .SetBorderBottom(Border.NO_BORDER);



                                        cell4.SetTextAlignment(TextAlignment.RIGHT)
                                            .Add(new Paragraph(string.Format("{0:N2}", activity.ActivityCost))
                                                            //.SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_1)
                                                            .SetFontSize(9))
                                            .SetBackgroundColor(cl_tablecontent_1)
                                            .SetBorderTop(Border.NO_BORDER)
                                            .SetBorderBottom(Border.NO_BORDER);
                                    }
                                    else
                                    {
                                        //Row Rows

                                        cell1.SetTextAlignment(TextAlignment.LEFT)
                                            .Add(new Paragraph(activity.ActivityDescription)
                                                            // .SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_2)
                                                            .SetFontSize(9))
                                                .SetBackgroundColor(cl_tablecontent_2)
                                                .SetBorderTop(Border.NO_BORDER)
                                                .SetBorderBottom(Border.NO_BORDER);



                                        cell2.SetTextAlignment(TextAlignment.LEFT)
                                            .Add(new Paragraph(_lkupActivityTypeRepository.GetActivityType(activity.ActivityType_Id).Activity_Name)
                                                            //.SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_2)
                                                            .SetFontSize(9))
                                            .SetBackgroundColor(cl_tablecontent_2)
                                            .SetBorderTop(Border.NO_BORDER)
                                            .SetBorderBottom(Border.NO_BORDER);


                                        cell3.SetTextAlignment(TextAlignment.LEFT)
                                            .Add(new Paragraph(period)
                                                            // .SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_2)
                                                            .SetFontSize(9))
                                            .SetBackgroundColor(cl_tablecontent_2)
                                            .SetBorderTop(Border.NO_BORDER)
                                            .SetBorderBottom(Border.NO_BORDER);
        


                                        cell4.SetTextAlignment(TextAlignment.RIGHT)
                                            .Add(new Paragraph(string.Format("{0:N2}", activity.ActivityCost))
                                                            // .SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_2)
                                                            .SetFontSize(9))
                                            .SetBackgroundColor(cl_tablecontent_2)
                                            .SetBorderTop(Border.NO_BORDER)
                                            .SetBorderBottom(Border.NO_BORDER);
                                        

                                    }

                                    row_alt=ToggleBoolean(row_alt);
                                    if(inneriter==activitycount8)
                                    {
                                        cell1.SetBorderBottom(new SolidBorder(1f));
                                        cell2.SetBorderBottom(new SolidBorder(1f));
                                        cell3.SetBorderBottom(new SolidBorder(1f));
                                        cell4.SetBorderBottom(new SolidBorder(1f));

                                    }

                                    tableactivity_spanning8.AddCell(cell1);
                                    tableactivity_spanning8.AddCell(cell2);
                                    tableactivity_spanning8.AddCell(cell3);   
                                    tableactivity_spanning8.AddCell(cell4);

                                }

                            }
                            inneriter=0;
                            row_alt=true;
                            document.Add(tableactivity_spanning8);




                        }
                        document.Add(txt);
                        document.Add(txt);

                        float indentmargin_outer28=document.GetLeftMargin()+49;
                            Table tableactivity_outer28= new Table(UnitValue.CreatePercentArray(new float[]{4, 96}), false)
                                                .SetWidth(PageSize.A4.GetWidth()-indentmargin_outer28)
                                                .SetMarginLeft(14)
                                                .SetHorizontalAlignment(HorizontalAlignment.LEFT);

                                Cell cellbullet28 = new Cell(1, 1)
                                .SetTextAlignment(TextAlignment.LEFT)
                                .Add(new Paragraph("\ue837")
                                                .SetFont(ft_materialicons_fonts)
                                                .SetFixedLeading(14f)
                                                .SetFontColor(cl_green)
                                                .SetFontSize(10))
                                    .SetBorder(Border.NO_BORDER);

                                Cell celltxt28= new Cell(1, 1)
                                .SetTextAlignment(TextAlignment.JUSTIFIED)
                                .Add(new Paragraph("Activities Outside of Workplan Period")
                                                .SetFixedLeading(14f)
                                                .SetFontColor(cl_green)
                                                .SetFontSize(10))
                                    .SetBorder(Border.NO_BORDER);

                            tableactivity_outer28.AddCell(cellbullet28);
                            tableactivity_outer28.AddCell(celltxt28);

                            document.Add(tableactivity_outer28);
                            document.Add(txt);

                             float indentmargin_outside28=document.GetLeftMargin()+74;
                            Table tableactivity_outside28 = new Table(UnitValue.CreatePercentArray(new float[]{35, 20, 27, 18}), false)
                                .SetWidth(PageSize.A4.GetWidth()-indentmargin_outside28)
                                .SetMarginLeft(37)
                                .SetHorizontalAlignment(HorizontalAlignment.LEFT);


                            var DB_Activities_outside28=_wpOutputActivitiesRepository.GetRecordsByMainRecordId(mainrec.Transaction_Id);

                            DateTime startperiod_outside28=new DateTime(mainrec.PeriodStartDate.Year, mainrec.PeriodStartDate.Month, 1);
                            DateTime endperiod_outside28=new DateTime(mainrec.PeriodEndDate.Year , mainrec.PeriodEndDate.Month, DateTime.DaysInMonth(mainrec.PeriodEndDate.Year , mainrec.PeriodEndDate.Month));

                            int actualrecords_outside28=0;
                            foreach (var activity in DB_Activities_outside28)
                            {
                                if(IsActivityOutsideWPPeriod(new DateTime(activity.ActivityStartDate.Year, activity.ActivityStartDate.Month, activity.ActivityStartDate.Day), new DateTime(activity.ActivityEndDate.Year, activity.ActivityEndDate.Month, activity.ActivityEndDate.Day), startperiod_outside28, endperiod_outside28)==true)
                                    actualrecords_outside28=actualrecords_outside28+1;
                            }

                            if(actualrecords_outside28>=1)
                            {
                                //Row Header
                                Cell cellheader01 = new Cell(1, 1)
                                .SetTextAlignment(TextAlignment.LEFT)
                                .Add(new Paragraph("ACTIVITY")
                                                //.SetFont(ft_montserrat_medium)
                                                .SetFixedLeading(14f)
                                                .SetFontColor(cl_grayDark)
                                                .SetBackgroundColor(cl_tableheader)
                                                .SetFontSize(10))
                                    .SetBackgroundColor(cl_tableheader);

                                tableactivity_outside28.AddCell(cellheader01);

                                Cell cellheader02 = new Cell(1, 1)
                                    .SetTextAlignment(TextAlignment.LEFT)
                                    .Add(new Paragraph("TYPE")
                                                   // .SetFont(ft_montserrat_medium)
                                                    .SetFixedLeading(14f)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tableheader)
                                                    .SetFontSize(10))
                                    .SetBackgroundColor(cl_tableheader);

                                tableactivity_outside28.AddCell(cellheader02);


                                Cell cellheader03 = new Cell(1, 1)
                                    .SetTextAlignment(TextAlignment.LEFT)
                                    .Add(new Paragraph("PERIOD")
                                                   // .SetFont(ft_montserrat_medium)
                                                    .SetFixedLeading(14f)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tableheader)
                                                    .SetFontSize(10))
                                    .SetBackgroundColor(cl_tableheader);
                                tableactivity_outside28.AddCell(cellheader03);

                                Cell cellheader04 = new Cell(1, 1)
                                    .SetTextAlignment(TextAlignment.RIGHT)
                                    .Add(new Paragraph("AMOUNT (USD)")
                                                   // .SetFont(ft_montserrat_medium)
                                                    .SetFixedLeading(14f)
                                                    .SetFontColor(cl_grayDark)
                                                    .SetBackgroundColor(cl_tableheader)
                                                    .SetFontSize(10))
                                    .SetBackgroundColor(cl_tableheader);

                                tableactivity_outside28.AddCell(cellheader04);

                                int activitycount=actualrecords_outside28;

                                foreach (var activity in DB_Activities_outside28)
                                {
                                    if(IsActivityOutsideWPPeriod(new DateTime(activity.ActivityStartDate.Year, activity.ActivityStartDate.Month, activity.ActivityStartDate.Day), new DateTime(activity.ActivityEndDate.Year, activity.ActivityEndDate.Month, activity.ActivityEndDate.Day), startperiod_outside28, endperiod_outside28)==true)
                                    {
                                        inneriter=inneriter+1;

                                        Cell cell1 = new Cell(1, 1);
                                        Cell cell2 = new Cell(1, 1);
                                        Cell cell3 = new Cell(1, 1);
                                        Cell cell4 = new Cell(1, 1);

                                        DateTime start= new  DateTime(activity.ActivityStartDate.Year, activity.ActivityStartDate.Month, activity.ActivityStartDate.Day);
                                        DateTime end= new  DateTime(activity.ActivityEndDate.Year, activity.ActivityEndDate.Month, activity.ActivityEndDate.Day);
                                        string period=start.Date.ToString("MMM. d, yyyy")+" - "+end.Date.ToString("MMM. d, yyyy");

                                        if(row_alt==false)
                                        {
                                            //Row Rows
                                            cell1.SetTextAlignment(TextAlignment.LEFT)
                                            .Add(new Paragraph(activity.ActivityDescription)
                                                            //.SetFont(ft_montserrat_reg)
                                                            .SetFixedLeading(14f)
                                                            .SetFontColor(cl_grayDark)
                                                            .SetBackgroundColor(cl_tablecontent_1)
                                                            .SetFontSize(9))
                                                .SetBackgroundColor(cl_tablecontent_1)
                                                .SetBorderTop(Border.NO_BORDER)
                                                .SetBorderBottom(Border.NO_BORDER);


                                        
                                                cell2.SetTextAlignment(TextAlignment.LEFT)
                                                .Add(new Paragraph(_lkupActivityTypeRepository.GetActivityType(activity.ActivityType_Id).Activity_Name)
                                                                //.SetFont(ft_montserrat_reg)
                                                                .SetFixedLeading(14f)
                                                                .SetFontColor(cl_grayDark)
                                                                .SetBackgroundColor(cl_tablecontent_1)
                                                                .SetFontSize(9))
                                                .SetBackgroundColor(cl_tablecontent_1)
                                                .SetBorderTop(Border.NO_BORDER)
                                                .SetBorderBottom(Border.NO_BORDER);


                                                cell3.SetTextAlignment(TextAlignment.LEFT)
                                                .Add(new Paragraph(period)
                                                                //.SetFont(ft_montserrat_reg)
                                                                .SetFixedLeading(14f)
                                                                .SetFontColor(cl_grayDark)
                                                                .SetBackgroundColor(cl_tablecontent_1)
                                                                .SetFontSize(9))
                                                .SetBackgroundColor(cl_tablecontent_1)
                                                .SetBorderTop(Border.NO_BORDER)
                                                .SetBorderBottom(Border.NO_BORDER);


                                            cell4.SetTextAlignment(TextAlignment.RIGHT)
                                                .Add(new Paragraph(string.Format("{0:N2}", activity.ActivityCost))
                                                                //.SetFont(ft_montserrat_reg)
                                                                .SetFixedLeading(14f)
                                                                .SetFontColor(cl_grayDark)
                                                                .SetBackgroundColor(cl_tablecontent_1)
                                                                .SetFontSize(9))
                                                .SetBackgroundColor(cl_tablecontent_1)
                                                .SetBorderTop(Border.NO_BORDER)
                                                .SetBorderBottom(Border.NO_BORDER);


                                        }
                                        else
                                        {
                                            //Row Rows

                                            cell1.SetTextAlignment(TextAlignment.LEFT)
                                                .Add(new Paragraph(activity.ActivityDescription)
                                                                //.SetFont(ft_montserrat_reg)
                                                                .SetFixedLeading(14f)
                                                                .SetFontColor(cl_grayDark)
                                                                .SetBackgroundColor(cl_tablecontent_2)
                                                                .SetFontSize(9))
                                                    .SetBackgroundColor(cl_tablecontent_2)
                                                    .SetBorderTop(Border.NO_BORDER)
                                                    .SetBorderBottom(Border.NO_BORDER);



                                            cell2.SetTextAlignment(TextAlignment.LEFT)
                                                .Add(new Paragraph(_lkupActivityTypeRepository.GetActivityType(activity.ActivityType_Id).Activity_Name)
                                                                //.SetFont(ft_montserrat_reg)
                                                                .SetFixedLeading(14f)
                                                                .SetFontColor(cl_grayDark)
                                                                .SetBackgroundColor(cl_tablecontent_2)
                                                                .SetFontSize(9))
                                                .SetBackgroundColor(cl_tablecontent_2)
                                                .SetBorderTop(Border.NO_BORDER)
                                                .SetBorderBottom(Border.NO_BORDER);



                                            cell3.SetTextAlignment(TextAlignment.LEFT)
                                                .Add(new Paragraph(period)
                                                                //.SetFont(ft_montserrat_reg)
                                                                .SetFixedLeading(14f)
                                                                .SetFontColor(cl_grayDark)
                                                                .SetBackgroundColor(cl_tablecontent_2)
                                                                .SetFontSize(9))
                                                .SetBackgroundColor(cl_tablecontent_2)
                                                .SetBorderTop(Border.NO_BORDER)
                                                .SetBorderBottom(Border.NO_BORDER);


                                            cell4.SetTextAlignment(TextAlignment.RIGHT)
                                                .Add(new Paragraph(string.Format("{0:N2}", activity.ActivityCost))
                                                                //.SetFont(ft_montserrat_reg)
                                                                .SetFixedLeading(14f)
                                                                .SetFontColor(cl_grayDark)
                                                                .SetBackgroundColor(cl_tablecontent_2)
                                                                .SetFontSize(9))
                                                .SetBackgroundColor(cl_tablecontent_2)
                                                .SetBorderTop(Border.NO_BORDER)
                                                .SetBorderBottom(Border.NO_BORDER);

                                        }

                                        row_alt=ToggleBoolean(row_alt);
                                        if(inneriter==activitycount)
                                        {
                                            cell1.SetBorderBottom(new SolidBorder(1f));
                                            cell2.SetBorderBottom(new SolidBorder(1f));
                                            cell3.SetBorderBottom(new SolidBorder(1f));
                                            cell4.SetBorderBottom(new SolidBorder(1f));

                                        }

                                        tableactivity_outside28.AddCell(cell1);
                                        tableactivity_outside28.AddCell(cell2);
                                        tableactivity_outside28.AddCell(cell3);   
                                        tableactivity_outside28.AddCell(cell4);

                                    }

                                }
                                inneriter=0;
                                row_alt=true;
                                document.Add(tableactivity_outside28);




                            }




                    
                    break;

                }
                                    
       




                

                 document.Close();

                 return workStream;


        }
        List<string> MonthNames(DateTime date1, DateTime date2)
        {
            var monthList = new List<string>();

            while (date1 < date2)
            {
                monthList.Add(date1.ToString("MMMM/yyyy"));
                date1 = date1.AddMonths(1);
            }

            return monthList;
        }

        List<MonthAndYear> GetMonthsInPeriodRange(DateTime date1, DateTime date2)
        {
            var monthList = new List<MonthAndYear>();

            while (date1 < date2)
            {
                MonthAndYear rec=new MonthAndYear();
                rec.PMonth=Int32.Parse(date1.ToString("MM"));
                rec.PYear=Int32.Parse(date1.ToString("yyyy"));

                monthList.Add(rec);
                date1 = date1.AddMonths(1);
            }

            return monthList;
        }



        public bool WithinMonth(int year, int month, DateTime start, DateTime end)
        {
            DateTime monthstart=new DateTime(Int32.Parse(_lkupFiscalYearRepository.GetRecord(year).Record_Name) , month, 1);
            DateTime monthend=new DateTime(Int32.Parse(_lkupFiscalYearRepository.GetRecord(year).Record_Name) , month, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(year).Record_Name), month));

            return start >= monthstart && end <= monthend;
        }
        public bool WithinMonthforOther8(int year, int month, DateTime start, DateTime end)
        {
            DateTime monthstart=new DateTime(year, month, 1);
            DateTime monthend=new DateTime(year, month, DateTime.DaysInMonth(year, month));

            return start >= monthstart && end <= monthend;
        }
        //IsActivitySpanningMultipleMonthsforOther8

        public bool IsActivitySpanningMultipleMonthsforOther8(List<MonthAndYear>  months, DateTime start, DateTime end, DateTime startperiod, DateTime endsperiod )
        {
            bool rtnval=true;

            bool withinperiod=start >= startperiod && end <= endsperiod;

            if(withinperiod)
            {
                foreach (var i in months)
                {
                    if(WithinMonthforOther8(i.PYear,i.PMonth, start, end))
                        rtnval=false;
                }

            }
            else
            {
                rtnval=false;
            }


            return rtnval;
        }
        public bool IsActivitySpanningMultipleMonths(int year, int[] months, DateTime start, DateTime end, DateTime startperiod, DateTime endsperiod )
        {
            bool rtnval=true;

            bool withinperiod=start >= startperiod && end <= endsperiod;

            if(withinperiod)
            {
                foreach (var i in months)
                {
                    if(WithinMonth(year,i, start, end))
                        rtnval=false;
                }

            }
            else
            {
                rtnval=false;
            }


            return rtnval;
        }

        public bool IsActivityOutsideWPPeriod(DateTime start, DateTime end, DateTime startperiod, DateTime endsperiod )
        {
            bool rtnval=true;

            bool withinperiod=start >= startperiod && end <= endsperiod;

            if(withinperiod)
            {
                rtnval=false;
            }
            else
            {
                rtnval=true;
            }


            return rtnval;
        }
        public bool ToggleBoolean(bool val)
        {
            bool rtnval=true;
            if(val==true)
                rtnval= false;
            else if(val==false)
                rtnval=true;

            return rtnval;

        }
     
        protected internal class MyEventHandler : IEventHandler {
            public virtual void HandleEvent(Event @event) {
                PdfDocumentEvent docEvent = (PdfDocumentEvent)@event;
                PdfDocument pdfDoc = docEvent.GetDocument();
                PdfPage page = docEvent.GetPage();
                int pageNumber = pdfDoc.GetPageNumber(page);
                Rectangle pageSize = page.GetPageSize();
                PdfCanvas pdfCanvas = new PdfCanvas(page.NewContentStreamBefore(), page.GetResources(), pdfDoc);

                //Add header and footer
                string fontpath = @"wwwroot/reports/fonts/FaktSlabPro-Blond.ttf";
                PdfFont ft = PdfFontFactory.CreateFont(fontpath, PdfEncodings.WINANSI, true);
                if(pageNumber==1)
                {
                    pdfCanvas.BeginText()
                    .SetFontAndSize(ft, 11)

                    //.MoveText(pageSize.GetWidth() / 2 - 60, pageSize.GetTop() - 20)
                    .MoveText(pageSize.GetWidth() -70, pageSize.GetTop() - 20)
                    .ShowText("")
                    //.ShowText("Page "+pageNumber.ToString())
                   // .MoveText(60, -pageSize.GetTop() + 40)

                   .SetFontAndSize(ft, 9)

                    .MoveText(pageSize.GetWidth() / 2 -760, -pageSize.GetTop() + 40)
                    .ShowText("230, 15th Road, Midrand, Gauteng, Johannesburg, 1685, South Africa | Tel +27 (0) 11 256 3600 | www.nepad.org")
                    

                   // .NewlineText()
                    //.ShowText("Page "+pageNumber.ToString())
                    .EndText();
                }
                else
                {
                    pdfCanvas.BeginText()
                    .SetFontAndSize(ft, 11)
                    .MoveText(pageSize.GetWidth() -70, pageSize.GetTop() - 20)
                    .ShowText("Page "+pageNumber.ToString())

                    .SetFontAndSize(ft, 9)

                    .MoveText(pageSize.GetWidth() / 2 -760, -pageSize.GetTop() + 40)
                    .ShowText("230, 15th Road, Midrand, Gauteng, Johannesburg, 1685, South Africa | Tel +27 (0) 11 256 3600 | www.nepad.org")

                    .EndText();

                }
            }
            internal MyEventHandler(NEPADStaffController _enclosing) {
                this._enclosing = _enclosing;
            }
            private readonly NEPADStaffController _enclosing;
        }

        protected internal class MyEventHandlerA3 : IEventHandler {
            public virtual void HandleEvent(Event @event) {
                PdfDocumentEvent docEvent = (PdfDocumentEvent)@event;
                PdfDocument pdfDoc = docEvent.GetDocument();
                PdfPage page = docEvent.GetPage();
                int pageNumber = pdfDoc.GetPageNumber(page);
                Rectangle pageSize = page.GetPageSize();
                PdfCanvas pdfCanvas = new PdfCanvas(page.NewContentStreamBefore(), page.GetResources(), pdfDoc);

                //Add header and footer
                string fontpath = @"wwwroot/reports/fonts/FaktSlabPro-Blond.ttf";
                PdfFont ft = PdfFontFactory.CreateFont(fontpath, PdfEncodings.WINANSI, true);
                if(pageNumber==1)
                {
                    pdfCanvas.BeginText()
                    .SetFontAndSize(ft, 11)

                    //.MoveText(pageSize.GetWidth() / 2 - 60, pageSize.GetTop() - 20)
                    .MoveText(pageSize.GetWidth() -70, pageSize.GetTop() - 20)
                    .ShowText("")
                    //.ShowText("Page "+pageNumber.ToString())
                   // .MoveText(60, -pageSize.GetTop() + 40)

                   .SetFontAndSize(ft, 9)

                    .MoveText(pageSize.GetWidth() / 2 -1340, -pageSize.GetTop() + 40)
                    .ShowText("230, 15th Road, Midrand, Gauteng, Johannesburg, 1685, South Africa | Tel +27 (0) 11 256 3600 | www.nepad.org")
                    

                   // .NewlineText()
                    //.ShowText("Page "+pageNumber.ToString())
                    .EndText();
                }
                else
                {
                    pdfCanvas.BeginText()
                    .SetFontAndSize(ft, 11)
                    .MoveText(pageSize.GetWidth() -70, pageSize.GetTop() - 20)
                    .ShowText("Page "+pageNumber.ToString())

                    .SetFontAndSize(ft, 9)

                    .MoveText(pageSize.GetWidth() / 2 -1340, -pageSize.GetTop() + 40)
                    .ShowText("230, 15th Road, Midrand, Gauteng, Johannesburg, 1685, South Africa | Tel +27 (0) 11 256 3600 | www.nepad.org")

                    .EndText();

                }
            }
            internal MyEventHandlerA3(NEPADStaffController _enclosing) {
                this._enclosing = _enclosing;
            }
            private readonly NEPADStaffController _enclosing;
        }



        protected internal class MyEventHandlerA3Portrait : IEventHandler {
            public virtual void HandleEvent(Event @event) {
                PdfDocumentEvent docEvent = (PdfDocumentEvent)@event;
                PdfDocument pdfDoc = docEvent.GetDocument();
                PdfPage page = docEvent.GetPage();
                int pageNumber = pdfDoc.GetPageNumber(page);
                Rectangle pageSize = page.GetPageSize();
                PdfCanvas pdfCanvas = new PdfCanvas(page.NewContentStreamBefore(), page.GetResources(), pdfDoc);

                //Add header and footer
                string fontpath = @"wwwroot/reports/fonts/FaktSlabPro-Blond.ttf";
                PdfFont ft = PdfFontFactory.CreateFont(fontpath, PdfEncodings.WINANSI, true);
                if(pageNumber==1)
                {
                    pdfCanvas.BeginText()
                    .SetFontAndSize(ft, 11)

                    //.MoveText(pageSize.GetWidth() / 2 - 60, pageSize.GetTop() - 20)
                    .MoveText(pageSize.GetWidth()-70, pageSize.GetTop() - 20)
                    .ShowText("")
                    //.ShowText("Page "+pageNumber.ToString())
                   // .MoveText(60, -pageSize.GetTop() + 40)

                   .SetFontAndSize(ft, 9)

                    .MoveText(pageSize.GetWidth() / 2 -1000, -pageSize.GetTop() + 40)
                    .ShowText("230, 15th Road, Midrand, Gauteng, Johannesburg, 1685, South Africa | Tel +27 (0) 11 256 3600 | www.nepad.org")
                    

                   // .NewlineText()
                    //.ShowText("Page "+pageNumber.ToString())
                    .EndText();
                }
                else
                {
                    pdfCanvas.BeginText()
                    .SetFontAndSize(ft, 11)
                    .MoveText(pageSize.GetWidth() -70, pageSize.GetTop() - 20)
                    .ShowText("Page "+pageNumber.ToString())

                    .SetFontAndSize(ft, 9)

                    .MoveText(pageSize.GetWidth() / 2 -1000, -pageSize.GetTop() + 40)
                    .ShowText("230, 15th Road, Midrand, Gauteng, Johannesburg, 1685, South Africa | Tel +27 (0) 11 256 3600 | www.nepad.org")

                    .EndText();

                }
            }
            internal MyEventHandlerA3Portrait (NEPADStaffController _enclosing) {
                this._enclosing = _enclosing;
            }
            private readonly NEPADStaffController _enclosing;
        }
        
        public ActionResult GenerateDrateActivityReportPDF(string id)
        {

            string contentType = "application/pdf";
            WP_MainRecord mainrec=_wpMainRecordRepository.GetRecord(id);

            MemoryStream workStream=GetMemoryStreamActivityPlan(mainrec);
        

            byte[] byte1 = workStream.ToArray();


            return new FileContentResult(byte1, contentType);
        }

        public ActionResult GenerateInstitutionalWorkplanDraftPDF(string cycleid)
        {

            string contentType = "application/pdf";
            WP_DispatchCycle cyclerec=_wpDispatchCycleRepository.GetRecord(cycleid);

            MemoryStream workStream=GetMemoryInstitutionalWorkplanDraft(cyclerec);
        

            byte[] byte1 = workStream.ToArray();


            return new FileContentResult(byte1, contentType);
        }

        public ActionResult GenerateDrateActivityReportPDF2(string id)
        {

            string contentType = "application/pdf";
            WP_MainRecord mainrec=_wpMainRecordRepository.GetRecord(id);


                            MemoryStream workStream = new MemoryStream();

                PdfWriter writer = new PdfWriter(workStream);
                PdfDocument pdf = new PdfDocument(writer);
                Document document = new Document(pdf);

                                Paragraph header = new Paragraph("HEADER")
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetFontSize(20);


                 document.Add(header);
                 document.Close();

                 byte[] byte1 = workStream.ToArray();

                // Response.AddHeader("Content-Disposition", "inline; filename=test.pdf");

                return new FileContentResult(byte1, contentType);


          // return File(byte1, contentType, _lkupProjectRepository.GetRecord(mainrec.Project_Id).Record_Name + "_" 
                                       // + _lkupFiscalYearRepository.GetRecord(mainrec.FiscalYear_Id).Record_Name +"_"+ 
                                         // _lkupPeriodRepository.GetRecord(mainrec.Period_Id).Record_Name+".pdf");

                // var fileResult = new FileContentResult(byte1, contentType);
                // fileResult.FileDownloadName=_lkupProjectRepository.GetRecord(mainrec.Project_Id).Record_Name + "_" 
                //                        + _lkupFiscalYearRepository.GetRecord(mainrec.FiscalYear_Id).Record_Name +"_"+ 
                //                          _lkupPeriodRepository.GetRecord(mainrec.Period_Id).Record_Name+".pdf";

                // return fileResult;

        }

        public MemoryStream GetActivityReport_PDF(WP_MainRecord rec)
        {
                MemoryStream workStream = new MemoryStream();

                PdfWriter writer = new PdfWriter(workStream);
                PdfDocument pdf = new PdfDocument(writer);
                Document document = new Document(pdf);

                

                Paragraph header = new Paragraph("HEADER")
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetFontSize(20);


                 document.Add(header);
                 document.Close();

                 return workStream;



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


        public async Task<ActionResult> ManageWorkplansDraft(string divid, string progid, string projid, string yearid, string periodid, string periodtxt)
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
            
            WP_MainRecord wp_mainrec_check=null;

            if(Int32.Parse(periodid)==8)
            {
                 var DB_Records8 =  _wpMainRecordRepository.GetRecordsByProjectYearAndPeriodRecs(Int32.Parse(projid), Int32.Parse(yearid), Int32.Parse(periodid));

                int _countrecs =  DB_Records8.Count();
                if(_countrecs>0)
                {
                    foreach (var rec in DB_Records8)
                    {
                        DateTime pstart=new DateTime(rec.PeriodStartDate.Year, rec.PeriodStartDate.Month, rec.PeriodStartDate.Day);
                        DateTime pend=new DateTime(rec.PeriodEndDate.Year, rec.PeriodEndDate.Month, rec.PeriodEndDate.Day);
                        string periodinmain=pstart.Date.ToString("MMMM dd, yyyy") + " - "+ pend.Date.ToString("MMMM dd, yyyy"); 

                        if(periodinmain==periodtxt)
                           wp_mainrec_check=rec;
                    }
                }

            }
            else
            {
               wp_mainrec_check=_wpMainRecordRepository.GetRecordByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(yearid), Int32.Parse(periodid));
            }

            
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
                FisPeriod=periodtxt,
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

          //  WP_MainRecord wp_mainrec=_wpMainRecordRepository.GetRecordByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(yearid), Int32.Parse(periodid));

            WP_MainRecord wp_mainrec=null;

            if(Int32.Parse(periodid)==8)
            {
                 var DB_Records8 =  _wpMainRecordRepository.GetRecordsByProjectYearAndPeriodRecs(Int32.Parse(projid), Int32.Parse(yearid), Int32.Parse(periodid));

                int _countrecs =  DB_Records8.Count();
                if(_countrecs>0)
                {
                    foreach (var rec in DB_Records8)
                    {
                        DateTime pstart=new DateTime(rec.PeriodStartDate.Year, rec.PeriodStartDate.Month, rec.PeriodStartDate.Day);
                        DateTime pend=new DateTime(rec.PeriodEndDate.Year, rec.PeriodEndDate.Month, rec.PeriodEndDate.Day);
                        string periodinmain=pstart.Date.ToString("MMMM dd, yyyy") + " - "+ pend.Date.ToString("MMMM dd, yyyy"); 

                        if(periodinmain==periodtxt)
                           wp_mainrec=rec;
                    }
                }

            }
            else
            {
               wp_mainrec=_wpMainRecordRepository.GetRecordByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(yearid), Int32.Parse(periodid));
            }

            if(wp_mainrec!=null)
                emp_view.WPMainRecordId=wp_mainrec.Transaction_Id;
            else
                emp_view.WPMainRecordId="";

            //Selected Country Scope Read
            List<DropDownListViewModel> collection_recs = new List<DropDownListViewModel>();
            var DB_Recs =  _wpCountryScopeRepository.GetRecordsByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(yearid), Int32.Parse(periodid));
            
            if(wp_mainrec!=null)
                DB_Recs =  _wpCountryScopeRepository.GetRecordsByMainRecordId(wp_mainrec.Transaction_Id);
            else
                DB_Recs=_wpCountryScopeRepository.GetRecordsByMainRecordId("Null");


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

            if(wp_mainrec!=null)
                DB_Records =  _wpRegionScopeRepository.GetRecordsByMainRecordId(wp_mainrec.Transaction_Id);
            else
                DB_Records=_wpRegionScopeRepository.GetRecordsByMainRecordId("Null");
            
            
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

        public async Task<ActionResult> InstitutionalWorkplanDraftList()
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

        public async Task<ActionResult> AddDivisionKPI()
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            DivisionKPIsViewModel model = new DivisionKPIsViewModel
            {
                Employee_Id=user.Employee_Id
            };

            return PartialView("_AddDivisionKPI", model);
        }

        public async Task<ActionResult> EditDivisionKPI(string transid)
        {
            var user = await userManager.GetUserAsync(HttpContext.User);

            Trans_StrucDirDivIndicators rec=_transStrucDirDivIndicatorsRepository.GetRecord(transid);
            DivisionKPIsViewModel model = new DivisionKPIsViewModel
            {
                Transaction_Id=transid,
                Record_Id=rec.Record_Id,
                Employee_Id=user.Employee_Id,
                Directorate_Ident=rec.Directorate_Id,
                Division_Ident=rec.Division_Id,
                Division_Ident_Old=rec.Division_Id,
                Division_Name=_strucDivisionRepository.GetRecord(rec.Division_Id).Record_Name,
                Record_Name=rec.Record_Name,
                Record_Name_Old=rec.Record_Name,
                Indicator_Type_Ident=rec.Indicator_Type_Id,
                Indicator_Type_Ident_Old=rec.Indicator_Type_Id,
                Indicator_Type=_lkupIndicatorTypeRepository.GetRecord(rec.Indicator_Type_Id).Record_Name


            };

            return PartialView("_EditDivisionKPI", model);
        }


        public async Task<ActionResult> EditWorkplanCycle(string transid, DateTime pstart, DateTime pend)
        {
            WP_DispatchCycle rec = _wpDispatchCycleRepository.GetRecord(transid);
            var user = await userManager.GetUserAsync(HttpContext.User);

           // DateTime PeriodStart = DateTime.Parse(pstart);
           // DateTime PeriodEnd = DateTime.Parse(pend);

            WorkplansViewModel model = new WorkplansViewModel
            {
                Transaction_Id=rec.Transaction_Id,
                Employee_Id = user.Employee_Id,
                FYearIdent=rec.FiscalYear_Id,
                FPeriodIdent =rec.Period_Id,
                FisYear=_lkupFiscalYearRepository.GetRecord(rec.FiscalYear_Id).Record_Name
                //FisPeriod=_lkupPeriodRepository.GetRecord(rec.Period_Id).Record_Name
            };
            if(rec.Period_Id==8)
            {
                model.FisPeriod=pstart.Date.ToString("MMMM dd, yyyy") + " - "+ pend.Date.ToString("MMMM dd, yyyy"); 
            }
            else
            {
                model.FisPeriod=_lkupPeriodRepository.GetRecord(rec.Period_Id).Record_Name;
            }



            if( rec.Dispatch_Status==null)
                model.WPStatus=false;
            else
                model.WPStatus=rec.Dispatch_Status.Value;

            if( rec.LinkToSAPExecution==null)
                model.WPSAPLinkView=false;
            else
                model.WPSAPLinkView=rec.LinkToSAPExecution.Value;


            PopulateCategories();

            PopulateDirectorates();

            return PartialView("_EditWorkplanCycle", model);
        }


        

        private void PopulateCategories()
        {


            var emp_recs =  _employeeRepository.GetAllEmployee().ToList();

            List<CategoryViewModel> categories = new List<CategoryViewModel>();

            foreach (var rec in emp_recs)
            {
                CategoryViewModel srec = new CategoryViewModel
                {
                        CategoryID = rec.Id,
                        CategoryName = rec.First_Name+" "+rec.Last_Name
                };
                categories.Add(srec);
  
            }
            ViewData["categories"] = categories.OrderBy(e => e.CategoryName).ToList();
            ViewData["defaultCategory"] = categories.OrderBy(e => e.CategoryName).First();

        }

        private void PopulateDirectorates()
        {


            var dir_recs =  _transStrucDirectorateRepository.GetAllRecords().ToList();

            List<CategoryViewModel> categories = new List<CategoryViewModel>();

            foreach (var rec in dir_recs)
            {
                var directorate =_strucDirectorateRepository.GetRecord(rec.Record_Id);

                CategoryViewModel srec = new CategoryViewModel
                {
                        CategoryID = directorate.Record_Id,
                        CategoryName = directorate.Record_Name
                };
                categories.Add(srec);
  
            }
            ViewData["directorates"] = categories.OrderBy(e => e.CategoryName).ToList();
            ViewData["defaultDirectorate"] = categories.OrderBy(e => e.CategoryName).First();

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
            
            WP_OutcomeOutputIndicatorsVM model = new WP_OutcomeOutputIndicatorsVM
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


        public async Task<ActionResult> AddOutcomeIndicator(string transid)
        {
            WP_Outcomes rec = _wpOutcomesRepository.GetRecord(transid);
            var user = await userManager.GetUserAsync(HttpContext.User);
            
            WP_OutcomeOutputIndicatorsVM model = new WP_OutcomeOutputIndicatorsVM
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



            return PartialView("_AddOutcomeIndicator", model);
        }


        public async Task<ActionResult> AddOutputActivity(string transid)
        {
            WP_Outputs rec = _wpOutputsRepository.GetRecord(transid);
            var user = await userManager.GetUserAsync(HttpContext.User);
            
            WP_MainRecord mainrecord=_wpMainRecordRepository.GetRecord(rec.WPMainRecord_id);
            string periodinmain="";

            DateTime pmonthstart=DateTime.Today;
            DateTime pmonthend=DateTime.Today;

            if(mainrecord.Period_Id==8)
            {
                DateTime pstart=new DateTime(mainrecord.PeriodStartDate.Year, mainrecord.PeriodStartDate.Month, mainrecord.PeriodStartDate.Day);
                DateTime pend=new DateTime(mainrecord.PeriodEndDate.Year, mainrecord.PeriodEndDate.Month, mainrecord.PeriodEndDate.Day);
                periodinmain=pstart.Date.ToString("MMMM dd, yyyy") + " - "+ pend.Date.ToString("MMMM dd, yyyy"); 

                pmonthstart=new DateTime(mainrecord.PeriodStartDate.Year , mainrecord.PeriodStartDate.Month, 1);
                pmonthend=new DateTime(mainrecord.PeriodEndDate.Year, mainrecord.PeriodEndDate.Month, DateTime.DaysInMonth(mainrecord.PeriodEndDate.Year, mainrecord.PeriodEndDate.Month));

            }
            else
            {
                periodinmain=_lkupPeriodRepository.GetRecord(mainrecord.Period_Id).Record_Name;

                switch(mainrecord.Period_Id)
                {
                    case 1 :
                        pmonthstart=new DateTime(Int32.Parse(_lkupFiscalYearRepository.GetRecord(mainrecord.FiscalYear_Id).Record_Name),1, 1);
                        pmonthend=new DateTime(Int32.Parse(_lkupFiscalYearRepository.GetRecord(mainrecord.FiscalYear_Id).Record_Name), 3, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(mainrecord.FiscalYear_Id).Record_Name), 3));
                        break;
                    case 2 :
                        pmonthstart=new DateTime(Int32.Parse(_lkupFiscalYearRepository.GetRecord(mainrecord.FiscalYear_Id).Record_Name),4, 1);
                        pmonthend=new DateTime(Int32.Parse(_lkupFiscalYearRepository.GetRecord(mainrecord.FiscalYear_Id).Record_Name), 6, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(mainrecord.FiscalYear_Id).Record_Name), 6));
                        break;
                    case 3 :
                        pmonthstart=new DateTime(Int32.Parse(_lkupFiscalYearRepository.GetRecord(mainrecord.FiscalYear_Id).Record_Name),7, 1);
                        pmonthend=new DateTime(Int32.Parse(_lkupFiscalYearRepository.GetRecord(mainrecord.FiscalYear_Id).Record_Name), 9, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(mainrecord.FiscalYear_Id).Record_Name), 9));
                        break;
                    case 4 :
                        pmonthstart=new DateTime(Int32.Parse(_lkupFiscalYearRepository.GetRecord(mainrecord.FiscalYear_Id).Record_Name),10, 1);
                        pmonthend=new DateTime(Int32.Parse(_lkupFiscalYearRepository.GetRecord(mainrecord.FiscalYear_Id).Record_Name), 12, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(mainrecord.FiscalYear_Id).Record_Name), 12));
                        break;
                    case 5 :
                        pmonthstart=new DateTime(Int32.Parse(_lkupFiscalYearRepository.GetRecord(mainrecord.FiscalYear_Id).Record_Name),1, 1);
                        pmonthend=new DateTime(Int32.Parse(_lkupFiscalYearRepository.GetRecord(mainrecord.FiscalYear_Id).Record_Name), 6, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(mainrecord.FiscalYear_Id).Record_Name), 6));
                        break;
                    case 6 :
                        pmonthstart=new DateTime(Int32.Parse(_lkupFiscalYearRepository.GetRecord(mainrecord.FiscalYear_Id).Record_Name),7, 1);
                        pmonthend=new DateTime(Int32.Parse(_lkupFiscalYearRepository.GetRecord(mainrecord.FiscalYear_Id).Record_Name), 12, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(mainrecord.FiscalYear_Id).Record_Name), 12));
                        break;
                    case 7 :
                        pmonthstart=new DateTime(Int32.Parse(_lkupFiscalYearRepository.GetRecord(mainrecord.FiscalYear_Id).Record_Name),1, 1);
                        pmonthend=new DateTime(Int32.Parse(_lkupFiscalYearRepository.GetRecord(mainrecord.FiscalYear_Id).Record_Name), 12, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(mainrecord.FiscalYear_Id).Record_Name), 12));
                        break;


                }

            }   

            
            WP_OutputActivitiesVM model = new WP_OutputActivitiesVM
            {
                Transaction_IdOAVMMain=rec.Transaction_Id,
                WPMainRecord_idOAVMMain=rec.WPMainRecord_id,
                Employee_IdOAVMMain = user.Employee_Id,
                FiscalYear_IdOAVMMain=rec.FiscalYear_Id,
                Period_IdOAVMMain =rec.Period_Id,
                Project_IdOAVMMain=rec.Project_Id,
                FisYearOAVMMain=_lkupFiscalYearRepository.GetRecord(rec.FiscalYear_Id).Record_Name,
                FisPeriodOAVMMain=periodinmain,
                PeriodStartDate=pmonthstart,
                PeriodEndDate=pmonthend,
                PartnerFundingOAVMMain=false

            };



            return PartialView("_AddOutputActivity", model);
        }


        public async Task<ActionResult> AddOutputMobility(string transid)
        {
            WP_Outputs rec = _wpOutputsRepository.GetRecord(transid);
            var user = await userManager.GetUserAsync(HttpContext.User);
            
            WP_MainRecord mainrecord=_wpMainRecordRepository.GetRecord(rec.WPMainRecord_id);
            string periodinmain="";

            DateTime pmonthstart=DateTime.Today;
            DateTime pmonthend=DateTime.Today;

            if(mainrecord.Period_Id==8)
            {
                DateTime pstart=new DateTime(mainrecord.PeriodStartDate.Year, mainrecord.PeriodStartDate.Month, mainrecord.PeriodStartDate.Day);
                DateTime pend=new DateTime(mainrecord.PeriodEndDate.Year, mainrecord.PeriodEndDate.Month, mainrecord.PeriodEndDate.Day);
                periodinmain=pstart.Date.ToString("MMMM dd, yyyy") + " - "+ pend.Date.ToString("MMMM dd, yyyy"); 

                pmonthstart=new DateTime(mainrecord.PeriodStartDate.Year , mainrecord.PeriodStartDate.Month, 1);
                pmonthend=new DateTime(mainrecord.PeriodEndDate.Year, mainrecord.PeriodEndDate.Month, DateTime.DaysInMonth(mainrecord.PeriodEndDate.Year, mainrecord.PeriodEndDate.Month));

            }
            else
            {
                periodinmain=_lkupPeriodRepository.GetRecord(mainrecord.Period_Id).Record_Name;

                switch(mainrecord.Period_Id)
                {
                    case 1 :
                        pmonthstart=new DateTime(Int32.Parse(_lkupFiscalYearRepository.GetRecord(mainrecord.FiscalYear_Id).Record_Name),1, 1);
                        pmonthend=new DateTime(Int32.Parse(_lkupFiscalYearRepository.GetRecord(mainrecord.FiscalYear_Id).Record_Name), 3, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(mainrecord.FiscalYear_Id).Record_Name), 3));
                        break;
                    case 2 :
                        pmonthstart=new DateTime(Int32.Parse(_lkupFiscalYearRepository.GetRecord(mainrecord.FiscalYear_Id).Record_Name),4, 1);
                        pmonthend=new DateTime(Int32.Parse(_lkupFiscalYearRepository.GetRecord(mainrecord.FiscalYear_Id).Record_Name), 6, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(mainrecord.FiscalYear_Id).Record_Name), 6));
                        break;
                    case 3 :
                        pmonthstart=new DateTime(Int32.Parse(_lkupFiscalYearRepository.GetRecord(mainrecord.FiscalYear_Id).Record_Name),7, 1);
                        pmonthend=new DateTime(Int32.Parse(_lkupFiscalYearRepository.GetRecord(mainrecord.FiscalYear_Id).Record_Name), 9, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(mainrecord.FiscalYear_Id).Record_Name), 9));
                        break;
                    case 4 :
                        pmonthstart=new DateTime(Int32.Parse(_lkupFiscalYearRepository.GetRecord(mainrecord.FiscalYear_Id).Record_Name),10, 1);
                        pmonthend=new DateTime(Int32.Parse(_lkupFiscalYearRepository.GetRecord(mainrecord.FiscalYear_Id).Record_Name), 12, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(mainrecord.FiscalYear_Id).Record_Name), 12));
                        break;
                    case 5 :
                        pmonthstart=new DateTime(Int32.Parse(_lkupFiscalYearRepository.GetRecord(mainrecord.FiscalYear_Id).Record_Name),1, 1);
                        pmonthend=new DateTime(Int32.Parse(_lkupFiscalYearRepository.GetRecord(mainrecord.FiscalYear_Id).Record_Name), 6, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(mainrecord.FiscalYear_Id).Record_Name), 6));
                        break;
                    case 6 :
                        pmonthstart=new DateTime(Int32.Parse(_lkupFiscalYearRepository.GetRecord(mainrecord.FiscalYear_Id).Record_Name),7, 1);
                        pmonthend=new DateTime(Int32.Parse(_lkupFiscalYearRepository.GetRecord(mainrecord.FiscalYear_Id).Record_Name), 12, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(mainrecord.FiscalYear_Id).Record_Name), 12));
                        break;
                    case 7 :
                        pmonthstart=new DateTime(Int32.Parse(_lkupFiscalYearRepository.GetRecord(mainrecord.FiscalYear_Id).Record_Name),1, 1);
                        pmonthend=new DateTime(Int32.Parse(_lkupFiscalYearRepository.GetRecord(mainrecord.FiscalYear_Id).Record_Name), 12, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(mainrecord.FiscalYear_Id).Record_Name), 12));
                        break;


                }

            }   

            
            WP_OutputMobilityVMWindow model = new WP_OutputMobilityVMWindow
            {
                Transaction_IdOMVMMain=rec.Transaction_Id,
                WPMainRecord_idOMVMMain=rec.WPMainRecord_id,
                Employee_IdOMVMMain = user.Employee_Id,
                FiscalYear_IdOMVMMain=rec.FiscalYear_Id,
                Period_IdOMVMMain =rec.Period_Id,
                Project_IdOMVMMain=rec.Project_Id,
                FisYearOMVMMain=_lkupFiscalYearRepository.GetRecord(rec.FiscalYear_Id).Record_Name,
                FisPeriodOMVMMain=periodinmain,
                PeriodStartDateOMVMMain=pmonthstart,
                PeriodEndDateOMVMMain=pmonthend

            };



            return PartialView("_AddOutputMobility", model);
        }

        public async Task<ActionResult> AddOutputActivityGantt(string transid)
        {
            WP_MainRecord rec = _wpMainRecordRepository.GetRecord(transid);

            var user = await userManager.GetUserAsync(HttpContext.User);

            WP_MainRecord mainrecord=_wpMainRecordRepository.GetRecord(rec.Transaction_Id);
            string periodinmain="";

            DateTime pmonthstart=DateTime.Today;
            DateTime pmonthend=DateTime.Today;

            if(mainrecord.Period_Id==8)
            {
                DateTime pstart=new DateTime(mainrecord.PeriodStartDate.Year, mainrecord.PeriodStartDate.Month, mainrecord.PeriodStartDate.Day);
                DateTime pend=new DateTime(mainrecord.PeriodEndDate.Year, mainrecord.PeriodEndDate.Month, mainrecord.PeriodEndDate.Day);
                periodinmain=pstart.Date.ToString("MMMM dd, yyyy") + " - "+ pend.Date.ToString("MMMM dd, yyyy"); 

                pmonthstart=new DateTime(mainrecord.PeriodStartDate.Year , mainrecord.PeriodStartDate.Month, 1);
                pmonthend=new DateTime(mainrecord.PeriodEndDate.Year, mainrecord.PeriodEndDate.Month, DateTime.DaysInMonth(mainrecord.PeriodEndDate.Year, mainrecord.PeriodEndDate.Month));

            }
            else
            {
                periodinmain=_lkupPeriodRepository.GetRecord(mainrecord.Period_Id).Record_Name;

                switch(mainrecord.Period_Id)
                {
                    case 1 :
                        pmonthstart=new DateTime(Int32.Parse(_lkupFiscalYearRepository.GetRecord(mainrecord.FiscalYear_Id).Record_Name),1, 1);
                        pmonthend=new DateTime(Int32.Parse(_lkupFiscalYearRepository.GetRecord(mainrecord.FiscalYear_Id).Record_Name), 3, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(mainrecord.FiscalYear_Id).Record_Name), 3));
                        break;
                    case 2 :
                        pmonthstart=new DateTime(Int32.Parse(_lkupFiscalYearRepository.GetRecord(mainrecord.FiscalYear_Id).Record_Name),4, 1);
                        pmonthend=new DateTime(Int32.Parse(_lkupFiscalYearRepository.GetRecord(mainrecord.FiscalYear_Id).Record_Name), 6, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(mainrecord.FiscalYear_Id).Record_Name), 6));
                        break;
                    case 3 :
                        pmonthstart=new DateTime(Int32.Parse(_lkupFiscalYearRepository.GetRecord(mainrecord.FiscalYear_Id).Record_Name),7, 1);
                        pmonthend=new DateTime(Int32.Parse(_lkupFiscalYearRepository.GetRecord(mainrecord.FiscalYear_Id).Record_Name), 9, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(mainrecord.FiscalYear_Id).Record_Name), 9));
                        break;
                    case 4 :
                        pmonthstart=new DateTime(Int32.Parse(_lkupFiscalYearRepository.GetRecord(mainrecord.FiscalYear_Id).Record_Name),10, 1);
                        pmonthend=new DateTime(Int32.Parse(_lkupFiscalYearRepository.GetRecord(mainrecord.FiscalYear_Id).Record_Name), 12, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(mainrecord.FiscalYear_Id).Record_Name), 12));
                        break;
                    case 5 :
                        pmonthstart=new DateTime(Int32.Parse(_lkupFiscalYearRepository.GetRecord(mainrecord.FiscalYear_Id).Record_Name),1, 1);
                        pmonthend=new DateTime(Int32.Parse(_lkupFiscalYearRepository.GetRecord(mainrecord.FiscalYear_Id).Record_Name), 6, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(mainrecord.FiscalYear_Id).Record_Name), 6));
                        break;
                    case 6 :
                        pmonthstart=new DateTime(Int32.Parse(_lkupFiscalYearRepository.GetRecord(mainrecord.FiscalYear_Id).Record_Name),7, 1);
                        pmonthend=new DateTime(Int32.Parse(_lkupFiscalYearRepository.GetRecord(mainrecord.FiscalYear_Id).Record_Name), 12, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(mainrecord.FiscalYear_Id).Record_Name), 12));
                        break;
                    case 7 :
                        pmonthstart=new DateTime(Int32.Parse(_lkupFiscalYearRepository.GetRecord(mainrecord.FiscalYear_Id).Record_Name),1, 1);
                        pmonthend=new DateTime(Int32.Parse(_lkupFiscalYearRepository.GetRecord(mainrecord.FiscalYear_Id).Record_Name), 12, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(mainrecord.FiscalYear_Id).Record_Name), 12));
                        break;


                }
            }

            
            WP_OutputActivitiesVM model = new WP_OutputActivitiesVM
            {
                Transaction_IdOAVMMain="",
                WPMainRecord_idOAVMMain=rec.Transaction_Id,
                Employee_IdOAVMMain = user.Employee_Id,
                FiscalYear_IdOAVMMain=rec.FiscalYear_Id,
                Period_IdOAVMMain =rec.Period_Id,
                Project_IdOAVMMain=rec.Project_Id,
                FisYearOAVMMain=_lkupFiscalYearRepository.GetRecord(rec.FiscalYear_Id).Record_Name,
                FisPeriodOAVMMain=periodinmain,
                PeriodStartDate=pmonthstart,
                PeriodEndDate=pmonthend
            };



            return PartialView("_AddOutputActivityGantt", model);
        }


        public async Task<ActionResult> EditOutputActivity(string transid)
        {
           // WP_Outputs rec = _wpOutputsRepository.GetRecord(transid);

            WP_OutputActivities rec=_wpOutputActivitiesRepository.GetRecord(transid);
            var user = await userManager.GetUserAsync(HttpContext.User);

            WP_MainRecord mainrecord=_wpMainRecordRepository.GetRecord(rec.WPMainRecord_id);
            string periodinmain="";
            if(mainrecord.Period_Id==8)
            {
                DateTime pstart=new DateTime(mainrecord.PeriodStartDate.Year, mainrecord.PeriodStartDate.Month, mainrecord.PeriodStartDate.Day);
                DateTime pend=new DateTime(mainrecord.PeriodEndDate.Year, mainrecord.PeriodEndDate.Month, mainrecord.PeriodEndDate.Day);
                periodinmain=pstart.Date.ToString("MMMM dd, yyyy") + " - "+ pend.Date.ToString("MMMM dd, yyyy"); 

            }
            else
            {
                periodinmain=_lkupPeriodRepository.GetRecord(mainrecord.Period_Id).Record_Name;

            }  

            
            WP_OutputActivitiesVM model = new WP_OutputActivitiesVM
            {
                Transaction_IdOAVMMain=rec.Transaction_Id,
                WPMainRecord_idOAVMMain=rec.WPMainRecord_id,
                WPOutput_IdOAVMMain=rec.WPOutput_Id,
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
                PartnerFundingOAVMMain=rec.PartnerFunding.Value,
                PartnerFundingDescrOAVMMain=rec.PartnerFundingDescr,
                FisPeriodOAVMMain=periodinmain

            };



            return PartialView("_EditOutputActivity", model);
        }

        public async Task<ActionResult> EditOutputMobility(string transid)
        {
           // WP_Outputs rec = _wpOutputsRepository.GetRecord(transid);

            WP_Mobility rec=_wpMobilityRepository.GetRecord(transid);
            var user = await userManager.GetUserAsync(HttpContext.User);

            WP_MainRecord mainrecord=_wpMainRecordRepository.GetRecord(rec.WPMainRecord_id);
            string periodinmain="";
            if(mainrecord.Period_Id==8)
            {
                DateTime pstart=new DateTime(mainrecord.PeriodStartDate.Year, mainrecord.PeriodStartDate.Month, mainrecord.PeriodStartDate.Day);
                DateTime pend=new DateTime(mainrecord.PeriodEndDate.Year, mainrecord.PeriodEndDate.Month, mainrecord.PeriodEndDate.Day);
                periodinmain=pstart.Date.ToString("MMMM dd, yyyy") + " - "+ pend.Date.ToString("MMMM dd, yyyy"); 

            }
            else
            {
                periodinmain=_lkupPeriodRepository.GetRecord(mainrecord.Period_Id).Record_Name;

            }  

            
            WP_OutputMobilityVMWindow model = new WP_OutputMobilityVMWindow
            {
                Transaction_IdOMVMMain=rec.Transaction_Id,
                WPMainRecord_idOMVMMain=rec.WPMainRecord_id,
                WPOutput_IdOMVMMain=rec.WPOutput_Id,
                Employee_IdOMVMMain = user.Employee_Id,
                FiscalYear_IdOMVMMain=rec.FiscalYear_Id,
                Period_IdOMVMMain =rec.Period_Id,
                Project_IdOMVMMain=rec.Project_Id,
                Country_IdOMVMMain=rec.Country_Id,
                WPMobility_DescriptionOMVMMain=rec.WPMobility_Description,
                MobilityCostOMVMMain=rec.MobilityCost,
                MobilityStartDateOMVMMain=new DateTime(rec.MobilityStartDate.Year, rec.MobilityStartDate.Month, rec.MobilityStartDate.Day),
                MobilityEndDateOMVMMain=new DateTime(rec.MobilityEndDate.Year, rec.MobilityEndDate.Month, rec.MobilityEndDate.Day),
                FisYearOMVMMain=_lkupFiscalYearRepository.GetRecord(rec.FiscalYear_Id).Record_Name,
                FisPeriodOMVMMain=periodinmain

            };

            //Selected Employees
            List<DropDownListViewModel> collection_recs = new List<DropDownListViewModel>();

            var DB_Recs =  _wpMobilityInternalTeamRepository.GetRecordsByMobilityId(transid);

            int _count =  DB_Recs.Count();

            if (_count > 0)
            {
                foreach (var recordset in DB_Recs)
                {
                    Employee emp=_employeeRepository.GetEmployee(recordset.Employee_Id);
                   
                    DropDownListViewModel srec = new DropDownListViewModel
                    {
                            DropDown_IntId = recordset.Employee_Id,
                            DropDown_Name = emp.First_Name+" "+emp.Last_Name
                    };
                    // EmployeeDropDownViewModel me = DB_Employees[_count];
                    collection_recs.Add(srec);
                }
            }

             model.SelectedEmployees=collection_recs;


            PopulateExternalType();

            return PartialView("_EditOutputMobility", model);
        }

        private void PopulateExternalType()
        {


            var emp_recs =  _transExtParticipantTypeRepository.GetAllRecords().ToList();

            List<CategoryViewModel> categories = new List<CategoryViewModel>();

            foreach (var rec in emp_recs)
            {
                CategoryViewModel srec = new CategoryViewModel
                {
                        CategoryID = rec.Record_Id,
                        CategoryName = _lkupExtParticipantTypeRepository.GetRecord(rec.Record_Id).Record_Name
                };
                categories.Add(srec);
  
            }
            ViewData["externaltypes"] = categories.OrderBy(e => e.CategoryName).ToList();
            ViewData["defaultExternalType"] = categories.OrderBy(e => e.CategoryName).First();

        }

        public async Task<ActionResult> ManageOutputBudgetLink(string projid, string fyear, string fperiod, string mainrecordid,  string outputid)
        {
           // WP_Outputs rec = _wpOutputsRepository.GetRecord(transid);
            var user = await userManager.GetUserAsync(HttpContext.User);

            WP_Outputs wpoutput_recfetch=_wpOutputsRepository.GetRecord(outputid);
           
            WP_MainRecord mainrec=_wpMainRecordRepository.GetRecord(mainrecordid);
            WP_DispatchCycle wpcycle=_wpDispatchCycleRepository.GetRecordByYearAndPeriod(mainrec.FiscalYear_Id, mainrec.Period_Id);
           
            WP_OutputBudgetVM model = new WP_OutputBudgetVM();

            var DB_Recs_Activities =  _wpOutputActivitiesRepository.GetRecordsByOutputId(wpoutput_recfetch.Transaction_Id);
            double total_budget=0;
            foreach (var record in DB_Recs_Activities)
            {
                total_budget=total_budget+record.ActivityCost;

            }
            if(wpoutput_recfetch.WPSAPLink_Id!=null)
            {
                    WP_SAPLink saplinkrec = _wpSAPLinkRepository.GetRecord(wpoutput_recfetch.WPSAPLink_Id);


                    var DB_Recs_Activities_Linked_SAP =  _wpOutputActivitiesRepository.GetRecordsByWPSAPLink_Id(wpoutput_recfetch.WPSAPLink_Id);
                    double total_use=0;
                    double utilization_percent=0;

                    foreach (var record in DB_Recs_Activities_Linked_SAP)
                    {
                        total_use=total_use+record.ActivityCost;

                    }
                    utilization_percent=saplinkrec.SAP_BudgetAmount/total_use;

                
                    model.Transaction_IdOBVM=wpoutput_recfetch.Transaction_Id;
                    model.WPMainRecord_idOBVM=wpoutput_recfetch.WPMainRecord_id;
                    model.Employee_IdOBVM = user.Employee_Id;
                    model.Project_IdOBVM=wpoutput_recfetch.Project_Id;
                    model.FiscalYear_IdOBVM=wpoutput_recfetch.FiscalYear_Id;
                    model.Period_IdOBVM=wpoutput_recfetch.Period_Id;
                    model.WPOutput_IdOBVM=wpoutput_recfetch.Transaction_Id;
                    model.Output_BudgetAmountOBVM=total_budget;
                    model.WPSAPLink_IdOBVM=wpoutput_recfetch.WPSAPLink_Id;
                    //model.WPSAPBudget_WBSOBVM=_wpSAPLinkRepository.GetRecord(wpoutputbudget_recfetch.WPSAPLink_Id).SAP_WBS;
                    model.UtilizationPercentageOBVM=utilization_percent;

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
                    model.Output_BudgetAmountOBVM=total_budget;
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