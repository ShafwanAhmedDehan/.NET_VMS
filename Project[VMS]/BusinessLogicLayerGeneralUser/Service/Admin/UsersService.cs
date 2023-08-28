using AutoMapper;
using BusinessLogicLayerGeneralUser.Service.Messages;
using BusinessLogicLayerVMS.DTO;
using DataAccessLayerOfGeneralUser.DataBase;
using DataAccessLayerVMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayerGeneralUser.Service.Admin
{
    public class UsersService
    {
        public static List<UserDTO> ShowAllUser()
        {
            var data = DataAccessPanel.AdminControl().Get();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<UserVM, UserDTO>();
            });
            var mapper = new Mapper(config);
            var convertedValue = mapper.Map<List<UserDTO>>(data);
            return convertedValue;
        }

        public static bool DeleteUserAccount(int id)
        {
            return DataAccessPanel.AdminControl().Delete(id);
        }

        public static bool CreateUserAccount(UserDTO user)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<UserDTO, UserVM>();
            });
            var mapper = new Mapper(config);
            var conv = mapper.Map<UserVM>(user);
            var Response = DataAccessPanel.AdminControl().Create(conv);
            if (Response)
            {
                return MessageService.SendMessage(user.emailphn);
            }
            else
            {
                return false;
            }
        }
    }
}
