using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OmnivoreClassLibrary;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using OmnivoreClassLibrary.DataContracts.V01;
using OmnivoreClassLibrary.DataContracts.V01.Enums;
using OmnivoreClassLibrary.BusinessDomain;
using OmnivoreClassLibrary.DataAccess;
using Moq;

namespace OmnivoreClassLibraryTests
{
    [TestClass]
    public class OmnivoreManagerTests
    {
        private bool RunInIntegrationMode = false; // set to true to run against the real API to test connectivity, etc. - but ONLY on a fresh POS!
        // also, will need to IGNORE the POST tests if you turn on integration mode and do not update the ids.

        [TestMethod]
        public async Task TestGetLocation_Async()
        {
            OmnivoreManager mgr = null;

            if (RunInIntegrationMode)
            {
                mgr = new OmnivoreManager(); // default, which uses the real repository
            }
            else
            {
                // set up mocking so we don't hit the real API
                Mock<OmnivoreRepository> mockRepo = new Mock<OmnivoreRepository>();
                mockRepo.Setup(m => m.GetOmnivoreObject<Location>(It.IsAny<string>()))
                    .Returns(Task.FromResult<Location>(Helpers.DeserializeJSONString<Location>(JSONStrings.DefaultLocation)));
                OmnivoreDataManager dataMgr = new OmnivoreDataManager(mockRepo.Object);
                mgr = new OmnivoreManager(dataMgr);
            }

            // make the call
            Location output = await mgr.GetLocation_Async(URLBuilder.DefaultLocationUrl);

            // assert that it worked
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
            OmnivoreManager mgr = null;

            if (RunInIntegrationMode)
            {
                mgr = new OmnivoreManager(); // default, which uses the real repository
            }
            else
            {
                // set up mocking so we don't hit the real API
                Mock<OmnivoreRepository> mockRepo = new Mock<OmnivoreRepository>();
                mockRepo.Setup(m => m.GetOmnivoreObject<MainInterface>(It.IsAny<string>()))
                    .Returns(Task.FromResult<MainInterface>(Helpers.DeserializeJSONString<MainInterface>(JSONStrings.Base)));
                OmnivoreDataManager dataMgr = new OmnivoreDataManager(mockRepo.Object);
                mgr = new OmnivoreManager(dataMgr);
            }

            // make the call
            MainInterface output = await mgr.GetMainInterface_Async(URLBuilder.BaseUrl);

            // assert that it worked
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
            OmnivoreManager mgr = null;

            if (RunInIntegrationMode)
            {
                mgr = new OmnivoreManager(); // default, which uses the real repository
            }
            else
            {
                // set up mocking so we don't hit the real API
                Mock<OmnivoreRepository> mockRepo = new Mock<OmnivoreRepository>();
                mockRepo.Setup(m => m.GetOmnivoreObject<OmnivoreCollection<Location>>(It.IsAny<string>()))
                    .Returns(Task.FromResult<OmnivoreCollection<Location>>(Helpers.DeserializeJSONString<OmnivoreCollection<Location>>(JSONStrings.Locations)));
                OmnivoreDataManager dataMgr = new OmnivoreDataManager(mockRepo.Object);
                mgr = new OmnivoreManager(dataMgr);
            }

            // make the call
            OmnivoreCollection<Location> output = await mgr.GetLocationCollection_Async(URLBuilder.LocationsUrl);

            // assert that it worked
            Assert.IsNotNull(output);
            Assert.IsTrue(output.Count > 0);
            Assert.IsNotNull(output.Items);
            Assert.IsTrue(output.Items.Count == 1);
            List<Location> locGroups = (List<Location>)output.Items.First().Value;
            Assert.IsNotNull(locGroups);
            Assert.IsTrue(locGroups.Count == 1);
            Location loc = locGroups.First();
            Assert.IsTrue(loc.Links.Count == 9);
            Assert.IsTrue(loc.Name == "Virtual POS");
        }

        [TestMethod]
        public async Task TestGetMenu_Async()
        {
            OmnivoreManager mgr = null;

            if (RunInIntegrationMode)
            {
                mgr = new OmnivoreManager(); // default, which uses the real repository
            }
            else
            {
                // set up mocking so we don't hit the real API
                Mock<OmnivoreRepository> mockRepo = new Mock<OmnivoreRepository>();
                mockRepo.Setup(m => m.GetOmnivoreObject<Menu>(It.IsAny<string>())).Returns(Task.FromResult<Menu>(Helpers.DeserializeJSONString<Menu>(JSONStrings.Menu)));
                OmnivoreDataManager dataMgr = new OmnivoreDataManager(mockRepo.Object);
                mgr = new OmnivoreManager(dataMgr);
            }

            // make the call
            Menu output = await mgr.GetMenu_Async(URLBuilder.DefaultLocationMenuUrl);

            // assert that it worked
            Assert.IsNotNull(output);
            Assert.IsNotNull(output.Links);
            Assert.IsTrue(output.Links.Count == 4);
        }

        [TestMethod]
        public async Task TestGetMenuCategoriesAndItems_Async()
        {
            OmnivoreManager mgr = null;

            if (RunInIntegrationMode)
            {
                mgr = new OmnivoreManager(); // default, which uses the real repository
            }
            else
            {
                // set up mocking so we don't hit the real API
                Mock<OmnivoreRepository> mockRepo = new Mock<OmnivoreRepository>();
                mockRepo.Setup(m => m.GetOmnivoreObject<OmnivoreCollection<Category>>(It.IsAny<string>()))
                    .Returns(Task.FromResult<OmnivoreCollection<Category>>(Helpers.DeserializeJSONString<OmnivoreCollection<Category>>(JSONStrings.MenuCategories)));
                OmnivoreDataManager dataMgr = new OmnivoreDataManager(mockRepo.Object);
                mgr = new OmnivoreManager(dataMgr);
            }

            // make the call
            OmnivoreCollection<Category> output = await mgr.GetMenuCategoriesAndItems_Async(URLBuilder.DefaultLocationMenuCategoriesUrl);

            // assert that it worked
            Assert.IsNotNull(output);
            Assert.IsTrue(output.Count == 3);
            Assert.IsNotNull(output.Links);
            Assert.IsTrue(output.Links.Count == 1);
            Assert.IsNotNull(output.Items);
            Assert.IsTrue(output.Items.Count == 1);
            List<Category> catGroups = (List<Category>)output.Items.First().Value;
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
            MenuItem mi = menuItems.Find(m => m.Name == "Orange Juice"); // can't rely on order
            Assert.IsNotNull(mi);
            Assert.IsTrue(mi.Id == "doTaLTyg");
        }

        [TestMethod]
        public async Task TestGetMenuItemModifierGroupCollection_Async()
        {
            OmnivoreManager mgr = null;

            if (RunInIntegrationMode)
            {
                mgr = new OmnivoreManager(); // default, which uses the real repository
            }
            else
            {
                // set up mocking so we don't hit the real API
                Mock<OmnivoreRepository> mockRepo = new Mock<OmnivoreRepository>();
                mockRepo.Setup(c => c.GetOmnivoreObject<OmnivoreCollection<MenuItemModifierGroup>>(It.IsAny<string>()))
                    .Returns(Task.FromResult<OmnivoreCollection<MenuItemModifierGroup>>(Helpers.DeserializeJSONString<OmnivoreCollection<MenuItemModifierGroup>>(JSONStrings.MenuItemModifierGroups)));
                OmnivoreDataManager dataMgr = new OmnivoreDataManager(mockRepo.Object);
                mgr = new OmnivoreManager(dataMgr);
            }

            // make the call
            OmnivoreCollection<MenuItemModifierGroup> output = await mgr.GetMenuItemModifierGroupCollection_Async(URLBuilder.DefaultLocationMenuItemModifierGroupsUrl("rMTAbTjr"));

            // assert that it worked
            Assert.IsNotNull(output);
            Assert.IsTrue(output.Count == 2);
            Assert.IsNotNull(output.Links);
            Assert.IsTrue(output.Links.Count == 1);
            Assert.IsNotNull(output.Items);
            Assert.IsTrue(output.Items.Count == 1);
            List<MenuItemModifierGroup> modGroups = (List<MenuItemModifierGroup>)output.Items.First().Value;
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
            OmnivoreManager mgr = null;

            if (RunInIntegrationMode)
            {
                mgr = new OmnivoreManager(); // default, which uses the real repository
            }
            else
            {
                // set up mocking so we don't hit the real API
                Mock<OmnivoreRepository> mockRepo = new Mock<OmnivoreRepository>();
                mockRepo.Setup(m => m.GetOmnivoreObject<OmnivoreCollection<Table>>(It.IsAny<string>()))
                    .Returns(Task.FromResult<OmnivoreCollection<Table>>(Helpers.DeserializeJSONString<OmnivoreCollection<Table>>(JSONStrings.Tables)));
                OmnivoreDataManager dataMgr = new OmnivoreDataManager(mockRepo.Object);
                mgr = new OmnivoreManager(dataMgr);
            }

            // make the call
            OmnivoreCollection<Table> output = await mgr.GetTableCollection_Async(URLBuilder.DefaultLocationTablesUrl);

            // assert that it worked
            Assert.IsNotNull(output);
            Assert.IsNotNull(output.Links);
            Assert.IsTrue(output.Links.Count == 1);
            Assert.IsNotNull(output.Items);
            Assert.IsTrue(output.Items.Count == 1);
            List<Table> tables = (List<Table>)output.Items.First().Value;
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
        public async Task TestGetRevenueCenterCollection_Async()
        {
            OmnivoreManager mgr = null;

            if (RunInIntegrationMode)
            {
                mgr = new OmnivoreManager(); // default, which uses the real repository
            }
            else
            {
                // set up mocking so we don't hit the real API
                Mock<OmnivoreRepository> mockRepo = new Mock<OmnivoreRepository>();
                mockRepo.Setup(m => m.GetOmnivoreObject<OmnivoreCollection<RevenueCenter>>(It.IsAny<string>()))
                    .Returns(Task.FromResult<OmnivoreCollection<RevenueCenter>>(Helpers.DeserializeJSONString<OmnivoreCollection<RevenueCenter>>(JSONStrings.RevenueCenters)));
                OmnivoreDataManager dataMgr = new OmnivoreDataManager(mockRepo.Object);
                mgr = new OmnivoreManager(dataMgr);
            }

            // make the call
            OmnivoreCollection<RevenueCenter> output = await mgr.GetRevenueCenterCollection_Async(URLBuilder.DefaultLocationRevenueCentersUrl);

            // assert that it worked
            Assert.IsNotNull(output);
            Assert.IsNotNull(output.Links);
            Assert.IsTrue(output.Links.Count == 1);
            Assert.IsNotNull(output.Items);
            Assert.IsTrue(output.Items.Count == 1);
            RevenueCenter rc = (RevenueCenter)output.Items.First().Value[0];
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
            TicketItem ti = t.EmbeddedTicketItems.items.Find(c => c.Id == "nibAL5cy"); // new baconings
            Assert.IsNotNull(ti);
            Assert.IsTrue(ti.Name == "New Bacon-ings");
            Assert.IsNotNull(ti.EmbeddedTicketItemSubclasses);
            Assert.IsNotNull(ti.EmbeddedTicketItemSubclasses.menu_item);
            MenuItem mi = ti.EmbeddedTicketItemSubclasses.menu_item;
            Assert.IsTrue(mi.Id == "rMTAbTjr");
            Assert.IsNotNull(ti.EmbeddedTicketItemSubclasses.modifiers);
            Assert.IsTrue(ti.EmbeddedTicketItemSubclasses.modifiers.Count == 2);
            TicketItemModifier tim = ti.EmbeddedTicketItemSubclasses.modifiers.Find(c => c.Id == "KieArGcr"); // tomato
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
            OmnivoreManager mgr = null;

            if (RunInIntegrationMode)
            {
                mgr = new OmnivoreManager(); // default, which uses the real repository
            }
            else
            {
                // set up mocking so we don't hit the real API
                Mock<OmnivoreRepository> mockRepo = new Mock<OmnivoreRepository>();
                mockRepo.Setup(m => m.GetOmnivoreObject<OmnivoreCollection<OrderType>>(It.IsAny<string>()))
                    .Returns(Task.FromResult<OmnivoreCollection<OrderType>>(Helpers.DeserializeJSONString<OmnivoreCollection<OrderType>>(JSONStrings.OrderTypes)));
                OmnivoreDataManager dataMgr = new OmnivoreDataManager(mockRepo.Object);
                mgr = new OmnivoreManager(dataMgr);
            }

            // make the call
            OmnivoreCollection<OrderType> output = await mgr.GetOrderTypeCollection_Async(URLBuilder.DefaultLocationOrderTypesUrl);

            // assert that it worked
            Assert.IsNotNull(output);
            Assert.IsNotNull(output.Links);
            Assert.IsTrue(output.Links.Count == 1);
            Assert.IsNotNull(output.Items);
            Assert.IsTrue(output.Items.Count == 1);
            List<OrderType> orderTypes = (List<OrderType>)output.Items.First().Value;
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
            OmnivoreManager mgr = null;

            if (RunInIntegrationMode)
            {
                mgr = new OmnivoreManager(); // default, which uses the real repository
            }
            else
            {
                // set up mocking so we don't hit the real API
                Mock<OmnivoreRepository> mockRepo = new Mock<OmnivoreRepository>();
                mockRepo.Setup(m => m.GetOmnivoreObject<OmnivoreCollection<Employee>>(It.IsAny<string>()))
                    .Returns(Task.FromResult<OmnivoreCollection<Employee>>(Helpers.DeserializeJSONString<OmnivoreCollection<Employee>>(JSONStrings.Employees)));
                OmnivoreDataManager dataMgr = new OmnivoreDataManager(mockRepo.Object);
                mgr = new OmnivoreManager(dataMgr);
            }

            // make the call
            OmnivoreCollection<Employee> output = await mgr.GetEmployeeCollection_Async(URLBuilder.DefaultLocationEmployeesUrl);

            // assert that it worked
            Assert.IsNotNull(output);
            Assert.IsNotNull(output.Links);
            Assert.IsTrue(output.Links.Count == 1);
            Assert.IsNotNull(output.Items);
            Assert.IsTrue(output.Items.Count == 1);
            List<Employee> emps = (List<Employee>)output.Items.First().Value;
            Assert.IsNotNull(emps);
            Assert.IsTrue(emps.Count == 5);
            Employee emp = emps.First();
            Assert.IsNotNull(emp);
            Assert.IsTrue(emp.Id == "MjikgioG");
            Assert.IsTrue(emp.LastName == "Belcher");
        }

        [TestMethod]
        public async Task TestGetTenderTypeCollection_Async()
        {
            OmnivoreManager mgr = null;

            if (RunInIntegrationMode)
            {
                mgr = new OmnivoreManager(); // default, which uses the real repository
            }
            else
            {
                // set up mocking so we don't hit the real API
                Mock<OmnivoreRepository> mockRepo = new Mock<OmnivoreRepository>();
                mockRepo.Setup(m => m.GetOmnivoreObject<OmnivoreCollection<TenderType>>(It.IsAny<string>()))
                    .Returns(Task.FromResult<OmnivoreCollection<TenderType>>(Helpers.DeserializeJSONString<OmnivoreCollection<TenderType>>(JSONStrings.TenderTypes)));
                OmnivoreDataManager dataMgr = new OmnivoreDataManager(mockRepo.Object);
                mgr = new OmnivoreManager(dataMgr);
            }

            // make the call
            OmnivoreCollection<TenderType> output = await mgr.GetTenderTypeCollection_Async(URLBuilder.DefaultLocationTenderTypesUrl);

            // assert that it worked
            Assert.IsNotNull(output);
            Assert.IsNotNull(output.Links);
            Assert.IsTrue(output.Links.Count == 1);
            Assert.IsNotNull(output.Items);
            Assert.IsTrue(output.Items.Count == 1);
            List<TenderType> tenderTypes = (List<TenderType>)output.Items.First().Value;
            Assert.IsNotNull(tenderTypes);
            Assert.IsTrue(tenderTypes.Count == 4);
            TenderType tt = tenderTypes.Find(t => t.Name == "Visa");
            Assert.IsNotNull(tt);
            Assert.IsTrue(tt.Id == "qBi4Bik7");
        }

        [TestMethod]
        public async Task TestGetTicket()
        {
            OmnivoreManager mgr = null;

            if (RunInIntegrationMode)
            {
                mgr = new OmnivoreManager(); // default, which uses the real repository
            }
            else
            {
                // set up mocking so we don't hit the real API
                Mock<OmnivoreRepository> mockRepo = new Mock<OmnivoreRepository>();
                mockRepo.Setup(m => m.GetOmnivoreObject<Ticket>(It.IsAny<string>())).Returns(Task.FromResult<Ticket>(Helpers.DeserializeJSONString<Ticket>(JSONStrings.Ticket)));
                OmnivoreDataManager dataMgr = new OmnivoreDataManager(mockRepo.Object);
                mgr = new OmnivoreManager(dataMgr);
            }

            // make the call
            Ticket output = await mgr.GetTicket(URLBuilder.DefaultLocationTicketUrl("6c9bp8Td"));

            // assert that it worked
            Assert.IsNotNull(output);
            Assert.IsTrue(output.Name == "Your First Ticket!");
        }

        [TestMethod]
        public async Task TestOpenTicket()
        {
            OmnivoreManager mgr = null;

            if (RunInIntegrationMode)
            {
                mgr = new OmnivoreManager(); // default, which uses the real repository
            }
            else
            {
                // set up mocking so we don't hit the real API
                Mock<OmnivoreRepository> mockRepo = new Mock<OmnivoreRepository>();
                mockRepo.Setup(m => m.PostOmnivoreObject<TicketOpenDTO, Ticket>(It.IsAny<string>(), It.IsAny<TicketOpenDTO>()))
                    .Returns(Task.FromResult<Ticket>(Helpers.DeserializeJSONString<Ticket>(JSONStrings.OpenTicketResponse)));
                OmnivoreDataManager dataMgr = new OmnivoreDataManager(mockRepo.Object);
                mgr = new OmnivoreManager(dataMgr);
            }

            // arrange - TODO: get IDs from POS system, not hardcoded!
            Ticket ticketToCreate = new Ticket();
            ticketToCreate.EmbeddedTicketItems = new EmbeddedTicketItems();
            ticketToCreate.EmbeddedTicketItems.employee = new Employee() { Id = "BdTaKT4X" };
            ticketToCreate.EmbeddedTicketItems.order_type = new OrderType() { Id = "KxiAaip5" };
            ticketToCreate.EmbeddedTicketItems.revenue_center = new RevenueCenter() { Id = "LdiqGibo" };
            ticketToCreate.EmbeddedTicketItems.table = new Table() { Id = "x4TdoTd8" };
            ticketToCreate.GuestCount = 2;
            ticketToCreate.Name = "Scott's Test Ticket!";
            ticketToCreate.AutoSend = true;

            // act
            Ticket output = await mgr.OpenTicket(ticketToCreate);

            // assert
            Assert.IsNotNull(output);
            Assert.IsTrue(output.Name == "Scott's Test Ticket!");
            Assert.IsFalse(String.IsNullOrEmpty(output.Id)); // should have assigned an id   9c89xxTd
            Assert.IsTrue(output.GuestCount == 2);
            Assert.IsNotNull(output.EmbeddedTicketItems);
            Assert.IsNotNull(output.EmbeddedTicketItems.employee);
            Assert.IsTrue(output.EmbeddedTicketItems.employee.Id == "BdTaKT4X");
            Assert.IsNotNull(output.EmbeddedTicketItems.order_type);
            Assert.IsTrue(output.EmbeddedTicketItems.order_type.Id == "KxiAaip5");
            Assert.IsNotNull(output.EmbeddedTicketItems.revenue_center);
            Assert.IsTrue(output.EmbeddedTicketItems.revenue_center.Id == "LdiqGibo");
            Assert.IsNotNull(output.EmbeddedTicketItems.table);
            Assert.IsTrue(output.EmbeddedTicketItems.table.Id == "x4TdoTd8");
        }

        [TestMethod]
        //[Ignore] // might not want to run this in integration mode too often - requires updating
        public async Task TestAddItemsToTicket()
        {
            string ticketId = "9c89xxTd"; // update each time I open a ticket on the real API

            OmnivoreManager mgr = null;

            if (RunInIntegrationMode)
            {
                mgr = new OmnivoreManager(); // default, which uses the real repository
            }
            else
            {
                // set up mocking so we don't hit the real API
                Mock<OmnivoreRepository> mockRepo = new Mock<OmnivoreRepository>();
                mockRepo.Setup(m => m.GetOmnivoreObject<OmnivoreCollection<Category>>(URLBuilder.DefaultLocationMenuCategoriesUrl)).Returns(Task.FromResult<OmnivoreCollection<Category>>(Helpers.DeserializeJSONString<OmnivoreCollection<Category>>(JSONStrings.MenuCategories)));
                mockRepo.Setup(m => m.GetOmnivoreObject<Ticket>(URLBuilder.DefaultLocationTicketUrl(ticketId))).Returns(Task.FromResult<Ticket>(Helpers.DeserializeJSONString<Ticket>(JSONStrings.OpenTicketResponse)));
                mockRepo.Setup(m => m.GetOmnivoreObject<OmnivoreCollection<MenuItemModifierGroup>>(URLBuilder.DefaultLocationMenuItemModifierGroupsUrl("rMTAbTjr"))).Returns(Task.FromResult<OmnivoreCollection<MenuItemModifierGroup>>(Helpers.DeserializeJSONString<OmnivoreCollection<MenuItemModifierGroup>>(JSONStrings.MenuItemModifierGroups)));
                mockRepo.Setup(m => m.PostOmnivoreObject<List<TicketItemOpenDTO>, Ticket>(URLBuilder.DefaultLocationAddTicketItemsUrl("9c89xxTd"), It.IsAny<List<TicketItemOpenDTO>>())).Returns(Task.FromResult<Ticket> (Helpers.DeserializeJSONString<Ticket>(JSONStrings.AddTicketItemsResponse)));
                OmnivoreDataManager dataMgr = new OmnivoreDataManager(mockRepo.Object);
                mgr = new OmnivoreManager(dataMgr);
            }

            // let's get some menu items
            OmnivoreCollection<Category> categoryCollection = await mgr.GetMenuCategoriesAndItems_Async(URLBuilder.DefaultLocationMenuCategoriesUrl);

            // let's get our ticket that we opened
            Ticket output = await mgr.GetTicket(URLBuilder.DefaultLocationTicketUrl(ticketId));

            // now let's add a couple of menu items, with modifiers, to our ticket
            // Note that the assumption is that another feature would get the list of menu items,
            // and there would be some selection of menu items from there, and they would then pass
            // in the selected menu items...so this selection is a little contrived since I'm not
            // building the client app.  I can provide methods to get the menu items, and to 
            // allow passing in selected menu items to add them to a ticket, but the actual selection
            // is something the client app would need to perform.
            if (categoryCollection != null)
            {
                // let's bypass the proper checks for now since I'm just testing for now
                List<Category> categories = categoryCollection.Items.First().Value;

                MenuItem drink = null;
                MenuItem burger = null;

                // let's get a drink first
                Category drinkCat = categories.Find(c => c.Name == "Drinks");


                if (drinkCat != null)
                {
                    // I'll just grab the first thing because I'm thirsty - again bypassing proper coding techniques because 
                    // I just want to get the menu item, and I don't have my proper client-facing .NET objects yet, etc.
                    // I'm just testing the add item functionality here, so I can refine it later.
                    drink = drinkCat.MenuItems.First().Value.First();

                    // if there are modifier groups for this item, I'll grab them... need to methodize this
                    if (drink.ModifierGroupsCount > 0)
                    {
                        // I know there are none for this one, so punting for now.
                    }
                }

                // let's order a burger...mmm, burgers..
                Category burgerCat = categories.Find(c => c.Name == "Burgers");

                if (burgerCat != null)
                {
                    burger = burgerCat.MenuItems.First().Value.Find(b => b.Name == "New Bacon-ings");

                    // if there are modifier groups for this item, I'll grab them
                    // TODO: methodize this
                    if (burger.ModifierGroupsCount > 0)
                    {
                        Link burgerModsLink = burger.Links.Where(l => l.Key == "modifier_groups").First().Value;
                        OmnivoreCollection<MenuItemModifierGroup> modifierCollection = await mgr.GetMenuItemModifierGroupCollection_Async(burgerModsLink.URL); // I should be getting all URLs from the API...
                        List<MenuItemModifierGroup> modGroups = modifierCollection.Items.First().Value;
                        MenuItemModifierGroup temperatureGroup = modGroups.Find(mg => mg.Name == "Temperature");
                        MenuItemModifier temperatureMod = temperatureGroup.Modifiers.First().Value.Find(m => m.Name == "Perfect");
                        temperatureMod.Comment = "just the right amount of pink";
                        MenuItemModifierGroup toppings = modGroups.Find(mg => mg.Name == "Toppings");
                        MenuItemModifier toppingMod = toppings.Modifiers.First().Value.Find(m => m.Name == "Cheese");
                        toppingMod.Quantity = 2;
                        toppingMod.Comment = "extra cheese!";

                        if (burger.Modifiers == null)
                        {
                            burger.Modifiers = new List<MenuItemModifier>();
                        }
                        burger.Modifiers.Add(temperatureMod);
                        burger.Modifiers.Add(toppingMod);
                    }
                }

                // I've selected what I want - now let's add it to the ticket!
                TicketItem drinkTicketItem = new TicketItem();
                drinkTicketItem.EmbeddedTicketItemSubclasses = new EmbeddedTicketItemSubclasses();
                drinkTicketItem.Comment = "ticket item comment for my soda";
                drinkTicketItem.Quantity = 2; // just so I make sure it doesn't default
                drinkTicketItem.EmbeddedTicketItemSubclasses.menu_item = drink;

                TicketItem burgerTicketItem = new TicketItem();
                burgerTicketItem.EmbeddedTicketItemSubclasses = new EmbeddedTicketItemSubclasses();
                burgerTicketItem.Comment = "ticket item comment for my burger";
                burgerTicketItem.Quantity = 2; // just so I make sure it doesn't default
                burgerTicketItem.EmbeddedTicketItemSubclasses.menu_item = burger;

                List<TicketItem> ticketItemsToAdd = new List<TicketItem>(); // fix somehow
                ticketItemsToAdd.Add(drinkTicketItem);
                ticketItemsToAdd.Add(burgerTicketItem);

                Ticket t = await mgr.AddTicketItems(ticketId, ticketItemsToAdd);

                // test the output to see if the items were added.
                Assert.IsNotNull(t);
                // check the rest manually/later
            }
        }

        [TestMethod]
        //[Ignore]
        public async Task TestMakeCardPresentPayment() // todo fix
        {
            OmnivoreManager mgr = null;

            if (RunInIntegrationMode)
            {
                mgr = new OmnivoreManager(); // default, which uses the real repository
            }
            else
            {
                // set up mocking so we don't hit the real API
                Mock<OmnivoreRepository> mockRepo = new Mock<OmnivoreRepository>();
                mockRepo.Setup(m => m.PostOmnivoreObject<PaymentDTO, PaymentStatus>(It.IsAny<string>(), It.IsAny<PaymentDTO>()))
                    .Returns(Task.FromResult<PaymentStatus>(Helpers.DeserializeJSONString<PaymentStatus>(JSONStrings.PaymentStatusResponse))); // todo: don't have a good mock JSON for this yet.
                OmnivoreDataManager dataMgr = new OmnivoreDataManager(mockRepo.Object);
                mgr = new OmnivoreManager(dataMgr);
            }

            PaymentDTO payment = new PaymentDTO();
            payment.Amount = (decimal)18.03;
            payment.CardInfo = new Dictionary<string, object>();
            payment.CardInfo.Add("data", "%B4111111111111111^SCHMOE                /JOE^161210100695000000?");
            payment.PaymentType = "card_present";
            payment.Tip = (decimal)3.50;

            PaymentStatus paymentStatus = await mgr.MakePayment("9c89xxTd", payment);

            // test the output to see if the items were added.
            Assert.IsNotNull(paymentStatus);
        }

        [TestMethod]
        //[Ignore]
        public async Task TestMakeCardNotPresentPayment() // todo fix
        {
            OmnivoreManager mgr = null;

            if (RunInIntegrationMode)
            {
                mgr = new OmnivoreManager(); // default, which uses the real repository
            }
            else
            {
                // set up mocking so we don't hit the real API
                Mock<OmnivoreRepository> mockRepo = new Mock<OmnivoreRepository>();
                mockRepo.Setup(m => m.PostOmnivoreObject<PaymentDTO, PaymentStatus>(It.IsAny<string>(), It.IsAny<PaymentDTO>()))
                    .Returns(Task.FromResult<PaymentStatus>(Helpers.DeserializeJSONString<PaymentStatus>(JSONStrings.PaymentStatusResponse))); // todo: don't have a good mock JSON for this yet.
                OmnivoreDataManager dataMgr = new OmnivoreDataManager(mockRepo.Object);
                mgr = new OmnivoreManager(dataMgr);
            }

            PaymentDTO payment = new PaymentDTO();
            payment.Amount = (decimal)18.03;
            payment.CardInfo = new Dictionary<string, object>();
            payment.CardInfo.Add("number", "4111111111111111");
            payment.CardInfo.Add("exp_month", 10); // int
            payment.CardInfo.Add("exp_year", 2016); // int
            payment.CardInfo.Add("cvc2", 123); // int
            payment.PaymentType = "card_not_present";
            payment.Tip = (decimal)3.50;

            PaymentStatus paymentStatus = await mgr.MakePayment("9c89xxTd", payment);

            // test the output to see if the items were added.
            Assert.IsNotNull(paymentStatus);
        }

        [TestMethod]
        //[Ignore]
        public async Task TestMakeGiftCardPayment() // todo fix
        {
            OmnivoreManager mgr = null;

            if (RunInIntegrationMode)
            {
                mgr = new OmnivoreManager(); // default, which uses the real repository
            }
            else
            {
                // set up mocking so we don't hit the real API
                Mock<OmnivoreRepository> mockRepo = new Mock<OmnivoreRepository>();
                mockRepo.Setup(m => m.PostOmnivoreObject<PaymentDTO, PaymentStatus>(It.IsAny<string>(), It.IsAny<PaymentDTO>()))
                    .Returns(Task.FromResult<PaymentStatus>(Helpers.DeserializeJSONString<PaymentStatus>(JSONStrings.PaymentStatusResponse))); // todo: don't have a good mock JSON for this yet.
                OmnivoreDataManager dataMgr = new OmnivoreDataManager(mockRepo.Object);
                mgr = new OmnivoreManager(dataMgr);
            }

            PaymentDTO payment = new PaymentDTO();
            payment.Amount = (decimal)18.03;
            payment.CardInfo = new Dictionary<string, object>();
            payment.CardInfo.Add("number", "4111111111111111");
            payment.PaymentType = "gift_card";
            payment.Tip = (decimal)3.50;

            PaymentStatus paymentStatus = await mgr.MakePayment("9c89xxTd", payment);

            // test the output to see if the items were added.
            Assert.IsNotNull(paymentStatus);
        }

        [TestMethod]
        //[Ignore]
        public async Task TestMakeThirdPartyPayment() // todo fix
        {
            OmnivoreManager mgr = null;

            if (RunInIntegrationMode)
            {
                mgr = new OmnivoreManager(); // default, which uses the real repository
            }
            else
            {
                // set up mocking so we don't hit the real API
                Mock<OmnivoreRepository> mockRepo = new Mock<OmnivoreRepository>();
                mockRepo.Setup(m => m.PostOmnivoreObject<PaymentThirdPartyDTO, PaymentStatus>(It.IsAny<string>(), It.IsAny<PaymentThirdPartyDTO>()))
                    .Returns(Task.FromResult<PaymentStatus>(Helpers.DeserializeJSONString<PaymentStatus>(JSONStrings.PaymentStatusResponse))); // todo: don't have a good mock JSON for this yet.
                mockRepo.Setup(m => m.GetOmnivoreObject<OmnivoreCollection<TenderType>>(URLBuilder.DefaultLocationTenderTypesUrl))
                .Returns(Task.FromResult<OmnivoreCollection<TenderType>>(Helpers.DeserializeJSONString<OmnivoreCollection<TenderType>>(JSONStrings.TenderTypes)));
                OmnivoreDataManager dataMgr = new OmnivoreDataManager(mockRepo.Object);
                mgr = new OmnivoreManager(dataMgr);
            }

            OmnivoreCollection<TenderType> tenderTypes = await mgr.GetTenderTypeCollection_Async(URLBuilder.DefaultLocationTenderTypesUrl);

            TenderType tenderType = tenderTypes.Items.First().Value.First();
            PaymentThirdPartyDTO payment = new PaymentThirdPartyDTO();
            payment.Amount = (decimal)18.03;
            payment.PaymentType = "3rd_party";
            payment.Tip = (decimal)3.50;
            payment.PaymentSource = "external transaction 111";
            payment.TenderType = Convert.ToString(tenderType.Id);

            PaymentStatus paymentStatus = await mgr.MakePaymentThirdParty("9c89xxTd", payment);

            // test the output to see if the items were added.
            Assert.IsNotNull(paymentStatus);
        }

        [TestMethod]
        public async Task EndToEndTest()
        {
            OmnivoreManager mgr = null;

            if (RunInIntegrationMode)
            {
                mgr = new OmnivoreManager(); // default, which uses the real repository - this works in integration mode!!
            }
            else
            {
                // set up mocking so we don't hit the real API
                Mock<OmnivoreRepository> mockRepo = new Mock<OmnivoreRepository>();
                mockRepo.Setup(m => m.PostOmnivoreObject<TicketOpenDTO, Ticket>(URLBuilder.DefaultLocationOpenTicketUrl, It.IsAny<TicketOpenDTO>())).Returns(Task.FromResult<Ticket>(Helpers.DeserializeJSONString<Ticket>(JSONStrings.OpenTicketResponse)));
                mockRepo.Setup(m => m.GetOmnivoreObject<OmnivoreCollection<Category>>(URLBuilder.DefaultLocationMenuCategoriesUrl)).Returns(Task.FromResult<OmnivoreCollection<Category>>(Helpers.DeserializeJSONString<OmnivoreCollection<Category>>(JSONStrings.MenuCategories)));
                mockRepo.Setup(m => m.GetOmnivoreObject<OmnivoreCollection<MenuItemModifierGroup>>(URLBuilder.DefaultLocationMenuItemModifierGroupsUrl("rMTAbTjr"))).Returns(Task.FromResult<OmnivoreCollection<MenuItemModifierGroup>>(Helpers.DeserializeJSONString<OmnivoreCollection<MenuItemModifierGroup>>(JSONStrings.MenuItemModifierGroups)));
                mockRepo.Setup(m => m.PostOmnivoreObject<PaymentDTO, PaymentStatus>(URLBuilder.DefaultLocationMakePaymentUrl("9c89xxTd"), It.IsAny<PaymentDTO>())).Returns(Task.FromResult<PaymentStatus>(Helpers.DeserializeJSONString<PaymentStatus>(JSONStrings.PaymentStatusResponse)));
                mockRepo.Setup(m => m.PostOmnivoreObject<List<TicketItemOpenDTO>, Ticket>(URLBuilder.DefaultLocationAddTicketItemsUrl("9c89xxTd"), It.IsAny<List<TicketItemOpenDTO>>())).Returns(Task.FromResult<Ticket>(Helpers.DeserializeJSONString<Ticket>(JSONStrings.AddTicketItemsResponse)));
                OmnivoreDataManager dataMgr = new OmnivoreDataManager(mockRepo.Object);
                mgr = new OmnivoreManager(dataMgr);
            }

            // open ticket - TODO: get IDs from POS system, not hardcoded!
            Ticket ticketToCreate = new Ticket();
            ticketToCreate.EmbeddedTicketItems = new EmbeddedTicketItems();
            ticketToCreate.EmbeddedTicketItems.employee = new Employee() { Id = "BdTaKT4X" };
            ticketToCreate.EmbeddedTicketItems.order_type = new OrderType() { Id = "KxiAaip5" };
            ticketToCreate.EmbeddedTicketItems.revenue_center = new RevenueCenter() { Id = "LdiqGibo" };
            ticketToCreate.EmbeddedTicketItems.table = new Table() { Id = "x4TdoTd8" };
            ticketToCreate.GuestCount = 2;
            ticketToCreate.Name = "Scott's Test Ticket!";
            ticketToCreate.AutoSend = true;

            // act
            Ticket openTicket = await mgr.OpenTicket(ticketToCreate);

            // assert
            Assert.IsNotNull(openTicket);
            Assert.IsFalse(String.IsNullOrEmpty(openTicket.Id));
            Assert.IsTrue(openTicket.Name == "Scott's Test Ticket!");
            string ticketId = openTicket.Id; // store for later

            // get menu, order stuff
            OmnivoreCollection<Category> categoryCollection = await mgr.GetMenuCategoriesAndItems_Async(URLBuilder.DefaultLocationMenuCategoriesUrl);

            // now let's add a couple of menu items, with modifiers, to our ticket
            // Note that the assumption is that another feature would get the list of menu items,
            // and there would be some selection of menu items from there, and they would then pass
            // in the selected menu items...so this selection is a little contrived since I'm not
            // building the client app.  I can provide methods to get the menu items, and to 
            // allow passing in selected menu items to add them to a ticket, but the actual selection
            // is something the client app would need to perform.
            Assert.IsNotNull(categoryCollection);

            // let's bypass the proper checks for now since I'm just testing for now
            List<Category> categories = categoryCollection.Items.First().Value;

            MenuItem drink = null;
            MenuItem burger = null;

            // let's get a drink first
            Category drinkCat = categories.Find(c => c.Name == "Drinks");


            if (drinkCat != null)
            {
                // I'll just grab the first thing because I'm thirsty - again bypassing proper coding techniques because 
                // I just want to get the menu item, and I don't have my proper client-facing .NET objects yet, etc.
                // I'm just testing the add item functionality here, so I can refine it later.
                drink = drinkCat.MenuItems.First().Value.First();

                // if there are modifier groups for this item, I'll grab them... need to methodize this
                if (drink.ModifierGroupsCount > 0)
                {
                    // I know there are none for this one, so punting for now.
                }
            }

            // let's order a burger...mmm, burgers..
            Category burgerCat = categories.Find(c => c.Name == "Burgers");

            if (burgerCat != null)
            {
                burger = burgerCat.MenuItems.First().Value.Find(b => b.Name == "New Bacon-ings");

                // if there are modifier groups for this item, I'll grab them
                // TODO: methodize this
                if (burger.ModifierGroupsCount > 0)
                {
                    Link burgerModsLink = burger.Links.Where(l => l.Key == "modifier_groups").First().Value;
                    OmnivoreCollection<MenuItemModifierGroup> modifierCollection = await mgr.GetMenuItemModifierGroupCollection_Async(burgerModsLink.URL);
                    List<MenuItemModifierGroup> modGroups = modifierCollection.Items.First().Value;
                    MenuItemModifierGroup temperatureGroup = modGroups.Find(mg => mg.Name == "Temperature");
                    MenuItemModifier temperatureMod = temperatureGroup.Modifiers.First().Value.Find(m => m.Name == "Perfect");
                    temperatureMod.Comment = "just the right amount of pink";
                    MenuItemModifierGroup toppings = modGroups.Find(mg => mg.Name == "Toppings");
                    MenuItemModifier toppingMod = toppings.Modifiers.First().Value.Find(m => m.Name == "Cheese");
                    toppingMod.Quantity = 2;
                    toppingMod.Comment = "extra cheese!";

                    if (burger.Modifiers == null)
                    {
                        burger.Modifiers = new List<MenuItemModifier>();
                    }
                    burger.Modifiers.Add(temperatureMod);
                    burger.Modifiers.Add(toppingMod);
                }
            }

            // I've selected what I want - now let's add it to the ticket!
            TicketItem drinkTicketItem = new TicketItem();
            drinkTicketItem.EmbeddedTicketItemSubclasses = new EmbeddedTicketItemSubclasses();
            drinkTicketItem.Comment = "ticket item comment for my soda";
            drinkTicketItem.Quantity = 2; // just so I make sure it doesn't default
            drinkTicketItem.EmbeddedTicketItemSubclasses.menu_item = drink;

            TicketItem burgerTicketItem = new TicketItem();
            burgerTicketItem.EmbeddedTicketItemSubclasses = new EmbeddedTicketItemSubclasses();
            burgerTicketItem.Comment = "ticket item comment for my burger";
            burgerTicketItem.Quantity = 2; // just so I make sure it doesn't default
            burgerTicketItem.EmbeddedTicketItemSubclasses.menu_item = burger;

            List<TicketItem> ticketItemsToAdd = new List<TicketItem>(); // fix somehow
            ticketItemsToAdd.Add(drinkTicketItem);
            ticketItemsToAdd.Add(burgerTicketItem);

            Ticket ticketWithItems = await mgr.AddTicketItems(ticketId, ticketItemsToAdd);

            Assert.IsNotNull(ticketWithItems);
            Assert.IsNotNull(ticketWithItems.Totals);
            Assert.IsTrue(ticketWithItems.Totals.Due == (decimal)18.03);

            // pay to close out ticket
            PaymentDTO payment = new PaymentDTO();
            payment.Amount = (decimal)18.03;
            payment.CardInfo = new Dictionary<string, object>();
            payment.CardInfo.Add("data", "%B4111111111111111^SCHMOE                /JOE^161210100695000000?");
            payment.PaymentType = "card_present";
            payment.Tip = (decimal)3.50;

            PaymentStatus paymentStatus = await mgr.MakePayment(ticketId, payment);

            Assert.IsNotNull(paymentStatus);
            Assert.IsTrue(paymentStatus.Accepted);
            Assert.IsTrue(paymentStatus.AmountPaid == (decimal)21.53);
            Assert.IsTrue(paymentStatus.TicketClosed);
        }
    }
}
