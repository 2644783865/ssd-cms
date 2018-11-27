using CMS.API.BLL.Interfaces;
using CMS.API.DAL.Interfaces;
using CMS.API.DAL.Repositories;
using CMS.BE.DTO;

namespace CMS.API.BLL.BLL
{
    class MessageBLL : IMessageBLL
    {
        private IMessageRepository _repository = new MessageRepository();

        public bool AddMessage(MessageDTO messageId)
        {
            try
            {
                _repository.AddMessage(messageId);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool DeleteMessage(int message)
        {
            try
            {
                _repository.DeleteMessage(message);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool EditMessage(MessageDTO message)
        {
            try
            {
                _repository.EditMessage(message);
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
