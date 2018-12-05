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
        /*
        public async Task<List<PresentationDTO>> GetPresentationsAsync()
        {
            var path = $"{Properties.Resources.getPresentationsPath}";
            var result = await _apiHelper.Get(path);
            if (result != null && result.ResponseType == ResponseType.Success)
            {
                return JsonConvert.DeserializeObject<List<PresentationDTO>>(result.Content);
            }
            return null;
        }

        public async Task<PresentationDTO> GetPresentationByIdAsync(int presentationId)
        {
            var path = $"{Properties.Resources.getPresentationByIdPath}?presentationId={presentationId}";
            var result = await _apiHelper.Get(path);
            if (result != null && result.ResponseType == ResponseType.Success)
            {
                return JsonConvert.DeserializeObject<PresentationDTO>(result.Content);
            }
            else return null;
        }
        */
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

        public void Dispose() => _apiHelper.Dispose();
    }
}
