using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OmnivoreClassLibrary;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
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
            Assert.IsNotNull(output.Links);
            Assert.IsTrue(output.Links.Count == 9);
        }

        [TestMethod]
        public async Task TestGetInterface_Async()
        {
            MainInterface output = await TestConnection.TestGetMainInterface_Async();
            Assert.IsNotNull(output);
            Assert.IsNotNull(output.Versions);
            Assert.IsTrue(output.Versions.Count == 1);
            Assert.IsTrue(output.Versions[0].MinorVersion == 1);
            Assert.IsNotNull(output.Links);
            Assert.IsTrue(output.Links.Count == 1);
        }

        [TestMethod]
        public async Task TestGetLocationCollection_Async()
        {
            LocationCollection output = await TestConnection.TestGetLocationCollection_Async();
            Assert.IsNotNull(output);
            Assert.IsTrue(output.Count > 0);
            Assert.IsNotNull(output.Locations);
            Assert.IsTrue(output.Locations.Count == 1);
            Location l = (Location)output.Locations.First().Value[0];
            Assert.IsTrue(l.Links.Count == 9);
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
        public async Task TestGetMenuCategoriesAndItems_Async()
        {
            CategoryCollection output = await TestConnection.TestGetMenuCategoriesAndItems_Async();
            Assert.IsNotNull(output);
            Assert.IsTrue(output.Count == 3);
            Assert.IsNotNull(output.Links);
            Assert.IsTrue(output.Links.Count == 1);
            Assert.IsNotNull(output.Categories);
            Assert.IsTrue(output.Categories.Count == 1);
            Category c = (Category)output.Categories.First().Value[0];
            Assert.IsNotNull(c);
            Assert.IsTrue(c.Name == "Drinks");
            Assert.IsNotNull(c.Links);
            Assert.IsTrue(c.Links.Count == 2);
            Assert.IsNotNull(c.MenuItems);
            Assert.IsTrue(c.MenuItems.Count == 1);
            List<MenuItem> menuItems = (List<MenuItem>)c.MenuItems.First().Value;
            Assert.IsNotNull(menuItems);
            Assert.IsTrue(menuItems.Count == 2);
            MenuItem mi = menuItems[0];
            Assert.IsNotNull(mi);
            Assert.IsTrue(mi.Name == "Orange Juice");

        }

        [TestMethod]
        public async Task TestGetMenuItemModifierGroupCollection_Async()
        {
            ModifierGroupCollection output = await TestConnection.TestGetMenuItemModifierGroupCollection_Async();
            Assert.IsNotNull(output);
            Assert.IsTrue(output.Count == 2);
            Assert.IsNotNull(output.Links);
            Assert.IsTrue(output.Links.Count == 1);
            Assert.IsNotNull(output.ModifierGroups);
            Assert.IsTrue(output.ModifierGroups.Count == 1);
            ModifierGroup mg = (ModifierGroup)output.ModifierGroups.First().Value[0];
            Assert.IsNotNull(mg);
            Assert.IsTrue(mg.Name == "Temperature");
            Assert.IsNotNull(mg.Links);
            Assert.IsTrue(mg.Links.Count == 2);
            Assert.IsNotNull(mg.Modifiers);
            Assert.IsTrue(mg.Modifiers.Count == 1);
            List<Modifier> mods = (List<Modifier>)mg.Modifiers.First().Value;
            Assert.IsNotNull(mods);
            Assert.IsTrue(mods.Count == 5);
            Modifier m = mods[0];
            Assert.IsNotNull(m);
            Assert.IsTrue(m.Name == "Perfect");
        }

        [TestMethod]
        public async Task TestGetTableCollection_Async()
        {
            TableCollection output = await TestConnection.TestGetTableCollection_Async();
            Assert.IsNotNull(output);
            Assert.IsNotNull(output.Links);
            Assert.IsTrue(output.Links.Count == 1);
        }
    }
}
