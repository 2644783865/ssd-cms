using CMS.BE.DTO;
using System.Collections.Generic;

namespace CMS.API.BLL.Interfaces
{
    public interface IWelcomePackGiftBLL
    {
        IEnumerable<WelcomePackGiftDTO> GetWelcomePackGiftInfo();
        WelcomePackGiftDTO GetWelcomePackGiftById(int id);
        bool AddWelcomePackGift(WelcomePackGiftDTO welcomepackgift);
        bool EditWelcomePackGift(WelcomePackGiftDTO welcomepackgift);
        bool DeleteWelcomePackGift(int welcomepackgiftId);
    }
}
