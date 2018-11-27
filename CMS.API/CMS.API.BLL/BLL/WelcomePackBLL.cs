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
    }
}
