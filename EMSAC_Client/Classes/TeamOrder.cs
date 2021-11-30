using System.Collections.Generic;
using System.Runtime.Serialization;

namespace EMSAC_Client
{
    [DataContractAttribute]
    public class TeamOrder
    {
        [DataMemberAttribute]
        public int id { get; set; }
        [DataMemberAttribute]
        public string date { get; set; }
        [DataMemberAttribute]
        public float total_price { get; set; }
        [DataMemberAttribute]
        public int id_team { get; set; }
        [DataMemberAttribute]
        public int delivered { get; set; }
        [DataMemberAttribute]
        public List<Product> products { get; set; }
    }
}
