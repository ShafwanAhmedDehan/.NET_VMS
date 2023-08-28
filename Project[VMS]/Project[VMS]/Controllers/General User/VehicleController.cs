using BusinessLogicLayerGeneralUser.Service.GeneralUser;
using BusinessLogicLayerVMS.DTO;
using BusinessLogicLayerVMS.Service;
using Project_VMS_.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Project_VMS_.Controllers.General_User
{
    public class VehicleController : ApiController
    {
        [LogInVerification]
        [HttpPost]
        [Route("api/User/AddVehicle")]
        public HttpResponseMessage AddVehicle(VehicleDTO data)
        {
            try
            {
                var addVehilceStatus = VehicleService.AddVehicle(data);
                return Request.CreateResponse(HttpStatusCode.OK, addVehilceStatus);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [LogInVerification]
        [HttpGet]
        [Route("api/User/ShowVehicle/{id}")]
        public HttpResponseMessage ShowVehicleInfo(int id)
        {
            try
            {
                var vehicleList = VehicleService.showVehicleInfo(id);
                return Request.CreateResponse(HttpStatusCode.OK, vehicleList);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [LogInVerification]
        [HttpDelete]
        [Route("api/User/DeleteVehicle/{id}")]
        public HttpResponseMessage DeleteVehicle(int id)
        {
            try
            {
                var Deletestatus = VehicleService.DeleteVehicleInfo(id);
                return Request.CreateResponse(HttpStatusCode.OK, Deletestatus);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
