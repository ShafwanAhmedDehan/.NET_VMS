using BusinessLogicLayerGeneralUser.DTO;
using BusinessLogicLayerGeneralUser.Service.Driver;
using BusinessLogicLayerVMS.Service;
using Project_VMS_.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Project_VMS_.Controllers.Driver
{
    public class HireProfileController : ApiController
    {
        [DriverLoginVerfication]
        [HttpPost]
        [Route("api/Driver/HireProfile/Create")]
        public HttpResponseMessage CreateHireProfile(HireValueDTO values)
        {
            try
            {
                var insertStatus = HiringValueService.CreateHiringProfile(values);
                return Request.CreateResponse(HttpStatusCode.OK, insertStatus);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [DriverLoginVerfication]
        [HttpPost]
        [Route("api/Driver/HireProfile/View")]
        public HttpResponseMessage viewHireProfile(int id)
        {
            try
            {
                var ProfileData= HiringValueService.ViewHireInfo(id);
                return Request.CreateResponse(HttpStatusCode.OK, ProfileData);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [DriverLoginVerfication]
        [HttpPost]
        [Route("api/Driver/HireProfile/Delete")]
        public HttpResponseMessage DeleteHireProfile(int id)
        {
            try
            {
                var DeleleStatus = HiringValueService.DeleteHireProfile(id);
                return Request.CreateResponse(HttpStatusCode.OK, DeleleStatus);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [DriverLoginVerfication]
        [HttpPost]
        [Route("api/Driver/HireProfile/Update")]
        public HttpResponseMessage HireProfileUpdate(HireValueDTO NewUpdate, int id)
        {
            try
            {
                var UpdateStatus = HiringValueService.UpdateHireProfile(NewUpdate,id);
                return Request.CreateResponse(HttpStatusCode.OK, UpdateStatus);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
