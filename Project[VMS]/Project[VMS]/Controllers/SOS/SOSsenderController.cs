using BusinessLogicLayerGeneralUser.Service.SOSservice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Project_VMS_.Controllers.SOS
{
    public class SOSsenderController : ApiController
    {
        [HttpGet]
        [Route("api/SOS/Send/{SOScontactNo}")]
        public HttpResponseMessage SendSOS(string SOScontactNo)
        {
            try
            {
                var Massage = SOSsend.SOSsend01(SOScontactNo);
                return Request.CreateResponse(HttpStatusCode.OK, new { Massage });
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
