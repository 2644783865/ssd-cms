using CMS.BE.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.Core.Interfaces
{
    public interface IRoomCore : IDisposable
    {
        Task<bool> AddRoomAsync(RoomDTO room);
        Task<bool> EditRoomAsync(RoomDTO room);
        Task<bool> DeleteRoomAsync(int roomId);

        Task<bool> AddBuildingAsync(BuildingDTO building);
        Task<bool> EditBuildingAsync(BuildingDTO building);
        Task<bool> DeleteBuildingAsync(int buildingId);

        Task<bool> SetBuildingForConferenceAsync(int conferenceId, int buildingId);
        Task<bool> DeleteBuildingForConferenceAsync(int conferenceId, int buildingId);
    }
}
