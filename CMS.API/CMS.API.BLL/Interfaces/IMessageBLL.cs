using CMS.BE.DTO;

namespace CMS.API.BLL.Interfaces
{
    interface IMessageBLL
    {
        bool AddMessage(MessageDTO message);
        bool EditMessage(MessageDTO message);
        bool DeleteMessage(int messageId);
    }
}
