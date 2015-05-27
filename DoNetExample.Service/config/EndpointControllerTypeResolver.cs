using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace DoNetExample.Service.config
{
    public class EndpointControllerTypeResolver : DefaultHttpControllerTypeResolver
    {
        public EndpointControllerTypeResolver()
            : base(IsHttpEndpoint)
        { }

        internal static bool IsHttpEndpoint(Type t)
        {
            if (t == null) throw new ArgumentNullException("t");
            return t.IsClass && t.IsVisible && !t.IsAbstract && typeof(ApiController).IsAssignableFrom(t) && typeof(IHttpController).IsAssignableFrom(t);
        }
    }
}