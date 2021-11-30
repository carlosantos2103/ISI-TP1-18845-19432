using System.Runtime.Serialization;

namespace EMSAC_Client
{
    [DataContractAttribute]
    class TeamCost
    {
        [DataMemberAttribute]
        public int id { get; set; }
        [DataMemberAttribute]
        public string label { get; set; }
        [DataMemberAttribute]
        public int cost { get; set; }
    }
}
