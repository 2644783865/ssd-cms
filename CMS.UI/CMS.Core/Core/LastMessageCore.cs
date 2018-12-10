using CMS.BE.DTO;
using CMS.BE.Models;
using CMS.Core.Helpers;
using CMS.Core.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.Core.Core
{
    public class LastMessageCore : ILastMessageCore
    {
        private ApiHelper _apiHelper = new ApiHelper();

       
        public async Task<LastMessageDTO> GetLastMessageByPairIdAsync(int pairId)
        {
            var path = $"{Properties.Resources.getLastMessageByPairIdPath}?pairId={pairId}";
            var result = await _apiHelper.Get(path);
            if (result != null && result.ResponseType == ResponseType.Success)
            {
                return JsonConvert.DeserializeObject<LastMessageDTO>(result.Content);
            }
            else return null;
        }

        public async Task<LastMessageDTO> GetLastMessageByFirstIdAsync(int firstId)
        {
            var path = $"{Properties.Resources.getLastMessageByFirstIdPath}?senderId={firstId}";
            var result = await _apiHelper.Get(path);
            if (result != null && result.ResponseType == ResponseType.Success)
            {
                return JsonConvert.DeserializeObject<LastMessageDTO>(result.Content);
            }
            else return null;
        }

        public async Task<LastMessageDTO> GetLastMessageBySecondIdAsync(int secondId)
        {
            var path = $"{Properties.Resources.getLastMessageBySecondIdPath}?secondId={secondId}";
            var result = await _apiHelper.Get(path);
            if (result != null && result.ResponseType == ResponseType.Success)
            {
                return JsonConvert.DeserializeObject<LastMessageDTO>(result.Content);
            }
            else return null;
        }

        public async Task<bool> AddLastMessageAsync(LastMessageDTO lastmessage)
        {
            var path = Properties.Resources.addLastMessagePath;
            var result = await _apiHelper.Post(path, lastmessage);
            return result != null && result.ResponseType == ResponseType.Success;
        }

        public async Task<bool> EditLastMessageAsync(LastMessageDTO lastmessage)
        {
            var path = Properties.Resources.editLastMessagePath;
            var result = await _apiHelper.Put(path, lastmessage);
            return result != null && result.ResponseType == ResponseType.Success;
        }

        public async Task<bool> DeleteLastMessageAsync(int pairId)
        {
            var path = $"{Properties.Resources.deleteLastMessagePath}?pairId={pairId}";
            var result = await _apiHelper.Delete(path);
            return result != null && result.ResponseType == ResponseType.Success;
        }

        public void Dispose() => _apiHelper.Dispose();
    }
}
