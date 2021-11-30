/*
 * <copyright file="User.cs" Company = "IPCA - Instituto Politecnico do Cavado e do Ave">
 *      Copyright IPCA-EST. All rights reserved.
 * </copyright>
 * <version>0.1</version>
 *  <user> Joao Ricardo / Carlos Santos </users>
 * <number> 18845 / 19432 <number>                                     
 * <email> a18845@alunos.ipca.pt / a19432@alunos.ipca.pt<email>
 */

using System.Text.Json.Serialization;

namespace EMSAC_WEBAPI.Model
{

    public class User
    {
        static int id;
        string passwd;

        public string Name { get ; set; }
        public string UserName { get; set; }
        public string EmailAddress { get; set; }

        [JsonIgnore]
        public string Pass { get=> passwd; set=> passwd=value; }
        public int Id { get => id; set => id = value; }
        public string Token { get; set; }

        public User(string name, string pass, string token)
        {
            Id = id++;
            Name =name;
            UserName = "";
            Pass = pass;
            Token = token;
        }

        public User()
        {
        }
    }

}
