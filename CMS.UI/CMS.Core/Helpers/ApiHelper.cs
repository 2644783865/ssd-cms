using CMS.BE.Models;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Core.Helpers
{
    public class ApiHelper : IDisposable
    {
        private HttpClient client;

        public ApiHelper()
        {
            client = SetupApiClient();
        }

        public HttpClient SetupApiClient()
        {
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri(AppSettings.ApiBaseURL)
            };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = BasicAuthorizeHelper.generateAuthenticationHeader();
            return client;
        }

        public async Task<ResponseModel> Get(string path)
        {
            HttpResponseMessage response;
            try
            {
                response = await client.GetAsync(path);
            }
            catch
            {
                return null;
            }
            return await GetResponseModel(response);
        }

        public async Task<ResponseModel> Post(string path, object contentObject)
        {
            HttpContent content = new StringContent(JsonConvert.SerializeObject(contentObject), Encoding.UTF8, "application/json");
            HttpResponseMessage response;
            try
            {
                response = await client.PostAsync(path, content);
            }
            catch
            {
                return null;
            }
            return await GetResponseModel(response);
        }

        public async Task<ResponseModel> Put(string path, object contentObject)
        {
            HttpContent content = new StringContent(JsonConvert.SerializeObject(contentObject), Encoding.UTF8, "application/json");
            HttpResponseMessage response;
            try
            {
                response = await client.PutAsync(path, content);
            }
            catch
            {
                return null;
            }
            return await GetResponseModel(response);
        }

        public async Task<ResponseModel> Delete(string path)
        {
            HttpResponseMessage response;
            try
            {
                response = await client.DeleteAsync(path);
            }
            catch
            {
                return null;
            }
            return await GetResponseModel(response);
        }

        public void Dispose()
        {
            client.Dispose();
        }

        private async static Task<ResponseModel> GetResponseModel(HttpResponseMessage response)
        {
            var model = new ResponseModel()
            {
                Content = await response.Content.ReadAsStringAsync()
            };
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    model.ResponseType = ResponseType.Success;
                    break;
                case HttpStatusCode.BadRequest:
                    model.ResponseType = ResponseType.WrongData;
                    break;
                case HttpStatusCode.Unauthorized:
                    model.ResponseType = ResponseType.Unauthorized;
                    break;
                default:
                    model.ResponseType = ResponseType.Error;
                    break;
            }
            return model;
        }
    }
}
