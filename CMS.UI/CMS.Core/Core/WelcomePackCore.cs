using CMS.BE.DTO;
using CMS.BE.Models;
using CMS.Core.Helpers;
using CMS.Core.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.Core.Core
{
    class WelcomePackCore : IWelcomePackCore
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

        public void Dispose() => _apiHelper.Dispose();
    }
}
