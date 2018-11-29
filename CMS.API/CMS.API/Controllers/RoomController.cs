using CMS.API.BLL.BLL;
using CMS.API.BLL.Interfaces;
using CMS.API.Helpers;
using CMS.BE.DTO;
using System;
using System.Web.Http;

namespace CMS.API.Controllers
{
    [BasicAuthentication]
    public class RoomController : ApiController
    {
        private IRoomBLL _bll = new RoomBLL();

        // POST: api/Room/AddRoom
        [HttpPost]
        [Route("api/room/addroom")]
        public IHttpActionResult AddRoom([FromBody] RoomDTO room)
        {
            if (_bll.AddRoom(room)) return Ok();
            return InternalServerError();
        }

        // PUT: api/Room/EditRoom
        [HttpPut]
        [Route("api/room/editroom")]
        public IHttpActionResult EditRoom([FromBody] RoomDTO room)
        {
            if (_bll.EditRoom(room)) return Ok();
            return InternalServerError();
        }

        // DELETE: api/Room/DeleteRoom?roomId=
        [HttpDelete]
        [Route("api/room/deleteroom")]
        public IHttpActionResult DeleteRoom(int roomId)
        {
            if (_bll.DeleteRoom(roomId)) return Ok();
            return InternalServerError();
        }



        // POST: api/Room/AddBuilding
        [HttpPost]
        [Route("api/room/addbuilding")]
        public IHttpActionResult AddBuilding([FromBody] BuildingDTO building)
        {
            if (string.IsNullOrEmpty(building.Name) || string.IsNullOrEmpty(building.Address)) return BadRequest();
            if (_bll.AddBuilding(building)) return Ok();
            return InternalServerError();
        }

        // PUT: api/Room/EditBuilding
        [HttpPut]
        [Route("api/room/editbuilding")]
        public IHttpActionResult EditBuilding([FromBody] BuildingDTO building)
        {
            if (string.IsNullOrEmpty(building.Name) || string.IsNullOrEmpty(building.Address)) return BadRequest();
            if (_bll.EditBuilding(building)) return Ok();
            return InternalServerError();
        }

        // DELETE: api/Room/DeleteBuilding?buildingId=
        [HttpDelete]
        [Route("api/room/deletebuilding")]
        public IHttpActionResult DeleteBuilding(int buildingId)
        {
            if (_bll.DeleteBuilding(buildingId)) return Ok();
            return InternalServerError();
        }



        // POST: api/Room/SetBuildingForConference?conferenceId=&buildingId=
        [HttpGet]
        [Route("api/room/setbuildingforconference")]
        public IHttpActionResult SetBuildingForConference(int conferenceId, int buildingId)
        {
            if (_bll.SetBuildingForConference(conferenceId, buildingId)) return Ok();
            return BadRequest();
        }

        // DELETE: api/Room/DeleteBuildingForConference?conferenceId=&buildingId=
        [HttpDelete]
        [Route("api/room/deletebuildingforconference")]
        public IHttpActionResult DeleteBuildingForConference(int conferenceId, int buildingId)
        {
            if (_bll.DeleteAssignmentBuildingForConference(conferenceId, buildingId)) return Ok();
            return InternalServerError();
        }
    }
}
