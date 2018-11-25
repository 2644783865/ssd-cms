using CMS.API.DAL.Extensions;
using CMS.API.DAL.Interfaces;
using CMS.BE.DTO;
using System.Collections.Generic;

namespace CMS.API.DAL.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private cmsEntities _db = new cmsEntities();

        public void AddAuthor(AuthorDTO authorDTO)
        {
            var author = MapperExtension.mapper.Map<AuthorDTO, Author>(authorDTO);
            _db.Authors.Add(author);
            _db.SaveChanges();
        }

        public void EditAuthor(AuthorDTO authorDTO)
        {
            var author = MapperExtension.mapper.Map<AuthorDTO, Author>(authorDTO);
            _db.Entry(author).CurrentValues.SetValues(author);
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
