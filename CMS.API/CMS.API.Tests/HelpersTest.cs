using CMS.API.BLL.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CMS.API.Tests
{
    [TestClass]
    public class HelpersTest
    {
        [TestMethod]
        public void TestComputeHash()
        {
            Assert.AreEqual("e4bb9f1ece9af9264a3b9e3913bbdb2cf497457167b14ced5f85688bfde74644", HashHelper.ComputeHash("Start"));
        }
    }
}
