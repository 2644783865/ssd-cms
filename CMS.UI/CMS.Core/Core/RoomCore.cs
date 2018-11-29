using CMS.BE.DTO;
using CMS.BE.Models;
using CMS.Core.Helpers;
using CMS.Core.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.Core.Core
{
    public class RoomCore : IRoomCore
    {
        private ApiHelper _apiHelper = new ApiHelper();

        public async Task<bool> AddRoomAsync(RoomDTO room)
        {
            var path = Properties.Resources.addRoomPath;
            var result = await _apiHelper.Post(path, room);
            return result != null && result.ResponseType == ResponseType.Success;
        }

        public async Task<bool> EditRoomAsync(RoomDTO room)
        {
            var path = Properties.Resources.editRoomPath;
            var result = await _apiHelper.Put(path, room);
            return result != null && result.ResponseType == ResponseType.Success;
        }

        public async Task<bool> DeleteRoomAsync(int roomId)
        {
            var path = $"{Properties.Resources.deleteRoomPath}?roomId={roomId}";
            var result = await _apiHelper.Delete(path);
            return result != null && result.ResponseType == ResponseType.Success;
        }



        public async Task<bool> AddBuildingAsync(BuildingDTO building)
        {
            var path = Properties.Resources.addBuildingPath;
            var result = await _apiHelper.Post(path, building);
            return result != null && result.ResponseType == ResponseType.Success;
        }

        public async Task<bool> EditBuildingAsync(BuildingDTO building)
        {
            var path = Properties.Resources.editBuildingPath;
            var result = await _apiHelper.Put(path, building);
            return result != null && result.ResponseType == ResponseType.Success;
        }

        public async Task<bool> DeleteBuildingAsync(int buildingId)
        {
            var path = $"{Properties.Resources.deleteBuildingPath}?buildingId={buildingId}";
            var result = await _apiHelper.Delete(path);
            return result != null && result.ResponseType == ResponseType.Success;
        }

        
        public async Task<bool> SetBuildingForConferenceAsync(int conferenceId, int buildingId)
        {
            var path = $"{Properties.Resources.setBuildingForConferencePath}?conferenceId={conferenceId}&buildingId={buildingId}";
            var result = await _apiHelper.Get(path);
            return result != null && result.ResponseType == ResponseType.Success;
        }
        
        public async Task<bool> DeleteBuildingForConferenceAsync(int conferenceId, int buildingId)
        {
            var path = $"{Properties.Resources.deleteBuildingForConferencePath}?conferenceId={conferenceId}&buildingId={buildingId}";
            var result = await _apiHelper.Delete(path);
            return result != null && result.ResponseType == ResponseType.Success;
        }

        public void Dispose() => _apiHelper.Dispose();
    }
}
