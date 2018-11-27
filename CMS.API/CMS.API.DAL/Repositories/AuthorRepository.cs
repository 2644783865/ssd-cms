using CMS.API.DAL.Extensions;
using CMS.API.DAL.Interfaces;
using CMS.BE.DTO;
using System.Collections.Generic;

namespace CMS.API.DAL.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private cmsEntities _db = new cmsEntities();

        public IEnumerable<AuthorDTO> GetAuthors()
        {
            return _db.Authors.Project().To<AuthorDTO>();
        }

        public AuthorDTO GetAuthorById(int authorId)
        {
            var author = _db.Authors.Find(authorId);
            if (author == null) return null;
            else return MapperExtension.mapper.Map<Author, AuthorDTO>(author);
        }

        public void AddAuthor(AuthorDTO authorDTO)
        {
            var author = MapperExtension.mapper.Map<AuthorDTO, Author>(authorDTO);
            _db.Authors.Add(author);
            _db.SaveChanges();
        }

        public void EditAuthor(AuthorDTO authorDTO)
        {
            var author = MapperExtension.mapper.Map<AuthorDTO, Author>(authorDTO);
            _db.Entry(_db.Authors.Find(authorDTO.AuthorID)).CurrentValues.SetValues(author);
            _db.SaveChanges();
        }

        public void DeleteAuthor(int authorId)
        {
            var author = _db.Authors.Find(authorId);
            _db.Authors.Remove(author);
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }

    }
}
