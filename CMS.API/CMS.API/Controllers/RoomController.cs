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

        // GET: api/Room/GetRoomById?roomId=
        [HttpGet]
        [Route("api/room/getroombyid")]
        public IHttpActionResult GetRoomById(int roomId)
        {
            var room = _bll.GetRoomById(roomId);
            if (room == null) return BadRequest();
            return Ok(room);
        }
        

        // GET: api/Room/GetRoomsForBuilding?buildingId=
        [HttpGet]
        [Route("api/room/getroomsforbuilding")]
        public IHttpActionResult GetRoomsForBuilding(int buildingId)
        {
            var rooms = _bll.GetRoomsForBuilding(buildingId);
            if (rooms == null) return BadRequest();
            return Ok(rooms);
        }

        // GET: api/Room/GetAvailableRooms?buildingId=&beginDate=&endDate=&roomId=
        [HttpGet]
        [Route("api/room/getavailablerooms")]
        public IHttpActionResult GetAvailableRooms(int buildingId, DateTime beginDate, DateTime endDate, int roomId)
        {
            var rooms = _bll.GetAvailableRooms(buildingId, beginDate, endDate, roomId);
            if (rooms == null) return BadRequest();
            return Ok(rooms);
        }

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


        // GET: api/Room/GetAssignedBuildForConf?conferenceId=
        [HttpGet]
        [Route("api/room/getassignedbuildforconf")]
        public IHttpActionResult GetAssignedBuildingsForConference(int conferenceId)
        {
            var building = _bll.GetAssignedBuildingsForConference(conferenceId);
            if (building == null) return BadRequest();
            return Ok(building);
        }

        // GET: api/Room/GetUnassignedBuildForConf?conferenceId=
        [HttpGet]
        [Route("api/room/getunassignedbuildforconf")]
        public IHttpActionResult GetUnassignedBuildingsForConference(int conferenceId)
        {
            var building = _bll.GetUnassignedBuildingsForConference(conferenceId);
            if (building == null) return BadRequest();
            return Ok(building);
        }

        // GET: api/Room/Building
        [HttpGet]
        [Route("api/room/building")]
        public IHttpActionResult GetBuilding()
        {
            return Ok(_bll.GetBuildings());
        }

        // GET: api/Room/GetBuildingmById?buildingId=
        [HttpGet]
        [Route("api/room/getbuildingbyid")]
        public IHttpActionResult GetBuildingById(int buildingId)
        {
            var building = _bll.GetBuildingById(buildingId);
            if (building == null) return BadRequest();
            return Ok(building);
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
