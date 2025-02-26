using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mesa
{
	internal class PaychexEmp
	{
		public string clientLegalNm { get; set; }
		public string wrkrFullNm { get; set; }
		public string wrkrFullNameDeepLink { get; set; }
		public string wrkrRefNbr { get; set; }
		public string vdcopCopNm { get; set; }
		public string whResrStusNm { get; set; }
		public string wseOrigHireDt { get; set; }
		public string wseTermDtCombined { get; set; }
		public string wrkrBirthDt { get; set; }
		public string wrkrTaxIdFrmtd { get; set; }
		public int eldSurWrkrId { get; set; }
		public int sortField { get; set; }
	}

	internal class PaychexEmpDeepLinkJson
	{
		public string clientId { get; set; }
		public string ssoCaid { get; set; }
		public string workerId { get; set; }
	}
}
