using CMS.BE.DTO;
using CMS.BE.Models;
using CMS.Core.Helpers;
using CMS.Core.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.Core.Core
{
    public class MessageCore : IMessageCore
    {
        private ApiHelper _apiHelper = new ApiHelper();
      
        public async Task<bool> AddMessageAsync(MessageDTO message)
        {
            var path = Properties.Resources.addMessagePath;
            var result = await _apiHelper.Post(path, message);
            return result != null && result.ResponseType == ResponseType.Success;
        }

        public async Task<bool> EditMessageAsync(MessageDTO message)
        {
            var path = Properties.Resources.editMessagePath;
            var result = await _apiHelper.Put(path, message);
            return result != null && result.ResponseType == ResponseType.Success;
        }

        public async Task<bool> DeleteMessageAsync(int groupId, int sequenceNumber)
        {
            var path = $"{Properties.Resources.deleteMessagePath}?groupId={groupId}&sequenceNumber={sequenceNumber}";
            var result = await _apiHelper.Delete(path);
            return result != null && result.ResponseType == ResponseType.Success;
        }

        public void Dispose() => _apiHelper.Dispose();
    }
}
