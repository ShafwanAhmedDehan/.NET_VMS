using DataAccessLayerOfGeneralUser.DataBase;
using DataAccessLayerVMS.DTO;
using DataAccessLayerVMS.Interface;
using DataAccessLayerVMS.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerVMS.Repos
{
    internal class GeneralUserManage : DataBaseConnection, BasicOperation<UserVM, int, bool>
    {
        public bool Create(UserVM values)
        {
            db.UserVMS.Add(values);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var userOBJ = Get(id);
            db.UserVMS.Remove(userOBJ);
            return db.SaveChanges() > 0;
        }
        
        public UserVM Get(int id)
        {
            return db.UserVMS.Find(id);
        }

        public List<UserVM> Get()
        {
            return db.UserVMS.ToList();
        }

        public bool Update(UserVM values, int id)
        {
            var infoDTO = new InfoDTO();
            infoDTO.Emailphn = values.emailphn;
            infoDTO.Password = values.password;
            infoDTO.Fname = values.Fname;
            infoDTO.Lname = values.Lname;
            infoDTO.Lname = values.nid;
            infoDTO.Usertype = values.usertype;
            infoDTO.Gender = values.Gender;
            infoDTO.Address = values.address;

            var existData = Get(id);
            existData.id = id;
            existData.emailphn = infoDTO.Emailphn;
            existData.password = infoDTO.Password;
            existData.Fname = infoDTO.Fname;
            existData.Lname = infoDTO.Lname;
            existData.nid = infoDTO.Lname;
            existData.usertype = infoDTO.Usertype;
            existData.Gender = infoDTO.Gender;
            existData.address = infoDTO.Address;

            return db.SaveChanges() > 0;
        }
    }
}
