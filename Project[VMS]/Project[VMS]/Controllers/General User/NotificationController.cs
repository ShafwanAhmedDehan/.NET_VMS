using BusinessLogicLayerGeneralUser.DTO;
using BusinessLogicLayerGeneralUser.Service.GeneralUser;
using Project_VMS_.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Project_VMS_.Controllers.General_User
{
    public class NotificationController : ApiController
    {
        [LogInVerification]
        [HttpPost]
        [Route("api/Create/Notification")]
        public HttpResponseMessage CreateUser(NotificationDTO value)
        {
            try
            {
                var insertStatus = NotificationService.CreateNotification(value);
                return Request.CreateResponse(HttpStatusCode.OK, insertStatus);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [LogInVerification]
        [HttpGet]
        [Route("api/View/Notification/{id}")]
        public HttpResponseMessage ShowNotification(int id)
        {
            try
            {
                var Notifications = NotificationService.ShowAllNotification(id);
                return Request.CreateResponse(HttpStatusCode.OK, Notifications);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [LogInVerification]
        [HttpDelete]
        [Route("api/Delete/Notification/{id}")]
        public HttpResponseMessage DeleteNotifi(int id)
        {
            try
            {
                var DeleteStatus = NotificationService.DeleteNotification(id);
                return Request.CreateResponse(HttpStatusCode.OK, DeleteStatus);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
