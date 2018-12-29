using CMS.API.DAL.Extensions;
using CMS.API.DAL.Interfaces;
using CMS.BE.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace CMS.API.DAL.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private cmsEntities _db = new cmsEntities();

        public IEnumerable<RoomDTO> GetRoomsForBuilding(int buildingId)
        {
            return _db.Rooms.Where(room => room.BuildingID == buildingId).Project().To<RoomDTO>();
        }

        public IEnumerable<RoomDTO> GetAvailableRooms(int buildingId, DateTime beginDate, DateTime endDate, int roomId)
        {
            var rooms = _db.Rooms.SqlQuery("SELECT DISTINCT * FROM Room WHERE BuildingID = @buildingid " +
                "AND (RoomID NOT IN(SELECT RoomId FROM Event WHERE((@begindate >= BeginDate AND @begindate < EndDate) " +
                "OR(@enddate > BeginDate AND @enddate <= EndDate)) " +
                "UNION SELECT RoomId FROM Session WHERE((@begindate >= BeginDate AND @begindate < EndDate) " +
                "OR(@enddate > BeginDate AND @enddate <= EndDate)) " +
                "UNION SELECT RoomId FROM SpecialSession WHERE((@begindate >= BeginDate AND @begindate < EndDate) " +
                "OR(@enddate > BeginDate AND @enddate <= EndDate))) OR RoomID=@currentRoom)",
               new SqlParameter("@buildingid", buildingId), new SqlParameter("@begindate", beginDate), 
               new SqlParameter("@enddate", endDate), new SqlParameter("@currentRoom", roomId)).ToList();
            foreach (var room in rooms)
            {
                yield return MapperExtension.mapper.Map<Room, RoomDTO>(room);
            }
        }

        public RoomDTO GetRoomById(int id)
        {
            var room = _db.Rooms.Find(id);
            if (room == null) return null;
            else return MapperExtension.mapper.Map<Room, RoomDTO>(room);
        }

        public void AddRoom(RoomDTO roomDTO)
        {
            var room = MapperExtension.mapper.Map<RoomDTO, Room>(roomDTO);
            _db.Rooms.Add(room);
            _db.SaveChanges();
        }

        public void EditRoom(RoomDTO roomDTO)
        {
            var room = MapperExtension.mapper.Map<RoomDTO, Room>(roomDTO);
            _db.Entry(_db.Rooms.Find(roomDTO.RoomID)).CurrentValues.SetValues(room);
            _db.SaveChanges();
        }

        public void DeleteRoom(int roomId)
        {
            var room = _db.Rooms.Find(roomId);
            _db.Rooms.Remove(room);
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }



        //Building

        public IEnumerable<BuildingDTO> GetBuildings()
        {
            return _db.Buildings.Project().To<BuildingDTO>();
        }
        public BuildingDTO GetBuildingById(int id)
        {
            var building = _db.Buildings.Find(id);
            if (building == null) return null;
            else return MapperExtension.mapper.Map<Building, BuildingDTO>(building);
        }

        public IEnumerable<BuildingDTO> GetAssignedBuildingsForConference(int conferenceId)
        {
            var buildings = _db.Buildings.SqlQuery("SELECT * FROM Building WHERE BuildingID IN (SELECT BuildingId FROM ConferenceBuilding WHERE ConferenceId = @conferenceid)",
                new SqlParameter("@conferenceid", conferenceId)).ToList();
            foreach (var building in buildings)
            {
                yield return MapperExtension.mapper.Map<Building, BuildingDTO>(building);
            }
        }

        public IEnumerable<BuildingDTO> GetUnassignedBuildingsForConference(int conferenceId)
        {
            var buildings = _db.Buildings.SqlQuery("SELECT * FROM Building WHERE BuildingID NOT IN (SELECT BuildingId FROM ConferenceBuilding WHERE ConferenceId = @conferenceid)",
                new SqlParameter("@conferenceid", conferenceId)).ToList();
            foreach (var building in buildings)
            {
                yield return MapperExtension.mapper.Map<Building, BuildingDTO>(building);
            }
        }

        public void AddBuilding(BuildingDTO buildingDTO)
        {
            var building = MapperExtension.mapper.Map<BuildingDTO, Building>(buildingDTO);
            _db.Buildings.Add(building);
            _db.SaveChanges();
        }

        public void EditBuilding(BuildingDTO buildingDTO)

        {
            var building = MapperExtension.mapper.Map<BuildingDTO, Building>(buildingDTO);
            _db.Entry(_db.Buildings.Find(buildingDTO.BuildingID)).CurrentValues.SetValues(building);
            _db.SaveChanges();
        }

        public void DeleteBuilding(int buildingId)
        {
            var building = _db.Buildings.Find(buildingId);
            _db.Buildings.Remove(building);
            _db.SaveChanges();
        }

        //ConferenceBuilding

        public void AddConferenceBuilding(int buildingId, int conferenceId)
        {
            _db.Database.ExecuteSqlCommand("INSERT INTO ConferenceBuilding  VALUES (@p0, @p1)",
                conferenceId, buildingId);
        }

        public void DeleteConferenceBuilding(int buildingId, int conferenceId)
        {
            _db.Database.ExecuteSqlCommand("DELETE FROM ConferenceBuilding WHERE ConferenceId=@p0 AND BuildingId=@p1",
                conferenceId, buildingId);
        }
    }
}
