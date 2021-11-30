using System.Runtime.Serialization;

namespace EMSAC_Client
{
    [DataContractAttribute]
    public class AuthenticateResponse
    {
        [DataMemberAttribute]
        public string name { get; set; }
        [DataMemberAttribute]
        public string token { get; set; }


        public AuthenticateResponse(string user, string token)
        {
            name = user;
            this.token = token;
        }
    }
}
