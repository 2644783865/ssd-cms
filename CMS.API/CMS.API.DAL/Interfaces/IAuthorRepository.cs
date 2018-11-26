using CMS.BE.DTO;
using System;
using System.Collections.Generic;

namespace CMS.API.DAL.Interfaces
{
    public interface IAuthorRepository : IDisposable
    {
        IEnumerable<AuthorDTO> GetAuthors();
        AuthorDTO GetAuthorById(int id);
        void AddAuthor(AuthorDTO authorDTO);
        void EditAuthor(AuthorDTO authorDTO);
        void DeleteAuthor(int authorId);
    }
}
