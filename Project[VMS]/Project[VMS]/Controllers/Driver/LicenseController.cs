using BusinessLogicLayerGeneralUser.Service.Driver;
using BusinessLogicLayerVMS.DTO;
using Project_VMS_.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Project_VMS_.Controllers.Driver
{
    public class LicenseController : ApiController
    {
        [DriverLoginVerfication]
        [HttpPost]
        [Route("api/Driver/AddLicense")]
        public HttpResponseMessage AddDriverLicense(LicenseDTO value)
        {
            try
            {
                var licenseAddStatus = LicenseService.AddLicense(value);
                return Request.CreateResponse(HttpStatusCode.OK, licenseAddStatus);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [DriverLoginVerfication]
        [HttpGet]
        [Route("api/Driver/ShowLicense/{id}")]
        public HttpResponseMessage ShowLicense(int id)
        {
            try
            {
                var LicenseInfo = LicenseService.ShowLicenseInfo(id);
                return Request.CreateResponse(HttpStatusCode.OK, LicenseInfo);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [DriverLoginVerfication]
        [HttpDelete]
        [Route("api/Driver/DeleteLicense/{id}")]
        public HttpResponseMessage DeleteLicense(int id)
        {
            try
            {
                var DeleteStatus = LicenseService.DeleteValue(id);
                return Request.CreateResponse(HttpStatusCode.OK, DeleteStatus);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
