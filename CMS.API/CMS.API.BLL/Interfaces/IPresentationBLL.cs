using CMS.BE.DTO;

namespace CMS.API.BLL.Interfaces
{
    public interface IPresentationBLL
    {
        bool AddPresentation(PresentationDTO presentation);
        bool EditPresentation(PresentationDTO presentation);
        bool DeletePresentation(int presentationId);
    }
}