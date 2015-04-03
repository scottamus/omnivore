﻿using System;
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
    public class MenuItemModifierGroupCollection : OmnivoreCollectionBase
    {
        [JsonProperty("_embedded")]
        public Dictionary<string, List<MenuItemModifierGroup>> ModifierGroups { get; set; }
    }
}
