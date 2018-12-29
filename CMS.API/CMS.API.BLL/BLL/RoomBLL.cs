using CMS.API.BLL.Interfaces;
using CMS.API.DAL;
using CMS.API.DAL.Interfaces;
using CMS.API.DAL.Repositories;
using CMS.BE.DTO;
using System.Collections.Generic;
using System;


namespace CMS.API.BLL.BLL
{
    public class RoomBLL : IRoomBLL
    {
        private IRoomRepository _repository = new RoomRepository();

        // Room 
        public IEnumerable<RoomDTO> GetRoomsForBuilding(int buildingId)
        {
            try
            {
                return _repository.GetRoomsForBuilding(buildingId);
            }
            catch
            {
                return null;
            }
        }

        public RoomDTO GetRoomById(int roomId)
        {
            try
            {
                return _repository.GetRoomById(roomId);
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<RoomDTO> GetAvailableRooms(int buildingId, DateTime beginDate, DateTime endDate, int roomId)
        {
            try
            {
                return _repository.GetAvailableRooms(buildingId, beginDate, endDate, roomId);
            }
            catch
            {
                return null;
            }
        }

        public bool AddRoom(RoomDTO room)
        {
            try
            {
                _repository.AddRoom(room);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool DeleteRoom(int roomId)
        {
            try
            {
                _repository.DeleteRoom(roomId);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool EditRoom(RoomDTO room)
        {
            try
            {
                _repository.EditRoom(room);
            }
            catch
            {
                return false;
            }
            return true;
        }

        // Building
        public IEnumerable<BuildingDTO> GetAssignedBuildingsForConference(int conferenceId)
        {
            try
            {
                return _repository.GetAssignedBuildingsForConference(conferenceId);
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<BuildingDTO> GetUnassignedBuildingsForConference(int conferenceId)
        {
            try
            {
                return _repository.GetUnassignedBuildingsForConference(conferenceId);
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<BuildingDTO> GetBuildings()
        {
            try
            {
                return _repository.GetBuildings();
            }
            catch
            {
                return null;
            }
        }

        public BuildingDTO GetBuildingById(int id)
        {
            try
            {
                var building = _repository.GetBuildingById(id);
                if (building == null) return null;
                return building;
            }
            catch
            {
                return null;
            }
        }

        public bool AddBuilding(BuildingDTO building)
        {
            try
            {
                _repository.AddBuilding(building);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool DeleteBuilding(int buildingId)
        {
            try
            {
                _repository.DeleteBuilding(buildingId);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool EditBuilding(BuildingDTO building)
        {
            try
            {
                _repository.EditBuilding(building);
            }
            catch
            {
                return false;
            }
            return true;
        }

        // ConferenceBuilding

        public bool SetBuildingForConference(int conferenceId, int buildingId)
        {
            try
            {
                _repository.AddConferenceBuilding(buildingId, conferenceId);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool DeleteAssignmentBuildingForConference(int conferenceId, int buildingId)
        {
            try
            {
                _repository.DeleteConferenceBuilding(buildingId, conferenceId);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
