using CMS.API.BLL.Interfaces;
using CMS.API.DAL.Interfaces;
using CMS.API.DAL.Repositories;
using CMS.BE.DTO;
using System.Collections.Generic;

namespace CMS.API.BLL.BLL
{
    public class AuthorBLL : IAuthorBLL
    {
        private IAuthorRepository _repository = new AuthorRepository();

        public IEnumerable<AuthorDTO> GetAuthors()
        {
            try
            {
                return _repository.GetAuthors();
            }
            catch
            {
                return null;
            }
        }

        public AuthorDTO GetAuthorById(int id)
        {
            try
            {
                var author = _repository.GetAuthorById(id);
                if (author == null) return null;
                return author;
            }
            catch
            {
                return null;
            }
        }

        public bool AddAuthor(AuthorDTO author)
        {
            try
            {
                _repository.AddAuthor(author);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool EditAuthor(AuthorDTO author)
        {
            try
            {
                _repository.EditAuthor(author);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool DeleteAuthor(int authorId)
        {
            try
            {
                _repository.DeleteAuthor(authorId);
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
