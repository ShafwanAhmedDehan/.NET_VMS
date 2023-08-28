using BusinessLogicLayerVMS.DTO;
using BusinessLogicLayerVMS.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Project_VMS_.Controllers
{
    public class GeneralUserController : ApiController
    {
        [HttpPost]
        [Route("api/CreateAccount/Create")]
        public HttpResponseMessage CreateUser (UserDTO user)
        {
            var insertStatus = GeneralUserService.CreateAccount(user);
            return Request.CreateResponse(HttpStatusCode.OK, insertStatus);
        }

        [HttpPost]
        [Route("api/Login")]
        public HttpResponseMessage LogIn (LoginDTO loginValue)
        {
            var LoginData = GeneralUserService.login(loginValue);
            return Request.CreateResponse(HttpStatusCode.OK, LoginData);
        }

        [HttpGet]
        [Route("api/user/viewProfile/{id}")]
        public HttpResponseMessage ViewProfile (int id)
        {
            var viewProfile = GeneralUserService.viewProfile(id);
            return Request.CreateResponse(HttpStatusCode.OK, viewProfile);
        }

        [HttpPost]
        [Route("api/User/UpdateProfile/{id}")]
        public HttpResponseMessage UpDate(UserDTO data, int id)
        {
            var updateStatus = GeneralUserService.UpdateuserProfile(data, id);
            return Request.CreateResponse(HttpStatusCode.OK, updateStatus);
        }

        [HttpPost]
        [Route("api/User/AddVehicle")]
        public HttpResponseMessage AddVehicle(VehicleDTO data)
        {
            var addVehilceStatus = GeneralUserService.AddVehicle(data);
            return Request.CreateResponse(HttpStatusCode.OK, addVehilceStatus);
        }

        [HttpGet]
        [Route("api/User/ShowVehicle/{id}")]
        public HttpResponseMessage ShowVehicleInfo( int id)
        {
            var vehicleList = GeneralUserService.showVehicleInfo(id);
            return Request.CreateResponse(HttpStatusCode.OK, vehicleList);
        }

        [HttpDelete]
        [Route("api/User/DeleteVehicle/{id}")]
        public HttpResponseMessage DeleteVehicle(int id)
        {
            var Deletestatus = GeneralUserService.DeleteVehicleInfo(id);
            return Request.CreateResponse(HttpStatusCode.OK, Deletestatus);
        }
    }
}
