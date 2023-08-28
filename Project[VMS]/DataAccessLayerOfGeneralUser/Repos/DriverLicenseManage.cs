using DataAccessLayerOfGeneralUser.DataBase;
using DataAccessLayerVMS.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerVMS.Repos
{
    internal class DriverLicenseManage : DataBaseConnection, BasicOperation<DriverLicense, int, bool>
    {
        public bool Create(DriverLicense values)
        {
            db.DriverLicenses.Add(values);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var userOBJ = Get(id);
            db.DriverLicenses.Remove(userOBJ);
            return db.SaveChanges() > 0;
        }
        public DriverLicense Get(int id)
        {
            return db.DriverLicenses.Find(id);
        }

        public List<DriverLicense> Get()
        {
            return db.DriverLicenses.ToList();
        }

        public bool Update(DriverLicense values, int id)
        {
            throw new NotImplementedException();
        }
    }
}
