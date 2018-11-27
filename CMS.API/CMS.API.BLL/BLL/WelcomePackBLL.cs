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

        //Welcome Pack

        public IEnumerable<WelcomePackDTO> GetWelcomePackInfo()
        {
            try
            {
                return _repository.GetWelcomePackInfo();
            }
            catch
            {
                return null;
            }
        }

        public WelcomePackDTO GetWelcomePackById(int id)
        {
            try
            {
                var welcomepack = _repository.GetWelcomePackById(id);
                if (welcomepack == null) return null;
                return welcomepack;
            }
            catch
            {
                return null;
            }
        }

        public bool AddWelcomePack(WelcomePackDTO welcomepack)
        {
            try
            {
                _repository.AddWelcomePack(welcomepack);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool EditWelcomePack(WelcomePackDTO welcomepack)
        {
            try
            {
                _repository.EditWelcomePack(welcomepack);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool DeleteWelcomePack(int welcomepackId)
        {
            try
            {
                _repository.DeleteWelcomePack(welcomepackId);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public IEnumerable<WelcomePackReceiverDTO> GetWelcomePackReceiverInfo()
        {
            try
            {
                return _repository.GetWelcomePackReceiverInfo();
            }
            catch
            {
                return null;
            }
        }

        //Welcome Pack Receiver

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

        //Welcome Pack Gift

        public IEnumerable<WelcomePackGiftDTO> GetWelcomePackGiftInfo()
        {
            try
            {
                return _repository.GetWelcomePackGiftInfo();
            }
            catch
            {
                return null;
            }
        }

        public WelcomePackGiftDTO GetWelcomePackGiftById(int id)
        {
            try
            {
                var welcomepackgift = _repository.GetWelcomePackGiftById(id);
                if (welcomepackgift == null) return null;
                return welcomepackgift;
            }
            catch
            {
                return null;
            }
        }

        public bool AddWelcomePackGift(WelcomePackGiftDTO welcomepackgift)
        {
            try
            {
                _repository.AddWelcomePackGift(welcomepackgift);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool EditWelcomePackGift(WelcomePackGiftDTO welcomepackgift)
        {
            try
            {
                _repository.EditWelcomePackGift(welcomepackgift);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool DeleteWelcomePackGift(int welcomepackgiftId)
        {
            try
            {
                _repository.DeleteWelcomePackGift(welcomepackgiftId);
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
