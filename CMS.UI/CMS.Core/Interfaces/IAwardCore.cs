using CMS.BE.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.Core.Interfaces
{ 
 public interface IAwardCore : IDisposable
{
    Task<List<AwardDTO>> GetAwardsAsync();
    Task<AwardDTO> GetAwardByIdAsync(int awardId);
    Task<bool> AddAwardAsync(AwardDTO award);
    Task<bool> EditAwardAsync(AwardDTO award);
    Task<bool> DeleteAwardAsync(int awardId);
}
}
