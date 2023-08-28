using DataAccessLayerOfGeneralUser.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerVMS.Repos
{
    internal class DataBaseConnection
    {
        protected VMSSystemEntities db;
        protected DataBaseConnection()
        {
            db = new VMSSystemEntities();
        }
    }
}
