using AutoMapper;
using BusinessLogicLayerGeneralUser.DTO;
using DataAccessLayerOfGeneralUser.DataBase;
using DataAccessLayerVMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayerGeneralUser.Service.GeneralUser
{
    public class NotificationService
    {
        public static bool CreateNotification(NotificationDTO value)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<NotificationDTO, Notification>();
            });
            var mapper = new Mapper(config);
            var conv = mapper.Map<Notification>(value);
            return DataAccessPanel.NotificationControl().Create(conv);
        }

        public static List<NotificationDTO> ShowAllNotification(int Uid)
        {
            var data = DataAccessPanel.NotificationControl().Get();
            var UsersNotifi = (from n in data where n.UID == Uid select n).ToList();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Notification, NotificationDTO>();
            });
            var mapper = new Mapper(config);
            var convertedValue = mapper.Map<List<NotificationDTO>>(UsersNotifi);
            return convertedValue;
        }

        public static bool DeleteNotification(int id)
        {
            return DataAccessPanel.NotificationControl().Delete(id);
        }
    }
}
