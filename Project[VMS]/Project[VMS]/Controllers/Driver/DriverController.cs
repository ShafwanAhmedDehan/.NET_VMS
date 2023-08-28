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
    public class DriverController : ApiController
    {
        [HttpPost]
        [Route("api/Driver/CreateAccount/Create")]
        public HttpResponseMessage CreateUser(UserDTO user)
        {
            try
            {
                var insertStatus = DriverService.CreateAccount(user);
                return Request.CreateResponse(HttpStatusCode.OK, insertStatus);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPost]
        [Route("api/Driver/Login")]
        public HttpResponseMessage LogIn(LoginDTO loginValue)
        {
            try
            {
                var LoginData = DriverService.login(loginValue);
                var TokenValue = TokenService.DriverLogin(loginValue);
                return Request.CreateResponse(HttpStatusCode.OK, new { LoginData, TokenValue });
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }  
        }
        
        [DriverLoginVerfication]
        [HttpGet]
        [Route("api/Driver/viewProfile/{id}")]
        public HttpResponseMessage ViewProfile(int id)
        {
            try
            {
                var viewProfile = DriverService.viewProfile(id);
                return Request.CreateResponse(HttpStatusCode.OK, viewProfile);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [DriverLoginVerfication]
        [HttpPost]
        [Route("api/Driver/UpdateProfile/{id}")]
        public HttpResponseMessage UpDate(UserDTO data, int id)
        {
            try
            {
                var updateStatus = DriverService.UpdateProfile(data, id);
                return Request.CreateResponse(HttpStatusCode.OK, updateStatus);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
