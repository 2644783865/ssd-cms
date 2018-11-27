using CMS.API.BLL.Interfaces;
using CMS.API.DAL.Interfaces;
using CMS.API.DAL.Repositories;
using CMS.BE.DTO;

namespace CMS.API.BLL.BLL
{
    public class PresentationBLL : IPresentationBLL
    {
        private IPresentationRepository _repository = new PresentationRepository();

        public bool AddPresentation(PresentationDTO presentation)
        {
            try
            {
                _repository.AddPresentation(presentation);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool DeletePresentation(int presentationId)
        {
            try
            {
                _repository.DeletePresentation(presentationId);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool EditPresentation(PresentationDTO presentation)
        {
            try
            {
                _repository.EditPresentation(presentation);
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
