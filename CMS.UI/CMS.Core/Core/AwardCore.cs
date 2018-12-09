using CMS.BE.DTO;
using CMS.BE.Models;
using CMS.Core.Helpers;
using CMS.Core.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.Core.Core
{
    public class AwardCore : IAwardCore
    {
        private ApiHelper _apiHelper = new ApiHelper();

        public async Task<List<AwardDTO>> GetAwardsAsync()
        {
            var path = $"{Properties.Resources.getAwardsPath}";
            var result = await _apiHelper.Get(path);
            if (result != null && result.ResponseType == ResponseType.Success)
            {
                return JsonConvert.DeserializeObject<List<AwardDTO>>(result.Content);
            }
            return null;
        }

        public async Task<AwardDTO> GetAwardByIdAsync(int AwardId)
        {
            var path = $"{Properties.Resources.getAwardByIdPath}?awardId={AwardId}";
            var result = await _apiHelper.Get(path);
            if (result != null && result.ResponseType == ResponseType.Success)
            {
                return JsonConvert.DeserializeObject<AwardDTO>(result.Content);
            }
            else return null;
        }

        public async Task<bool> AddAwardAsync(AwardDTO award)
        {
            var path = Properties.Resources.addAwardPath;
            var result = await _apiHelper.Post(path, award);
            return result != null && result.ResponseType == ResponseType.Success;
        }
        public async Task<bool> EditAwardAsync(AwardDTO award)
        {
            var path = Properties.Resources.editAwardPath;
            var result = await _apiHelper.Put(path, award);
            return result != null && result.ResponseType == ResponseType.Success;
        }

        public async Task<bool> DeleteAwardAsync(int AwardId)
        {
            var path = $"{Properties.Resources.deleteAwardPath}?awardId={AwardId}";
            var result = await _apiHelper.Delete(path);
            return result != null && result.ResponseType == ResponseType.Success;
        }

        public void Dispose() => _apiHelper.Dispose();
    }
}
