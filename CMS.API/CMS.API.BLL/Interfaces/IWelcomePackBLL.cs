using CMS.BE.DTO;
using System.Collections.Generic;

namespace CMS.API.BLL.Interfaces
{
    public interface IWelcomePackBLL
    {
        //Welcome Pack

        IEnumerable<WelcomePackDTO> GetWelcomePackInfo();
        WelcomePackDTO GetWelcomePackById(int id);
        bool AddWelcomePack(WelcomePackDTO welcomepack);
        bool EditWelcomePack(WelcomePackDTO welcomepack);
        bool DeleteWelcomePack(int welcomepackId);

        //Welcome Pack Gift

        IEnumerable<WelcomePackReceiverDTO> GetWelcomePackReceiverInfo();
        WelcomePackReceiverDTO GetWelcomePackReceiverById(int id);
        bool AddWelcomePackReceiver(WelcomePackReceiverDTO welcomepackreceiver);
        bool EditWelcomePackReceiver(WelcomePackReceiverDTO welcomepackreceiver);
        bool DeleteWelcomePackReceiver(int welcomepackreceiverId);

        //Welcome Pack Receiver

        IEnumerable<WelcomePackGiftDTO> GetWelcomePackGiftInfo();
        WelcomePackGiftDTO GetWelcomePackGiftById(int id);
        bool AddWelcomePackGift(WelcomePackGiftDTO welcomepackgift);
        bool EditWelcomePackGift(WelcomePackGiftDTO welcomepackgift);
        bool DeleteWelcomePackGift(int welcomepackgiftId);
    }
}

