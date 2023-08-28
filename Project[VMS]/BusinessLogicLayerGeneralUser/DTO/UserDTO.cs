using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayerVMS.DTO
{
    public class UserDTO
    {
        public int id { get; set; }
        public string emailphn { get; set; }
        public string password { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Gender { get; set; }
        public string nid { get; set; }
        public string address { get; set; }
        public int usertype { get; set; }
    }
}
