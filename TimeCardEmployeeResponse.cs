using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lifewell_Reaper.Classes
{
    public class TimeCardEmployeeResponse
    {
        public List<Datum> data { get; set; }
        public int total { get; set; }
    }

    public class Datum
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeNumber { get; set; }
        public string BadgeNumber { get; set; }
    }

}
