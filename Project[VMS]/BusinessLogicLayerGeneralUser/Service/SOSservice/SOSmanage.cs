using AutoMapper;
using BusinessLogicLayerGeneralUser.DTO;
using BusinessLogicLayerVMS.DTO;
using DataAccessLayerOfGeneralUser.DataBase;
using DataAccessLayerVMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayerGeneralUser.Service.SOSservice
{
    public class SOSmanage
    {
        public static bool AddSOS(sosDTO SOSdata)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<sosDTO, SOSinfo>();
            });
            var mapper = new Mapper(config);
            var conv = mapper.Map<SOSinfo>(SOSdata);
            return DataAccessPanel.SOScontrol().Create(conv);
        }

        public static bool DeleteSOScontact(int id)
        {
            return DataAccessPanel.SOScontrol().Delete(id);
        }

        public static sosDTO ViewSOSinfo(int id)
        {
            var data = ShowAllSOSinfo();
            var SOSID = (from n in data
                         where n.UserID == id
                         select new sosDTO
                         {
                             id = n.id,
                             SOScontact = n.SOScontact,
                             UserID = n.UserID
                         }).FirstOrDefault(); 
            
            return SOSID;
        }

        public static List<sosDTO> ShowAllSOSinfo()
        {
            var data = DataAccessPanel.SOScontrol().Get();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<SOSinfo, sosDTO>();
            });
            var mapper = new Mapper(config);
            var convertedValue = mapper.Map<List<sosDTO>>(data);
            return convertedValue;
        }

        public static bool UpdateSOScontact (sosDTO values, int Uid)
        {
            var data = ShowAllSOSinfo();
            var SOSID = (from n in data where n.UserID == Uid 
             select new sosDTO
             {
                 id = n.id
             }).FirstOrDefault();
            
            if (SOSID != null)
            {
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<sosDTO, SOSinfo>();
                });
                var mapper = new Mapper(config);
                var conv = mapper.Map<SOSinfo>(values);
                Console.WriteLine(conv);
                return DataAccessPanel.SOScontrol().Update(conv, SOSID.id);
            }
            else
            {
                return false;
            }
        }

    }
}
