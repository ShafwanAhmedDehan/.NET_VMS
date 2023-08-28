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
    public class AdminController : ApiController
    {
        [HttpPost]
        [Route("api/Admin/Login")]
        public HttpResponseMessage Login (LoginDTO loginvalue)
        {
            var LoginInfo = AdminService.login(loginvalue);
            return Request.CreateResponse(HttpStatusCode.OK, LoginInfo);
        }

        [HttpDelete]
        [Route("api/Admin/Delete/{id}")]
        public HttpResponseMessage DeleteUser(int id)
        {
            var deleteStatus = AdminService.DeleteUserAccount(id);
            return Request.CreateResponse(HttpStatusCode.OK, deleteStatus);
        }

        [HttpGet]
        [Route("api/Admin/viewProfile/{id}")]
        public HttpResponseMessage ViewProfile(int id)
        {
            var viewProfile = AdminService.viewProfile(id);
            return Request.CreateResponse(HttpStatusCode.OK, viewProfile);
        }

        [HttpPost]
        [Route("api/Admin/UpdateProfile/{id}")]
        public HttpResponseMessage UpDate(UserDTO data, int id)
        {
            var updateStatus = AdminService.UpdateAdminProfile(data, id);
            return Request.CreateResponse(HttpStatusCode.OK, updateStatus);
        }

        [HttpPost]
        [Route("api/Admin/CreateUserProfile")]
        public HttpResponseMessage CreateUserInfo(UserDTO user)
        {
            var createUserStatus = AdminService.CreateUserAccount(user);
            return Request.CreateResponse(HttpStatusCode.OK, createUserStatus);
        }

        [HttpGet]
        [Route("api/Admin/UserList")]
        public HttpResponseMessage ShowAlluser()
        {
            var AlluserDetails = AdminService.ShowAllUser();
            return Request.CreateResponse(HttpStatusCode.OK, AlluserDetails);
        }

        [HttpGet]
        [Route("api/Admin/VehicleList")]
        public HttpResponseMessage showAllVehicle()
        {
            var AllVehicleDetails = AdminService.ShowAllVehicle();
            return Request.CreateResponse(HttpStatusCode.OK, AllVehicleDetails);
        }
    }
}
