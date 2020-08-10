using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

namespace WebApiAcadConnection.Extentions
{
    /// <summary>
    /// OwinContextExtentions
    /// </summary>
    public static class OwinContextExtentions
    {
        /// <summary>
        /// Retorna o id do usuário
        /// </summary>
        /// <param name="context"></param>
        public static string getUserId(this IOwinContext context)
        {
            var result = "-1";
            var claim = context.Authentication.User.Claims.FirstOrDefault(c => c.Type == "UsuarioCodigo");
            if (claim != null)
            {
                result = claim.Value;
            }
            return result;
        }
    }
}
