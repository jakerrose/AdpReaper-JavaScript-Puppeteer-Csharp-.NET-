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
}
