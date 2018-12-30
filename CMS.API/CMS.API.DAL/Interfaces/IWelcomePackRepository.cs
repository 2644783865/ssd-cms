using CMS.BE.DTO;
using System;
using System.Collections.Generic;

namespace CMS.API.DAL.Interfaces
{
    public interface IWelcomePackRepository : IDisposable
    {
        //WelcomePackReciever
        IEnumerable<WelcomePackReceiverDTO> GetWelcomePackReceiverInfo();
        WelcomePackReceiverDTO GetWelcomePackReceiverById(int id);
        IEnumerable<WelcomePackReceiverDTO> GetGuestsByConferenceId(int id);
        void AddWelcomePackReceiver(WelcomePackReceiverDTO welcomePackReceiverDTO);
        void EditWelcomePackReceiver(WelcomePackReceiverDTO welcomePackReceiverDTO);
        void DeleteWelcomePackReceiver(int welcomePackReceiverId);
    }
}
