using CMS.BE.DTO;
using System;
using System.Collections.Generic;

namespace CMS.API.BLL.Interfaces
{
    public interface IRoomBLL
    {
        // Room 
        IEnumerable<RoomDTO> GetRoomsForBuilding(int buildingId);
        IEnumerable<RoomDTO> GetAvailableRooms(int buildingId, DateTime beginDate, DateTime endDate);
        bool AddRoom(RoomDTO room);
        bool EditRoom(RoomDTO room);
        bool DeleteRoom(int roomId);

        // Building
        IEnumerable<BuildingDTO> GetAssignedBuildingsForConference(int conferenceId);
        IEnumerable<BuildingDTO> GetUnassignedBuildingsForConference(int conferenceId);
        IEnumerable<BuildingDTO> GetBuildings();
        BuildingDTO GetBuildingById(int id);
        bool AddBuilding(BuildingDTO building);
        bool EditBuilding(BuildingDTO building);
        bool DeleteBuilding(int buildingId);

        // ConferenceBuilding
        bool SetBuildingForConference(int conferenceId, int buildingId);
        bool DeleteAssignmentBuildingForConference(int conferenceId, int buildingId);
    }
}
