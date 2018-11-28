using CMS.BE.DTO;
using System;
using System.Collections.Generic;

namespace CMS.API.DAL.Interfaces
{
    public interface IRoomRepository : IDisposable
    {
        //Room
        IEnumerable<RoomDTO> GetRooms();
        RoomDTO GetRoomById(int id);
        void AddRoom(RoomDTO roomDTO);
        void EditRoom(RoomDTO roomDTO);
        void DeleteRoom(int roomId);

        //Building
        IEnumerable<BuildingDTO> GetBuildings();
        BuildingDTO GetBuildingById(int id);
        void AddBuilding(BuildingDTO buildingDTO);
        void EditBuilding(BuildingDTO buildingDTO);
        void DeleteBuilding(int buildingId);

        //ConferenceBuilding
        void AddConferenceBuilding(int buildingId, int conferenceId);
        void DeleteConferenceBuilding(int buildingId, int conferenceId);
    }
}
