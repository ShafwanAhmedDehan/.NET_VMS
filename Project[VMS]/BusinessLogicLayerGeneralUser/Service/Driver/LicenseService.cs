using AutoMapper;
using BusinessLogicLayerVMS.DTO;
using DataAccessLayerOfGeneralUser.DataBase;
using DataAccessLayerVMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayerGeneralUser.Service.Driver
{
    public class LicenseService
    {
        public static bool AddLicense(LicenseDTO data)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<LicenseDTO, DriverLicense>();
            });
            var mapper = new Mapper(config);
            var conv = mapper.Map<DriverLicense>(data);
            Console.WriteLine(conv);
            return DataAccessPanel.LicenseControl().Create(conv);
        }

        public static List<LicenseDTO> ShowLicenseInfo(int id)
        {
            var data = (from n in DataAccessPanel.LicenseControl().Get()
                        where n.UID == id
                        select new LicenseDTO
                        {
                            LicenseID = n.LicenseID,
                            Issue = n.Issue,
                            Expire = n.Expire,
                            id = n.id,
                            UID = n.UID
                        }).ToList();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<DriverLicense, LicenseDTO>();
            });
            var mapper = new Mapper(config);
            var convertedValue = mapper.Map<List<LicenseDTO>>(data);
            return convertedValue;
        }

        public static bool DeleteValue(int id)
        {
            return DataAccessPanel.LicenseControl().Delete(id);
        }
    }
}
