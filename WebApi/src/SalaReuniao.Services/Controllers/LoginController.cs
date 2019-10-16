using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SalaReuniao.Aplicacao.Interface;
using SalaReuniao.Aplicacao.ViewModel;
using SalaReuniao.Services.Model;

namespace SalaReuniao.Services.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        [AllowAnonymous]
        [HttpPost]
        public object Post(
            [FromBody]UsuarioViewModel usuario,
            [FromServices]IUsuarioAppService usuaripoAppService,
            [FromServices]SigningConfigurations signingConfigurations,
            [FromServices]TokenConfigurations tokenConfigurations)
        {

            var usuarioBase = new UsuarioViewModel();
            bool credenciaisValidas = false;
            if (usuario != null && !String.IsNullOrWhiteSpace(usuario.Email))
            {
                usuarioBase = usuaripoAppService.ObterPorEmail(usuario.Email);
                credenciaisValidas = (usuarioBase != null &&
                                      usuario.Email == usuarioBase.Email &&
                                      usuario.Senha == usuarioBase.Senha);
            }

            if (credenciaisValidas)
            {
                ClaimsIdentity identity = new ClaimsIdentity(
                    new GenericIdentity(usuario.UsuarioId.ToString(), "Login"),
                    new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        new Claim(JwtRegisteredClaimNames.UniqueName, usuario.UsuarioId.ToString())
                    }
                );

                identity.AddClaim(new Claim("UsuarioId", usuarioBase.UsuarioId.ToString()));
                identity.AddClaim(new Claim("Username", usuarioBase.Username));
                identity.AddClaim(new Claim("Email", usuarioBase.Email));
                identity.AddClaim(new Claim("Nome", usuarioBase.Nome));
                identity.AddClaim(new Claim("Sobrenome", usuarioBase.Sobrenome));
                identity.AddClaim(new Claim("LoggedOn", DateTime.Now.ToString()));
                /*
                var userRoles = usuarioBase?.Roles;
                foreach (string roleName in userRoles)
                {
                    identity.AddClaim(new Claim(ClaimTypes.Role, roleName));
                }
                */
                DateTime dataCriacao = DateTime.Now;
                DateTime dataExpiracao = dataCriacao +
                                         TimeSpan.FromSeconds(tokenConfigurations.Seconds);

                var handler = new JwtSecurityTokenHandler();
                var securityToken = handler.CreateToken(new SecurityTokenDescriptor
                {
                    Issuer = tokenConfigurations.Issuer,
                    Audience = tokenConfigurations.Audience,
                    SigningCredentials = signingConfigurations.SigningCredentials,
                    Subject = identity,
                    NotBefore = dataCriacao,
                    Expires = dataExpiracao
                });
                var token = handler.WriteToken(securityToken);

                return new
                {
                    authenticated = true,
                    created = dataCriacao.ToString("yyyy-MM-dd HH:mm:ss"),
                    expiration = dataExpiracao.ToString("yyyy-MM-dd HH:mm:ss"),
                    accessToken = token,
                    message = "OK",
                    usuario = usuarioBase
                };
            }
            else
            {
                return new
                {
                    authenticated = false,
                    message = "Falha ao autenticar"
                };
            }
        }

        [AllowAnonymous]
        [HttpPost("registar")]
        public object Registrar(
            [FromBody] UsuarioViewModel usuario,
            [FromServices]IUsuarioAppService usuaripoAppService,
            [FromServices]SigningConfigurations signingConfigurations,
            [FromServices]TokenConfigurations tokenConfigurations)
        {
            return usuaripoAppService.Registar(usuario);
        }

        [HttpGet]
        [Authorize("Bearer")]
        [Route("GetUserClaims")]
        public UsuarioViewModel GetUserClaims([FromServices]IUsuarioAppService usuaripoAppService)
        {
            var identityClaims = (ClaimsIdentity)User.Identity;
            if (identityClaims == null)
                return null;

            var usuarioGuid = Guid.Parse(identityClaims.FindFirst("UsuarioId").Value);

            var model = usuaripoAppService.ObterPorId(usuarioGuid);

            return model;
        }
    }
}