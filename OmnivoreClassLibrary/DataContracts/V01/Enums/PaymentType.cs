using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Converters;
using OmnivoreClassLibrary.JSONConverters;

namespace OmnivoreClassLibrary.DataContracts.V01.Enums
{
    public enum PaymentType
    {
        CardNotPresent = 1,
        CardPresent = 2,
        ThirdParty = 3,
        GiftCard = 4
    }
}
