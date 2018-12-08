using CMS.BE.DTO;
using System;
using System.Collections.Generic;

namespace CMS.API.DAL.Interfaces
{
    public interface ILastMessageRepository : IDisposable
    {
        LastMessageDTO GetLastMessageByPairId(int PairId);
        LastMessageDTO GetLastMessageByFirstId(int FirstId);
        LastMessageDTO GetLastMessageBySecondId(int SecondId);
        void AddLastMessage(LastMessageDTO lastMessageDTO);
        void EditLastMessage(LastMessageDTO lastMessageDTO);
        void DeleteLastMessage(int PairId);
    }
}
