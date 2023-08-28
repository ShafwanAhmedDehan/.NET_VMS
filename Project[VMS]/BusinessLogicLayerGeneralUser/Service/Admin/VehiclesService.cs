using AutoMapper;
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
    public class VehiclesService
    {
        public static List<VehicleDTO> ShowAllVehicle()
        {
            var data = DataAccessPanel.VehicleControl().Get();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Vehicle, VehicleDTO>();
            });
            var mapper = new Mapper(config);
            var convertedValue = mapper.Map<List<VehicleDTO>>(data);
            return convertedValue;
        }



        public static bool DeleteUserVehicle(int id)
        {
            return DataAccessPanel.VehicleControl().Delete(id);
        }
    }
}
