using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryItADP
{

	// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
	public class DetailData
	{
		public bool masked { get; set; }
		public PayStatement2 payStatement { get; set; }
		public bool stopPaymentFeatureAvailable { get; set; }
		public bool readOnly { get; set; }
		public bool payStatementFeatureAvailable { get; set; }
		public string status { get; set; }
	}

	public class DistributionsList
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
	}

	public class HoursEarningsRateList
	{
		public string earnings { get; set; }
		public string fieldNumber { get; set; }
		public string description { get; set; }
		public string displayRate { get; set; }
		public string otherPayrollBegin { get; set; }
		public string otherPayrollEnd { get; set; }
		public bool accumulated { get; set; }
		public bool federalIncomeTaxable { get; set; }
		public bool quebecIncomeTaxable { get; set; }
		public bool isFootnote { get; set; }
		public List<object> accumulatedData { get; set; }
	}

	public class MemosList
	{
		public string code { get; set; }
		public string description { get; set; }
		public string codeAndDesc { get; set; }
		public string amount { get; set; }
		public bool accumulated { get; set; }
		public List<object> accumulatedData { get; set; }
	}

	public class OtherDeductionsList
	{
		public string code { get; set; }
		public string description { get; set; }
		public string codeAndDesc { get; set; }
		public string category { get; set; }
		public string amount { get; set; }
		public bool accumulated { get; set; }
		public List<object> accumulatedData { get; set; }
	}

	public class OvertimeHoursEarningsList
	{
		public string code { get; set; }
		public string description { get; set; }
		public object codeAndDesc { get; set; }
		public object category { get; set; }
		public object amount { get; set; }
	}

	public class PayStatement2
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
		public string totalHoursWorked { get; set; }
		public string companyCode { get; set; }
		public string fileNumber { get; set; }
		public string payrollNumber { get; set; }
		public string checkNumber { get; set; }
		public string checkOrVoucher { get; set; }
		public object clock { get; set; }
		public string homeDepartment { get; set; }
		public object workedInDepartment { get; set; }
		public string periodStartDate { get; set; }
		public string periodEndDate { get; set; }
		public string mailLabel { get; set; }
		public string companyMailLabel { get; set; }
		public string periodStartDateFormattedStr { get; set; }
		public string periodEndDateFormattedStr { get; set; }
		public string basisOfPay { get; set; }
		public List<DistributionsList> distributionsList { get; set; }
		public List<TaxDeductionsList> taxDeductionsList { get; set; }
		public List<OtherDeductionsList> otherDeductionsList { get; set; }
		public List<object> taxableBenefitsList { get; set; }
		public bool ratesAvailable { get; set; }
		public List<RegularHoursEarningsList> regularHoursEarningsList { get; set; }
		public List<HoursEarningsRateList> hoursEarningsRateList { get; set; }
		public List<OvertimeHoursEarningsList> overtimeHoursEarningsList { get; set; }
		public List<object> additionalHoursEarningsList { get; set; }
		public List<TakeHomeList> takeHomeList { get; set; }
		public List<MemosList> memosList { get; set; }
		public List<object> otherPeriodEarningsList { get; set; }
		public string oid { get; set; }
		public string payDate { get; set; }
		public string year { get; set; }
		public string week { get; set; }
		public string payDateFormattedStr { get; set; }

	}

	public class RegularHoursEarningsList
	{
		public string code { get; set; }
		public string description { get; set; }
		public object codeAndDesc { get; set; }
		public object category { get; set; }
		public object amount { get; set; }
	}

	public class DetailRoot
	{
		public string status { get; set; }
		public DetailData data { get; set; }
		public string requestResponseId { get; set; }
		public string serverTimeTaken { get; set; }
	}

	public class TakeHomeList
	{
		public string code { get; set; }
		public string description { get; set; }
		public string codeAndDesc { get; set; }
		public string amount { get; set; }
		public bool accumulated { get; set; }
		public List<object> accumulatedData { get; set; }
	}

	public class TaxDeductionsList
	{
		public string code { get; set; }
		public string description { get; set; }
		public string codeAndDesc { get; set; }
		public string category { get; set; }
		public string amount { get; set; }
		public bool accumulated { get; set; }
		public List<object> accumulatedData { get; set; }
	}


}

