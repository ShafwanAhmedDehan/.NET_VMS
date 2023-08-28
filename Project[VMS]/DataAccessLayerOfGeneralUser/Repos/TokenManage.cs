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
    internal class TokenManage : DataBaseConnection, BasicOperation<AccessToken, int, AccessToken>
    {
        public AccessToken Create(AccessToken values)
        {
            db.AccessTokens.Add(values);
            if(db.SaveChanges() > 0)
            {
                return values;
            }
            else
            {
                return null;
            }
        }

        public bool Delete(int id)
        {
            var userOBJ = Get(id);
            db.AccessTokens.Remove(userOBJ);
            return db.SaveChanges() > 0;
        }

        public AccessToken Get(int id)
        {
            return db.AccessTokens.Find(id);
        }

        public List<AccessToken> Get()
        {
            return db.AccessTokens.ToList();
        }

        public AccessToken Update(AccessToken values, int id)
        {
            throw new NotImplementedException();
        }
    }
}
