using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OmnivoreClassLibrary;
using System.Threading.Tasks;
using System.Collections.Generic;

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
            Assert.IsFalse(String.IsNullOrEmpty(output.id));
            Assert.IsTrue(output.id == "zGibgKT9");
            Assert.IsFalse(String.IsNullOrEmpty(output.name));
            Assert.IsTrue(output.name == "Virtual POS");
            Assert.IsFalse(String.IsNullOrEmpty(output.display_name));
            Assert.IsTrue(output.display_name == "Virtual POS");
        }

        [TestMethod]
        public async Task TestGetInterface_Async()
        {
            Interface output = await TestConnection.TestGetInterface_Async();

            Assert.IsNotNull(output);
            Assert.IsNotNull(output.versions);
            Assert.IsTrue(output.versions.Count == 1);
            Assert.IsTrue(output.versions[0].minor == 1);
        }

        [TestMethod]
        public async Task TestGetLocationsCollection_Async()
        {
            List<Location> output = await TestConnection.TestGetLocationsCollection_Async();
            Assert.IsNotNull(output);
            Assert.IsTrue(output.Count > 0);
        }

        //[TestMethod]
        //public async Task TestGetMenuLinks_Async()
        //{
        //    MenuLinks output = await TestConnection.TestGetMenuLinks_Async();
        //    Assert.IsNotNull(output);
        //    Assert.IsNotNull(output._links);
        //    //Assert.IsNotNull(output._links.categories);
        //    //Assert.IsNotNull(output._links.items);
        //    //Assert.IsNotNull(output._links.modifiers);
        //}

        //[TestMethod]
        //public async Task TestGetMenuItemsCollection_Async()
        //{
        //    MenuItemsCollection output = await TestConnection.TestGetMenuItemsCollection_Async();
        //    Assert.IsNotNull(output);
        //    Assert.IsNotNull(output._embedded);
        //    Assert.IsNotNull(output._embedded.menu_items);
        //    Assert.IsTrue(output._embedded.menu_items.Count > 0);
        //}

        //[TestMethod]
        //public async Task TestGetMenuCategoryCollection_Async()
        //{
        //    MenuCategoryCollection output = await TestConnection.TestGetMenuCategoryCollection_Async();
        //    Assert.IsNotNull(output);
        //    Assert.IsNotNull(output._embedded);
        //    Assert.IsNotNull(output._embedded.categories);
        //    Assert.IsTrue(output._embedded.categories.Count > 0);
        //}

        //[TestMethod]
        //public async Task TestGetMenuModifierCollection_Async()
        //{
        //    ModifierCollection output = await TestConnection.TestGetMenuModifierCollection_Async();
        //    Assert.IsNotNull(output);
        //    Assert.IsNotNull(output._embedded);
        //    Assert.IsNotNull(output._embedded.modifiers);
        //    Assert.IsTrue(output._embedded.modifiers.Count > 0);
        //}
    }
}
