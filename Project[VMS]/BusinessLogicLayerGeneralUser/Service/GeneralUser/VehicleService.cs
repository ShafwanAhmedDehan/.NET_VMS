using AutoMapper;
using BusinessLogicLayerVMS.DTO;
using DataAccessLayerOfGeneralUser.DataBase;
using DataAccessLayerVMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayerGeneralUser.Service.GeneralUser
{
    public class VehicleService
    {
        public static bool AddVehicle(VehicleDTO data)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<VehicleDTO, Vehicle>();
            });
            var mapper = new Mapper(config);
            var conv = mapper.Map<Vehicle>(data);
            Console.WriteLine(conv);
            return DataAccessPanel.VehicleControl().Create(conv);
        }

        public static List<VehicleDTO> showVehicleInfo(int id)
        {
            var data = (from n in DataAccessPanel.VehicleControl().Get()
                        where n.OwnerID == id
                        select new VehicleDTO
                        {
                            VehicleNumber = n.VehicleNumber,
                            VehicleType = n.VehicleType,
                            id = n.id,
                            OwnerID = n.OwnerID
                        }).ToList();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Vehicle, VehicleDTO>();
            });
            var mapper = new Mapper(config);
            var convertedValue = mapper.Map<List<VehicleDTO>>(data);
            return convertedValue;
        }

        public static bool DeleteVehicleInfo(int id)
        {
            return DataAccessPanel.VehicleControl().Delete(id);
        }
    }
}
