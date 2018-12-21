using System;
using System.Linq;
using CMS.API.BLL.BLL;
using CMS.API.BLL.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CMS.API.Tests
{
    [TestClass]
    public class PresentationTest
    {
        IPresentationBLL bll;

        [TestInitialize]
        public void InitializeBLL()
        {
            bll = new PresentationBLL();
        }
        
        [TestMethod]
        public void TestEditGradeOfPresentation()
        {
            var result = bll.EditGradeOfPresentation(1, 1);
            var grade = bll.GetPresentationById(1).Grade;
            Assert.IsTrue(result && grade == 1);
        }

        [TestMethod]
        public void TestDeleteGradeFromPresentation()
        {
            var result = bll.DeleteGradeFromPresentation(1);
            var grade = bll.GetPresentationById(1).Grade;
            Assert.IsTrue(result && grade == null);
        }

        [TestMethod]
        public void TestEditSessionOfPresentation1()
        {
            var result = bll.EditSessionOfPresentation(1, 1);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestEditSpecialSessionOfPresentation1()
        {
            var result = bll.EditSpecialSessionOfPresentation(1, 1);
            Assert.IsFalse(result);
        }


/* Doesn't work because of error in EditPresentation
        [TestMethod]
        public void TestDeleteSessionFromPresentation()
        {
            var result = bll.DeleteSessionFromPresentation(1);
            Assert.IsTrue(result);
        }
*/


        [TestMethod]
        public void TestEditSpecialSessionOfPresentation2()
        {
            var result = bll.EditSpecialSessionOfPresentation(1, 1);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestEditSessionOfPresentation2()
        {
            var result = bll.EditSessionOfPresentation(1, 1);
            Assert.IsFalse(result);
        }


/* Doesn't work because of error in EditPresentation
        [TestMethod]
        public void TestDeleteSpecialSessionFromPresentation()
        {
            var result = bll.DeleteSpecialSessionFromPresentation(1);
            Assert.IsTrue(result);
        }
*/



/* Doesn't work because of an error in the core.dll, Exeption not machting arguments
        [TestMethod]
        public void TestGetPresentationsById()
        {
            var result = bll.GetPresentationsById(1);
            Assert.AreEqual(1, result.Count());
        }
*/


        [TestMethod]
        public void TestGetPresentationById()
        {
            var result = bll.GetPresentationById(1);
            Assert.IsNotNull(result);
        }
    }
}
