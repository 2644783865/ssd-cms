using CMS.BE.DTO;

namespace CMS.API.BLL.Interfaces
{
    public interface IMessageBLL
    {
        bool AddMessage(MessageDTO message);
        bool EditMessage(MessageDTO message);
        bool DeleteMessage(int groupId, int sequenceNumber);
    }
}
