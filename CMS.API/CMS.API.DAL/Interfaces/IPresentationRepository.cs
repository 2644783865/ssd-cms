using CMS.BE.DTO;
using System;
using System.Collections.Generic;

namespace CMS.API.DAL.Interfaces
{
    public interface IPresentationRepository : IDisposable
    {
        IEnumerable<PresentationDTO> GetPresentations();
        PresentationDTO GetPresentationById(int presentationId);
        IEnumerable<PresentationDTO> GetPresentationsById(int conferenceId);
        void AddPresentation(PresentationDTO presentationDTO);
        void EditPresentation(PresentationDTO presentationDTO);
        void DeletePresentation(int presentationId);
        decimal GetLastPresentationId();
    }
}
