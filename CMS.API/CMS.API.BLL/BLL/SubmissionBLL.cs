using CMS.API.BLL.Interfaces;
using CMS.API.DAL.Interfaces;
using CMS.API.DAL.Repositories;
using CMS.BE.DTO;
using System.Collections.Generic;

namespace CMS.API.BLL.BLL
{
    public class SubmissionBLL : ISubmissionBLL
    {
        private IArticleRepository _repository = new ArticleRepository();

        public IEnumerable<SubmissionDTO> GetSubmissions()
        {
            try
            {
                return _repository.GetSubmissions();
            }
            catch
            {
                return null;
            }
        }

        public SubmissionDTO GetSubmissionById(int id)
        {
            try
            {
                var submission = _repository.GetSubmissionById(id);
                if (submission == null) return null;
                return submission;
            }
            catch
            {
                return null;
            }
        }

        public bool AddSubmission(SubmissionDTO submission)
        {
            try
            {
                _repository.AddSubmission(submission);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool EditSubmission(SubmissionDTO submission)
        {
            try
            {
                _repository.EditSubmission(submission);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool DeleteSubmission(int submissionId)
        {
            try
            {
                _repository.DeleteSubmission(submissionId);
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
