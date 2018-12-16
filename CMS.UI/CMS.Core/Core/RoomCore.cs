using CMS.BE.DTO;
using CMS.BE.Models;
using CMS.Core.Helpers;
using CMS.Core.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.Core.Core
{
    public class RoomCore : IRoomCore
    {
        private ApiHelper _apiHelper = new ApiHelper();
        

        public async Task<RoomDTO> GetRoomByIdAsync(int roomId)
        {
            var path = $"{Properties.Resources.getRoomByIdPath}?roomId={roomId}";
            var result = await _apiHelper.Get(path);
            if (result != null && result.ResponseType == ResponseType.Success)
            {
                return JsonConvert.DeserializeObject<RoomDTO>(result.Content);
            }
            else return null;
        }
       
        public async Task<List<RoomDTO>> GetRoomsForBuildingAsync(int buildingId)
        {
            var path = $"{Properties.Resources.getRoomsForBuildingPath}?buildingId={buildingId}";
            var result = await _apiHelper.Get(path);
            if (result != null && result.ResponseType == ResponseType.Success)
            {
                return JsonConvert.DeserializeObject<List<RoomDTO>>(result.Content);
            }
            else return null;
        }

        public async Task<List<RoomDTO>> GetAvailableRoomsAsync(int buildingId, DateTime beginDate, DateTime endDate)
        {
            var path = $"{Properties.Resources.getAvailableRoomsPath}?buildingId={buildingId}&beginDate={beginDate}&endDate={endDate}";
            var result = await _apiHelper.Get(path);
            if (result != null && result.ResponseType == ResponseType.Success)
            {
                return JsonConvert.DeserializeObject<List<RoomDTO>>(result.Content);
            }
            else return null;
        }

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


        public async Task<List<BuildingDTO>> GetAssignedBuildingsForConferenceAsync(int conferenceId)
        {
            var path = $"{Properties.Resources.getAssignedBuildForConfPath}?conferenceId={conferenceId}";
            var result = await _apiHelper.Get(path);
            if (result != null && result.ResponseType == ResponseType.Success)
            {
                return JsonConvert.DeserializeObject<List<BuildingDTO>>(result.Content);
            }
            else return null;
        }
        public async Task<List<BuildingDTO>> GetUnassignedBuildingsForConferenceAsync(int conferenceId)
        {
            var path = $"{Properties.Resources.getUnassignedBuildForConfPath}?conferenceId={conferenceId}";
            var result = await _apiHelper.Get(path);
            if (result != null && result.ResponseType == ResponseType.Success)
            {
                return JsonConvert.DeserializeObject<List<BuildingDTO>>(result.Content);
            }
            else return null;
        }

        public async Task<List<BuildingDTO>> GetBuildingsAsync()
        {
            var path = $"{Properties.Resources.getBuildingsPath}";
            var result = await _apiHelper.Get(path);
            if (result != null && result.ResponseType == ResponseType.Success)
            {
                return JsonConvert.DeserializeObject<List<BuildingDTO>>(result.Content);
            }
            return null;
        }
        
        public async Task<BuildingDTO> GetBuildingByIdAsync(int buildingId)
        {
            var path = $"{Properties.Resources.getBuildingByIdPath}?buildingId={buildingId}";
            var result = await _apiHelper.Get(path);
            if (result != null && result.ResponseType == ResponseType.Success)
            {
                return JsonConvert.DeserializeObject<BuildingDTO>(result.Content);
            }
            else return null;
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
