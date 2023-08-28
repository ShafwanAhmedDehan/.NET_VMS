using BusinessLogicLayerGeneralUser.Service.Admin;
using BusinessLogicLayerVMS.Service;
using Project_VMS_.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Project_VMS_.Controllers.Admin
{
    public class VehiclesController : ApiController
    {
        [AdminLoginVerification]
        [HttpGet]
        [Route("api/Admin/VehicleList")]
        public HttpResponseMessage showAllVehicle()
        {
            var AllVehicleDetails = VehiclesService.ShowAllVehicle();
            return Request.CreateResponse(HttpStatusCode.OK, AllVehicleDetails);
        }

        [AdminLoginVerification]
        [HttpDelete]
        [Route("api/Admin/DeleteVehicle/{id}")]
        public HttpResponseMessage DeleteUserVehicle(int id)
        {
            try
            {
                var Deletestatus = VehiclesService.DeleteUserVehicle(id);
                return Request.CreateResponse(HttpStatusCode.OK, Deletestatus);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
