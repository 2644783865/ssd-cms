using CMS.API.BLL.Interfaces;
using CMS.API.DAL.Interfaces;
using CMS.API.DAL.Repositories;
using CMS.BE.DTO;
using System.Collections.Generic;

namespace CMS.API.BLL.BLL
{
    public class WelcomePackBLL : IWelcomePackBLL
    {
        private IWelcomePackRepository _repository = new WelcomePackRepository();

        //Welcome Pack Receiver

        public IEnumerable<WelcomePackReceiverDTO> GetWelcomePackReceiverInfo()
        {
            try
            {
                var welcomepackreceiver = _repository.GetWelcomePackReceiverInfo();
                if (welcomepackreceiver == null) return null;
                return welcomepackreceiver;
            }
            catch
            {
                return null;
            }
        }

        public WelcomePackReceiverDTO GetWelcomePackReceiverById(int id)
        {
            try
            {
                var welcomepackreceiver = _repository.GetWelcomePackReceiverById(id);
                if (welcomepackreceiver == null) return null;
                return welcomepackreceiver;
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<WelcomePackReceiverDTO> GetGuestsByConferenceId(int id)
        {
                try
                {
                    return _repository.GetGuestsByConferenceId(id);
                }
                catch
                {
                    return null;
                }
        }

        public bool AddWelcomePackReceiver(WelcomePackReceiverDTO welcomepackreceiver)
        {
            try
            {
                _repository.AddWelcomePackReceiver(welcomepackreceiver);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool EditWelcomePackReceiver(WelcomePackReceiverDTO welcomepackreceiver)
        {
            try
            {
                _repository.EditWelcomePackReceiver(welcomepackreceiver);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool DeleteWelcomePackReceiver(int welcomepackreceiverId)
        {
            try
            {
                _repository.DeleteWelcomePackReceiver(welcomepackreceiverId);
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
