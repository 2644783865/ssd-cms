using CMS.BE.DTO;

namespace CMS.API.BLL.Interfaces
{
    public interface IRoomBLL
    {
        // Room 
        bool AddRoom(RoomDTO room);
        bool EditRoom(RoomDTO room);
        bool DeleteRoom(int roomId);

        // Building
        bool AddBuilding(BuildingDTO building);
        bool EditBuilding(BuildingDTO building);
        bool DeleteBuilding(int buildingId);

        // ConferenceBuilding
        bool SetBuildingForConference(int conferenceId, int buildingId);
        bool DeleteAssignmentBuildingForConference(int conferenceId, int buildingId);
    }
}
