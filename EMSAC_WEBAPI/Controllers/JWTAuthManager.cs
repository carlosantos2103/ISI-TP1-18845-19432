/*
 * <copyright file="JWTAuthManager.cs" Company = "IPCA - Instituto Politecnico do Cavado e do Ave">
 *      Copyright IPCA-EST. All rights reserved.
 * </copyright>
 * <version>0.1</version>
 *  <user> Joao Ricardo / Carlos Santos </users>
 * <number> 18845 / 19432 <number>                                     
 * <email> a18845@alunos.ipca.pt / a19432@alunos.ipca.pt<email>
 */

using System;
using System.Collections.Generic;
using EMSAC_WEBAPI.Model;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;


namespace EMSAC_WEBAPI.Controllers
{
    public interface IJWTAuthManager
    {
        AuthResponse Authenticate(AuthRequest loginDetails);
    }

    /// <summary>
    /// Classe auxiliar para gerir Autenticação e JWT
    /// </summary>
    public class JWTAuthManager : IJWTAuthManager
    {

        private readonly string tokenKey;

        /// <summary>
        /// Gere Token
        /// </summary>
        /// <param name="tokenKey"></param>
        public JWTAuthManager(string tokenKey)
        {
            this.tokenKey = tokenKey;
        }

        /// <summary>
        /// Autenticação com login/password
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="password">Password</param>
        /// <returns>AuthResponse(Name, Token, Expiration)</returns>
        public AuthResponse Authenticate(AuthRequest loginDetails)
        {
            if (!ValidarUser(loginDetails)) return new AuthResponse();

            var token = GenerateTokenString(loginDetails.Username, DateTime.UtcNow);

            return new AuthResponse
            {
                Name = loginDetails.Username,
                Token = token,
                Expiration = DateTime.UtcNow.AddMinutes(40)
            };
        }

        #region GerarTokens

        /// <summary>
        /// Gerar JWT token!
        /// </summary>
        /// <param name="username"></param>
        /// <param name="expires"></param>
        /// <returns></returns>
        string GenerateTokenString(string username, DateTime expires)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(tokenKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                {
                    new Claim(ClaimTypes.Name, username)
                }),
                Expires = expires.AddMinutes(40),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
        }

        #endregion

        #region ValidaUser

        /// <summary>
        /// Valida Utilizador
        /// </summary>
        /// <param name="loginDetalhes">Username e Password</param>
        /// <returns>True se existir, falso caso contrário</returns>
        private static bool ValidarUser(AuthRequest loginDetalhes)
        {
            bool valid = false;
            try
            {
                //1º ConnectionString
                string cs = "Server=tcp:emsac-isi.database.windows.net,1433;Database=EMSAC;User ID=a19432@emsac-isi;Password=ipca123!;Trusted_Connection=False;Encrypt=True;";

                //2º Conexao a BD
                SqlConnection con = new (cs);

                //3º Query
                string q = "select * from users where username=@username and password=@password";


                //4º Cria comando para permitir executar
                SqlCommand co = new (q, con);

                //Instancia parâmetros
                co.Parameters.Add("@username", SqlDbType.VarChar);
                co.Parameters["@username"].Value = loginDetalhes.Username;

                co.Parameters.Add("@password", SqlDbType.VarChar);
                co.Parameters["@password"].Value = loginDetalhes.Password;

                // Executa e lê dados
                con.Open();
                using (SqlDataReader read = co.ExecuteReader())
                {
                    if (read.Read())
                        valid = true;
                    con.Close();
                }
                return valid;
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                return false;
            }
        }


        #endregion
    }
}
