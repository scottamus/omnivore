using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OmnivoreClassLibrary;
using System.Threading.Tasks;
using System.Collections.Generic;
using OmnivoreClassLibrary.DataContracts.V01;
using OmnivoreClassLibrary.DataContracts.V01.Enums;

namespace OmnivoreClassLibraryTests
{
    [TestClass]
    public class TestConnectionTest
    {
        [TestMethod]
        public async Task TestGetLocation_Async()
        {
            Location output = await TestConnection.TestGetLocation_Async();
            Assert.IsNotNull(output);
            Assert.IsFalse(String.IsNullOrEmpty(output.Id));
            Assert.IsTrue(output.Id == "zGibgKT9");
            Assert.IsFalse(String.IsNullOrEmpty(output.Name));
            Assert.IsTrue(output.Name == "Virtual POS");
            Assert.IsFalse(String.IsNullOrEmpty(output.DisplayName));
            Assert.IsTrue(output.DisplayName == "Virtual POS");
        }

        [TestMethod]
        public async Task TestGetInterface_Async()
        {
            MainInterface output = await TestConnection.TestGetMainInterface_Async();

            Assert.IsNotNull(output);
            Assert.IsNotNull(output.Versions);
            Assert.IsTrue(output.Versions.Count == 1);
            Assert.IsTrue(output.Versions[0].MinorVersion == 1);
        }

        [TestMethod]
        public async Task TestGetLocationsCollection_Async()
        {
            List<Location> output = await TestConnection.TestGetLocationsCollection_Async();
            Assert.IsNotNull(output);
            Assert.IsTrue(output.Count > 0);
        }

        [TestMethod]
        public async Task TestGetMenu_Async()
        {
            Menu output = await TestConnection.TestGetMenu_Async();
            Assert.IsNotNull(output);
            Assert.IsNotNull(output.Links);
            Assert.IsTrue(output.Links.Count == 4);
        }

        [TestMethod]
        public async Task TestGetMenuWithCategoriesAndItems_Async()
        {
            Menu output = await TestConnection.TestGetMenuWithCategoriesAndItems_Async();
            Assert.IsNotNull(output);
            Assert.IsNotNull(output.Links);
            Assert.IsNotNull(output.Categories);
            Assert.IsTrue(output.Categories.Count == 3);
        }

        [TestMethod]
        public async Task TestGetMenuItemModifiers_Async()
        {
            List<ModifierGroup> output = await TestConnection.TestGetMenuItemModifiers_Async();
            Assert.IsNotNull(output);
            Assert.IsTrue(output.Count == 2);
        }
    }
}
