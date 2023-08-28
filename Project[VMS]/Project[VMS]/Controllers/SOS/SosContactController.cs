using BusinessLogicLayerGeneralUser.DTO;
using BusinessLogicLayerGeneralUser.Service.SOSservice;
using Project_VMS_.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Project_VMS_.Controllers.Driver
{
    public class SosContactController : ApiController
    {
        [LogInVerification]
        [HttpPost]
        [Route("api/SOS/Create")]
        public HttpResponseMessage CreateSOS(sosDTO value)
        {
            try
            {
                var insertStatus = SOSmanage.AddSOS(value);
                return Request.CreateResponse(HttpStatusCode.OK, insertStatus);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [LogInVerification]
        [HttpDelete]
        [Route("api/SOS/Delete/{id}")]
        public HttpResponseMessage DeleteSOS(int id)
        {
            try
            {
                var DeleteStatus = SOSmanage.DeleteSOScontact(id);
                return Request.CreateResponse(HttpStatusCode.OK, DeleteStatus);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [LogInVerification]
        [HttpGet]
        [Route("api/SOS/ViewSOSinfo/{id}")]
        public HttpResponseMessage ViewSOSinfo(int id)
        {
            try
            {
                var SOSinfo = SOSmanage.ViewSOSinfo(id);
                return Request.CreateResponse(HttpStatusCode.OK, SOSinfo);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [LogInVerification]
        [HttpPost]
        [Route("api/SOS/UpdateSOSinfo/{id}")]
        public HttpResponseMessage UpdateSOSinfo(sosDTO values,int id)
        {
            try
            {
                var UpdateStatus = SOSmanage.UpdateSOScontact(values,id);
                return Request.CreateResponse(HttpStatusCode.OK, UpdateStatus);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
