using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayerGeneralUser.DTO
{
    public class TokenDTO
    {
        public int id { get; set; }
        public string TokenValue { get; set; }
        public string Email { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime ExpireTime { get; set; }
        public int UID { get; set; }
    }
}
