﻿using CMS.BE.DTO;
using CMS.BE.Models;
using CMS.Core.Helpers;
using CMS.Core.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.Core.Core
{
    public class MessageCore : IMessageCore
    {
        private ApiHelper _apiHelper = new ApiHelper();
        
        public async Task<List<MessageDTO>> GetMessagesAsync()
        {
            var path = $"{Properties.Resources.getMessagesPath}";
            var result = await _apiHelper.Get(path);
            if (result != null && result.ResponseType == ResponseType.Success)
            {
                return JsonConvert.DeserializeObject<List<MessageDTO>>(result.Content);
            }
            return null;
        }

        public async Task<MessageDTO> GetMessageByIdAsync(int messageId)
        {
            var path = $"{Properties.Resources.getMessageByIdPath}?messageId={messageId}";
            var result = await _apiHelper.Get(path);
            if (result != null && result.ResponseType == ResponseType.Success)
            {
                return JsonConvert.DeserializeObject<MessageDTO>(result.Content);
            }
            else return null;
        }

        public async Task<MessageDTO> GetMessageBySenderIdAsync(int senderId)
        {
            var path = $"{Properties.Resources.getMessageBySenderIdPath}?senderId={senderId}";
            var result = await _apiHelper.Get(path);
            if (result != null && result.ResponseType == ResponseType.Success)
            {
                return JsonConvert.DeserializeObject<MessageDTO>(result.Content);
            }
            else return null;
        }

        public async Task<MessageDTO> GetMessageByReceiverIdAsync(int receiverId)
        {
            var path = $"{Properties.Resources.getMessageByReceiverIdPath}?receiverId={receiverId}";
            var result = await _apiHelper.Get(path);
            if (result != null && result.ResponseType == ResponseType.Success)
            {
                return JsonConvert.DeserializeObject<MessageDTO>(result.Content);
            }
            else return null;
        }

        public async Task<List<MessageDTO>> GetMessagesByAccountIdAsync(int accountId)
        {
            var path = $"{Properties.Resources.getMessagesByAccountIdPath}?accountId={accountId}";
            var result = await _apiHelper.Get(path);
            if (result != null && result.ResponseType == ResponseType.Success)
            {
                return JsonConvert.DeserializeObject<List<MessageDTO>>(result.Content);
            }
            return null;
        }

        public async Task<bool> AddMessageAsync(MessageDTO message)
        {
            var path = Properties.Resources.addMessagePath;
            var result = await _apiHelper.Post(path, message);
            return result != null && result.ResponseType == ResponseType.Success;
        }

        public async Task<bool> EditMessageAsync(MessageDTO message)
        {
            var path = Properties.Resources.editMessagePath;
            var result = await _apiHelper.Put(path, message);
            return result != null && result.ResponseType == ResponseType.Success;
        }

        public async Task<bool> DeleteMessageAsync(int messageId)
        {
            var path = $"{Properties.Resources.deleteMessagePath}?messageId={messageId}";
            var result = await _apiHelper.Delete(path);
            return result != null && result.ResponseType == ResponseType.Success;
        }

        public void Dispose() => _apiHelper.Dispose();

        public async Task<List<LastMessageDTO>> GetLastMessagesByAccountIdAsync(int accountId)
        {
            var path = $"{Properties.Resources.getLastMessagesByAccountIdPath}?accountId={accountId}";
            var result = await _apiHelper.Get(path);
            if (result != null && result.ResponseType == ResponseType.Success)
            {
                return JsonConvert.DeserializeObject<List<LastMessageDTO>>(result.Content);
            }
            return null;
        }

        public async Task<List<MessageDTO>> GetMessagesByTargetIdAsync(int requesterId, int targetId)
        {
            var path = $"{Properties.Resources.getMessagesByTargetIdPath}?requesterId={requesterId}&targetId={targetId}";
            var result = await _apiHelper.Get(path);
            if (result != null && result.ResponseType == ResponseType.Success)
            {
                return JsonConvert.DeserializeObject<List<MessageDTO>>(result.Content);
            }
            return null;
        }

        public async Task<int> HasNewMessages()
        {
            int currentUserId = UserCredentials.Account.AccountId;
            int counter = 0;
            var path = $"{Properties.Resources.getLastMessagesByAccountIdPath}?accountId={currentUserId}";
            var result = await _apiHelper.Get(path);
            if (result != null && result.ResponseType == ResponseType.Success)
            {
                
                var recent_messages = JsonConvert.DeserializeObject<List<LastMessageDTO>>(result.Content);
                counter = 0;
                foreach(var msg in recent_messages)
                {
                    if (msg.FirstId == currentUserId && !Convert.ToBoolean(msg.firstIdReceived) ||
                        (msg.SecondId == currentUserId && !Convert.ToBoolean(msg.secondIdReceived)))
                    {
                        ++counter;
                    }
                }
            }
            return counter;
        }

        public async Task<bool> markReceived(int FirstId, int SecondId)
        {
            var path = $"{Properties.Resources.markMessageReceivedPath}?FirstId={FirstId}&SecondId={SecondId}";
            var result = await _apiHelper.Get(path);
            return result != null && result.ResponseType == ResponseType.Success;
        }
    }
}
