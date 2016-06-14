using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Si.Dev.Uniplac.TrabalhoSC.API.Startup))]

namespace Si.Dev.Uniplac.TrabalhoSC.API
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
