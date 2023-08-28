using BusinessLogicLayerGeneralUser.DTO;
using BusinessLogicLayerGeneralUser.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Project_VMS_.Controllers.OTPFunction
{
    public class OTPsendController : ApiController
    {
        [HttpPost]
        [Route("api/OTP/Send")]
        public HttpResponseMessage OtpSend(OTP obj)
        {
            try
            {
                var OTPcode = OTPservice.SendOTP(obj.IDvalue);
                return Request.CreateResponse(HttpStatusCode.OK, new { OTPcode });
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
