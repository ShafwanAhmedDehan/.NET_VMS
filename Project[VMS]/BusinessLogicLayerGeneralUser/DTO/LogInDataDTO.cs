using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayerVMS.DTO
{
    public class LogInDataDTO
    {
        public int Id { get; set; }
        public string Emailphn { get; set; }
        public string Password { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Gender { get; set; }
        public string Nid { get; set; }
        public string Address { get; set; }
        public int Usertype { get; set; }
    }
}
