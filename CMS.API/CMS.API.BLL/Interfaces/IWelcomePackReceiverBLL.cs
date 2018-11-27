using CMS.BE.DTO;
using System.Collections.Generic;

namespace CMS.API.BLL.Interfaces
{
    public interface IWelcomePackReceiverBLL
    {
        IEnumerable<WelcomePackReceiverDTO> GetWelcomePackReceiverInfo();
        WelcomePackReceiverDTO GetWelcomePackReceiverById(int id);
        bool AddWelcomePackReceiver(WelcomePackReceiverDTO welcomepackreceiver);
        bool EditWelcomePackReceiver(WelcomePackReceiverDTO welcomepackreceiver);
        bool DeleteWelcomePackReceiver(int welcomepackreceiverId);
    }
}

