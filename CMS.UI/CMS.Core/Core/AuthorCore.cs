using CMS.BE.DTO;
using CMS.BE.Models;
using CMS.Core.Helpers;
using CMS.Core.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.Core.Core
{
    public class AuthorCore : IAuthorCore
    {
        private ApiHelper _apiHelper = new ApiHelper();

        public async Task<List<AuthorDTO>> GetAuthorsAsync()
        {
            var path = $"{Properties.Resources.getAuthorsPath}";
            var result = await _apiHelper.Get(path);
            if (result != null && result.ResponseType == ResponseType.Success)
            {
                return JsonConvert.DeserializeObject<List<AuthorDTO>>(result.Content);
            }
            return null;
        }

        public async Task<AuthorDTO> GetAuthorByIdAsync(int authorId)
        {
            var path = $"{Properties.Resources.getAuthorByIdPath}?authorId={authorId}";
            var result = await _apiHelper.Get(path);
            if (result != null && result.ResponseType == ResponseType.Success)
            {
                return JsonConvert.DeserializeObject<AuthorDTO>(result.Content);
            }
            else return null;
        }

        public async Task<bool> AddAuthorAsync(AuthorDTO author)
        {
            var path = Properties.Resources.addAuthorPath;
            var result = await _apiHelper.Post(path, author);
            return result != null && result.ResponseType == ResponseType.Success;
        }

        //not implemented
        public async Task<bool> EditAuthorAsync(AuthorDTO author)
        {
            var path = Properties.Resources.editAuthorPath;
            var result = await _apiHelper.Put(path, author);
            return result != null && result.ResponseType == ResponseType.Success;
        }

        public async Task<bool> DeleteAuthorAsync(int authorId)
        {
            var path = $"{Properties.Resources.deleteAuthorPath}?authorId={authorId}";
            var result = await _apiHelper.Delete(path);
            return result != null && result.ResponseType == ResponseType.Success;
        }

        public void Dispose() => _apiHelper.Dispose();
    }
}
