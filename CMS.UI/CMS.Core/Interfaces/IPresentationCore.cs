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

        Task<bool> EditGradeOfPresentationAsync(int presentationId, int grade);
        Task<bool> DeleteGradeFromPresentationAsync(int presentationId);
        Task<bool> EditSessionOfPresentationAsync(int presentationId, int sessionId);
        Task<bool> EditSpecialSessionOfPresentationAsync(int presentationId, int specialSessionId);
        Task<bool> DeleteSessionFromPresentationAsync(int presentationId);
        Task<bool> DeleteSpecialSessionFromPresentationAsync(int presentationId);

        Task<List<PresentationDTO>> GetPresentationsByIdAsync(int conferenceID);
        Task<PresentationDTO> GetPresentationByIdAsync(int presentationId);
    }
}
