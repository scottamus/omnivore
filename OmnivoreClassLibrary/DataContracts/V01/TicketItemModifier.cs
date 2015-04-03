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
    public class TicketItemModifier : ModifierBase
    {
        [JsonProperty("_embedded")]
        public EmbeddedMenuItemModifier EmbeddedMenuItemModifier { get; set; }
    }

    public class EmbeddedMenuItemModifier
    {
        public MenuItemModifier menu_modifier { get; set; }
    }
}
