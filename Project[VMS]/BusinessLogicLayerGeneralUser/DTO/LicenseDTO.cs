using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayerVMS.DTO
{
    public class LicenseDTO
    {
        public int id { get; set; }
        public string LicenseID { get; set; }
        public System.DateTime Issue { get; set; }
        public System.DateTime Expire { get; set; }
        public int UID { get; set; }
    }
}
