using AutoMapper;
using BusinessLogicLayerGeneralUser.DTO;
using BusinessLogicLayerVMS.DTO;
using BusinessLogicLayerVMS.Service;
using DataAccessLayerOfGeneralUser.DataBase;
using DataAccessLayerVMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BusinessLogicLayerGeneralUser.Service.TokenForAll
{
    public class TokenService
    {
        public static TokenDTO GeneralLogin(LoginDTO data)
        {
            var user = GeneralUserService.login(data);
            if (user.Emailphn != "Wrong Email/Phone" && user.Password != "Worng Password")
            {
                var token = new AccessToken();
                token.TokenValue = Guid.NewGuid().ToString();
                token.Email = user.Emailphn;
                token.CreateTime = DateTime.Now;
                token.ExpireTime = DateTime.Now.AddMinutes(5);
                token.UID = user.Id;
                var NewToken = DataAccessPanel.TokenControl().Create(token);
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<AccessToken, TokenDTO>();
                });
                var mapper = new Mapper(config);
                var TokenData = mapper.Map<TokenDTO>(NewToken);
                return TokenData;
            }
            return null;
        }

        public static TokenDTO DriverLogin(LoginDTO data)
        {
            var user = DriverService.login(data);
            if (user.Emailphn != "Wrong Email/Phone" && user.Password != "Worng Password")
            {
                var token = new AccessToken();
                token.TokenValue = Guid.NewGuid().ToString();
                token.Email = user.Emailphn;
                token.CreateTime = DateTime.Now;
                token.ExpireTime = DateTime.Now.AddMinutes(5);
                token.UID = user.Id;
                var NewToken = DataAccessPanel.TokenControl().Create(token);
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<AccessToken, TokenDTO>();
                });
                var mapper = new Mapper(config);
                var TokenData = mapper.Map<TokenDTO>(NewToken);
                return TokenData;
            }
            return null;
        }

        public static TokenDTO AdminLogin(LoginDTO data)
        {
            var user = AdminService.login(data);
            if (user.Emailphn != "Wrong Email/Phone" && user.Password != "Worng Password")
            {
                var token = new AccessToken();
                token.TokenValue = Guid.NewGuid().ToString();
                token.Email = user.Emailphn;
                token.CreateTime = DateTime.Now;
                token.ExpireTime = DateTime.Now.AddMinutes(5);
                token.UID = user.Id;
                var NewToken = DataAccessPanel.TokenControl().Create(token);
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<AccessToken, TokenDTO>();
                });
                var mapper = new Mapper(config);
                var TokenData = mapper.Map<TokenDTO>(NewToken);
                return TokenData;
            }
            return null;
        }


        public static bool IsTokenValid(string token)
        {
            var TokenValueFound = (from t in DataAccessPanel.TokenControl().Get()
                      where t.TokenValue.Equals(token)
                      select t).SingleOrDefault();
            if (TokenValueFound != null && TokenValueFound.CreateTime.AddMinutes(5) >= DateTime.Now)
            {
                return true;
            }
            return false;
        }
    }
}
