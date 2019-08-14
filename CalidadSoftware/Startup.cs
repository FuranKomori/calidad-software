using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(CalidadSoftware.Startup))]

namespace CalidadSoftware
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
