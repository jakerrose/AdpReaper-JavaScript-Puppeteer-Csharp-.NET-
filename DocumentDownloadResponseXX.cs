using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lifewell_Reaper.Classes
{
	public class DocumentDownloadResponse
	{
		public string DocumentListId { get; set; }
		public string Url { get; set; }
		public string FullUrl { get; set; }
		public string FullUrlSb { get; set; }
		public string MimeType { get; set; }
	}

	public class ResourceUri
	{
		public string href { get; set; }
	}

	public class ApplicationCode
	{
		public string code { get; set; }
		public string typeCode { get; set; }
		public string message { get; set; }
	}

	public class ADPBillGOEmployeeI9DocumentResponse
	{
		public ADPBillGOEmployeeI9DocumentData[] Data { get; set; }
	}

	public class ADPBillGOEmployeeI9DocumentData
	{
		public ADPBillGOEmployeeI9Docdata data { get; set; }
		public bool isReadOnly { get; set; }
		public string requestResponseId { get; set; }
		public string serverTimeTaken { get; set; }
	}

	public class ADPBillGOEmployeeI9Docdata
	{
		public string responseCode { get; set; }
		public string methodCode { get; set; }
		public ResourceUri resourceUri { get; set; }
		public string serverRequestDateTime { get; set; }
		public ApplicationCode applicationCode { get; set; }
		public ADPBillGOEmployeeI9Docs[] data { get; set; }
	}

	public class ADPBillGOEmployeeI9Docs
	{
		public string documentId { get; set; }
		public string displayName { get; set; }
		public string fileName { get; set; }
		public int? fileSize { get; set; }
		public string documentType { get; set; }
		public string contentStreamMimeType { get; set; }
		public string category { get; set; }
		public string subcategory { get; set; }
		public string keywords { get; set; }
		public bool? readOnly { get; set; }
		public string attachmentType { get; set; }
		public string attachmentOID { get; set; }
		public string indexStatus { get; set; }
		public string creationDate { get; set; }
		public ResourceUri documentUri { get; set; }
		public string documentStatus { get; set; }
		public string srcAppFeatureId { get; set; }
		public string srcAppId { get; set; }
		public bool? containsNotes { get; set; }
		public ADPEmployeeDocNotes[] notes { get; set; }
		public bool? requestESignature { get; set; }
		public bool? nonAccessibleDocument { get; set; }
		public bool? employeeViewOnlyAccess { get; set; }
		public bool? synced { get; set; }
		public bool? fillableForm { get; set; }
		public string creationDateStr { get; set; }
		public string expirationDateStr { get; set; }
		public string effectiveDateStr { get; set; }
	}

	public class ADPBillGOEmployeeDocumentResponse
	{
		public ADPBillGOEmployeeDocdata Data { get; set; }
	}

	public class ADPBillGOEmployeeDocdata
	{
		public string responseCode { get; set; }
		public string methodCode { get; set; }
		public ResourceUri resourceUri { get; set; }
		public string serverRequestDateTime { get; set; }
		public ApplicationCode applicationCode { get; set; }
		public ADPBillGOEmployeeDocs[] data { get; set; }
	}

	public class ADPBillGOEmployeeDocs
	{
		public string documentId { get; set; }
		public string displayName { get; set; }
		public string fileName { get; set; }
		public int? fileSize { get; set; }
		public string documentType { get; set; }
		public string contentStreamMimeType { get; set; }
		public string category { get; set; }
		public string subcategory { get; set; }
		public string keywords { get; set; }
		public bool? readOnly { get; set; }
		public string attachmentType { get; set; }
		public string attachmentOID { get; set; }
		public string indexStatus { get; set; }
		public string creationDate { get; set; }
		public ResourceUri documentUri { get; set; }
		public string documentStatus { get; set; }
		public string srcAppFeatureId { get; set; }
		public string srcAppId { get; set; }
		public bool? containsNotes { get; set; }
		public ADPEmployeeDocNotes[] notes { get; set; }
		public bool? requestESignature { get; set; }
		public bool? nonAccessibleDocument { get; set; }
		public bool? employeeViewOnlyAccess { get; set; }
		public bool? synced { get; set; }
		public bool? fillableForm { get; set; }
		public string creationDateStr { get; set; }
		public string expirationDateStr { get; set; }
		public string effectiveDateStr { get; set; }
	}

	public class ADPEmployeeDocNotes
	{
		public string date { get; set; }
		public string noteText { get; set; }
		public string lastName { get; set; }
		public string firstName { get; set; }
		public string aoid { get; set; }
	}

}
