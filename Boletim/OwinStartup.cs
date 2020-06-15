using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.Cookies;

[assembly: OwinStartup(typeof(SistemaBoletim.OwinStartup))]

namespace SistemaBoletim
{
    public class OwinStartup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions()
            {
                AuthenticationType = "ApplicationCookie",
                LoginPath = new PathString("/Administrador/Login"),
                ExpireTimeSpan = TimeSpan.FromMinutes(10)
            });
        }
    }
}
