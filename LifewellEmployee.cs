using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lifewell_Reaper.Classes
{
    public class DominionEmployee
    {
        public string CompanyCode { get; set; }
        public string CompanyName { get; set;}
        public string EmployeeNumber { get; set;}
        public string SSN { get; set;}
        public string EmployeeLastName { get; set;}
        public string EmployeeFirstName { get; set;}
        public string EmployeeMiddleName { get; set;}
        public string HireDate { get; set; }
        public string TerminationDate {  get; set; }
        public string RehireDate { get; set;}
        public string Status {  get; set; }
        public string BirthDate { get; set; }
    }
    public class DominionEmployeeResponseLifeWell
    {
        public DominionEmployeeResultsLifeWell filtersUsed { get; set; }
        public string searchCriteriaUsed { get; set; }
        public DominionEmployeesLifeWell[] employees { get; set; }
        public DominionEmployeesOrgFieldsLifeWell[] orgFields { get; set; }
        public DominionEmployeesLegalsLifeWell[] legals { get; set; }
    }

    public class DominionEmployeeResultsLifeWell
    {
        public int? employeeId { get; set; }
        public int? legalId { get; set; }
        public int? payGroupId { get; set; }
        public int? orgFieldId { get; set; }
        public int? orgValueId { get; set; }
        public int? payrollStatusId { get; set; }
        public int? payTypeId { get; set; }
        public bool? isManager { get; set; }
        public bool? isSupervisor { get; set; }
        public bool? treatOrgManagementRolesAsJobManagementRoles { get; set; }
    }

    public class DominionEmployeesLifeWell
    {
        public int id { get; set; }
        public string prefix { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public string suffix { get; set; }
        public string preferredName { get; set; }
        public string ssn { get; set; }
        public string residentState { get; set; }
        public int? legalId { get; set; }
        public int? payGroupId { get; set; }
        public string employeeNumber { get; set; }
        public string timeclockId { get; set; }
        public string payrollEmploymentStatusId { get; set; }
        public int? clientEmploymentStatusId { get; set; }
        public int? clientEmploymentCategoryId { get; set; }
        public string employmentStatusEffectiveDate { get; set; }
        public string hireDate { get; set; }
        public string adjustedServiceDate { get; set; }
        public string peoStartDate { get; set; }
        public int? clientJobId { get; set; }
        public string payTypeId { get; set; }
        public string payAmount { get; set; }
        public int? workLocationId { get; set; }
        public string workersCompCode { get; set; }
        public string workersCompState { get; set; }
        public DominionEmployeesOrgValuesLifeWell[] orgValues { get; set; }
        public bool? remoteWorker { get; set; }
    }

    public class DominionEmployeesOrgValuesLifeWell
    {
        public int? orgFieldId { get; set; }
        public string orgValue { get; set; }
    }

    public class DominionEmployeesOrgFieldsLifeWell
    {
        public string employeeOrgPropertyName { get; set; }
        public DominionEmployeesLookupsLifeWell[] lookups { get; set; }
        public int? id { get; set; }
        public string description { get; set; }
    }

    public class DominionEmployeesLookupsLifeWell
    {
        public string id { get; set; }
        public string description { get; set; }
    }

    public class DominionEmployeesLegalsLifeWell
    {
        public string accountStatus { get; set; }
        public string peo { get; set; }
        public string dbaName { get; set; }
        public DominionEmployeesPayGroupsLifeWell[] payGroups { get; set; }
        public DominionEmployeesWorkStationsLifeWell[] workLocations { get; set; }
        public int id { get; set; }
        public string description { get; set; }
    }

    public class DominionEmployeesPayGroupsLifeWell
    {
        public bool isInactive { get; set; }
        public int id { get; set; }
        public string description { get; set; }
    }

    public class DominionEmployeesWorkStationsLifeWell
    {
        public int id { get; set; }
        public string description { get; set; }
    }


}
