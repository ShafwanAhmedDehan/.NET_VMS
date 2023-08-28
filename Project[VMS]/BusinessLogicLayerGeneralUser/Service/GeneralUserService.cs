using AutoMapper;
using BusinessLogicLayerVMS.DTO;
using DataAccessLayerOfGeneralUser;
using DataAccessLayerOfGeneralUser.DataBase;
using DataAccessLayerVMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayerVMS.Service
{
    public class GeneralUserService
    {
        public static bool CreateAccount (UserDTO user)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<UserDTO, UserVM>();
            });
            var mapper = new Mapper(config);
            var conv = mapper.Map<UserVM>(user);
            return DataAccessPanel.UserData().Create(conv);
        }

        public static LogInDataDTO login (LoginDTO loginData)
        {
            var data = (from n in DataAccessPanel.UserData().Get()
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

            if(data != null)
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
            var UserData = DataAccessPanel.UserData().Get(id);
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<UserVM, UserDTO>();
            });
            var mapper = new Mapper(config);
            var convertedValue = mapper.Map<UserDTO>(UserData);
            return convertedValue;
        }

        public static bool UpdateuserProfile(UserDTO value, int id)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<UserDTO, UserVM>();
            });
            var mapper = new Mapper(config);
            var conv = mapper.Map<UserVM>(value);
            Console.WriteLine(conv);
            return DataAccessPanel.UserData().Update(conv, id);
        }

        public static bool AddVehicle (VehicleDTO data)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<VehicleDTO, Vehicle>();
            });
            var mapper = new Mapper(config);
            var conv = mapper.Map<Vehicle>(data);
            Console.WriteLine(conv);
            return DataAccessPanel.VehicleControl().Create(conv);
        }

        public static List<VehicleDTO> showVehicleInfo (int id)
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

        public static bool DeleteVehicleInfo (int id)
        {
            return DataAccessPanel.VehicleControl().Delete(id);
        }
    }
}
