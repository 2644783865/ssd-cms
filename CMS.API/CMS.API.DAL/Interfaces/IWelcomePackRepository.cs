using CMS.BE.DTO;
using System;
using System.Collections.Generic;

namespace CMS.API.DAL.Interfaces
{
    public interface IWelcomePackRepository : IDisposable
    {
        //WelcomePack
        IEnumerable<WelcomePackDTO> GetWelcomePackInfo();
        WelcomePackDTO GetWelcomePackById(int id);
        void AddWelcomePack(WelcomePackDTO welcomePackDTO);
        void EditWelcomePack(WelcomePackDTO welcomePackDTO);
        void DeleteWelcomePack(int welcomePackId);

        //WelcomePackGift
        IEnumerable<WelcomePackGiftDTO> GetWelcomePackGiftInfo();
        WelcomePackGiftDTO GetWelcomePackGiftById(int id);
        void AddWelcomePackGift(WelcomePackGiftDTO welcomePackGiftDTO);
        void EditWelcomePackGift(WelcomePackGiftDTO welcomePackGiftDTO);
        void DeleteWelcomePackGift(int welcomePackGiftId);

        //WelcomePackReciever
        IEnumerable<WelcomePackReceiverDTO> GetWelcomePackReceiverInfo();
        WelcomePackReceiverDTO GetWelcomePackReceiverById(int id);
        void AddWelcomePackReceiver(WelcomePackReceiverDTO welcomePackReceiverDTO);
        void EditWelcomePackReceiver(WelcomePackReceiverDTO welcomePackReceiverDTO);
        void DeleteWelcomePackReceiver(int welcomePackReceiverId);
    }
}
