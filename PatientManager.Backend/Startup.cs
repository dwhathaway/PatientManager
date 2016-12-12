using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(PatientManager.Backend.Startup))]

namespace PatientManager.Backend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}