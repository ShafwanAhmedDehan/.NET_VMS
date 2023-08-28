using AutoMapper;
using BusinessLogicLayerGeneralUser.DTO;
using DataAccessLayerOfGeneralUser.DataBase;
using DataAccessLayerOfGeneralUser.DTO;
using DataAccessLayerVMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayerGeneralUser.Service.Driver
{
    public class HiringValueService
    {
        public static bool CreateHiringProfile(HireValueDTO Values)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<HireValueDTO, HiringInfo>();
            });
            var mapper = new Mapper(config);
            var conv = mapper.Map<HiringInfo>(Values);
            return DataAccessPanel.HireValueControl().Create(conv);
        }

        public static HireValueDTO ViewHireInfo(int id)
        {
            var Data = DataAccessPanel.HireValueControl().Get(id);
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<HiringInfo, HireValueDTO>();
            });
            var mapper = new Mapper(config);
            var convertedValue = mapper.Map<HireValueDTO>(Data);
            return convertedValue;
        }

        public static bool DeleteHireProfile (int id)
        {
            return DataAccessPanel.HireValueControl().Delete(id);
        }

        public static bool UpdateHireProfile(HireValueDTO value, int id)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<HireValueDTO, HiringInfo>();
            });
            var mapper = new Mapper(config);
            var conv = mapper.Map<HiringInfo>(value);
            return DataAccessPanel.HireValueControl().Update(conv, id);
        }
    }
}
