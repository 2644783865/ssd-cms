using CMS.API.BLL.Interfaces;
using CMS.API.DAL.Interfaces;
using CMS.API.DAL.Repositories;
using CMS.BE.DTO;
using System;

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

        public bool EditGradeOfPresentation(int presentationId, int grade)
        {
            try
            {
                var presentation = _repository.GetPresentationById(presentationId);
                presentation.Grade = grade;
                _repository.EditPresentation(presentation);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool DeleteGradeFromPresentation(int presentationId)
        {
            try
            {
                var presentation = _repository.GetPresentationById(presentationId);
                presentation.Grade = null;
                _repository.EditPresentation(presentation);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool EditSessionOfPresentation(int presentationId, int sessionId)
        {
            try
            {
                var presentation = _repository.GetPresentationById(presentationId);
                if(presentation.SpecialSessionId == null)
                {
                    presentation.SessionId = sessionId;
                }
                else
                {
                    throw new Exception("There is already a Special Session existing!");
                }
                _repository.EditPresentation(presentation);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool EditSpecialSessionOfPresentation(int presentationId, int specialSessionId)
        {
            try
            {
                var presentation = _repository.GetPresentationById(presentationId);
                if(presentation.SessionId == null)
                {
                    presentation.SpecialSessionId = specialSessionId;
                }
                else
                {
                    throw new Exception("There is already a Session existing!");
                }
                _repository.EditPresentation(presentation);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool DeleteSessionFromPresentation(int presentationId)
        {
            try
            {
                var presentation = _repository.GetPresentationById(presentationId);
                presentation.SessionId = null;
                _repository.EditPresentation(presentation);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool DeleteSpecialSessionFromPresentation(int presentationId)
        {
            try
            {
                var presentation = _repository.GetPresentationById(presentationId);
                presentation.SpecialSessionId = null;
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
