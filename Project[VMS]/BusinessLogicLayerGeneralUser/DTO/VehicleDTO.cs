using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayerVMS.DTO
{
    public class VehicleDTO
    {
        public int id { get; set; }
        public string VehicleType { get; set; }
        public string VehicleNumber { get; set; }
        public int OwnerID { get; set; }
    }
}
