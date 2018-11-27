using CMS.API.BLL.Interfaces;
using CMS.API.DAL.Interfaces;
using CMS.API.DAL.Repositories;
using CMS.BE.DTO;
using System.Collections.Generic;

namespace CMS.API.BLL.BLL
{
    public class WelcomePackGiftBLL : IWelcomePackGiftBLL
    {
        private IWelcomePackRepository _repository = new WelcomePackRepository();

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
