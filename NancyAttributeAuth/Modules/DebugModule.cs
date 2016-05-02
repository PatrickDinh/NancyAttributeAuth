using Nancy;

namespace NancyAttributeAuth.Modules
{
    public class DebugModule : NancyModule
    {
        public DebugModule()
        {
            Get["/Debug"] = _ => View["debug"];
        }
    }
}