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
    public class NotePadController : ApiController
    {
        [LogInVerification]
        [HttpPost]
        [Route("api/User/CreateNote")]
        public HttpResponseMessage CreateNotes(NotePadDTO data)
        {
            try
            {
                var CreateNote = NotepadService.CreateNote(data);
                return Request.CreateResponse(HttpStatusCode.OK, CreateNote);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [LogInVerification]
        [HttpGet]
        [Route("api/User/ShowNotes/{id}")]
        public HttpResponseMessage ShowNotes(int id)
        {
            try
            {
                var Notes = NotepadService.ShowNotepad(id);
                return Request.CreateResponse(HttpStatusCode.OK, Notes);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [LogInVerification]
        [HttpDelete]
        [Route("api/User/DeleteNote/{id}")]
        public HttpResponseMessage DeleteVehicle(int id)
        {
            try
            {
                var Deletestatus = NotepadService.DeleteNote(id);
                return Request.CreateResponse(HttpStatusCode.OK, Deletestatus);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
