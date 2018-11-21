using CMS.BE.DTO;
using System;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CMS.Core.Interfaces.Conference
{
    public interface IConferenceCore : IDisposable
    {
        void LoadConferencesAsync(ComboBox conferencesBox);
        Task<bool> AddConferenceAsync(ConferenceDTO conference);
    }
}
