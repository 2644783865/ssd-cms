using CMS.BE.DTO;
using System;
using System.Collections.Generic;

namespace CMS.API.DAL.Interfaces
{
    public interface ILastMessageRepository : IDisposable
    {
        LastMessageDTO GetLastMessageByPairId(int pairId);
        LastMessageDTO GetLastMessageByFirstId(int firstId);
        LastMessageDTO GetLastMessageBySecondId(int secondId);
        void AddLastMessage(LastMessageDTO lastMessageDTO);
        void EditLastMessage(LastMessageDTO lastMessageDTO);
        void DeleteLastMessage(int pairId);
    }
}
