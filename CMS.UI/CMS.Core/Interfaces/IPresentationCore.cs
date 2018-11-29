using CMS.BE.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.Core.Interfaces
{
    public interface IPresentationCore : IDisposable
    {
        Task<bool> AddPresentationAsync(PresentationDTO presentation);
        Task<bool> EditPresentationAsync(PresentationDTO presentation);
        Task<bool> DeletePresentationAsync(int presentationId);
    }
}
