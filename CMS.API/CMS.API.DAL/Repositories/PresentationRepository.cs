using CMS.API.DAL.Extensions;
using CMS.API.DAL.Interfaces;
using CMS.BE.DTO;
using System.Collections.Generic;
using System.Linq;

namespace CMS.API.DAL.Repositories
{
    public class PresentationRepository : IPresentationRepository
    {
        private cmsEntities _db = new cmsEntities();
        private ISessionRepository _repository = new SessionRepository();

        public IEnumerable<PresentationDTO> GetPresentations()
        {
            return _db.Presentations.Project().To<PresentationDTO>();
        }

        public PresentationDTO GetPresentationById(int presentationId)
        {
            var presentation = _db.Presentations.Find(presentationId);
            if (presentation == null) return null;
            else return MapperExtension.mapper.Map<Presentation, PresentationDTO>(presentation);
        }

        public IEnumerable<PresentationDTO> GetPresentationsById(int conferenceId)
        {
            return _db.Presentations.Where(p => p.Article.ConferenceID == conferenceId).Project().To<PresentationDTO>();
        }

        public void AddPresentation(PresentationDTO presentationDTO)
        {
            var presentation = MapperExtension.mapper.Map<PresentationDTO, Presentation>(presentationDTO);
            _db.Presentations.Add(presentation);
            _db.SaveChanges();
        }

        public void EditPresentation(PresentationDTO presentationDTO)
        {
            var presentation = MapperExtension.mapper.Map<PresentationDTO, Presentation>(presentationDTO);
            _db.Entry(_db.Presentations.Find(presentationDTO.PresentationId)).CurrentValues.SetValues(presentation);
            _db.SaveChanges();
        }

        public void DeletePresentation(int presentationId)
        {
            var presentation = _db.Presentations.Find(presentationId);
            _db.Presentations.Remove(presentation);
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void EditGradeOfPresentation(int presentationId, int grade)
        {
            var presentation = _db.Presentations.Find(presentationId);
            presentation.Grade = grade;
            _db.Entry(_db.Presentations.Find(presentationId)).CurrentValues.SetValues(presentation);
            _db.SaveChanges();
        }

        public void DeleteGradeFromPresentation(int presentationId)
        {
            var presentation = _db.Presentations.Find(presentationId);
            presentation.Grade = null;
            _db.Entry(_db.Presentations.Find(presentationId)).CurrentValues.SetValues(presentation);
            _db.SaveChanges();
        }
    }
}
