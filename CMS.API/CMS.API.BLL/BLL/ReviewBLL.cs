﻿using CMS.API.BLL.Interfaces;
using CMS.API.DAL.Interfaces;
using CMS.API.DAL.Repositories;
using CMS.BE.DTO;
using System.Collections.Generic;

namespace CMS.API.BLL.BLL
{
    public class ReviewBLL : IReviewBLL
    {
        private IReviewRepository _repository = new ReviewRepository();

        public IEnumerable<ReviewDTO> GetReviewInfo(int conferenceId)
        {
            try
            {
                return _repository.GetReviewInfo(conferenceId);
            }
            catch
            {
                return null;
            }
        }

        public ReviewDTO GetReviewById(int id)
        {
            try
            {
                var review = _repository.GetReviewById(id);
                if (review == null) return null;
                return review;
            }
            catch
            {
                return null;
            }
        }

        public bool AddReview(ReviewDTO review)
        {
            try
            {
                _repository.AddReview(review);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool EditReview(ReviewDTO review)
        {
            try
            {
                _repository.EditReview(review);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool DeleteReview(int reviewId)
        {
            try
            {
                _repository.DeleteReview(reviewId);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public IEnumerable<ReviewDTO> GetReviewsByArticleId(int articleId)
        {
            try
            {
                return _repository.GetReviewsByArticleId(articleId);
            }
            catch
            {
                return null;
            }
        }
    }
}
