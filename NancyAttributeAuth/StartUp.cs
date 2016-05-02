using Nancy;
using Nancy.Bootstrapper;
using Nancy.Owin;
using Nancy.TinyIoc;
using Owin;

namespace NancyAttributeAuth
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var bootstrapper = new Bootstrapper();

            app.UseNancy(new NancyOptions
            {
                Bootstrapper = bootstrapper
            });
        }

    }
}