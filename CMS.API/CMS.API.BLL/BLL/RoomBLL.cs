using CMS.API.BLL.Interfaces;
using CMS.API.DAL;
using CMS.API.DAL.Interfaces;
using CMS.API.DAL.Repositories;
using CMS.BE.DTO;

namespace CMS.API.BLL.BLL
{
    public class RoomBLL : IRoomBLL
    {
        private IRoomRepository _repository = new RoomRepository();

        // Room 
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
