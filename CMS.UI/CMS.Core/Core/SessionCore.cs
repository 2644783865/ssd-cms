using CMS.BE.DTO;
using CMS.BE.Models;
using CMS.Core.Helpers;
using CMS.Core.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.Core.Core
{
    public class SessionCore : ISessionCore
    {
        private ApiHelper _apiHelper = new ApiHelper();

        public async Task<bool> AddSessionAsync(SessionDTO session)
        {
            var path = Properties.Resources.addSessionPath;
            var result = await _apiHelper.Post(path, session);
            return result != null && result.ResponseType == ResponseType.Success;
        }

        public async Task<bool> EditSessionAsync(SessionDTO session)
        {
            var path = Properties.Resources.editSessionPath;
            var result = await _apiHelper.Put(path, session);
            return result != null && result.ResponseType == ResponseType.Success;
        }

        public async Task<bool> DeleteSessionAsync(int sessionId)
        {
            var path = $"{Properties.Resources.deleteSessionPath}?sessionId={sessionId}";
            var result = await _apiHelper.Delete(path);
            return result != null && result.ResponseType == ResponseType.Success;
        }



        public async Task<bool> AddSpecialSessionnAsync(SpecialSessionDTO specialSession)
        {
            var path = Properties.Resources.addSpecialSessionPath;
            var result = await _apiHelper.Post(path, specialSession);
            return result != null && result.ResponseType == ResponseType.Success;
        }

        public async Task<bool> EditSpecialSessionAsync(SpecialSessionDTO specialSession)
        {
            var path = Properties.Resources.editSpecialSessionPath;
            var result = await _apiHelper.Put(path, specialSession);
            return result != null && result.ResponseType == ResponseType.Success;
        }

        public async Task<bool> DeleteSpecialSessionAsync(int specialSessionId)
        {
            var path = $"{Properties.Resources.deleteSpecialSessionPath}?specialSessionId={specialSessionId}";
            var result = await _apiHelper.Delete(path);
            return result != null && result.ResponseType == ResponseType.Success;
        }

        public void Dispose() => _apiHelper.Dispose();
    }
}
