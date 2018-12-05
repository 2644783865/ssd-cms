using CMS.BE.DTO;
using CMS.BE.Models;
using CMS.Core.Helpers;
using CMS.Core.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.Core.Core
{
    class WelcomePackReceiverCore : IWelcomePackReceiverCore
    {
        private ApiHelper _apiHelper = new ApiHelper();

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
            var result = await _apiHelper.Post(path, conference);
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
