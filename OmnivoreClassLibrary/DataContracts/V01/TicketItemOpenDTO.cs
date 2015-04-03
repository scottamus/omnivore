using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Converters;
using OmnivoreClassLibrary.JSONConverters;

namespace OmnivoreClassLibrary.DataContracts.V01
{
    public class TicketItemOpenDTO
    {
        public TicketItemOpenDTO(TicketItem ticketItemToAdd)
        {
            if (ticketItemToAdd != null && ticketItemToAdd.EmbeddedTicketItemSubclasses != null &&
                ticketItemToAdd.EmbeddedTicketItemSubclasses.menu_item != null)
            {
                MenuItemId = ticketItemToAdd.EmbeddedTicketItemSubclasses.menu_item.Id;
                Quantity = ticketItemToAdd.Quantity;
                Comment = ticketItemToAdd.Comment;

                // todo: just grabbing first price level for now, if exists...
                if (ticketItemToAdd.EmbeddedTicketItemSubclasses.menu_item.PriceLevels != null &&
                    ticketItemToAdd.EmbeddedTicketItemSubclasses.menu_item.PriceLevels.Count > 0)
                {
                    PriceLevelId = ticketItemToAdd.EmbeddedTicketItemSubclasses.menu_item.PriceLevels[0].Id;
                }

                if (ticketItemToAdd.EmbeddedTicketItemSubclasses.menu_item != null &&
                    ticketItemToAdd.EmbeddedTicketItemSubclasses.menu_item.Modifiers != null &&
                    ticketItemToAdd.EmbeddedTicketItemSubclasses.menu_item.Modifiers.Count > 0)
                {
                    MenuItemModifiers = new List<MenuItemModifierAddDTO>();

                    foreach (MenuItemModifier item in ticketItemToAdd.EmbeddedTicketItemSubclasses.menu_item.Modifiers)
                    {
                        MenuItemModifiers.Add(new MenuItemModifierAddDTO(item));
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets the menu item identifier.  Required.
        /// </summary>
        /// <value>
        /// The menu item identifier.
        /// </value>
        [JsonProperty("menu_item")]
        public string MenuItemId { get; set; }

        /// <summary>
        /// Gets or sets the quanity.
        /// Defaults to 1!  Optional
        /// </summary>
        /// <value>
        /// The quanity.
        /// </value>
        [JsonProperty("quantity")]
        public int? Quantity { get; set; }

        /// <summary>
        /// Gets or sets the price level identifier.
        /// Defaults to 1!  Optional
        /// </summary>
        /// <value>
        /// The price level identifier.
        /// </value>
        [JsonProperty("price_level")]
        public string PriceLevelId { get; set; }

        /// <summary>
        /// Gets or sets the comment.
        /// Any text, typically special instructions that aren’t available through a modifier.  Optional
        /// </summary>
        /// <value>
        /// The comment.
        /// </value>
        [JsonProperty("comment")]
        public string Comment { get; set; }

        /// <summary>
        /// Gets or sets the menu item modifiers.
        /// Array of Menu Item Modifiers, Optional
        /// </summary>
        /// <value>
        /// The menu item modifiers.
        /// </value>
        [JsonProperty("modifiers")]
        public List<MenuItemModifierAddDTO> MenuItemModifiers { get; set; }
    }
}
