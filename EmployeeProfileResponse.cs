using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lifewell_Reaper.Classes
{

    public class EmployeeProfileResponse
    {
        public EmployeeCardInformation employeeCardInformation { get; set; }
        public PersonalInformation personalInformation { get; set; }
        public EmploymentInformation employmentInformation { get; set; }
        public JobInformation jobInformation { get; set; }
        public object payInformation { get; set; }
        public TaxInformation taxInformation { get; set; }
        public ManagementInformation managementInformation { get; set; }
        public OrganizationInformation[] organizationInformation { get; set; }
        public object[] laborInformation { get; set; }
        public bool hasAccessToEmployeeGeneral { get; set; }
        public bool hasAccessToEmployeeNotes { get; set; }
        public bool hasAccessToProfilePicture { get; set; }
        public bool hasAccessToEmployeeEmployment { get; set; }
        public bool hasAccessToEmployeeJobs { get; set; }
        public bool hasAccessToEmployeeSalary { get; set; }
        public bool hasAccessToEmployeeDirectDeposit { get; set; }
        public bool hasAccessToOverrideAddress { get; set; }
        public bool hasAccessToTaxInformation { get; set; }
        public bool hasAccessToEmployeeOrganizations { get; set; }
        public bool hasAccessToEmployeeLabors { get; set; }
    }

    public class EmployeeCardInformation
    {
        public int personId { get; set; }
        public bool hasProfilePicture { get; set; }
        public object profilePictureUrl { get; set; }
        public string employeeInitials { get; set; }
        public string employeeName { get; set; }
        public object preferredPronoun { get; set; }
        public string jobTitle { get; set; }
        public string workLocationName { get; set; }
        public object workPhone { get; set; }
        public object mobilePhone { get; set; }
        public string homePhone { get; set; }
        public string selfServiceEmail { get; set; }
        public Address address { get; set; }
    }

    public class Address
    {
        public string address1 { get; set; }
        public object address2 { get; set; }
        public string cityStateZip { get; set; }
        public object country { get; set; }
    }

    public class PersonalInformation
    {
        public string ssn { get; set; }
        public string maskedSsn { get; set; }
        public string birthDate { get; set; }
        public string maskedBirthDate { get; set; }
        public string gender { get; set; }
        public string maritalStatus { get; set; }
        public object personalEmail { get; set; }
        public object militaryStatus { get; set; }
    }

    public class EmploymentInformation
    {
        public string legalName { get; set; }
        public object dbaName { get; set; }
        public string employeeNumber { get; set; }
        public string timeclockId { get; set; }
        public string hireDate { get; set; }
        public string lengthOfHire { get; set; }
        public object adjustedServiceDate { get; set; }
        public object lengthOfService { get; set; }
        public bool isActiveOrInactive { get; set; }
        public bool isTerminated { get; set; }
        public string employmentStatus { get; set; }
        public string employmentCategory { get; set; }
        public string acaStatus { get; set; }
        public bool displayAcaHoursMet { get; set; }
        public string acaHoursMet { get; set; }
        public object terminationDate { get; set; }
        public object terminationReason { get; set; }
        public object terminationType { get; set; }
    }

    public class JobInformation
    {
        public string jobTitle { get; set; }
        public string effectiveDate { get; set; }
        public string lengthOfService { get; set; }
        public string jobGroup { get; set; }
        public string eeoCategory { get; set; }
        public string workersComp { get; set; }
    }

    public class TaxInformation
    {
        public FederalTaxCategory federalTaxCategory { get; set; }
        public ResidentStateTaxCategory residentStateTaxCategory { get; set; }
        public WorkStateTaxCategory workStateTaxCategory { get; set; }
        public bool hasSameResidentAndWorkState { get; set; }
        public string workLocation { get; set; }
        public string residentLocation { get; set; }
        public object schoolDistrict { get; set; }
        public object taxExemption { get; set; }
        public object alternateAddress { get; set; }
    }

    public class FederalTaxCategory
    {
        public object state { get; set; }
        public object stateAbbreviation { get; set; }
        public bool hasNoTax { get; set; }
        public string filingStatus { get; set; }
        public bool isBlocked { get; set; }
        public bool hasMultipleJobs { get; set; }
        public object primaryExemptions { get; set; }
        public object secondaryExemptions { get; set; }
        public object exemptionAmount { get; set; }
        public object dependentExemption { get; set; }
        public object deductionExemption { get; set; }
        public object additionalIncome { get; set; }
        public object additionalAmount { get; set; }
        public object additionalPercent { get; set; }
    }

    public class ResidentStateTaxCategory
    {
        public string state { get; set; }
        public string stateAbbreviation { get; set; }
        public bool hasNoTax { get; set; }
        public object filingStatus { get; set; }
        public bool isBlocked { get; set; }
        public bool hasMultipleJobs { get; set; }
        public object primaryExemptions { get; set; }
        public object secondaryExemptions { get; set; }
        public object exemptionAmount { get; set; }
        public object dependentExemption { get; set; }
        public object deductionExemption { get; set; }
        public object additionalIncome { get; set; }
        public object additionalAmount { get; set; }
        public object additionalPercent { get; set; }
    }

    public class WorkStateTaxCategory
    {
        public string state { get; set; }
        public string stateAbbreviation { get; set; }
        public bool hasNoTax { get; set; }
        public object filingStatus { get; set; }
        public bool isBlocked { get; set; }
        public bool hasMultipleJobs { get; set; }
        public object primaryExemptions { get; set; }
        public object secondaryExemptions { get; set; }
        public object exemptionAmount { get; set; }
        public object dependentExemption { get; set; }
        public object deductionExemption { get; set; }
        public object additionalIncome { get; set; }
        public object additionalAmount { get; set; }
        public object additionalPercent { get; set; }
    }

    public class ManagementInformation
    {
        public string assignedManager { get; set; }
        public bool isAssignedManagerTerminated { get; set; }
        public string assignedSupervisor { get; set; }
        public bool isAssignedSupervisorTerminated { get; set; }
        public object[] organizationManagers { get; set; }
        public object[] organizationSupervisors { get; set; }
    }

    public class OrganizationInformation
    {
        public bool isJobOrg { get; set; }
        public string fieldName { get; set; }
        public string value { get; set; }
    }

}
