using BusinessLogicLayerGeneralUser.Service.TokenForAll;
using BusinessLogicLayerVMS.DTO;
using BusinessLogicLayerVMS.Service;
using Project_VMS_.Authentication;
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
            var LoginToken = TokenService.AdminLogin(loginvalue);
            return Request.CreateResponse(HttpStatusCode.OK, new { LoginInfo, LoginToken });
        }

        [AdminLoginVerification]
        [HttpGet]
        [Route("api/Admin/viewProfile/{id}")]
        public HttpResponseMessage ViewProfile(int id)
        {
            var viewProfile = AdminService.viewProfile(id);
            return Request.CreateResponse(HttpStatusCode.OK, viewProfile);
        }

        [AdminLoginVerification]
        [HttpPost]
        [Route("api/Admin/UpdateProfile/{id}")]
        public HttpResponseMessage UpDate(UserDTO data, int id)
        {
            var updateStatus = AdminService.UpdateAdminProfile(data, id);
            return Request.CreateResponse(HttpStatusCode.OK, updateStatus);
        }
    }
}
