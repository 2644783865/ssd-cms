using CMS.BE.DTO;
using CMS.BE.Models;
using CMS.Core.Helpers;
using CMS.Core.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.Core.Core
{
    public class PresentationCore : IPresentationCore
    {
        private ApiHelper _apiHelper = new ApiHelper();

        public async Task<bool> AddPresentationAsync(PresentationDTO presentation)
        {
            var path = Properties.Resources.addPresentationPath;
            var result = await _apiHelper.Post(path, presentation);
            return result != null && result.ResponseType == ResponseType.Success;
        }

        public async Task<bool> EditPresentationAsync(PresentationDTO presentation)
        {
            var path = Properties.Resources.editPresentationPath;
            var result = await _apiHelper.Put(path, presentation);
            return result != null && result.ResponseType == ResponseType.Success;
        }

        public async Task<bool> DeletePresentationAsync(int presentationId)
        {
            var path = $"{Properties.Resources.deletePresentationPath}?presentationId={presentationId}";
            var result = await _apiHelper.Delete(path);
            return result != null && result.ResponseType == ResponseType.Success;
        }

        public async Task<bool> EditGradeOfPresentationAsync(int presentationId, int grade)
        {
            var path = $"{Properties.Resources.editGradeOfPresentationPath}?presentationId={presentationId}&grade={grade}";
            var result = await _apiHelper.Put(path, null);
            return result != null && result.ResponseType == ResponseType.Success;
        }

        public async Task<bool> DeleteGradeFromPresentationAsync(int presentationId)
        {
            var path = $"{Properties.Resources.deleteGradeFromPresentationPath}?presentationId={presentationId}";
            var result = await _apiHelper.Put(path, null);
            return result != null && result.ResponseType == ResponseType.Success;
        }

        public async Task<bool> EditSessionOfPresentationAsync(int presentationId, int sessionId)
        {
            var path = $"{Properties.Resources.editSessionOfPresentationPath}?presentationId={presentationId}&sessionId={sessionId}";
            var result = await _apiHelper.Put(path, null);
            return result != null && result.ResponseType == ResponseType.Success;
        }

        public async Task<bool> EditSpecialSessionOfPresentationAsync(int presentationId, int specialSessionId)
        {
            var path = $"{Properties.Resources.editSpecialSessionOfPresentationPath}?presentationId={presentationId}&sessionId={specialSessionId}";
            var result = await _apiHelper.Put(path, null);
            return result != null && result.ResponseType == ResponseType.Success;
        }

        public async Task<bool> DeleteSessionFromPresentationAsync(int presentationId)
        {
            var path = $"{Properties.Resources.deleteSessionFromPresentationPath}?presentationId={presentationId}";
            var result = await _apiHelper.Put(path, null);
            return result != null && result.ResponseType == ResponseType.Success;
        }

        public async Task<bool> DeleteSpecialSessionFromPresentationAsync(int presentationId)
        {
            var path = $"{Properties.Resources.deleteSpecialSessionFromPresentationPath}?presentationId={presentationId}";
            var result = await _apiHelper.Put(path, null);
            return result != null && result.ResponseType == ResponseType.Success;
        }

        public void Dispose() => _apiHelper.Dispose();
    }
}
