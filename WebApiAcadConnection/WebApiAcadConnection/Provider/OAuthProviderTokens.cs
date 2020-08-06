using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using WebApiAcadConnection.DTOs;
using WebApiAcadConnection.Models;

namespace WebApiAcadConnection.Provider
{
    public class OAuthProviderTokens : OAuthAuthorizationServerProvider
    {
        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            return Task.Factory.StartNew(() =>
            {
                var username = context.UserName;
                var password = context.Password;
                var usuarioModel = new UsuarioModel();
                UsuarioDTO usuario = usuarioModel.ConsultarUsuarioPorCredenciais(username, password);
                if (usuario != null)
                {
                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name, usuario.Login),  
                        new Claim("UsuarioCodigo", usuario.Codigo.ToString()),
                        new Claim("UsuarioPerfil", usuario.Perfil.GetValueOrDefault().ToString())
                    };

                    ClaimsIdentity oAutIdentity = new ClaimsIdentity(claims, Startup.OAuthOptions.AuthenticationType);
                    context.Validated(new AuthenticationTicket(oAutIdentity, new AuthenticationProperties() { }));
                }
                else
                {
                    context.SetError("invalid_grant", "Usuário não encontrado ou senha incorreta");
                }
            });
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            if (context.ClientId == null)
            {
                context.Validated();
            }
            return Task.FromResult<object>(null);
        }
    }
}