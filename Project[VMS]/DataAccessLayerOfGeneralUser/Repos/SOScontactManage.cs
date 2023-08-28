using DataAccessLayerOfGeneralUser.DataBase;
using DataAccessLayerOfGeneralUser.DTO;
using DataAccessLayerVMS.Interface;
using DataAccessLayerVMS.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerOfGeneralUser.Repos
{
    internal class SOScontactManage : DataBaseConnection, BasicOperation<SOSinfo, int, bool>
    {
        public bool Create(SOSinfo values)
        {
            db.SOSinfoes.Add(values);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var existData = Get(id);
            db.SOSinfoes.Remove(existData);
            return db.SaveChanges() > 0;
        }

        public SOSinfo Get(int id)
        {
            return db.SOSinfoes.Find(id);
        }

        public List<SOSinfo> Get()
        {
            return db.SOSinfoes.ToList();
        }

        public bool Update(SOSinfo values, int id)
        {
            var newData = new SOSDTO();
            newData.id = values.id;
            newData.SOScontact = values.SOScontact;
            newData.UserID = values.UserID;

            var existData = Get(values.id);
            existData.SOScontact = newData.SOScontact;
            return db.SaveChanges() > 0;
        }
    }
}
