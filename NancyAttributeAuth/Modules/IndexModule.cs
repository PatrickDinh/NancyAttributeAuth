using Nancy;

namespace NancyAttributeAuth.Modules
{
    public class IndexModule : NancyModule
    {
        public IndexModule()
        {
            Get["/"] = _ => View["index"];
        }
    }
}