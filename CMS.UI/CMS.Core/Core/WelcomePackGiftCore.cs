using CMS.BE.DTO;
using CMS.BE.Models;
using CMS.Core.Helpers;
using CMS.Core.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.Core.Core
{
    class WelcomePackGiftCore : IWelcomePackGiftCore
    {
        private ApiHelper _apiHelper = new ApiHelper();

        public async Task<List<WelcomePackGiftDTO>> GetWelcomePackGiftInfoAsync()
        {
            var path = $"{Properties.Resources.getWelcomePackGiftInfoPath}";
            var result = await _apiHelper.Get(path);
            if (result != null && result.ResponseType == ResponseType.Success)
            {
                return JsonConvert.DeserializeObject<List<WelcomePackGiftDTO>>(result.Content);
            }
            return null;
        }

        public async Task<WelcomePackGiftDTO> GetWelcomePackGiftByIdAsync(int welcomePackGiftId)
        {
            var path = $"{Properties.Resources.getWelcomePackGiftByIdPath}?welcomePackGiftId={welcomePackGiftId}";
            var result = await _apiHelper.Get(path);
            if (result != null && result.ResponseType == ResponseType.Success)
            {
                return JsonConvert.DeserializeObject<WelcomePackGiftDTO>(result.Content);
            }
            else return null;
        }

        public async Task<bool> AddWelcomePackGiftAsync(WelcomePackGiftDTO welcomePackGift)
        {
            var path = Properties.Resources.addWelcomePackGiftPath;
            var result = await _apiHelper.Post(path, welcomePackGift);
            return result != null && result.ResponseType == ResponseType.Success;
        }

        //not implemented
        public async Task<bool> EditWelcomePackGiftAsync(WelcomePackGiftDTO welcomePackGift)
        {
            var path = Properties.Resources.editWelcomePackGiftPath;
            var result = await _apiHelper.Put(path, welcomePackGift);
            return result != null && result.ResponseType == ResponseType.Success;
        }

        public async Task<bool> DeleteWelcomePackGiftAsync(int welcomePackGiftId)
        {
            var path = $"{Properties.Resources.deleteWelcomePackGiftPath}?welcomePackGiftId={welcomePackGiftId}";
            var result = await _apiHelper.Delete(path);
            return result != null && result.ResponseType == ResponseType.Success;
        }

        public void Dispose() => _apiHelper.Dispose();
    }
}
