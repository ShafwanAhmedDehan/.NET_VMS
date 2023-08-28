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
    internal class NotePadManage : DataBaseConnection, BasicOperation<NotePad, int, bool>
    {
        public bool Create(NotePad values)
        {
            db.NotePads.Add(values);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var ExistObj = Get(id);
            db.NotePads.Remove(ExistObj);
            return db.SaveChanges() > 0;
        }

        public NotePad Get(int id)
        {
            return db.NotePads.Find(id);
        }

        public List<NotePad> Get()
        {
            return db.NotePads.ToList();
        }

        public bool Update(NotePad values, int id)
        {
            throw new NotImplementedException();
        }
    }
}
