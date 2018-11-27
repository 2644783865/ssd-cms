using CMS.API.DAL.Extensions;
using CMS.API.DAL.Interfaces;
using CMS.BE.DTO;
using System.Collections.Generic;

namespace CMS.API.DAL.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private cmsEntities _db = new cmsEntities();

        public IEnumerable<RoomDTO> GetRooms()
        {
            return _db.Rooms.Project().To<RoomDTO>();
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
            _db.Entry(_db.Rooms.Find(roomDTO.RoomId)).CurrentValues.SetValues(room);
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

        public void AddBuilding(BuildingDTO buildingDTO)
        {
            var building = MapperExtension.mapper.Map<BuildingDTO, Building>(buildingDTO);
            _db.Buildings.Add(building);
            _db.SaveChanges();
        }

        public void EditBuilding(BuildingDTO buildingDTO)
        {
            var building = MapperExtension.mapper.Map<BuildingDTO, Building>(buildingDTO);
            _db.Entry(_db.Buildings.Find(buildingDTO.BuildingId)).CurrentValues.SetValues(building);
            _db.SaveChanges();
        }

        public void DeleteBuilding(int buildingId)
        {
            var building = _db.Buildings.Find(buildingId);
            _db.Buildings.Remove(building);
            _db.SaveChanges();
        }

    }
}
