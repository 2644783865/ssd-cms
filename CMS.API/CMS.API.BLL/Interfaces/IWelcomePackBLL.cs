using CMS.BE.DTO;
using System.Collections.Generic;

namespace CMS.API.BLL.Interfaces
{
    public interface IWelcomePackBLL
    {
        IEnumerable<WelcomePackDTO> GetWelcomePackInfo();
        WelcomePackDTO GetWelcomePackById(int id);
        bool AddWelcomePack(WelcomePackDTO welcomepack);
        bool EditWelcomePack(WelcomePackDTO welcomepack);
        bool DeleteWelcomePack(int welcomepackId);
    }
}

