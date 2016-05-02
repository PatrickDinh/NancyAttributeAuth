using System.Web.Mvc;
using Nancy;

namespace NancyAttributeAuth.Modules
{
    [Authorize]
    public class AuthModule : NancyModule
    {
        public AuthModule()
        {
            Get["/Auth"] = _ =>
            {
                return View["auth"];
            };
        }
    }
}