using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mesa
{
	internal class PaychexEmpDocument
	{
		public string type { get; set; }
		public string docId { get; set; }
		public string name { get; set; }
		public string mimeType { get; set; }
		public string createdOn { get; set; }
		public string lastUpdatedOn { get; set; }
		public string createdBySSOGuid { get; set; }
		public string lastModifiedBySSOGuid { get; set; }
		public string category { get; set; }
		public string classification { get; set; }
		public string startDate { get; set; }
		public bool isFillable { get; set; }
		public bool deleted { get; set; }
		public string ackDaysUntilDue { get; set; }
		public string ackRequestDate { get; set; }
		public string ackDate { get; set; }
		public string parentId { get; set; }
		public bool acknowledge { get; set; }
		public string signedWithDocId { get; set; }
		public string signedDocName { get; set; }
		public string signatureConfirmedDateTime { get; set; }
		public bool isDeletable { get; set; }
		public bool onboarding { get; set; }
		public string caId { get; set; }
		public bool request { get; set; }
		public string weId { get; set; }
		public bool workerVisible { get; set; }
		public string workerVisibleDate { get; set; }
		public bool shallowCopy { get; set; }
		public bool hideRedirectDialog { get; set; }
		public bool eSign { get; set; }
	}
	internal class PaychexEmpDocumentWrapper
	{
		public List<PaychexEmpDocument> Content { get; set; }
	}
}
