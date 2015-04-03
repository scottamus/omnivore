using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OmnivoreClassLibrary;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace OmnivoreClassLibraryTests
{
    [TestClass]
    public class TestNewWay
    {
        [TestMethod]
        public async Task TestGettingRootAndLinks()
        {
            APINavigator nav = new APINavigator();
            dynamic foo = await nav.GetRoot();

        }
    }
}
