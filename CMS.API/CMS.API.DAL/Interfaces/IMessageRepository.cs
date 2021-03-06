﻿using CMS.BE.DTO;
using System;
using System.Collections.Generic;

namespace CMS.API.DAL.Interfaces
{
    public interface IMessageRepository : IDisposable
    {
        IEnumerable<MessageDTO> GetMessages();
        IEnumerable<MessageDTO> GetMessagesByAccountId(int accountId);
        IEnumerable<MessageDTO> GetMessagesByTargetId(int requesterId, int targetId);
        IEnumerable<MessageDTO> GetMessagesBySenderId(int senderId);
        IEnumerable<MessageDTO> GetMessagesByReceiverId(int receiverId);
        MessageDTO GetMessageById(int messageId);
        void AddMessage(MessageDTO messageDTsO);
        void EditMessage(MessageDTO messageDTO);
        void DeleteMessage(int messageId);
        IEnumerable<LastMessageDTO> GetLastMessagesByAccountId(int accountId);
        void MarkReceived(int firstId, int secondId);
    }
}
