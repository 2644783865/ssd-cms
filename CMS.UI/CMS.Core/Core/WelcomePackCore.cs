using CMS.BE.DTO;
using CMS.BE.Models;
using CMS.Core.Helpers;
using CMS.Core.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.Core.Core
{
    class WelcomePackCore : IWelcomePackCore, IWelcomePackGiftCore, IWelcomePackReceiverCore
    {
        private ApiHelper _apiHelper = new ApiHelper();

        public async Task<List<WelcomePackDTO>> GetWelcomePackInfoAsync()
        {
            var path = $"{Properties.Resources.getWelcomePackInfoPath}";
            var result = await _apiHelper.Get(path);
            if (result != null && result.ResponseType == ResponseType.Success)
            {
                return JsonConvert.DeserializeObject<List<WelcomePackDTO>>(result.Content);
            }
            return null;
        }

        public async Task<WelcomePackDTO> GetWelcomePackByIdAsync(int welcomePackId)
        {
            var path = $"{Properties.Resources.getWelcomePackByIdPath}?welcomePackId={welcomePackId}";
            var result = await _apiHelper.Get(path);
            if (result != null && result.ResponseType == ResponseType.Success)
            {
                return JsonConvert.DeserializeObject<WelcomePackDTO>(result.Content);
            }
            else return null;
        }

        public async Task<bool> AddWelcomePackAsync(WelcomePackDTO welcomePack)
        {
            var path = Properties.Resources.addWelcomePackPath;
            var result = await _apiHelper.Post(path, welcomePack);
            return result != null && result.ResponseType == ResponseType.Success;
        }

        //not implemented
        public async Task<bool> EditWelcomePackAsync(WelcomePackDTO welcomePack)
        {
            var path = Properties.Resources.editWelcomePackPath;
            var result = await _apiHelper.Put(path, welcomePack);
            return result != null && result.ResponseType == ResponseType.Success;
        }

        public async Task<bool> DeleteWelcomePackAsync(int welcomePackId)
        {
            var path = $"{Properties.Resources.deleteWelcomePackPath}?welcomePackId={welcomePackId}";
            var result = await _apiHelper.Delete(path);
            return result != null && result.ResponseType == ResponseType.Success;
        }

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

        public async Task<List<WelcomePackReceiverDTO>> GetWelcomePackReceiverInfoAsync()
        {
            var path = $"{Properties.Resources.getWelcomePackReceiverInfoPath}";
            var result = await _apiHelper.Get(path);
            if (result != null && result.ResponseType == ResponseType.Success)
            {
                return JsonConvert.DeserializeObject<List<WelcomePackReceiverDTO>>(result.Content);
            }
            return null;
        }

        public async Task<WelcomePackReceiverDTO> GetWelcomePackReceiverByIdAsync(int welcomePackReceiverId)
        {
            var path = $"{Properties.Resources.getWelcomePackReceiverByIdPath}?welcomePackReceiverId={welcomePackReceiverId}";
            var result = await _apiHelper.Get(path);
            if (result != null && result.ResponseType == ResponseType.Success)
            {
                return JsonConvert.DeserializeObject<WelcomePackReceiverDTO>(result.Content);
            }
            else return null;
        }

        public async Task<bool> AddWelcomePackReceiverAsync(WelcomePackReceiverDTO welcomePackReceiver)
        {
            var path = Properties.Resources.addWelcomePackReceiverPath;
            var result = await _apiHelper.Post(path, welcomePackReceiver);
            return result != null && result.ResponseType == ResponseType.Success;
        }

        //not implemented
        public async Task<bool> EditWelcomePackReceiverAsync(WelcomePackReceiverDTO welcomePackReceiver)
        {
            var path = Properties.Resources.editWelcomePackReceiverPath;
            var result = await _apiHelper.Put(path, welcomePackReceiver);
            return result != null && result.ResponseType == ResponseType.Success;
        }

        public async Task<bool> DeleteWelcomePackReceiverAsync(int welcomePackReceiverId)
        {
            var path = $"{Properties.Resources.deleteWelcomePackReceiverPath}?welcomePackReceiverId={welcomePackReceiverId}";
            var result = await _apiHelper.Delete(path);
            return result != null && result.ResponseType == ResponseType.Success;
        }

        public void Dispose() => _apiHelper.Dispose();
    }
}
