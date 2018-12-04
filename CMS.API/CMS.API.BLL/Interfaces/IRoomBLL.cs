using CMS.BE.DTO;
using System.Collections.Generic;

namespace CMS.API.BLL.Interfaces
{
    public interface IRoomBLL
    {
        // Room 
        bool AddRoom(RoomDTO room);
        bool EditRoom(RoomDTO room);
        bool DeleteRoom(int roomId);

        // Building
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
