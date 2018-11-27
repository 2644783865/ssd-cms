using CMS.API.BLL.Interfaces;
using CMS.API.DAL.Interfaces;
using CMS.API.DAL.Repositories;
using CMS.BE.DTO;

namespace CMS.API.BLL.BLL
{
    public class MessageBLL : IMessageBLL
    {
        private IMessageRepository _repository = new MessageRepository();

        public bool AddMessage(MessageDTO message)
        {
            try
            {
                _repository.AddMessage(message);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool DeleteMessage(int groupId, int sequenceNumber)
        {
            try
            {
                _repository.DeleteMessage(groupId, sequenceNumber);
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
