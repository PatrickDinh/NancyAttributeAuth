using System.Linq;
using System.Web.Mvc;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.Conventions;
using Nancy.Extensions;
using Nancy.Security;
using Nancy.TinyIoc;

namespace NancyAttributeAuth
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void ConfigureConventions(NancyConventions conventions)
        {
            base.ConfigureConventions(conventions);

            conventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("Views"));
        }

        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            pipelines.BeforeRequest += (ctx) =>
            {
                var allModules = GetAllModules(ctx).Where(m => m.RouteExecuting());
                foreach (var module in allModules)
                {
                    var hasAuthorize = module.GetType().GetCustomAttributes(typeof(AuthorizeAttribute), false).FirstOrDefault() != null;
                    if (hasAuthorize && !ctx.CurrentUser.IsAuthenticated())
                    {
                        return new Response { StatusCode = HttpStatusCode.Unauthorized };
                    }
                }

                return null;
            };

        }

    }
}