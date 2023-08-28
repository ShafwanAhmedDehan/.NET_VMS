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
using System.Web.Http.Cors;

namespace Project_VMS_.Controllers
{
    [EnableCors("*", "*", "*")]
    public class GeneralUserController : ApiController
    {
        [HttpPost]
        [Route("api/CreateAccount/Create")]
        public HttpResponseMessage CreateUser (UserDTO user)
        {
            try 
            { 
                var insertStatus = GeneralUserService.CreateAccount(user);
                return Request.CreateResponse(HttpStatusCode.OK, insertStatus);
            }
            catch(Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPost]
        [Route("api/Login")]
        public HttpResponseMessage LogIn (LoginDTO loginValue)
        {
            try
            {
                var LoginData = GeneralUserService.login(loginValue);
                var LoginToken = TokenService.GeneralLogin(loginValue);
                return Request.CreateResponse(HttpStatusCode.OK, new { LoginData, LoginToken });
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [LogInVerification]
        [HttpGet]
        [Route("api/user/viewProfile/{id}")]
        public HttpResponseMessage ViewProfile (int id)
        {
            try
            {
                var viewProfile = GeneralUserService.viewProfile(id);
                return Request.CreateResponse(HttpStatusCode.OK, viewProfile);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [LogInVerification]
        [HttpPost]
        [Route("api/User/UpdateProfile/{id}")]
        public HttpResponseMessage UpDate(UserDTO data, int id)
        {
            try
            {
                var updateStatus = GeneralUserService.UpdateuserProfile(data, id);
                return Request.CreateResponse(HttpStatusCode.OK, updateStatus);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
