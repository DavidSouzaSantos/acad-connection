using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

namespace WebApiAcadConnection.Extentions
{
    public static class OwinContextExtentions
    {
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
