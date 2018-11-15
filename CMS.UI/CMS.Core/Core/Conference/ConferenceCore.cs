using CMS.BE.Models;
using CMS.Core.Helpers;
using CMS.Core.Interfaces.Conference;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CMS.Core.Core.Conference
{
    public class ConferenceCore : IConferenceCore
    {
        private ApiHelper _apiHelper = new ApiHelper();

        public async void LoadConferencesAsync(ComboBox conferencesBox)
        {
            conferencesBox.DisplayMemberPath = "Title";
            conferencesBox.SelectedValuePath = "ConferenceId";

            var path = $"{Properties.Resources.conferencesPath}";
            var result = await _apiHelper.Get(path);
            if (result != null && result.ResponseType == ResponseType.Success)
            {
                var conferences = JsonConvert.DeserializeObject<List<BE.Conference>>(result.Content);
                foreach (var conference in conferences)
                {
                    conferencesBox.Items.Add(conference);
                }
            }
        }

        public async Task<bool> AddConferenceAsync(BE.Conference conference)
        {
            var path = Properties.Resources.addConferencePath;
            var result = await _apiHelper.Post(path, conference);
            return result != null && result.ResponseType == ResponseType.Success;
        }

        public void Dispose() => _apiHelper.Dispose();
    }
}
