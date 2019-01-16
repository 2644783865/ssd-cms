using Microsoft.VisualStudio.TestTools.UnitTesting;
using CMS.API.BLL.BLL;
using System.Linq;
using CMS.API.BLL.Interfaces;

namespace CMS.API.Tests
{
    [TestClass]
    public class ArticleTest
    {
        IArticleBLL bll;

        [TestInitialize]
        public void InitializeBLL()
        {
            bll = new ArticleBLL();
        }

        //Article

        [TestMethod]
        public void TestGetArticles()
        {
            var result = bll.GetArticles(1);
            Assert.AreEqual(1, result.FirstOrDefault().ArticleId);
            result = bll.GetArticles(0);
            Assert.AreEqual(null, result.FirstOrDefault());
        }

        [TestMethod]
        public void TestGetArticleById()
        {
            var result = bll.GetArticleById(1);
            Assert.AreEqual(1, result.ArticleId);
            result = bll.GetArticleById(2);
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        public void TestGetArticlesForConferenceAndAuthor()
        {
            var result = bll.GetArticlesForConferenceAndAuthor(1, 1);
            Assert.AreEqual(1, result.FirstOrDefault().ArticleId);
            result = bll.GetArticlesForConferenceAndAuthor(0, 1);
            Assert.AreEqual(null, result.FirstOrDefault());
            result = bll.GetArticlesForConferenceAndAuthor(1, 0);
            Assert.AreEqual(null, result.FirstOrDefault());
            result = bll.GetArticlesForConferenceAndAuthor(0, 0);
            Assert.AreEqual(null, result.FirstOrDefault());
        }

        [TestMethod]
        public void TestGetAuthorsFromArticleId()
        {
            var result = bll.GetAuthorsFromArticleId(1);
            Assert.AreEqual(1, result.FirstOrDefault().AuthorId);
            result = bll.GetAuthorsFromArticleId(2);
            Assert.AreEqual(null, result.FirstOrDefault());
        }

        [TestMethod]
        public void TestGetSubmittedArticles()
        {
            var result = bll.GetSubmittedArticles();
            Assert.AreEqual(4, result.FirstOrDefault().ArticleId);
            Assert.AreEqual("submitted", result.FirstOrDefault().Status);
        }

        [TestMethod]
        public void TestGetRejectedArticles()
        {
            var result = bll.GetRejectedArticles();
            Assert.AreEqual(3, result.FirstOrDefault().ArticleId);
            Assert.AreEqual("rejected", result.FirstOrDefault().Status);
        }

        //Submission

        [TestMethod]
        public void TestGetSubmissions()
        {
            var result = bll.GetSubmissions();
            Assert.AreEqual(1, result.FirstOrDefault().SubmissionId);
        }

        [TestMethod]
        public void TestGetSubmissionById()
        {
            var result = bll.GetSubmissionById(1);
            Assert.AreEqual(1, result.SubmissionId);
            result = bll.GetSubmissionById(2);
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        public void TestGetSubmissionsForArticle()
        {
            var result = bll.GetSubmissionsForArticle(1);
            Assert.AreEqual(1, result.FirstOrDefault().SubmissionId);
            result = bll.GetSubmissionsForArticle(2);
            Assert.AreEqual(null, result.FirstOrDefault());
        }
    }
}
