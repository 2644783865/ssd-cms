using CMS.BE.DTO;

namespace CMS.API.BLL.Interfaces
{
    public interface IPresentationBLL
    {
        bool AddPresentation(PresentationDTO presentation);
        bool EditPresentation(PresentationDTO presentation);
        bool DeletePresentation(int presentationId);
        bool EditGradeOfPresentation(int presentationId, int grade);
        bool DeleteGradeFromPresentation(int presentationId);
        bool EditSessionOfPresentation(int presentationId, int sessionId);
        bool EditSpecialSessionOfPresentation(int presentationId, int specialSessionId);
        bool DeleteSessionFromPresentation(int presentationId);
        bool DeleteSpecialSessionFromPresentation(int presentationId);
        bool GetPresentationsById(int conferenceId);
    }
}