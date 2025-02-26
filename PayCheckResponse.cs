using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lifewell_Reaper.Classes
{

    public class TimecardApiResponse
    {
        public int dailyStartTime { get; set; }
        public string timezone { get; set; }
        public string payPeriodStartDate { get; set; }
        public string payPeriodEndDate { get; set; }
        public float payPeriodNumberOfDays { get; set; }
        public string viewStartDate { get; set; }
        public string viewEndDate { get; set; }
        public float viewNumberOfDays { get; set; }
        public string timecardDate { get; set; }
        public bool isTimecardLocked { get; set; }
        public bool isTimecardCommitted { get; set; }
        public bool isPayrollProcessed { get; set; }
        public bool isPayrollFound { get; set; }
        public bool isEmployeeUsingCertifiedPayrollLabor { get; set; }
        public int otStartDay { get; set; }
        public string weekStartDate { get; set; }
        public string weekEndDate { get; set; }
        public Timecarddata timecardData { get; set; }
        public string[] timecardPunchModeOptions { get; set; }
        public string[] timecardPunchTypeOptions { get; set; }
        public string[] timecardPunchSourceOptions { get; set; }
        public Laborfieldoption[] laborFieldOptions { get; set; }
        public Inactivelaborfieldoption[] inactiveLaborFieldOptions { get; set; }
        public Absencepolicyoption[] absencePolicyOptions { get; set; }
        public object[] adjustmentTypeOptions { get; set; }
        public Employeelabordefaults employeeLaborDefaults { get; set; }
        public string effectivePolicyGroupName { get; set; }
        public int effectivePolicyGroupId { get; set; }
        public int maxContinuousHours { get; set; }
        public object pendingAbsenceSeverity { get; set; }
        public object pendingPunchSeverity { get; set; }
        public object effectivePolicyGroupPermissions { get; set; }
        public object currentUserPermissions { get; set; }
        public string currentUserName { get; set; }
        public bool userHasSalaryRestriction { get; set; }
        public bool clientHasShifts { get; set; }
        public bool payGroupIsTimeOnly { get; set; }
        public string currentUserType { get; set; }
        public bool inOutStatus { get; set; }
        public Laborgroupsfieldoptions laborGroupsFieldOptions { get; set; }
        public Laborgroupnames laborGroupNames { get; set; }
        public Laborgroupitemlaboritems laborGroupItemLaborItems { get; set; }
        public Punchlockoutdata punchLockOutData { get; set; }
        public bool isEnabledTimecardAnalyzeRules { get; set; }
        public bool isEnabledTimecardVerification { get; set; }
        public object[] alertTypeOptions { get; set; }
        public bool isOccurrenceTrackingEnabled { get; set; }
    }

    public class Timecarddata
    {
        public string timezone { get; set; }
        public object timecardVerifications { get; set; }
        public object timecardVerificationSettings { get; set; }
        public object[] timecardAdjustments { get; set; }
        public Timeresult[] timeResults { get; set; }
        public object[] timeEarningResults { get; set; }
        public object[] adjustmentDollarResults { get; set; }
        public Adjustmentpayitemresults adjustmentPayItemResults { get; set; }
        public Timedateresult[] timeDateResults { get; set; }
        public object[] timeLaborResults { get; set; }
        public object[] laborsUsed { get; set; }
        public DateTime viewStartDate { get; set; }
        public DateTime viewEndDate { get; set; }
        public object[] analysisData { get; set; }
        public object[] timecardEvents { get; set; }
        public object[] timecardAlerts { get; set; }
        public bool hasPendingPunches { get; set; }
        public bool hasPendingAbsences { get; set; }
        public bool userHasDashboardAccess { get; set; }
        public Payperiodearningtotals payPeriodEarningTotals { get; set; }
    }

    public class Adjustmentpayitemresults
    {
    }

    public class Payperiodearningtotals
    {
    }

    public class Timeresult
    {
        public string guid { get; set; }
        public int id { get; set; }
        public int earningId { get; set; }
        public string earningTitle { get; set; }
        public bool isChanged { get; set; }
        public bool isDeleted { get; set; }
        public bool isNew { get; set; }
        public object labors { get; set; }
        public string laborsDisplayTitle { get; set; }
        public string laborsDisplayTitleLabel { get; set; }
        public DateTime resultEndDateTime { get; set; }
        public DateTime resultStartDateTime { get; set; }
        public DateTime resultDate { get; set; }
        public float totalHours { get; set; }
        public object childResultsModels { get; set; }
        public int sequenceNumber { get; set; }
        public int originalHourId { get; set; }
        public object[] alerts { get; set; }
        public bool isPhantomResult { get; set; }
    }

    public class Timedateresult
    {
        public string guid { get; set; }
        public int id { get; set; }
        public int earningId { get; set; }
        public string earningTitle { get; set; }
        public bool isChanged { get; set; }
        public bool isDeleted { get; set; }
        public bool isNew { get; set; }
        public object labors { get; set; }
        public string laborsDisplayTitle { get; set; }
        public string laborsDisplayTitleLabel { get; set; }
        public DateTime resultEndDateTime { get; set; }
        public DateTime resultStartDateTime { get; set; }
        public DateTime resultDate { get; set; }
        public float totalHours { get; set; }
        public Childresultsmodel[] childResultsModels { get; set; }
        public int sequenceNumber { get; set; }
        public int originalHourId { get; set; }
        public object alerts { get; set; }
        public bool isPhantomResult { get; set; }
    }

    public class Childresultsmodel
    {
        public string guid { get; set; }
        public int id { get; set; }
        public int earningId { get; set; }
        public string earningTitle { get; set; }
        public bool isChanged { get; set; }
        public bool isDeleted { get; set; }
        public bool isNew { get; set; }
        public object labors { get; set; }
        public string laborsDisplayTitle { get; set; }
        public string laborsDisplayTitleLabel { get; set; }
        public DateTime resultEndDateTime { get; set; }
        public DateTime resultStartDateTime { get; set; }
        public DateTime resultDate { get; set; }
        public float totalHours { get; set; }
        public object childResultsModels { get; set; }
        public int sequenceNumber { get; set; }
        public int originalHourId { get; set; }
        public object alerts { get; set; }
        public bool isPhantomResult { get; set; }
    }

    public class Employeelabordefaults
    {
        public string _2654 { get; set; }
        public string _2689 { get; set; }
        public string _2690 { get; set; }
        public string _2691 { get; set; }
        public string _2692 { get; set; }
    }

    public class Laborgroupsfieldoptions
    {
    }

    public class Laborgroupnames
    {
    }

    public class Laborgroupitemlaboritems
    {
    }

    public class Punchlockoutdata
    {
        public object applicableSchedule { get; set; }
        public object applicablePunch { get; set; }
        public bool isLockedOut { get; set; }
        public string nextPunchDate { get; set; }
        public string nextPunchTime { get; set; }
        public string nextAllowedPunchTime { get; set; }
        public string lockOutMessage { get; set; }
    }

    public class Laborfieldoption
    {
        public int id { get; set; }
        public bool isNew { get; set; }
        public string title { get; set; }
        public int laborGroupId { get; set; }
        public string laborGroupName { get; set; }
        public int? laborGroupSequence { get; set; }
        public Lookup[] lookups { get; set; }
    }

    public class Lookup
    {
        public string id { get; set; }
        public string description { get; set; }
    }

    public class Inactivelaborfieldoption
    {
        public int id { get; set; }
        public bool isNew { get; set; }
        public string title { get; set; }
        public int laborGroupId { get; set; }
        public string laborGroupName { get; set; }
        public int? laborGroupSequence { get; set; }
        public Lookup[] lookups { get; set; }
    }

    public class Absencepolicyoption
    {
        public int id { get; set; }
        public bool isNew { get; set; }
        public bool isChanged { get; set; }
        public string absenceName { get; set; }
        public float? defaultHours { get; set; }
        public float? minimumHours { get; set; }
        public float? maximumHours { get; set; }
        public float? timeOffRequestBalanceLimit { get; set; }
        public float timeOffRequestDurationLimit { get; set; }
        public bool isInactive { get; set; }
        public object values { get; set; }
    }

}
