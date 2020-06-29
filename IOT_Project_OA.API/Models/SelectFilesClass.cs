using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IOT_Project_OA.API.Models
{
    public class SelectFilesClass
    {
        public string Assets_No { get; set; }
        public string Assets_Name { get; set; }
        public string Assets_Class { get; set; }
        public string Assets_Type { get; set; }
        public string State { get; set; }
        public int PageIndex { get; set; }
    }
}
