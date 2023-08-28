using DataAccessLayerOfGeneralUser.DataBase;
using DataAccessLayerVMS.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerVMS.Repos
{
    internal class VehicleManage : DataBaseConnection, BasicOperation<Vehicle, int, bool>
    {
        public bool Create(Vehicle values)
        {
            db.Vehicles.Add(values);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var existData = Get(id);
            db.Vehicles.Remove(existData);
            return db.SaveChanges() > 0;
        }

        public Vehicle Get(int id)
        {
            return db.Vehicles.Find(id);
        }

        public List<Vehicle> Get()
        {
            return db.Vehicles.ToList();
        }

        public bool Update(Vehicle values, int id)
        {
            throw new NotImplementedException();
        }
    }
}
