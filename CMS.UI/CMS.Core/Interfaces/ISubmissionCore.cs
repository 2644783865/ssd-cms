using CMS.BE.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.Core.Interfaces
{
    public interface ISubmissionCore : IDisposable
    {
        Task<List<SubmissionDTO>> GetSubmissionsAsync();
        Task<SubmissionDTO> GetSubmissionByIdAsync(int submissionId);
        Task<bool> AddSubmissionAsync(SubmissionDTO submission);
        Task<bool> EditSubmissionAsync(SubmissionDTO submission);
        Task<bool> DeleteSubmissionAsync(int submissionId);
    }
}
