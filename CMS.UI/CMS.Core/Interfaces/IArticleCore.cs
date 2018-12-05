﻿using CMS.BE.DTO;
using CMS.BE.Models.Article;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.Core.Interfaces
{
    public interface IArticleCore : IDisposable
    {
        Task<List<ArticleDTO>> GetArticlesAsync();
        Task<ArticleDTO> GetArticleByIdAsync(int articleId);
        Task<bool> AddArticleAsync(AddArticleModel articleModel);
        Task<bool> EditArticleAsync(ArticleDTO article);
        Task<bool> DeleteArticleAsync(int articleId);

        Task<List<SubmissionDTO>> GetSubmissionsAsync();
        Task<SubmissionDTO> GetSubmissionByIdAsync(int submissionId);
        Task<bool> AddSubmissionAsync(SubmissionDTO submission);
        Task<bool> EditSubmissionAsync(SubmissionDTO submission);
        Task<bool> DeleteSubmissionAsync(int submissionId);
    }
}
