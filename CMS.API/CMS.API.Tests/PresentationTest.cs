using System;
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
    }
}
