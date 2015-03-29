using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OmnivoreClassLibrary;
using System.Threading.Tasks;

namespace OmnivoreClassLibraryTests
{
    [TestClass]
    public class TestConnectionTest
    {
        [TestMethod]
        public async Task TestGetLocation_Async()
        {
            await TestConnection.TestGetLocation_Async();
        }

        [TestMethod]
        public async Task TestGetInterface_Async()
        {
            await TestConnection.TestGetInterface_Async();
        }

    }
}
