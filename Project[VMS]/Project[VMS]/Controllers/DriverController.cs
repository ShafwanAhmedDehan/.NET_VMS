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
    public class DriverController : ApiController
    {
        [HttpPost]
        [Route("api/CreateAccount/Create")]
        public HttpResponseMessage CreateUser(UserDTO user)
        {
            var insertStatus = DriverService.CreateAccount(user);
            return Request.CreateResponse(HttpStatusCode.OK, insertStatus);
        }

        [HttpPost]
        [Route("api/Driver/Login")]
        public HttpResponseMessage LogIn(LoginDTO loginValue)
        {
            var LoginData = DriverService.login(loginValue);
            return Request.CreateResponse(HttpStatusCode.OK, LoginData);
        }

        [HttpGet]
        [Route("api/Driver/viewProfile/{id}")]
        public HttpResponseMessage ViewProfile(int id)
        {
            var viewProfile = DriverService.viewProfile(id);
            return Request.CreateResponse(HttpStatusCode.OK, viewProfile);
        }

        [HttpPost]
        [Route("api/Driver/UpdateProfile/{id}")]
        public HttpResponseMessage UpDate(UserDTO data, int id)
        {
            var updateStatus = DriverService.UpdateProfile(data,id);
            return Request.CreateResponse(HttpStatusCode.OK, updateStatus);
        }

        [HttpPost]
        [Route("api/Driver/AddLicense")]
         public HttpResponseMessage AddDriverLicense(LicenseDTO value)
         {
            var licenseAddStatus = DriverService.AddLicense(value);
            return Request.CreateResponse(HttpStatusCode.OK, licenseAddStatus);
         }

        [HttpGet]
        [Route("api/Driver/ShowLicense/{id}")]
        public HttpResponseMessage ShowLicense(int id)
        {
            var LicenseInfo = DriverService.ShowLicenseInfo(id);
            return Request.CreateResponse(HttpStatusCode.OK, LicenseInfo);
        }

        [HttpDelete]
        [Route("api/Driver/DeleteLicense/{id}")]
        public HttpResponseMessage DeleteLicense(int id)
        {
            var DeleteStatus = DriverService.DeleteValue(id);
            return Request.CreateResponse(HttpStatusCode.OK, DeleteStatus);
        }
    }
}
