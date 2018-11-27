using CMS.BE.DTO;
using System.Collections.Generic;

namespace CMS.API.BLL.Interfaces
{
    public interface ISubmissionBLL
    {
        IEnumerable<SubmissionDTO> GetSubmissions();
        SubmissionDTO GetSubmissionById(int id);
        bool AddSubmission(SubmissionDTO submission);
        bool EditSubmission(SubmissionDTO submission);
        bool DeleteSubmission(int submissionId);
    }
}

