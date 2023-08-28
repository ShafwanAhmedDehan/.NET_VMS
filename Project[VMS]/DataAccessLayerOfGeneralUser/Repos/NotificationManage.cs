using DataAccessLayerOfGeneralUser.DataBase;
using DataAccessLayerVMS.Interface;
using DataAccessLayerVMS.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerOfGeneralUser.Repos
{
    internal class NotificationManage : DataBaseConnection, BasicOperation<Notification, int, bool>
    {
        public bool Create(Notification values)
        {
            db.Notifications.Add(values);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var ExistData = Get(id);
            db.Notifications.Remove(ExistData);
            return db.SaveChanges() > 0;
        }

        public Notification Get(int id)
        {
            return db.Notifications.Find(id);
        }

        public List<Notification> Get()
        {
            return db.Notifications.ToList();
        }

        public bool Update(Notification values, int id)
        {
            throw new NotImplementedException();
        }
    }
}
