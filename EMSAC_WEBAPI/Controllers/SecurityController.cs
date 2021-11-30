/*
 * <copyright file="SecurityController.cs" Company = "IPCA - Instituto Politecnico do Cavado e do Ave">
 *      Copyright IPCA-EST. All rights reserved.
 * </copyright>
 * <version>0.1</version>
 *  <user> Joao Ricardo / Carlos Santos </users>
 * <number> 18845 / 19432 <number>                                     
 * <email> a18845@alunos.ipca.pt / a19432@alunos.ipca.pt<email>
 */

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using EMSAC_WEBAPI.Model;

namespace EMSAC_WEBAPI.Controllers
{
    [Route("orders")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        //classe que gera o JWT
        private readonly IJWTAuthManager jWTAuthManager;

        public SecurityController(IJWTAuthManager jWTAuthManager)
        {
            this.jWTAuthManager = jWTAuthManager;

        }

        /// <summary>
        /// Método para Autenticação...não protegido!
        /// </summary>
        /// <param name="loginDetalhes"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("login")]
        public  AuthResponse Login(AuthRequest loginDetalhes)
        {
            AuthResponse token = jWTAuthManager.Authenticate(loginDetalhes);

            if (token.Token == null)
            {
                token.Token = Unauthorized().ToString();
            }

            return token;
        }
    }
}
