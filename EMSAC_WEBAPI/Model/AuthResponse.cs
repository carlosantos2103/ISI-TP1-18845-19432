/*
 * <copyright file="AuthResponse.cs" Company = "IPCA - Instituto Politecnico do Cavado e do Ave">
 *      Copyright IPCA-EST. All rights reserved.
 * </copyright>
 * <version>0.1</version>
 *  <user> Joao Ricardo / Carlos Santos </users>
 * <number> 18845 / 19432 <number>                                     
 * <email> a18845@alunos.ipca.pt / a19432@alunos.ipca.pt<email>
 */

using System;

namespace EMSAC_WEBAPI.Model
{
    public class AuthResponse
    {
        public string Name { get; set; }
        public string Token { get; set; }

        public DateTime Expiration { get; set; }

        public AuthResponse() { }
        public AuthResponse(string user, string token)
        {
            Name = user;
            Token = token;
            Expiration = DateTime.Now.AddMinutes(120);
        }

        public AuthResponse(AuthRequest user, string token, DateTime expires)
        {
            Name = user.Username;
            Token = token;
            Expiration = expires;
        }
    }
}
