using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiAcadConnection
{
    /// <summary>
    /// Partial class Startup.
    /// </summary>
    public partial class Startup
    {
        /// <summary>
        /// Startup Configuration.
        /// </summary>
        /// <param name="app"></param>
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}