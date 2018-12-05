using CMS.BE.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.Core.Interfaces
{
    public interface IRoomCore : IDisposable
    {/*
        Task<List<RoomDTO>> GetRoomsAsync();
        Task<RoomDTO> GetRoomByIdAsync(int roomId);*/
        Task<List<RoomDTO>> GetRoomsForBuildingAsync(int buildingId);
        Task<List<RoomDTO>> GetAvailableRoomsAsync(int buildingId, DateTime beginDate, DateTime endDate);
        Task<bool> AddRoomAsync(RoomDTO room);
        Task<bool> EditRoomAsync(RoomDTO room);
        Task<bool> DeleteRoomAsync(int roomId);


        Task<List<BuildingDTO>> GetAssignedBuildingsForConferenceAsync(int conferenceId);
        Task<List<BuildingDTO>> GetUnassignedBuildingsForConferenceAsync(int conferenceId);
        Task<List<BuildingDTO>> GetBuildingsAsync();
        /*Task<BuildingDTO> GetBuildingByIdAsync(int buildingId);*/
        Task<bool> AddBuildingAsync(BuildingDTO building);
        Task<bool> EditBuildingAsync(BuildingDTO building);
        Task<bool> DeleteBuildingAsync(int buildingId);

        Task<bool> SetBuildingForConferenceAsync(int conferenceId, int buildingId);
        Task<bool> DeleteBuildingForConferenceAsync(int conferenceId, int buildingId);

    }
}
