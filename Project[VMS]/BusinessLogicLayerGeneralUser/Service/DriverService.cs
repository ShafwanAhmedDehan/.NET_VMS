using AutoMapper;
using BusinessLogicLayerVMS.DTO;
using DataAccessLayerOfGeneralUser.DataBase;
using DataAccessLayerVMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayerVMS.Service
{
    public class DriverService
    {
        public static bool CreateAccount(UserDTO user)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<UserDTO, UserVM>();
            });
            var mapper = new Mapper(config);
            var conv = mapper.Map<UserVM>(user);
            return DataAccessPanel.DriverControl().Create(conv);
        }

        public static LogInDataDTO login(LoginDTO loginData)
        {
            var data = (from n in DataAccessPanel.DriverControl().Get()
                        where n.emailphn == loginData.Emailphn && n.password == loginData.Password
                        select new LogInDataDTO
                        {
                            Id = n.id,
                            Emailphn = n.emailphn,
                            Password = n.password,
                            Fname = n.Fname,
                            Lname = n.Lname,
                            Gender = n.Gender,
                            Nid = n.nid,
                            Address = n.address,
                            Usertype = n.usertype
                        }).FirstOrDefault();
            Console.WriteLine(data);

            if (data != null)
            {
                data.Password = "";
                return data;
            }
            else
            {
                var LoginError = new LogInDataDTO();
                LoginError.Emailphn = "Wrong Email/Phone";
                LoginError.Password = "Worng Password";
                return LoginError;
            }
        }

        public static UserDTO viewProfile(int id)
        {
            var UserData = DataAccessPanel.DriverControl().Get(id);
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<UserVM, UserDTO>();
            });
            var mapper = new Mapper(config);
            var convertedValue = mapper.Map<UserDTO>(UserData);
            return convertedValue;
        }

        public static bool UpdateProfile (UserDTO value, int id)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<UserDTO, UserVM>();
            });
            var mapper = new Mapper(config);
            var conv = mapper.Map<UserVM>(value);
            Console.WriteLine(conv);
            return DataAccessPanel.DriverControl().Update(conv,id);
        }

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

        public static bool DeleteValue (int id)
        {
            return DataAccessPanel.LicenseControl().Delete(id);
        }

    }
}
