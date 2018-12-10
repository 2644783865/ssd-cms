using CMS.API.BLL.Interfaces;
using CMS.API.DAL.Interfaces;
using CMS.API.DAL.Repositories;
using CMS.BE.DTO;
using System.Collections.Generic;

namespace CMS.API.BLL.BLL
{
    public class LastMessageBLL : ILastMessageBLL
    {
        private ILastMessageRepository _repository = new LastMessageRepository();

        public LastMessageDTO GetLastMessageByPairId(int pairId)
        {
            try
            {
                return _repository.GetLastMessageByPairId(pairId);
            }
            catch
            {
                return null;
            }
        }


        public LastMessageDTO GetLastMessageByFirstId(int firstId)
        {
            try
            {
                return _repository.GetLastMessageByFirstId(firstId);
            }
            catch
            {
                return null;
            }
        }

        public LastMessageDTO GetLastMessageBySecondId(int secondId)
        {
            try
            {
                return _repository.GetLastMessageBySecondId(secondId);
            }
            catch
            {
                return null;
            }
        }

        public bool AddLastMessage(LastMessageDTO lastMessage)
        {
            try
            {
                _repository.AddLastMessage(lastMessage);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool EditLastMessage(LastMessageDTO lastMessage)
        {
            try
            {
                _repository.EditLastMessage(lastMessage);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool DeleteLastMessage(int pairId)
        {
            try
            {
                _repository.DeleteLastMessage(pairId); 
            }
            catch
            {
                return false;
            }
            return true;
        }

    }
}
