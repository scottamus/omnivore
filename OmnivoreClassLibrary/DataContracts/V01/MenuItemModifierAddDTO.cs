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
    public class MenuItemModifierAddDTO
    {
        public MenuItemModifierAddDTO(MenuItemModifier menuItemModifierToAdd)
        {
            if (menuItemModifierToAdd != null)
            {
                MenuItemModifierId = menuItemModifierToAdd.Id;
                Comment = menuItemModifierToAdd.Comment;

                if (menuItemModifierToAdd.Quantity.HasValue)
                {
                    Quantity = menuItemModifierToAdd.Quantity;
                }

                // todo: just grabbing first one for now.  Need to change up somehow - client-facing objs?
                if (menuItemModifierToAdd.PriceLevels != null && menuItemModifierToAdd.PriceLevels.Count > 0)
                {
                    PriceLevelId = menuItemModifierToAdd.PriceLevels[0].Id;
                }
            }
        }

        /// <summary>
        /// Gets or sets the menu item modifier identifier.  Required.
        /// </summary>
        /// <value>
        /// The menu item modifier identifier.
        /// </value>
        [JsonProperty("modifier")]
        public string MenuItemModifierId { get; set; }

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
    }
}
