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
        public async Task TestGetTenderTypeCollection_Async()
        {
            OmnivoreCollection<TenderType> output = await TestConnection.TestGetTenderTypeCollection_Async("https://api.omnivore.io/0.1/locations/zGibgKT9/tender_types/");
            Assert.IsNotNull(output);
            Assert.IsNotNull(output.Links);
            Assert.IsTrue(output.Links.Count == 1);
            Assert.IsNotNull(output.Items);
            Assert.IsTrue(output.Items.Count == 1);
            List<TenderType> tenderTypes = (List<TenderType>)output.Items.First().Value;
            Assert.IsNotNull(tenderTypes);
            Assert.IsTrue(tenderTypes.Count == 2);
            TenderType tt = tenderTypes.First();
            Assert.IsNotNull(tt);
            Assert.IsTrue(tt.Id == "qBi4Bik7");
            Assert.IsTrue(tt.TenderTypeEnum == TenderTypeEnum.Visa);
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
            ticketToCreate.Name = "Scott's Fifth Ticket!";
            ticketToCreate.AutoSend = true;

            // act
            Ticket output = await TestConnection.TestOpenTicket_Basic(ticketToCreate);

            // assert
            Assert.IsNotNull(output);
        }

        [TestMethod]
        [Ignore]
        public async Task TestGetTicketIOpened()
        {
            Ticket output = await TestConnection.TestGetTicket("Gc6bK8Tz");
            Assert.IsNotNull(output);
            Assert.IsTrue(output.Name == "Scott's Second Ticket!");
        }

        [TestMethod]
        [Ignore]
        public async Task TestAddItemsToTicket()
        {
            string ticketId = "ycjRX4Tz";

            // let's get some menu items
            CategoryCollection categoryCollection = await TestConnection.TestGetMenuCategoriesAndItems_Async();

            // let's get our ticket that we opened
            Ticket output = await TestConnection.TestGetTicket(ticketId);

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
                List<Category> categories = categoryCollection.Categories.First().Value;

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

                // let's order a burger
                Category burgerCat = categories.Find(c => c.Name == "Burgers");

                if (burgerCat != null)
                {
                    burger = burgerCat.MenuItems.First().Value.Find(b => b.Name == "New Bacon-ings");

                    // if there are modifier groups for this item, I'll grab them
                    // TODO: methodize this
                    if (burger.ModifierGroupsCount > 0)
                    {
                        Link burgerModsLink = burger.Links.Where(l => l.Key == "modifier_groups").First().Value;
                        MenuItemModifierGroupCollection modifierCollection = await TestConnection.TestGetMenuItemModifierGroupCollection_Async(burgerModsLink.URL);
                        List<MenuItemModifierGroup> modGroups = modifierCollection.ModifierGroups.First().Value;// sheesh...see why I need to clean this up in the object model??  I'd need a ton of null checks in here also if I wasn't in test (quick and dirty mode)
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

                Ticket t = await TestConnection.AddTicketItems(ticketId, ticketItemsToAdd);

                // test the output to see if the items were added.
                Assert.IsNotNull(t);
            }
        }

        [TestMethod]
        [Ignore]
        public async Task TestMakeCardPresentPayment()
        {
            PaymentDTO payment = new PaymentDTO();
            payment.Amount = (decimal)14.02;
            payment.CardInfo = new Dictionary<string, object>();
            payment.CardInfo.Add("data", "%B4111111111111111^SCHMOE                /JOE^161210100695000000?");
            payment.PaymentType = "card_present";
            payment.Tip = (decimal)3.50;

            PaymentStatus paymentStatus = await TestConnection.MakePayment("Gc6bK8Tz", payment);
            // test the output to see if the items were added.
            Assert.IsNotNull(paymentStatus);
        }

        [TestMethod]
        [Ignore]
        public async Task TestMakeCardNotPresentPayment()
        {
            PaymentDTO payment = new PaymentDTO();
            payment.Amount = (decimal)18.03;
            payment.CardInfo = new Dictionary<string, object>();
            payment.CardInfo.Add("number", "4111111111111111");
            payment.CardInfo.Add("exp_month", 10); // int
            payment.CardInfo.Add("exp_year", 2016); // int
            payment.CardInfo.Add("cvc2", 123); // int
            payment.PaymentType = "card_not_present";
            payment.Tip = (decimal)3.50;

            PaymentStatus paymentStatus = await TestConnection.MakePayment("xiAqgacA", payment);
            // test the output to see if the items were added.
            Assert.IsNotNull(paymentStatus);
        }

        [TestMethod]
        [Ignore]
        public async Task TestMakeGiftCardPayment()
        {
            PaymentDTO payment = new PaymentDTO();
            payment.Amount = (decimal)18.03;
            payment.CardInfo = new Dictionary<string, object>();
            payment.CardInfo.Add("number", "4111111111111111");
            payment.PaymentType = "gift_card";
            payment.Tip = (decimal)3.50;

            PaymentStatus paymentStatus = await TestConnection.MakePayment("9T89KXid", payment);
            // test the output to see if the items were added.
            Assert.IsNotNull(paymentStatus);
        }

        //[TestMethod]
        //[Ignore]
        //public async Task TestMakeThirdPartyPayment()
        //{
        //    //TenderTypeCollection tenderTypes = await TestConnection.TestGetTenderTypeCollection_Async();
        //    //TenderType tenderType = tenderTypes.TenderTypes.First().Value.First();

        //    //PaymentThirdPartyDTO payment = new PaymentThirdPartyDTO();
        //    //payment.Amount = (decimal)18.03;
        //    //payment.PaymentType = "3rd_party";
        //    //payment.Tip = (decimal)3.50;
        //    //payment.PaymentSource = "external transaction 111";
        //    //payment.TenderType = Convert.ToString(tenderType.Id);

        //    //PaymentStatus paymentStatus = await TestConnection.MakePaymentThirdParty("ycjRX4Tz", payment);
        //    //// test the output to see if the items were added.
        //    //Assert.IsNotNull(paymentStatus);
        //}
    }
}
