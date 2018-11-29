using CMS.BE.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.Core.Interfaces
{
    public interface IMessageCore : IDisposable
    {
        Task<bool> AddMessageAsync(MessageDTO message);
        Task<bool> EditMessageAsync(MessageDTO message);
        Task<bool> DeleteMessageAsync(int groupId, int sequenceNumber);
    }
}
