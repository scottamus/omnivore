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
    public class RevenueCenter : OmnivoreBase
    {
        [JsonProperty("default")]
        public bool Default { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("_embedded")]
        public EmbeddedTablesAndTickets EmbeddedTablesAndTickets { get; set; }
    }

    public class EmbeddedTablesAndTickets
    {
        public List<Ticket> open_tickets { get; set; }
        public List<Table> tables { get; set; }
    }

}
