using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dispatcher;

namespace DoNetExample.Service.config
{
    public class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API routes
            config.MapHttpAttributeRoutes();

            // Enable Cors
            config.EnableCors();

            // Override IHttpControllerTypeResolver implementation
            // Original idea obtain from here: http://www.strathweb.com/2013/02/but-i-dont-want-to-call-web-api-controllers-controller/
            config.Services.Replace(typeof(IHttpControllerTypeResolver), new EndpointControllerTypeResolver());

            // We cleaned the field "ControllerSuffix", which stores the hardcoded controller suffix, “Controller”
            // using reflection.
            var suffix = typeof(DefaultHttpControllerSelector).GetField("ControllerSuffix", BindingFlags.Static | BindingFlags.Public);
            if (suffix != null) suffix.SetValue(null, "Endpoint");

            // Json Formatter Setings
            // Code obtain from here: http://bitoftech.net/2013/11/25/implement-model-factory-dependency-injection-configuring-formatters-web-api/
            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            // Json keys in camel case format
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            // Datetime in new ISO 8601 format
            // Code obtain from here: http://www.hanselman.com/blog/OnTheNightmareThatIsJSONDatesPlusJSONNETAndASPNETWebAPI.aspx
            // jsonFormatter.SerializerSettings.Converters.Add(new IsoDateTimeConverter());
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/plain"));
        }
    }
}