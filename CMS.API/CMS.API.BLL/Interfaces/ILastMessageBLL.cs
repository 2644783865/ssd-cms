using System.Collections.Generic;
using CMS.BE.DTO;

namespace CMS.API.BLL.Interfaces
{
    public interface ILastMessageBLL
    {
        LastMessageDTO GetLastMessageByPairId(int pairId);
        LastMessageDTO GetLastMessageByFirstId(int firstId);
        LastMessageDTO GetLastMessageBySecondId(int secondId);
        bool AddLastMessage(LastMessageDTO lastMessage);
        bool EditLastMessage(LastMessageDTO lastMessage);
        bool DeleteLastMessage(int pairId);
    }
}
