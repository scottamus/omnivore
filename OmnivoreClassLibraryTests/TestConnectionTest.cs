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
            List<Location> locGroups = (List<Location>)output.Locations.First().Value;
            Assert.IsNotNull(locGroups);
            Assert.IsTrue(locGroups.Count == 1);
            Location loc = locGroups.First();
            Assert.IsTrue(loc.Links.Count == 9);
            Assert.IsTrue(loc.Name == "Virtual POS");
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
            List<Category> catGroups = (List<Category>)output.Categories.First().Value;
            Assert.IsNotNull(catGroups);
            Assert.IsTrue(catGroups.Count == 3);
            Category c = catGroups.First();
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
            MenuItemModifierGroupCollection output = await TestConnection.TestGetMenuItemModifierGroupCollection_Async();
            Assert.IsNotNull(output);
            Assert.IsTrue(output.Count == 2);
            Assert.IsNotNull(output.Links);
            Assert.IsTrue(output.Links.Count == 1);
            Assert.IsNotNull(output.ModifierGroups);
            Assert.IsTrue(output.ModifierGroups.Count == 1);
            List<MenuItemModifierGroup> modGroups = (List<MenuItemModifierGroup>)output.ModifierGroups.First().Value;
            Assert.IsNotNull(modGroups);
            Assert.IsTrue(modGroups.Count == 2);
            MenuItemModifierGroup mg = modGroups.First();
            Assert.IsNotNull(mg);
            Assert.IsTrue(mg.Name == "Temperature");
            Assert.IsNotNull(mg.Links);
            Assert.IsTrue(mg.Links.Count == 2);
            Assert.IsNotNull(mg.Modifiers);
            Assert.IsTrue(mg.Modifiers.Count == 1);
            List<MenuItemModifier> mods = (List<MenuItemModifier>)mg.Modifiers.First().Value;
            Assert.IsNotNull(mods);
            Assert.IsTrue(mods.Count == 5);
            MenuItemModifier m = mods[0];
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
            Assert.IsNotNull(output.Tables);
            Assert.IsTrue(output.Tables.Count == 1);
            List<Table> tables = (List<Table>)output.Tables.First().Value;
            Assert.IsNotNull(tables);
            Assert.IsTrue(tables.Count == 14);
            Table tab = tables.First();
            Assert.IsNotNull(tab);
            Assert.IsTrue(tab.Id == "jLiyniEb");
            Assert.IsTrue(tab.Name == "1");
            Assert.IsTrue(tab.Number == 1);
            Assert.IsTrue(tab.Seats == 4);
        }

        [TestMethod]
        [Ignore] // only run on a fresh, reset POS!!
        public async Task TestGetRevenueCenterCollection_Async()
        {
            RevenueCenterCollection output = await TestConnection.TestGetRevenueCenterCollection_Async();
            Assert.IsNotNull(output);
            Assert.IsNotNull(output.Links);
            Assert.IsTrue(output.Links.Count == 1);
            Assert.IsNotNull(output.RevenueCenters);
            Assert.IsTrue(output.RevenueCenters.Count == 1);
            RevenueCenter rc = (RevenueCenter)output.RevenueCenters.First().Value[0];
            Assert.IsNotNull(rc);
            Assert.IsTrue(rc.Name == "Dining");
            Assert.IsTrue(rc.Id == "LdiqGibo");
            Assert.IsNotNull(rc.EmbeddedTablesAndTickets);
            Assert.IsNotNull(rc.EmbeddedTablesAndTickets.open_tickets);
            Assert.IsTrue(rc.EmbeddedTablesAndTickets.open_tickets.Count == 1);
            Ticket t = rc.EmbeddedTablesAndTickets.open_tickets[0];
            Assert.IsNotNull(t);
            Assert.IsNotNull(t.Links);
            Assert.IsTrue(t.Links.Count == 6);
            Assert.IsTrue(t.Name == "Your First Ticket!");
            Assert.IsNotNull(t.Totals);
            Assert.IsTrue(t.Totals.Due == (decimal)10.09);
            Assert.IsNotNull(t.EmbeddedTicketItems);
            Assert.IsNotNull(t.EmbeddedTicketItems.employee);
            Assert.IsTrue(t.EmbeddedTicketItems.employee.Id == "MjikgioG");
            Assert.IsNotNull(t.EmbeddedTicketItems.items);
            Assert.IsTrue(t.EmbeddedTicketItems.items.Count == 2);
            TicketItem ti = t.EmbeddedTicketItems.items.Find(c => c.Id == "4Tx5xgij"); // new baconings
            Assert.IsNotNull(ti);
            Assert.IsTrue(ti.Name == "New Bacon-ings");
            Assert.IsNotNull(ti.EmbeddedTicketItemSubclasses);
            Assert.IsNotNull(ti.EmbeddedTicketItemSubclasses.menu_item);
            MenuItem mi = ti.EmbeddedTicketItemSubclasses.menu_item;
            Assert.IsTrue(mi.Id == "rMTAbTjr");
            Assert.IsNotNull(ti.EmbeddedTicketItemSubclasses.modifiers);
            Assert.IsTrue(ti.EmbeddedTicketItemSubclasses.modifiers.Count == 2);
            TicketItemModifier tim = ti.EmbeddedTicketItemSubclasses.modifiers.Find(c => c.Id == "dEcgdyiG"); // tomato
            Assert.IsNotNull(tim);
            Assert.IsTrue(tim.Name == "Tomato");
            Assert.IsNotNull(tim.EmbeddedMenuItemModifier);
            Assert.IsNotNull(tim.EmbeddedMenuItemModifier.menu_modifier);
            MenuItemModifier mim = tim.EmbeddedMenuItemModifier.menu_modifier;
            Assert.IsNotNull(mim);
            Assert.IsTrue(mim.Id == "E5cpac84");
            Assert.IsNotNull(mim.PriceLevels);
            Assert.IsTrue(mim.PriceLevels.Count == 1);
            PriceLevel pl = mim.PriceLevels[0];
            Assert.IsNotNull(pl);
            Assert.IsTrue(pl.Id == "Rzi98iRR");
            Assert.IsNotNull(t.EmbeddedTicketItems.order_type);
            OrderType ot = t.EmbeddedTicketItems.order_type;
            Assert.IsTrue(ot.Id == "KxiAaip5");
            Assert.IsNotNull(t.EmbeddedTicketItems.revenue_center);
            RevenueCenter revCenter = t.EmbeddedTicketItems.revenue_center;
            Assert.IsTrue(revCenter.Id == "LdiqGibo");
            Assert.IsNotNull(t.EmbeddedTicketItems.table);
            Table ticketTable = t.EmbeddedTicketItems.table;
            Assert.IsTrue(ticketTable.Id == "jLiyniEb");
            Assert.IsNotNull(rc.EmbeddedTablesAndTickets.tables);
            Assert.IsTrue(rc.EmbeddedTablesAndTickets.tables.Count == 10);
            Table tab = rc.EmbeddedTablesAndTickets.tables[0];
            Assert.IsNotNull(tab);
            Assert.IsNotNull(tab.Links);
            Assert.IsTrue(tab.Links.Count == 1);
            Assert.IsTrue(tab.Name == "1");
            Assert.IsTrue(tab.Number == 1);
            Assert.IsTrue(tab.Seats == 4);
        }

        [TestMethod]
        public async Task TestGetOrderTypeCollection_Async()
        {
            OrderTypeCollection output = await TestConnection.TestGetOrderTypeCollection_Async();
            Assert.IsNotNull(output);
            Assert.IsNotNull(output.Links);
            Assert.IsTrue(output.Links.Count == 1);
            Assert.IsNotNull(output.OrderTypes);
            Assert.IsTrue(output.OrderTypes.Count == 1);
            List<OrderType> orderTypes = (List<OrderType>)output.OrderTypes.First().Value;
            Assert.IsNotNull(orderTypes);
            Assert.IsTrue(orderTypes.Count == 2);
            OrderType ot = orderTypes.First();
            Assert.IsNotNull(ot);
            Assert.IsTrue(ot.Name == "Eat In");
            Assert.IsTrue(ot.Id == "KxiAaip5");
        }

        [TestMethod]
        public async Task TestGetEmployeeCollection_Async()
        {
            EmployeeCollection output = await TestConnection.TestGetEmployeeCollection_Async();
            Assert.IsNotNull(output);
            Assert.IsNotNull(output.Links);
            Assert.IsTrue(output.Links.Count == 1);
            Assert.IsNotNull(output.Employees);
            Assert.IsTrue(output.Employees.Count == 1);
            List<Employee> emps = (List<Employee>)output.Employees.First().Value;
            Assert.IsNotNull(emps);
            Assert.IsTrue(emps.Count == 5);
            Employee emp = emps.First();
            Assert.IsNotNull(emp);
            Assert.IsTrue(emp.Id == "MjikgioG");
            Assert.IsTrue(emp.LastName == "Belcher");
        }

        [TestMethod]
        [Ignore] // don't want to open a new ticket every time I run all tests!
        public async Task TestOpenTicket_Basic()
        {
            // arrange - TODO: get from POS system, not hardcoded!
            Ticket ticketToCreate = new Ticket();
            ticketToCreate.EmbeddedTicketItems = new EmbeddedTicketItems();
            ticketToCreate.EmbeddedTicketItems.employee = new Employee() { Id = "BdTaKT4X" };
            ticketToCreate.EmbeddedTicketItems.order_type = new OrderType() { Id = "KxiAaip5" };
            ticketToCreate.EmbeddedTicketItems.revenue_center = new RevenueCenter() { Id = "LdiqGibo" };
            ticketToCreate.EmbeddedTicketItems.table = new Table() { Id = "x4TdoTd8" };
            ticketToCreate.GuestCount = 2;
            ticketToCreate.Name = "Scott's First Ticket!";
            ticketToCreate.AutoSend = true;

            // act
            Ticket output = await TestConnection.TestOpenTicket_Basic(ticketToCreate);

            // assert
            Assert.IsNotNull(output);
        }

        [TestMethod]
        public async Task TestGetTicketIOpened()
        {
            Ticket output = await TestConnection.TestGetTicket("qTRXjxio");
            Assert.IsNotNull(output);
            Assert.IsTrue(output.Name == "Scott's First Ticket!");
        }
    }
}
