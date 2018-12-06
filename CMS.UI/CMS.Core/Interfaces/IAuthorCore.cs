using CMS.BE.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.Core.Interfaces
{
    public interface IAuthorCore : IDisposable
    {
        Task<List<AuthorDTO>> GetAuthorsAsync();
        Task<AuthorDTO> GetAuthorByAccountIdAsync(int accountId);
        Task<AuthorDTO> GetAuthorByIdAsync(int authorId);
        Task<bool> AddAuthorAsync(AuthorDTO author);
        Task<bool> EditAuthorAsync(AuthorDTO author);
        Task<bool> DeleteAuthorAsync(int authorId);
    }
}
