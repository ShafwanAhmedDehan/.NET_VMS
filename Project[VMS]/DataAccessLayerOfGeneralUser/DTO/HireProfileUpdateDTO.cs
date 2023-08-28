using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerOfGeneralUser.DTO
{
    public class HireProfileUpdateDTO
    {
        public int id { get; set; }
        public int MonthlySalary { get; set; }
        public int DailySalary { get; set; }
        public int UID { get; set; }
    }
}
