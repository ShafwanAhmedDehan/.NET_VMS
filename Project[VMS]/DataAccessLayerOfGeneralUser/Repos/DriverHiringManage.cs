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
    internal class DriverHiringManage : DataBaseConnection, BasicOperation<HiringInfo, int, bool>
    {
        public bool Create(HiringInfo values)
        {
            db.HiringInfoes.Add(values);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var ExistData = Get(id);
            db.HiringInfoes.Remove(ExistData);
            return db.SaveChanges() > 0;
        }

        public HiringInfo Get(int id)
        {
            return db.HiringInfoes.Find(id);
        }

        public List<HiringInfo> Get()
        {
            return db.HiringInfoes.ToList();
        }

        public bool Update(HiringInfo values, int id)
        {
            var NewData = new HireProfileUpdateDTO();
            NewData.id = values.id;
            NewData.MonthlySalary = values.DailySalary;
            NewData.UID = values.UID;

            var existData = Get(id);
            existData.id = id;
            existData.MonthlySalary = NewData.MonthlySalary;
            existData.DailySalary = NewData.DailySalary;
            existData.UID = NewData.UID;

            return db.SaveChanges() > 0;
        }
    }
}
