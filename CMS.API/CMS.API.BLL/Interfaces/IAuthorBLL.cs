using CMS.BE.DTO;
using System.Collections.Generic;

namespace CMS.API.BLL.Interfaces
{
    public interface IAuthorBLL
    {
        IEnumerable<AuthorDTO> GetAuthors();
        AuthorDTO GetAuthorById(int id);
        bool AddAuthor(AuthorDTO author);
        bool EditAuthor(AuthorDTO author);
        bool DeleteAuthor(int authorId);
    }
}
