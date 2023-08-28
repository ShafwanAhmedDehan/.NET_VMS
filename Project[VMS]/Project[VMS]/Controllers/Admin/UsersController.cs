using BusinessLogicLayerGeneralUser.Service.Admin;
using BusinessLogicLayerVMS.DTO;
using BusinessLogicLayerVMS.Service;
using Project_VMS_.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Project_VMS_.Controllers.Admin
{
    public class UsersController : ApiController
    {
        [AdminLoginVerification]
        [HttpDelete]
        [Route("api/Admin/User/Delete/{id}")]
        public HttpResponseMessage DeleteUser(int id)
        {
            var deleteStatus = UsersService.DeleteUserAccount(id);
            return Request.CreateResponse(HttpStatusCode.OK, deleteStatus);
        }

        [AdminLoginVerification]
        [HttpPost]
        [Route("api/Admin/CreateUserProfile")]
        public HttpResponseMessage CreateUserInfo(UserDTO user)
        {
            var createUserStatus = UsersService.CreateUserAccount(user);
            return Request.CreateResponse(HttpStatusCode.OK, createUserStatus);
        }

        [AdminLoginVerification]
        [HttpGet]
        [Route("api/Admin/UserList")]
        public HttpResponseMessage ShowAlluser()
        {
            var AlluserDetails = UsersService.ShowAllUser();
            return Request.CreateResponse(HttpStatusCode.OK, AlluserDetails);
        }
    }
}
