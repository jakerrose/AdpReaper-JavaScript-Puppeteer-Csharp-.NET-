using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lifewell_Reaper.Classes
{
    internal class DocumentListResponse
    {
        public List<DocumentListItem> Result { get; set; }
        public int TotalCount { get; set; }
    }

    public class DocumentListItem
    {
        public string DocumentListId { get; set; }
        public string MetadataSourceId { get; set; }
        public string DisplayName { get; set; }
        public string MetadataSource { get; set; }
        public Storageid StorageId { get; set; }
        public string Category { get; set; }
        public Employee Employee { get; set; }
        public Fileaccess FileAccess { get; set; }
        public bool EmployeeConfidential { get; set; }
        public bool CompanyConfidential { get; set; }
        public DateTime UploadedDate { get; set; }
        public DateTime ReceivedDate { get; set; }
        public DateTime LastChanged { get; set; }
    }

    public class Storageid
    {
        public string FileGroup { get; set; }
    }

    public class Employee
    {
        public string Co { get; set; }
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string PreferredName { get; set; }
        public string LastName { get; set; }
    }

    public class Fileaccess
    {
        public bool Add { get; set; }
        public bool View { get; set; }
        public bool Edit { get; set; }
        public bool Delete { get; set; }
        public object[] Fields { get; set; }
    }

}
