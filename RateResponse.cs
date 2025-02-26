using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryItADP
{

	public class RatesResponse
	{
		public string companyId { get; set; }
		public string assignmentId { get; set; }
		public bool hasPending { get; set; }
		public bool hasActiveEaf { get; set; }
		public Rate[] rates { get; set; }
		public bool tempFromNewQuery { get; set; }
	}

	public class Rate
	{
		public string companyId { get; set; }
		public string assignmentId { get; set; }
		public string effectiveDate { get; set; }
		public string checkDate { get; set; }
		public string beginCheckDate { get; set; }
		public string changeReason { get; set; }
		public string changedBy { get; set; }
		public bool edited { get; set; }
		public string payType { get; set; }
		public float perCheckSalary { get; set; }
		public float baseRate { get; set; }
		public Baserateper baseRatePer { get; set; }
		public Payfrequency payFrequency { get; set; }
		public float defaultHours { get; set; }
		public float annualSalary { get; set; }
		public Autopaytype autoPayType { get; set; }
		public string rateSetupNotes { get; set; }
		public string type { get; set; }
		public string pendingState { get; set; }
		public object[] pendingChanges { get; set; }
		public string recordId { get; set; }
		public bool wasEditedWithEaf { get; set; }
		public float amountChangedFromPrevious { get; set; }
		public float percentChangedFromPrevious { get; set; }
		public Experienceedit experienceEdit { get; set; }
	}

	public class Baserateper
	{
		public string code { get; set; }
		public string description { get; set; }
	}

	public class Payfrequency
	{
		public string code { get; set; }
		public string description { get; set; }
	}

	public class Autopaytype
	{
		public string code { get; set; }
		public string description { get; set; }
	}

	public class Experienceedit
	{
		public int experienceStatusChangeId { get; set; }
		public int pscId { get; set; }
		public string experienceName { get; set; }
		public string designType { get; set; }
		public Change[] changes { get; set; }
	}

	public class Change
	{
		public string name { get; set; }
		public string[] originalValues { get; set; }
		public string[] completedValues { get; set; }
	}

	public class PayRateHistADP
	{
		public PayRateHistListADP[] futureList { get; set; }
		public PayRateHistListADP[] currentList { get; set; }
		public PayRateHistListADP[] historyList { get; set; }
		public bool isReadOnly { get; set; }
		public string requestResponseId { get; set; }
		public string serverTimeTaken { get; set; }
	}

	public class PayRateHistListADP
	{
		public bool showDeleteIcon { get; set; }
		public bool showDeleteInfoIcon { get; set; }
		public PayRateHistSalaryADP Salary { get; set; }
	}

	public class PayRateHistDetailADP
	{
		public PayRateHistSalaryADP Salary { get; set; }
		public string CompanyPayFrequency { get; set; }
		public bool DoNotUpdateHistoryRecord { get; set; }
		public string CancelAutoPay { get; set; }
		public bool CancelFuturePayrolls { get; set; }
		public string ScheduledPayment { get; set; }
		public PayRateHistTypeADP[] PayFreqFactorList { get; set; }
		public PayRateHistTypeADP OriginalPayFreqTypeFromDB { get; set; }
		public bool isCurrentRecord { get; set; }
		public string paid { get; set; }
		public PayRateHistAttributes Attributes { get; set; }
		public string endDate { get; set; }
		public string[] effDateList { get; set; }
		public bool quickAddAllOtherRemaining { get; set; }
		public bool isReadOnly { get; set; }
		public object[] info { get; set; }
		public object[] warning { get; set; }
		public string requestResponseId { get; set; }
		public string serverTimeTaken { get; set; }
	}

	public class PayRateHistSalaryADP
	{
		public PayRateHistSalaryKeyADP key { get; set; }
		public PayRateHistTypeADP IncreaseType { get; set; }
		public float AnnualSalaryAmount { get; set; }
		public float dollarChange { get; set; }
		public string payFrequencyOid { get; set; }
		public string rateTypeOid { get; set; }
		public float Rate1Amount { get; set; }
		public float Rate2Amount { get; set; }
		public float percentChange { get; set; }
		public float StandardHours { get; set; }
		public float CompanyStandardHours { get; set; }
		public string rateMultiplier { get; set; }
		public bool FLSA { get; set; }
		public string Rate1CurrencyCode { get; set; }
		public string Rate2CurrencyCode { get; set; }
		public bool Tipped { get; set; }
		public string basisOfPayOid { get; set; }
		public PayRateHistTypeADP basisOfPayType { get; set; }
		public PayRateHistPayFreqTypeADP PayFreqType { get; set; }
		public PayRateHistTypeADP RateType { get; set; }
		public PayRateHistTypeADP PremiumRateFactorType { get; set; }
		public int version { get; set; }
	}

	public class PayRateHistSalaryKeyADP
	{
		public string pfid { get; set; }
		public string effDate { get; set; }
		public string increaseTypeOid { get; set; }
	}

	public class PayRateHistRateTypeADP
	{
		public string oid { get; set; }
		public string code { get; set; }
		public string description { get; set; }
		public string category { get; set; }
		public string abbrev { get; set; }
		public bool taxable { get; set; }
		public string subClass { get; set; }
		public string userLocaleCode { get; set; }
		public string prodLocaleCode { get; set; }
		public int version { get; set; }
	}

	public class PayRateHistPayFreqTypeADP
	{
		public string oid { get; set; }
		public string code { get; set; }
		public string description { get; set; }
		public string category { get; set; }
		public string abbrev { get; set; }
		public bool taxable { get; set; }
		public string subClass { get; set; }
		public string userLocaleCode { get; set; }
		public string prodLocaleCode { get; set; }
		public int version { get; set; }
	}

	public class PayRateHistTypeDataPayFreqADP
	{
		public PayRateHistPayFreqTypeADP[] data { get; set; }
		public bool isReadOnly { get; set; }
		public string requestResponseId { get; set; }
		public string serverTimeTaken { get; set; }
	}


	public class PayRateHistTypeADP
	{
		public bool? clientType { get; set; }
		public string oid { get; set; }
		public string code { get; set; }
		public string description { get; set; }
		public string name { get; set; }
		public string category { get; set; }
		public string abbrev { get; set; }
		public bool? active { get; set; }
		public bool? taxable { get; set; }
		public string subClass { get; set; }
		public string userLocaleCode { get; set; }
		public string prodLocaleCode { get; set; }
		public int version { get; set; }
	}

	public class PayRateHistTypeDataADP
	{
		public PayRateHistTypeADP[] data { get; set; }
		public bool isReadOnly { get; set; }
		public string requestResponseId { get; set; }
		public string serverTimeTaken { get; set; }
	}

	public class PayHistoryADP
	{
		public string status { get; set; }
		public PayHistoryDataADP data { get; set; }
		public bool isReadOnly { get; set; }
		public string requestResponseId { get; set; }
		public string serverTimeTaken { get; set; }
	}

	public class PayHistoryDataADP
	{
		public PayHistoryPayStmt[] payStatementList { get; set; }
		public string status { get; set; }
		public string message { get; set; }
	}

	public class PayHistoryPayStmt
	{
		public string checkGrossPayAmt { get; set; }
		public string checkNetPay { get; set; }
		public string totalTax { get; set; }
		public string totalDeduction { get; set; }
		public string totalMemos { get; set; }
		public string totalOtherPeriodEarnings { get; set; }
		public string totalTaxableBenefits { get; set; }
		public string checkGrossPayAmtFormattedStr { get; set; }
		public string checkNetPayFormattedStr { get; set; }
		public string totalTaxFormattedStr { get; set; }
		public string totalDeductionFormattedStr { get; set; }
		public string totalMemosFormattedStr { get; set; }
		public string totalOtherPeriodEarningsFormattedStr { get; set; }
		public string totalTaxableBenefitsFormattedStr { get; set; }
		public int totalDistributions { get; set; }
		public string coCodeFileNum { get; set; }
		public string checkNumber { get; set; }
		public string checkOrVoucher { get; set; }
		public string checkOrVoucherOid { get; set; }
		public string periodEndDate { get; set; }
		public string periodEndDateFormattedStr { get; set; }
		public string checkYearWeekPayrollNumber { get; set; }
		public string uniqueKey { get; set; }
		public bool ratesAvailable { get; set; }
		public string oid { get; set; }
		public string payDate { get; set; }
		public string payDateFormattedStr { get; set; }
	}

	public class PayRateHistAttributes
	{
		public bool FlsaOTFlag { get; set; }
		public bool ShowCancelAutomaticPay { get; set; }
		public string FutureTermPayrollScheduleMessage { get; set; }
		public float BlueCollarMinValue { get; set; }
		public bool ShowCurrencyConversion { get; set; }
		public bool isUSPosition { get; set; }
		public bool PendingWorkflow { get; set; }
		public bool DisablePremiumRateFactor { get; set; }
		public bool ShowPaymentSchedule { get; set; }
		public bool isCAPosition { get; set; }
		public bool isBasisOfPayStandardRateType { get; set; }
		public bool CalcRate2forSalariedEmployees { get; set; }
		public bool isPaidPosition { get; set; }
		public bool Reveal { get; set; }
		public bool HasPayroll { get; set; }
		public bool ReadOnly { get; set; }
		public bool isTIPsWGPSCompany { get; set; }
		public bool ShowFinancialTools { get; set; }
		public bool ShowFutureTerminationMessage { get; set; }
		public float WhiteCollarMaxValue { get; set; }
		public bool showNOSExpanded { get; set; }
		public bool EnableCompanyAutomaticPay { get; set; }
		public float BlueCollarMaxValue { get; set; }
		public bool showBasisOfPay { get; set; }
		public float WhiteCollarMinValue { get; set; }
		public bool EnableCancelAutomaticPay { get; set; }
		public bool VariablePayPendingWorkflow { get; set; }
		public bool isInternationalPosition { get; set; }
	}

	public class PayRateHistDataTypesADP
	{
		public PayRateHistTypeADP[] data { get; set; }
		public bool isReadOnly { get; set; }
		public string requestResponseId { get; set; }
		public string serverTimeTaken { get; set; }
	}

	public class PayRateHistWorkWeekADP
	{
		public WorkWeekDataADP[] workWeekData { get; set; }
		public string firstDayOfWeek { get; set; }
		public string effStartDate { get; set; }
		public string effEndDate { get; set; }
		public bool isReadOnly { get; set; }
		public string requestResponseId { get; set; }
		public string serverTimeTaken { get; set; }
	}

	public class WorkWeekDataADP
	{
		public string id { get; set; }
		public bool selected { get; set; }
	}

	public class PayRateHistWageEntityADP
	{
		public WageEntityADP[] data { get; set; }
		public bool isReadOnly { get; set; }
		public string requestResponseId { get; set; }
		public string serverTimeTaken { get; set; }
	}

	public class WageEntityADP
	{
		public bool disabled { get; set; }
		public bool escape { get; set; }
		public string label { get; set; }
		public string value { get; set; }
		public bool noSelectionOption { get; set; }
	}
}
